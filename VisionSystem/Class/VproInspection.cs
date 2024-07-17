using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;

using Cognex.VisionPro.ImageFile;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ColorMatch;
using Cognex.VisionPro.ColorExtractor;
using Cognex.VisionPro.ColorSegmenter;
using Cognex.VisionPro.OCRMax;
using Cognex.VisionPro.ResultsAnalysis;
using System.Windows.Forms;
using System.Diagnostics;
using static GlovalVar;
using DevExpress.CodeParser;

using System.IO;

public delegate void InspectionDataHandeler(string[] strValue, bool bManualMode, string strResData);
public delegate void InspectionGrahphicHandler(List<CogPointMarker> cogPoint, List<CogLine> cogLine, List<CogCircle> cogCircle, List<CogCompositeShape> cogShape, List<CogEllipse> cogEllipse, List<ICogRegion> cogRegion, List<CogGraphicLabel> cogLbl, string strResData);
public delegate void JobLoadHandler(string strRes);
public delegate void MessageHandler(string strRes, Color color);
public class VproInspection
{
    public InspectionDataHandeler _OnInspData;
    public InspectionGrahphicHandler _OnInspGraphic;
    public JobLoadHandler _OnJobLoad;
    public MessageHandler _OnMessage;

    private CogToolGroup _job = new CogToolGroup();
    private CogToolGroup _toolGroup = new CogToolGroup();
    private List<CogImageConvertTool> _listConvertTool = new List<CogImageConvertTool>();
    //private CogIPOneImageTool _cogIPOimgTool = null;
    private CogDataAnalysisTool _DataAnalysisTool = null;

    GraphicToolParam _graphicVpro;
    List<ICogTool> _listTool = new List<ICogTool>();

    string _strWriteDate = "";
    //private string _strCode = "";
    public int GetJobCount
    {
        get { return _job.Tools.Count; }
    }

    public bool VJoblode(string strJobPath, ICogImage cogImg)
    {
        bool bRes = true;
        try
        {
            DateTime dt = File.GetLastWriteTime(strJobPath);
            var strWritedate = dt.ToString("yy-MM-dd HH:mm:ss");

            if (_strWriteDate != strWritedate)
            {
                _job = CogSerializer.LoadObjectFromFile(strJobPath) as CogToolGroup;

                if (_job != null)
                {
                    _job.AbortRunOnToolFailure = false;
                    _job.GarbageCollectionEnabled = true;
                    _job.GarbageCollectionFrequency = 15;

                    _listConvertTool.Clear();

                    for (int i = 0; i < _job.Tools.Count; i++)
                    {
                        if (_job.Tools[i].GetType() == typeof(CogImageConvertTool))
                        {
                            (_job.Tools[i] as CogImageConvertTool).InputImage = cogImg;
                            _listConvertTool.Add(_job.Tools[i] as CogImageConvertTool);
                        }

                        if (_job.Tools[i].GetType() == typeof(CogDataAnalysisTool))
                            _DataAnalysisTool = _job.Tools[i] as CogDataAnalysisTool;
                    }

                    _job.Run();
                    _job.Run();
                }
            }
            else
                return true;
        }
        catch (Exception ex)
        {
            bRes = false;

            if (_OnJobLoad != null)
                _OnJobLoad(ex.Message);
        }

        return bRes;
    }

    public CogToolGroup GetJob
    {
        get { return _job; }
        set { _job = value; }
    }

    public void VJobrun(int nSel, ICogImage cogGrab, ModelParam modelParam, GraphicToolParam graphicParam, bool bManualMode, bool bSimulation)
    {
        _graphicVpro = _graphicVproParam[nSel];
        ICogImage cogImg = cogGrab;
        bool bManual = bManualMode;

        string[] strData = null;

        List<CogPointMarker> cogPoint = null;
        List<CogLine> cogLine = null;
        List<CogCircle> cogCircle = null;
        List<CogRectangleAffine> cogRectAffine = null;
        List<CogCompositeShape> cogShape = null;
        List<CogRectangle> cogRect = null;
        List<CogEllipse> cogEllipse = null;
        List<ICogRegion> cogRegion = null;
        List<CogGraphicLabel> cogLbl = null;
        string[] strToolResValue = null;

        string strResData = "";

        try
        {

            bool[] bGraphicRes = new bool[_job.Tools.Count];

            if (_job != null && cogImg != null)
            {
                if (_listConvertTool != null)
                {
                    for (var i = 0; i < _listConvertTool.Count; i++)
                        _listConvertTool[i].InputImage = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                }
                else
                {
                    _OnMessage("vpp Error", Color.Red);
                    return;
                }

                _job.Run();

                if (_job.RunStatus.Result != CogToolResultConstants.Error)
                {
                    strData = new string[_DataAnalysisTool.RunParams.Count];
                    strData[0] = _DataAnalysisTool.RunParams[0].CurrentValue.ToString();
                    strData[1] = _DataAnalysisTool.RunParams[1].Description;
                    strData[2] = _DataAnalysisTool.RunParams[2].CurrentValue.ToString();
                    strData[3] = _DataAnalysisTool.RunParams[3].CurrentValue.ToString();
                    strData[4] = _DataAnalysisTool.RunParams[4].CurrentValue.ToString();
                    strData[5] = _DataAnalysisTool.RunParams[5].Description;
                    strData[6] = _DataAnalysisTool.RunParams[6].Description;
                    strData[7] = _DataAnalysisTool.RunParams[7].Description;

                    cogPoint = new List<CogPointMarker>();
                    cogLine = new List<CogLine>();
                    cogCircle = new List<CogCircle>();
                    cogRectAffine = new List<CogRectangleAffine>();
                    cogShape = new List<CogCompositeShape>();
                    cogRect = new List<CogRectangle>();
                    cogEllipse = new List<CogEllipse>();
                    cogRegion = new List<ICogRegion>();
                    cogLbl = new List<CogGraphicLabel>();

                    GetResultGraphic(ref cogPoint, ref cogLine, ref cogCircle, ref cogRectAffine, ref cogShape, ref cogRect, ref cogEllipse, ref cogRegion, ref cogLbl, ref strResData, modelParam, strData[7], bSimulation);

                    if (_OnInspData != null)
                    {
                        Thread threadData = new Thread(() => _OnInspData(strData, bManual, strResData));
                        threadData.Start();
                    }

                    if (_OnInspGraphic != null)
                        _OnInspGraphic(cogPoint, cogLine, cogCircle, cogShape, cogEllipse, cogRegion, cogLbl, strResData);
                }
                else
                {
                    if (_OnInspData != null)
                    {
                        Thread threadData = new Thread(() => _OnInspData(null, bManual, strResData));
                        threadData.Start();
                    }

                    if (_OnInspGraphic != null)
                        _OnInspGraphic(cogPoint, cogLine, cogCircle, cogShape, cogEllipse, cogRegion, cogLbl, strResData);
                }
            }
            else
            {
                if (_job == null)
                    _OnMessage("The working file was not loaded.", Color.Red);

                if (cogImg == null)
                    _OnMessage("No Image", Color.Red);
            }
        }
        catch (System.Exception ex)
        {
            double[] dData = new double[1];
            dData[0] = 0;

            if (_OnInspData != null)
            {
                Thread threadData = new Thread(() => _OnInspData(strData, bManual, strResData));
                threadData.Start();
            }

            if (_OnInspGraphic != null)
                _OnInspGraphic(cogPoint, cogLine, cogCircle, cogShape, cogEllipse, cogRegion, cogLbl, strResData);
        }
    }

    private int GetDrawGraphic(string strName, GraphicToolParam graphicParam)
    {
        int nIdx = -1;

        try
        {
            for (var i = 0; i < graphicParam.strName.Length; i++)
            {
                if (strName == graphicParam.strName[i])
                {
                    if (graphicParam.bUse[i])
                        nIdx = i;

                    break;
                }

            }
        }
        catch { }

        return nIdx;
    }

    private ICogRegion GetToolRegion(ICogRegion ToolRegion, CogColorConstants color, int nLineThick, ref CogGraphicLabel coglbl)
    {
        ICogRegion region = null;

        try
        {
            if (ToolRegion.GetType() == typeof(CogCircle))
            {
                CogCircle cogCirclr = new CogCircle();
                cogCirclr = ToolRegion as CogCircle;
                cogCirclr.Interactive = false;
                cogCirclr.Color = color;
                cogCirclr.LineWidthInScreenPixels = nLineThick;

                coglbl.X = cogCirclr.CenterX;
                coglbl.Y = cogCirclr.CenterY;
                coglbl.SelectedSpaceName = cogCirclr.SelectedSpaceName;

                region = cogCirclr;
            }
            else if (ToolRegion.GetType() == typeof(CogEllipse))
            {
                CogEllipse cogEllipse = new CogEllipse();
                cogEllipse = new CogEllipse();
                cogEllipse = ToolRegion as CogEllipse;
                cogEllipse.Interactive = false;
                cogEllipse.Color = color;
                cogEllipse.LineWidthInScreenPixels = nLineThick;

                coglbl.X = cogEllipse.CenterX;
                coglbl.Y = cogEllipse.CenterY;
                coglbl.SelectedSpaceName = cogEllipse.SelectedSpaceName;

                region = cogEllipse;
            }
            else if (ToolRegion.GetType() == typeof(CogPolygon))
            {
                CogPolygon cogPolygon = new CogPolygon();
                cogPolygon = ToolRegion as CogPolygon;
                cogPolygon.Interactive = false;
                cogPolygon.Color = color;
                cogPolygon.LineWidthInScreenPixels = nLineThick;

                region = cogPolygon;
            }
            else if (ToolRegion.GetType() == typeof(CogRectangleAffine))
            {
                CogRectangleAffine cogRectangleAffine = new CogRectangleAffine();
                cogRectangleAffine = ToolRegion as CogRectangleAffine;
                cogRectangleAffine.Interactive = false;
                cogRectangleAffine.Color = color;
                cogRectangleAffine.LineWidthInScreenPixels = nLineThick;

                coglbl.X = cogRectangleAffine.CenterX;
                coglbl.Y = cogRectangleAffine.CenterY;
                coglbl.SelectedSpaceName = cogRectangleAffine.SelectedSpaceName;

                region = cogRectangleAffine;
            }
            else if (ToolRegion.GetType() == typeof(CogRectangle))
            {
                CogRectangle cogRectangle = new CogRectangle();
                cogRectangle = ToolRegion as CogRectangle;
                cogRectangle.Interactive = false;
                cogRectangle.Color = color;
                cogRectangle.LineWidthInScreenPixels = nLineThick;

                coglbl.X = cogRectangle.CenterX;
                coglbl.Y = cogRectangle.CenterY;
                coglbl.SelectedSpaceName = cogRectangle.SelectedSpaceName;

                region = cogRectangle;
            }
            else if (ToolRegion.GetType() == typeof(CogCircularAnnulusSection))
            {
                CogCircularAnnulusSection cogCircularAnnulusSection = new CogCircularAnnulusSection();
                cogCircularAnnulusSection = ToolRegion as CogCircularAnnulusSection;
                cogCircularAnnulusSection.Interactive = false;
                cogCircularAnnulusSection.Color = color;
                cogCircularAnnulusSection.LineWidthInScreenPixels = nLineThick;

                coglbl.X = cogCircularAnnulusSection.CenterX;
                coglbl.Y = cogCircularAnnulusSection.CenterY;
                coglbl.SelectedSpaceName = cogCircularAnnulusSection.SelectedSpaceName;

                region = cogCircularAnnulusSection;
            }
            else if (ToolRegion.GetType() == typeof(CogEllipticalAnnulusSection))
            {
                CogEllipticalAnnulusSection cogEllipticalAnnulusSection = new CogEllipticalAnnulusSection();
                cogEllipticalAnnulusSection = ToolRegion as CogEllipticalAnnulusSection;
                cogEllipticalAnnulusSection.Color = color;
                cogEllipticalAnnulusSection.Interactive = false;
                cogEllipticalAnnulusSection.LineWidthInScreenPixels = nLineThick;

                coglbl.X = cogEllipticalAnnulusSection.CenterX;
                coglbl.Y = cogEllipticalAnnulusSection.CenterY;
                coglbl.SelectedSpaceName = cogEllipticalAnnulusSection.SelectedSpaceName;

                region = cogEllipticalAnnulusSection;
            }
        }
        catch { }
        return region;
    }

    private CogColorConstants GetPinColor(ModelParam modelParam, string strPingData, int nFindCnt, int nIdx)
    {
        CogColorConstants color = (CogColorConstants)Enum.Parse(typeof(CogColorConstants), _graphicVpro.strOKColor[nIdx]);

        try
        {
            if (modelParam.bPinChange)
            {
                if (modelParam.strPinMaster != "" && modelParam.strPinMasterResult != "")
                {
                    if (modelParam.strPinMaster[nIdx] == strPingData[nIdx] || modelParam.strPinMasterResult[nIdx] == strPingData[nIdx])
                        color = (CogColorConstants)Enum.Parse(typeof(CogColorConstants), _graphicVpro.strOKColor[nIdx]);
                    else
                        color = (CogColorConstants)Enum.Parse(typeof(CogColorConstants), _graphicVpro.strNGColor[nIdx]);

                   
                }
                else
                    color = CogColorConstants.Red;
            }
            else
                color = nFindCnt > 0 ? (CogColorConstants)Enum.Parse(typeof(CogColorConstants), _graphicVpro.strOKColor[nIdx]) : (CogColorConstants)Enum.Parse(typeof(CogColorConstants), _graphicVpro.strNGColor[nIdx]);

        }
        catch { }

        return color;
    }

    private void GetResultGraphic(ref List<CogPointMarker> cogPoint, ref List<CogLine> cogLine, ref List<CogCircle> cogCircle, ref List<CogRectangleAffine> cogRectAffine, ref List<CogCompositeShape> cogShape, ref List<CogRectangle> cogRect, ref List<CogEllipse> cogEllipse, ref List<ICogRegion> cogRegion, ref List<CogGraphicLabel> cogLbl, ref string strResData, ModelParam modelParam, string strPinData, bool bSimulation)
    {
        int nCnt = 0;
        CogCompositeShape[] shape = null;
        CogCircle[] Circle = null;
        CogLine[] Line = null;
        CogEllipse[] Ellipse = null;
        CogPointMarker[] point = null;
        CogCreateSegmentTool Segment = null;

        CogColorConstants color = new CogColorConstants();
        int nToolCnt = 0;

        _listTool.Clear();

        for (var i = 0; i < _job.Tools.Count; i++)
        {
            if (_job.Tools[i].GetType() != typeof(CogToolBlock))
            {
                _listTool.Add(_job.Tools[i]);
                nToolCnt++;
            }
            else
            {
                _listTool.Add(_job.Tools[i]);
                for (var j = 0; j < (_job.Tools[i] as CogToolBlock).Tools.Count; j++)
                {
                    _listTool.Add((_job.Tools[i] as CogToolBlock).Tools[j]);
                    nToolCnt++;
                }
            }
        }

        var nDrawIndx = -1;

        for (int i = 0; i < _listTool.Count; i++)
        {
            try
            {
                nDrawIndx = GetDrawGraphic(_listTool[i].Name, _graphicVpro);

                if (nDrawIndx > -1)
                {
                    color = (CogColorConstants)Enum.Parse(typeof(CogColorConstants), _graphicVpro.strOKColor[nDrawIndx]);

                    if (_listTool[i].GetType() == typeof(CogPMAlignTool))
                    {
                        nCnt = (_listTool[i] as CogPMAlignTool).Results.Count;

                        if (nCnt > 0)
                        {
                            if (strResData == "")
                                strResData = string.Format("{0} = 임계값 : {1}, 스코어 : {2:F2}", (_listTool[i] as CogPMAlignTool).Name, (_listTool[i] as CogPMAlignTool).RunParams.AcceptThreshold, (_listTool[i] as CogPMAlignTool).Results[0].Score);
                            else
                                strResData += string.Format("/ {0} = 임계값 : {1}, 스코어 : {2:F2}", (_listTool[i] as CogPMAlignTool).Name, (_listTool[i] as CogPMAlignTool).RunParams.AcceptThreshold, (_listTool[i] as CogPMAlignTool).Results[0].Score);
                        }

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        color = GetPinColor(modelParam, strPinData, nCnt, nDrawIndx);
                        cogRegion.Add(GetToolRegion((_listTool[i] as CogPMAlignTool).SearchRegion, color, _graphicVpro.nLineThick[nDrawIndx] + 1, ref coglbl));
                        coglbl.Color = color;

                        if (nCnt > 0)
                        {
                            coglbl.Text = string.Format("{0:F2}%", (_listTool[i] as CogPMAlignTool).Results[0].Score * 100);

                            shape = null;
                            shape = new CogCompositeShape[nCnt];

                            for (int j = 0; j < nCnt; j++)
                            {
                                shape[j] = new CogCompositeShape();
                                shape[j] = (_job.Tools[i] as CogPMAlignTool).Results[j].CreateResultGraphics(CogPMAlignResultGraphicConstants.All);
                                shape[j].CompositionMode = CogCompositeShapeCompositionModeConstants.Uniform;
                                shape[j].Color = CogColorConstants.Yellow;
                                shape[j].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                                //shape[j].TipText = string.Format("{0}, Score : {1:F3}", (_job.Tools[i] as CogPMAlignTool).Name, (_job.Tools[i] as CogPMAlignTool).Results[j].Score);

                                cogShape.Add(shape[j]);
                            }
                        }

                        else
                            coglbl.Text = "";

                        cogLbl.Add(coglbl);
                    }

                    if (_listTool[i].GetType() == typeof(CogBlobTool))
                    {
                        CogBlobResultCollection blob = (_listTool[i] as CogBlobTool).Results.GetTopLevelBlobs(false);
                        nCnt = (_listTool[i] as CogBlobTool).Results.GetBlobs().Count;

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        color = GetPinColor(modelParam, strPinData, nCnt, nDrawIndx);
                        cogRegion.Add(GetToolRegion((_listTool[i] as CogBlobTool).Region, color, _graphicVpro.nLineThick[nDrawIndx] + 1, ref coglbl));

                        coglbl.Color = color;

                        if (nCnt > 0)
                        {
                            coglbl.Text = string.Format("{0}", (_listTool[i] as CogBlobTool).Results.GetBlobs()[0].Area);

                            if ((_listTool[i] as CogBlobTool).RunParams.RunTimeMeasures.Count > 0)
                            {
                                for (var j = 0; j < (_listTool[i] as CogBlobTool).RunParams.RunTimeMeasures.Count; j++)
                                {
                                    if ((_listTool[i] as CogBlobTool).RunParams.RunTimeMeasures[j].Measure == CogBlobMeasureConstants.Area)
                                    {
                                        if (strResData == "")
                                            strResData = string.Format("{0} = 하한값 : {1}, 상한값 : {2}, 측정값 : {3:F2}", (_listTool[i] as CogBlobTool).Name, (_listTool[i] as CogBlobTool).RunParams.RunTimeMeasures[j].FilterRangeLow, (_listTool[i] as CogBlobTool).RunParams.RunTimeMeasures[j].FilterRangeHigh, (_listTool[i] as CogBlobTool).Results.GetBlobs()[0].Area);
                                        else
                                            strResData += string.Format("/ {0} = 하한값 : {1}, 상한값 : {2}, 측정값 : {3:F2}", (_listTool[i] as CogBlobTool).Name, (_listTool[i] as CogBlobTool).RunParams.RunTimeMeasures[j].FilterRangeLow, (_listTool[i] as CogBlobTool).RunParams.RunTimeMeasures[j].FilterRangeHigh, (_listTool[i] as CogBlobTool).Results.GetBlobs()[0].Area);

                                        break;
                                    }
                                }
                            }
                        }
                        else
                            coglbl.Text = "";

                        cogLbl.Add(coglbl);
                    }

                    if (_listTool[i].GetType() == typeof(CogCaliperTool))
                    {
                        nCnt = (_listTool[i] as CogCaliperTool).Results.Count;

                        var region = (_listTool[i] as CogCaliperTool).Region;

                        if ((_listTool[i] as CogCaliperTool).RunParams.EdgeMode == CogCaliperEdgeModeConstants.SingleEdge)
                            region.Color = nCnt == 1 ? color : CogColorConstants.Red;
                        else
                            region.Color = nCnt == 2 ? color : CogColorConstants.Red;

                        region.LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        cogRectAffine.Add(region);

                        point = null;
                        point = new CogPointMarker[nCnt];
                        for (int j = 0; j < nCnt; j++)
                        {
                            point[j] = new CogPointMarker();
                            point[j].X = (_listTool[i] as CogCaliperTool).Results[j].PositionX;
                            point[j].Y = (_listTool[i] as CogCaliperTool).Results[j].PositionY;
                            point[j].Color = color;
                            point[j].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                            point[j].TipText = string.Format("{0}, CenterX : {0:F3}, CenterY : {1:F3}", (_listTool[i] as CogCaliperTool).Name, (_listTool[i] as CogCaliperTool).Results[j].PositionX, (_listTool[i] as CogCaliperTool).Results[j].PositionX);

                            cogPoint.Add(point[j]);

                            CogGraphicLabel coglbl = new CogGraphicLabel();
                            coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                            using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                                coglbl.Font = font;

                            coglbl.Color = color;
                            coglbl.SetXYText(point[j].X, point[j].Y, string.Format("{0:F2}%", (_listTool[i] as CogCaliperTool).Results[j].Score * 100));
                            cogLbl.Add(coglbl);

                            if (strResData == "")
                                strResData = string.Format("{0} = 스코어 : {1:F2}%", (_listTool[i] as CogCaliperTool).Name, (_listTool[i] as CogCaliperTool).Results[j].Score * 100);
                            else
                                strResData += string.Format("/ {0} = 스코어 : {1:F2}%", (_listTool[i] as CogCaliperTool).Name, (_listTool[i] as CogCaliperTool).Results[j].Score * 100);
                        }


                    }

                    if (_listTool[i].GetType() == typeof(CogCreateCircleTool))
                    {
                        Circle = null;
                        Circle = new CogCircle[1];
                        Circle[0] = new CogCircle();
                        Circle[0] = (_listTool[i] as CogCreateCircleTool).GetOutputCircle();
                        Circle[0].Color = color;
                        Circle[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Circle[0].GraphicDOFEnable = CogCircleDOFConstants.None;
                        Circle[0].Interactive = true;
                        Circle[0].SelectedSpaceName = (_listTool[i] as CogCreateCircleTool).InputImage.SelectedSpaceName;
                        Circle[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}, Area : {3:F3}", (_listTool[i] as CogCreateCircleTool).Name, Circle[0].CenterX, Circle[0].CenterY, Circle[0].Area);
                        cogCircle.Add(Circle[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Circle[0].CenterX, Circle[0].CenterY, string.Format("{0:F2}", Circle[0].Radius * 2));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}, Area : {3:F3}", (_listTool[i] as CogCreateCircleTool).Name, Circle[0].CenterX, Circle[0].CenterY, Circle[0].Area);
                        else
                            strResData += string.Format("/ {0}, CenterX : {1:F3}, CenterY : {2:F3}, Area : {3:F3}", (_listTool[i] as CogCreateCircleTool).Name, Circle[0].CenterX, Circle[0].CenterY, Circle[0].Area);
                    }

                    if (_listTool[i].GetType() == typeof(CogCreateEllipseTool))
                    {
                        Ellipse = null;
                        Ellipse = new CogEllipse[1];
                        Ellipse[0] = new CogEllipse();
                        Ellipse[0] = (_listTool[i] as CogCreateEllipseTool).GetOutputEllipse();
                        Ellipse[0].Color = CogColorConstants.Green;
                        Ellipse[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Ellipse[0].GraphicDOFEnable = CogEllipseDOFConstants.None;
                        Ellipse[0].Interactive = true;
                        Ellipse[0].SelectedSpaceName = (_listTool[i] as CogCreateCircleTool).InputImage.SelectedSpaceName;
                        Ellipse[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}, Area : {3:F3}", (_listTool[i] as CogCreateEllipseTool).Name, Ellipse[0].CenterX, Ellipse[0].CenterY, Ellipse[0].Area);
                        cogEllipse.Add(Ellipse[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Ellipse[0].CenterX, Ellipse[0].CenterY, string.Format("{0:F2}", Ellipse[0].Area));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}, Area : {3:F3}", (_listTool[i] as CogCreateEllipseTool).Name, Ellipse[0].CenterX, Ellipse[0].CenterY, Ellipse[0].Area);
                        else
                            strResData += string.Format("/ {0}, CenterX : {1:F3}, CenterY : {2:F3}, Area : {3:F3}", (_listTool[i] as CogCreateEllipseTool).Name, Ellipse[0].CenterX, Ellipse[0].CenterY, Ellipse[0].Area);
                    }

                    if (_listTool[i].GetType() == typeof(CogCreateLineTool))
                    {
                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = (_listTool[i] as CogCreateLineTool).GetOutputLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogCreateLineTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateLineTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        if (strResData == "")
                            strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateLineTool).Name, Line[0].X, Line[0].Y);
                        else
                            strResData += string.Format("/ {0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateLineTool).Name, Line[0].X, Line[0].Y);

                    }

                    if (_listTool[i].GetType() == typeof(CogCreateSegmentAvgSegsTool))
                    {
                        Line = null;
                        Line = new CogLine[2];
                        Line[0] = new CogLine();
                        Line[1] = new CogLine();
                        Line[0] = (_listTool[i] as CogCreateSegmentAvgSegsTool).SegmentA.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogCreateSegmentAvgSegsTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateSegmentAvgSegsTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        if (strResData == "")
                            strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateSegmentAvgSegsTool).Name, Line[0].X, Line[0].Y);
                        else
                            strResData += string.Format(" / {0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateSegmentAvgSegsTool).Name, Line[0].X, Line[0].Y);

                        Line[1] = (_listTool[i] as CogCreateSegmentAvgSegsTool).SegmentB.CreateLine();
                        Line[1].Color = color;
                        Line[1].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[1].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[1].Interactive = true;
                        Line[1].SelectedSpaceName = (_listTool[i] as CogCreateSegmentAvgSegsTool).InputImage.SelectedSpaceName;
                        Line[1].TipText = string.Format("{0}, X : {1:F3}, rY : {2:F3}", (_listTool[i] as CogCreateSegmentAvgSegsTool).Name, Line[1].X, Line[1].Y);
                        cogLine.Add(Line[1]);

                        if (strResData == "")
                            strResData = string.Format("{0}, X : {1:F3}, rY : {2:F3}", (_listTool[i] as CogCreateSegmentAvgSegsTool).Name, Line[1].X, Line[1].Y);
                        else
                            strResData += string.Format("{0}, X : {1:F3}, rY : {2:F3}", (_listTool[i] as CogCreateSegmentAvgSegsTool).Name, Line[1].X, Line[1].Y);
                    }

                    if (_listTool[i].GetType() == typeof(CogCreateSegmentTool))
                    {
                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = (_listTool[i] as CogCreateSegmentTool).Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogCreateSegmentTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateSegmentTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        if (strResData == "")
                            strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateSegmentTool).Name, Line[0].X, Line[0].Y);
                        else
                            strResData += string.Format("/ {0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogCreateSegmentTool).Name, Line[0].X, Line[0].Y);

                    }

                    if (_listTool[i].GetType() == typeof(CogFindCircleTool))
                    {
                        nCnt = (_listTool[i] as CogFindCircleTool).Results.Count;
                        if (nCnt > 0)
                        {
                            Circle = null;
                            Circle = new CogCircle[1];

                            Circle[0] = new CogCircle();
                            Circle[0] = (_listTool[i] as CogFindCircleTool).Results.GetCircle();
                            Circle[0].Color = color;
                            Circle[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                            Circle[0].GraphicDOFEnable = CogCircleDOFConstants.None;
                            Circle[0].Interactive = true;
                            Circle[0].SelectedSpaceName = (_listTool[i] as CogFindCircleTool).InputImage.SelectedSpaceName;
                            Circle[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogFindCircleTool).Name, Circle[0].CenterX, Circle[0].CenterX);
                            cogCircle.Add(Circle[0]);

                            CogGraphicLabel coglbl = new CogGraphicLabel();
                            coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                            using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                                coglbl.Font = font;

                            coglbl.Color = color;
                            coglbl.SetXYText(Circle[0].CenterX, Circle[0].CenterY, string.Format("{0:F2}", Circle[0].Radius * 2));
                            cogLbl.Add(coglbl);

                            if (strResData == "")
                                strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogFindCircleTool).Name, Circle[0].CenterX, Circle[0].CenterX);
                            else
                                strResData += string.Format("/ {0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogFindCircleTool).Name, Circle[0].CenterX, Circle[0].CenterX);
                        }
                    }

                    if (_listTool[i].GetType() == typeof(CogFindCornerTool))
                    {
                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = (_listTool[i] as CogFindCornerTool).Result.CornerX;
                        point[0].Y = (_listTool[i] as CogFindCornerTool).Result.CornerY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogFindCornerTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}, CornerX : {1:F3}, CornerY : {2:F3}", (_listTool[i] as CogFindCornerTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        if (strResData == "")
                            strResData = string.Format("{0}, CornerX : {1:F3}, CornerY : {2:F3}", (_listTool[i] as CogFindCornerTool).Name, point[0].X, point[0].Y);
                        else
                            strResData += string.Format("/ {0}, CornerX : {1:F3}, CornerY : {2:F3}", (_listTool[i] as CogFindCornerTool).Name, point[0].X, point[0].Y);
                    }

                    if (_listTool[i].GetType() == typeof(CogFindEllipseTool))
                    {
                        nCnt = (_listTool[i] as CogFindEllipseTool).Results.Count;
                        Ellipse = null;
                        Ellipse = new CogEllipse[nCnt];

                        for (int j = 0; j < nCnt; j++)
                        {
                            Ellipse[j] = new CogEllipse();
                            Ellipse[j] = (_listTool[i] as CogFindEllipseTool).Results.GetEllipse();
                            Ellipse[j].Color = color;
                            Ellipse[j].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                            Ellipse[j].GraphicDOFEnable = CogEllipseDOFConstants.None;
                            Ellipse[j].Interactive = true;
                            Ellipse[j].SelectedSpaceName = (_listTool[i] as CogFindEllipseTool).InputImage.SelectedSpaceName;
                            Ellipse[j].TipText = string.Format("{0}, X : {1:F3}, Y : {1:F3}, Area : {2:F3}", (_listTool[i] as CogFindEllipseTool).Name, Ellipse[j].CenterX, Ellipse[j].CenterY, Ellipse[j].Area);
                            cogEllipse.Add(Ellipse[j]);

                            CogGraphicLabel coglbl = new CogGraphicLabel();
                            coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                            using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                                coglbl.Font = font;

                            coglbl.Color = color;
                            coglbl.SetXYText(Ellipse[j].CenterX, Ellipse[j].CenterY, string.Format("{0:F2}", Ellipse[j].Area));
                            cogLbl.Add(coglbl);

                            if (strResData == "")
                                strResData = string.Format("{0}, X : {1:F3}, Y : {1:F3}, Area : {2:F3}", (_listTool[i] as CogFindEllipseTool).Name, Ellipse[j].CenterX, Ellipse[j].CenterY, Ellipse[j].Area);
                            else
                                strResData += string.Format("/ {0}, X : {1:F3}, Y : {1:F3}, Area : {2:F3}", (_listTool[i] as CogFindEllipseTool).Name, Ellipse[j].CenterX, Ellipse[j].CenterY, Ellipse[j].Area);
                        }
                    }

                    if (_listTool[i].GetType() == typeof(CogFindLineTool))
                    {
                        nCnt = (_listTool[i] as CogFindLineTool).Results.Count;
                        Line = null;
                        Line = new CogLine[nCnt];
                        for (int j = 0; j < (_listTool[i] as CogFindLineTool).Results.Count; j++)
                        {
                            Line[j] = new CogLine();
                            Line[j] = (_listTool[i] as CogFindLineTool).Results.GetLine();
                            Line[j].Color = color;
                            Line[j].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                            Line[j].GraphicDOFEnable = CogLineDOFConstants.None;
                            Line[j].Interactive = true;
                            Line[j].SelectedSpaceName = (_listTool[i] as CogFindLineTool).InputImage.SelectedSpaceName;
                            Line[j].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogFindLineTool).Name, Line[j].X, Line[j].Y);
                            cogLine.Add(Line[j]);

                            if (strResData == "")
                                strResData = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogFindLineTool).Name, Line[j].X, Line[j].Y);
                            else
                                strResData += string.Format("/ {0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogFindLineTool).Name, Line[j].X, Line[j].Y);
                        }
                    }

                    if (_listTool[i].GetType() == typeof(CogFindCircleTool))
                    {
                        nCnt = (_listTool[i] as CogFindCircleTool).Results.Count;
                        Circle = null;
                        Circle = new CogCircle[nCnt];
                        for (int j = 0; j < nCnt; j++)
                        {
                            Circle[j] = new CogCircle();
                            Circle[j] = (_listTool[i] as CogFindCircleTool).Results.GetCircle();
                            Circle[j].Color = color;
                            Circle[j].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                            Circle[j].GraphicDOFEnable = CogCircleDOFConstants.None;
                            Circle[j].Interactive = true;
                            Circle[j].SelectedSpaceName = (_listTool[i] as CogFindCircleTool).InputImage.SelectedSpaceName;
                            Circle[j].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogFindCircleTool).Name, Circle[j].CenterX, Circle[j].CenterY);
                            cogCircle.Add(Circle[j]);

                            CogGraphicLabel coglbl = new CogGraphicLabel();
                            coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                            using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                                coglbl.Font = font;

                            coglbl.Color = color;
                            coglbl.SetXYText(Circle[j].CenterX, Circle[j].CenterY, string.Format("{0:F2}", Circle[j].Radius * 2));
                            cogLbl.Add(coglbl);

                            if (strResData == "")
                                strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}, Area : {3:F3}", (_listTool[i] as CogFindCircleTool).Name, Circle[j].CenterX, Circle[j].CenterY, Circle[j].Area);
                            else
                                strResData += string.Format("/ {0}, CenterX : {1:F3}, CenterY : {2:F3}, Area: {3:F3}", (_listTool[i] as CogFindCircleTool).Name, Circle[j].CenterX, Circle[j].CenterY, Circle[j].Area);
                        }
                    }

                    if (_listTool[i].GetType() == typeof(CogFitCircleTool))
                    {
                        Circle = null;
                        Circle = new CogCircle[1];
                        Circle[0] = new CogCircle();
                        Circle[0] = (_listTool[i] as CogFitCircleTool).Result.GetCircle();
                        Circle[0].Color = color;
                        Circle[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Circle[0].GraphicDOFEnable = CogCircleDOFConstants.None;
                        Circle[0].Interactive = true;
                        Circle[0].SelectedSpaceName = (_listTool[i] as CogFitCircleTool).InputImage.SelectedSpaceName;
                        Circle[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}, , Area : {3:F3}", (_listTool[i] as CogFitCircleTool).Name, Circle[0].CenterX, Circle[0].CenterY, Circle[0].Area);
                        cogCircle.Add(Circle[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Circle[0].CenterX, Circle[0].CenterY, string.Format("{0:F2}", Circle[0].Radius * 2));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}, , Area : {3:F3}", (_listTool[i] as CogFitCircleTool).Name, Circle[0].CenterX, Circle[0].CenterY, Circle[0].Area);
                        else
                            strResData += string.Format("/ {0}, CenterX : {1:F3}, CenterY : {2:F3}, , Area : {3:F3}", (_listTool[i] as CogFitCircleTool).Name, Circle[0].CenterX, Circle[0].CenterY, Circle[0].Area);
                    }

                    if (_listTool[i].GetType() == typeof(CogFitEllipseTool))
                    {
                        Ellipse = null;
                        Ellipse = new CogEllipse[1];
                        Ellipse[0] = new CogEllipse();
                        Ellipse[0] = (_listTool[i] as CogFitEllipseTool).Result.GetEllipse();
                        Ellipse[0].Color = color;
                        Ellipse[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Ellipse[0].GraphicDOFEnable = CogEllipseDOFConstants.None;
                        Ellipse[0].Interactive = true;
                        Ellipse[0].SelectedSpaceName = (_listTool[i] as CogFitEllipseTool).InputImage.SelectedSpaceName;
                        Ellipse[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}, Area : {3:F3}", (_listTool[i] as CogFitEllipseTool).Name, Ellipse[0].CenterX, Ellipse[0].CenterX, Ellipse[0].Area);
                        cogEllipse.Add(Ellipse[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Ellipse[0].CenterX, Ellipse[0].CenterY, string.Format("{0:F2}", Ellipse[0].Area));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, X : {1:F3}, Y : {2:F3}, Area : {3:F3}", (_listTool[i] as CogFitEllipseTool).Name, Ellipse[0].CenterX, Ellipse[0].CenterX, Ellipse[0].Area);
                        else
                            strResData += string.Format("/ {0}, X : {1:F3}, Y : {2:F3}, Area : {3:F3}", (_listTool[i] as CogFitEllipseTool).Name, Ellipse[0].CenterX, Ellipse[0].CenterX, Ellipse[0].Area);
                    }

                    if (_listTool[i].GetType() == typeof(CogFitLineTool))
                    {
                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = (_listTool[i] as CogFitLineTool).Result.GetLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogFitLineTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogFitLineTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        if (strResData == "")
                            strResData = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogFitLineTool).Name, Line[0].X, Line[0].Y);
                        else
                            strResData += string.Format("/ {0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogFitLineTool).Name, Line[0].X, Line[0].Y);
                    }

                    if (_listTool[i].GetType() == typeof(CogAngleLineLineTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogAngleLineLineTool).LineA.X;
                        Segment.Segment.StartX = (_listTool[i] as CogAngleLineLineTool).LineA.Y;

                        Segment.Segment.EndX = (_listTool[i] as CogAngleLineLineTool).LineB.X;
                        Segment.Segment.EndY = (_listTool[i] as CogAngleLineLineTool).LineB.Y;

                        point = null;
                        point = new CogPointMarker[2];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = CogColorConstants.Green;
                        point[0].LineWidthInScreenPixels = 2;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogAngleLineLineTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}, CornerX : {1:F3}, CornerY : {2:F3}", (_listTool[i] as CogAngleLineLineTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);


                        point[1] = new CogPointMarker();
                        point[1].X = Segment.Segment.EndX;
                        point[1].Y = Segment.Segment.EndY;
                        point[1].Color = CogColorConstants.Green;
                        point[1].LineWidthInScreenPixels = 2;
                        point[1].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[1].Interactive = true;
                        point[1].SelectedSpaceName = (_listTool[i] as CogAngleLineLineTool).InputImage.SelectedSpaceName;
                        point[1].TipText = string.Format("{0}, CornerX : {1:F3}, CornerY : {2:F3}", (_listTool[i] as CogAngleLineLineTool).Name, point[1].X, point[1].Y);
                        cogPoint.Add(point[1]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = CogColorConstants.Green;
                        Line[0].LineWidthInScreenPixels = 2;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogAngleLineLineTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogAngleLineLineTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogAngleLineLineTool).Angle * (180.0 / Math.PI)));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Angle : {1:F3}", (_listTool[i] as CogAngleLineLineTool).Name, (_listTool[i] as CogAngleLineLineTool).Angle * (180.0 / Math.PI));
                        else
                            strResData += string.Format("/ {0}, Angle : {1:F3}", (_listTool[i] as CogAngleLineLineTool).Name, (_listTool[i] as CogAngleLineLineTool).Angle * (180.0 / Math.PI));
                    }

                    if (_listTool[i].GetType() == typeof(CogAnglePointPointTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogAnglePointPointTool).StartX;
                        Segment.Segment.StartY = (_listTool[i] as CogAnglePointPointTool).StartY;

                        Segment.Segment.EndX = (_listTool[i] as CogAnglePointPointTool).EndX;
                        Segment.Segment.EndY = (_listTool[i] as CogAnglePointPointTool).EndY;

                        point = null;
                        point = new CogPointMarker[2];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogAnglePointPointTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY: {2:F3}", (_listTool[i] as CogAnglePointPointTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        point[1] = new CogPointMarker();
                        point[1].X = Segment.Segment.EndX;
                        point[1].Y = Segment.Segment.EndY;
                        point[1].Color = color;
                        point[1].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[1].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[1].Interactive = true;
                        point[1].SelectedSpaceName = (_listTool[i] as CogAnglePointPointTool).InputImage.SelectedSpaceName;
                        point[1].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogAnglePointPointTool).Name, point[1].X, point[1].Y);
                        cogPoint.Add(point[1]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogAnglePointPointTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogAnglePointPointTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogAnglePointPointTool).Angle * (180.0 / Math.PI)));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Angle : {1:F3}", (_listTool[i] as CogAnglePointPointTool).Name, (_listTool[i] as CogAnglePointPointTool).Angle * (180.0 / Math.PI));
                        else
                            strResData += string.Format("/ {0}, Angle : {1:F3}", (_listTool[i] as CogAnglePointPointTool).Name, (_listTool[i] as CogAnglePointPointTool).Angle * (180.0 / Math.PI));
                    }

                    if (_listTool[i].GetType() == typeof(CogColorExtractorTool))
                    {
                        color = GetPinColor(modelParam, strPinData, nCnt, nDrawIndx);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        cogRegion.Add(GetToolRegion((_listTool[i] as CogColorExtractorTool).Region, color, _graphicVpro.nLineThick[nDrawIndx] + 1, ref coglbl));
                        coglbl.Color = color;

                        if ((_listTool[i] as CogColorExtractorTool).Results.GroupResults.Count > 1)
                        {
                            if (Math.Abs((_listTool[i] as CogColorExtractorTool).Results.GroupResults[0].PixelCount - (_listTool[i] as CogColorExtractorTool).Results.GroupResults[1].PixelCount) > 3000)
                                coglbl.Text = Math.Abs((_listTool[i] as CogColorExtractorTool).Results.GroupResults[0].PixelCount - (_listTool[i] as CogColorExtractorTool).Results.GroupResults[1].PixelCount).ToString();
                            else
                                coglbl.Text = "0";
                        }
                        else
                            coglbl.Text = (_listTool[i] as CogColorExtractorTool).Results.GroupResults[0].PixelCount.ToString();

                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, PixelCount : {1:F3}", (_listTool[i] as CogColorExtractorTool).Name, (_listTool[i] as CogColorExtractorTool).Results.GroupResults[0].PixelCount.ToString());
                        else
                            strResData += string.Format("/ {0}, PixelCount : {1:F3}", (_listTool[i] as CogColorExtractorTool).Name, (_listTool[i] as CogColorExtractorTool).Results.GroupResults[0].PixelCount.ToString());
                    }

                    if (_listTool[i].GetType() == typeof(CogDistanceCircleCircleTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistanceCircleCircleTool).CircleA.CenterX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistanceCircleCircleTool).CircleA.CenterY;

                        Segment.Segment.EndX = (_listTool[i] as CogDistanceCircleCircleTool).CircleB.CenterX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistanceCircleCircleTool).CircleB.CenterY;

                        point = null;
                        point = new CogPointMarker[2];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistanceCircleCircleTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceCircleCircleTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        point[1] = new CogPointMarker();
                        point[1].X = Segment.Segment.EndX;
                        point[1].Y = Segment.Segment.EndY;
                        point[1].Color = color;
                        point[1].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[1].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[1].Interactive = true;
                        point[1].SelectedSpaceName = (_listTool[i] as CogDistanceCircleCircleTool).InputImage.SelectedSpaceName;
                        point[1].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceCircleCircleTool).Name, point[1].X, point[1].Y);
                        cogPoint.Add(point[1]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistanceCircleCircleTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistanceCircleCircleTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistanceCircleCircleTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistanceCircleCircleTool).Name, (_listTool[i] as CogDistanceCircleCircleTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistanceCircleCircleTool).Name, (_listTool[i] as CogDistanceCircleCircleTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistanceLineCircleTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistanceLineCircleTool).InputCircle.CenterX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistanceLineCircleTool).InputCircle.CenterY;

                        Segment.Segment.EndX = (_listTool[i] as CogDistanceLineCircleTool).Line.X;
                        Segment.Segment.EndY = (_listTool[i] as CogDistanceLineCircleTool).Line.Y;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistanceLineCircleTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}, CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceLineCircleTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistanceLineCircleTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistanceLineCircleTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistanceCircleCircleTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistanceLineCircleTool).Name, (_listTool[i] as CogDistanceCircleCircleTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistanceLineCircleTool).Name, (_listTool[i] as CogDistanceCircleCircleTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistanceLineEllipseTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistanceLineEllipseTool).EllipseX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistanceLineEllipseTool).EllipseY;

                        Segment.Segment.EndX = (_listTool[i] as CogDistanceLineEllipseTool).LineX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistanceLineEllipseTool).LineY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistanceLineEllipseTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceLineEllipseTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistanceLineEllipseTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistanceLineEllipseTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistanceLineEllipseTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistanceLineEllipseTool).Name, (_listTool[i] as CogDistanceLineEllipseTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistanceLineEllipseTool).Name, (_listTool[i] as CogDistanceLineEllipseTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistancePointCircleTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistancePointCircleTool).X;
                        Segment.Segment.StartY = (_listTool[i] as CogDistancePointCircleTool).Y;

                        Segment.Segment.EndX = (_listTool[i] as CogDistancePointCircleTool).InputCircle.CenterX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistancePointCircleTool).InputCircle.CenterY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistancePointCircleTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistancePointCircleTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistancePointCircleTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistancePointCircleTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistancePointCircleTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointCircleTool).Name, (_listTool[i] as CogDistancePointCircleTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointCircleTool).Name, (_listTool[i] as CogDistancePointCircleTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistancePointEllipseTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistancePointEllipseTool).X;
                        Segment.Segment.StartY = (_listTool[i] as CogDistancePointEllipseTool).Y;

                        Segment.Segment.EndX = (_listTool[i] as CogDistancePointEllipseTool).EllipseX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistancePointEllipseTool).EllipseY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistancePointEllipseTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistancePointEllipseTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistancePointEllipseTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistancePointEllipseTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistancePointEllipseTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}(LineA), Distance : {1:F3}", (_listTool[i] as CogDistancePointEllipseTool).Name, (_listTool[i] as CogDistancePointEllipseTool).Distance);
                        else
                            strResData += string.Format("/ {0}(LineA), Distance : {1:F3}", (_listTool[i] as CogDistancePointEllipseTool).Name, (_listTool[i] as CogDistancePointEllipseTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistancePointLineTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistancePointLineTool).X;
                        Segment.Segment.StartY = (_listTool[i] as CogDistancePointLineTool).Y;

                        Segment.Segment.EndX = (_listTool[i] as CogDistancePointLineTool).LineX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistancePointLineTool).LineY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = (_listTool[i] as CogDistancePointLineTool).X;
                        point[0].Y = (_listTool[i] as CogDistancePointLineTool).Y;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistancePointLineTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistancePointLineTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0].SetFromStartXYEndXY(Segment.Segment.StartX, Segment.Segment.StartY, Segment.Segment.EndX, Segment.Segment.EndY);
                        //Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistancePointLineTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistancePointLineTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistancePointLineTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointLineTool).Name, (_listTool[i] as CogDistancePointLineTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointLineTool).Name, (_listTool[i] as CogDistancePointLineTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistancePointPointTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistancePointPointTool).StartX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistancePointPointTool).StartY;

                        Segment.Segment.EndX = (_listTool[i] as CogDistancePointPointTool).EndX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistancePointPointTool).EndY;

                        point = null;
                        point = new CogPointMarker[2];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistancePointPointTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistancePointPointTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        point[1] = new CogPointMarker();
                        point[1].X = Segment.Segment.EndX;
                        point[1].Y = Segment.Segment.EndY;
                        point[1].Color = color;
                        point[1].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[1].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[1].Interactive = true;
                        point[1].SelectedSpaceName = (_listTool[i] as CogDistancePointPointTool).InputImage.SelectedSpaceName;
                        point[1].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistancePointPointTool).Name, point[1].X, point[1].Y);
                        cogPoint.Add(point[1]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0].SetFromStartXYEndXY(point[0].X, point[0].Y, point[1].X, point[1].Y);
                        //Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistancePointPointTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistancePointPointTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistancePointPointTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointPointTool).Name, (_listTool[i] as CogDistancePointPointTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointPointTool).Name, (_listTool[i] as CogDistancePointPointTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistancePointSegmentTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistancePointSegmentTool).X;
                        Segment.Segment.StartY = (_listTool[i] as CogDistancePointSegmentTool).X;

                        Segment.Segment.EndX = (_listTool[i] as CogDistancePointSegmentTool).SegmentX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistancePointSegmentTool).SegmentY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = (_listTool[i] as CogDistancePointSegmentTool).X;
                        point[0].Y = (_listTool[i] as CogDistancePointSegmentTool).Y;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistancePointSegmentTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistancePointSegmentTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistancePointSegmentTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistancePointSegmentTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistancePointSegmentTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointSegmentTool).Name, (_listTool[i] as CogDistancePointSegmentTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistancePointSegmentTool).Name, (_listTool[i] as CogDistancePointSegmentTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistanceSegmentCircleTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistanceSegmentCircleTool).InputCircle.CenterX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistanceSegmentCircleTool).InputCircle.CenterY;

                        Segment.Segment.EndX = (_listTool[i] as CogDistanceSegmentCircleTool).SegmentX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistanceSegmentCircleTool).SegmentY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentCircleTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceSegmentCircleTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentCircleTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistanceSegmentCircleTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistanceSegmentCircleTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentCircleTool).Name, (_listTool[i] as CogDistanceSegmentCircleTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentCircleTool).Name, (_listTool[i] as CogDistanceSegmentCircleTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistanceSegmentEllipseTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistanceSegmentEllipseTool).EllipseX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistanceSegmentEllipseTool).EllipseX;

                        Segment.Segment.EndX = (_listTool[i] as CogDistanceSegmentEllipseTool).SegmentX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistanceSegmentEllipseTool).SegmentY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentEllipseTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceSegmentEllipseTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentEllipseTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistanceSegmentEllipseTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistanceSegmentEllipseTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentEllipseTool).Name, (_listTool[i] as CogDistanceSegmentEllipseTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentEllipseTool).Name, (_listTool[i] as CogDistanceSegmentEllipseTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistanceSegmentLineTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistanceSegmentLineTool).LineX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistanceSegmentLineTool).LineY;

                        Segment.Segment.EndX = (_listTool[i] as CogDistanceSegmentLineTool).SegmentX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistanceSegmentLineTool).SegmentY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentLineTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceSegmentLineTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentLineTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistanceSegmentLineTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistanceSegmentLineTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentLineTool).Name, (_listTool[i] as CogDistanceSegmentLineTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentLineTool).Name, (_listTool[i] as CogDistanceSegmentLineTool).Distance);
                    }

                    if (_listTool[i].GetType() == typeof(CogDistanceSegmentSegmentTool))
                    {
                        Segment = null;
                        Segment = new CogCreateSegmentTool();

                        Segment.Segment.StartX = (_listTool[i] as CogDistanceSegmentSegmentTool).SegmentAX;
                        Segment.Segment.StartY = (_listTool[i] as CogDistanceSegmentSegmentTool).SegmentAY;

                        Segment.Segment.EndX = (_listTool[i] as CogDistanceSegmentSegmentTool).SegmentBX;
                        Segment.Segment.EndY = (_listTool[i] as CogDistanceSegmentSegmentTool).SegmentBY;

                        point = null;
                        point = new CogPointMarker[1];
                        point[0] = new CogPointMarker();
                        point[0].X = Segment.Segment.StartX;
                        point[0].Y = Segment.Segment.StartY;
                        point[0].Color = color;
                        point[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        point[0].GraphicDOFEnable = CogPointMarkerDOFConstants.None;
                        point[0].Interactive = true;
                        point[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentSegmentTool).InputImage.SelectedSpaceName;
                        point[0].TipText = string.Format("{0}(LineA), CenterX : {1:F3}, CenterY : {2:F3}", (_listTool[i] as CogDistanceSegmentSegmentTool).Name, point[0].X, point[0].Y);
                        cogPoint.Add(point[0]);

                        Line = null;
                        Line = new CogLine[1];
                        Line[0] = new CogLine();
                        Line[0] = Segment.Segment.CreateLine();
                        Line[0].Color = color;
                        Line[0].LineWidthInScreenPixels = _graphicVpro.nLineThick[nDrawIndx] + 1;
                        Line[0].GraphicDOFEnable = CogLineDOFConstants.None;
                        Line[0].Interactive = true;
                        Line[0].SelectedSpaceName = (_listTool[i] as CogDistanceSegmentSegmentTool).InputImage.SelectedSpaceName;
                        Line[0].TipText = string.Format("{0}, X : {1:F3}, Y : {2:F3}", (_listTool[i] as CogDistanceSegmentSegmentTool).Name, Line[0].X, Line[0].Y);
                        cogLine.Add(Line[0]);

                        CogGraphicLabel coglbl = new CogGraphicLabel();
                        coglbl.Alignment = CogGraphicLabelAlignmentConstants.BaselineCenter;
                        using (Font font = new Font("Tahoma", 9, FontStyle.Bold))
                            coglbl.Font = font;

                        coglbl.Color = color;
                        coglbl.SetXYText(Line[0].X, Line[0].Y, string.Format("{0:F2}", (_listTool[i] as CogDistanceSegmentSegmentTool).Distance));
                        cogLbl.Add(coglbl);

                        if (strResData == "")
                            strResData = string.Format("{0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentSegmentTool).Name, (_listTool[i] as CogDistanceSegmentSegmentTool).Distance);
                        else
                            strResData += string.Format("/ {0}, Distance : {1:F3}", (_listTool[i] as CogDistanceSegmentSegmentTool).Name, (_listTool[i] as CogDistanceSegmentSegmentTool).Distance);
                    }
                }
            }
            catch { }
        }
    }
}
