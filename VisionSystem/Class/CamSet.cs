using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cognex.VisionPro;
using Basler.Pylon;
using System.Windows.Forms;
using System.Threading;
using System.Drawing.Imaging;
using System.Drawing;
using MvCamCtrl.NET;
using System.Runtime.InteropServices;
using System.IO;
using System.Windows.Media.Imaging;
using System.Windows.Forms.Layout;

using Cognex.VisionPro.FGGigE;
using static GlovalVar;
using System.Windows.Media;
using VisionSystem;

public delegate void DeviceDisconnectedDelegate(string sDeviceIPAddress);
public delegate void DeviceEventGenICamDelegate(string sDeviceIPAddress, string sEventMessage);
public delegate void CamLostConnect();
public delegate void GrabHandler(int nIdx, Bitmap bmpImg, ICogImage cogGrab);
public delegate void MessageHanlder(string strMsg, System.Drawing.Color color, bool bShowMsg, bool bError, int msgType);
public delegate void AcquisitionStart();
public class CamSet
{
    [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
    public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);

    public CamLostConnect _OnCamLostConnect;
    public GrabHandler _GrabComplete;
    public MessageHanlder _MessageFunc;

    public Camera _BaslerCam = null;
    public MyCamera _HikCam = null;
    public CameraControl _KeyenceCam = null;
    public string _strKeyenceIp = "";

    MyCamera.MV_FRAME_OUT_INFO_EX m_stFrameInfo;

    UInt32 m_nBufSizeForDriver = 0;
    IntPtr m_BufForDriver = IntPtr.Zero;
    private static Object BufForDriverLock = new Object();

    private MyCamera.cbExceptiondelegate pCallBackFunc;
    //public int _nCamCnt = 0;
    //public bool _bConnect = false;

    public bool _bGrabThread = false;
    bool _bGrab = false;
    //public int _nCamType = -1;
    public int _nIdx = -1;
    //public bool _bCamCopy = false;
    bool _bLive = false;
    //double _dExpose = 0;


    bool _bKeyenceTrigger = false;
    private Utility instUtility = new Utility();
    //public string _strPixelFormat = "";

    Bitmap _bmpImg = null;
    ICogImage _cogImg = null;


    public string CamConnect(int nSel, List<Camera> Balsercameras, List<MyCamera> Hikcameras, List<CameraControl> KeyenceCameras, List<string> listKeyenceIP, ref CamPram camParam)
    {
        string strRes = "";
        int nidx = 0;
        try
        {
            if (camParam.camInterface == CameraInterface.NONE)
                strRes = "No camera connection information";
            else
            {
                if (camParam.camInterface == CameraInterface.Basler)
                {
                    if (camParam.strCopy == "" || camParam.strCopy == "NONE")
                    {
                        if (_BaslerCam != null)
                        {
                            camParam.bConnect = false;
                            //_bConnect = false;
                            _BaslerCam.StreamGrabber.Stop();
                            _BaslerCam = null;
                        }

                        for (var i = 0; i < Balsercameras.Count; i++)
                        {
                            if (string.Format("{0}:{1}", Balsercameras[i].CameraInfo["FriendlyName"], Balsercameras[i].CameraInfo["Address"]) == camParam.strIP)
                            {
                                _BaslerCam = Balsercameras[i];

                                if (_BaslerCam == null)
                                    _BaslerCam.ConnectionLost += new EventHandler<EventArgs>(this.OnConnectionLost);

                                if (!_BaslerCam.IsOpen)
                                    _BaslerCam.Open();

                                SetTriggerMode(camParam.camInterface, true, 0);

                                if (camParam.dExpose > 0)
                                    SetExposure(camParam.camInterface, camParam.dExpose);

                                _BaslerCam.Parameters[PLCamera.PixelFormat].GetEnumerator().Reset();
                                var strPixelList = _BaslerCam.Parameters[PLCamera.PixelFormat].GetEnumerator();

                                camParam.strPixelFormats = "";
                                while (true)
                                {
                                    if (!strPixelList.MoveNext())
                                        break;

                                    if (camParam.strPixelFormats == "")
                                        camParam.strPixelFormats += strPixelList.Current.ToString();
                                    else
                                        camParam.strPixelFormats += "," + strPixelList.Current.ToString();
                                }

                                SetPixelFormat(CameraInterface.Basler, camParam.strCamFormat);

                                camParam.strVender = "Basler";
                                camParam.strCamType = _BaslerCam.CameraInfo["ModelName"].Substring(2, 1) == "A" ? "에어리어 스캔 카메라" : "라인 스캔 카메라";
                                camParam.strSerial = _BaslerCam.CameraInfo["SerialNumber"];
                                camParam.strModel = _BaslerCam.CameraInfo["ModelName"];
                                camParam.strResolution = string.Format("{0} * {1}", _BaslerCam.Parameters[PLCamera.Width].GetValue(), _BaslerCam.Parameters[PLCamera.Height].GetValue());

                                _BaslerCam.StreamGrabber.Start();
                                _BaslerCam.StreamGrabber.GrabResultWaitHandle.WaitOne(0);

                                camParam.bConnect = true;
                                //_bConnect = true;
                                //_nCamType = int.Parse(camParam.strCamType);

                                break;
                            }
                        }
                    }
                }
                else if (camParam.camInterface == CameraInterface.Hik)
                {
                    if (string.IsNullOrEmpty(camParam.strCopy) || camParam.strCopy == "-1")
                    {
                        MyCamera.MV_CC_DEVICE_INFO device = new MyCamera.MV_CC_DEVICE_INFO();
                        MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = new MyCamera.MV_GIGE_DEVICE_INFO();
                        MyCamera.MV_CC_DEVICE_INFO.SPECIAL_INFO info = new MyCamera.MV_CC_DEVICE_INFO.SPECIAL_INFO();

                        for (var i = 0; i < Hikcameras.Count; i++)
                        {
                            Hikcameras[i].MV_CC_GetDeviceInfo_NET(ref device);
                            gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)MyCamera.ByteToStruct(device.SpecialInfo.stGigEInfo, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                            info = device.SpecialInfo;

                            if (string.Format("{0}:{1}.{2}.{3}.{4]", gigeInfo.chUserDefinedName, info.stGigEInfo[11].ToString(), info.stGigEInfo[10].ToString(), info.stGigEInfo[9].ToString(), info.stGigEInfo[8].ToString()) == camParam.strIP)
                            {
                                if (null == _HikCam)
                                {
                                    _HikCam = new MyCamera();
                                    if (null == _HikCam)
                                    {
                                        return "Hik Cam Error";
                                    }
                                }

                                int nRet = _HikCam.MV_CC_CreateDevice_NET(ref device);
                                if (MyCamera.MV_OK != nRet)
                                {
                                    return "Device Create fail!";
                                }

                                nRet = _HikCam.MV_CC_OpenDevice_NET();
                                if (MyCamera.MV_OK != nRet)
                                {
                                    _HikCam.MV_CC_DestroyDevice_NET();
                                    return "Device open fail!";
                                }

                                _HikCam.MV_CC_SetHeartBeatTimeout_NET(3000);

                                if (device.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                                {
                                    int nPacketSize = _HikCam.MV_CC_GetOptimalPacketSize_NET();
                                    if (nPacketSize > 0)
                                    {
                                        nRet = _HikCam.MV_CC_SetIntValue_NET("GevSCPSPacketSize", (uint)nPacketSize);
                                        if (nRet != MyCamera.MV_OK)
                                        {
                                            return "Set Packet Size failed!";
                                        }
                                    }
                                    else
                                    {
                                        return "Get Packet Size failed!";
                                    }
                                }

                                pCallBackFunc = new MyCamera.cbExceptiondelegate(cbExceptiondelegate);
                                nRet = _HikCam.MV_CC_RegisterExceptionCallBack_NET(pCallBackFunc, IntPtr.Zero);

                                GC.KeepAlive(pCallBackFunc);

                                MyCamera.MVCC_ENUMVALUE eNUMVALUE = new MyCamera.MVCC_ENUMVALUE();
                                _HikCam.MV_CC_GetPixelFormat_NET(ref eNUMVALUE);

                                camParam.strPixelFormats = "";
                                var strPixelformat = "";
                                for (var j = 0; j < eNUMVALUE.nSupportedNum - 1; j++)
                                {
                                    if (eNUMVALUE.nSupportValue[j + 1] > 0)
                                    {
                                        var strTemp = GetPixelFormat(eNUMVALUE.nSupportValue[j + 1]).Split('_');
                                        strPixelformat = strTemp[2];

                                        if (camParam.strPixelFormats == "")
                                            camParam.strPixelFormats += strPixelformat;
                                        else
                                            camParam.strPixelFormats += strPixelformat;
                                    }
                                }

                                MyCamera.MVCC_INTVALUE mVCC = new MyCamera.MVCC_INTVALUE();
                                _HikCam.MV_CC_GetWidth_NET(ref mVCC);
                                var nWidth = mVCC.nCurValue;

                                _HikCam.MV_CC_GetHeight_NET(ref mVCC);
                                var nHeight = mVCC.nCurValue;

                                camParam.strVender = "Hik";
                                camParam.strCamType = "에어리어 스캔 카메라";
                                camParam.strSerial = gigeInfo.chSerialNumber;
                                camParam.strModel = gigeInfo.chModelName;
                                camParam.strResolution = string.Format("{0} * {1}", nWidth, nHeight);

                                _HikCam.MV_CC_SetEnumValue_NET("AcquisitionMode", (uint)MyCamera.MV_CAM_ACQUISITION_MODE.MV_ACQ_MODE_CONTINUOUS);
                                _HikCam.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                                _HikCam.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);

                                if (nRet != MyCamera.MV_OK)
                                {
                                    return "Set Exposure Time Fail!";
                                }

                                nRet = _HikCam.MV_CC_StartGrabbing_NET();

                                if (nRet != MyCamera.MV_OK)
                                    return "Start Grabbing Fail!";

                                camParam.bConnect = true;
                                //_bConnect = true;
                                //_nCamType = int.Parse(camParam.strCamType);

                                break;
                            }
                        }
                    }
                }
                else if ((CameraInterface)int.Parse(camParam.strCamType) == CameraInterface.KeyenceVJ)
                {
                    for (var i = 0; i < listKeyenceIP.Count; i++)
                    {
                        if (listKeyenceIP[i] == camParam.strIP)
                        {
                            if (_KeyenceCam == null)
                            {
                                DeviceDisconnectedDelegate _OnDeviceDisconnected = new DeviceDisconnectedDelegate(OnDeviceDisconnected);
                                DeviceEventGenICamDelegate _OnDeviceEventGenICam = new DeviceEventGenICamDelegate(OnDeviceEventGenICam);
                            }

                            _KeyenceCam = KeyenceCameras[i];
                            var CamInfo = camParam.strIP.Split(':');
                            _strKeyenceIp = CamInfo[0];

                            camParam.strVender = "Keyence";
                            camParam.strCamType = "에어리어 스캔 카메라";
                            camParam.strSerial = CamInfo[2];
                            camParam.strModel = CamInfo[1];
                            camParam.strResolution = string.Format("{0} * {1}", _KeyenceCam.GetCameraInfo(_strKeyenceIp).kglDevice.getDeviceParameters().getIntegerValue("Width"), _KeyenceCam.GetCameraInfo(_strKeyenceIp).kglDevice.getDeviceParameters().getIntegerValue("Height"));

                            camParam.bConnect = true;

                            break;
                        }
                    }
                }

                if (camParam.bConnect)
                {
                    if (!_bGrabThread)
                    {
                        _bGrabThread = true;
                        Thread threadGrab = new Thread(GrabThread);
                        threadGrab.Start();
                    }
                }
            }
        }
        catch (Exception ex)
        {
            strRes = "Camera Connect Error : " + ex.Message;
        }

        return strRes;
    }

    private void OnDeviceEventGenICam(string sDeviceIPAddress, string sEventMessage)
    {
    }

    private void OnDeviceDisconnected(string sDeviceIPAddress)
    {
        _camParam[_nIdx].bConnect = false;

        if (_OnCamLostConnect != null)
            _OnCamLostConnect();
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

    public void SetPixelFormat(CameraInterface cameraInterface, string strFormat)
    {
        if (cameraInterface == CameraInterface.Basler)
            _BaslerCam.Parameters[PLCamera.PixelFormat].SetValue(strFormat);

    }

    private void OnConnectionLost(Object sender, EventArgs e)
    {
        _camParam[_nIdx].bConnect = false;

        if (_OnCamLostConnect != null)
            _OnCamLostConnect();
    }

    private void cbExceptiondelegate(uint nMsgType, IntPtr pUser)
    {
        _camParam[_nIdx].bConnect = false;

        if (nMsgType == MyCamera.MV_EXCEPTION_DEV_DISCONNECT)
        {
            if (_OnCamLostConnect != null)
                _OnCamLostConnect();
        }
    }

    private bool IsMonoPixelFormat(MyCamera.MvGvspPixelType enType)
    {
        switch (enType)
        {
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                return true;
            default:
                return false;
        }
    }

    private bool IsColorPixelFormat(MyCamera.MvGvspPixelType enType)
    {
        switch (enType)
        {
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BGR8_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_YUV422_YUYV_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR8:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG8:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB8:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG8:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB10_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG10_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG10_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR10_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGB12_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerBG12_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerRG12_Packed:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12:
            case MyCamera.MvGvspPixelType.PixelType_Gvsp_BayerGR12_Packed:
                return true;
            default:
                return false;
        }
    }

    public double[] GetCamParam(CameraInterface cameraInterface)
    {
        double[] dValue = new double[3] { 0, 0, 0 };

        if (cameraInterface == CameraInterface.Basler)
        {
            dValue[0] = _BaslerCam.Parameters[PLCamera.ExposureTimeAbs].GetValue();
            dValue[1] = _BaslerCam.Parameters[PLCamera.AutoExposureTimeAbsLowerLimit].GetValue();
            dValue[2] = _BaslerCam.Parameters[PLCamera.AutoExposureTimeAbsUpperLimit].GetValue();
        }
        else if (cameraInterface == CameraInterface.Hik)
        {
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();

            int nRet = _HikCam.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                dValue[0] = stParam.fCurValue;
                dValue[1] = stParam.fMin;
                dValue[2] = stParam.fMax;
            }
        }
        else if (cameraInterface == CameraInterface.KeyenceVJ)
        {
            dValue[0] = (double)_KeyenceCam.GetFeatureValue(_strKeyenceIp, "ExposureTime");
            dValue[1] = 17;
            dValue[2] = 100000;
        }

        return dValue;
    }


    public void SetExposure(CameraInterface cameraInterface, double dValue)
    {
        try
        {
            var dExposure = dValue == 0 ? 1000 : dValue;

            if (cameraInterface == CameraInterface.Basler)
            {
                _BaslerCam.Parameters[PLCamera.ExposureTimeAbs].SetValue(dExposure);
            }
            else if (cameraInterface == CameraInterface.Hik)
            {
                _HikCam.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
                _HikCam.MV_CC_SetFloatValue_NET("ExposureTime", (float)dExposure);
            }
            else if (cameraInterface == CameraInterface.KeyenceVJ)
            {
                _KeyenceCam.SetFeatureValue(_strKeyenceIp, "ExposureTime", dValue.ToString());
            }
        }
        catch { }
    }

    public void CamDisconnect()
    {
        _bGrabThread = false;

        Thread.Sleep(100);

        try
        {
            if (_camParam[_nIdx].camInterface == CameraInterface.Basler)
            {
                if (_BaslerCam != null)
                {
                    _BaslerCam.StreamGrabber.Stop();
                    _BaslerCam.Close();

                    _BaslerCam = null;
                }
            }
            else if (_camParam[_nIdx].camInterface == CameraInterface.Hik)
            {
                if (_HikCam != null)
                {
                    _HikCam.MV_CC_CloseDevice_NET();
                    _HikCam.MV_CC_DestroyDevice_NET();

                    _HikCam = null;
                }
            }
            else if (_camParam[_nIdx].camInterface == CameraInterface.KeyenceVJ)
            {
                bool bStatus = Convert.ToBoolean(_KeyenceCam.GetFeatureValue(_strKeyenceIp, "BufferCaptureAcquisitionActiveStatus"));
                bool ret = _KeyenceCam.Disconnect(_strKeyenceIp);
            }
        }
        catch { }

        
        //_bConnect = false;
    }

    private void GrabThread()
    {
        int nWidth = 0, nHeight = 0;
        int nRet = 0;

        PixelDataConverter converter = null;

        CamPram camParam = new CamPram();

        while (true)
        {
            camParam = _camParam[_nIdx];
            try
            {
                if (camParam.camInterface == CameraInterface.Basler)
                {
                    if (converter == null)
                        converter = new PixelDataConverter();

                    IGrabResult grabResult = _BaslerCam.StreamGrabber.RetrieveResult(System.Threading.Timeout.Infinite, TimeoutHandling.ThrowException);

                    if (!_bGrabThread)
                        return;

                    using (grabResult)
                    {
                        if (grabResult == null)
                            continue;

                        if (grabResult.GrabSucceeded)
                        {
                            nWidth = grabResult.Width;
                            nHeight = grabResult.Height;

                            _bmpImg = null;
                            _cogImg = null;

                            using (Bitmap bitmap = new Bitmap(nWidth, nHeight, System.Drawing.Imaging.PixelFormat.Format32bppRgb))
                            {
                                System.Drawing.Imaging.BitmapData bmpData = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), System.Drawing.Imaging.ImageLockMode.ReadWrite, bitmap.PixelFormat);
                                converter.OutputPixelFormat = PixelType.BGRA8packed;

                                IntPtr ptrBmp = bmpData.Scan0;
                                converter.Convert(ptrBmp, bmpData.Stride * bitmap.Height, grabResult);
                                bitmap.UnlockBits(bmpData);

                                _bmpImg = (Bitmap)bitmap.Clone();
                            }

                            if (_bmpImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
                            {
                                using (var cogImg = new CogImage8Grey((Bitmap)_bmpImg.Clone()))
                                    _cogImg = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                            }
                            else
                            {
                                using (var cogImg = new CogImage24PlanarColor((Bitmap)_bmpImg.Clone()))
                                    _cogImg = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                            }

                            if (_GrabComplete != null)
                                _GrabComplete(_nIdx, _bmpImg, _cogImg);

                            if (_bLive)
                                Thread.Sleep(50);
                        }
                    }

                    Thread.Sleep(1);
                }
                else if (camParam.camInterface == CameraInterface.Hik)
                {
                    var stFrameInfo = new MyCamera.MV_FRAME_OUT();
                    nRet = _HikCam.MV_CC_GetImageBuffer_NET(ref stFrameInfo, 1000);

                    if (!_bGrabThread)
                        return;

                    if (nRet != MyCamera.MV_OK)
                        continue;

                    lock (BufForDriverLock)
                    {
                        if (m_BufForDriver == IntPtr.Zero || stFrameInfo.stFrameInfo.nFrameLen > m_nBufSizeForDriver)
                        {
                            if (m_BufForDriver != IntPtr.Zero)
                            {
                                Marshal.Release(m_BufForDriver);
                                m_BufForDriver = IntPtr.Zero;
                            }

                            m_BufForDriver = Marshal.AllocHGlobal((Int32)stFrameInfo.stFrameInfo.nFrameLen);
                            if (m_BufForDriver == IntPtr.Zero)
                            {
                                return;
                            }
                            m_nBufSizeForDriver = stFrameInfo.stFrameInfo.nFrameLen;
                        }

                        m_stFrameInfo = stFrameInfo.stFrameInfo;
                        CopyMemory(m_BufForDriver, stFrameInfo.pBufAddr, stFrameInfo.stFrameInfo.nFrameLen);
                    }

                    if (RemoveCustomPixelFormats(stFrameInfo.stFrameInfo.enPixelType))
                    {
                        _HikCam.MV_CC_FreeImageBuffer_NET(ref stFrameInfo);
                        continue;
                    }

                    if (stFrameInfo.stFrameInfo.enPixelType.ToString().ToLower().Contains("mono"))
                    {
                        using (Bitmap bitmap = new Bitmap(stFrameInfo.stFrameInfo.nWidth, stFrameInfo.stFrameInfo.nHeight, stFrameInfo.stFrameInfo.nWidth, System.Drawing.Imaging.PixelFormat.Format8bppIndexed, stFrameInfo.pBufAddr))
                        {
                            ColorPalette cp = bitmap.Palette;

                            for (int i = 0; i < 256; i++)
                            {
                                cp.Entries[i] = System.Drawing.Color.FromArgb(i, i, i);
                            }

                            bitmap.Palette = cp;
                            _bmpImg = (Bitmap)bitmap.Clone();
                        }

                        using (var cogImg = new CogImage8Grey((Bitmap)_bmpImg.Clone()))
                            _cogImg = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                    }
                    else
                    {
                        using (Bitmap bitmap = new Bitmap(stFrameInfo.stFrameInfo.nWidth, stFrameInfo.stFrameInfo.nHeight, stFrameInfo.stFrameInfo.nWidth * 3, System.Drawing.Imaging.PixelFormat.Format24bppRgb, stFrameInfo.pBufAddr))
                        {
                            BitmapData data = bitmap.LockBits(new Rectangle(0, 0, stFrameInfo.stFrameInfo.nWidth, stFrameInfo.stFrameInfo.nHeight), ImageLockMode.WriteOnly, bitmap.PixelFormat);
                            int nLen = Math.Abs(data.Stride) * bitmap.Height;

                            unsafe
                            {
                                byte* value = (byte*)data.Scan0.ToPointer();

                                try
                                {
                                    for (int px = 0; px < nLen; px += 3)
                                    {
                                        byte temp = value[px];
                                        value[px] = value[px + 2];
                                        value[px + 2] = temp;
                                    }
                                }
                                catch { }
                            }

                            bitmap.UnlockBits(data);
                            _bmpImg = (Bitmap)bitmap.Clone();
                        }

                        using (var cogImg = new CogImage24PlanarColor((Bitmap)_bmpImg.Clone()))
                            _cogImg = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                    }

                    if (_GrabComplete != null)
                    {
                        _GrabComplete(_nIdx, _bmpImg, _cogImg);
                        //Thread threadGrabComplete = new Thread(() => _GrabComplete(_nIdx, _bmpImg, _cogImg));
                        //threadGrabComplete.Start();
                    }

                    _HikCam.MV_CC_FreeImageBuffer_NET(ref stFrameInfo);

                    Thread.Sleep(1);
                }
                else if (camParam.camInterface == CameraInterface.KeyenceVJ)
                {
                    if (!_bLive)
                    {
                        if (_bKeyenceTrigger)
                        {
                            AcquisitionStart();
                            _bKeyenceTrigger = false;
                        }
                    }
                    else
                    {
                        AcquisitionStart();
                        //Thread.Sleep(350);
                    }

                    Thread.Sleep(1);
                }
            }
            catch { }
        }

    }

    private void AcquisitionStart()
    {
        bool bStatus = Convert.ToBoolean(_KeyenceCam.GetFeatureValue(_strKeyenceIp, "BufferCaptureAcquisitionActiveStatus"));

        if (!bStatus)
            _KeyenceCam.SetFeatureValue(_strKeyenceIp, "OperationMode", "RunMode");

        AcquisitionStartEx_SingleFrame();
    }

    private void AcquisitionStartEx_SingleFrame()
    {
        string[] EnableImageType;
        WriteableBitmap[] Bmp = new WriteableBitmap[1];
        bool bRet;
        IntPtr buff;

        ActiveStatusCheck("AcquisitionActiveStatus");
        _KeyenceCam.SetFeatureValue(_strKeyenceIp, "MultiCaptureUpdateImage", true);
        EnableImageType = GetEnableImageType();

        try
        {
            for (var i = 0; i < EnableImageType.Length; i++)
            {
                if (!string.IsNullOrEmpty(EnableImageType[i]))
                {
                    if (EnableImageType[i] == "MlspColorImage")
                    {
                        _KeyenceCam.SetFeatureValue(_strKeyenceIp, "MultiCaptureImageType", EnableImageType[i]);
                        Bmp[0] = instUtility.CreateBitmap(_KeyenceCam, _strKeyenceIp);

                        if (Bmp[0] != null)
                        {
                            ActiveStatusCheck("AcquisitionActiveStatus");

                            _KeyenceCam.SetFeatureValue(_strKeyenceIp, "MultiCaptureUpdateImage", true);
                            _KeyenceCam.SetFeatureValue(_strKeyenceIp, "MultiCaptureImageType", EnableImageType[i]);

                            buff = Bmp[0].BackBuffer;
                            _KeyenceCam.QueueBuffer(_strKeyenceIp, buff, "Allocate");

                            string pixelFormat = (string)_KeyenceCam.GetFeatureValue(_strKeyenceIp, "PixelFormat");
                            bRet = _KeyenceCam.AcquisitionStart(_strKeyenceIp);
                            if (bRet)
                            {
                                bool bTaskRet = _KeyenceCam.RetrieveBuffer(_strKeyenceIp, buff, "Allocate", EnumAcquisitionMode.SingleFrame);
                                if (pixelFormat == "RGBA8Packed")
                                {
                                    instUtility.ConvertRGBA8toBGRA8(buff, (Bmp[0].PixelWidth * Bmp[0].PixelHeight));
                                }

                                _bmpImg = null;
                                _cogImg = null;

                                BitmapFromWriteableBitmap(Bmp[0], ref _bmpImg, ref _cogImg);

                                if (_bmpImg != null || _cogImg != null)
                                {
                                    Thread threadGrabComplete = new Thread(() => _GrabComplete(_nIdx, _bmpImg, _cogImg));
                                    threadGrabComplete.Start();

                                }
                            }
                        }

                        return;
                    }
                }
            }
        }
        catch (Exception ex)
        {
        }
    }

    private void BitmapFromWriteableBitmap(WriteableBitmap writeBmp, ref Bitmap bmpImg, ref ICogImage cogImg)
    {
        using (MemoryStream outStream = new MemoryStream())
        {
            BitmapEncoder enc = new BmpBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create((BitmapSource)writeBmp));
            enc.Save(outStream);
            bmpImg = new System.Drawing.Bitmap(outStream);

            if (bmpImg.PixelFormat == System.Drawing.Imaging.PixelFormat.Format8bppIndexed)
            {
                using (var CogGrabImg = new CogImage8Grey(bmpImg))
                    cogImg = CogGrabImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
            }
            else
            {
                using (var CogGrabImg = new CogImage24PlanarColor(bmpImg))
                    cogImg = CogGrabImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
            }
        }
    }

    private void ActiveStatusCheck(string sActiveStatus)
    {
        while (true)
        {
            bool bStatus = Convert.ToBoolean(_KeyenceCam.GetFeatureValue(_strKeyenceIp, sActiveStatus));
            if (!bStatus)
            {
                break;
            }
            else
            {
                Thread.Sleep(10);
            }
        }
    }

    private string[] GetEnableImageType()
    {
        string[] EnableImageType = new string[30];

        string[,] StdImageTypeTable =
        {
                {"StdNormalImageEnable",       "StdNormalImage"}
            };

        string[,] LtrxNmlImageTypeTable =
        {
                {"LtrxNormalImageEnable",      "LtrxNormalImage"},
                {"LtrxUpperImageEnable",       "LtrxUpperImage"},
                {"LtrxUpperRightImageEnable",  "LtrxUpperRightImage"},
                {"LtrxRightImageEnable",       "LtrxRightImage"},
                {"LtrxLowerRightImageEnable",  "LtrxLowerRightImage"},
                {"LtrxLowerImageEnable",       "LtrxLowerImage"},
                {"LtrxLowerLeftImageEnable",   "LtrxLowerLeftImage"},
                {"LtrxLeftImageEnable",        "LtrxLeftImage"},
                {"LtrxUpperLeftImageEnable",   "LtrxUpperLeftImage"},
                {"LtrxShapeImage1Enable",      "LtrxShapeImage1"},
                {"LtrxShapeImage2Enable",      "LtrxShapeImage2"},
                {"LtrxShapeImage3Enable",      "LtrxShapeImage3"},
                {"LtrxTextureImageEnable",     "LtrxTextureImage"},
                {"LtrxGradientXImageEnable",   "LtrxGradientXImage"},
                {"LtrxGradientYImageEnable",   "LtrxGradientYImage"},
            };

        string[,] MlspImageTypeTable =
        {
                {"MlspUVImageEnable",          "MlspUVImage"},
                {"MlspBlueImageEnable",        "MlspBlueImage"},
                {"MlspGreenImageEnable",       "MlspGreenImage"},
                {"MlspAmberImageEnable",       "MlspAmberImage"},
                {"MlspRedImageEnable",         "MlspRedImage"},
                {"MlspFarRedImageEnable",      "MlspFarRedImage"},
                {"MlspIRImageEnable",          "MlspIRImage"},
                {"MlspWhiteImageEnable",       "MlspWhiteImage"},
                {"MlspAverageGrayscaleImageEnable",    "MlspAverageGrayscaleImage"},
                {"MlspColorImageEnable",       "MlspColorImage"},
                {"MlspColorDifferenceImageEnable",     "MlspColorDifferenceImage"}
            };

        string[,] SprfImageTypeTable =
        {
                {"SprfX1ImageEnable",          "SprfX1Image"},
                {"SprfX2ImageEnable",          "SprfX2Image"},
                {"SprfX3ImageEnable",          "SprfX3Image"},
                {"SprfX4ImageEnable",          "SprfX4Image"},
                {"SprfY1ImageEnable",          "SprfY1Image"},
                {"SprfY2ImageEnable",          "SprfY2Image"},
                {"SprfY3ImageEnable",          "SprfY3Image"},
                {"SprfY4ImageEnable",          "SprfY4Image"},
                {"SprfSpecularReflectionImageEnable",  "SprfSpecularReflectionImage"},
                {"SprfDiffuseReflectionImageEnable",   "SprfDiffuseReflectionImage"},
                {"SprfShapeImage1Enable",      "SprfShapeImage1"},
                {"SprfShapeImage2Enable",      "SprfShapeImage2"},
                {"SprfPhaseXImageEnable",      "SprfPhaseXImage"},
                {"SprfPhaseYImageEnable",      "SprfPhaseYImage"},
                {"SprfGlossRatioImageEnable",  "SprfGlossRatioImage"},
                {"SprfNormalImageEnable",      "SprfNormalImage"}
            };

        string[,] Cap3DImageTypeTable =
        {
                {"Cap3DAreascan3DImageEnable", "Areascan3DImage"},
                {"Cap3DAreascan2DImageEnable", "Areascan2DImage"}
            };

        string[,] RBImageTypeTable =
        {
                {"Areascan3DImageEnable", "Areascan3DImage"},
                {"Areascan2DGrayscaleImageEnable", "Areascan2DGrayscaleImage"}
            };

        string[,] XTImageTypeTable =
        {
                {"Areascan3DImageEnable", "Areascan3DImage"},
                {"Areascan2DColorImageEnable", "Areascan2DColorImage"},
                {"Areascan2DGrayscaleImageEnable", "Areascan2DGrayscaleImage"}
            };

        string[,] FilteredImageTable =
        {
                {"FilteredImageEnable",       "FilteredImage1"},
                {"FilteredImageEnable",       "FilteredImage2"},
                {"FilteredImageEnable",       "FilteredImage3"},
                {"FilteredImageEnable",       "FilteredImage4"},
                {"FilteredImageEnable",       "FilteredImage5"},
                {"FilteredImageEnable",       "FilteredImage6"},
                {"FilteredImageEnable",       "FilteredImage7"},
                {"FilteredImageEnable",       "FilteredImage8"}
            };

        string[,] ImageTypeTable = StdImageTypeTable;
        //CameraItems TabCamera = GetTabControlCamera(CurrentIPAddress);
        bool bEnable;
        string sLightingMode;
        uint cnt = 0;


        object oTargetParameterSet = _KeyenceCam.GetFeatureValue(_strKeyenceIp, "TargetParameterSet");
        _KeyenceCam.SetFeatureValue(_strKeyenceIp, "ParameterSetSelector", oTargetParameterSet);


        //instCamera.SetFeatureValue(_CurrentIPAddress, "FixedCaptureNoSelector", oTargetCaptureCount);
        //if ((TabCamera.IsHLMXCamera) && (TabCamera.CaptureMode == EnumCaptureMode.Fixed_MultipleImages))
        //{
        //bEnable = Convert.ToBoolean(instCamera.GetFeatureValue(_CurrentIPAddress, "IndividualFilterPerFixedCaptureNoEnable"));
        //if (bEnable)
        //{
        //    object oTargetCaptureCount = instCamera.GetFeatureValue(_CurrentIPAddress, "TargetFixedCaptureNo");
        //    instCamera.SetFeatureValue(_CurrentIPAddress, "FixedCaptureNoSelector", oTargetCaptureCount);
        //}
        //}

        //if (TabCamera.IsRBCamera)
        //{
        //    ImageTypeTable = RBImageTypeTable;
        //}
        //else if (TabCamera.IsXTCamera)
        //{
        //    ImageTypeTable = XTImageTypeTable;
        //}
        //else
        //{
        sLightingMode = _KeyenceCam.GetFeatureValue(_strKeyenceIp, "ImagingMode").ToString();

        if (sLightingMode == "StandardLighting")
        {
            ImageTypeTable = StdImageTypeTable;
        }
        else if (sLightingMode == "LumiTrax")
        {
            ImageTypeTable = LtrxNmlImageTypeTable;
        }
        else if (sLightingMode == "MultiSpectrum")
        {
            ImageTypeTable = MlspImageTypeTable;
        }
        else if (sLightingMode == "LumiTraxSpecularReflection")
        {
            ImageTypeTable = SprfImageTypeTable;
        }
        else if (sLightingMode == "Capture3D")
        {
            ImageTypeTable = Cap3DImageTypeTable;
        }
        //}

        int length = ImageTypeTable.GetLength(0);
        for (int i = 0; i < length; i++)
        {
            bEnable = Convert.ToBoolean(_KeyenceCam.GetFeatureValue(_strKeyenceIp, ImageTypeTable[i, 0]));
            if (bEnable)
            {
                EnableImageType[cnt] = ImageTypeTable[i, 1];
                cnt++;
            }
        }

        length = FilteredImageTable.GetLength(0);
        for (int i = 0; i < length; i++)
        {
            _KeyenceCam.SetFeatureValue(_strKeyenceIp, "FilteredImageSelector", (i + 1));

            bEnable = Convert.ToBoolean(_KeyenceCam.GetFeatureValue(_strKeyenceIp, FilteredImageTable[i, 0]));
            if (bEnable)
            {
                EnableImageType[cnt] = FilteredImageTable[i, 1];
                cnt++;
            }
        }
        return EnableImageType;
    }

    private void AcquisitionStop()
    {
        bool bStatus = Convert.ToBoolean(_KeyenceCam.GetFeatureValue(_strKeyenceIp, "BufferCaptureAcquisitionActiveStatus"));
        bool bRet = _KeyenceCam.AcquisitionStop(_strKeyenceIp);
    }

    private bool RemoveCustomPixelFormats(MyCamera.MvGvspPixelType enPixelFormat)
    {
        Int32 nResult = ((int)enPixelFormat) & (unchecked((Int32)0x80000000));
        if (0x80000000 == nResult)
        {
            return true;
        }
        else
        {
            return false;
        }
    }


    public void Grab(int nIdx, double dExpo)
    {
        if (_camParam[_nIdx].bConnect)
        {
            _nIdx = nIdx;
            var dExpose = dExpo;
            try
            {
                if (dExpose > 0)
                    SetExposure(_camParam[_nIdx].camInterface, dExpose);

                SoftwareTrigger(_camParam[_nIdx].camInterface);
            }
            catch (Exception ex)
            {
                _MessageFunc(string.Format("{0} camera Grab Err> :" + ex.ToString(), _nIdx + 1), System.Drawing.Color.Red, false, false, 0);
            }
        }
    }

    private void SoftwareTrigger(CameraInterface cameraInterface)
    {
        try
        {
            if (cameraInterface == CameraInterface.Basler)
                _BaslerCam.Parameters[PLCamera.TriggerSoftware].Execute();
            else if (cameraInterface == CameraInterface.Hik)
                _HikCam.MV_CC_SetCommandValue_NET("TriggerSoftware");
            else if (cameraInterface == CameraInterface.KeyenceVJ)
                _bKeyenceTrigger = true;
        }
        catch { }
    }

    public void LiveView(CameraInterface cameraInterface, bool bLive)
    {
        try
        {
            _bLive = bLive;
            SetTriggerMode(cameraInterface, !bLive, 0);
        }
        catch { }
    }

    public void SaveParam(CameraInterface cameraInterface)
    {
        try
        {
            if (cameraInterface == CameraInterface.Basler)
            {
                if (_BaslerCam != null)
                {
                    if (_BaslerCam.IsOpen)
                    {
                        _BaslerCam.Parameters[PLCamera.UserSetSelector].SetValue("UserSet1");
                        _BaslerCam.Parameters[PLCamera.UserSetSave].TryExecute();
                    }
                }
            }
            else if (cameraInterface == CameraInterface.Hik)
            {
                if (_HikCam != null)
                {
                    MyCamera.MV_CC_FILE_ACCESS stFileAccess = new MyCamera.MV_CC_FILE_ACCESS();

                    stFileAccess.pUserFileName = "UserSet1.bin";
                    stFileAccess.pDevFileName = "UserSet1";
                    _HikCam.MV_CC_FileAccessWrite_NET(ref stFileAccess);
                }
            }
        }
        catch { }
    }

    public void SetTriggerMode(CameraInterface cameraInterface, bool bModeOn, int nTriggerSource)
    {
        try
        {
            if (cameraInterface == CameraInterface.Basler)
            {
                if (_BaslerCam != null)
                {
                    if (_BaslerCam.IsOpen)
                    {
                        if (bModeOn)
                            _BaslerCam.Parameters[PLCamera.TriggerMode].SetValue(PLCamera.TriggerMode.On);
                        else
                            _BaslerCam.Parameters[PLCamera.TriggerMode].SetValue(PLCamera.TriggerMode.Off);

                        if (nTriggerSource == 0)
                            _BaslerCam.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Software);
                        else
                            _BaslerCam.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line1);
                    }
                }
            }
            else if (cameraInterface == CameraInterface.Hik)
            {
                if (_HikCam != null)
                {
                    if (bModeOn)
                    {
                        _HikCam.MV_CC_StopGrabbing_NET();
                        _HikCam.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                        _HikCam.MV_CC_StartGrabbing_NET();
                    }
                    else
                    {
                        _HikCam.MV_CC_StopGrabbing_NET();
                        _HikCam.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                        _HikCam.MV_CC_StartGrabbing_NET();
                    }
                }
            }
            else if (cameraInterface == CameraInterface.KeyenceVJ)
            {
                if (bModeOn)
                    _bLive = false;
                else
                    _bLive = true;
            }
        }
        catch
        { }
    }
}
