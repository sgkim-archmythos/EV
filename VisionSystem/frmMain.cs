using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Diagnostics;
using DevComponents.DotNetBar;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;


using System.IO.Ports;

using DevExpress.XtraSplashScreen;
using Basler.Pylon;
using Cognex.VisionPro.FGGigE;
using System.Data.OleDb;
using Cognex.VisionPro;
using S7.Net;
using MvCamCtrl.NET;

using DevExpress.Utils.Layout;
using System.Globalization;

using Cognex.VisionPro.Display;
using System.Drawing.Imaging;
using DevExpress.XtraEditors;

using System.Data.SqlClient;
using static PLCComm;
using static GlovalVar;
using DevExpress.XtraRichEdit.Model;
using System.Net.Sockets;
using System.Net;
using System.Windows.Media.Media3D;
using DevExpress.XtraRichEdit.Import.Doc;
using DevExpress.Pdf.Native;
using CodeMeter;
using DevExpress.Utils.Extensions;
using VagabondK.Protocols.Logging;



namespace VisionSystem
{

    public partial class frmMain : DevExpress.XtraEditors.XtraForm
    {
        WaitForm1 waitForm = new WaitForm1();

        FluentSplashScreenOptions op;

        frmCamera _frmCamera;  // 카메라 설정
        frmModel _frmModel;
        frmJobList _frmJobList;
        frmComm _frmComm;
        IniFiles ini = new IniFiles();
        frmMDI[] _frmMDI = null;

        public CAM[] _CAM = new CAM[30];
        //public PinCheck _pin = new PinCheck();

        //public CamSet[] _camSet = null;
        bool _bTimeThread; // 현재 시간 
        public int _nCamCnt = 30;

        bool _bChkDrive = false;

        public int _nCamInfo = 0;
        public int _nFindCam = 0;

        public DeviceListControl instDevices = null;
        public PylonCam _cam = null;
        public List<Basler.Pylon.Camera> _Balsercameras = null;
        public List<MyCamera> _Hikcameras = null;
        public List<CameraControl> _KeyenceCameras = null;
        public List<string> _listKeyenceIP = new List<string>();

        public MyCamera.MV_CC_DEVICE_INFO_LIST m_stDeviceList;

        bool _bPassmode = false;

        public string _strRecvData = "";
        public byte[] _Readbytes = null;
        public ushort[] _ReadShort = null;

        bool _bOriginalDelete = false;
        bool _bResultDelete = false;

        bool[] _bGrabEnd = new bool[30];
        bool[] _bInspRes = new bool[30];
        bool[] _bResult = new bool[30];
        string[] _strCamData = null;

        private AdminMode _adminMode = AdminMode.Camera;

        bool _bImgList = false;

        CogDisplay[] _cogDisp = new CogDisplay[20];
        int _nDispNo = -1;
        int _nImgListCamNo = -1;


        //SerialComm _serial = new SerialComm(0);
        bool _bLight = false;

        TCPComponents.TCPSimpleClient _print = null;

        bool _bRobot = false;
        string tempModelData = "";

        SerialPort _LightSerial = new SerialPort();
        SocketUDPClient _LightClient = new SocketUDPClient();

        RobotParam _robotParam = new RobotParam();
        LightParam _LightParam = new LightParam();

        bool _bReTryConn = false;
        string _strResult = "";
        string _strBlob = "";
        string _strTrigger = "";
        public int _indexCountSum = 0;

        keyenceLib _Sensor = new keyenceLib();
        SensorParam _sensorParam = new SensorParam();

        public bool bLabelStatus = false;
        public bool bRibeenStatus = false;
        //DateTime _time;
        string[] _pinShowData;

        public PLCComm _plc = null;


        bool _bServerRead = false;
        bool _bSlaveOpen = false;


        bool _bClientRead = false;

        bool _bRecv = false;

        int _nCamNo = -1;
        bool _bSendImgThread = false;

        int[] _nBuffer = new int[30];
        int[] _nImgSize = new int[30];
        byte[][] _bytes = new byte[30][];

        //bool[] _bInspStart = new bool[30];
        //bool[] _bServInspStart = new bool[30];

        bool[] _bManual = new bool[30];
        bool _bResetCount = false;
        bool _bInspectioning = false;
        string[] _strPinData = new string[30];

        int _nStartPos = 2;
        bool _bReadIO = false;
        short _shDev = -1;

        LabelControl[] _lblIn = new LabelControl[16];
        LabelControl[] _lblOut = new LabelControl[16];

        LabelControl[] _lblInName = new LabelControl[16];
        LabelControl[] _lblOutName = new LabelControl[16];

        static string _strConfigPath = Application.StartupPath + "\\Config";

        char[,] _chLight = new char[2, 8] { { '1', '1', '1', '1', '1', '1', '0', '0' }, { '1', '1', '1', '1', '1', '1', '0', '0' } };


        public frmMain()
        {
            InitializeComponent();

            //ShowInTaskbar = false;
            this.Opacity = 0;

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            var strConnectMode = ini.ReadIniFile("ConnectMode", "Value", Application.StartupPath + "\\Config", "Config.ini");

            _strProcName = ini.ReadIniFile("ProcessName", "Value", Application.StartupPath + "\\Config", "Config.ini");

            DBInfo dbInfo = new DBInfo();
            dbInfo.strIP = ini.ReadIniFile("DBIP", "Value", _strConfigPath, "Config.ini");
            int.TryParse(ini.ReadIniFile("DBPort", "Value", _strConfigPath, "Config.ini"), out dbInfo.nPort);
            dbInfo.strID = ini.ReadIniFile("DBID", "Value", _strConfigPath, "Config.ini");
            dbInfo.strPW = ini.ReadIniFile("DBPW", "Value", _strConfigPath, "Config.ini");
            dbInfo.strDBName = ini.ReadIniFile("DBName", "Value", _strConfigPath, "Config.ini");


            _dbInfo = dbInfo;

            SQL sql = new SQL();

            var strLineInfo = "";
            var nScreenCnt = 0;


            sql.GetLineInfo(_strProcName, _dbInfo, ref strLineInfo);
            sql.GetPGMInfo(_strProcName, _dbInfo, ref nScreenCnt);



            _strLineName = strLineInfo;
            _nScreenCnt = nScreenCnt;



            txtLineInfo.Text = _strLineName;
            txtProcName.Text = _strProcName;
            txtDBIP.Text = _dbInfo.strIP;
            txtDBPort.Text = _dbInfo.nPort.ToString();
            txtDBID.Text = _dbInfo.strID;
            txtDBPW.Text = _dbInfo.strPW;
            txtDBName.Text = _dbInfo.strDBName;




            sql.Dispose();
            InitCam();
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        protected override bool GetAllowSkin()
        {
            if (this.DesignMode) return false;
            return true;
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Loading();
        }

        private void LicenseChk()
        {
            try
            {
                _bVproLic = CogLicense.IsLicenseEnabled(CogLicenseConstants.Blob, false);

                lblLic.Visible = true;

                if (!_bVproLic)
                {
                    lblLic.BackColor = red;
                    lblLic.ForeColor = white;
                    AddMsg(Str.Licensenotactive, red, false, false, MsgType.Alarm);
                }
                else
                {
                    lblLic.BackColor = lime;
                    lblLic.ForeColor = black;
                    AddMsg(Str.LicenseActive, green, false, false, MsgType.Alarm);
                }
            }
            catch { }
        }



        private void Loading()
        {
            string[] strVersion = Application.ProductVersion.Split('.');
            this.Text = string.Format("Vision Inspection [Ver {0}.{1}.{2}]", strVersion[0], strVersion[1], strVersion[2]);



            CreateSplash(true);
            Delay(50);

            var nTotalCnt = 9;
            var nCnt = 1;

            ChangeLanguage();

            LoadingMsg(nCnt++, nTotalCnt, Str.InitControl);
            InitControl();
            Delay(50);

            LoadingMsg(nCnt++, nTotalCnt, Str.Settime);
            _bTimeThread = true;
            Thread threadTime = new Thread(CurrentTime);
            threadTime.Start();
            Delay(50);

            LoadingMsg(nCnt++, nTotalCnt, Str.loadParam);
            LoadSet();
            Delay(50);

            LicenseChk();

            LoadingMsg(nCnt++, nTotalCnt, Str.Camconn);
            CamConnecting();
            Delay(50);

            LoadingMsg(nCnt++, nTotalCnt, Str.Commconn);
            Thread threadCommConnect = new Thread(CommConnect);                                                              //카메라 연결
            threadCommConnect.Start();
            Delay(50);
            nCnt++;



            LoadingMsg(nCnt++, nTotalCnt, Str.chkDrive);
            _bChkDrive = true;
            Thread threadChkDrive = new Thread(DriveSize);
            threadChkDrive.Start();
            Delay(50);
            nCnt++;


            LoadingMsg(nCnt++, nTotalCnt, Str.programstart);
            Delay(50);

            LoadCount();
            CreateSplash(false);



            ActiveControl = lblresultImgsave;

            WindowState = FormWindowState.Maximized;

            BringToFront();

            Opacity = 100;
        }

        private void CreateSplash(bool bShow)
        {

            if (bShow)
            {
                op = null;
                op = new FluentSplashScreenOptions();

                op.Title = "";
                op.Subtitle = "";
                using (Font font = new Font("Tahoma", 10, FontStyle.Bold))
                {
                    op.AppearanceLeftFooter.Font = font;
                    op.AppearanceRightFooter.Font = font;
                }

                using (Font font = new Font("Tahoma", 12, FontStyle.Bold))
                {
                    op.AppearanceSubtitle.Font = font;
                }

                using (Font font = new Font("Tahoma", 30, FontStyle.Bold))
                {
                    op.AppearanceTitle.Font = font;
                }

                op.AppearanceLeftFooter.ForeColor = Color.FromArgb(255, 255, 192);
                op.AppearanceRightFooter.ForeColor = Color.FromArgb(255, 255, 192);
                op.LeftFooter = this.Text;
                op.RightFooter = "Copyright © 2022 Vasim Inc.\nAll Rights reserved.";

                op.LoadingIndicatorType = FluentLoadingIndicatorType.Dots;

                op.Opacity = 130;
                op.OpacityColor = black;
                SplashScreenManager.ShowFluentSplashScreen(op, parentForm: this, useFadeIn: true, useFadeOut: true);
            }
            else
            {
                SplashScreenManager.CloseForm(false);
            }

        }

        private void LoadingMsg(int nCnt, int nTotalCnt, string strMsg)
        {

            op.Title = strMsg;
            op.Subtitle = string.Format("{0:F1}%", ((double)nCnt / (double)nTotalCnt) * 100.0);
            SplashScreenManager.Default.SendCommand(FluentSplashScreenCommand.UpdateOptions, op);

        }

        private void LightConnecting()
        {
            if (string.IsNullOrEmpty(_LightParam.strConnectMode) || string.IsNullOrEmpty(_LightParam.strPortName) || string.IsNullOrEmpty(_LightParam.strBaudrate))
            {
                //lblLight.Visible = false;
                return;
            }

            try
            {
                lblLight.BackColor = red;
                lblLight.ForeColor = white;

                if (_LightParam.strConnectMode == "SERIAL")
                {
                    if (_LightClient != null)
                    {
                        if (_LightClient.Connected)
                        {
                            _LightClient.StopUDPClient();
                            _LightClient = null;
                        }
                    }

                    if (_LightSerial == null)
                        _LightSerial = new SerialPort();

                    if (_LightSerial.IsOpen)
                        _LightSerial.Close();

                    _LightSerial.PortName = _LightParam.strPortName;

                    int.TryParse(_LightParam.strBaudrate, out var nBaudrate);
                    _LightSerial.BaudRate = nBaudrate;
                    _LightSerial.Open();

                    if (_LightSerial.IsOpen)
                    {
                        _bLight = true;

                        SetLightValue();
                        for (int i = 0; i < _LightParam.nChannelNo; i++)
                        {
                            LightOnOff(false, i + 1);
                        }

                        lblLightConStatus1.BackColor = Color.Lime;


                        //AddMsg("조명이 연결 되었습니다.", green, false, false, MsgType.Alarm);
                    }
                    else
                    {
                        //AddMsg("조명이 되지 않았습니다.", red, false, false, MsgType.Alarm);
                    }

                    if (_LightSerial.IsOpen)
                    {
                        if (lblLight.BackColor != lime)
                        {
                            lblLight.Visible = true;
                            lblLight.BackColor = lime;
                            lblLight.ForeColor = black;
                            AddMsg("조명이 연결 되었습니다.", green, false, false, MsgType.Alarm);
                        }
                    }
                    else
                        AddMsg("조명이 되지 않았습니다.", red, false, false, MsgType.Alarm);
                }
                else if (_LightParam.strConnectMode == "UDP")
                {
                    if (_LightSerial != null)
                    {
                        if (_LightSerial.IsOpen)
                        {
                            _LightSerial.Close();
                            _LightSerial = null;
                        }
                    }

                    if (_LightClient == null)
                        _LightClient = new SocketUDPClient();

                    if (_LightClient.Connected)
                        _LightClient.StopUDPClient();

                    int.TryParse(_LightParam.strBaudrate, out var nPort);
                    _LightClient.Connect(_LightParam.strPortName, "", nPort);

                    if (_LightClient.Connected)
                    {
                        _bLight = true;

                        //SetLightValue(nIdx);

                        //for (var i = 0; i < 2; i++)
                        //LightOnOff(nIdx, false, i + 1);

                        //if (_LightClient[0].Connected || _LightClient[1].Connected)
                        //{
                        //    lblLight.BackColor = lime;
                        //    lblLight.ForeColor = black;
                        //    AddMsg("조명이 연결 되었습니다.", green, false, false, MsgType.Alarm);
                        //}
                    }
                    else
                    {
                        //AddMsg("조명이 되지 않았습니다.", red, false, false, MsgType.Alarm);
                    }

                    if (_LightClient.Connected)
                    {
                        if (lblLight.BackColor != lime)
                        {
                            lblLight.BackColor = lime;
                            lblLight.ForeColor = black;
                            AddMsg("조명이 연결 되었습니다.", green, false, false, MsgType.Alarm);
                        }
                    }
                    else
                    {
                        AddMsg("조명이 되지 않았습니다.", red, false, false, MsgType.Alarm);
                    }
                }

            }
            catch (Exception ex)
            {
                AddMsg("조명 연결 오류 : " + ex.Message, red, false, false, MsgType.Alarm);
            }
        }


        private void InitControl()
        {
            for (int i = 0; i < 20; i++)
            {
                _cogDisp[i] = new CogDisplay();
                _cogDisp[i] = Controls.Find(string.Format("cogDisp{0}", i + 1), true).FirstOrDefault() as CogDisplay;
                _cogDisp[i].Tag = i;
                _cogDisp[i].AutoFit = true;
                _cogDisp[i].Image = null;
            }

            AddPort();

            //_serial.DataReceivedHandler = OnLightDataRecive;
            //_serial.MessageHandler = OnLightMessage;

            string[] strIOCardType = Enum.GetNames(typeof(IOCardType));

            cbIODev.Properties.Items.AddRange(strIOCardType);

            string strName = "";
            for (var i = 0; i < 16; i++)
            {
                _lblIn[i] = new LabelControl();
                _lblOut[i] = new LabelControl();

                _lblInName[i] = new LabelControl();
                _lblOutName[i] = new LabelControl();

                _lblIn[i] = Controls.Find(string.Format("lblInStatus{0}", i + 1), true).FirstOrDefault() as LabelControl;
                _lblOut[i] = Controls.Find(string.Format("lblOutStatus{0}", i + 1), true).FirstOrDefault() as LabelControl;

                _lblInName[i] = Controls.Find(string.Format("lblIOIN_{0}", i + 1), true).FirstOrDefault() as LabelControl;
                _lblOutName[i] = Controls.Find(string.Format("lblIOOUT_{0}", i + 1), true).FirstOrDefault() as LabelControl;

                _lblIn[i].Tag = i;
                _lblOut[i].Tag = i;

                _lblInName[i].Tag = i;
                _lblOutName[i].Tag = i;

                strName = ini.ReadIniFile(string.Format("IOInTitle{0}", i + 1), "Value", Application.StartupPath + "\\Config", "Config.ini");
                if (strName != "")
                    _lblInName[i].Text = strName;

                strName = ini.ReadIniFile(string.Format("IOOutTitle{0}", i + 1), "Value", Application.StartupPath + "\\Config", "Config.ini");
                if (strName != "")
                    _lblOutName[i].Text = strName;
            }
        }

        private void OnLightMessage(string strMsg)
        {
            AddMsg("Light Error Message : " + strMsg, red, false, false, MsgType.Alarm);
        }

        private void OnLightDataRecive(byte[] receiveData)
        {
            var strData = Encoding.UTF8.GetString(receiveData);
            //AddMsg("Light Receive Data : " + strData, white, false, false, MsgType.Log);
        }


        private void OnRobotError(object sender, string strErrMsg)
        {
            AddMsg("Robot Error Message : " + strErrMsg, red, false, false, MsgType.Alarm);
        }

        private void AddPort()
        {
            try
            {
                string[] PortNames = SerialPort.GetPortNames();

                if (PortNames.Length == 0)
                    return;

                cbPort_1.Properties.Items.AddRange(PortNames);

                string[] strBaudrate = new string[15] { "110", "300", "600", "1200", "2400", "4800", "9600", "14400", "19200", "38400", "56000", "57600", "115200", "128000", "256000" };
                cbBaud_1.Properties.Items.AddRange(strBaudrate);
                //cbBaud.EditValue = _var._strLightBaudrate;
            }
            catch { }
        }

        private void ShowLog()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            bool bStart = true;

            while (bStart)
            {
                if (sw.ElapsedMilliseconds >= 500)
                {
                    Invoke(new EventHandler(delegate
                    {
                        try
                        {
                            if (!flyLog.IsPopupOpen)
                            {
                                flyLog.ShowPopup();
                                sw.Reset();
                                sw.Start();
                            }
                        }
                        catch { }

                    }));
                }

                if (sw.ElapsedMilliseconds > 2000)
                {
                    Invoke(new EventHandler(delegate
                    {
                        try
                        {
                            if (flyLog.IsPopupOpen)
                            {
                                flyLog.HidePopup();
                                bStart = false;
                            }
                        }
                        catch { }

                    }));
                }
                Thread.Sleep(100);
            }
        }

        private void OnResultImageList(int nIdx)
        {
            if (_nImgListCamNo != nIdx)
            {
                _bImgList = true;
                _nImgListCamNo = nIdx;

                Delay(50);

                Thread threadImgList = new Thread(() => ShowImgList(_nImgListCamNo));
                threadImgList.Start();

                Delay(100);

                if (!flyImgList.IsPopupOpen)
                    flyImgList.ShowPopup();
            }
        }

        private void ShowImgList(int nIdx)
        {
            var nCamNp = nIdx;
            var listResultImg = new List<ICogImage>();

            while (true)
            {
                if (!_bImgList)
                    return;

                if (_CAM[nCamNp].isUpdate)
                {
                    _CAM[nCamNp].isUpdate = false;

                    listResultImg = _CAM[nCamNp].GetResultImg;

                    if (listResultImg != null)
                        ShowResultImgList(listResultImg);
                }

                Thread.Sleep(100);
            }
        }

        private void ShowResultImgList(List<ICogImage> listResultImg)
        {
            try
            {
                Invoke(new EventHandler(delegate
                {
                    for (int i = 0; i < listResultImg.Count; i++)
                    {
                        _cogDisp[i].AutoFit = true;
                        _cogDisp[i].Image = listResultImg[i];
                    }
                }));
            }
            catch { }
        }

        private void ChkInspection()
        {
            int nCnt = 0;
            SQL sql = new SQL();

            try
            {
                for (int i = 0; i < _nScreenCnt; i++)
                {
                    if (_bResult[i])
                        nCnt++;
                }

                var dateTime = DateTime.Now;
                int.TryParse(dateTime.ToString("HH"), out var nHour);

                var nTotalCnt = new int[16];
                var nOKCnt = new int[16];
                var nNGCnt = new int[16];

                var nDailyTotal = new int[24];
                var nDailyOK = new int[24];
                var nDailyNG = new int[24];

                sql.GetDailyCount(_strProcName, _strModelName, false, Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00")), Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:00")), _dbInfo, ref nDailyTotal, ref nDailyOK, ref nDailyNG);
                sql.GetCount(_strProcName, _strModelName, Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd 00:00:00")), Convert.ToDateTime(System.DateTime.Now.ToString("yyyy-MM-dd 23:59:59")), _dbInfo, ref nTotalCnt, ref nOKCnt, ref nNGCnt);

                nDailyTotal[nHour]++;
                nTotalCnt[0]++;

                //_nDailyTOTALCnt[nHour]++;
                //_nTotalCnt++;

                int nRes = 1;

                if (_modelParam[0].bPinChange && _modelParam[1].bPinChange)
                {
                    var strPinData = _strPinData[0] + _strPinData[1];


                    if (_bStartSignal)
                    {
                        if ((_modelParam[0].strPinMaster == _strPinData[0]) && (_modelParam[1].strPinMaster == _strPinData[1]))
                        {
                            nRes = 1;
                        }
                        //else if ((_modelParam[0].strPinMasterResult == _strPinData[0]) && (_modelParam[1].strPinMasterResult == _strPinData[1]))
                        //{
                        //    nRes = 2;
                        //}
                        //else
                        //{
                        //    nRes = 3;
                        //}
                    }
                    else
                    {
                        if ((_modelParam[0].strPinMaster == _strPinData[0]) && (_modelParam[1].strPinMaster == _strPinData[1]))
                        {
                            nRes = 1;
                        }
                        else
                        {
                            nRes = 3;
                        }
                    }
                }
                else
                {
                    if (nCnt == _nScreenCnt)
                        nRes = 1;
                    else
                        nRes = 0;
                }

                Invoke(new EventHandler(delegate
                {
                    if (nRes == 1 || nRes == 2)
                    {
                        nDailyOK[nHour]++;
                        nOKCnt[0]++;

                        lblResult.Text = "OK";
                        lblResult.BackColor = lime;
                        lblResult.ForeColor = black;
                    }
                    else
                    {
                        nDailyNG[nHour]++;
                        nNGCnt[0]++;

                        lblResult.Text = "NG";
                        lblResult.BackColor = red;
                        lblResult.ForeColor = white;
                    }
                }));

                if (_plc != null)
                {
                    Thread threadSendTotalRes = new Thread(() => _plc.SetTotalResult(nRes));
                    threadSendTotalRes.Start();
                }

                for (var i = 0; i < _nScreenCnt; i++)
                {
                    _bInspRes[i] = false;
                    _bResult[i] = false;
                    On_LightOnOff(i, false);
                }

                if (sql != null)
                {
                    var nDaliyCnt = new int[3];

                    nDaliyCnt[0] = nDailyTotal[nHour];
                    nDaliyCnt[1] = nDailyOK[nHour];
                    nDaliyCnt[2] = nDailyNG[nHour];

                    sql.SaveCount(_strProcName, _strModelName, _dbInfo, nTotalCnt, nOKCnt, nNGCnt, dateTime);
                    sql.SetDailyCount(_strProcName, dateTime, _strModelName, _dbInfo, dateTime.ToString("HH"), nDaliyCnt);
                }

                //SetCount();

                _bInspectioning = false;
                sql.Dispose();

                GC.Collect();
            }
            catch (Exception ex)
            {
                AddMsg("Total Chk Error : " + ex.Message, red, false, false, MsgType.Alarm);
            }

        }
        private void CamInspComplete(int nCameraNo, bool bResult, string[] strInspData, bool bManualMode)
        {
            int nCamNo = nCameraNo;
            bool bRes = bResult;
            var strValue = strInspData;
            bool bManual = bManualMode;
            string[] strData = strValue;
            SQL sql = new SQL();

            try
            {
                _bResult[nCamNo] = bRes;
                _bInspRes[nCamNo] = true;


                if (!bManual)
                {
                    _strPinData[nCamNo] = strValue[7];


                    if (_plc != null)
                    {
                        _plc.SetPointResult(nCamNo, bRes, strValue);
                    }


                    int nCnt = 0;
                    for (var i = 0; i < _nScreenCnt; i++)
                    {
                        if (_bInspRes[i])
                            nCnt++;
                    }

                    if (_bResult[nCamNo])
                        AddMsg(string.Format("#{0} Camera {1} : OK({2})", nCamNo + 1, Str.InspResult, strData[0]), green, false, false, MsgType.Log);
                    else
                        AddMsg(string.Format("#{0} Camera {1} : NG({2})", nCamNo + 1, Str.InspResult, strData[0]), red, false, false, MsgType.Log);

                    if (nCnt == _nScreenCnt)
                        ChkInspection();

                    sql.Dispose();
                }
            }
            catch (Exception ex)
            {
                AddMsg("Complete Error : " + ex.Message, red, false, false, MsgType.Alarm);
            }
        }


        private void CamGrabComplete(int nCameraNo)
        {
            var nCamNo = nCameraNo;
            try
            {

                if (_plc != null)
                    _plc.GrabComplete(nCamNo, _nScreenCnt);

            }
            catch { }
        }



        #region CAM Function

        private void CamConnecting()
        {
            try
            {
                if (_CAM == null)
                    _CAM = new CAM[_nCamCnt];

                if (_modelParam == null)
                    _modelParam = new ModelParam[30];

                if (_graphicVproParam == null)
                    _graphicVproParam = new GraphicToolParam[30];

                if (_graphicResParam == null)
                    _graphicResParam = new GraphicResViewParam[30];


                if (_camParam == null)
                    _camParam = new CamPram[30];

                if (_bUsePinchange == true)
                    _frmMDI = new frmMDI[_nCamCnt + 1];
                else
                    _frmMDI = new frmMDI[_nCamCnt];

                for (int i = 0; i < _nScreenCnt; i++)
                {
                    _modelParam[i] = new ModelParam();
                    _graphicVproParam[i] = new GraphicToolParam();
                    _graphicResParam[i] = new GraphicResViewParam();

                    _camParam[i] = new CamPram();

                    CamConn(i);
                }

                Thread threadScreenAlign = new Thread(ScreenAlign);
                threadScreenAlign.Start();

                Delay(100);
            }
            catch (Exception ex)
            {
                AddMsg(Str.CamConnerr + ex.Message, red, false, false, MsgType.Alarm);
            }
        }
        private void CamConn(int nSel)
        {
            int nIdx = nSel;

            SQL sql = new SQL();

            if (_frmMDI[nIdx] == null)
                _frmMDI[nIdx] = new frmMDI(this, nIdx);

            if (_CAM[nIdx] == null)
            {
                _CAM[nIdx] = new CAM(nIdx);
                _CAM[nIdx]._CamSetFunc = CamSetFunc;
                _CAM[nIdx]._OnGrabComplete = CamGrabComplete;
                _CAM[nIdx]._OnInspComplete = CamInspComplete;
                _CAM[nIdx]._OnMessage = Cam_OnMessage;
                _CAM[nIdx]._OnCamDisconnect = CamLostConnected;
                _CAM[nIdx]._OnPositionChange = OnPositionChange;
                _CAM[nIdx]._OnResultImageList = OnResultImageList;
                _CAM[nIdx]._OnLightOnOff = On_LightOnOff;
                _CAM[nIdx]._OnSendImg = OnRecvSendImg;
                _CAM[nIdx]._OnMaualInsption = On_ManualInspection;
                _CAM[nIdx]._OnTitleChange = On_TitleChange;


                _frmMDI[nIdx].Controls.Add(_CAM[nIdx]);
            }

            if (!string.IsNullOrEmpty(_camParam[nIdx].strCopy))
            {
                if (_camParam[nIdx].strCopy != "NONE")
                {
                    var strCopy = _camParam[nIdx].strCopy;
                    int.TryParse(Regex.Replace(strCopy, @"\D", ""), out var nCopy);
                    nCopy--;
                    _camSet[nIdx] = _camSet[nCopy];
                    _camParam[nIdx] = _camParam[nCopy];

                    _camParam[nIdx].strCopy = strCopy;
                }
                else
                {
                    _camSet[nIdx].CamConnect(nIdx, _Balsercameras, _Hikcameras, _KeyenceCameras, _listKeyenceIP, ref _camParam[nIdx]);
                }
            }
            sql.SaveCamInfo(nIdx, _strProcName, DateTime.Now, _camParam[nIdx], _dbInfo);
            sql.Dispose();

            _camSet[nIdx]._GrabComplete = GrabComplete;

            _CAM[nIdx].Dock = DockStyle.Fill;
            _CAM[nIdx].LoadSet();
            _frmMDI[nIdx].Show();
        }

        private void On_TitleChange(int nCamNo, string strName)
        {
            try
            {
                if (_frmMDI[nCamNo] != null)
                    _frmMDI[nCamNo].ChangeName(strName);
            }
            catch { }
        }

        private void On_LightOnOff(int nCamNo, bool bOn)
        {
            try
            {
                if (_modelParam[nCamNo].strLightNo != "")
                {
                    var strTemp = _modelParam[nCamNo].strLightNo.Split(',');

                    if (_shDev == 0)
                    {
                        for (var i = 0; i < strTemp.Length; i++)
                        {
                            if (strTemp[i] != "")
                            {
                                ushort.TryParse(strTemp[i], out var nLightNo);
                                SetIO(bOn, nLightNo);
                            }
                        }
                    }
                    else if (_LightSerial != null || _LightClient != null)
                    {
                        if (strTemp.Length > 0)
                        {
                            for (var i = 0; i < strTemp.Length; i++)
                            {
                                var nIdx = 0;
                                int.TryParse(strTemp[i], out var nChannle);

                                if (strTemp[i] == "2" || strTemp[i] == "3")
                                {
                                    nIdx = 1;
                                    nChannle = nChannle - 2;
                                }

                                LightOnOff(bOn, nChannle + 1);
                            }
                        }
                        else
                        {
                            for (var i = 0; i < 4; i++)
                            {
                                var nIdx = 0;
                                var nChannel = i + 1;

                                if (i > 2)
                                {
                                    nIdx = i;
                                    nChannel = i - 2;
                                }

                                LightOnOff(false, nCamNo + 1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex) { }
        }

        private void On_ManualInspection(int nCameraNo, bool bManaul)
        {
            int nCamNo = nCameraNo;
            _bManual[nCamNo] = bManaul;

            try
            {
                AddMsg("Inspection Start : " + (nCamNo + 1).ToString(), white, false, false, MsgType.Log);
            }
            catch (Exception ex)
            {
                AddMsg("Inspection Start Error : " + ex.Message, red, false, false, MsgType.Alarm);
            }
        }

        private void OnRecvSendImg(int nCameraNo, byte[] bytes)
        {
            _bytes[nCameraNo] = bytes;
        }


        private void CamLostConnected(int nCameraNo)
        {
            var nCamNo = nCameraNo;
            SQL sql = new SQL();

            sql.SaveCamInfo(nCamNo, _strProcName, DateTime.Now, _camParam[nCamNo], _dbInfo);

            sql.Dispose();
            AddMsg(string.Format("#{0} Camera DISCONNECTED", nCamNo + 1), red, false, false, MsgType.Alarm);
        }

        public void GrabComplete(int nSel, Bitmap bmpImg, ICogImage cogImg)
        {
            int nCamNo = nSel;
            ICogImage cogGrabImg = cogImg;
            Bitmap bmpGrab = bmpImg;

            _bGrabEnd[nCamNo] = true;

            try
            {
                Invoke(new EventHandler(delegate
                {
                    if (cogGrabImg == null && bmpGrab == null)
                    {
                        AddMsg("Cam Disconnected", red, false, false, MsgType.Alarm);
                        return;
                    }

                    if (!_CAM[nCamNo]._bLive)
                    {
                        if (_plc.plcParams.strTriggerSignal.Length != 1)
                        {
                            if (_modelParam[nCamNo].strLightNo != "")
                            {
                                var strTemp = _modelParam[nCamNo].strLightNo.Split(',');

                                if (_shDev == 0)
                                {
                                    for (var i = 0; i < strTemp.Length; i++)
                                    {
                                        if (strTemp[i] != "")
                                        {
                                            ushort.TryParse(strTemp[i], out var nLightNo);
                                            SetIO(false, nLightNo);
                                        }
                                    }
                                }
                                else if (_LightSerial != null || _LightClient != null)
                                {

                                    LightOnOff(false, _LightParam.nChannelNo);

                                }
                            }
                        }
                        else
                        {
                            int nEndCnt = 0;
                            int nLightCnt = 0;
                            for (var i = 0; i < _nScreenCnt; i++)
                            {
                                if (_modelParam[i].strLightNo != "")
                                {
                                    nLightCnt++;

                                    if (_bGrabEnd[i])
                                        nEndCnt++;
                                }
                            }

                            if (nLightCnt == nEndCnt)
                            {
                                if (_modelParam[nCamNo].strLightNo != "")
                                {
                                    var strTemp = _modelParam[nCamNo].strLightNo.Split(',');

                                    if (_shDev == 0)
                                    {
                                        for (var i = 0; i < strTemp.Length; i++)
                                        {
                                            if (strTemp[i] != "")
                                            {
                                                ushort.TryParse(strTemp[i], out var nLightNo);
                                                SetIO(false, nLightNo);
                                            }
                                        }
                                    }
                                    else if (_LightSerial != null || _LightClient != null)
                                    {
                                        LightOnOff(false, _LightParam.nChannelNo);

                                    }
                                }
                            }
                        }
                    }

                    Thread threadCamGrab = new Thread(() => _CAM[nCamNo].GrabComplete(nCamNo, (Bitmap)bmpGrab.Clone(), cogGrabImg));
                    threadCamGrab.Start();


                    if (_CAM[nCamNo]._requestMode == RequestMode.AUTO)
                    {
                        if (_plc != null)
                            _plc.GrabComplete(nCamNo, _nScreenCnt);
                    }



                    if (_bPassmode)
                    {
                        Thread.Sleep(100);

                        Thread threadSendResult = new Thread(() => _plc.SetPointResult(nCamNo, true, null));
                        threadSendResult.Start();

                        ChkInspection();
                    }

                }));
            }
            catch (Exception ex)
            {
                AddMsg("GrabFunc Error : " + ex.Message, red, false, false, MsgType.Alarm);
            }
        }
        public void InitCam()
        {
            try
            {
                //lblLic.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;                

                _camSet = new CamSet[_nCamCnt];

                for (int i = 0; i < _nCamCnt; i++)
                {
                    if (_camSet[i] == null)
                    {
                        _camSet[i] = new CamSet();
                        _camSet[i]._nIdx = i;
                    }
                }

                try
                {
                    _cam = new PylonCam();

                    if (_Balsercameras != null)
                        _Balsercameras.Clear();

                    _cam.Init();
                    _Balsercameras = _cam.Connect();
                }
                catch
                {
                    // AddMsg("Basler Cam Init Error : " + ex.Message, red, false, false, MsgType.Alarm);
                }

                try
                {
                    m_stDeviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST();

                    m_stDeviceList.nDeviceNum = 0;
                    int nRet = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref m_stDeviceList);

                    if (m_stDeviceList.nDeviceNum > 0)
                    {
                        _Hikcameras = new List<MyCamera>();

                        MyCamera.MV_CC_DEVICE_INFO device = new MyCamera.MV_CC_DEVICE_INFO();
                        MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = new MyCamera.MV_GIGE_DEVICE_INFO();
                        for (var i = 0; i < m_stDeviceList.nDeviceNum; i++)
                        {
                            device = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(m_stDeviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));
                            gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                            if (gigeInfo.chUserDefinedName.ToLower().Contains("hik"))
                            {
                                var myCamera = new MyCamera();
                                nRet = myCamera.MV_CC_CreateDevice_NET(ref device);
                                nRet = myCamera.MV_CC_OpenDevice_NET();
                                myCamera.MV_CC_SetHeartBeatTimeout_NET(2000);

                                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                                {
                                    int nPacketSize = myCamera.MV_CC_GetOptimalPacketSize_NET();
                                    if (nPacketSize > 0)
                                    {
                                        nRet = myCamera.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                                    }
                                }

                                _Hikcameras.Add(myCamera);
                            }
                        }
                    }
                }
                catch
                {
                    //AddMsg("Hik Cam Init Error : " + ex.Message, red, false, false, MsgType.Alarm);
                }

                //try
                //{
                //    instDevices.FindDevices();
                //    _KeyenceCameras = new List<CameraControl>();
                //    foreach (DeviceListControl.Device device in instDevices.FoundDevices)
                //    {
                //        CameraControl camera = new CameraControl();
                //        bool ret = camera.Connect(device.sIpAddress, instDevices);

                //        camera.SetFeatureValue(device.sIpAddress, "OperationMode", "SetupMode");
                //        bool bRet = camera.AcquisitionStop(device.sIpAddress);
                //        camera.SetFeatureValue(device.sIpAddress, "AcquisitionMode", "SingleFrame");
                //        camera.SetFeatureValue(device.sIpAddress, "ImageCaptureBufferEnable", false);
                //        camera.SetFeatureValue(device.sIpAddress, "TriggerMode", "Off");
                //        camera.SetFeatureValue(device.sIpAddress, "OperationMode", "RunMode");

                //        _listKeyenceIP.Add(string.Format("{0}:{1}:{2}", device.sIpAddress, device.sModelName, device.kglDeviceInfo.getSerialNumber()));
                //        _KeyenceCameras.Add(camera);
                //    }
                //}
                //catch
                //{
                //    //AddMsg("Keyence Cam Init Error : " + ex.Message, red, false, false, MsgType.Alarm);
                //}
            }
            catch (Exception ex)
            {
                AddMsg(Str.initcamerr + ex.Message, red, false, false, MsgType.Alarm);
            }
        }
        private void CamSetOnMessage(string strMsg, Color color)
        {
            AddMsg(strMsg, color, false, false, MsgType.Alarm);
        }
        private void CamSetFunc(int nIdx)
        {
            if (_frmCamera != null)
            {
                _frmCamera.Dispose();
                _frmCamera = null;
            }

            _frmCamera = new frmCamera(this, nIdx);
            _frmCamera.Show();
        }
        #endregion


        private void DriveSize()
        {
            DriveInfo[] drives;
            Stopwatch sw = new Stopwatch();
            string TotalSize = "";
            string freeSize = "";
            string usage = "";
            int nCnt = 0;
            double[] dUsage = new double[2] { 0, 80 };

            sw.Start();
            while (true)
            {
                if (!_bChkDrive)
                    return;

                drives = DriveInfo.GetDrives();

                try
                {
                    Invoke(new EventHandler(delegate
                    {
                        if (sw.ElapsedMilliseconds >= 3000)
                        {
                            sw.Reset();
                            sw.Start();

                            nCnt = 0;

                            foreach (DriveInfo dr in drives)
                            {
                                if (nCnt > 2)
                                    break;
                                if (dr.DriveType == DriveType.Fixed)
                                {
                                    if (dr.Name.Substring(0, 1).ToLower() != "c")
                                    {
                                        TotalSize = Convert.ToInt32(dr.TotalSize / 1024 / 1024 / 1024).ToString();
                                        freeSize = Convert.ToInt32(dr.AvailableFreeSpace / 1024 / 1024 / 1024).ToString();
                                        usage = (Convert.ToInt32(TotalSize) - Convert.ToInt32(freeSize)).ToString();
                                        dUsage[1] = _SaveImgParam._nDiskDelete > 0 ? _SaveImgParam._nDiskDelete : 80;

                                        Invoke(new EventHandler(delegate
                                        {
                                            if (nCnt == 0)
                                            {
                                                dUsage[0] = ((Convert.ToInt32(usage) * 1.0) / (Convert.ToInt32(TotalSize) * 1.0)) * 100;
                                                Bar1.Text = string.Format("{0} : {1:F1}%", dr.Name.Substring(0, 1), dUsage[0]);
                                                Bar1.Value = (int)dUsage[0];

                                                if (dUsage[0] < dUsage[1] - 10.0)
                                                    Bar1.ColorTable = eProgressBarItemColor.Normal;
                                                else if (dUsage[0] > dUsage[1])
                                                    Bar1.ColorTable = eProgressBarItemColor.Error;
                                                else
                                                    Bar1.ColorTable = eProgressBarItemColor.Paused;
                                            }
                                            else if (nCnt == 1)
                                            {
                                                dUsage[0] = ((Convert.ToInt32(usage) * 1.0) / (Convert.ToInt32(TotalSize) * 1.0)) * 100;
                                                Bar2.Text = string.Format("{0} : {1:F1}%", dr.Name.Substring(0, 1), dUsage[0]);
                                                Bar2.Value = (int)dUsage[0];

                                                if (dUsage[0] < dUsage[1] - 10.0)
                                                    Bar2.ColorTable = eProgressBarItemColor.Normal;
                                                else if (dUsage[0] > dUsage[1])
                                                    Bar2.ColorTable = eProgressBarItemColor.Error;
                                                else
                                                    Bar2.ColorTable = eProgressBarItemColor.Paused;
                                            }


                                            if (!string.IsNullOrEmpty(_SaveImgParam._strSaveImagePath))
                                            {
                                                if (dUsage[0] > dUsage[1])
                                                {
                                                    if (dr.Name.Substring(0, 1) == _SaveImgParam._strSaveImagePath.Substring(0, 1))
                                                    {
                                                        if (!_bOriginalDelete)
                                                        {
                                                            _bOriginalDelete = true;
                                                            Thread threadOriginDelete = new Thread(OriginalImageDelete);
                                                            threadOriginDelete.Start();
                                                        }

                                                        if (!_bResultDelete)
                                                        {
                                                            _bResultDelete = true;
                                                            Thread threadResultDelete = new Thread(ResultImageDelete);
                                                            threadResultDelete.Start();
                                                        }
                                                    }
                                                }
                                            }


                                        }));

                                        nCnt++;
                                    }
                                }
                            }

                            if (nCnt == 0)
                            {
                                Bar1.Visible = false;
                                Bar2.Visible = false;
                            }
                            else if (nCnt == 1)
                            {
                                Bar1.Visible = true;
                                Bar2.Visible = false;
                            }
                            else if (nCnt > 1)
                            {
                                Bar1.Visible = true;
                                Bar2.Visible = true;
                            }
                        }
                    }));
                }
                catch { }

                Thread.Sleep(50);
            }
        }
        private void CurrentTime()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            DateTime dateTime = DateTime.Now;

            SQL sql = new SQL();

            while (_bTimeThread)
            {
                if (sw.ElapsedMilliseconds >= 1000)
                {
                    sw.Reset();
                    sw.Start();
                    dateTime = DateTime.Now;
                    Invoke(new EventHandler(delegate
                    {
                        LoadCount();
                    }));
                }
                Thread.Sleep(1);
            }

            sql.Dispose();
        }


        #region Communcation 연결
        public void CommConnect()   //Communication Connect(MX, Simens, IO)
        {
            Invoke(new EventHandler(delegate
            {
                try
                {
                    lblPLC.BackColor = red;
                    lblPLC.ForeColor = white;

                    if (_plc == null)
                    {
                        _plc = new PLCComm();
                        _plc._OnPLCConnect = On_PLCConnect;
                        _plc._OnPLCDisconnect = On_PLCDisconnect;
                        _plc._OnTrigger = OnTrigger;
                        _plc._OnModelChange = OnModelChange;
                        _plc._OnLotNo = OnLotIDReceive;
                        _plc._OnMessage = OnPLCMessage;
                    }
                    lblPLC.Visible = true;
                    _plc.Connect();
                }
                catch (Exception ex)
                {
                    AddMsg("Communication Connect Error : " + ex.Message, red, false, false, MsgType.Alarm);
                }
            }));
        }

        private void OnPLCMessage(string strMsg)
        {
            AddMsg("PLC Message : " + strMsg, red, false, false, MsgType.Alarm);
        }

        private void On_PLCDisconnect()
        {
            Invoke(new EventHandler(delegate
            {
                lblPLC.Visible = true;
                lblPLC.BackColor = red;
                lblPLC.ForeColor = white;
            }));

            AddMsg(Str.plcdisconn, red, false, false, MsgType.Alarm);
        }

        private void On_PLCConnect()
        {
            Invoke(new EventHandler(delegate
            {
                lblPLC.Visible = true;
                lblPLC.BackColor = lime;
                lblPLC.ForeColor = black;
            }));
            AddMsg(Str.plcconn, green, false, false, MsgType.Alarm);

        }

        #endregion


        #region CAM,Communication 데이터 및 저장 위치 로드
        private void LoadSet()
        {
            try
            {
                LoadSaveImgParam();
                LoadPassword();
                LoadModelList();

                LoadLightParam();
                LoadIOParam();

                AddMsg(Str.paramload, green, false, false, MsgType.Alarm);
            }
            catch (Exception ex)
            {
                AddMsg(Str.paramloaderr + ex.Message, red, false, false, MsgType.Alarm);
            }
        }

        private void LoadLightParam()
        {
            try
            {
                SQL sql = new SQL();

                _LightParam.nValue[0] = 0;
                _LightParam.bLightUse = new bool[2];




                sql.GetLightParam(_strProcName, _dbInfo, ref _LightParam);

                if (_LightParam.strConnectMode == "SERIAL")
                {
                    radLightSerial.Checked = true;


                    cbPort_1.EditValue = _LightParam.strPortName;
                    cbBaud_1.EditValue = _LightParam.strBaudrate;

                }
                else if (_LightParam.strConnectMode == "UDP")
                {
                    radLightUDP.Checked = true;


                    txtLightIP_1.Text = _LightParam.strPortName;
                    txtLightPort_1.Text = _LightParam.strBaudrate;

                }


                chkLightUse1.Checked = _LightParam.bLightUse[0];
                chkLightUse2.Checked = _LightParam.bLightUse[1];

                txtValue1.Text = _LightParam.nValue[0].ToString();


                barValue1.Value = _LightParam.nValue[0];


                chkLightUse3.Checked = _LightParam.bLightUse[0];
                chkLightUse4.Checked = _LightParam.bLightUse[1];

                barValue3.Value = _LightParam.nValue[2];


                txtValue3.Text = _LightParam.nValue[2].ToString();



                LightConnecting();




                sql.Dispose();
            }
            catch { }
        }

        private void SaveLightParam()
        {
            try
            {
                if (radLightSerial.Checked)
                {
                    if (cbPort_1.SelectedIndex > -1 && cbBaud_1.SelectedIndex > -1)
                    {
                        _LightParam.strConnectMode = "SERIAL";
                        _LightParam.strPortName = cbPort_1.SelectedItem.ToString();
                        _LightParam.strBaudrate = cbBaud_1.SelectedItem.ToString();
                    }
                    else
                    {
                        _LightParam.strConnectMode = "SERIAL";
                        _LightParam.strPortName = "";
                        _LightParam.strBaudrate = "";
                    }



                }
                else if (radLightUDP.Checked)
                {
                    _LightParam.strConnectMode = "UDP";
                    _LightParam.strPortName = txtLightIP_1.Text;
                    _LightParam.strBaudrate = txtLightPort_1.Text;



                }

                int.TryParse(txtValue1.Text, out _LightParam.nValue[0]);




                _LightParam.bLightUse[0] = chkLightUse1.Checked;
                _LightParam.bLightUse[1] = chkLightUse2.Checked;


                SQL sql = new SQL();
                for (var i = 0; i < 2; i++)
                    sql.SaveLightParam(i, _strProcName, _dbInfo, _LightParam);
                sql.Dispose();

                
                    LightConnecting();

                AddMsg("조명 설정 저장 완료", white, true, false, MsgType.Alarm);
            }
            catch { }
        }

        private void LoadIOParam()
        {
            try
            {
                SQL sql = new SQL();
                sql.GetIOParam(_strProcName, _dbInfo, ref _strIOCardType);
                sql.Dispose();

                cbIODev.EditValue = _strIOCardType;

                ConnectIO();
            }
            catch { }

        }

        private void ConnectIO()
        {
            if (_strIOCardType == "")
                return;

            if (_shDev == -1)
            {
                lblIO.Visible = true;
                lblIO.BackColor = red;
                lblIO.ForeColor = white;
                int nCardType = (int)(IOCardType)Enum.Parse(typeof(IOCardType), _strIOCardType);


                _shDev = DASK.Register_Card((ushort)nCardType, 0);

                if (_shDev == 0)
                {
                    for (var i = 0; i < 16; i++)
                        DASK.DO_WritePort((ushort)_shDev, 0, 0);

                    if (!_bReadIO)
                    {
                        _bReadIO = true;

                        Thread threadReadIO = new Thread(ReadIO);
                        threadReadIO.Start();
                    }

                    lblIO.BackColor = lime;
                    lblIO.ForeColor = black;
                    AddMsg("IO CONNECTED", green, false, false, MsgType.Alarm);
                }
                else
                    AddMsg("IO DISCONNECTED", green, false, false, MsgType.Alarm);
            }
        }

        private void ReadIO()
        {
            uint nCurrentValue = 0;
            uint nValue = 0;
            char[] chData = null;

            while (_bReadIO)
            {
                try
                {
                    if (_shDev == 0)
                    {
                        DASK.DI_ReadPort((ushort)_shDev, 0, out nValue);

                        if (nValue > 0)
                        {
                            if (nCurrentValue != nValue)
                            {
                                nCurrentValue = nValue;
                                chData = Convert.ToString(nCurrentValue, 2).PadLeft(16, '0').ToCharArray();

                                Array.Reverse(chData);
                                SetIOStatus(chData);
                            }
                        }
                    }
                }
                catch { }

                Thread.Sleep(1);
            }
        }

        private void SetIOStatus(char[] chData)
        {
            Invoke(new EventHandler(delegate
            {
                for (var i = 0; i < chData.Length; i++)
                {
                    if (chData[i] == '1')
                    {
                        _lblIn[i].BackColor = lime;
                        _lblIn[i].ForeColor = black;
                        _lblIn[i].Text = "ON";
                    }
                    else
                    {
                        _lblIn[i].BackColor = gray;
                        _lblIn[i].ForeColor = white;
                        _lblIn[i].Text = "OFF";
                    }
                }
            }));
        }

        private void SaveIOParam()
        {
            try
            {
                _strIOCardType = cbIODev.SelectedItem.ToString();
                SQL sql = new SQL();
                sql.SaveIOParam(_strProcName, _dbInfo, _strIOCardType);
                sql.Dispose();

                AddMsg("IO Paramaters Saved", white, true, false, MsgType.Alarm);
                ConnectIO();
            }
            catch { }

        }

        private void LoadSaveImgParam()
        {
            SQL sql = new SQL();
            sql.GetIMGParam(_strProcName, _dbInfo, ref _SaveImgParam);

            if (_SaveImgParam._nDiskDelete == 0)
                _SaveImgParam._nDiskDelete = 80;

            if (_SaveImgParam._OriginImageFormat == IMGFormat.bmp)
                radOriginBMP.Checked = true;
            else
                radOriginJPG.Checked = true;

            if (_SaveImgParam._ResultImageFormat == IMGFormat.bmp)
                radResultBMP.Checked = true;
            else
                radResultJPG.Checked = true;

            swOriginSave.IsOn = _SaveImgParam._bOriginImageSave;
            swResultSave.IsOn = _SaveImgParam._bResultImageSave;
            swAutoImageDelete.IsOn = _SaveImgParam._bAutoImageDelete;

            txtOriginImgRate.Text = _SaveImgParam._nOriginImgCompRate.ToString();
            txtResultImgRate.Text = _SaveImgParam._nResultImgCompRate.ToString();

            txtSaveImagePath.Text = _SaveImgParam._strSaveImagePath;
            txtDiskDelete.Text = _SaveImgParam._nDiskDelete.ToString();

            sql.Dispose();
        }

        private void LoadModelList()
        {
            try
            {
                SQL sql = new SQL();
                var strModelList = "";
                int nModelNo = 0;
                var strLotNo = "";
                sql.GetModelInfo(_strProcName, _dbInfo, ref strModelList, ref nModelNo, ref strLotNo);

                string[] strValue = strModelList.Split(',');

                //listModel.Caption = "";
                lblLotNo.Text = _strLotNo;

                _listModel.Clear();
                listModel.Items.Clear();
                foreach (string str in strValue)
                {
                    if (!string.IsNullOrEmpty(str))
                    {
                        _listModel.Add(str);
                        listModel.Items.Add(str);
                    }
                }

                if (nModelNo > 0)
                {
                    listModel.SelectedIndex = nModelNo - 1;
                    _strModelName = _listModel[nModelNo - 1];

                    listModel.Invalidate();
                }

                int.TryParse(_strModelNo, out var nModelNum);

                //if (nModelNum != nModelNo)
                //    OnModelChange(nModelNo.ToString());

            }
            catch { }

        }

        private void LoadCount()
        {
            var nTotal = new int[16];
            var nOK = new int[16];
            var nNG = new int[16];
            SQL sql = new SQL();
            DateTime dateTimeStart = DateTime.Now;
            DateTime dateTimeEnd = DateTime.Now;
            try
            {
                if ((Convert.ToDateTime(DateTime.Now.ToString("HH:mm")) >= Convert.ToDateTime("00:00")) && (Convert.ToDateTime(DateTime.Now.ToString("HH:mm")) <= Convert.ToDateTime("07:30")))
                {
                    dateTimeStart = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 00:00:00"));
                    dateTimeEnd = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy-MM-dd 23:59:59"));
                }
                else
                {
                    dateTimeStart = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 07:30:00"));
                    dateTimeEnd = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));
                }

                var nTotalCnt = 0;
                var nTotalOKCnt = 0;
                var nTotalNGCnt = 0;

                var nCamTotalCnt = new int[_nScreenCnt];
                var nCamOKCnt = new int[_nScreenCnt];
                var nCamNGCnt = new int[_nScreenCnt];

                for (var i = 0; i < _listModel.Count; i++)
                {
                    Array.Clear(nTotal, 0, nTotal.Length);
                    Array.Clear(nOK, 0, nOK.Length);
                    Array.Clear(nNG, 0, nNG.Length);
                    sql.GetCount(_strProcName, _listModel[i], dateTimeStart, dateTimeEnd, _dbInfo, ref nTotal, ref nOK, ref nNG);

                    nTotalCnt += nTotal[0];
                    nTotalOKCnt += nOK[0];
                    nTotalNGCnt += nNG[0];

                    for (var j = 0; j < _nScreenCnt; j++)
                    {
                        nCamTotalCnt[j] += nTotal[1 + j];
                        nCamOKCnt[j] += nOK[1 + j];
                        nCamNGCnt[j] += nNG[1 + j];
                    }
                }


                double dOKrate = (nTotalCnt > 0) ? ((double)nTotalOKCnt / (double)nTotalCnt) * 100.0 : 0.0;
                double dNGrate = dOKrate > 0.0 ? 100.0 - dOKrate : 0.0; ;

                Invoke(new EventHandler(delegate
                {
                    lblTotalCnt.Text = nTotalCnt.ToString();
                    lblOKCnt.Text = nTotalOKCnt.ToString();
                    lblNGCnt.Text = nTotalNGCnt.ToString();

                    lblOKRate.Text = string.Format("{0:F1}%", dOKrate);
                    lblNGRate.Text = string.Format("{0:F1}%", dNGrate);

                    for (var i = 0; i < _nScreenCnt; i++)
                        _CAM[i].SetCount(nCamTotalCnt[i], nCamOKCnt[i], nCamNGCnt[i]);
                }));
            }
            catch { }



            sql.Dispose();
        }

        private void LoadPassword()
        {
            try
            {
                FileInfo fi = new FileInfo("C:\\ProgramData\\PassWord" + "\\AdminPW.pwd");
                if (fi.Exists)
                    _strAdminPW = ini.ReadIniFile("AdminPW", "Value", "C:\\ProgramData\\PassWord", "AdminPW.pwd");
                else
                    _strAdminPW = "0000";

                fi = new FileInfo("C:\\ProgramData\\PassWord" + "\\OperatorPW.pwd");
                if (fi.Exists)
                    _strOPPW = ini.ReadIniFile("OperatorPW", "Value", "C:\\ProgramData\\PassWord", "OperatorPW.pwd");
                else
                    _strOPPW = "9999";
            }
            catch { }

        }

        #endregion

        #region Log & Alarm

        private void Cam_OnMessage(string strMsg, Color color, bool bShowPopup, bool bError, MsgType msgType)
        {
            AddMsg(strMsg, color, bShowPopup, bError, msgType);
        }
        private void labelControl1_DoubleClick(object sender, EventArgs e)
        {
            listAlarmMsg.Clear();
        }
        private void labelControl3_DoubleClick(object sender, EventArgs e)
        {
            listMsg.Clear();
        }
        public void AddMsg(string strMsg, Color color, bool bShowMsg, bool bError, MsgType msgType)
        {
            SQL sql = new SQL();

            try
            {
                var dateTime = DateTime.Now;
                string strLogMsg = string.Format("[{0}] {1}", dateTime.ToString("HH:mm:ss.fff"), strMsg);

                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        if (msgType == MsgType.Log)
                        {
                            if (listMsg.Lines.Count<object>() > 100)
                                listMsg.Clear();

                            listMsg.SelectionStart = listMsg.TextLength;
                            listMsg.SelectionColor = color;
                            listMsg.AppendText(strLogMsg + "\r\n");
                            listMsg.ScrollToCaret();
                        }
                        else
                        {
                            if (listAlarmMsg.Lines.Count<object>() > 100)
                                listAlarmMsg.Clear();

                            listAlarmMsg.SelectionStart = listAlarmMsg.TextLength;
                            listAlarmMsg.SelectionColor = color;
                            listAlarmMsg.AppendText(strLogMsg + "\r\n");
                            listAlarmMsg.ScrollToCaret();
                        }

                        if (bShowMsg)
                        {
                            if (bError)
                                MessageBox.Show(new Form { TopMost = true }, strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            else
                                MessageBox.Show(new Form { TopMost = true }, strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }));
                }
                else
                {
                    if (msgType == MsgType.Log)
                    {
                        if (listMsg.Lines.Count<object>() > 100)
                            listMsg.Clear();

                        listMsg.SelectionStart = listMsg.TextLength;
                        listMsg.SelectionColor = color;
                        listMsg.AppendText(strLogMsg + "\r\n");
                        listMsg.ScrollToCaret();
                    }
                    else
                    {
                        if (listAlarmMsg.Lines.Count<object>() > 100)
                            listAlarmMsg.Clear();

                        listAlarmMsg.SelectionStart = listAlarmMsg.TextLength;
                        listAlarmMsg.SelectionColor = color;
                        listAlarmMsg.AppendText(strLogMsg + "\r\n");
                        listAlarmMsg.ScrollToCaret();
                    }

                    if (bShowMsg)
                    {
                        if (bError)
                            MessageBox.Show(strMsg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        else
                            MessageBox.Show(strMsg, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                sql.SaveAlarm(_strProcName, _dbInfo, dateTime, msgType.ToString(), strMsg);


            }
            catch { }
        }
        #endregion

        #region Program Close
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show(Str.programexit, Str.exit, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                e.Cancel = true;
            else
                ProgramClose();
        }

        private void ProgramClose()
        {
            Hide();

            CreateSplash(true);
            Delay(50);

            _bReadIO = false;
            _bReTryConn = false;
            _bChkDrive = false;
            _bTimeThread = false;

            //if (_serial.IsOpen)
            //{
            //    LightOnOff(false);
            //    _serial.CloseComm();
            //}

            Application.ExitThread();

            var nTotal = 2;
            var nCnt = 1;

            LoadingMsg(nCnt++, nTotal, Str.camconndis);

            SQL sql = new SQL();

            for (int i = 0; i < _nScreenCnt; i++)
            {
                _CAM[i].CamDisconnect();
                sql.SaveCamInfo(i, _strProcName, DateTime.Now, _camParam[i], _dbInfo);
            }



            sql.Dispose();

            Delay(50);

            LoadingMsg(nCnt++, nTotal, Str.commdis);
            //op.Title = Str.commdis;

            if (_plc != null)
            {
                if (_plc.isConnected)
                    _plc.Disconnect();
            }

            Delay(50);

            if (_Balsercameras != null)
            {
                foreach (Basler.Pylon.Camera cam in _Balsercameras)
                    cam.Close();
            }

            if (_Hikcameras != null)
            {
                foreach (MyCamera cam in _Hikcameras)
                {
                    cam.MV_CC_CloseDevice_NET();
                    cam.MV_CC_DestroyDevice_NET();
                }
            }


            if (_LightSerial != null)
            {
                if (_LightSerial.IsOpen)
                    _LightSerial.Close();
            }

            if (_LightClient != null)
            {
                if (_LightClient.Connected)
                    _LightClient.StopUDPClient();
            }



            if (_shDev == 0)
            {
                DASK.DO_WritePort((ushort)_shDev, 0, 0);
                DASK.Release_Card((ushort)_shDev);
            }

            CreateSplash(false);
            Delay(200);

            Environment.Exit(0);
        }
        #endregion

        #region Button Function
        private void btnSetCam_Click(object sender, EventArgs e)
        {
            if (flyCamCnt.IsPopupOpen)
                flyCamCnt.HideBeakForm();

            if (flyLogin.IsPopupOpen)
            {
                flyLogin.HideBeakForm();
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                flyLogin.OwnerControl = btnSetCam;
                flyLogin.ShowBeakForm();

                txtUser.Focus();
                _adminMode = AdminMode.Camera;
            }
        }

        private void btnSetModel_Click(object sender, EventArgs e)
        {
            if (flyLogin.IsPopupOpen)
            {
                flyLogin.HideBeakForm();
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                flyLogin.OwnerControl = btnSetModel;
                flyLogin.ShowBeakForm();

                //Delay(200);

                txtUser.Focus();
                _adminMode = AdminMode.Model;
            }
        }

        private void bntSetComm_Click(object sender, EventArgs e)
        {
            if (flyLogin.IsPopupOpen)
            {
                flyLogin.HideBeakForm();
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                flyLogin.OwnerControl = bntSetComm;
                flyLogin.ShowBeakForm();

                //Delay(200);

                txtUser.Focus();
                _adminMode = AdminMode.Communication;
            }
        }
        private void btnImgpnlClose_Click(object sender, EventArgs e)
        {
            if (flyImageSet.IsPopupOpen)
                flyImageSet.HidePopup();
        }

        private void bntRecord_Click(object sender, EventArgs e)
        {
            if (flyAdmin.IsPopupOpen)
                flyAdmin.HidePopup();

            Delay(500);

            ShowSplash(true);

            if (_frmJobList != null)
            {
                _frmJobList.Dispose();
                _frmJobList = null;
            }

            _frmJobList = new frmJobList(this);
            _frmJobList.WindowState = FormWindowState.Maximized;
            _frmJobList.Show();

            Delay(100);

            ShowSplash(false);
        }
        private void btnImgSet_Click(object sender, EventArgs e)
        {
            //OnTrigger(0);
            //return;

            if (!flyImageSet.IsPopupOpen)
                flyImageSet.ShowBeakForm();
            else
                flyImageSet.HideBeakForm();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            flyLogin.HideBeakForm();
        }
        #endregion


        #region 트리거 신호
        private void OnTrigger(int nCameraNo, int nTriggerCount)
        {
            int nCamNo = nCameraNo;
            int nTriggerCnt = nTriggerCount;

            try
            {
                _dateTime[nCamNo] = DateTime.Now;

                if (_bUseSensor)
                {
                    //_dateTime[nCamNo] = DateTime.Now;

                    if (nCamNo != 1)
                    {
                        if (_CAM[nCamNo] != null)
                        {
                            _bInspRes[nCamNo] = false;
                            _CAM[nCamNo].InitDisp(false);
                            _CAM[nCamNo].Grab(false, _modelParam[nCamNo].dExpose);

                            AddMsg(string.Format("#{0} Camera Trigger On", nCamNo + 1), yellow, false, false, MsgType.Log);
                        }
                    }
                    if (nCamNo == 1)
                    {
                        Thread.Sleep(2000);
                        _Sensor.TriggerOn();
                        AddMsg(string.Format("#{0} Camera Sensor Trigger On", nCamNo + 1), yellow, false, false, MsgType.Log);
                        return;
                    }
                }
                else
                {
                    _bInspectioning = true;

                    if (nCamNo == 0)
                    {
                        Invoke(new EventHandler(delegate
                        {
                            lblResult.Text = "-";
                            lblResult.BackColor = gray;
                            lblResult.ForeColor = white;
                        }));

                        var dateTime = DateTime.Now;

                        for (var i = 0; i < _nScreenCnt; i++)
                        {
                            _bResult[i] = false;
                            _bInspRes[i] = false;
                            _CAM[i].InitDisp(false);
                            _CAM[i].ChangeStatus(Status.NONE);
                            _dateTime[i] = dateTime;
                            _bGrabEnd[i] = false;
                        }
                    }

                    //if (nTriggerCnt == _nScreenCnt)
                    // {
                    if (_CAM[nCamNo] != null)
                    {

                        Thread threadGrab = new Thread(() => _CAM[nCamNo].Grab(false, _modelParam[nCamNo].dExpose));
                        threadGrab.Start();

                        Thread.Sleep(30);

                        AddMsg(string.Format("#{0} Camera Trigger On", nCamNo + 1), yellow, false, false, MsgType.Log);
                    }

                }
            }
            catch (Exception ex)
            {
                AddMsg("OnTirgger Error : " + ex.Message, red, false, false, MsgType.Alarm);
            }
        }

        #endregion

        #region 데이터 Load
        public void OnModelChange(string strModelNo)
        {
            string strModel = "";
            int nModelNo = 0;

            if (strModelNo != "")
            {
                if (!strModelNo.Contains("_"))
                {
                    int.TryParse(strModelNo, out nModelNo);
                    strModel = string.Format("{0:D2}", nModelNo);
                    nModelNo--;
                }
                else
                    strModel = strModelNo;
            }

            Invoke(new EventHandler(delegate
            {
                try
                {
                    if (strModel != "")
                    {
                        if (_listModel.Count == 0)
                        {
                            ShowSplash(false);
                            AddMsg("등록된 모델이 없습니다.", red, false, false, MsgType.Log);
                            return;
                        }
                    }

                    if (_strModelNo != strModel)
                    {
                        _strModelNo = strModel;

                        ShowSplash(true);
                        if (!strModelNo.Contains("_"))
                        {
                            listModel.SelectedIndex = nModelNo;
                            _strModelName = _listModel[nModelNo];
                        }
                        else
                        {
                            for (var i = 0; i < _listModel.Count; i++)
                            {
                                if (_listModel[i].Contains(strModel))
                                {
                                    listModel.SelectedIndex = i;
                                    _strModelName = _listModel[i];
                                }
                            }
                        }


                        lblModel.Text = _strModelName;

                        listModel.Invalidate();

                        for (int j = 0; j < _nScreenCnt; j++)
                        {
                            _CAM[j].ChangeStatus(Status.NONE);
                            _CAM[j].LoadRecipe(true);
                        }

                        string strTemp = "";
                        for (int i = 0; i < _listModel.Count; i++)
                            strTemp += _listModel[i] + ",";

                        int.TryParse(_strModelNo, out var nModel);
                        SQL sql = new SQL();
                        sql.SaveModelInfo(_strProcName, _dbInfo, strTemp, nModel, _strLotNo);

                        for (var i = 0; i < _nScreenCnt; i++)
                        {
                            _bInspRes[i] = false;
                            _bResult[i] = false;
                        }

                        AddMsg("모델 변경 : " + _strModelName, white, false, false, MsgType.Alarm);
                    }
                }
                catch (Exception ex)
                {
                    AddMsg("모델 변경 오류 : " + ex.Message, red, false, false, MsgType.Alarm);
                }

                ShowSplash(false);
            }));

        }
        private void OnLotIDReceive(string strLotNo)
        {
            Invoke(new EventHandler(delegate
            {
                lblLotNo.Text = strLotNo;
                _strLotNo = strLotNo;
            }));


            ini.WriteIniFile("LotNo", "Value", _strLotNo, _strConfigPath, "Config.ini");
            AddMsg(string.Format("Lot No : {0}", strLotNo), yellow, false, false, MsgType.Log);
        }
        #endregion


        #region Password Function
        private void btnChkPass_Click(object sender, EventArgs e)
        {
            ChkLogin();
        }
        private void ChkLogin()
        {
            if (txtUser.Text == "" && txtPassword.Text == "")
            {
                AddMsg("Please enter your login information.", red, false, false, MsgType.Alarm);
                return;
            }
            SQL sql = new SQL();
            try
            {
                if (sql.Login(_dbInfo, txtUser.Text, txtPassword.Text, ref _userLevel))
                {
                    _strUser = txtUser.Text;
                    AddMsg("Login : " + txtUser.Text, white, false, false, MsgType.Alarm);

                    if (_adminMode == AdminMode.Model)
                    {
                        ShowSplash(true);

                        flyLogin.HideBeakForm();
                        flyAdmin.HidePopup();
                        Delay(500);

                        if (_frmModel != null)
                        {
                            _frmModel.Dispose();
                            _frmModel = null;
                        }

                        _frmModel = new frmModel(this);
                        _frmModel.Show();

                        ShowSplash(false);
                    }
                    else if (_adminMode == AdminMode.Communication)
                    {
                        if (_userLevel == UserLevel.OPERATOR)
                        {
                            AddMsg("You do not have access.", red, false, false, MsgType.Alarm);
                            return;
                        }

                        ShowSplash(true);

                        flyLogin.HideBeakForm();
                        flyAdmin.HidePopup();
                        Delay(500);

                        if (_frmComm != null)
                        {
                            _frmComm.Dispose();
                            _frmComm = null;
                        }

                        _frmComm = new frmComm(this);
                        _frmComm.Show();

                        ShowSplash(false);
                    }
                    else if (_adminMode == AdminMode.Camera)
                    {
                        if (_userLevel == UserLevel.OPERATOR)
                        {
                            AddMsg("You do not have access.", red, false, false, MsgType.Alarm);
                            return;
                        }

                        flyLogin.HideBeakForm();

                        if (!flyCamCnt.IsPopupOpen)
                        {
                            txtCamCnt.Text = "";
                            flyCamCnt.ShowBeakForm();
                            txtCamCnt.Focus();
                        }
                    }
                    else if (_adminMode == AdminMode.Light)
                    {
                        flyLogin.HideBeakForm();

                        if (!flyLight.IsPopupOpen)
                            flyLight.ShowBeakForm();
                        else
                            flyLight.HideBeakForm();
                    }
                    else if (_adminMode == AdminMode.IO)
                    {
                        flyLogin.HideBeakForm();

                        if (flyIO.IsPopupOpen)
                            flyIO.HideBeakForm();
                        else
                            flyIO.ShowBeakForm();
                    }
                    else if (_adminMode == AdminMode.UserManagement)
                    {
                        if (_userLevel == UserLevel.OPERATOR)
                        {
                            AddMsg("You do not have access.", red, false, false, MsgType.Alarm);
                            return;
                        }

                        if (!flyChangePW.IsPopupOpen)
                        {
                            sql = new SQL();

                            try
                            {
                                flyChangePW.ShowPopup();
                                var ds = sql.GetUser(_dbInfo);
                                GetUserList(ds);
                            }
                            catch
                            { }

                            flySetting.HidePopup();

                        }
                        else
                            flyChangePW.HidePopup();
                    }
                }
                else
                {
                    txtUser.Text = "";
                    txtPassword.Text = "";

                    txtUser.Focus();
                    AddMsg("No matching login information found.", red, false, false, MsgType.Alarm);
                }
            }
            catch { }


            sql.Dispose();
        }

        private void GetUserList(DataSet ds)
        {
            dgUser.DataSource = ds.Tables[0];

            if (dgUser.Rows.Count > 0)
            {
                using (Font font = new Font("Tahoma", 13, FontStyle.Bold))
                    dgUser.ColumnHeadersDefaultCellStyle.Font = font;

                dgUser.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgUser.ColumnHeadersHeight = 35;

                dgUser.Columns[0].Visible = false;
                dgUser.Columns[2].Visible = false;

                dgUser.Columns[1].Width = 350;
                dgUser.Columns[3].Width = 200;

                dgUser.Columns[1].HeaderText = "USER ID";
                dgUser.Columns[3].HeaderText = "USER LEVEL";
            }

            ds.Dispose();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChkLogin();
            }
        }
        private void btnPasswordChange_Click(object sender, EventArgs e)
        {
            if (flyLogin.IsPopupOpen)
            {
                flyLogin.HideBeakForm();
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                flyLogin.OwnerControl = btnUserManage;
                flyLogin.ShowBeakForm();

                txtUser.Focus();
                _adminMode = AdminMode.UserManagement;
            }
        }
        private void btnPWClose_Click(object sender, EventArgs e)
        {
            if (flyChangePW.IsPopupOpen)
                flyChangePW.HidePopup();
        }
        private void btnChange_Click(object sender, EventArgs e)
        {
            if (dgUser.CurrentRow.Index == -1)
            {
                AddMsg("비밀번호를 변경할 USER를 선택하여 주십시오", red, true, true, MsgType.Alarm);
                return;
            }

            try
            {
                cbLevel.Properties.Items.Clear();
                string[] strLevel = Enum.GetNames(typeof(UserLevel));
                cbLevel.Properties.Items.AddRange(strLevel);

                txtID.Text = dgUser.Rows[dgUser.CurrentRow.Index].Cells[1].Value.ToString();
                txtID.Enabled = false;

                cbLevel.EditValue = dgUser.Rows[dgUser.CurrentRow.Index].Cells[3].Value.ToString();

                txtPW.Text = "";
                txtChangePW1.Text = "";
                txtChangePW2.Text = "";

                flyUserEdit.ShowPopup();
            }
            catch { }

        }
        private void txtChangePW1_TextChanged(object sender, EventArgs e)
        {
            if (txtChangePW1.Text == "" || txtChangePW2.Text == "")
            {
                lblMatch2.Visible = false;
                return;
            }

            if (txtChangePW1.Text == txtChangePW2.Text)
            {
                lblMatch2.Text = "Match";
                lblMatch2.ForeColor = lime;
            }
            else
            {
                lblMatch2.Text = "Not Match";
                lblMatch2.ForeColor = red;
            }

            lblMatch2.Visible = true;
        }
        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
        }
        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
        }
        #endregion

        #region 화면 정렬 및 추가 

        private void ScreenAlign()
        {
            try
            {
                if (_frmMDI == null)
                    return;

                Invoke(new EventHandler(delegate
                {
                    _nWidth = this.ClientRectangle.Size.Width - 4;
                    _nHeight = this.ClientRectangle.Size.Height - pnl.Height - 29;

                    if (_nScreenCnt > 0 && _nScreenCnt == 1)
                    {
                        _frmMDI[0].WindowState = FormWindowState.Maximized;
                    }
                    else if (_nScreenCnt >= 2)
                    {
                        for (var i = 0; i < _nScreenCnt; i++)
                            _frmMDI[i].WindowState = FormWindowState.Normal;

                        var nWidth = 0;
                        var nHeight = 0;

                        GetScreenCnt(ref nWidth, ref nHeight);

                        int nCol = 0, nRow = 0;

                        int nFormWidth = (_nWidth / nWidth);
                        int nFormHeight = (_nHeight / nHeight);

                        for (int i = 0; i < _nScreenCnt; i++)
                        {
                            _frmMDI[i].Width = nFormWidth;
                            _frmMDI[i].Height = nFormHeight;

                            if (nCol == 0)
                                _frmMDI[i].Location = new Point(nCol * (nFormWidth + 5), nRow * nFormHeight);
                            else
                                _frmMDI[i].Location = new Point((nCol * nFormWidth), nRow * nFormHeight);

                            if (nCol >= nWidth - 1)
                            {
                                nCol = 0;
                                nRow++;
                            }
                            else
                                nCol++;
                        }
                    }
                }));
            }
            catch { }
        }

        private void GetScreenCnt(ref int nWidth, ref int nHeight)
        {
            if (_nScreenCnt == 2)
            {
                nWidth = 2;
                nHeight = 1;
            }
            else if (_nScreenCnt > 2 && _nScreenCnt <= 4)
            {
                nWidth = 2;
                nHeight = 2;
            }
            else if (_nScreenCnt > 4 && _nScreenCnt <= 6)
            {
                nWidth = 3;
                nHeight = 2;
            }
            else if (_nScreenCnt > 6 && _nScreenCnt <= 8)
            {
                nWidth = 4;
                nHeight = 2;
            }
            else if (_nScreenCnt > 8 && _nScreenCnt <= 12)
            {
                nWidth = 4;
                nHeight = 3;
            }
            else if (_nScreenCnt > 12 && _nScreenCnt <= 16)
            {
                nWidth = 5;
                nHeight = 3;
            }
            else if (_nScreenCnt > 16 && _nScreenCnt <= 20)
            {
                nWidth = 5;
                nHeight = 4;
            }
        }
        public void OnPositionChange(int nIdx, PositionType type)
        {
            if (_nScreenCnt < 2)
                return;

            try
            {
                Point point = new Point();

                if (type == PositionType.Next)
                {
                    point.X = _frmMDI[0].Location.X;
                    point.Y = _frmMDI[0].Location.Y;
                }
                else
                {

                }

                if (nIdx == _nScreenCnt - 1)
                {
                    point.X = _frmMDI[0].Location.X;
                    point.Y = _frmMDI[0].Location.Y;

                    _frmMDI[0].Location = new Point(_frmMDI[nIdx].Location.X, _frmMDI[nIdx].Location.Y);
                    _frmMDI[nIdx].Location = point;
                }
                else
                {
                    if (type == PositionType.Next)
                    {
                        if (nIdx + 1 == _nScreenCnt)
                        {
                            point.X = _frmMDI[0].Location.X;
                            point.Y = _frmMDI[0].Location.Y;

                            _frmMDI[0].Location = new Point(_frmMDI[nIdx].Location.X, _frmMDI[nIdx].Location.Y);
                            _frmMDI[nIdx].Location = point;
                        }
                        else
                        {
                            point.X = _frmMDI[nIdx + 1].Location.X;
                            point.Y = _frmMDI[nIdx + 1].Location.Y;

                            _frmMDI[nIdx + 1].Location = new Point(_frmMDI[nIdx].Location.X, _frmMDI[nIdx].Location.Y);
                            _frmMDI[nIdx].Location = point;
                        }
                    }
                    else
                    {
                        if (nIdx == 0)
                        {
                            point.X = _frmMDI[_nScreenCnt - 1].Location.X;
                            point.Y = _frmMDI[_nScreenCnt - 1].Location.Y;

                            _frmMDI[_nScreenCnt - 1].Location = new Point(_frmMDI[nIdx].Location.X, _frmMDI[nIdx].Location.Y);
                            _frmMDI[nIdx].Location = point;
                        }
                        else
                        {
                            point.X = _frmMDI[nIdx - 1].Location.X;
                            point.Y = _frmMDI[nIdx - 1].Location.Y;

                            _frmMDI[nIdx - 1].Location = new Point(_frmMDI[nIdx].Location.X, _frmMDI[nIdx].Location.Y);
                            _frmMDI[nIdx].Location = point;
                        }

                    }
                }
            }
            catch { }
        }
        private void btnCamClose_Click(object sender, EventArgs e)
        {
            if (flyCamCnt.IsPopupOpen)
                flyAdmin.HideBeakForm();

            Delay(200);

            if (flyAdmin.IsPopupOpen)
                flyAdmin.HidePopup();
        }
        private void btnCamAdd_Click(object sender, EventArgs e)
        {
            int.TryParse(txtCamCnt.Text, out int nCnt);

            if (nCnt == 0)
            {
                MessageBox.Show(Str.entercamcnt, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                ShowSplash(true);

                Delay(500);

                int nScreenCnt = _nScreenCnt;
                for (int i = nScreenCnt; i < nScreenCnt + nCnt; i++)
                {
                    _frmMDI[i] = new frmMDI(this, i);
                    _CAM[i] = new CAM(i);
                    _camSet[i]._GrabComplete = GrabComplete;
                    _CAM[i]._CamSetFunc = CamSetFunc;
                    _CAM[i]._OnGrabComplete = CamGrabComplete;
                    _CAM[i]._OnInspComplete = CamInspComplete;
                    _CAM[i]._OnMessage = Cam_OnMessage;
                    _CAM[i]._OnCamDisconnect = CamLostConnected;
                    _CAM[i]._OnPositionChange = OnPositionChange;
                    _CAM[i]._OnResultImageList = OnResultImageList;
                    _CAM[i]._OnLightOnOff = On_LightOnOff;
                    _CAM[i]._OnSendImg = OnRecvSendImg;
                    _CAM[i]._OnMaualInsption = On_ManualInspection;
                    _frmMDI[i].Controls.Add(_CAM[i]);
                    _CAM[i].Dock = DockStyle.Fill;
                    _CAM[i].LoadSet();
                    _frmMDI[i].Show();

                    _nScreenCnt++;
                    //ini.WriteIniFile("ScreenCnt", "Value", _nScreenCnt.ToString(), _strConfigPath, "Config.ini");
                }

                SQL sql = new SQL();
                sql.SavePGMInfo(_strProcName, _dbInfo, _nScreenCnt);

                sql.Dispose();

                Thread threadScreenAlign = new Thread(ScreenAlign);
                threadScreenAlign.Start();

                _bResult = null;
                _bInspRes = null;
                _bResult = new bool[_nScreenCnt];
                _bInspRes = new bool[_nScreenCnt];

                for (int i = 0; i < _nScreenCnt; i++)
                {
                    _bResult[i] = false;
                    _bInspRes[i] = false;
                }

                if (flyCamCnt.IsPopupOpen)
                    flyCamCnt.HideBeakForm();

                if (flyAdmin.IsPopupOpen)
                    flyAdmin.HidePopup();

                Delay(500);

                ShowSplash(false);

                AddMsg(string.Format("{0}님이 카메라를 추가 하였습니다.", txtUser.Text), white, false, false, MsgType.Alarm);

            }
            catch (Exception ex)
            {
                AddMsg("Add Camera Error : " + ex.Message, red, false, false, MsgType.Alarm);
            }
        }
        private void txtCamCnt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCamAdd.PerformClick();
        }
        #endregion

        #region Image 저장 
        private void btnSaveImagePath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
                txtSaveImagePath.Text = dialog.SelectedPath;
        }
        private void radOriginBMP_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                (sender as RadioButton).ForeColor = yellow;
            else
                (sender as RadioButton).ForeColor = white;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {

                _SaveImgParam._bOriginImageSave = swOriginSave.IsOn;
                _SaveImgParam._bResultImageSave = swResultSave.IsOn;
                _SaveImgParam._OriginImageFormat = radOriginBMP.Checked ? IMGFormat.bmp : IMGFormat.jpg;
                _SaveImgParam._ResultImageFormat = radResultBMP.Checked ? IMGFormat.bmp : IMGFormat.jpg;
                _SaveImgParam._strSaveImagePath = txtSaveImagePath.Text;
                int.TryParse(txtOriginImgRate.Text, out _SaveImgParam._nOriginImgCompRate);
                int.TryParse(txtResultImgRate.Text, out _SaveImgParam._nResultImgCompRate);
                _SaveImgParam._bAutoImageDelete = swAutoImageDelete.IsOn;

                SQL sql = new SQL();
                sql.SaveIMGParam(_strProcName, _dbInfo, _SaveImgParam);
                sql.Dispose();

                _paramCode = ParamCode.SaveImgParamChage;

                AddMsg(Str.imgParamsave, green, true, false, MsgType.Alarm);
            }
            catch (Exception ex)
            {
                AddMsg(Str.imgparamnotsave + ex.Message, red, true, true, MsgType.Alarm);
            }
        }
        #endregion

        #region 데이터 Clear
        private void btnReset_Click(object sender, EventArgs e)
        {
            if (flyAdmin.IsPopupOpen)
                flyAdmin.HidePopup();

            ShowSplash(false);
            Delay(100);
            for (int i = 0; i < _nScreenCnt; i++)
            {
                _CAM[i].ChangeStatus(Status.NONE);
                _CAM[i].InitDisp(true);

                _bytes[i] = null;
                //_CAM[i]._bytes.Clear();

                if (_bInspRes != null)
                    _bInspRes[i] = false;

                //Delay(20);
            }
        }
        #endregion 

        #region 언어
        public void ChangeLanguage()
        {
            if (_Language == Language.Korean)
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("ko-KR");
                SetTextLanguage();
            }
            else
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
                SetTextLanguage();
            }
        }

        private void SetTextLanguage()
        {
            //lblModelTitle.Caption = Str.Model;
            //lblLotTitle.Caption = Str.LotNo;
            //btnAdmin.Caption = Str.Menu;
            //btnLog.Caption = Str.Log;
            btnReset.Text = Str.Reset;

            btnSetting.Text = Str.Setting;
            bntRecord.Text = Str.Record;
            btnSetCam.Text = Str.AddCamera;
            btnSetModel.Text = Str.ModelSetting;
            bntSetComm.Text = Str.CommunicationSetting;

            btnUserEdit.Text = Str.Change;
            btnPWClose.Text = Str.Close;
            btnChkPass.Text = Str.Check;
            btnClose.Text = Str.Close;
            btnUserManage.Text = Str.PasswordChange;
            lblPW.Text = Str.Password;
            lblCamCnt.Text = Str.CameraCount;
            btnCamAdd.Text = Str.Add;
            btnUserAdd.Text = Str.Add;
            btnUserDel.Text = Str.Delete;
            btnImgSet.Text = Str.SaveImgSet;
            btnCamClose.Text = Str.Close;
            //btnSave.Text = Str.Save;
            //lblCurrentPW.Text = Str.Currentpassword;
            lblEnterPW.Text = Str.EnterPassword;
            lblReenterPW.Text = Str.ReenterPasswrod;

            lblOriginImgPath.Text = Str.ImageSavePath;
            lblOriginImgsave.Text = Str.OriginImgSave;
            lblOriginImgformat.Text = Str.OriginalImageSaveFormat;
            lblresultImgsave.Text = Str.ResultImageSave;
            lblresultImgformat.Text = Str.ResultImageSaveFormat;

            waitForm.progressPanel1.Caption = Str.WaitMsg;
            waitForm.progressPanel1.Description = Str.Loading;
        }
        #endregion


        private void frmMain_Resize(object sender, EventArgs e)
        {
            Thread threadScreenAlign = new Thread(ScreenAlign);
            threadScreenAlign.Start();
        }

        #region Image 20 History
        private void btnPrevious_Click(object sender, EventArgs e)
        {
            if (_nImgListCamNo == -1)
                return;

            try
            {
                if (_nDispNo == 0)
                    _nDispNo = 19;
                else
                    _nDispNo--;


                //for (var i = 0; i < 20; i++)
                //    _Pnl[i].Invalidate();

                cogDispOrigin.AutoFit = true;
                cogDispResult.AutoFit = true;

                if (_CAM[_nImgListCamNo].GetOriginImg != null)
                    cogDispOrigin.Image = _CAM[_nImgListCamNo].GetOriginImg[_nDispNo];

                if (_CAM[_nImgListCamNo].GetResultImg != null)
                    cogDispResult.Image = _CAM[_nImgListCamNo].GetResultImg[_nDispNo];
            }
            catch { }
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            if (_nImgListCamNo == -1)
                return;

            try
            {
                if (_nDispNo == 19)
                    _nDispNo = 0;
                else
                    _nDispNo++;


                //for (var i = 0; i < 20; i++)
                //    _Pnl[i].Invalidate();

                cogDispOrigin.AutoFit = true;
                cogDispResult.AutoFit = true;

                if (_CAM[_nImgListCamNo].GetOriginImg != null)
                    cogDispOrigin.Image = _CAM[_nImgListCamNo].GetOriginImg[_nDispNo];

                if (_CAM[_nImgListCamNo].GetResultImg != null)
                    cogDispResult.Image = _CAM[_nImgListCamNo].GetResultImg[_nDispNo];
            }
            catch { }
        }

        private void btnListClose_Click(object sender, EventArgs e)
        {
            flyResImg.HideBeakForm();
        }
        #endregion



        private void btnLightSetting_Click(object sender, EventArgs e)
        {
            if (flyLogin.IsPopupOpen)
            {
                flyLogin.HideBeakForm();
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                flyLogin.OwnerControl = btnLightSetting;
                flyLogin.ShowBeakForm();

                txtUser.Focus();
                _adminMode = AdminMode.Light;
            }
        }

        static string STX = "\x02";
        static string ETX = "\x03";
        static string CR = "\x0D";
        static string LF = "\x0A";
        static string O = "\x4F";
        static string V = "\x56";
        static string W = "\x57";

        private void LightAllOn(bool bLightOn, int nChannel)                                      // 조명 전체 On Off 함수.
        {
            bool bOn = bLightOn;

            try
            {
                if (_LightSerial.IsOpen)
                {
                    int startchnnel = 1; //01 = 시작번지 채널 12 = 채널 갯수
                    int nValue = 0;
                    string strValue = "";
                    int nCnt = 0;


                    for (int i = 0; i < nChannel; i++)
                    {
                        if (bOn)
                        {
                            if (_LightParam.bLightUse[i])
                            {
                                nValue = 1;
                                strValue += nValue.ToString("X2");
                                nCnt++;

                            }
                        }
                        else
                        {
                            if (_LightParam.bLightUse[i])
                            {
                                nValue = 0;
                                strValue += nValue.ToString("X2");
                                nCnt++;
                            }
                        }
                    }


                    _LightSerial.Write(STX + O + W + startchnnel.ToString("X2") + nCnt.ToString("X2") + strValue + CR + LF);


                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void LightOnOff(bool bLightOn, int nChannel)                                       // 조명 On Off 함수.
        {
            if (!_LightSerial.IsOpen)
            {
                return;
            }

            var bOn = bLightOn;

            LightAllOn(bOn, nChannel);
        }

        private void SetLightValue()                                    // 조명 값 설정 함수.
        {
            int nChannel = _LightParam.nChannelNo;
            int startchnnel = 1;

            for (int i = 0; i < nChannel; i++)
            {
                int nValue = _LightParam.nValue[i];
                try
                {
                    if (_LightSerial.IsOpen)
                    {
                        string strSendMsg = string.Format("{0:X2}", startchnnel + i); //01 = 시작번지 채널 12 = 채널 갯수
                        string strValue = nValue.ToString("X2");
                        int ncount = 1;
                        _LightSerial.Write(STX + V + W + strSendMsg + ncount.ToString("X2") + strValue + CR + LF);
                    }
                }

                catch (Exception ex)
                {

                    throw;
                }

            }


        }


        #region File Delete
        public void ImageDelete(string path)
        {
            string strImagePath = path;

            DirectoryInfo dirInfo = new DirectoryInfo(strImagePath);
            DirectoryInfo[] dirInfoYear;
            DirectoryInfo[] dirInfoMonth;
            DirectoryInfo[] dirInfoDay;
            DirectoryInfo[] dirResult;
            DirectoryInfo[] dirInfoModelData;
            DirectoryInfo[] dirInfoCam;

            try
            {
                dirInfoYear = dirInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);                   //경로내 년도 파일
                dirInfoMonth = dirInfoYear[0].GetDirectories("*", SearchOption.TopDirectoryOnly);           //년도 파일 내 월 파일

                if (dirInfoMonth.Length == 0)
                    dirInfoYear[0].Delete(true);
                else
                {
                    dirInfoDay = dirInfoMonth[0].GetDirectories("*", SearchOption.TopDirectoryOnly);           //월 파일 내 일 파일

                    if (dirInfoDay.Length == 0)
                        dirInfoMonth[0].Delete(true);
                    else
                    {
                        dirResult = dirInfoDay[0].GetDirectories("*", SearchOption.TopDirectoryOnly);           //일 파일 내 Model Data 파일

                        if (dirInfoDay.Length == 0)
                            dirInfoMonth[0].Delete(true);
                        else
                        {
                            dirInfoModelData = dirResult[0].GetDirectories("*", SearchOption.TopDirectoryOnly);
                            if (dirInfoModelData.Length == 0)
                                dirInfoDay[0].Delete(true);
                            else
                            {
                                DirectoryInfo dirDel = new DirectoryInfo(dirInfoModelData[0].FullName);
                                dirDel.Delete(true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //AddMsg("ImageDelete Err : " + ex.ToString(), Color.Red, false, false, MsgType.Alarm);
            }
        }
        public void FileCopyToJPG(string parentPath)
        {
            DirectoryInfo parentPathInfo = new DirectoryInfo(parentPath);
            string _PathInfo = parentPath.Replace("OriginImage", "ConvertImage");

            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
            EncoderParameters myEncoderParameters = new EncoderParameters(1);
            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 60L);
            myEncoderParameters.Param[0] = myEncoderParameter;
            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            double width, height = 0;
            //

            try
            {
                FileInfo[] bmpFiles = parentPathInfo.GetFiles();
                Directory.CreateDirectory(_PathInfo);

                foreach (FileInfo bmpFile in bmpFiles)
                {

                    if (bmpFile.Extension.ToLower() == ".bmp")
                    {
                        byte[] raw = File.ReadAllBytes(bmpFile.FullName);
                        string jpgFileFullName = _PathInfo + "\\" + bmpFile.Name.Substring(0, bmpFile.Name.LastIndexOf('.')) + ".jpg";
                        FileInfo jpgFile = new FileInfo(jpgFileFullName);
                        using (Image img = Image.FromStream(new MemoryStream(raw)))
                        {
                            if (!jpgFile.Exists)
                            {
                                Bitmap bmp1 = new Bitmap(img);
                                bmp1.Save(jpgFileFullName, jpgEncoder, myEncoderParameters);
                            }
                        }
                    }
                    else if (bmpFile.Extension.ToLower() == ".jpg")
                    {
                        FileInfo jpgFile = new FileInfo(bmpFile.FullName);

                        jpgFile.CopyTo(_PathInfo + "\\" + bmpFile.Name);
                    }

                    File.Delete(bmpFile.FullName);
                }

            }
            catch (Exception ex)
            {
                //MessageBox.Show("<ERROR > <AutoImagesBackup >FileCopyToJPG Function : " + ex.Message);
            }
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {

            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }
        #endregion

        private void btnBackupDelete_Click(object sender, EventArgs e)
        {
            //결과 삭제
            ResultImageDelete();
        }
        private void ResultImageDelete()
        {
            ImageDelete(_SaveImgParam._strSaveImagePath + "\\ResultImage\\" + _strProcName);
            _bResultDelete = false;
        }
        private void OriginalImageDelete()
        {
            ImageDelete(_SaveImgParam._strSaveImagePath + "\\OriginImage\\" + _strProcName);
            _bOriginalDelete = false;
        }
        private void btnOriginalDelete_Click(object sender, EventArgs e)
        {
            //원본 삭제
            OriginalImageDelete();
        }






        public void ShowSplash(bool bShow)
        {
            if (bShow)
            {
                if (!splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.ShowWaitForm();
            }
            else
            {
                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
            }
        }


        private void radNetwork_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                (sender as RadioButton).ForeColor = yellow;
            else
                (sender as RadioButton).ForeColor = white;
        }


        private void btnSetting_Click(object sender, EventArgs e)
        {
            if (flySetting.IsPopupOpen)
                flySetting.HidePopup();
            else
                flySetting.ShowPopup();
        }

        private void btnSetClose_Click(object sender, EventArgs e)
        {
            flySetting.HidePopup();
        }

        private void btnSetSave_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();
            try
            {
                _strLineName = txtLineInfo.Text;
                _strProcName = txtProcName.Text;
                _dbInfo.strIP = txtDBIP.Text;
                int.TryParse(txtDBPort.Text, out _dbInfo.nPort);
                _dbInfo.strID = txtDBID.Text;
                _dbInfo.strPW = txtDBPW.Text;
                _dbInfo.strDBName = txtDBName.Text;



                ini.WriteIniFile("DBIP", "Value", _dbInfo.strIP, _strConfigPath, "Config.ini");
                ini.WriteIniFile("DBPort", "Value", _dbInfo.nPort.ToString(), _strConfigPath, "Config.ini");
                ini.WriteIniFile("DBID", "Value", _dbInfo.strID, _strConfigPath, "Config.ini");
                ini.WriteIniFile("DBPW", "Value", _dbInfo.strPW, _strConfigPath, "Config.ini");
                ini.WriteIniFile("DBName", "Value", _dbInfo.strDBName, _strConfigPath, "Config.ini");

                ini.WriteIniFile("ProcessName", "Value", _strProcName, Application.StartupPath + "\\Config", "Config.ini");


                sql.SaveLineInfo(_strLineName, _strProcName, _dbInfo);
                sql.SaveDBInfo(_strProcName, _dbInfo);

                AddMsg("Finished saving db information", green, true, false, MsgType.Alarm);
            }
            catch { }

            sql.Dispose();
        }

        private void btnIOClose_Click(object sender, EventArgs e)
        {
            flyIO.HideBeakForm();
        }

        private void btnIOSave_Click(object sender, EventArgs e)
        {
            SaveIOParam();
        }

        private void btnIOSetting_Click(object sender, EventArgs e)
        {
            if (flyLogin.IsPopupOpen)
            {
                flyLogin.HideBeakForm();
            }
            else
            {
                txtUser.Text = "";
                txtPassword.Text = "";
                flyLogin.OwnerControl = btnIOSetting;
                flyLogin.ShowBeakForm();

                //Delay(200);

                txtUser.Focus();
                _adminMode = AdminMode.IO;
            }
        }

        private void lblOutStatus1_Click(object sender, EventArgs e)
        {
            var strTag = (sender as LabelControl).Tag.ToString();

            if (strTag != "")
            {
                int.TryParse(strTag, out var nNo);

                if (_lblOut[nNo].Text == "OFF")
                    SetIO(true, nNo);
                else
                    SetIO(false, nNo);
            }
        }

        private void SetIO(bool bOn, int nLine)
        {
            if (_shDev == 0)
            {
                Invoke(new EventHandler(delegate
                {
                    if (bOn)
                    {
                        if (_lblOut[nLine].Text == "OFF")
                        {
                            _lblOut[nLine].BackColor = lime;
                            _lblOut[nLine].ForeColor = black;
                            _lblOut[nLine].Text = "ON";
                        }

                        DASK.DO_WriteLine((ushort)_shDev, 0, (ushort)nLine, 1);
                    }
                    else
                    {
                        if (_lblOut[nLine].Text == "ON")
                        {
                            _lblOut[nLine].BackColor = gray;
                            _lblOut[nLine].ForeColor = white;
                            _lblOut[nLine].Text = "OFF";
                        }

                        DASK.DO_WriteLine((ushort)_shDev, 0, (ushort)nLine, 0);
                    }

                }));
            }
        }

        private void btnUserAdd_Click(object sender, EventArgs e)
        {
            if (flyUserEdit.IsPopupOpen)
            {
                flyUserEdit.HidePopup();
            }
            else
            {
                txtID.Text = "";
                txtPW.Text = "";

                lblPassword.Visible = false;
                txtPW.Visible = false;

                txtChangePW1.Text = "";
                txtChangePW2.Text = "";

                cbLevel.Properties.Items.Clear();
                string[] strLevel = Enum.GetNames(typeof(UserLevel));
                cbLevel.Properties.Items.AddRange(strLevel);
                cbLevel.SelectedIndex = 0;

                flyUserEdit.ShowPopup();
            }
        }

        private void btnUserChk_Click(object sender, EventArgs e)
        {
            SQL sql = new SQL();

            try
            {
                if (txtID.Enabled)
                {
                    if (txtID.Text == "")
                    {
                        AddMsg("Please enter your ID.", red, true, true, MsgType.Alarm);
                        return;
                    }

                    if (txtChangePW1.Text != txtChangePW2.Text)
                    {
                        AddMsg("Password does not match.", red, true, true, MsgType.Alarm);
                        return;
                    }

                    if (sql.UserChk(_dbInfo, txtID.Text))
                    {
                        AddMsg("Duplicate ID found.", red, true, true, MsgType.Alarm);
                        return;
                    }
                    else
                    {
                        if (MessageBox.Show("Do you want to add users?", "User Add", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                            return;

                        sql.UserAdd(_dbInfo, txtID.Text, txtChangePW1.Text, cbLevel.EditValue.ToString());
                        flyUserEdit.HidePopup();

                        AddMsg(string.Format("User : {0} 가 User ID : {1} 를 추가 하였습니다.", _strUser, txtID.Text), white, false, false, MsgType.Alarm);
                    }
                }
                else
                {
                    string strPW = dgUser.Rows[dgUser.CurrentRow.Index].Cells[2].Value.ToString();
                    if (txtPW.Text != strPW)
                    {
                        AddMsg("The current password does not match.", red, true, true, MsgType.Alarm);
                        return;
                    }

                    if (txtChangePW1.Text != txtChangePW2.Text)
                    {
                        AddMsg("Password does not match.", red, true, true, MsgType.Alarm);
                        return;
                    }

                    sql.UserEdit(_dbInfo, txtID.Text, txtChangePW1.Text, cbLevel.EditValue.ToString());
                    flyUserEdit.HidePopup();

                    AddMsg(string.Format("User : {0} 가 User ID : {1} 를 수정 하였습니다.", _strUser, txtID.Text), white, false, false, MsgType.Alarm);
                }

                var ds = sql.GetUser(_dbInfo);
                GetUserList(ds);
            }
            catch { }

            sql.Dispose();

        }

        private void btnUserEditClose_Click(object sender, EventArgs e)
        {
            flyUserEdit.HidePopup();
        }

        private void listModel_DrawItem(object sender, ListBoxDrawItemEventArgs e)
        {
            if (listModel.Items.Count == 0)
                return;

            var nidx = 0;
            foreach (string strModel in _listModel)
            {
                if (strModel == _strModelName)
                    break;

                nidx++;
            }

            if (nidx == e.Index)
            {
                // e.Appearance.BackColor = white;
                e.Appearance.ForeColor = yellow;
            }
        }

        private void listModel_DoubleClick(object sender, EventArgs e)
        {
            if (listModel.SelectedIndex == -1)
                return;

            flyList.HideBeakForm();
            Delay(500);

            if (listModel.Items[listModel.SelectedIndex].ToString().Contains("("))
            {
                var strModel = listModel.Items[listModel.SelectedIndex].ToString().Split('(');
                var strModelName = strModel[1].Replace(")", "");

                OnModelChange(strModelName);
            }
            else
            {
                OnModelChange((listModel.SelectedIndex + 1).ToString());
            }
        }

        private void lblModel_Click(object sender, EventArgs e)
        {
            if (flyList.IsPopupOpen)
                flyList.HideBeakForm();
            else
                flyList.ShowBeakForm();
        }

        private void btnMenu_Click(object sender, EventArgs e)
        {
            if (!flyAdmin.IsPopupOpen)
                flyAdmin.ShowPopup();
            else
                flyAdmin.HidePopup();
        }

        private void btnLog_Click(object sender, EventArgs e)
        {
            if (!flyLog.IsPopupOpen)
                flyLog.ShowPopup();
            else
                flyLog.HidePopup();
        }

        private void btnProgClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnHome_Click(object sender, EventArgs e)
        {
            Hide();
        }


        private void btnLightSave_Click(object sender, EventArgs e)
        {
            SaveLightParam();
        }

        private void btnLightClose_Click(object sender, EventArgs e)
        {
            flyLight.HideBeakForm();
        }

        private void swOn1_Toggled(object sender, EventArgs e)
        {
            var Tag = (sender as ToggleSwitch).Tag.ToString();

            try
            {
                bool bOn = false;
                if ((sender as ToggleSwitch).IsOn)
                    bOn = true;

                if (Tag == "0")
                    LightOnOff(bOn, 1);
                else if (Tag == "1")
                    LightOnOff(bOn, 2);
                else if (Tag == "2")
                    LightOnOff(bOn, 3);
                else if (Tag == "3")
                    LightOnOff(bOn, 4);
            }
            catch { }
        }

        private void txtValue1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var Tag = (sender as TextEdit).Tag.ToString();

                    int.TryParse((sender as TextEdit).Text, out var nValue);

                    if (Tag == "0")
                        barValue1.Value = nValue;
                    else if (Tag == "1")
                        barValue2.Value = nValue;
                    else if (Tag == "2")
                        barValue3.Value = nValue;
                    else if (Tag == "3")
                        barValue4.Value = nValue;
                }
            }
            catch { }
        }

        private void barValue1_EditValueChanged(object sender, EventArgs e)
        {
            try
            {
                var Tag = (sender as TrackBarControl).Tag.ToString();
                int.TryParse(Tag, out var nNo);


                _LightParam.nValue[nNo] = (sender as TrackBarControl).Value;

                if (Tag == "0")
                    txtValue1.Text = (sender as TrackBarControl).Value.ToString();
                else if (Tag == "1")
                    txtValue2.Text = (sender as TrackBarControl).Value.ToString();
                else if (Tag == "2")
                    txtValue3.Text = (sender as TrackBarControl).Value.ToString();
                else if (Tag == "3")
                    txtValue4.Text = (sender as TrackBarControl).Value.ToString();


                SetLightValue();
            }
            catch { }
        }


        private void radLightTCP_CheckedChanged(object sender, EventArgs e)
        {
            var Tag = (sender as RadioButton).Tag.ToString();
            if ((sender as RadioButton).Checked)
            {
                (sender as RadioButton).ForeColor = yellow;

                if (Tag == "0")
                {
                    cbPort_1.Visible = true;
                    cbBaud_1.Visible = true;



                    txtLightIP_1.Visible = false;
                    txtLightPort_1.Visible = false;


                }
                else
                {
                    cbPort_1.Visible = false;
                    cbBaud_1.Visible = false;


                    txtLightIP_1.Visible = true;
                    txtLightPort_1.Visible = true;

                }
            }
            else
                (sender as RadioButton).ForeColor = white;
        }

        private void chkLightUse1_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckEdit).Checked)
                (sender as CheckEdit).ForeColor = yellow;
            else
                (sender as CheckEdit).ForeColor = white;
        }

        private void lblIOIN_1_Click(object sender, EventArgs e)
        {
            try
            {
                var strTag = (sender as LabelControl).Tag.ToString();
                int.TryParse(strTag, out var nNum);

                var strName = XtraInputBox.Show("Please enter the I/O IN Name", "I/O Name", "");

                if (strName != "")
                {
                    _lblInName[nNum].Text = strName;
                    ini.WriteIniFile(string.Format("IOInTitle{0}", nNum + 1), "Value", strName, Application.StartupPath + "\\Config", "Config.ini");
                }
            }
            catch { }
        }

        private void lblIOOUT_1_Click(object sender, EventArgs e)
        {
            try
            {
                var strTag = (sender as LabelControl).Tag.ToString();
                int.TryParse(strTag, out var nNum);

                var strName = XtraInputBox.Show("Please enter the I/O OUT Name", "I/O Name", "");

                if (strName != "")
                {
                    _lblOutName[nNum].Text = strName;
                    ini.WriteIniFile(string.Format("IOOutTitle{0}", nNum + 1), "Value", strName, Application.StartupPath + "\\Config", "Config.ini");


                }
            }
            catch { }
        }

        private void btnImgListClose_Click(object sender, EventArgs e)
        {
            if (flyImgList.IsPopupOpen)
                flyImgList.HidePopup();
        }

        private void btnSetDLpath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();

            if (fbd.ShowDialog() == DialogResult.OK)
                lblDLpath.Text = fbd.SelectedPath;
        }

        private void btnSetDlFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Python files (*.pt)|*.pt|All files (*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
                lblDLFile.Text = ofd.FileName;
        }
    }
}
