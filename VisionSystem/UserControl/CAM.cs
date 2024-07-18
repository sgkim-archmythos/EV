using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using DevExpress.XtraEditors;

using System.IO;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolBlock;
using System.Drawing.Imaging;
using static GlovalVar;
using LBSoft.IndustrialCtrls.Leds;

using DevExpress.XtraRichEdit.Internal.PrintLayout;
using System.Diagnostics;
using DevExpress.Pdf.Native;
using DevExpress.XtraEditors.Popup;
using Cognex.VisionPro.ID;
using System.Security.Cryptography;
using DevExpress.CodeParser;

namespace VisionSystem
{
    public delegate void CamSetHandler(int nIdx);
    public delegate void CamGrabCompleteHandler(int nIdx);
    public delegate void CamInspCompleteHandler(int nIdx, bool bRes, string[] strData, bool bManualMode);
    public delegate void MessageHaldler(string strMsg, Color color, bool bShoPopup, bool bError, MsgType msgType);
    public delegate void PositionChangeHandler(int nIdx, PositionType type);
    public delegate void CamDisconnectHandler(int nIdx);
    public delegate void CamBCRData(int nIdx, string strBCRData);
    public delegate void ResultImageListHandler(int nIdx);
    public delegate void SensorTrigger();
    public delegate void SnesorModelChange(int index);
    public delegate void OnSendImg(int nCamNo, byte[] bytes);
    public delegate void OnGrabRequest(int nCamNo, bool bManual);
    public delegate void OnMaualInsption(int nCamNo, bool bManualMode);
    public delegate void OnLIghtOnOff(int nCamNo, bool bOn);
    public delegate void OnTitleChange(int nCamNo, string strName);

    public partial class CAM : DevExpress.XtraEditors.XtraUserControl
    {
        public CamSetHandler _CamSetFunc;
        public CamGrabCompleteHandler _OnGrabComplete;
        public CamInspCompleteHandler _OnInspComplete;
        public CamBCRData _onBCRData;
        public MessageHaldler _OnMessage;
        public PositionChangeHandler _OnPositionChange;
        public ResultImageListHandler _OnResultImageList;
        public SensorTrigger _OnSensorTrigger;
        public SnesorModelChange _OnSensorModelChange;
        public OnSendImg _OnSendImg;
        public CamDisconnectHandler _OnCamDisconnect;
        //public OnGrabRequest _OnGrabRequest;
        public OnMaualInsption _OnMaualInsption;
        public OnLIghtOnOff _OnLightOnOff;
        public OnTitleChange _OnTitleChange;

        public int _nIdx = -1;
        //public CamSet _camSet = new CamSet();
        public bool _bLive = false;
        //public GlovalVar _var;

        //IniFiles ini = new IniFiles();
        frmToolEdit _frmToolEdit;


        public VproInspection _vPro = null;

        public bool _bLicense = false;
        public bool _bManual = false;

        public int _nPos = 0;
        bool _bJobLoad = false;

        //public int _nTotal = 0;
        //public int _nOK = 0;
        //public int _nNG = 0;

        //public DateTime _dateTime;

        bool[] _bvProUse = null;
        CheckEdit[] _chkVproUse = null;
        ComboBoxEdit[] _cbVproOKColor = null;
        ComboBoxEdit[] _cbVproNGColor = null;
        ComboBoxEdit[] _cbVProLine = null;
               
        

        public ICogImage _cogGrabImg = null;

        Font font = new Font("Tahoma", 11, FontStyle.Regular);
        Font font1 = new Font("Tahoma", 11, FontStyle.Bold);

        public bool _bCamUse = false;
        public bool _bPassMode = false;

        private int nGrabCnt = 0;

        List<ICogImage> _listOriginImg = new List<ICogImage>();
        List<ICogImage> _listResultImg = new List<ICogImage>();
        private bool _bUpdate = false;

        bool _bLoad = false;

        bool _bSensor = false;
        frmNGPopup _ngPopup = new frmNGPopup();
        public bool _bpopup = false;

        bool _bVppInspRes = false;
      
        bool _bVppInspEnd = false;
        //bool _bPythonRes = false;
        //bool _bPythonEnd = false;

        public bool _bInspStart = false;
        public bool _bInspRes = false;
        public bool _bInspEnd = false;

        public string _strInspData = "";

        public string _strResImgFile = ""; //Server 용

        //public RequestMode _Request = RequestMode.NONE;

        public List<byte[]> _bytes = new List<byte[]>();
        public ushort[] _usResImg = null; // 클라이언트용

        ICogImage _cogSaveImg = null;
        ICogImage _cogSendImg = null;

        Result _result = Result.NONE;



        public bool _bGrabStart = false;
        public bool _bGrabEnd = false;

        public RequestMode _requestMode = RequestMode.NONE;

        bool _bResData = false;
        List<CogGraphicLabel> _coglblResData = null;



        public CAM(int nCameraNo)
        {
            InitializeComponent();
            _nIdx = nCameraNo;
            LoadCamParam();
            LoadRecipe(true);
        }


        public ICogImage SendImg
        {
            set { _cogSendImg = value; }
            get { return _cogSendImg; }
        }

        public List<ICogImage> GetOriginImg
        {
            get { return _listOriginImg; }
        }

        public List<ICogImage> GetResultImg
        {
            get { return _listResultImg; }
        }

        public bool isUpdate
        {
            get { return _bUpdate; }
            set { _bUpdate = value; }
        }

        public void SetMenuPosition(int nWidth)
        {
            lblMenu.Location = new Point(nWidth - lblMenu.Width - 20, 32);
        }

        public void LoadSet()
        {
            pnlRes.Dock = DockStyle.Fill;
            //tpDisp.Dock = DockStyle.Fill;
            lblMenu.Location = new Point(this.Width - lblMenu.Width - 20, 32);
            lblConnect.Text = string.Format("#{0}", _nIdx + 1);

            if (_camParam[_nIdx].bConnect)
            {
                lblConnect.BackColor = Color.Lime;
                lblConnect.ForeColor = Color.Black;
                _OnMessage(string.Format("#{0} Camera Connected", _nIdx + 1), Color.GreenYellow, false, false, GlovalVar.MsgType.Alarm);
            }
            else
            {
                lblConnect.BackColor = Color.Red;
                lblConnect.ForeColor = Color.White;
                _OnMessage(string.Format("#{0} Camera Disconnected", _nIdx + 1), Color.Red, false, false, MsgType.Alarm);
            }

            _camSet[_nIdx]._OnCamLostConnect = OnCamLostConnected;

            LoadModelImage();
            SetGraphicview();

            _bLoad = true;
        }

        public void CamStatus(bool bConnect)
        {
            if (bConnect != _camParam[_nIdx].bConnect)
            {
                _camParam[_nIdx].bConnect = bConnect;
                ChangeStatus(Status.NONE);
                Invoke(new EventHandler(delegate
                {
                    if (_camParam[_nIdx].bConnect)
                    {
                        lblConnect.BackColor = Color.Lime;
                        lblConnect.ForeColor = Color.Black;
                        _OnMessage(string.Format("#{0} Camera Connected", _nIdx + 1), Color.GreenYellow, false, false, GlovalVar.MsgType.Alarm);
                    }
                    else
                    {
                        lblConnect.BackColor = Color.Red;
                        lblConnect.ForeColor = Color.White;
                        _OnMessage(string.Format("#{0} Camera Disconnected", _nIdx + 1), Color.Red, false, false, MsgType.Alarm);
                    }
                }));
            }
        }

        private void OnCamLostConnected()
        {
            _camParam[_nIdx].bConnect = false;

            if (_OnCamDisconnect != null)
                _OnCamDisconnect(_nIdx);
        }

        public void LoadCamParam()
        {
            try
            {
                SQL sql = new SQL();
                sql.GetCamInfo(_strProcName, _nIdx, _dbInfo, ref _camParam[_nIdx]);
                sql.Dispose();
            }
            catch (Exception ex)
            {
            }
        }

        public void SaveCamParam()
        {
            try
            {
                SQL sql = new SQL();
                sql.SaveCamInfo(_nIdx, _strProcName, DateTime.Now, _camParam[_nIdx], _dbInfo);
                sql.Dispose();

                int.TryParse(_camParam[_nIdx].strCamType, out var nCamType);
                _camSet[_nIdx].SaveParam((CameraInterface)nCamType);

            }
            catch { }
        }

        public void LoadRecipe(bool bChange)
        {
            string strValue = "";

            try
            {
                _modelParam[_nIdx] = new ModelParam();

                SQL sql = new SQL();
                sql.GetRecipe(_strProcName, _dbInfo, _nIdx, _strModelName, ref _modelParam[_nIdx]);

               

                ModelChange(bChange);
                SetGraphicview();
                //LoadGraphicParam();

                if (_OnMessage != null)
                    _OnMessage(string.Format("#{0} Model Change Complete", _nIdx + 1), green, false, false, MsgType.Alarm);
            }
            catch (Exception ex)
            {
                if (_OnMessage != null)
                    _OnMessage("Recipe Load Error : " + ex.Message, red, false, false, MsgType.Alarm);
            }
        }

        public void SensorConnect()
        {
            Invoke(new EventHandler(delegate
            {
                _bSensor = true;

                _camParam[_nIdx].bConnect = true;
                lblConnect.BackColor = Color.Lime;
                lblConnect.ForeColor = Color.Black;
                _OnMessage(string.Format("#{0} Sensor Connected", _nIdx + 1), Color.GreenYellow, false, false, MsgType.Alarm);

            }));
        }


        public void SetGraphicview()
        {
            try
            {
                //if (_strModelName == "ST01")
                //    return;

                Invoke(new EventHandler(delegate
                {
                    LoadGraphicParam();

                    string[] strColor = new string[6] { "Green", "Yellow", "Blue", "Cyan", "Magenta", "Red" };
                    string[] strLine = new string[10] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };

                    if (!string.IsNullOrEmpty(_graphicResParam[_nIdx].strAlign))
                        cbAlign.EditValue = _graphicResParam[_nIdx].strAlign;
                    else
                        cbAlign.SelectedIndex = 0;

                    if (_graphicResParam[_nIdx].nFontSize != 0)
                        txtFontSize.Text = _graphicResParam[_nIdx].nFontSize.ToString();
                    else
                        txtFontSize.Text = "15";

                    if (_graphicResParam[_nIdx].dPosX != 0)
                        txtGraphicPosX.Text = _graphicResParam[_nIdx].dPosX.ToString();
                    else
                        txtGraphicPosX.Text = "50";

                    if (_graphicResParam[_nIdx].dPosY != 0)
                        txtGraphicPosY.Text = _graphicResParam[_nIdx].dPosY.ToString();
                    else
                        txtGraphicPosY.Text = "50";

                    if (_graphicResParam[_nIdx].nSubFontSize != 0)
                        txtSubFontSize.Text = _graphicResParam[_nIdx].nSubFontSize.ToString();
                    else
                        txtSubFontSize.Text = "15";

                    if (_graphicResParam[_nIdx].dSubPosX != 0)
                        txtGraphicSubPosX.Text = _graphicResParam[_nIdx].dSubPosX.ToString();
                    else
                        txtGraphicSubPosX.Text = "50";

                    if (_graphicResParam[_nIdx].dSubPosY != 0)
                        txtGraphicSubPosY.Text = _graphicResParam[_nIdx].dSubPosY.ToString();
                    else
                        txtGraphicSubPosY.Text = "50";


                    if (_vPro != null)
                    {

                        int nCnt = _vPro.GetJob.Tools.Count;
                        var nListCnt = 0;

                        for (var i = 0; i < _vPro.GetJob.Tools.Count; i++)
                        {
                            if (_vPro.GetJob.Tools[i].GetType() == typeof(CogToolBlock))
                                nCnt += (_vPro.GetJob.Tools[i] as CogToolBlock).Tools.Count + 1;
                        }

                        if (cbOKColor.Properties.Items.Count == 0)
                            cbOKColor.Properties.Items.AddRange(strColor);

                        if (cbNGColor.Properties.Items.Count == 0)
                            cbNGColor.Properties.Items.AddRange(strColor);

                        if (cbAllLine.Properties.Items.Count == 0)
                            cbAllLine.Properties.Items.AddRange(strLine);

                        //SetControl(InspType.Vpro, nCnt);
                        _bvProUse = new bool[nCnt];

                        _chkVproUse = new CheckEdit[nCnt];
                        _cbVproOKColor = new ComboBoxEdit[nCnt];
                        _cbVproNGColor = new ComboBoxEdit[nCnt];
                        _cbVProLine = new ComboBoxEdit[nCnt];

                        scVproBar.Controls.Clear();


                        if (_graphicVproParam[_nIdx].bUse == null)
                        {
                            _graphicVproParam[_nIdx].strName = new string[nCnt];
                            _graphicVproParam[_nIdx].bUse = new bool[nCnt];
                            _graphicVproParam[_nIdx].strOKColor = new string[nCnt];
                            _graphicVproParam[_nIdx].strNGColor = new string[nCnt];
                            _graphicVproParam[_nIdx].nLineThick = new int[nCnt];

                        }





                        for (int i = 0; i < nCnt; i++)
                        {
                            _chkVproUse[i] = new CheckEdit();
                            _cbVproOKColor[i] = new ComboBoxEdit();
                            _cbVproNGColor[i] = new ComboBoxEdit();
                            _cbVProLine[i] = new ComboBoxEdit();

                            _bvProUse[i] = false;

                            if (_vPro.GetJob.Tools[nListCnt].GetType() != typeof(CogToolBlock))
                            {


                                scVproBar.Controls.Add(_chkVproUse[nListCnt]);
                                _chkVproUse[nListCnt].Font = font1;
                                _chkVproUse[nListCnt].Size = new Size(250, 24);
                                _chkVproUse[nListCnt].Text = _vPro.GetJob.Tools[nListCnt].Name;
                                _chkVproUse[nListCnt].Location = new Point(15, 6 + (nListCnt * 28));
                                _chkVproUse[nListCnt].CheckedChanged += new System.EventHandler(chkUse_CheckedChanged);

                                scVproBar.Controls.Add(_cbVproOKColor[nListCnt]);
                                _cbVproOKColor[nListCnt].Font = font1;
                                _cbVproOKColor[nListCnt].Location = new Point(cbOKColor.Location.X, 5 + (nListCnt * 28));
                                _cbVproOKColor[nListCnt].Size = new Size(cbOKColor.Width, 24);
                                _cbVproOKColor[nListCnt].Properties.AppearanceDropDown.Font = font1;
                                _cbVproOKColor[nListCnt].Properties.Items.AddRange(strColor);
                                _cbVproOKColor[nListCnt].SelectedIndex = 0;

                                scVproBar.Controls.Add(_cbVproNGColor[nListCnt]);
                                _cbVproNGColor[nListCnt].Font = font1;
                                _cbVproNGColor[nListCnt].Location = new Point(cbNGColor.Location.X, 5 + (nListCnt * 28));
                                _cbVproNGColor[nListCnt].Size = new Size(cbNGColor.Width, 24);
                                _cbVproNGColor[nListCnt].Properties.AppearanceDropDown.Font = font1;
                                _cbVproNGColor[nListCnt].Properties.Items.AddRange(strColor);
                                _cbVproNGColor[nListCnt].SelectedIndex = 0;

                                scVproBar.Controls.Add(_cbVProLine[nListCnt]);
                                _cbVProLine[nListCnt].Font = font1;
                                _cbVProLine[nListCnt].Location = new Point(cbAllLine.Location.X, 5 + (nListCnt * 28));
                                _cbVProLine[nListCnt].Size = new Size(cbAllLine.Width, 24);
                                _cbVProLine[nListCnt].Properties.AppearanceDropDown.Font = font1;
                                _cbVProLine[nListCnt].Properties.Items.AddRange(strLine);
                                _cbVProLine[nListCnt].SelectedIndex = 0;

                                for (var j = 0; j < _graphicVproParam[_nIdx].strName.Length; j++)
                                {
                                    if (_graphicVproParam[_nIdx].strName[j] == _vPro.GetJob.Tools[nListCnt].Name)
                                    {
                                        _chkVproUse[nListCnt].Checked = _graphicVproParam[_nIdx].bUse[j];
                                        _cbVproOKColor[nListCnt].EditValue = string.IsNullOrEmpty(_graphicVproParam[_nIdx].strOKColor[j]) ? "" : _graphicVproParam[_nIdx].strOKColor[j];
                                        _cbVproNGColor[nListCnt].EditValue = string.IsNullOrEmpty(_graphicVproParam[_nIdx].strNGColor[j]) ? "" : _graphicVproParam[_nIdx].strNGColor[j];
                                        _cbVProLine[nListCnt].SelectedIndex = _graphicVproParam[_nIdx].nLineThick[j];
                                    }
                                }

                                nListCnt++;
                            }
                            else
                            {
                                scVproBar.Controls.Add(_chkVproUse[nListCnt]);
                                _chkVproUse[nListCnt].Font = font1;
                                _chkVproUse[nListCnt].Location = new Point(15, 6 + (nListCnt * 28));
                                _chkVproUse[nListCnt].Size = new Size(250, 24);
                                _chkVproUse[nListCnt].Text = _vPro.GetJob.Tools[nListCnt].Name;

                                var nNum = nListCnt;
                                nListCnt++;

                                for (var j = 0; j < (_vPro.GetJob.Tools[nNum] as CogToolBlock).Tools.Count; j++)
                                {


                                    scVproBar.Controls.Add(_chkVproUse[nListCnt]);
                                    _chkVproUse[nListCnt].Font = font1;
                                    _chkVproUse[nListCnt].Size = new Size(250, 24);
                                    _chkVproUse[nListCnt].Text = (_vPro.GetJob.Tools[nNum] as CogToolBlock).Tools[j].Name;
                                    _chkVproUse[nListCnt].Location = new Point(30, 6 + (nListCnt * 28));
                                    _chkVproUse[nListCnt].CheckedChanged += new System.EventHandler(chkUse_CheckedChanged);

                                    scVproBar.Controls.Add(_cbVproOKColor[nListCnt]);
                                    _cbVproOKColor[nListCnt].Font = font1;
                                    _cbVproOKColor[nListCnt].Location = new Point(cbOKColor.Location.X, 5 + (nListCnt * 28));
                                    _cbVproOKColor[nListCnt].Size = new Size(cbOKColor.Width, 24);
                                    _cbVproOKColor[nListCnt].Properties.AppearanceDropDown.Font = font1;
                                    _cbVproOKColor[nListCnt].Properties.Items.AddRange(strColor);
                                    _cbVproOKColor[nListCnt].SelectedIndex = 0;

                                    scVproBar.Controls.Add(_cbVproNGColor[nListCnt]);
                                    _cbVproNGColor[nListCnt].Font = font1;
                                    _cbVproNGColor[nListCnt].Location = new Point(cbNGColor.Location.X, 5 + (nListCnt * 28));
                                    _cbVproNGColor[nListCnt].Size = new Size(cbNGColor.Width, 24);
                                    _cbVproNGColor[nListCnt].Properties.AppearanceDropDown.Font = font1;
                                    _cbVproNGColor[nListCnt].Properties.Items.AddRange(strColor);
                                    _cbVproNGColor[nListCnt].SelectedIndex = 0;

                                    scVproBar.Controls.Add(_cbVProLine[nListCnt]);
                                    _cbVProLine[nListCnt].Font = font1;
                                    _cbVProLine[nListCnt].Location = new Point(cbAllLine.Location.X, 5 + (nListCnt * 28));
                                    _cbVProLine[nListCnt].Size = new Size(cbAllLine.Width, 24);
                                    _cbVProLine[nListCnt].Properties.AppearanceDropDown.Font = font1;
                                    _cbVProLine[nListCnt].Properties.Items.AddRange(strLine);
                                    _cbVProLine[nListCnt].SelectedIndex = 0;

                                    for (var k = 0; k < _graphicVproParam[_nIdx].strName.Length; k++)
                                    {
                                        if (_graphicVproParam[_nIdx].strName[k] == _vPro.GetJob.Tools[nListCnt].Name)
                                        {
                                            _chkVproUse[nListCnt].Checked = _graphicVproParam[_nIdx].bUse[k];
                                            _cbVproOKColor[nListCnt].EditValue = string.IsNullOrEmpty(_graphicVproParam[_nIdx].strOKColor[k]) ? "" : _graphicVproParam[_nIdx].strOKColor[k];
                                            _cbVproNGColor[nListCnt].EditValue = string.IsNullOrEmpty(_graphicVproParam[_nIdx].strNGColor[k]) ? "" : _graphicVproParam[_nIdx].strNGColor[k];
                                            _cbVProLine[nListCnt].SelectedIndex = _graphicVproParam[_nIdx].nLineThick[k];
                                        }
                                    }

                                    nListCnt++;
                                }
                            }
                        }
                    }

                }));
            }
            catch (Exception ex)
            {
                if (_OnMessage != null)
                {
                    _OnMessage("Set Graphicview Error : " + ex.ToString(), Color.Red, false, false, MsgType.Alarm);
                }
            }
        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckEdit).Checked)
                (sender as CheckEdit).ForeColor = Color.Yellow;
            else
                (sender as CheckEdit).ForeColor = Color.White;
        }

        public void SetCount(int nTotal, int nOKCnt, int nNGCnt)
        {
            if (InvokeRequired)
            {
                Invoke(new EventHandler(delegate
                {
                    lblTotal.Text = nTotal.ToString();
                    lblOK.Text = nOKCnt.ToString();
                    lblNG.Text = nNGCnt.ToString();
                }));
            }
            else
            {
                lblTotal.Text = nTotal.ToString();
                lblOK.Text = nOKCnt.ToString();
                lblNG.Text = nNGCnt.ToString();
            }
        }


        //[STAThread]
        public void GrabComplete(int nSel, Bitmap bmpImg, ICogImage cogImage)
        {
            int nIdx = nSel;
            try
            {
                Invoke(new EventHandler(delegate
                {
                    cogDisp.AutoFit = true;
                    cogResDisp.AutoFit = true;


                    var cogImg = cogImage.CopyBase(CogImageCopyModeConstants.CopyPixels);

                    if (cogImg != null)
                    {
                        cogDisp.Image = cogImg;
                        cogResDisp.Image = cogImg;



                        if (!_bLive)
                        {
                            ChangeStatus(Status.Grab);

                            if (!_bManual)
                            {
                                if (!_bPassMode && !_bCamUse)
                                {
                                    if (_bJobLoad)
                                    {
                                        Thread threadInspStart = new Thread(() => ChangeStatus(Status.Inspection));
                                        threadInspStart.Start();


                                        if (_vPro != null)
                                        {
                                            _bVppInspEnd = false;

                                            Thread threadRun = new Thread(() => _vPro.VJobrun(_nIdx, cogImg, _modelParam[_nIdx], _graphicVproParam[_nIdx], false, false));
                                            threadRun.Start();
                                        }
                                    }
                                    else
                                    {
                                        if (_OnMessage != null)
                                            _OnMessage("job file not loaded", Color.Red, false, false, MsgType.Alarm);
                                    }
                                }
                                else
                                {
                                    //_nTotal++;
                                    //_nOK++;

                                    if (_OnInspComplete != null)
                                    {
                                        var strData = new string[8] { "1", "", "", "", "", "", "", "" };
                                        _OnInspComplete(_nIdx, true, strData, false);

                                        SaveListImg();
                                        _bUpdate = true;
                                    }

                                    //SetCount();
                                }

                                //Delay(200);

                                //if (_OnLightOnOff != null)
                                //    _OnLightOnOff(_nIdx, false);
                            }
                            else
                            {
                                if (_OnLightOnOff != null)
                                    _OnLightOnOff(_nIdx, false);
                            }
                        }

                        Thread.Sleep(50);


                    }

                    //if (bmpGrabImg != null)
                    //{
                    //    bmpGrabImg.Dispose();
                    //    bmpGrabImg = null;
                    // }
                }));

            }
            catch (Exception ex)
            {
                if (_OnInspComplete != null)
                {
                    var strData = new string[8] { "2", "", "", "", "", "", "", "" };
                    _OnInspComplete(_nIdx, true, strData, false);
                }

                _OnMessage(string.Format("#{0} camera Grabfunc Err> : ", _nIdx + 1) + ex.Message, Color.Red, false, false, MsgType.Alarm);
            }
        }

        public void ChangeStatus(Status Commandstatus)
        {
            var status = Commandstatus;
            SQL sql = new SQL();

            Invoke(new EventHandler(delegate
            {
                if (status == Status.Grab)
                {
                    ChangeImage(picGrab, Color.Green);
                    //ChangeImage(picInspStart, Color.Gray);
                    //ChangeImage(picRes, Color.Gray);
                }
                else if (status == Status.InspedtionReset)
                {
                    ChangeImage(picInspStart, Color.Gray);
                    ChangeImage(picRes, Color.Gray);
                }
                else if (status == Status.Inspection)
                {
                    ChangeImage(picInspStart, Color.Green);
                }
                else if (status == Status.InspecEnd)
                {
                    //if (!_bManual)
                    //    _nTotal++;
                    var bRes = _bInspRes;

                    if (_bInspRes)
                    {
                        //if (!_bManual)
                        //    _nOK++;

                        _result = Result.OK;
                        pnlRes.Invalidate();
                        ChangeImage(picRes, Color.Green);
                        //DrawRectangle(Result.OK, true);
                    }
                    else
                    {
                        //if (!_bManual)
                        //    _nNG++;

                        _result = Result.NG;
                        pnlRes.Invalidate();
                        ChangeImage(picRes, Color.Red);
                        //DrawRectangle(Result.NG, true);
                    }

                    CogGraphicLabel cobLbl = new CogGraphicLabel();

                    if (_bInspRes)
                    {
                        cobLbl.Text = "OK";
                        cobLbl.Color = CogColorConstants.Green;
                    }
                    else
                    {
                        cobLbl.Text = "NG";
                        cobLbl.Color = CogColorConstants.Red;
                    }

                    AddResGraphic(cobLbl);

                    if (!_bManual)
                    {
                        var dateTimeStart = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 00:00:00"));
                        var dateTimeEnd = Convert.ToDateTime(DateTime.Now.ToString("yyyy-MM-dd 23:59:59"));

                        int[] nTotal = new int[16];
                        int[] nOK = new int[16];
                        int[] nNG = new int[16];
                        sql.GetCount(_strProcName, _strModelName, dateTimeStart, dateTimeEnd, _dbInfo, ref nTotal, ref nOK, ref nNG);

                        nTotal[_nIdx + 1]++;

                        if (_bInspRes)
                            nOK[_nIdx + 1]++;
                        else
                            nNG[_nIdx + 1]++;

                        sql.SaveCount(_strProcName, _strModelName, _dbInfo, nTotal, nOK, nNG, dateTimeStart);
                    }

                    //SetCount();
                }
                else if (status == Status.CamConnect)
                {
                    lblConnect.ForeColor = Color.Black;
                    lblConnect.BackColor = Color.Lime;
                }
                else if (status == Status.CamDisconnect)
                {
                    lblConnect.ForeColor = Color.White;
                    lblConnect.BackColor = Color.Red;
                }
                else
                {
                    ChangeImage(picGrab, Color.Gray);
                    ChangeImage(picInspStart, Color.Gray);
                    ChangeImage(picRes, Color.Gray);

                    InitDisp(false);
                }
            }));

            sql.Dispose();
        }

        public void ChangeImage(object picture, Color color)    //상태 이미지 변경
        {
            PictureBox ptbox = picture as PictureBox;

            try
            {
                Invoke(new EventHandler(delegate
                {
                    if (color == Color.Red)
                    {
                        if (ptbox.Image != Properties.Resources.Red)
                            ptbox.Image = Properties.Resources.Red;

                    }
                    else if (color == Color.Green)
                    {
                        if (ptbox.Image != Properties.Resources.Green)
                            ptbox.Image = Properties.Resources.Green;
                    }
                    else if (color == Color.Yellow)
                    {
                        if (ptbox.Image != Properties.Resources.Yellow)
                            ptbox.Image = Properties.Resources.Yellow;
                    }
                    else if (color == Color.Gray)
                    {
                        if (ptbox.Image != Properties.Resources.Gray)
                            ptbox.Image = Properties.Resources.Gray;
                    }
                }));
            }

            catch { }
        }

        private void SaveListImg()
        {
            try
            {
                _listOriginImg.Add(cogDisp.Image.CopyBase(CogImageCopyModeConstants.CopyPixels));

                if (_listOriginImg.Count > 20)
                    _listOriginImg.RemoveAt(0);

                using (var cogImg = new CogImage24PlanarColor((Bitmap)cogDisp.CreateContentBitmap(Cognex.VisionPro.Display.CogDisplayContentBitmapConstants.Image).Clone()))
                    _listResultImg.Add(cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels));

                if (_listResultImg.Count > 20)
                    _listResultImg.RemoveAt(0);
            }
            catch { }
        }

        public void GrabStart()
        {
            if (_requestMode == RequestMode.AUTO)
                _bManual = false;
            else
                _bManual = true;

            Thread threadGrab = new Thread(() => Grab(_bManual, _modelParam[_nIdx].dExpose));
            threadGrab.Start();
        }
        public void Grab(bool bManualMode, double dExposureValue)
        {
            var bManual = bManualMode;
            var dExposure = dExposureValue;

            try
            {
                //ChangeStatus(Status.NONE);

                if (_nIdx == -1)
                    return;

                if (!_camParam[_nIdx].bConnect)
                {
                    if (_OnMessage != null)
                        _OnMessage(string.Format("#{0} Camera Disconnected", _nIdx + 1), Color.Red, false, false, MsgType.Alarm);

                    return;
                }

                if (_OnLightOnOff != null)
                    _OnLightOnOff(_nIdx, true);



                nGrabCnt = 0;
                Delay(_modelParam[_nIdx].nGrabdelay);
                _bManual = bManual;
                _camSet[_nIdx].Grab(_nIdx, dExposure);
            }
            catch (Exception ex)
            {
                if (_OnMessage != null)
                    _OnMessage(string.Format("#{0} Camera Grab Error : {1}", _nIdx + 1, ex.Message), Color.Red, false, false, MsgType.Alarm);
            }
        }

        public void ChangeImage(object picture, string strColoe)    //상태 이미지 변경
        {
            PictureBox ptbox = picture as PictureBox;

            try
            {
                if (InvokeRequired)
                {
                    Invoke(new EventHandler(delegate
                    {
                        if (strColoe == "Red")
                        {
                            if (ptbox.Image != Properties.Resources.Red)
                                ptbox.Image = Properties.Resources.Red;

                        }
                        else if (strColoe == "Green")
                        {
                            if (ptbox.Image != Properties.Resources.Green)
                                ptbox.Image = Properties.Resources.Green;
                        }
                        else if (strColoe == "Gray")
                        {
                            if (ptbox.Image != Properties.Resources.Gray)
                                ptbox.Image = Properties.Resources.Gray;
                        }
                    }));
                }
                else
                {
                    if (strColoe == "Red")
                    {
                        if (ptbox.Image != Properties.Resources.Red)
                            ptbox.Image = Properties.Resources.Red;

                    }
                    else if (strColoe == "Green")
                    {
                        if (ptbox.Image != Properties.Resources.Green)
                            ptbox.Image = Properties.Resources.Green;
                    }
                    else if (strColoe == "Gray")
                    {
                        if (ptbox.Image != Properties.Resources.Gray)
                            ptbox.Image = Properties.Resources.Gray;
                    }
                }
            }

            catch { }
        }
        public void CamDisconnect()
        {
            _camSet[_nIdx].CamDisconnect();
            CamStatus(false);
            _camParam[_nIdx].bConnect = false;
        }
        public void LiveView()
        {
            if (!_camParam[_nIdx].bConnect)
            {
                MessageBox.Show("camera is not connected.", "Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                cogDisp.StaticGraphics.Clear();
                cogDisp.InteractiveGraphics.Clear();

                if (!_bLive)
                {
                    _bLive = true;

                    if (_OnLightOnOff != null)
                        _OnLightOnOff(_nIdx, true);

                    Grab(true, _modelParam[_nIdx].dExpose);

                    _camSet[_nIdx].LiveView(_camParam[_nIdx].camInterface, _bLive);

                    Delay(500);

                    ChangeImage(picGrab, Color.Yellow);

                    CogGraphicLabel cogLive = new CogGraphicLabel();
                    CogLine cogLineWidth = new CogLine();
                    CogLine cogLineHeight = new CogLine();

                    cogLive.SetXYText(50, 150, "LIVE");
                    cogLive.Color = CogColorConstants.Green;
                    cogLive.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;

                    using (Font font = new Font("Tahoma", 20, FontStyle.Bold))
                        cogLive.Font = font;

                    cogLineWidth.LineWidthInScreenPixels = 2;
                    cogLineWidth.Color = CogColorConstants.Green;

                    cogLineHeight.LineWidthInScreenPixels = 2;
                    cogLineHeight.Color = CogColorConstants.Green;

                    cogLineWidth.SetXYRotation(0, cogDisp.Image.Height / 2.0, 0);
                    cogLineHeight.SetXYRotation(cogDisp.Image.Width / 2.0, 0, (90.0 * Math.PI) / 180.0);

                    cogDisp.StaticGraphics.Add(cogLive, "");
                    cogDisp.StaticGraphics.Add(cogLineWidth, "");
                    cogDisp.StaticGraphics.Add(cogLineHeight, "");
                }
                else
                {
                    _camSet[_nIdx].LiveView(_camParam[_nIdx].camInterface, false);
                    Delay(1000);
                    //Thread.Sleep(1000);

                    _bLive = false;

                    ChangeImage(picGrab, Color.Gray);

                    if (_OnLightOnOff != null)
                        _OnLightOnOff(_nIdx, false);

                    cogDisp.StaticGraphics.Clear();
                }
            }
            catch (Exception ex)
            {
                if (_OnMessage != null)
                    _OnMessage("Live Error : " + ex.Message, Color.Red, false, false, MsgType.Alarm);
            }
        }

        public void OpenImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Image Open";
            ofd.InitialDirectory = _SaveImgParam._strSaveImagePath;
            ofd.Filter = "Image File (*.bmp,*.jpg,*.png) | *.bmp;*.jpg;*.png; | All Files (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    cogDisp.StaticGraphics.Clear();
                    cogDisp.InteractiveGraphics.Clear();
                    cogDisp.Image = null;
                    cogDisp.AutoFit = true;

                    cogResDisp.StaticGraphics.Clear();
                    cogResDisp.InteractiveGraphics.Clear();
                    cogResDisp.Image = null;
                    cogResDisp.AutoFit = true;

                    using (FileStream fs = new FileStream(ofd.FileName, FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (Image img = Image.FromStream(fs))
                        {
                            using (Bitmap bmpimg = new Bitmap(img))
                            {
                                using (var cogImg = new CogImage24PlanarColor(bmpimg))
                                {
                                    cogDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                                    cogResDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);


                                    _cogSendImg = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                                }
                            }
                        }
                    }
                }
                catch { }
            }
        }

        public void ToolEdit()
        {
            if (_frmToolEdit != null)
            {
                _frmToolEdit.Dispose();
                _frmToolEdit = null;
            }

            _frmToolEdit = new frmToolEdit(this, _nIdx);
            _frmToolEdit.LoadSet(cogDisp.Image);
            _frmToolEdit.Show();
        }

        private void btnControl_Click(object sender, EventArgs e)
        {
            if (flyChk.IsPopupOpen)
                flyChk.HideBeakForm();

            if (!fypnl.IsPopupOpen)
                fypnl.ShowBeakForm();
            else
                fypnl.HideBeakForm();
        }


        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            if (_bSensor) return;

            OpenImage();

        }

        private void btnToolEdit_Click(object sender, EventArgs e)
        {

            if (!_bJobLoad)
            {
                MessageBox.Show(new Form { TopMost = true }, "No inspection file", "No file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (fypnl.IsPopupOpen)
                fypnl.HideBeakForm();

            Delay(500);
            if (!splashScreenManager1.IsSplashFormVisible)
                splashScreenManager1.ShowWaitForm();

            ToolEdit();

        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            _dateTime[_nIdx] = DateTime.Now;

            //MakeImgFileName();
            //InitDisp(false);
            _bManual = true;
            if (_bSensor)
            {
                if (_OnSensorTrigger != null)
                    _OnSensorTrigger();
            }
            else
            {
                if (!_camParam[_nIdx].bConnect)
                {
                    MessageBox.Show(new Form { TopMost = true }, "CAMERA DSCONNECTED", "DISCONNECTED", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                _requestMode = RequestMode.NONE;
                ChangeStatus(Status.NONE);
                Grab(true, _modelParam[_nIdx].dExpose);

            }
        }

        private void btnLive_Click(object sender, EventArgs e)
        {
            if (_bSensor) return;

            _bManual = true;
            LiveView();
        }


        private void btnInspection_Click(object sender, EventArgs e)
        {
            _dateTime[_nIdx] = DateTime.Now;
            _bManual = true;
            InitDisp(false);

            if (_bSensor)
            {
                if (_OnSensorTrigger != null)
                    _OnSensorTrigger();
            }
            else
            {
                _requestMode = RequestMode.NONE;
                ChangeStatus(Status.InspedtionReset);
                Inspection();
            }
        }

        public void Inspection()
        {
            try
            {
                if (_nIdx == -1)
                    return;

                if (cogDisp.Image == null)
                {
                    _OnMessage("<Inspection Err> No image to examine", Color.Red, false, false, MsgType.Alarm);
                    return;
                }


                if (!_bJobLoad)
                {
                    if (!_bManual)
                    {
                        _strInspData = "2,0,0,0,0,0,0,0";
                        _bInspRes = false;
                        _bInspEnd = true;

                        MakeImgFileName();


                        if (_requestMode != RequestMode.NONE)
                        {
                            SQL sql = new SQL();
                            sql.InsertResult(_nIdx, _strProcName, _bInspRes, _strInspData.Split(','), _dateTime[_nIdx], _strModelName, _strLotNo, _modelParam[_nIdx].strCode, _strResImgFile, _bManual, _dbInfo, "");
                            sql.Dispose();
                        }

                    }

                    ChangeStatus(Status.Inspection);
                    ChangeStatus(Status.InspecEnd);

                    _OnMessage("<Inspection Err> No inspection file", Color.Red, false, false, MsgType.Alarm);
                    return;
                }

                InitDisp(false);

                Thread threadInspStart = new Thread(() => ChangeStatus(Status.Inspection));
                threadInspStart.Start();

                _bVppInspRes = false;
           
                _bVppInspEnd = false;


                Thread threadVproRun = new Thread(() => _vPro.VJobrun(_nIdx, cogDisp.Image, _modelParam[_nIdx], _graphicVproParam[_nIdx], true, false));
                threadVproRun.Start();



                //ChangeStatus(GlovalVar.Status.Inspection);
            }
            catch (Exception ex)
            {
                if (_OnMessage != null)
                    _OnMessage("Inspection Error : " + ex.Message, Color.Red, false, false, MsgType.Alarm);
            }
        }

        public void InitDisp(bool _bClear)
        {
            cogDisp.InteractiveGraphics.Clear();
            cogDisp.StaticGraphics.Clear();

            cogResDisp.InteractiveGraphics.Clear();
            cogResDisp.StaticGraphics.Clear();



            if (_bClear)
            {
                cogDisp.Image = null;
                cogResDisp.Image = null;

            }

            _result = Result.NONE;
            pnlRes.Invalidate();
        }

        private void btnMaster_Click(object sender, EventArgs e)
        {
            try
            {
                if (cogDisp.Image == null)
                {
                    MessageBox.Show(Str.NoMasterImgMsg, "No Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (MessageBox.Show(Str.SaveMasterImgMsg, "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

                var strFileName = XtraInputBox.Show("Please enter the master image code", "New Master", "");

                if (string.IsNullOrEmpty(strFileName))
                    return;

                var strPath = string.Format("{0}\\Camera_{1:D2}", _strMasterImagePath, _nIdx + 1);
                DirectoryInfo dr = new DirectoryInfo(strPath);
                if (!dr.Exists)
                    dr.Create();

                using (CogImageFileJPEG cogJPG = new CogImageFileJPEG())
                {
                    cogJPG.Open(strPath + "\\" + strFileName + ".jpg", CogImageFileModeConstants.Write);
                    cogJPG.Append(cogDisp.Image);
                    cogJPG.Close();
                    cogJPG.Dispose();
                }

                MessageBox.Show(Str.SaveCompleteMasterImg, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch { }
        }


        private void btnCamSet_Click(object sender, EventArgs e)
        {
            if (_bSensor)
                return;

            fypnl.HideBeakForm();

            Delay(100);

            if (_CamSetFunc != null)
                _CamSetFunc(_nIdx);
        }


        public void ModelChange(bool bChange)
        {
            _bLoad = false;

            LoadModelImage();



            if (_vPro == null)
            {
                _vPro = new VproInspection();
                _vPro._OnInspData = OnInspectionData;
                _vPro._OnInspGraphic = OnInspectionGraphic;
            }

            var Temp = _modelParam[_nIdx].strCode;
            if (_modelParam[_nIdx].strCode == "")
            {
                if (_OnMessage != null)
                    _OnMessage(string.Format("#{0} Camera job file loading error", _nIdx + 1), Color.Red, false, false, MsgType.Alarm);
            }
            else
            {
                _bLoad = false;
                _bJobLoad = _vPro.VJoblode(string.Format("{0}\\vpp\\Camera_{1:D2}\\{2}.vpp", Application.StartupPath, _nIdx + 1, _modelParam[_nIdx].strCode), cogDisp.Image);

                if (!_bJobLoad)
                    _OnMessage(string.Format("#{0} Camera job file Not Load", _nIdx + 1), Color.Red, false, false, MsgType.Alarm);
                else
                    chkPass.Checked = _bPassMode;
            }



            Delay(500);
            _bLoad = true;
        }




        private void SaveOriginImage()
        {
            if (_SaveImgParam._strSaveImagePath == "")
                return;

            Invoke(new EventHandler(delegate
            {
                try
                {
                    bool bRes = _bInspRes;
                    string strRes = bRes ? "OK" : "NG";
                    string strInspMonth = _dateTime[_nIdx].ToString("yyyyMM");
                    string strInspDay = _dateTime[_nIdx].ToString("dd");
                    string strInspTime = _dateTime[_nIdx].ToString("HH_mm_ss_fff");
                    string strProcName = _strProcName == "" ? "NO_NAME" : _strProcName;
                    string strModel = _strModelName == "" ? "NO_MODEL" : _strModelName;
                    string strLotNo = _strLotNo == "" ? "NO_LOTNO" : _strLotNo;

                    string strPath = _SaveImgParam._strSaveImagePath + "\\" + strModel + "\\" + strRes + "\\" + strInspMonth + "\\" + strInspDay + "\\" + strLotNo + "\\OriginImage";

                    DirectoryInfo dr = new DirectoryInfo(strPath);
                    if (!dr.Exists)
                        dr.Create();

                    if (cogResDisp.Image != null)
                    {
                        ICogImage cogImg = cogResDisp.Image.CopyBase(CogImageCopyModeConstants.CopyPixels);
                        if (_SaveImgParam._OriginImageFormat == IMGFormat.bmp) // bmp
                        {
                            using (CogImageFileBMP cogBMP = new CogImageFileBMP())
                            {
                                cogBMP.Open(strPath + "\\" + "Cam" + (_nIdx + 1).ToString() + "_" + strLotNo + "_" + strInspMonth + "_" + strInspDay + "_" + strInspTime + ".bmp", CogImageFileModeConstants.Write);
                                cogBMP.Append(cogImg);
                                cogBMP.Close();
                            }
                        }
                        else
                        {
                            var strFileName = strPath + "\\" + "Cam" + (_nIdx + 1).ToString() + "_" + strLotNo + "_" + strInspMonth + "_" + strInspDay + "_" + strInspTime + ".jpg";
                            ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                            EncoderParameters myEncoderParams = new EncoderParameters(1);
                            EncoderParameter EncoderParam = new EncoderParameter(myEncoder, (long)(100 - _SaveImgParam._nOriginImgCompRate));
                            myEncoderParams.Param[0] = EncoderParam;
                            cogImg.ToBitmap().Save(strFileName, jpgEncoder, myEncoderParams);

                            EncoderParam.Dispose();
                            EncoderParam = null;

                            myEncoderParams.Dispose();
                            myEncoderParams = null;
                        }
                    }
                }
                catch { }
            }));
        }


        private void SaveResultImage()
        {
            if (_SaveImgParam._strSaveImagePath == "")
                return;

            Invoke(new EventHandler(delegate
            {
                bool bRes = _bInspRes;
                string strRes = bRes ? "OK" : "NG";
                string strInspMonth = _dateTime[_nIdx].ToString("yyyyMM");
                string strInspDay = _dateTime[_nIdx].ToString("dd");
                string strInspTime = _dateTime[_nIdx].ToString("HH_mm_ss_fff");
                string strProcName = _strProcName == "" ? "NO_NAME" : _strProcName;
                string strModel = _strModelName == "" ? "NO_MODEL" : _strModelName;
                string strLotNo = _strLotNo == "" ? "NO_LOTNO" : _strLotNo;

                try
                {
                    string strPath = _SaveImgParam._strSaveImagePath + "\\" + strModel + "\\" + strRes + "\\" + strInspMonth + "\\" + strInspDay + "\\" + strLotNo + "\\ResultImage";

                    DirectoryInfo dr = new DirectoryInfo(strPath);

                    if (!dr.Exists)
                        dr.Create();

                    if (cogResDisp.Image != null)
                    {
                        var strFileName = "";

                        Bitmap bmpImg = (Bitmap)cogResDisp.CreateContentBitmap(Cognex.VisionPro.Display.CogDisplayContentBitmapConstants.Image).Clone();

                        if (bmpImg != null)
                        {
                            if (_SaveImgParam._ResultImageFormat == IMGFormat.bmp) // bmp
                            {
                                strFileName = strPath + "\\" + "Cam" + (_nIdx + 1).ToString() + "_" + strLotNo + "_" + strInspMonth + "_" + strInspDay + "_" + strInspTime;

                                using (var cogImg = new CogImage24PlanarColor(bmpImg))
                                {
                                    using (CogImageFileBMP cogBMP = new CogImageFileBMP())
                                    {
                                        cogBMP.Open(_SaveImgParam._strSaveImagePath + strFileName + ".bmp", CogImageFileModeConstants.Write);
                                        cogBMP.Append(cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels));
                                        cogBMP.Close();
                                    }
                                }
                            }
                            else
                            {
                                strFileName = strPath + "\\" + "Cam" + (_nIdx + 1).ToString() + "_" + strLotNo + "_" + strInspMonth + "_" + strInspDay + "_" + strInspTime + ".jpg";
                                ImageCodecInfo jpgEncoder = GetEncoder(ImageFormat.Jpeg);
                                System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                                EncoderParameters myEncoderParams = new EncoderParameters(1);
                                EncoderParameter EncoderParam = new EncoderParameter(myEncoder, (long)(100 - _SaveImgParam._nResultImgCompRate));
                                myEncoderParams.Param[0] = EncoderParam;

                                bmpImg.Save(strFileName, jpgEncoder, myEncoderParams);

                                EncoderParam.Dispose();
                                EncoderParam = null;

                                myEncoderParams.Dispose();
                                myEncoderParams = null;
                            }

                            if (bmpImg != null)
                            {
                                bmpImg.Dispose();
                                bmpImg = null; ;
                            }
                        }
                    }
                }
                catch { }
            }));
        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }
            return null;
        }


        public void LoadModelImage()
        {
            if (cogDisp.Image != null)
                return;

            if (string.IsNullOrEmpty(_modelParam[_nIdx].strCode))
                return;

            try
            {
                var strPath = "";

                strPath = string.Format("{0}\\Camera_{1:D2}", _strMasterImagePath, _nIdx + 1);


                if (!string.IsNullOrEmpty(_modelParam[_nIdx].strCode))
                {
                    var stream = new FileInfo(strPath + "\\" + _modelParam[_nIdx].strCode + ".jpg").Open(FileMode.Open, FileAccess.ReadWrite, FileShare.None);

                    if (stream != null)
                    {
                        using (var bmp = new Bitmap(stream))
                        {
                            using (CogImage24PlanarColor cogImg = new CogImage24PlanarColor((Bitmap)bmp.Clone()))
                            {
                                cogDisp.AutoFit = true;
                                cogResDisp.AutoFit = true;


                                cogDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                                cogResDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);

                            }
                        }
                        stream.Close();
                    }
                }
            }
            catch { }
        }


        public void LoadGraphicParam()
        {
            SQL sql = new SQL();

            try
            {
                int nCnt = 0;
                sql.GetGraphicResViewParam(_strProcName, _strModelName, _nIdx, _dbInfo, ref _graphicResParam[_nIdx]);

                if (_graphicResParam[_nIdx].strAlign == "")
                    _graphicResParam[_nIdx].strAlign = "BaselineCenter";

                if (_graphicResParam[_nIdx].nFontSize == 0)
                    _graphicResParam[_nIdx].nFontSize = 15;

                if (_graphicResParam[_nIdx].nSubFontSize == 0)
                    _graphicResParam[_nIdx].nSubFontSize = 15;

                sql.GetGraphicToolParam(_strProcName, _strModelName, _nIdx, _dbInfo, ref _graphicVproParam[_nIdx]);



            }
            catch { }

            sql.Dispose();
        }

        private void OnInspectionData(string[] strValue, bool bManualMode, string strResultData)
        {
            if (!_bLoad)
                return;

            try
            {
                string[] strData = strValue;
                bool[] bRes = new bool[6];
                bool bManual = bManualMode;
                string strResData = strResultData;

                if (strValue == null)
                {
                    if (_modelParam[_nIdx].nDefectCnt > nGrabCnt)
                    {
                        if (!bManual)
                        {
                            ReInspection();
                            return;
                        }
                    }
                    else
                    {
                        strData = new string[8];
                        strData[0] = "2";

                        bRes[0] = false;
                        bRes[1] = false;
                        bRes[2] = false;
                        bRes[3] = false;
                        _bVppInspRes = false;

                        //if (!bManual)
                        //    _nNG++;
                    }
                }
                else
                {
                    var nCnt = 0;
                    bRes[0] = ChkDefectInspection(strData[0]);
                    bRes[1] = Chk2DInspection(ref strData[1], ref nCnt);
                    bRes[5] = GetAlignData(ref strData[2], ref strData[3], ref strData[4], ref nCnt);
                    bRes[2] = GetDimension(strData[5], strData[6], ref nCnt);
                    bRes[3] = GetPinData(PinInsp.PinMaster, strData[7], ref nCnt);
                    bRes[4] = GetPinData(PinInsp.PinNumberMaster, strData[7], ref nCnt);
                }

                _bVppInspRes = (bRes[0] && bRes[1] && bRes[2] && bRes[3] && bRes[4] && bRes[5]) ? true : false;
                _bVppInspEnd = true;

                _bInspRes = _bVppInspRes ? true : false;
                strData[0] = _bInspRes ? "1" : "2";

                _strInspData = string.Format("{0},{1},{2},{3},{4},{5},{6},{7}", strData[0], strData[1], strData[2], strData[3], strData[4], strData[5], strData[6], strData[7]);

                Thread threadInspStart = new Thread(() => ChangeStatus(Status.InspecEnd));
                threadInspStart.Start();

                if (_OnInspComplete != null)
                {
                    Thread threadInspComplete = new Thread(() => _OnInspComplete(_nIdx, _bInspRes, strData, bManual));
                    threadInspComplete.Start();
                }

                MakeImgFileName();

                if (!bManual)
                {

                    SQL sql = new SQL();
                    sql.InsertResult(_nIdx, _strProcName, _bInspRes, _strInspData.Split(','), _dateTime[_nIdx], _strModelName, _strLotNo, _modelParam[_nIdx].strCode, _strResImgFile, _bManual, _dbInfo, strResData);
                    sql.Dispose();

                }
                _bInspEnd = true;
            }
            catch (Exception ex) { }
        }
        public void MakeImgFileName()
        {
            bool bRes = _bInspRes;
            string strRes = bRes ? "OK" : "NG";
            string strInspMonth = _dateTime[_nIdx].ToString("yyyyMM");
            string strInspDay = _dateTime[_nIdx].ToString("dd");
            string strInspTime = _dateTime[_nIdx].ToString("HH_mm_ss_fff");
            string strProcName = _strProcName == "" ? "NO_NAME" : _strProcName;
            string strModel = _strModelName == "" ? "NO_MODEL" : _strModelName;
            string strLotNo = _strLotNo == "" ? "NO_LOTNO" : _strLotNo;

            string strPath = _SaveImgParam._strSaveImagePath + "\\" + strModel + "\\" + strRes + "\\" + strInspMonth + "\\" + strInspDay + "\\" + strLotNo + "\\ResultImage";
            _strResImgFile = strPath + "\\" + "Cam" + (_nIdx + 1).ToString() + "_" + strLotNo + "_" + strInspMonth + "_" + strInspDay + "_" + strInspTime;

        }

        private bool GetDimension(string strWidth, string strHeight, ref int nGrabphicCnt)
        {
            bool bRes = true;
            if (_modelParam[_nIdx].bDimens)
            {
                //CogGraphicLabel coglbl = new CogGraphicLabel();


                var strWidths = strWidth.Split(',');
                var strHeights = strHeight.Split(',');

                CogGraphicLabel[] coglblWidth = new CogGraphicLabel[strWidths.Length];
                CogGraphicLabel[] coglblHeight = new CogGraphicLabel[strHeights.Length];

                var bDimension = new bool[2] { true, true };

                for (var i = 0; i < strWidths.Length; i++)
                {
                    coglblHeight[i] = new CogGraphicLabel();
                    double.TryParse(strWidths[i], out var dWidth);

                    if (_modelParam[_nIdx].dResoluton != 0)
                        dWidth *= _modelParam[_nIdx].dResoluton;

                    coglblWidth[i] = new CogGraphicLabel();
                    coglblWidth[i].Color = CogColorConstants.Green;

                    if (_modelParam[_nIdx].dWidthMin != 0.0 && _modelParam[_nIdx].dWidthMax != 0.0)
                    {
                        if (dWidth <= _modelParam[_nIdx].dWidthMin || dWidth >= _modelParam[_nIdx].dWidthMax)
                        {
                            coglblWidth[i].Color = CogColorConstants.Red;
                            bDimension[0] = false;
                        }

                        coglblWidth[i].Text = string.Format("Width : {0:F3}mm", dWidth);
                    }

                    var dPosY = coglblWidth[i].Y;

                    if (i == 0)
                        coglblWidth[i].Y = dPosY + _graphicResParam[_nIdx].dPosY + _graphicResParam[_nIdx].dSubPosY;
                    else
                        coglblWidth[i].Y = coglblWidth[i - 1].Y + _graphicResParam[_nIdx].dSubPosY;

                    AddGraphic(coglblWidth[i], nGrabphicCnt);
                    nGrabphicCnt++;
                }

                for (var i = 0; i < strHeights.Length; i++)
                {
                    coglblHeight[i] = new CogGraphicLabel();
                    double.TryParse(strHeights[i], out var dHeight);

                    if (_modelParam[_nIdx].dResoluton != 0)
                        dHeight *= _modelParam[_nIdx].dResoluton;

                    coglblHeight[i].Color = CogColorConstants.Green;

                    if (_modelParam[_nIdx].dHeightMin != 0.0 && _modelParam[_nIdx].dHeightMax != 0.0)
                    {
                        if (dHeight <= _modelParam[_nIdx].dWidthMin && dHeight >= _modelParam[_nIdx].dWidthMax)
                        {
                            coglblHeight[i].Color = CogColorConstants.Red;
                            bDimension[1] = false;
                        }
                        coglblHeight[i].Text = string.Format("Width : {0:F3}mm", dHeight);
                    }

                    AddGraphic(coglblHeight[i], nGrabphicCnt);
                }

                bRes = (bDimension[0] && bDimension[1]) ? true : false;
            }

            return bRes;
        }

        #region Pin Data
        private bool GetPinData(PinInsp pinInsp, string strData, ref int nGraphicCnt)
        {
            bool bRes = true;
            bool bInsp = false;


            if (pinInsp == PinInsp.PinMaster)            
                bInsp = _modelParam[_nIdx].bPinChange;         

            if (bInsp)
            {
                CogGraphicLabel[] coglbl = new CogGraphicLabel[2];
                string strPinMaster = "";
                coglbl[0] = new CogGraphicLabel();
                coglbl[1] = new CogGraphicLabel();

                if (_modelParam[_nIdx].bPinChange)
                {
                    strPinMaster = _modelParam[_nIdx].strPinMaster;
                    
                }

                if (_graphicResParam[_nIdx].nSubFontSize == 0)
                    _graphicResParam[_nIdx].nSubFontSize = 15;

                using (Font font = new Font("Tahoma", _graphicResParam[_nIdx].nSubFontSize, FontStyle.Bold))
                {
                    coglbl[0].Font = font;
                    coglbl[1].Font = font;
                }

                coglbl[0].Text = string.Format("Pin Master ({0}, {1})", strPinMaster);
                coglbl[1].Text = string.Format("Pin Data ({0})", strData);
                              
                if (strPinMaster == strData)
                    bRes = true;
                else
                    bRes = false;
               

                if (bRes)
                {
                    coglbl[0].Color = CogColorConstants.Green;
                    coglbl[1].Color = CogColorConstants.Green;
                }
                else
                {
                    coglbl[0].Color = CogColorConstants.Red;
                    coglbl[1].Color = CogColorConstants.Red;
                }

                AddGraphic(coglbl[0], nGraphicCnt);
                nGraphicCnt++;
                AddGraphic(coglbl[1], nGraphicCnt);
                nGraphicCnt++;
            }

            return bRes;
        }

       

        #endregion

        private double AngleToRadian(double dAngle)
        {
            return (Math.PI / 180) * dAngle;
        }
        #region 로봇 좌표 데이터 
        private bool GetAlignData(ref string strDataX, ref string strDataY, ref string strDataR, ref int nGraphicCnt)
        {
            bool bRes = true;
            if (_modelParam[_nIdx].bAlingInsp)
            {
                CogGraphicLabel coglblX = new CogGraphicLabel();
                CogGraphicLabel coglblY = new CogGraphicLabel();
                CogGraphicLabel coglblR = new CogGraphicLabel();

                double.TryParse(strDataX, out var dCenX);
                double.TryParse(strDataY, out var dCenY);
                double.TryParse(strDataR, out var dCenR);

                var dX = 0.0;
                var dY = 0.0;
                var dR = 0.0;

                if (!_modelParam[_nIdx].bAlignFormula)
                {
                    dX = ((dCenX - _modelParam[_nIdx].dAlignMasterX) * _modelParam[_nIdx].dResoluton) + _modelParam[_nIdx].dAlignOffsetX;
                    dY = ((dCenY - _modelParam[_nIdx].dAlignMasterY) * _modelParam[_nIdx].dResoluton) + _modelParam[_nIdx].dAlignOffsetY;
                    dR = dCenR - _modelParam[_nIdx].dAlignMasterR + _modelParam[_nIdx].dAlignOffsetR;
                }
                else
                {
                    var dRotateSub = _modelParam[_nIdx].dAlignMasterR - dCenR;

                    dX = ((dCenX - (_modelParam[_nIdx].dCenterMass * Math.Sin(dRotateSub)) - _modelParam[_nIdx].dAlignMasterX) * _modelParam[_nIdx].dResoluton) + _modelParam[_nIdx].dAlignOffsetX;
                    dY = ((dCenY + (_modelParam[_nIdx].dCenterMass * (1 - Math.Sin(dRotateSub))) - _modelParam[_nIdx].dAlignMasterY) * _modelParam[_nIdx].dResoluton) + _modelParam[_nIdx].dAlignOffsetY;
                    dR = dCenR - _modelParam[_nIdx].dAlignMasterR + _modelParam[_nIdx].dAlignOffsetR;
                }

                coglblX.Text = string.Format("X : {0:F2}", dX);
                coglblY.Text = string.Format("Y : {0:F2}", dY);
                coglblR.Text = string.Format("R : {0:F2}", dR);

                strDataX = string.Format("{0:D5}", (int)(dX * _modelParam[_nIdx].dAlignUnit));
                strDataY = string.Format("{0:D5}", (int)(dY * _modelParam[_nIdx].dAlignUnit));
                strDataR = string.Format("{0:D5}", (int)(dR * _modelParam[_nIdx].dAlignUnit));

                double maxX = _modelParam[_nIdx].dMaxX;
                double maxY = _modelParam[_nIdx].dMaxY;
                if (maxX != 0 || maxY != 0)
                {
                    if (-maxX < dX && dX < maxX)
                    {
                        coglblX.Color = CogColorConstants.Green;
                    }
                    else
                    {
                        coglblX.Color = CogColorConstants.Red;
                        bRes = false;

                    }
                    if (-maxY < dY && dY < maxY)
                    {
                        coglblY.Color = CogColorConstants.Green;
                    }
                    else
                    {
                        coglblY.Color = CogColorConstants.Red;
                        bRes = false;
                    }
                    coglblR.Color = CogColorConstants.Green;
                }
                else
                {
                    coglblX.Color = CogColorConstants.Green;
                    coglblY.Color = CogColorConstants.Green;
                    coglblR.Color = CogColorConstants.Green;
                }



                var dPosY = coglblX.Y;

                coglblX.Y = dPosY + _graphicResParam[_nIdx].dPosY + _graphicResParam[_nIdx].dSubPosY;
                nGraphicCnt++;

                AddGraphic(coglblX, nGraphicCnt);

                coglblY.Y = coglblX.Y + _graphicResParam[_nIdx].dSubPosY;
                nGraphicCnt++;

                AddGraphic(coglblY, nGraphicCnt);

                coglblR.Y = coglblY.Y + _graphicResParam[_nIdx].dSubPosY;
                nGraphicCnt++;

                AddGraphic(coglblR, nGraphicCnt);
            }
            return bRes;
        }


        public double RadToAngle(double Rad)
        {
            return (Rad * 180.0) / Math.PI;
        }
        #endregion

        #region 결과 처리 OK or NG
        private bool ChkDefectInspection(string strResult)
        {
            bool bRes = true;
            if (_modelParam[_nIdx].bDefectInsp)
            {
                int.TryParse(strResult, out var nRes);

                if (nRes > 0)
                    bRes = true;
                else
                    bRes = false;
            }

            return bRes;
        }
        #endregion

        #region 2D 데이터 처리
        private bool Chk2DInspection(ref string str2DData, ref int nGraphicCnt)
        {
            bool bRes = true;
            if (_modelParam[_nIdx].bBCRInsp)
            {
                CogGraphicLabel coglbl = new CogGraphicLabel();

                using (Font font = new Font("Tahoma", _graphicResParam[_nIdx].nSubFontSize, FontStyle.Bold))
                    coglbl.Font = font;

                if (!string.IsNullOrEmpty(_modelParam[_nIdx].strBCRData))
                {
                    if (!string.IsNullOrEmpty(_modelParam[_nIdx].strBCRLen))
                    {
                        var strParse = _modelParam[_nIdx].strBCRLen.Split('~');
                        int.TryParse(strParse[0], out int nStart);
                        int.TryParse(strParse[1], out int nEnd);

                        str2DData = str2DData.Substring(nStart, nEnd);
                    }

                    coglbl.Text = "2D Data : " + str2DData;
                    if (str2DData != _modelParam[_nIdx].strBCRData)
                    {
                        bRes = false;
                        coglbl.Color = CogColorConstants.Red;
                    }
                    else
                        coglbl.Color = CogColorConstants.Green;
                }
                else
                {
                    coglbl.Text = "2D Data : " + str2DData;
                }

                AddGraphic(coglbl, nGraphicCnt);
                nGraphicCnt++;
            }

            return bRes;
        }

        #endregion

        private void ReInspection()
        {
            if (string.IsNullOrEmpty(_modelParam[_nIdx].strExposeInc))
            {
                //if (_OnMessage != null)
                //    _OnMessage("Set the exposure value for the re-examination camera.", Color.Red, false, false);
            }
            else
            {
                string[] strExpose = _modelParam[_nIdx].strExposeInc.Split(',');
                double.TryParse(strExpose[nGrabCnt - 1], out double dExpose);
                _camSet[_nIdx].Grab(_nIdx, dExpose);
            }
        }

        private void OnInspectionGraphic(List<CogPointMarker> cogPoint, List<CogLine> cogLine, List<CogCircle> cogCircle, List<CogCompositeShape> cogShape, List<CogEllipse> cogEllipse, List<ICogRegion> cogResRegion, List<CogGraphicLabel> coglbls, string strResultData)
        {
            List<CogPointMarker> cogPoints = cogPoint;
            List<CogLine> cogLines = cogLine;
            List<CogCircle> cogCircles = cogCircle;
            List<CogCompositeShape> cogShapes = cogShape;
            List<CogEllipse> cogEllipses = cogEllipse;
            List<ICogRegion> cogRegion = cogResRegion;
            _coglblResData = coglbls;
            var strResData = strResultData;

            try
            {
                if (cogDisp.Image != null)
                {
                    if (cogRegion != null)
                    {
                        for (int i = 0; i < cogRegion.Count; i++)
                        {
                            if (cogRegion[i] != null)
                            {
                                cogDisp.InteractiveGraphics.Add(cogRegion[i] as ICogGraphicInteractive, "Region", false);
                                cogResDisp.InteractiveGraphics.Add(cogRegion[i] as ICogGraphicInteractive, "Region", false);

                                cogRegion[i] = null;
                            }
                        }
                    }

                    if (cogPoints != null)
                    {
                        for (int i = 0; i < cogPoints.Count; i++)
                        {
                            if (cogPoints[i] != null)
                            {
                                cogDisp.InteractiveGraphics.Add(cogPoints[i], "Point", false);
                                cogResDisp.InteractiveGraphics.Add(cogPoints[i], "Point", false);

                                cogPoints[i].Dispose();
                                cogPoints[i] = null;
                            }
                        }
                    }

                    if (cogLines != null)
                    {
                        for (int i = 0; i < cogLines.Count; i++)
                        {
                            if (cogLines[i] != null)
                            {
                                cogDisp.InteractiveGraphics.Add(cogLines[i], "Line", false);
                                cogResDisp.InteractiveGraphics.Add(cogLines[i], "Line", false);

                                cogLines[i].Dispose();
                                cogLines[i] = null;
                            }
                        }
                    }

                    if (cogCircles != null)
                    {
                        for (int i = 0; i < cogCircles.Count; i++)
                        {
                            if (cogCircles[i] != null)
                            {
                                cogDisp.InteractiveGraphics.Add(cogCircles[i], "Circle", false);
                                cogResDisp.InteractiveGraphics.Add(cogCircles[i], "Circle", false);

                                cogCircles[i].Dispose();
                                cogCircles[i] = null;
                            }
                        }
                    }

                    if (cogShapes != null)
                    {
                        for (int i = 0; i < cogShapes.Count; i++)
                        {
                            if (cogShapes[i] != null)
                            {
                                cogDisp.InteractiveGraphics.Add(cogShapes[i], "Shape", false);
                                cogResDisp.InteractiveGraphics.Add(cogShapes[i], "Shape", false);

                                cogShapes[i].Dispose();
                                cogShapes[i] = null;
                            }
                        }
                    }

                    if (cogEllipses != null)
                    {
                        for (int i = 0; i < cogEllipses.Count; i++)
                        {
                            if (cogEllipses[i] != null)
                            {
                                cogDisp.InteractiveGraphics.Add(cogEllipses[i], "Ellipses", false);
                                cogResDisp.InteractiveGraphics.Add(cogEllipses[i], "Ellipses", false);

                                cogEllipses[i].Dispose();
                                cogEllipses[i] = null;
                            }
                        }
                    }

                    if (_bResData)
                    {
                        if (_coglblResData != null)
                        {
                            for (int i = 0; i < _coglblResData.Count; i++)
                            {
                                if (_coglblResData[i] != null)
                                {
                                    cogDisp.InteractiveGraphics.Add(_coglblResData[i], "GROUP", false);
                                    cogResDisp.InteractiveGraphics.Add(_coglblResData[i], "GROUP", false);
                                }
                            }
                        }
                    }

                    
                    Delay(200);



                    if (_SaveImgParam._bOriginImageSave)
                    {
                        Thread ThreadSaveOriginImg = new Thread(SaveOriginImage);
                        ThreadSaveOriginImg.Start();
                    }

                    if (_SaveImgParam._bResultImageSave)
                    {
                        Thread threadSaveResImg = new Thread(SaveResultImage);
                        threadSaveResImg.Start();
                    }


                    SaveListImg();

                    _bUpdate = true;
                }
            }
            catch { }


        }

        private void btnMoveLeft_Click(object sender, EventArgs e)
        {
            if (fypnl.IsPopupOpen)
                fypnl.HideBeakForm();

            if (_OnPositionChange != null)
                _OnPositionChange(_nPos, PositionType.Previous);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (fypnl.IsPopupOpen)
                fypnl.HideBeakForm();

            if (_OnPositionChange != null)
                _OnPositionChange(_nPos, PositionType.Next);
        }

        private void btnChk_Click(object sender, EventArgs e)
        {
            LoadGraphicParam();
            SetGraphicview();

            if (!flyChk.IsPopupOpen)
                flyChk.ShowBeakForm();
            else
                flyChk.HideBeakForm();
        }

        private void btnChkClose_Click(object sender, EventArgs e)
        {
            if (flyChk.IsPopupOpen)
                flyChk.HideBeakForm();
        }


        private void btnChkSave_Click(object sender, EventArgs e)
        {

            _paramCode = ParamCode.GraphicParamChange;
            SQL sql = new SQL();

            try
            {
                _graphicResParam[_nIdx].strAlign = cbAlign.EditValue.ToString();
                int.TryParse(txtFontSize.Text, out _graphicResParam[_nIdx].nFontSize);
                int.TryParse(txtSubFontSize.Text, out _graphicResParam[_nIdx].nSubFontSize);
                double.TryParse(txtGraphicPosX.Text, out _graphicResParam[_nIdx].dPosX);
                double.TryParse(txtGraphicPosY.Text, out _graphicResParam[_nIdx].dPosY);
                double.TryParse(txtGraphicSubPosX.Text, out _graphicResParam[_nIdx].dSubPosX);
                double.TryParse(txtGraphicSubPosY.Text, out _graphicResParam[_nIdx].dSubPosY);

                sql.SaveGraphicResViewlParam(_strProcName, _strModelName, _nIdx, _dbInfo, _graphicResParam[_nIdx]);

                if (_vPro != null)
                {
                    _graphicVproParam[_nIdx] = new GraphicToolParam();
                    _graphicVproParam[_nIdx].strName = new string[_chkVproUse.Length];
                    _graphicVproParam[_nIdx].bUse = new bool[_chkVproUse.Length];
                    _graphicVproParam[_nIdx].strOKColor = new string[_chkVproUse.Length];
                    _graphicVproParam[_nIdx].strNGColor = new string[_chkVproUse.Length];
                    _graphicVproParam[_nIdx].nLineThick = new int[_chkVproUse.Length];


                    for (int i = 0; i < _chkVproUse.Length; i++)
                    {
                        _graphicVproParam[_nIdx].strName[i] = _chkVproUse[i].Text;
                        _graphicVproParam[_nIdx].bUse[i] = _chkVproUse[i].Checked;
                        _graphicVproParam[_nIdx].strOKColor[i] = string.IsNullOrEmpty(_cbVproOKColor[i].SelectedItem.ToString()) ? _cbVproOKColor[0].SelectedItem.ToString() : _cbVproOKColor[i].SelectedItem.ToString();
                        _graphicVproParam[_nIdx].strNGColor[i] = string.IsNullOrEmpty(_cbVproNGColor[i].SelectedItem.ToString()) ? _cbVproNGColor[0].SelectedItem.ToString() : _cbVproNGColor[i].SelectedItem.ToString();
                        _graphicVproParam[_nIdx].nLineThick[i] = _cbVProLine[i].SelectedIndex;

                    }

                    sql.SaveGraphicToolParam(_strProcName, _strModelName, _nIdx, _dbInfo, _graphicVproParam[_nIdx]);
                }
                SetGraphicview();
            }
            catch (Exception ex)
            {
                _OnMessage("Graphic Result Param Save Error : " + ex.Message, Color.Red, false, false, MsgType.Alarm);
            }

            sql.Dispose();
        }

        private void btnCamExpose_Click(object sender, EventArgs e)
        {
            if (_bSensor)
                return;

            if (!_camParam[_nIdx].bConnect)
            {
                MessageBox.Show("Camera is not connected", "Camera Disconnected", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!flyChk.IsPopupOpen)
            {
                double[] dValue = _camSet[_nIdx].GetCamParam(_camParam[_nIdx].camInterface);

                BarExpose.Properties.Minimum = (int)dValue[1];
                BarExpose.Properties.Maximum = (int)dValue[2];
                txtExposure.Text = string.Format("{0:D}", (int)dValue[0]);

                fypnl.HideBeakForm();
                flyExpose.ShowPopup();
            }
        }

        private void btnexloseClose_Click(object sender, EventArgs e)
        {
            flyExpose.HidePopup();
            fypnl.ShowBeakForm();
        }

        private void BarExpose_EditValueChanged(object sender, EventArgs e)
        {
            int nValue = BarExpose.Value;

            txtExposure.Text = nValue.ToString();
            _camSet[_nIdx].SetExposure((CameraInterface)int.Parse(_camParam[_nIdx].strCamType), nValue);
        }



        private void chkPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPass.Checked)
            {
                chkCamUse.Checked = false;

                _bPassMode = chkPass.Checked;

                lblConnect.BackColor = Color.Yellow;
                chkPass.ForeColor = Color.Yellow;
            }
            else
            {
                chkPass.ForeColor = Color.White;
                _bPassMode = chkPass.Checked;

                if (_camParam[_nIdx].bConnect)
                    lblConnect.BackColor = Color.Lime;
                else
                    lblConnect.BackColor = Color.Red;
            }
        }

        private void chkCamUse_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkCamUse.Checked)
            {
                lblConnect.BackColor = Color.LightGray;
                chkCamUse.ForeColor = Color.Yellow;
            }
            else
            {
                chkCamUse.ForeColor = Color.White;

                if (_camParam[_nIdx].bConnect)
                    lblConnect.BackColor = Color.Lime;
                else
                    lblConnect.BackColor = Color.Red;
            }

            _bCamUse = !chkCamUse.Checked;
        }

        private void btmImgList_Click(object sender, EventArgs e)
        {
            if (_OnResultImageList != null)
            {
                fypnl.HideBeakForm();

                _bUpdate = true;
                _OnResultImageList(_nIdx);
            }
        }


        private void AddGraphic(CogGraphicLabel cogLbl, int nlblCount)
        {
            try
            {
                var dPosX = cogLbl.X;
                var dPosY = cogLbl.Y;

                using (Font font = new Font("Tahoma", _graphicResParam[_nIdx].nSubFontSize, FontStyle.Bold))
                    cogLbl.Font = font;

                cogLbl.Alignment = (CogGraphicLabelAlignmentConstants)Enum.Parse(typeof(CogGraphicLabelAlignmentConstants), _graphicResParam[_nIdx].strAlign);
                cogLbl.X = _graphicResParam[_nIdx].dSubPosX;
                cogLbl.Y = _graphicResParam[_nIdx].dSubPosY + (100 * nlblCount);

                cogDisp.StaticGraphics.Add(cogLbl, "");

                using (Font font = new Font("Tahoma", _graphicResParam[_nIdx].nSubFontSize * 3, FontStyle.Bold))
                    cogLbl.Font = font;

                cogResDisp.StaticGraphics.Add(cogLbl, "");
            }
            catch { }
        }

        private void AddResGraphic(CogGraphicLabel cogLbl)
        {
            try
            {
                if (_graphicResParam[_nIdx].nFontSize == 0)
                    _graphicResParam[_nIdx].nFontSize = 15;

                using (Font font = new Font("Tahoma", _graphicResParam[_nIdx].nFontSize, FontStyle.Bold))
                    cogLbl.Font = font;

                if (_graphicResParam[_nIdx].strAlign != "")
                    cogLbl.Alignment = (CogGraphicLabelAlignmentConstants)Enum.Parse(typeof(CogGraphicLabelAlignmentConstants), _graphicResParam[_nIdx].strAlign);
                else
                    cogLbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;

                cogLbl.X = _graphicResParam[_nIdx].dPosX;
                cogLbl.Y = _graphicResParam[_nIdx].dPosY;

                cogDisp.StaticGraphics.Add(cogLbl, "");

                using (Font font = new Font("Tahoma", _graphicResParam[_nIdx].nFontSize * 3, FontStyle.Bold))
                    cogLbl.Font = font;

                cogResDisp.StaticGraphics.Add(cogLbl, "");
            }
            catch { }
        }

        private void txtExposure_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int.TryParse(txtExposure.Text, out var nExposure);

                if (nExposure < BarExpose.Properties.Minimum || nExposure > BarExpose.Properties.Maximum)
                {
                    MessageBox.Show(new Form { TopMost = true }, string.Format("The exposure value must be greater than {0} or less than {1}", BarExpose.Properties.Minimum, BarExpose.Properties.Maximum));
                    return;
                }

                BarExpose.Value = nExposure;
            }
        }


        private void pnlRes_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 3;

            Color borderColor = Color.Lime;
            if (_result == Result.NG)
                borderColor = Color.Red;
            else if (_result == Result.NONE)
                borderColor = Color.FromArgb(38, 38, 38);

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
            ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
            borderColor, borderWidth, ButtonBorderStyle.Solid);
        }





        private void cbOKColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_cbVproOKColor != null)
                {
                    for (var i = 0; i < _cbVproOKColor.Length; i++)
                        _cbVproOKColor[i].SelectedIndex = cbOKColor.SelectedIndex;
                }

              
            }
            catch { }
        }

        private void cbNGColor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (_cbVproNGColor != null)
                {
                    for (var i = 0; i < _cbVproNGColor.Length; i++)
                        _cbVproNGColor[i].SelectedIndex = cbNGColor.SelectedIndex;
                }

                
            }
            catch { }
        }


    }
}
