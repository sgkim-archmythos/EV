using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.PMAlign;
using MvCamCtrl.NET;
using System.Runtime.InteropServices;

using Basler.Pylon;
using static GlovalVar;
using System.Text.RegularExpressions;
using System.Windows.Media.Media3D;
using DevExpress.Data.Linq.Helpers;
using DevExpress.Utils.About;

namespace VisionSystem
{
    public partial class frmCamera : DevExpress.XtraEditors.XtraForm
    {
        frmMain _frmMain;
        //IniFiles ini = new IniFiles();

        bool _bFinding = false;
        bool _bLive = false;
        //int _nLiveIndex = 0;
        int _nIdx = -1;

        CamPram _CameraParam = new CamPram();

        public frmCamera(frmMain MainFrm, int nIdx)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            _frmMain = MainFrm;
            _nIdx = nIdx;

            _CameraParam = _camParam[_nIdx];
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

        public void InitControl()
        {
            try
            {
                cbCamNo.Properties.Items.Clear();
                cbIP.Properties.Items.Clear();
                cbIP.SelectedIndex = -1;
                cbPixelFormat.Properties.Items.Clear();
                lblSerial.Text = "-";

                lblConnect.BackColor = Color.Red;
                lblConnect.ForeColor = Color.White;
                lblConnect.Text = "DISCONNECTED";

                GetCamCount();

                cbCamNo.Properties.Items.Add("NONE");
                for (int i = 0; i < _nScreenCnt; i++)
                {
                    if (_camParam[i].strCopy == "NONE")
                        cbCamNo.Properties.Items.Add(string.Format("#{0}", i + 1));
                }

                cbCamNo.SelectedIndex = 0;
            }
            catch { }
        }

        private void GetCamCount()
        {
            var nCamCnt = 0;

            if (_frmMain._Balsercameras != null)
                nCamCnt = _frmMain._Balsercameras.Count;

            if (_frmMain._Hikcameras != null)
                nCamCnt += _frmMain._Hikcameras.Count;

            if (_frmMain._KeyenceCameras != null)
                nCamCnt += _frmMain._KeyenceCameras.Count;

            lblCamCnt.Text = nCamCnt.ToString();
        }


        private void SetParam()
        {
            try
            {
                if (_nIdx != -1)
                {
                    var nCamNo = 0;

                    if (!string.IsNullOrEmpty(_CameraParam.strSerial))
                    {
                        if (_CameraParam.strCopy == "NONE" || _CameraParam.strCopy == "")
                        {
                            nCamNo = _nIdx;
                        }
                        else
                        {
                            var strCopyCamNo = Regex.Replace(_CameraParam.strCopy, @"\D", "");   // 읽기 레지스트 : D
                            int.TryParse(strCopyCamNo, out nCamNo);

                            cbCamNo.EditValue = string.Format("#{0}", nCamNo);

                            nCamNo--;
                        }

                        var dValue = new double[3];

                        if (_CameraParam.camInterface == CameraInterface.Basler)
                        {
                            SetCamInfo(CameraInterface.Basler);
                            var strPixelFormatData = _CameraParam.strPixelFormats.Split(',');

                            cbPixelFormat.Properties.Items.AddRange(strPixelFormatData);
                            cbPixelFormat.EditValue = _CameraParam.strCamFormat;

                            _camSet[_nIdx]._BaslerCam = _frmMain._Balsercameras[nCamNo];
                            dValue = _camSet[_nIdx].GetCamParam(CameraInterface.Basler);

                            sliderExpose.Minimum = (int)dValue[1];
                            sliderExpose.Maximum = (int)dValue[2];
                            sliderExpose.Value = (int)_CameraParam.dExpose;

                            sliderExpose.Enabled = true;
                            txtExpose.Enabled = true;
                            radBalser.Checked = true;
                        }
                        else if (_CameraParam.camInterface == CameraInterface.Hik)
                        {
                            SetCamInfo(CameraInterface.Hik);

                            var strPixelFormatData = _CameraParam.strPixelFormats.Split(',');
                            cbPixelFormat.Properties.Items.AddRange(strPixelFormatData);
                            cbPixelFormat.EditValue = _CameraParam.strCamFormat;

                            _camSet[nCamNo]._HikCam = _frmMain._Hikcameras[nCamNo];

                            dValue = _camSet[nCamNo].GetCamParam(CameraInterface.Hik);
                            radHIK.Checked = true;
                        }
                        else if (_CameraParam.camInterface == CameraInterface.KeyenceVJ)
                        {
                            SetCamInfo(CameraInterface.KeyenceVJ);
                            cbPixelFormat.EditValue = _CameraParam.strCamFormat;

                            _camSet[nCamNo]._KeyenceCam = _frmMain._KeyenceCameras[nCamNo];
                            _camSet[nCamNo]._strKeyenceIp = _frmMain._listKeyenceIP[nCamNo];

                            dValue = _camSet[nCamNo].GetCamParam(CameraInterface.KeyenceVJ);
                        }

                        if (_CameraParam.strIP != "")
                            cbIP.EditValue = _CameraParam.strIP;

                        if (_CameraParam.strSerial != "")
                            lblSerial.Text = _CameraParam.strSerial;

                        if (_CameraParam.strCamFormat != "")
                            cbPixelFormat.EditValue = _CameraParam.strCamFormat;

                        if (_CameraParam.dExpose > 0)
                            txtExpose.Text = _CameraParam.dExpose.ToString();

                        sliderExpose.Minimum = (int)dValue[1];
                        sliderExpose.Maximum = (int)dValue[2];
                        sliderExpose.Value = (int)_CameraParam.dExpose;

                        sliderExpose.Enabled = true;
                        txtExpose.Enabled = true;

                        if (_CameraParam.bConnect)
                        {
                            _camSet[_nIdx]._GrabComplete = GrabCompelte;
                            lblConnect.Text = "CONNECTED";
                            lblConnect.BackColor = lime;
                            lblConnect.ForeColor = black;

                            btnConnect.Text = "Disconnect";
                        }
                    }
                }
            }
            catch
            { }
        }

        private void SetCamInfo(CameraInterface cameraInterface)
        {
            try
            {
                if (cameraInterface == CameraInterface.Basler)
                {
                    for (var i = 0; i < _frmMain._Balsercameras.Count; i++)
                        cbIP.Properties.Items.Add(string.Format("{0}:{1}", _frmMain._Balsercameras[i].CameraInfo["FriendlyName"], _frmMain._Balsercameras[i].CameraInfo["Address"]));
                }
                else if (cameraInterface == CameraInterface.Hik)
                {
                    MyCamera.MV_CC_DEVICE_INFO device = new MyCamera.MV_CC_DEVICE_INFO();
                    MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = new MyCamera.MV_GIGE_DEVICE_INFO();

                    for (var i = 0; i < _frmMain._Hikcameras.Count; i++)
                    {
                        _frmMain._Hikcameras[i].MV_CC_GetDeviceInfo_NET(ref device);
                        gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                        MyCamera.MV_CC_DEVICE_INFO.SPECIAL_INFO info = device.SpecialInfo;

                        cbIP.Properties.Items.Add(string.Format("{0}:{1}.{2}.{3}.{4}", gigeInfo.chUserDefinedName, info.stGigEInfo[11].ToString(), info.stGigEInfo[10].ToString(), info.stGigEInfo[9].ToString(), info.stGigEInfo[8].ToString()));
                    }
                }
                else if (cameraInterface == CameraInterface.KeyenceVJ)
                {
                    for (var i = 0; i < _frmMain._listKeyenceIP.Count; i++)
                    {
                        cbIP.Properties.Items.Add(_frmMain._listKeyenceIP[i]);
                    }
                }
            }
            catch { }
        }
        private static DateTime Delay(int MS)
        {
            DateTime ThisMoment = DateTime.Now;
            TimeSpan duration = new TimeSpan(0, 0, 0, 0, MS);
            DateTime AfterWards = ThisMoment.Add(duration);
            while (AfterWards >= ThisMoment)
            {
                System.Windows.Forms.Application.DoEvents();
                ThisMoment = DateTime.Now;
            }
            return DateTime.Now;
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_bLive)
                _camSet[_nIdx].LiveView((CameraInterface)int.Parse(_CameraParam.strCamType), false);

            _camSet[_nIdx]._GrabComplete = _frmMain.GrabComplete;
            Close();
        }


        private void btnCamSearch_Click(object sender, EventArgs e)
        {
            if (!_bFinding)
            {
                _bFinding = true;

                splashScreenManager1.ShowWaitForm();
            }

            Delay(200);

            _frmMain.InitCam();
            splashScreenManager1.CloseWaitForm();

            GetCamCount();
            _bFinding = false;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {
                if (btnConnect.Text == "Connect")
                {
                    if (cbCamNo.EditValue.ToString() != "NONE")
                    {
                        var strCopyCamNo = Regex.Replace(cbCamNo.EditValue.ToString(), @"\D", "");   // 읽기 레지스트 : D
                        int.TryParse(strCopyCamNo, out var nCamNo);

                        if (_CameraParam.bConnect)
                        {
                            _camSet[nCamNo].LiveView(CameraInterface.Basler, false);

                            _CameraParam.bConnect = true;
                            _camSet[_nIdx]._GrabComplete = GrabCompelte;
                            _CameraParam.strCopy = (nCamNo - 1).ToString();

                            lblConnect.Text = "CONNECTED";
                            lblConnect.BackColor = Color.Lime;
                            lblConnect.ForeColor = Color.Black;

                            btnConnect.Text = "Disconnect";
                        }
                        else
                        {
                            lblConnect.Text = "DISCONNECTED";
                            lblConnect.BackColor = Color.Red;
                            lblConnect.ForeColor = Color.White;
                        }
                    }
                    else
                    {
                        if (radBalser.Checked)
                            _camSet[_nIdx].LiveView(CameraInterface.Basler, false);
                        else if (radHIK.Checked)
                            _camSet[_nIdx].LiveView(CameraInterface.Hik, false);

                        if (cbIP.SelectedIndex == -1)
                        {
                            MessageBox.Show("Please select a camera Serial", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (radBalser.Checked)
                            _CameraParam.camInterface = CameraInterface.Basler;
                        else if (radHIK.Checked)
                            _CameraParam.camInterface = CameraInterface.Hik;
                        else if (radKeyenceVJ.Checked)
                            _CameraParam.camInterface = CameraInterface.KeyenceVJ;

                        _CameraParam.strSerial = lblSerial.Text;
                        _CameraParam.strIP = cbIP.EditValue.ToString();
                        _CameraParam.strCamFormat = cbPixelFormat.EditValue.ToString();
                        _CameraParam.strCopy = cbCamNo.EditValue.ToString();
                        _CameraParam.dExpose = sliderExpose.Value;
                        _CameraParam.strCamFormat = cbPixelFormat.EditValue.ToString();

                        _camSet[_nIdx].CamConnect(_nIdx, _frmMain._Balsercameras, _frmMain._Hikcameras, _frmMain._KeyenceCameras, _frmMain._listKeyenceIP, ref _CameraParam);

                        _camParam[_nIdx] = _CameraParam;
                        if (_CameraParam.bConnect)
                        {
                            _camSet[_nIdx]._GrabComplete = GrabCompelte;

                            lblConnect.Text = "CONNECTED";
                            lblConnect.BackColor = Color.Lime;
                            lblConnect.ForeColor = Color.Black;
                            btnConnect.Text = "Disconnect";
                            _frmMain.AddMsg(string.Format("Camera #{0} Connected", _nIdx + 1), Color.GreenYellow, true, false, GlovalVar.MsgType.Alarm);
                        }
                        else
                        {
                            lblConnect.Text = "DISCONNECTED";
                            lblConnect.BackColor = Color.Red;
                            lblConnect.ForeColor = Color.White;
                            btnConnect.Text = "Connect";
                            _frmMain.AddMsg(string.Format("Camera #{0} Disconnected", _nIdx + 1), Color.Red, true, true, GlovalVar.MsgType.Alarm);
                        }
                    }
                }
                else
                {
                    if (_CameraParam.bConnect)
                    {
                        //_camSet[_nIdx].CamDisconnect();

                        for (int i = 0; i < _nScreenCnt; i++)
                        {
                            if (_CameraParam.strCopy == _nIdx.ToString())
                            {
                                _CameraParam.bConnect = false;
                                _frmMain._CAM[i].LoadSet();
                            }
                        }

                        lblConnect.Text = "DISCONNECTED";
                        lblConnect.BackColor = Color.Red;
                        lblConnect.ForeColor = Color.White;
                        btnConnect.Text = "Connect";
                        _frmMain.AddMsg(string.Format("Camera #{0} Disconnected", _nIdx + 1), Color.Red, true, true, GlovalVar.MsgType.Alarm);
                    }

                    //InitControl();
                }
            }
            catch (Exception ex)
            {
                _frmMain.AddMsg("Camera Connect Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private void GrabCompelte(int nIdx, Bitmap bmpImg, ICogImage cogGrab)
        {
            try
            {
                if (bmpImg != null)
                {
                    Bitmap bmpGrab = (Bitmap)bmpImg.Clone();

                    if (bmpGrab.PixelFormat.ToString().ToLower().Contains("mono"))
                    {
                        using (CogImage8Grey cogImg = new CogImage8Grey(bmpGrab))
                        {
                            cogView.AutoFit = true;
                            cogView.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                        }
                    }
                    else
                    {
                        using (CogImage24PlanarColor cogImg = new CogImage24PlanarColor(bmpGrab))
                        {
                            cogView.AutoFit = true;
                            cogView.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                        }
                    }

                    bmpGrab.Dispose();
                    bmpGrab = null;
                }
                else if (cogGrab != null)
                {
                    cogView.AutoFit = true;
                    cogView.Image = cogGrab.CopyBase(CogImageCopyModeConstants.CopyPixels);
                }
            }
            catch (Exception ex) { _frmMain.AddMsg("Camera GrabFunc Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm); }
        }


        private void btnGrab_Click(object sender, EventArgs e)
        {
            try
            {
                if (!_CameraParam.bConnect)
                {
                    MessageBox.Show("Camera Disconnected");
                    return;
                }

                double.TryParse(txtExpose.Text, out var dExposure);
                _camSet[_nIdx].Grab(_nIdx, dExposure);
            }
            catch (Exception ex)
            {
                MessageBox.Show(new Form { TopMost = true }, "Camera Grab Error : " + ex.Message);
            }
        }


        private void btnLive_Click(object sender, EventArgs e)
        {
            if (!_CameraParam.bConnect)
            {
                MessageBox.Show("Camera Disconnected");
                return;
            }

            _bLive = !_bLive;

            try
            {
                if (_bLive)
                {
                    if (sliderExpose.Value > 0)
                        _camSet[_nIdx].SetExposure((CameraInterface)int.Parse(_CameraParam.strCamType), sliderExpose.Value);

                    _camSet[_nIdx].LiveView((CameraInterface)int.Parse(_CameraParam.strCamType), true);

                    CogGraphicLabel lblLive = new CogGraphicLabel();
                    lblLive.SetXYText(50, 70, "Live");
                    using (Font font = new Font("Tahoma", 20, FontStyle.Bold))
                        lblLive.Font = font;
                    lblLive.Color = CogColorConstants.Green;
                    lblLive.Alignment = CogGraphicLabelAlignmentConstants.BaselineLeft;

                    cogView.StaticGraphics.Add(lblLive, "Live");
                }
                else
                {
                    _camSet[_nIdx].LiveView((CameraInterface)int.Parse(_CameraParam.strCamType), false);
                    cogView.StaticGraphics.Clear();
                }
            }
            catch (Exception ex)
            {
                _frmMain.AddMsg("Live Error : " + ex.Message, Color.Red, true, true, GlovalVar.MsgType.Alarm);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!_CameraParam.bConnect)
            {
                MessageBox.Show("Please connect the camera and save it", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                if (radBalser.Checked)
                    _CameraParam.camInterface = CameraInterface.Basler;
                else if (radHIK.Checked)
                    _CameraParam.camInterface = CameraInterface.Hik;
                else if (radKeyenceVJ.Checked)
                    _CameraParam.camInterface = CameraInterface.KeyenceVJ;

                _CameraParam.strSerial = lblSerial.Text;
                _CameraParam.strIP = cbIP.EditValue.ToString();
                _CameraParam.strCamFormat = cbPixelFormat.EditValue.ToString();
                _CameraParam.strCopy = cbCamNo.EditValue.ToString();
                _CameraParam.dExpose = sliderExpose.Value;
                _CameraParam.strCamFormat = cbPixelFormat.EditValue.ToString();
                _CameraParam.strIP = cbIP.SelectedItem.ToString();
                _CameraParam.strCamFormat = cbPixelFormat.SelectedItem.ToString();
                _CameraParam.strSerial = lblSerial.Text;
                double.TryParse(txtExpose.Text, out _CameraParam.dExpose);

                _camParam[_nIdx] = _CameraParam;
                //_camSet[_nIdx] = _frmMain._camSet[_nIdx];

                _frmMain._CAM[_nIdx].SaveCamParam();
                _frmMain._CAM[_nIdx].LoadSet();

                MessageBox.Show("saved the camera information.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                _frmMain.AddMsg("Error saving camera settings" + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cbCamNo.EditValue.ToString() == "NONE")
            {
                MessageBox.Show("Please select the camera you want to copy.", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                return;
            }

            try
            {
                var strCopyCamNo = Regex.Replace(cbCamNo.EditValue.ToString(), @"\D", "");   // 읽기 레지스트 : D
                int.TryParse(strCopyCamNo, out var nCamNo);

                _camSet[_nIdx] = _camSet[nCamNo - 1];
                _CameraParam = _camParam[nCamNo - 1];
                _CameraParam.strCopy = cbCamNo.EditValue.ToString();

                if (_CameraParam.camInterface == CameraInterface.Basler)
                    radBalser.Checked = true;
                else if (_CameraParam.camInterface == CameraInterface.Hik)
                    radHIK.Checked = true;
                else if (_CameraParam.camInterface == CameraInterface.KeyenceVJ)
                    radKeyenceVJ.Checked = true;

                SetParam();

                _camSet[_nIdx]._GrabComplete = GrabCompelte;
            }
            catch { }
        }

        private void radBalser_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                (sender as RadioButton).ForeColor = Color.Yellow;
            else
                (sender as RadioButton).ForeColor = Color.White;
        }

        private void radBalser_Click(object sender, EventArgs e)
        {
            var strTag = (sender as RadioButton).Tag as string;
            int.TryParse(strTag, out var nCamType);

            InitControl();
            SetCamInfo((CameraInterface)nCamType);
            //SetParam();
        }

        private void cbIP_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIP.SelectedIndex == -1 || (!radBalser.Checked && !radHIK.Checked && !radKeyenceVJ.Checked))
                return;

            var strIP = cbIP.SelectedItem.ToString();

            if (radBalser.Checked)
            {
                for (var i = 0; i < _frmMain._Balsercameras.Count; i++)
                {
                    if (string.Format("{0}:{1}", _frmMain._Balsercameras[i].CameraInfo["FriendlyName"], _frmMain._Balsercameras[i].CameraInfo["Address"]) == strIP)
                    {
                        lblSerial.Text = _frmMain._Balsercameras[i].CameraInfo["SerialNumber"];
                        cbPixelFormat.Properties.Items.Clear();
                        var strPixelFormat = _frmMain._Balsercameras[i].Parameters[PLCamera.PixelFormat].GetValue();

                        _frmMain._Balsercameras[i].Parameters[PLCamera.PixelFormat].GetEnumerator().Reset();
                        var strPixelList = _frmMain._Balsercameras[i].Parameters[PLCamera.PixelFormat].GetEnumerator();

                        while (true)
                        {
                            if (!strPixelList.MoveNext())
                                break;

                            cbPixelFormat.Properties.Items.Add(strPixelList.Current.ToString());
                        }

                        cbPixelFormat.EditValue = strPixelFormat;

                        var dExposure = _frmMain._Balsercameras[i].Parameters[PLCamera.ExposureTimeAbs].GetValue();
                        var dExposureMin = _frmMain._Balsercameras[i].Parameters[PLCamera.AutoExposureTimeAbsLowerLimit].GetValue();
                        var dExposureMax = _frmMain._Balsercameras[i].Parameters[PLCamera.AutoExposureTimeAbsUpperLimit].GetValue();

                        txtExpose.Text = dExposure.ToString();
                        sliderExpose.Minimum = (int)dExposureMin;
                        sliderExpose.Maximum = (int)dExposureMax;
                        sliderExpose.Value = (int)dExposure;

                        _camSet[_nIdx]._BaslerCam = _frmMain._Balsercameras[i];

                        break;
                    }
                }
            }
            else if (radHIK.Checked)
            {
                MyCamera.MV_CC_DEVICE_INFO device = new MyCamera.MV_CC_DEVICE_INFO();
                MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = new MyCamera.MV_GIGE_DEVICE_INFO();

                for (var i = 0; i < _frmMain._Hikcameras.Count; i++)
                {
                    _frmMain._Hikcameras[i].MV_CC_GetDeviceInfo_NET(ref device);
                    gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));

                    if (string.Format("{0}:{1}", gigeInfo.chModelName, gigeInfo.nCurrentIp) == strIP)
                    {
                        lblSerial.Text = gigeInfo.chSerialNumber;

                        MyCamera.MVCC_ENUMVALUE eNUMVALUE = new MyCamera.MVCC_ENUMVALUE();
                        _frmMain._Hikcameras[i].MV_CC_GetPixelFormat_NET(ref eNUMVALUE);

                        string[] strPixelFormat = new string[eNUMVALUE.nSupportedNum];
                        string[] strTemp = null;

                        for (var j = 0; j < eNUMVALUE.nSupportedNum - 1; j++)
                        {
                            if (eNUMVALUE.nSupportValue[j + 1] > 0)
                            {
                                strTemp = GetPixelFormat(eNUMVALUE.nSupportValue[j + 1]).Split('_');
                                strPixelFormat[j] = strTemp[2];

                                if (j > 0)
                                    cbPixelFormat.Properties.Items.Add(strPixelFormat[j]);
                            }
                        }

                        cbPixelFormat.EditValue = strPixelFormat[0];

                        MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();

                        int nRet = _frmMain._Hikcameras[i].MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);

                        var dExposure = 0.0;
                        var dExposureMin = 0.0;
                        var dExposureMax = 0.0;
                        if (MyCamera.MV_OK == nRet)
                        {
                            dExposure = stParam.fCurValue;
                            dExposureMin = stParam.fMin;
                            dExposureMax = stParam.fMax;
                        }

                        txtExpose.Text = dExposure.ToString();
                        sliderExpose.Minimum = (int)dExposureMin;
                        sliderExpose.Maximum = (int)dExposureMax;
                        sliderExpose.Value = (int)dExposure;

                        _camSet[_nIdx]._HikCam = _frmMain._Hikcameras[i];

                        break;
                    }
                }
            }
            else if (radKeyenceVJ.Checked)
            {
                for (var i = 0; i < _frmMain._listKeyenceIP.Count; i++)
                {
                    if (_frmMain._listKeyenceIP[i] == strIP)
                    {
                        var strIPAddr = _frmMain._listKeyenceIP[i].Split(':');
                        lblSerial.Text = strIPAddr[2];

                        double.TryParse(_frmMain._KeyenceCameras[i].GetFeatureValue(strIPAddr[0], "ExposureTime").ToString(), out var dExposure);
                        var dExposureMin = 17;
                        var dExposureMax = 1000000;

                        var strPixelFormat = _frmMain._KeyenceCameras[i].GetFeatureValue(strIPAddr[0], "PixelFormat").ToString();

                        cbPixelFormat.EditValue = strPixelFormat;

                        txtExpose.Text = dExposure.ToString();
                        sliderExpose.Minimum = (int)dExposureMin;
                        sliderExpose.Maximum = (int)dExposureMax;
                        sliderExpose.Value = (int)dExposure;

                        _camSet[_nIdx]._KeyenceCam = _frmMain._KeyenceCameras[i];
                        _camSet[_nIdx]._strKeyenceIp = strIPAddr[0];

                        break;
                    }
                }
            }

            sliderExpose.Enabled = true;
            txtExpose.Enabled = true;
        }

        public string GetPixelFormat(uint uPixelFormat)
        {
            var strPixelFormat = "";
            switch (uPixelFormat)
            {
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed.ToString();
                case (int)MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
                    return strPixelFormat = MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed.ToString();
            }

            return strPixelFormat;
        }

        private void cbCamNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbCamNo.EditValue.ToString() == "NONE")
                InitControl();
            else
                SetParam();
        }

        private void txtExpose_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    int.TryParse(txtExpose.Text, out var nValue);

                    if (nValue < sliderExpose.Minimum || nValue > sliderExpose.Maximum)
                    {
                        MessageBox.Show(new Form { TopMost = true }, string.Format("The exposure value is between {0} and {1}.", sliderExpose.Minimum, sliderExpose.Maximum));
                        return;
                    }

                    sliderExpose.Value = nValue;
                }
                catch { }
            }
        }

        private void sliderExpose_ValueChanged(object sender, EventArgs e)
        {
            if (_CameraParam.bConnect)
            {
                CameraInterface cameraInterface = CameraInterface.Basler;
                if (radBalser.Checked)
                    cameraInterface = CameraInterface.Basler;
                else if (radHIK.Checked)
                    cameraInterface = CameraInterface.Hik;
                else if (radKeyenceVJ.Checked)
                    cameraInterface = CameraInterface.KeyenceVJ;

                _camSet[_nIdx].SetExposure(cameraInterface, sliderExpose.Value);
            }
        }

        private void frmCamera_Load(object sender, EventArgs e)
        {
            InitControl();
            SetParam();
            _camSet[_nIdx]._GrabComplete = GrabCompelte;

            ActiveControl = lblCam;
        }
    }
}