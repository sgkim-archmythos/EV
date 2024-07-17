using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.Text.RegularExpressions;

public class GlovalVar
{

    public enum GraphicAlign
    {
        Left,
        Center,
        Right
    }

    public enum GraphicColor
    {
        Green,
        Yellow,
        Blue,
        Cyan,
        Magenta,
        Red
    }

    public enum PLCType
    {
        MX,
        LS,
        Simens
    }

    public enum PLCDataType
    {
        Binary,
        ASCII
    }

    public enum SignalFormat
    {
        DEC,
        HEX
    }

    public enum DataType
    {
        DEC,
        BINARY,
        HEX,
        ASCII
    }

    public enum PositionType
    {
        Previous,
        Next
    }

    public enum AdminMode
    {
        Model,
        Communication,
        Camera,
        Light,
        IO,
        UserManagement
    }

    public enum CameraInterface
    {
        NONE,
        Basler,
        Hik,
        KeyenceVJ
    }
   

    public enum ResImgType
    {
        NETWORK = 1,
        TCP = 2,
    }

    public enum RequestMode
    {
        AUTO = 1,
        GRAB = 2,
        LIVE = 3,
        INSPECTION = 4,
        NONE = 5
    }


    public enum Status
    {
        NONE,
        Grab,
        Live,
        InspedtionReset,
        Inspection,
        InspecEnd,
        CamConnect,
        CamDisconnect
    }
       

    public enum Result
    {
        OK,
        NG,
        NONE
    }

    public enum WhiteBalnce
    {
        OFF,
        ONCE,
        CONTINOUS
    }

    public enum MsgType
    {
        Log,
        Alarm
    }

    public enum Language
    {
        English,
        Korean
    }

    public enum ImageMove
    {
        START,
        PREVIOUS,
        NEXT,
        END
    }

    public enum IMGFormat
    {
        bmp,
        jpg
    }
    public enum ParamCode
    {
        NONE,
        ModelListChange,
        ModelChange,
        LotNoChange,
        RecipeChage,
        PLCInfoChange,
        SaveImgParamChage,
        GraphicParamChange,
        
        ModelListChangeEnd,
        ModelChangeEnd,
        LotNoChangeEnd,
        RecipeChageEnd,
        PLCInfoChangeEnd,
        SaveImgParamChageEnd,
        GraphicParamChangeEnd,
        
    }

    public enum IOCardType
    {
        PCI_7230 = 6,
        PCI_6208V = 1,
        PCI_6208A = 2,
        PCI_6308V = 3,
        PCI_6308A = 4,
        PCI_7200 = 5,
        PCI_7233 = 7,
        PCI_7234 = 8,
        PCI_7248 = 9,
        PCI_7249 = 10,
        PCI_7250 = 11,
        PCI_7252 = 12,
        PCI_7296 = 13,
        PCI_7300A_RevA = 14,
        PCI_7300A_RevB = 15,
        PCI_7432 = 16,
        PCI_7433 = 17,
        PCI_7434 = 18,
        PCI_8554 = 19,
        PCI_9111DG = 20,
        PCI_9111HR = 21,
        PCI_9112 = 22,
        PCI_9113 = 23,
        PCI_9114DG = 24,
        PCI_9114HG = 25,
        PCI_9118DG = 26,
        PCI_9118HG = 27,
        PCI_9118HR = 28,
        PCI_9810 = 29,
        PCI_9812 = 30,
        PCI_7396 = 31,
        PCI_9116 = 32,
        PCI_7256 = 33,
        PCI_7258 = 34,
        PCI_7260 = 35,
        PCI_7452 = 36,
        PCI_7442 = 37,
        PCI_7443 = 38,
        PCI_7444 = 39,
        PCI_9221 = 40,
        PCI_9524 = 41,
        PCI_6202 = 42,
        PCI_9222 = 43,
        PCI_9223 = 44,
        PCI_7433C = 45,
        PCI_7434C = 46,
        PCI_922A = 47,
        PCI_7350 = 48,
    }


    public enum PinInsp
    {
        PinMaster,
        PinNumberMaster
    }

    public enum RunMode
    {
        AUTO = 1,
        MANUAL = 2,
        LIVE = 3
    }

    public enum UserLevel
    {
        ADMIN,
        MANAGER,
        OPERATOR
    }



    public struct CamPram  //카메라 파라미터
    {
        public CameraInterface camInterface;
        public string strCamType;
        public string strCamNo;
        public string strCamFormat;
        public string strPixelFormats;
        public string strIP;
        public double dExpose;
        public string strFormats;
        public string strCopy;
        public string strVender;
        public string strSerial;
        public string strModel;
        public string strResolution;
        public bool bConnect;
    }

    public struct ModelParam  //카메라 파라미터
    {
        public int nInspCnt;
        public int nGrabdelay;
        public double dExpose;
        public string strCode;
        public int nDefectCnt;
        public string strExposeInc;
        public int nAlign;
        public int nFontSize;
        public int nPosX;
        public int nPosY;
        public bool bDefectInsp;
        public bool bBCRInsp;
        public bool bAlignFormula;
        public bool bAlingInsp;
        public bool bAlingOutsp;
        public bool bDimens;
        public string strBCRData;
        public string strBCRLen;
        public bool bPinChange;
        
        public double dCenterMass;
        public double dAlignMasterX;
        public double dAlignMasterY;
        public double dAlignMasterR;
        public double dAlignOffsetX;
        public double dAlignOffsetY;
        public double dAlignOffsetR;
        public double dAlignUnit;
        public double dWidthMin;
        public double dWidthMax;
        public double dHeightMin;
        public double dHeightMax;
        public double dResoluton;
        public string strPinMaster;
        public string strPinMasterResult;
        
        
        
        
        public List<string> listAreaParam;
        public string strTriggerNo;
        public string strLightNo;
        
        
     
        public double dMaxX;
        public double dMaxY;
    }

    public struct PLCPram  //카메라 파라미터
    {
        public PLCType plcType;
        public string strPLCIP;
        public string strPLCPort;
        public short shRack;
        public short shSlot;
        public PLCDataType ReadFormat;
        public string strTriggerSignal;
        public string strOKSignal;
        public string strNGSignal;
        public SignalFormat SignalFormat;
        public string strCPUType;
        public string strRead;
        public string strReadDev;
        public string strReadCnt;
        public string strReadInterval;
        public string strReadTrigger;
        public string strReadTriggerCnt;
        public string strReadModel;
        public string strReadModelCnt;
        public string strReadLot;
        public string strReadLotCnt;
        public string strWrite;
        public string strWriteDev;
        public string strWriteHeartbeat;
        public string strWriteHeartbeatInterval;
        public string strWriteGrabComplete;
        public string strWriteModelChange;
        public string strWriteLotComplete;
        public string strWritePointResult;
        public string strWriteTotalResult;
        public string strWrite2DData;
        public string strWriteAlignX;
        public string strWriteAlignY;
        public string strWriteAlignR;
        public string strWriteWidth;
        public string strWriteHeight;
        public string strWritePinChange;
        public bool bConnect;
       
    }



    public struct GraphicToolParam
    {
        public string[] strName;
        public bool[] bUse;
        public string[] strOKColor;
        public string[] strNGColor;
        public int[] nLineThick;
        
    }

    public struct GraphicResViewParam
    {
        public string strAlign;
        public int nFontSize;
        public double dPosX;
        public double dPosY;
        public int nSubFontSize;
        public double dSubPosX;
        public double dSubPosY;
    }


    public struct RobotParam
    {
        public string strIP;
        public string strPort;
        public string strTrigger1;
        public string strTrigger2;
    }

    public struct LightParam
    {
        public string strConnectMode;
        public string strPortName;
        public string strBaudrate;
        public int[] nValue;
        public bool[] bLightUse;
    }

    public struct SensorParam
    {
        public string strIP;
        public string strPort;
        public double dLimitLow;
        public double dLimitHigh;
        public int nTriggerCycleTime;
        public int nModelNo;
    }

    public struct DBInfo
    {
        public string strIP;
        public int nPort;
        public string strID;
        public string strPW;
        public string strDBName;
    }

    public struct SaveImageParam
    {
        public bool _bOriginImageSave;
        public IMGFormat _OriginImageFormat;
        public bool _bResultImageSave;
        public IMGFormat _ResultImageFormat;
        public bool _bAutoImageDelete;
        public int _nDiskDelete;
        public int _nOriginImgCompRate;
        public int _nResultImgCompRate;
        public string _strSaveImagePath;
    }
   
    public static void Delay(int ms)
    {
        DateTime dateTimeNow = DateTime.Now;
        TimeSpan duration = new TimeSpan(0, 0, 0, 0, ms);
        DateTime dateTimeAdd = dateTimeNow.Add(duration);
        while (dateTimeAdd >= dateTimeNow)
        {
            System.Windows.Forms.Application.DoEvents();
            dateTimeNow = DateTime.Now;
        }
        return;
    }

    public static string _strConfigPath = Application.StartupPath + "\\Config";
    public static string _strLogPath = Application.StartupPath + "\\Log";
    public static string _strCameraInfoPath = Application.StartupPath + "\\CameraInfo";
    public static string _strCommInfoPath = Application.StartupPath + "\\Communication";
    public static string _strMasterImagePath = Application.StartupPath + "\\MasterImage";
    public static string _strModelPath = Application.StartupPath + "\\Model";
 

    public static string _strAdminPW = "0000";
    public static string _strOPPW = "9999";
    //public static string _tsReset = "";

    public static List<string> _strlistLocation = new List<string>();
    
    public static DBInfo _dbInfo = new DBInfo();
    public static SaveImageParam _SaveImgParam = new SaveImageParam();
    public static ModelParam[] _modelParam = new ModelParam[30];
    public static GraphicToolParam[] _graphicVproParam = new GraphicToolParam[30];
    public static GraphicResViewParam[] _graphicResParam = new GraphicResViewParam[30];
    
    public static CamPram[] _camParam = new CamPram[30];
    public static PLCPram _plcParam = new PLCPram();
    public static CamSet[] _camSet = null;

    public static string _strIOCardType = "";

    public static int _nWidth = 0;
    public static int _nHeight = 0;
        
    public static string _strLineName = "";
    public static string _strProcName = "";

    public static string _strWidth = "";
    public static string _strHeight = "";

    public static int _nScreenCnt = 0;

    public static string _strModelNo = "";
    public static string _strLotNo = "";
    public static string _strVppNo = "";
    public static string _strPassData = "";
    public static string _strUser = "";

    public static bool _bStartSignal = false;

    //파이썬
    public static dynamic _runtime_code = null;
    public static dynamic _numpy = null;
    public static dynamic _Model = null;
    public static dynamic pysys = null;

    public static dynamic _Simulation_runtime_code = null;
    public static dynamic _Simulation_numpy = null;
    public static dynamic _Simulation_Model = null;

    //public static bool _bStart = false;

    //public static int _nTotalCnt = 0;
    //public static int _nOKCnt = 0;
    //public static int _nNGCnt = 0;

    public static List<string> _listModel = new List<string>();
    public static List<string> _listCode = new List<string>();
    public static List<string> _listCodeComment = new List<string>();

    public static string _strModelName = "";

    

    public static bool _bVproLic = false;
    
    
    public static string _strAddfunction;

    public static bool _bUseSensor = false;
    public static bool _bUsePinchange = false;

    public static int[] _nDailyTOTALCnt = new int[24];
    public static int[] _nDailyOKCnt = new int[24];
    public static int[] _nDailyNGCnt = new int[24];

    public static DateTime[] _dateTime = new DateTime[30];

    public static ParamCode _paramCode = ParamCode.NONE;

    public static Color green = Color.GreenYellow;
    public static Color yellow = Color.Yellow;
    public static Color lime = Color.Lime;
    public static Color red = Color.Red;
    public static Color white = Color.White;
    public static Color black = Color.Black;
    public static Color gray = Color.Gray;

    public static UserLevel _userLevel = UserLevel.OPERATOR;

    public static Language _Language = Language.Korean;
}
