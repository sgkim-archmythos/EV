using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using System.Threading;

using Cognex.VisionPro;
using static GlovalVar;
using DevExpress.Utils.Extensions;
using S7.Net.Types;

namespace VisionSystem
{
    public delegate void SendValueHandler(int nIdx, string strValue);
    public delegate void SendDLInfo(string strType, string strPath);
    public partial class CamParamControl : DevExpress.XtraEditors.XtraUserControl
    {
        public SendDLInfo _OnDLInfo;

        frmMain _frmMain;
        CodeControl[] _codeControl = null;
        int _nIdx = 0;
        string _strModel = "";
        bool _bLoadSame = false;
        DirectoryInfo[] _vppDirectoryInfos;
        int _nCodeCnt = 0;

        CogRectangle[] _cogRect = new CogRectangle[50];


        public CamParamControl(frmMain MainFrm, int nidx, string strModel)
        {
            InitializeComponent();
            _nIdx = nidx;
            _frmMain = MainFrm;
            _strModel = strModel;

            ChangeLanguage();
        }

        public void ChangeLanguage()
        {
            if (_Language == Language.English)
            {
                lblGrabDelay.Text = "Grab Delay : ";
                lblExpose.Text = "Expose : ";
                lblCodeNo.Text = "Code : ";
                btnCode.Text = "Code Table";
                lblResolution.Text = "Resoultion : ";
                lblDefctInsp.Text = "Defect Inspection : ";
                lbl2DInsp.Text = "2D Inspection : ";
                lbl2DData.Text = "2D Data : ";
                lblDatadigit.Text = "Data digit value : ";
                lblAlign.Text = "Align Inspection : ";
                lblMasterX.Text = "Master Location X : ";
                lblMasterY.Text = "Master Location Y : ";
                lblMasterR.Text = "Master Location R : ";
                lblOffsetX.Text = "Offset X : ";
                lblOffsetY.Text = "Offset Y : ";
                lblOffsetR.Text = "Offset R : ";
                lblReInsp.Text = "Re-inspection quantity : ";
                lblExposeVar.Text = "Exposure variation : ";
                lblPinChange.Text = "Pin Change Inspection : ";
                
            }
            else
            {
                lblGrabDelay.Text = "촬영 지연 시간 : ";
                lblExpose.Text = "노출값 : ";
                lblCodeNo.Text = "코드 : ";
                btnCode.Text = "코드 리스트";
                lblResolution.Text = "분해능 : ";
                lblDefctInsp.Text = "일반 검사 : ";
                lbl2DInsp.Text = "2D 검사 : ";
                lbl2DData.Text = "2D 데이터 : ";
                lblDatadigit.Text = "데이터 추출 : ";
                lblAlign.Text = "Align 검사 : ";
                lblMasterX.Text = "마스터 위치 X : ";
                lblMasterY.Text = "마스터 위치 Y : ";
                lblMasterR.Text = "마스터 위치 R : ";
                lblOffsetX.Text = "보정값 X : ";
                lblOffsetY.Text = "보정값 Y : ";
                lblOffsetR.Text = "보정값 R : ";
                lblReInsp.Text = "재검사 횟수 : ";
                lblExposeVar.Text = "노출값 변화량 : ";
                lblPinChange.Text = "핀 체인지 검사 : ";
                
            }
        }
        public void LoadSet(string strModel, bool bModelSame)
        {
            _bLoadSame = bModelSame;
            _strModel = strModel;

            for (var i = 0; i < 50; i++)
            {
                if (_cogRect[i] == null)
                    _cogRect[i] = new CogRectangle();
            }

            Invoke(new EventHandler(delegate
            {
                try
                {
                    if (bModelSame)
                    {
                        txtGrabDelay.Text = _modelParam[_nIdx].nGrabdelay.ToString();
                        txtExpose.Text = _modelParam[_nIdx].dExpose.ToString();
                        lblCode.Text = _modelParam[_nIdx].strCode;
                        txtDefectCnt.Text = _modelParam[_nIdx].nDefectCnt.ToString();
                        txtExposeIncrease.Text = _modelParam[_nIdx].strExposeInc;
                        swDefect.IsOn = _modelParam[_nIdx].bDefectInsp;
                        swBCR.IsOn = _modelParam[_nIdx].bBCRInsp;
                        swAlign.IsOn = _modelParam[_nIdx].bAlingInsp;
                        swDimens.IsOn = _modelParam[_nIdx].bDimens;
                        txtBCRData.Text = _modelParam[_nIdx].strBCRData;
                        txtBCRLen.Text = _modelParam[_nIdx].strBCRLen;
                        swPin.IsOn = _modelParam[_nIdx].bPinChange;
                        
                        chkMathematical.Checked = _modelParam[_nIdx].bAlignFormula;
                        txtCenterMass.Text = _modelParam[_nIdx].dCenterMass.ToString();
                        txtAlignMasterX.Text = _modelParam[_nIdx].dAlignMasterX.ToString();
                        txtAlignMasterY.Text = _modelParam[_nIdx].dAlignMasterY.ToString();
                        txtAlignMasterR.Text = _modelParam[_nIdx].dAlignMasterR.ToString();
                        txtAlignOffsetX.Text = _modelParam[_nIdx].dAlignOffsetX.ToString();
                        txtAlignOffsetY.Text = _modelParam[_nIdx].dAlignOffsetY.ToString();
                        txtAlignOffsetR.Text = _modelParam[_nIdx].dAlignOffsetR.ToString();
                        txtAlingUnit.Text = _modelParam[_nIdx].dAlignUnit.ToString();
                        txtWidthMin.Text = _modelParam[_nIdx].dWidthMin.ToString();
                        txtWidthMax.Text = _modelParam[_nIdx].dWidthMax.ToString();
                        txtHeightMin.Text = _modelParam[_nIdx].dHeightMin.ToString();
                        txtHeightMax.Text = _modelParam[_nIdx].dHeightMax.ToString();
                        txtResolution.Text = _modelParam[_nIdx].dResoluton.ToString();
                        txtPinMaster.Text = _modelParam[_nIdx].strPinMaster;
                        
                        txtPinMasterResult.Text = _modelParam[_nIdx].strPinMasterResult;
                        
                        txtTriggerNo.Text = _modelParam[_nIdx].strTriggerNo;
                        txtLightNo.Text = _modelParam[_nIdx].strLightNo;
                        txtMaxX.Text = _modelParam[_nIdx].dMaxX.ToString();
                        txtMaxY.Text = _modelParam[_nIdx].dMaxY.ToString();

                    }
                    else
                    {
                        SQL sql = new SQL();
                        ModelParam modelParam = new ModelParam();
                        sql.GetRecipe(_strProcName, _dbInfo, _nIdx, _strModel, ref modelParam);

                        txtGrabDelay.Text = modelParam.nGrabdelay.ToString();
                        txtExpose.Text = modelParam.dExpose.ToString();
                        lblCode.Text = modelParam.strCode;
                        txtDefectCnt.Text = modelParam.nDefectCnt.ToString();
                        txtExposeIncrease.Text = modelParam.strExposeInc;
                        swDefect.IsOn = modelParam.bDefectInsp;
                        swBCR.IsOn = modelParam.bBCRInsp;
                        swAlign.IsOn = modelParam.bAlingInsp;
                        swDimens.IsOn = modelParam.bDimens;
                        txtBCRData.Text = modelParam.strBCRData;
                        txtBCRLen.Text = modelParam.strBCRLen;
                        swPin.IsOn = modelParam.bPinChange;
                        
                        chkMathematical.Checked = modelParam.bAlignFormula;
                        txtCenterMass.Text = modelParam.dCenterMass.ToString();
                        txtAlignMasterX.Text = modelParam.dAlignMasterX.ToString();
                        txtAlignMasterY.Text = modelParam.dAlignMasterY.ToString();
                        txtAlignMasterR.Text = modelParam.dAlignMasterR.ToString();
                        txtAlignOffsetX.Text = modelParam.dAlignOffsetX.ToString();
                        txtAlignOffsetY.Text = modelParam.dAlignOffsetY.ToString();
                        txtAlignOffsetR.Text = modelParam.dAlignOffsetR.ToString();
                        txtAlingUnit.Text = modelParam.dAlignUnit.ToString();
                        txtWidthMin.Text = modelParam.dWidthMin.ToString();
                        txtWidthMax.Text = modelParam.dWidthMax.ToString();
                        txtHeightMin.Text = modelParam.dHeightMin.ToString();
                        txtHeightMax.Text = modelParam.dHeightMax.ToString();
                        txtResolution.Text = modelParam.dResoluton.ToString();
                        txtPinMaster.Text = modelParam.strPinMaster;
                        
                        txtPinMasterResult.Text = modelParam.strPinMasterResult;
                        
                        txtTriggerNo.Text = modelParam.strTriggerNo;
                        txtLightNo.Text = modelParam.strLightNo;
                        txtMaxX.Text = modelParam.dMaxX.ToString();
                        txtMaxY.Text = modelParam.dMaxY.ToString();       
                    }

                }
                catch (Exception ex) { }
            }));
            
        }

        private void LoadCodeTable()
        {
            try
            {
                Invoke(new EventHandler(delegate
                {
                    panel1.Visible = false;
                    panel1.Controls.Clear();

                    gpCamera.Text = string.Format("Camera_{0:D2}", _nIdx + 1);
                    DirectoryInfo dr = new DirectoryInfo(_strMasterImagePath);
                    if (!dr.Exists)
                        return;

                    _vppDirectoryInfos = dr.GetDirectories();

                    FileInfo[] fi = null;
                    for (int i = 0; i < _vppDirectoryInfos.Length; i++)
                    {
                        if (_vppDirectoryInfos[i].Name.Contains(string.Format("Camera_{0:D2}", _nIdx + 1)))
                        {
                            fi = _vppDirectoryInfos[i].GetFiles();
                            _nCodeCnt = fi.Length;

                            _codeControl = null;
                            _codeControl = new CodeControl[_nCodeCnt];

                            for (int j = 0; j < _nCodeCnt; j++)
                            {
                                _codeControl[j] = new CodeControl(j);
                                _codeControl[j].onClick = OnClick;
                                panel1.Controls.Add(_codeControl[j]);
                                _codeControl[j].Location = new Point(1, 1 + (j * _codeControl[j].Height) + 8);
                                _codeControl[j].LoadSet(fi[j]);

                                if (lblCode.Text == _codeControl[j].lblCodeName.Text)
                                    _codeControl[j].chkUse.Checked = true;
                            }

                            panel1.Visible = true;
                            //ActiveControl = labelControl10;

                            break;
                        }
                    }

                }));
            }
            catch (Exception ex)
            {
                MessageBox.Show("Set Code Table Error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void OnClick(int nIdx, string strCode, bool bChk)
        {
            lblCode.Text = "";
            for (int i = 0; i < _nCodeCnt; i++)
            {
                if (_codeControl[i].chkUse.Checked)
                {
                    lblCode.Text = _codeControl[i].lblCodeName.Text;
                    break;
                }
            }

            StatusChange(nIdx, strCode, bChk);
        }

        private void StatusChange(int nIdx, string strCode, bool bChk)
        {
            try
            {
                for (int i = 0; i < _nCodeCnt; i++)
                {
                    if (bChk)
                    {
                        if (i != nIdx)
                        {
                            _codeControl[i].chkUse.Checked = false;
                            _codeControl[i].ActiveControl = null;
                        }
                    }
                }
            }
            catch { }
        }

        public bool SaveSet(string strModelName)
        {
            _strModel = strModelName;
            SQL sql = new SQL();

            bool bChage = false;

            try
            {
                if (_strModel == _strModelName)
                {
                    if (_modelParam[_nIdx].strCode != lblCode.Text)
                    {
                        bChage = true;
                        _frmMain.AddMsg(string.Format("#{0} Cam Code : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].strCode, lblCode.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);
                    }                   

                    if (_modelParam[_nIdx].dExpose.ToString() != txtExpose.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Exposure : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dExpose, txtExpose.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].bDefectInsp != swDefect.IsOn)
                        _frmMain.AddMsg(string.Format("#{0} Cam Inspection : {1}=>{2}", _nIdx + 1, (_modelParam[_nIdx].bDefectInsp) ? "Enable" : "Disable", (swDefect.IsOn) ? "Enable" : "Disable"), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].bBCRInsp != swBCR.IsOn)
                        _frmMain.AddMsg(string.Format("#{0} Cam 2D Inspection : {1}=>{2}", _nIdx + 1, (_modelParam[_nIdx].bBCRInsp) ? "Enable" : "Disable", (swBCR.IsOn) ? "Enable" : "Disable"), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].strBCRData != txtBCRData.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam 2D Data : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].strBCRData, txtBCRData.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].strBCRLen != txtBCRLen.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam 2D Data extraction : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].strBCRLen, txtBCRLen.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].bAlingInsp != swAlign.IsOn)
                        _frmMain.AddMsg(string.Format("#{0} Cam 2D Inspection : {1}=>{2}", _nIdx + 1, (_modelParam[_nIdx].bAlingInsp) ? "Enable" : "Disable", (swAlign.IsOn) ? "Enable" : "Disable"), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dResoluton.ToString() != txtResolution.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Align Resolution : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dResoluton, txtResolution.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dAlignMasterX.ToString() != txtAlignMasterX.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Align MasterX : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dAlignMasterX, txtAlignMasterX.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dAlignMasterY.ToString() != txtAlignMasterY.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Align MasterY : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dAlignMasterY, txtAlignMasterY.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dAlignMasterR.ToString() != txtAlignMasterR.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Align MasterR : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dAlignMasterR, txtAlignMasterR.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].bDimens != swDimens.IsOn)
                        _frmMain.AddMsg(string.Format("#{0} Cam Dimension Inspection : {1}=>{2}", _nIdx + 1, (_modelParam[_nIdx].bDimens) ? "Enable" : "Disable", (swDimens.IsOn) ? "Enable" : "Disable"), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dWidthMin.ToString() != txtWidthMin.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Dimension Witdh Min Value : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dWidthMin, txtWidthMin.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dWidthMax.ToString() != txtWidthMax.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Dimension Witdh Max Value : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dWidthMax, txtWidthMax.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dHeightMin.ToString() != txtHeightMin.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Dimension Height Min Value : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dHeightMin, txtHeightMin.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].dHeightMax.ToString() != txtHeightMax.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Dimension Height Max Value : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].dHeightMax, txtHeightMax.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].bPinChange != swPin.IsOn)
                        _frmMain.AddMsg(string.Format("#{0} Cam Pin Change : {1}=>{2}", _nIdx + 1, (_modelParam[_nIdx].bPinChange) ? "Enable" : "Disable", (swPin.IsOn) ? "Enable" : "Disable"), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].strPinMaster != txtPinMaster.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Pin Change Master : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].strPinMaster, txtPinMaster.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].strTriggerNo != txtTriggerNo.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Trigger No : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].strTriggerNo, txtTriggerNo.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    if (_modelParam[_nIdx].strLightNo != txtLightNo.Text)
                        _frmMain.AddMsg(string.Format("#{0} Cam Light No : {1}=>{2}", _nIdx + 1, _modelParam[_nIdx].strLightNo, txtLightNo.Text), Color.White, false, false, GlovalVar.MsgType.Alarm);

                    
                    int.TryParse(txtGrabDelay.Text, out _modelParam[_nIdx].nGrabdelay);
                    double.TryParse(txtExpose.Text, out _modelParam[_nIdx].dExpose);
                    _modelParam[_nIdx].strCode = lblCode.Text;
                    int.TryParse(txtDefectCnt.Text, out _modelParam[_nIdx].nDefectCnt);
                    _modelParam[_nIdx].strExposeInc = txtExposeIncrease.Text;
                    _modelParam[_nIdx].bDefectInsp = swDefect.IsOn;
                    _modelParam[_nIdx].bBCRInsp = swBCR.IsOn;
                    _modelParam[_nIdx].bAlingInsp = swAlign.IsOn;
                    _modelParam[_nIdx].strBCRData = txtBCRData.Text;
                    _modelParam[_nIdx].strBCRLen = txtBCRLen.Text;
                    _modelParam[_nIdx].bPinChange = swPin.IsOn;
                    _modelParam[_nIdx].bDimens = swDimens.IsOn;
                    
                    _modelParam[_nIdx].bAlignFormula = chkMathematical.Checked;

                    double.TryParse(txtCenterMass.Text, out _modelParam[_nIdx].dCenterMass);
                    double.TryParse(txtAlignMasterX.Text, out _modelParam[_nIdx].dAlignMasterX);
                    double.TryParse(txtAlignMasterY.Text, out _modelParam[_nIdx].dAlignMasterY);
                    double.TryParse(txtAlignMasterR.Text, out _modelParam[_nIdx].dAlignMasterR);
                    double.TryParse(txtAlignOffsetX.Text, out _modelParam[_nIdx].dAlignOffsetX);
                    double.TryParse(txtAlignOffsetY.Text, out _modelParam[_nIdx].dAlignOffsetY);
                    double.TryParse(txtAlignOffsetR.Text, out _modelParam[_nIdx].dAlignOffsetR);
                    double.TryParse(txtAlingUnit.Text, out _modelParam[_nIdx].dAlignUnit);
                    double.TryParse(txtResolution.Text, out _modelParam[_nIdx].dResoluton);

                    double.TryParse(txtWidthMin.Text, out _modelParam[_nIdx].dWidthMin);
                    double.TryParse(txtWidthMax.Text, out _modelParam[_nIdx].dWidthMax);
                    double.TryParse(txtHeightMin.Text, out _modelParam[_nIdx].dHeightMin);
                    double.TryParse(txtHeightMax.Text, out _modelParam[_nIdx].dHeightMax);
                    double.TryParse(txtMaxX.Text, out _modelParam[_nIdx].dMaxX);
                    double.TryParse(txtMaxY.Text, out _modelParam[_nIdx].dMaxY);

                    _modelParam[_nIdx].strPinMaster = txtPinMaster.Text;
                    _modelParam[_nIdx].strPinMasterResult = txtPinMasterResult.Text;
                    

                    _modelParam[_nIdx].strTriggerNo = txtTriggerNo.Text;
                    _modelParam[_nIdx].strLightNo = txtLightNo.Text;

                   

                    sql.SaveRecipe(_strProcName, _dbInfo, _nIdx, _strModelName, _modelParam[_nIdx]);

                    _frmMain._CAM[_nIdx].ModelChange(bChage);
                }
                else
                {
                    ModelParam modelParam = new ModelParam();

                    int.TryParse(txtGrabDelay.Text, out modelParam.nGrabdelay);
                    double.TryParse(txtExpose.Text, out modelParam.dExpose);
                    modelParam.strCode = lblCode.Text;
                    int.TryParse(txtDefectCnt.Text, out modelParam.nDefectCnt);
                    modelParam.strExposeInc = txtExposeIncrease.Text;
                    modelParam.bDefectInsp = swDefect.IsOn;
                    modelParam.bBCRInsp = swBCR.IsOn;
                    modelParam.bAlingInsp = swAlign.IsOn;
                    modelParam.strBCRData = txtBCRData.Text;
                    modelParam.strBCRLen = txtBCRLen.Text;
                    modelParam.bPinChange = swPin.IsOn;
                    modelParam.bDimens = swDimens.IsOn;
                    
                    modelParam.bAlignFormula = chkMathematical.Checked;

                    double.TryParse(txtCenterMass.Text, out modelParam.dCenterMass);
                    double.TryParse(txtAlignMasterX.Text, out modelParam.dAlignMasterX);
                    double.TryParse(txtAlignMasterY.Text, out modelParam.dAlignMasterY);
                    double.TryParse(txtAlignMasterR.Text, out modelParam.dAlignMasterR);
                    double.TryParse(txtAlignOffsetX.Text, out modelParam.dAlignOffsetX);
                    double.TryParse(txtAlignOffsetY.Text, out modelParam.dAlignOffsetY);
                    double.TryParse(txtAlignOffsetR.Text, out modelParam.dAlignOffsetR);
                    double.TryParse(txtAlingUnit.Text, out modelParam.dAlignUnit);
                    double.TryParse(txtResolution.Text, out modelParam.dResoluton);

                    double.TryParse(txtWidthMin.Text, out modelParam.dWidthMin);
                    double.TryParse(txtWidthMax.Text, out modelParam.dWidthMax);
                    double.TryParse(txtHeightMin.Text, out modelParam.dHeightMin);
                    double.TryParse(txtHeightMax.Text, out modelParam.dHeightMax);
                    double.TryParse(txtMaxX.Text, out modelParam.dMaxX);
                    double.TryParse(txtMaxY.Text, out modelParam.dMaxY);

                    modelParam.strPinMaster = txtPinMaster.Text;
                    modelParam.strPinMasterResult = txtPinMasterResult.Text;
                    

                    if (modelParam.listVIDIParam == null)
                        modelParam.listVIDIParam = new List<string>();

                    modelParam.listVIDIParam.Clear();
                    
                    modelParam.strTriggerNo = txtTriggerNo.Text;
                    modelParam.strLightNo = txtLightNo.Text;


                    sql.SaveRecipe(_strProcName, _dbInfo, _nIdx, _strModel, modelParam);
                }

                sql.Dispose();
            }
            catch
            {
                return false;
            }

            sql.Dispose();
            return true;
        }

        private void btnCode_Click(object sender, EventArgs e)
        {
            if (!fypnl.IsPopupOpen)
            {
                LoadCodeTable();

                fypnl.ShowBeakForm();
                //    StatusChange(GetCodeNo());
            }
            else
                fypnl.HideBeakForm();
        }

    }
}
