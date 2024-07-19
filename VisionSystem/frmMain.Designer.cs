using System;

namespace VisionSystem
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.tablePanel9 = new DevExpress.Utils.Layout.TablePanel();
            this.listAlarmMsg = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.listMsg = new DevComponents.DotNetBar.Controls.RichTextBoxEx();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::VisionSystem.WaitForm1), true, true);
            this.btnSetModel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetCam = new DevExpress.XtraEditors.SimpleButton();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.txtID = new DevExpress.XtraEditors.TextEdit();
            this.txtPW = new DevExpress.XtraEditors.TextEdit();
            this.txtUser = new DevExpress.XtraEditors.TextEdit();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.tablePanel14 = new DevExpress.Utils.Layout.TablePanel();
            this.btnIOSetting = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetting = new DevExpress.XtraEditors.SimpleButton();
            this.btnLightSetting = new DevExpress.XtraEditors.SimpleButton();
            this.bntSetComm = new DevExpress.XtraEditors.SimpleButton();
            this.bntRecord = new DevExpress.XtraEditors.SimpleButton();
            this.btnReset = new DevExpress.XtraEditors.SimpleButton();
            this.btnImgSet = new DevExpress.XtraEditors.SimpleButton();
            this.flyAdmin = new DevExpress.Utils.FlyoutPanel();
            this.lblMenu = new DevExpress.XtraEditors.LabelControl();
            this.tablePanel5 = new DevExpress.Utils.Layout.TablePanel();
            this.tablePanel12 = new DevExpress.Utils.Layout.TablePanel();
            this.Bar1 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.Bar2 = new DevComponents.DotNetBar.Controls.ProgressBarX();
            this.tablePanel11 = new DevExpress.Utils.Layout.TablePanel();
            this.lblModel = new DevExpress.XtraEditors.LabelControl();
            this.lblLotNo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl54 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl53 = new DevExpress.XtraEditors.LabelControl();
            this.tablePanel8 = new DevExpress.Utils.Layout.TablePanel();
            this.lblNGCnt = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalCnt = new DevExpress.XtraEditors.LabelControl();
            this.lblOKCnt = new DevExpress.XtraEditors.LabelControl();
            this.lblNGRate = new DevExpress.XtraEditors.LabelControl();
            this.lblOKRate = new DevExpress.XtraEditors.LabelControl();
            this.tablePanel7 = new DevExpress.Utils.Layout.TablePanel();
            this.btnLog = new DevExpress.XtraEditors.SimpleButton();
            this.btnMenu = new DevExpress.XtraEditors.SimpleButton();
            this.tablePanel10 = new DevExpress.Utils.Layout.TablePanel();
            this.lblLight = new DevExpress.XtraEditors.LabelControl();
            this.lblLic = new DevExpress.XtraEditors.LabelControl();
            this.lblPLC = new DevExpress.XtraEditors.LabelControl();
            this.lblIO = new DevExpress.XtraEditors.LabelControl();
            this.lblResult = new DevExpress.XtraEditors.LabelControl();
            this.lblView = new DevExpress.XtraEditors.LabelControl();
            this.flyImageSet = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl4 = new DevExpress.Utils.FlyoutPanelControl();
            this.labelControl23 = new DevExpress.XtraEditors.LabelControl();
            this.txtOriginImgRate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl24 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl21 = new DevExpress.XtraEditors.LabelControl();
            this.txtResultImgRate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl22 = new DevExpress.XtraEditors.LabelControl();
            this.toggleSwitch1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl91 = new DevExpress.XtraEditors.LabelControl();
            this.txtDiskAlarm = new DevExpress.XtraEditors.TextEdit();
            this.lblDiskusage = new DevExpress.XtraEditors.LabelControl();
            this.swAutoImageDelete = new DevExpress.XtraEditors.ToggleSwitch();
            this.lblautoImgdelete = new DevExpress.XtraEditors.LabelControl();
            this.ResetTimer = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl67 = new DevExpress.XtraEditors.LabelControl();
            this.btnOriginalDelete = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl65 = new DevExpress.XtraEditors.LabelControl();
            this.txtDiskDelete = new DevExpress.XtraEditors.TextEdit();
            this.btnResultDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveImagePath = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.radResultJPG = new System.Windows.Forms.RadioButton();
            this.radResultBMP = new System.Windows.Forms.RadioButton();
            this.labelControl14 = new DevExpress.XtraEditors.LabelControl();
            this.panelControl4 = new DevExpress.XtraEditors.PanelControl();
            this.radOriginJPG = new System.Windows.Forms.RadioButton();
            this.radOriginBMP = new System.Windows.Forms.RadioButton();
            this.btnImgpnlClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblOriginImgPath = new DevExpress.XtraEditors.LabelControl();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.swOriginSave = new DevExpress.XtraEditors.ToggleSwitch();
            this.lblOriginImgsave = new DevExpress.XtraEditors.LabelControl();
            this.txtSaveImagePath = new DevExpress.XtraEditors.TextEdit();
            this.lblOriginImgformat = new DevExpress.XtraEditors.LabelControl();
            this.swResultSave = new DevExpress.XtraEditors.ToggleSwitch();
            this.lblresultImgsave = new DevExpress.XtraEditors.LabelControl();
            this.lblresultImgformat = new DevExpress.XtraEditors.LabelControl();
            this.flyLog = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl5 = new DevExpress.Utils.FlyoutPanelControl();
            this.lblLog = new DevExpress.XtraEditors.LabelControl();
            this.flyLogin = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl2 = new DevExpress.Utils.FlyoutPanelControl();
            this.labelControl95 = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnChkPass = new DevExpress.XtraEditors.SimpleButton();
            this.lblPW = new DevExpress.XtraEditors.LabelControl();
            this.btnUserManage = new DevExpress.XtraEditors.SimpleButton();
            this.flyChangePW = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl3 = new DevExpress.Utils.FlyoutPanelControl();
            this.btnUserDel = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnPWClose = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl8 = new DevExpress.XtraEditors.GroupControl();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.btnUserEdit = new DevExpress.XtraEditors.SimpleButton();
            this.txtChangePW2 = new DevExpress.XtraEditors.TextEdit();
            this.lblReenterPW = new DevExpress.XtraEditors.LabelControl();
            this.txtChangePW1 = new DevExpress.XtraEditors.TextEdit();
            this.lblEnterPW = new DevExpress.XtraEditors.LabelControl();
            this.lblPass = new DevExpress.XtraEditors.LabelControl();
            this.flyCamCnt = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl7 = new DevExpress.Utils.FlyoutPanelControl();
            this.btnCamClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnCamAdd = new DevExpress.XtraEditors.SimpleButton();
            this.txtCamCnt = new DevExpress.XtraEditors.TextEdit();
            this.lblCamCnt = new DevExpress.XtraEditors.LabelControl();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.lblCurrent = new DevExpress.XtraEditors.LabelControl();
            this.lblPasswrod = new DevExpress.XtraEditors.LabelControl();
            this.labelControl19 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.flyResImg = new DevExpress.Utils.FlyoutPanel();
            this.btnPrevious = new DevExpress.XtraEditors.SimpleButton();
            this.btnNext = new DevExpress.XtraEditors.SimpleButton();
            this.btnListClose = new DevExpress.XtraEditors.SimpleButton();
            this.flyoutPanelControl9 = new DevExpress.Utils.FlyoutPanelControl();
            this.tablePanel3 = new DevExpress.Utils.Layout.TablePanel();
            this.cogDispOrigin = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDispResult = new Cognex.VisionPro.CogRecordDisplay();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl72 = new DevExpress.XtraEditors.LabelControl();
            this.txtProcName = new DevExpress.XtraEditors.TextEdit();
            this.flyImgList = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl8 = new DevExpress.Utils.FlyoutPanelControl();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.btnImgListClose = new DevExpress.XtraEditors.SimpleButton();
            this.pnlImage = new System.Windows.Forms.Panel();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.cogDisp1 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp2 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp3 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp4 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp5 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp6 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp7 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp8 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp9 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp10 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp11 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp12 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp13 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp14 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp15 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp16 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp17 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp18 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp19 = new Cognex.VisionPro.CogRecordDisplay();
            this.cogDisp20 = new Cognex.VisionPro.CogRecordDisplay();
            this.flySetting = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl14 = new DevExpress.Utils.FlyoutPanelControl();
            this.labelControl55 = new DevExpress.XtraEditors.LabelControl();
            this.lblDLpath = new DevExpress.XtraEditors.LabelControl();
            this.labelControl48 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl35 = new DevExpress.XtraEditors.LabelControl();
            this.txtLineInfo = new DevExpress.XtraEditors.TextEdit();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl14 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl92 = new DevExpress.XtraEditors.LabelControl();
            this.txtDBName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl96 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl101 = new DevExpress.XtraEditors.LabelControl();
            this.txtDBPW = new DevExpress.XtraEditors.TextEdit();
            this.txtDBPort = new DevExpress.XtraEditors.TextEdit();
            this.labelControl97 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl102 = new DevExpress.XtraEditors.LabelControl();
            this.txtDBID = new DevExpress.XtraEditors.TextEdit();
            this.txtDBIP = new DevExpress.XtraEditors.TextEdit();
            this.labelControl118 = new DevExpress.XtraEditors.LabelControl();
            this.btnSetClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSetSave = new DevExpress.XtraEditors.SimpleButton();
            this.flyIO = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl6 = new DevExpress.Utils.FlyoutPanelControl();
            this.groupControl7 = new DevExpress.XtraEditors.GroupControl();
            this.tablePanel4 = new DevExpress.Utils.Layout.TablePanel();
            this.lblOutStatus16 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus15 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus14 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus13 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus12 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus11 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus10 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus9 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus8 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus7 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus6 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus5 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus4 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus3 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus2 = new DevExpress.XtraEditors.LabelControl();
            this.lblOutStatus1 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_16 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_15 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_14 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_13 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_12 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_11 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_10 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_9 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_8 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_7 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_6 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_5 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_4 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_3 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_2 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOOUT_1 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus16 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus15 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus14 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus13 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus12 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus11 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus10 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus9 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus8 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus7 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus6 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus5 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus4 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus3 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus2 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_16 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_15 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_14 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_13 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_12 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_11 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_10 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_9 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_8 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_7 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_6 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_5 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_4 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_3 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_2 = new DevExpress.XtraEditors.LabelControl();
            this.lblInStatus1 = new DevExpress.XtraEditors.LabelControl();
            this.lblIOIN_1 = new DevExpress.XtraEditors.LabelControl();
            this.btnIOClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnIOSave = new DevExpress.XtraEditors.SimpleButton();
            this.groupControl6 = new DevExpress.XtraEditors.GroupControl();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl93 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOOutSount = new DevExpress.XtraEditors.TextEdit();
            this.labelControl46 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOOutAir2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl45 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOOutAir1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl42 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOOutLight = new DevExpress.XtraEditors.TextEdit();
            this.labelControl40 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOOutLampR = new DevExpress.XtraEditors.TextEdit();
            this.labelControl37 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOOutLampG = new DevExpress.XtraEditors.TextEdit();
            this.labelControl32 = new DevExpress.XtraEditors.LabelControl();
            this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
            this.txtIOInShutter2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl31 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOInShutter1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl30 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl39 = new DevExpress.XtraEditors.LabelControl();
            this.txtIOInStartSignal = new DevExpress.XtraEditors.TextEdit();
            this.txtIOInSensor = new DevExpress.XtraEditors.TextEdit();
            this.labelControl29 = new DevExpress.XtraEditors.LabelControl();
            this.cbIODev = new DevExpress.XtraEditors.ComboBoxEdit();
            this.toggleSwitch2 = new DevExpress.XtraEditors.ToggleSwitch();
            this.labelControl34 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit6 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl36 = new DevExpress.XtraEditors.LabelControl();
            this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
            this.labelControl38 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl41 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl44 = new DevExpress.XtraEditors.LabelControl();
            this.flyUserEdit = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl11 = new DevExpress.Utils.FlyoutPanelControl();
            this.labelControl33 = new DevExpress.XtraEditors.LabelControl();
            this.cbLevel = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblUser = new DevExpress.XtraEditors.LabelControl();
            this.lblMatch2 = new DevExpress.XtraEditors.LabelControl();
            this.btnUserEditClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnUserChk = new DevExpress.XtraEditors.SimpleButton();
            this.lblPassword = new DevExpress.XtraEditors.LabelControl();
            this.pnl = new System.Windows.Forms.Panel();
            this.flyList = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl12 = new DevExpress.Utils.FlyoutPanelControl();
            this.listModel = new DevExpress.XtraEditors.ListBoxControl();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar4 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.flyLight = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl15 = new DevExpress.Utils.FlyoutPanelControl();
            this.groupControl10 = new DevExpress.XtraEditors.GroupControl();
            this.txtChannelNo = new DevExpress.XtraEditors.TextEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cbPort_1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblLightConStatus1 = new DevExpress.XtraEditors.LabelControl();
            this.txtLightIP_1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl57 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl56 = new DevExpress.XtraEditors.LabelControl();
            this.cbBaud_1 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtLightPort_1 = new DevExpress.XtraEditors.TextEdit();
            this.chkLightUse4 = new DevExpress.XtraEditors.CheckEdit();
            this.chkLightUse3 = new DevExpress.XtraEditors.CheckEdit();
            this.chkLightUse2 = new DevExpress.XtraEditors.CheckEdit();
            this.chkLightUse1 = new DevExpress.XtraEditors.CheckEdit();
            this.radLightSerial = new System.Windows.Forms.RadioButton();
            this.radLightUDP = new System.Windows.Forms.RadioButton();
            this.labelControl52 = new DevExpress.XtraEditors.LabelControl();
            this.swOn4 = new DevExpress.XtraEditors.ToggleSwitch();
            this.swOn3 = new DevExpress.XtraEditors.ToggleSwitch();
            this.swOn2 = new DevExpress.XtraEditors.ToggleSwitch();
            this.barValue4 = new DevExpress.XtraEditors.TrackBarControl();
            this.txtValue4 = new DevExpress.XtraEditors.TextEdit();
            this.barValue3 = new DevExpress.XtraEditors.TrackBarControl();
            this.txtValue3 = new DevExpress.XtraEditors.TextEdit();
            this.barValue2 = new DevExpress.XtraEditors.TrackBarControl();
            this.txtValue2 = new DevExpress.XtraEditors.TextEdit();
            this.swOn1 = new DevExpress.XtraEditors.ToggleSwitch();
            this.barValue1 = new DevExpress.XtraEditors.TrackBarControl();
            this.txtValue1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl58 = new DevExpress.XtraEditors.LabelControl();
            this.btnLightClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnLightSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel9)).BeginInit();
            this.tablePanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel14)).BeginInit();
            this.tablePanel14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyAdmin)).BeginInit();
            this.flyAdmin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel5)).BeginInit();
            this.tablePanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel12)).BeginInit();
            this.tablePanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel11)).BeginInit();
            this.tablePanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel8)).BeginInit();
            this.tablePanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel7)).BeginInit();
            this.tablePanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel10)).BeginInit();
            this.tablePanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyImageSet)).BeginInit();
            this.flyImageSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl4)).BeginInit();
            this.flyoutPanelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginImgRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResultImgRate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiskAlarm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swAutoImageDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResetTimer.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiskDelete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).BeginInit();
            this.panelControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.swOriginSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaveImagePath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swResultSave.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyLog)).BeginInit();
            this.flyLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl5)).BeginInit();
            this.flyoutPanelControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyLogin)).BeginInit();
            this.flyLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl2)).BeginInit();
            this.flyoutPanelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyChangePW)).BeginInit();
            this.flyChangePW.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl3)).BeginInit();
            this.flyoutPanelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).BeginInit();
            this.groupControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChangePW2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChangePW1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyCamCnt)).BeginInit();
            this.flyCamCnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl7)).BeginInit();
            this.flyoutPanelControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamCnt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyResImg)).BeginInit();
            this.flyResImg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl9)).BeginInit();
            this.flyoutPanelControl9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel3)).BeginInit();
            this.tablePanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDispOrigin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDispResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyImgList)).BeginInit();
            this.flyImgList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl8)).BeginInit();
            this.flyoutPanelControl8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            this.pnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp11)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp12)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp14)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp15)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp17)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp19)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp20)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flySetting)).BeginInit();
            this.flySetting.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl14)).BeginInit();
            this.flyoutPanelControl14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtLineInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl14)).BeginInit();
            this.groupControl14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPW.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBID.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyIO)).BeginInit();
            this.flyIO.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl6)).BeginInit();
            this.flyoutPanelControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).BeginInit();
            this.groupControl7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel4)).BeginInit();
            this.tablePanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).BeginInit();
            this.groupControl6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutSount.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutAir2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutAir1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutLight.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutLampR.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutLampG.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
            this.groupControl5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInShutter2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInShutter1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInStartSignal.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInSensor.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIODev.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyUserEdit)).BeginInit();
            this.flyUserEdit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl11)).BeginInit();
            this.flyoutPanelControl11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbLevel.Properties)).BeginInit();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyList)).BeginInit();
            this.flyList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl12)).BeginInit();
            this.flyoutPanelControl12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listModel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyLight)).BeginInit();
            this.flyLight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl15)).BeginInit();
            this.flyoutPanelControl15.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).BeginInit();
            this.groupControl10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtChannelNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPort_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLightIP_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBaud_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLightPort_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel9
            // 
            this.tablePanel9.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 55F)});
            this.tablePanel9.Controls.Add(this.listAlarmMsg);
            this.tablePanel9.Controls.Add(this.labelControl1);
            this.tablePanel9.Controls.Add(this.pictureBox1);
            this.tablePanel9.Controls.Add(this.listMsg);
            this.tablePanel9.Controls.Add(this.labelControl3);
            this.tablePanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel9.Location = new System.Drawing.Point(2, 2);
            this.tablePanel9.Name = "tablePanel9";
            this.tablePanel9.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 29F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 29F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 75F)});
            this.tablePanel9.Size = new System.Drawing.Size(430, 1043);
            this.tablePanel9.TabIndex = 28;
            // 
            // listAlarmMsg
            // 
            this.listAlarmMsg.BackColorRichTextBox = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.listAlarmMsg.BackgroundStyle.Class = "RichTextBoxBorder";
            this.listAlarmMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tablePanel9.SetColumn(this.listAlarmMsg, 0);
            this.listAlarmMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listAlarmMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.listAlarmMsg.Location = new System.Drawing.Point(3, 516);
            this.listAlarmMsg.Name = "listAlarmMsg";
            this.tablePanel9.SetRow(this.listAlarmMsg, 3);
            this.listAlarmMsg.Size = new System.Drawing.Size(424, 449);
            this.listAlarmMsg.TabIndex = 27;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl1.Appearance.Options.UseBackColor = true;
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel9.SetColumn(this.labelControl1, 0);
            this.labelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl1.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl1.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl1.ImageOptions.SvgImage")));
            this.labelControl1.Location = new System.Drawing.Point(3, 487);
            this.labelControl1.Name = "labelControl1";
            this.tablePanel9.SetRow(this.labelControl1, 2);
            this.labelControl1.Size = new System.Drawing.Size(424, 23);
            this.labelControl1.TabIndex = 26;
            this.labelControl1.Text = "Alarm Message";
            this.labelControl1.DoubleClick += new System.EventHandler(this.labelControl1_DoubleClick);
            // 
            // pictureBox1
            // 
            this.tablePanel9.SetColumn(this.pictureBox1, 0);
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.pictureBox1.Location = new System.Drawing.Point(3, 978);
            this.pictureBox1.Name = "pictureBox1";
            this.tablePanel9.SetRow(this.pictureBox1, 4);
            this.pictureBox1.Size = new System.Drawing.Size(424, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 25;
            this.pictureBox1.TabStop = false;
            // 
            // listMsg
            // 
            this.listMsg.BackColorRichTextBox = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(40)))), ((int)(((byte)(45)))));
            // 
            // 
            // 
            this.listMsg.BackgroundStyle.Class = "RichTextBoxBorder";
            this.listMsg.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tablePanel9.SetColumn(this.listMsg, 0);
            this.listMsg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listMsg.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.listMsg.Location = new System.Drawing.Point(3, 32);
            this.listMsg.Name = "listMsg";
            this.tablePanel9.SetRow(this.listMsg, 1);
            this.listMsg.Size = new System.Drawing.Size(424, 449);
            this.listMsg.TabIndex = 22;
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl3.Appearance.Options.UseBackColor = true;
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Appearance.Options.UseForeColor = true;
            this.labelControl3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel9.SetColumn(this.labelControl3, 0);
            this.labelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl3.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl3.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl3.ImageOptions.SvgImage")));
            this.labelControl3.Location = new System.Drawing.Point(3, 3);
            this.labelControl3.Name = "labelControl3";
            this.tablePanel9.SetRow(this.labelControl3, 0);
            this.labelControl3.Size = new System.Drawing.Size(424, 23);
            this.labelControl3.TabIndex = 19;
            this.labelControl3.Text = "System Message";
            this.labelControl3.DoubleClick += new System.EventHandler(this.labelControl3_DoubleClick);
            // 
            // btnSetModel
            // 
            this.btnSetModel.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetModel.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.btnSetModel.Appearance.Options.UseFont = true;
            this.btnSetModel.Appearance.Options.UseForeColor = true;
            this.btnSetModel.Appearance.Options.UseTextOptions = true;
            this.btnSetModel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSetModel.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSetModel.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnSetModel.AppearanceHovered.Options.UseBackColor = true;
            this.btnSetModel.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.btnSetModel, 2);
            this.btnSetModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetModel.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetModel.ImageOptions.Image")));
            this.btnSetModel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSetModel.Location = new System.Drawing.Point(343, 3);
            this.btnSetModel.Name = "btnSetModel";
            this.tablePanel14.SetRow(this.btnSetModel, 0);
            this.btnSetModel.Size = new System.Drawing.Size(164, 49);
            this.btnSetModel.TabIndex = 6;
            this.btnSetModel.Text = "Model Setting";
            this.btnSetModel.ToolTip = "Model Setting";
            this.btnSetModel.Click += new System.EventHandler(this.btnSetModel_Click);
            // 
            // btnSetCam
            // 
            this.btnSetCam.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetCam.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.btnSetCam.Appearance.Options.UseFont = true;
            this.btnSetCam.Appearance.Options.UseForeColor = true;
            this.btnSetCam.Appearance.Options.UseTextOptions = true;
            this.btnSetCam.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSetCam.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSetCam.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnSetCam.AppearanceHovered.Options.UseBackColor = true;
            this.btnSetCam.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.btnSetCam, 1);
            this.btnSetCam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetCam.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSetCam.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSetCam.ImageOptions.SvgImage")));
            this.btnSetCam.Location = new System.Drawing.Point(173, 3);
            this.btnSetCam.Name = "btnSetCam";
            this.tablePanel14.SetRow(this.btnSetCam, 0);
            this.btnSetCam.Size = new System.Drawing.Size(164, 49);
            this.btnSetCam.TabIndex = 2;
            this.btnSetCam.Text = "Add Camera";
            this.btnSetCam.ToolTip = "Camera Setting";
            this.btnSetCam.Click += new System.EventHandler(this.btnSetCam_Click);
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            this.imageCollection1.Images.SetKeyName(0, "Gray.png");
            this.imageCollection1.Images.SetKeyName(1, "Green.png");
            this.imageCollection1.Images.SetKeyName(2, "Red.png");
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Orange;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(228, 22);
            this.txtID.Name = "txtID";
            this.txtID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtID.Properties.Appearance.Options.UseFont = true;
            this.txtID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtID.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Yellow;
            this.txtID.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtID.Size = new System.Drawing.Size(197, 30);
            this.txtID.TabIndex = 0;
            // 
            // txtPW
            // 
            this.txtPW.Location = new System.Drawing.Point(228, 61);
            this.txtPW.Name = "txtPW";
            this.txtPW.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPW.Properties.Appearance.Options.UseFont = true;
            this.txtPW.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPW.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPW.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Yellow;
            this.txtPW.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtPW.Properties.PasswordChar = '*';
            this.txtPW.Size = new System.Drawing.Size(197, 30);
            this.txtPW.TabIndex = 1;
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(142, 22);
            this.txtUser.Name = "txtUser";
            this.txtUser.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtUser.Properties.Appearance.Options.UseFont = true;
            this.txtUser.Properties.Appearance.Options.UseTextOptions = true;
            this.txtUser.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtUser.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Yellow;
            this.txtUser.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtUser.Size = new System.Drawing.Size(197, 30);
            this.txtUser.TabIndex = 49;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(142, 62);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtPassword.Properties.Appearance.Options.UseFont = true;
            this.txtPassword.Properties.Appearance.Options.UseTextOptions = true;
            this.txtPassword.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtPassword.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Yellow;
            this.txtPassword.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(197, 30);
            this.txtPassword.TabIndex = 1;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            this.txtPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPassword_KeyDown);
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.Controls.Add(this.tablePanel14);
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyAdmin;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(853, 114);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // tablePanel14
            // 
            this.tablePanel14.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel14.Controls.Add(this.btnIOSetting);
            this.tablePanel14.Controls.Add(this.btnSetting);
            this.tablePanel14.Controls.Add(this.btnLightSetting);
            this.tablePanel14.Controls.Add(this.bntSetComm);
            this.tablePanel14.Controls.Add(this.btnSetCam);
            this.tablePanel14.Controls.Add(this.bntRecord);
            this.tablePanel14.Controls.Add(this.btnReset);
            this.tablePanel14.Controls.Add(this.btnSetModel);
            this.tablePanel14.Controls.Add(this.btnImgSet);
            this.tablePanel14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel14.Location = new System.Drawing.Point(2, 2);
            this.tablePanel14.Name = "tablePanel14";
            this.tablePanel14.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel14.Size = new System.Drawing.Size(849, 110);
            this.tablePanel14.TabIndex = 25;
            // 
            // btnIOSetting
            // 
            this.btnIOSetting.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnIOSetting.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.btnIOSetting.Appearance.Options.UseFont = true;
            this.btnIOSetting.Appearance.Options.UseForeColor = true;
            this.btnIOSetting.Appearance.Options.UseTextOptions = true;
            this.btnIOSetting.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnIOSetting.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnIOSetting.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnIOSetting.AppearanceHovered.Options.UseBackColor = true;
            this.btnIOSetting.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.btnIOSetting, 1);
            this.btnIOSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIOSetting.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnIOSetting.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnIOSetting.ImageOptions.SvgImage")));
            this.btnIOSetting.Location = new System.Drawing.Point(173, 58);
            this.btnIOSetting.Name = "btnIOSetting";
            this.tablePanel14.SetRow(this.btnIOSetting, 1);
            this.btnIOSetting.Size = new System.Drawing.Size(164, 49);
            this.btnIOSetting.TabIndex = 11;
            this.btnIOSetting.Text = "I/O Setting";
            this.btnIOSetting.ToolTip = "historical data inquiry";
            this.btnIOSetting.Click += new System.EventHandler(this.btnIOSetting_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnSetting.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.btnSetting.Appearance.Options.UseFont = true;
            this.btnSetting.Appearance.Options.UseForeColor = true;
            this.btnSetting.Appearance.Options.UseTextOptions = true;
            this.btnSetting.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSetting.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnSetting.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnSetting.AppearanceHovered.Options.UseBackColor = true;
            this.btnSetting.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.btnSetting, 4);
            this.btnSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSetting.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSetting.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnSetting.ImageOptions.SvgImage")));
            this.btnSetting.Location = new System.Drawing.Point(682, 3);
            this.btnSetting.Name = "btnSetting";
            this.tablePanel14.SetRow(this.btnSetting, 0);
            this.btnSetting.Size = new System.Drawing.Size(164, 49);
            this.btnSetting.TabIndex = 10;
            this.btnSetting.Text = "Setting";
            this.btnSetting.ToolTip = "Setting";
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnLightSetting
            // 
            this.btnLightSetting.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnLightSetting.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.btnLightSetting.Appearance.Options.UseFont = true;
            this.btnLightSetting.Appearance.Options.UseForeColor = true;
            this.btnLightSetting.Appearance.Options.UseTextOptions = true;
            this.btnLightSetting.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLightSetting.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnLightSetting.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnLightSetting.AppearanceHovered.Options.UseBackColor = true;
            this.btnLightSetting.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.btnLightSetting, 0);
            this.btnLightSetting.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLightSetting.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLightSetting.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLightSetting.ImageOptions.SvgImage")));
            this.btnLightSetting.Location = new System.Drawing.Point(3, 58);
            this.btnLightSetting.Name = "btnLightSetting";
            this.tablePanel14.SetRow(this.btnLightSetting, 1);
            this.btnLightSetting.Size = new System.Drawing.Size(164, 49);
            this.btnLightSetting.TabIndex = 10;
            this.btnLightSetting.Text = "Light Setting";
            this.btnLightSetting.ToolTip = "Light Setting";
            this.btnLightSetting.Click += new System.EventHandler(this.btnLightSetting_Click);
            // 
            // bntSetComm
            // 
            this.bntSetComm.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntSetComm.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.bntSetComm.Appearance.Options.UseFont = true;
            this.bntSetComm.Appearance.Options.UseForeColor = true;
            this.bntSetComm.Appearance.Options.UseTextOptions = true;
            this.bntSetComm.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bntSetComm.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bntSetComm.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.bntSetComm.AppearanceHovered.Options.UseBackColor = true;
            this.bntSetComm.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.bntSetComm, 3);
            this.bntSetComm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bntSetComm.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.bntSetComm.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("bntSetComm.ImageOptions.SvgImage")));
            this.bntSetComm.Location = new System.Drawing.Point(512, 3);
            this.bntSetComm.Name = "bntSetComm";
            this.tablePanel14.SetRow(this.bntSetComm, 0);
            this.bntSetComm.Size = new System.Drawing.Size(164, 49);
            this.bntSetComm.TabIndex = 9;
            this.bntSetComm.Text = "Communication Setting";
            this.bntSetComm.ToolTip = "Communication Setting";
            this.bntSetComm.Click += new System.EventHandler(this.bntSetComm_Click);
            // 
            // bntRecord
            // 
            this.bntRecord.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.bntRecord.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.bntRecord.Appearance.Options.UseFont = true;
            this.bntRecord.Appearance.Options.UseForeColor = true;
            this.bntRecord.Appearance.Options.UseTextOptions = true;
            this.bntRecord.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.bntRecord.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.bntRecord.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.bntRecord.AppearanceHovered.Options.UseBackColor = true;
            this.bntRecord.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.bntRecord, 2);
            this.bntRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bntRecord.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("bntRecord.ImageOptions.Image")));
            this.bntRecord.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.bntRecord.Location = new System.Drawing.Point(343, 58);
            this.bntRecord.Name = "bntRecord";
            this.tablePanel14.SetRow(this.bntRecord, 1);
            this.bntRecord.Size = new System.Drawing.Size(164, 49);
            this.bntRecord.TabIndex = 2;
            this.bntRecord.Text = "Record";
            this.bntRecord.ToolTip = "historical data inquiry";
            this.bntRecord.Click += new System.EventHandler(this.bntRecord_Click);
            // 
            // btnReset
            // 
            this.btnReset.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnReset.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.btnReset.Appearance.Options.UseFont = true;
            this.btnReset.Appearance.Options.UseForeColor = true;
            this.btnReset.Appearance.Options.UseTextOptions = true;
            this.btnReset.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnReset.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnReset.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnReset.AppearanceHovered.Options.UseBackColor = true;
            this.btnReset.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.btnReset, 0);
            this.btnReset.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReset.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnReset.ImageOptions.Image")));
            this.btnReset.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnReset.Location = new System.Drawing.Point(3, 3);
            this.btnReset.Name = "btnReset";
            this.tablePanel14.SetRow(this.btnReset, 0);
            this.btnReset.Size = new System.Drawing.Size(164, 49);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "RESET";
            this.btnReset.ToolTip = "Screen and count initialization";
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // btnImgSet
            // 
            this.btnImgSet.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.btnImgSet.Appearance.ForeColor = DevExpress.LookAndFeel.DXSkinColors.ForeColors.Information;
            this.btnImgSet.Appearance.Options.UseFont = true;
            this.btnImgSet.Appearance.Options.UseForeColor = true;
            this.btnImgSet.Appearance.Options.UseTextOptions = true;
            this.btnImgSet.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnImgSet.AppearanceHovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnImgSet.AppearanceHovered.ForeColor = System.Drawing.Color.White;
            this.btnImgSet.AppearanceHovered.Options.UseBackColor = true;
            this.btnImgSet.AppearanceHovered.Options.UseForeColor = true;
            this.tablePanel14.SetColumn(this.btnImgSet, 3);
            this.btnImgSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImgSet.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnImgSet.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnImgSet.ImageOptions.SvgImage")));
            this.btnImgSet.Location = new System.Drawing.Point(512, 58);
            this.btnImgSet.Name = "btnImgSet";
            this.tablePanel14.SetRow(this.btnImgSet, 1);
            this.btnImgSet.Size = new System.Drawing.Size(164, 49);
            this.btnImgSet.TabIndex = 6;
            this.btnImgSet.Text = "Save Image Settings";
            this.btnImgSet.ToolTip = "Save Image Settings";
            this.btnImgSet.Click += new System.EventHandler(this.btnImgSet_Click);
            // 
            // flyAdmin
            // 
            this.flyAdmin.AutoSize = true;
            this.flyAdmin.Controls.Add(this.flyoutPanelControl1);
            this.flyAdmin.Location = new System.Drawing.Point(20, 127);
            this.flyAdmin.Name = "flyAdmin";
            this.flyAdmin.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyAdmin.Options.CloseOnHidingOwner = false;
            this.flyAdmin.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyAdmin.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyAdmin.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyAdmin.OwnerControl = this.lblMenu;
            this.flyAdmin.Size = new System.Drawing.Size(853, 114);
            this.flyAdmin.TabIndex = 21;
            // 
            // lblMenu
            // 
            this.lblMenu.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblMenu.Location = new System.Drawing.Point(0, 132);
            this.lblMenu.Name = "lblMenu";
            this.lblMenu.Size = new System.Drawing.Size(1443, 0);
            this.lblMenu.TabIndex = 166;
            // 
            // tablePanel5
            // 
            this.tablePanel5.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 300F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 180F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 100F)});
            this.tablePanel5.Controls.Add(this.tablePanel12);
            this.tablePanel5.Controls.Add(this.tablePanel11);
            this.tablePanel5.Controls.Add(this.tablePanel8);
            this.tablePanel5.Controls.Add(this.tablePanel7);
            this.tablePanel5.Controls.Add(this.tablePanel10);
            this.tablePanel5.Controls.Add(this.lblResult);
            this.tablePanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel5.Location = new System.Drawing.Point(0, 0);
            this.tablePanel5.Name = "tablePanel5";
            this.tablePanel5.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel5.Size = new System.Drawing.Size(1443, 107);
            this.tablePanel5.TabIndex = 0;
            // 
            // tablePanel12
            // 
            this.tablePanel5.SetColumn(this.tablePanel12, 1);
            this.tablePanel12.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel12.Controls.Add(this.Bar1);
            this.tablePanel12.Controls.Add(this.Bar2);
            this.tablePanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel12.Location = new System.Drawing.Point(566, 3);
            this.tablePanel12.Name = "tablePanel12";
            this.tablePanel5.SetRow(this.tablePanel12, 0);
            this.tablePanel12.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel12.Size = new System.Drawing.Size(194, 101);
            this.tablePanel12.TabIndex = 6;
            // 
            // Bar1
            // 
            // 
            // 
            // 
            this.Bar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tablePanel12.SetColumn(this.Bar1, 0);
            this.Bar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bar1.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bar1.Location = new System.Drawing.Point(3, 3);
            this.Bar1.Name = "Bar1";
            this.tablePanel12.SetRow(this.Bar1, 0);
            this.Bar1.Size = new System.Drawing.Size(188, 45);
            this.Bar1.TabIndex = 4;
            this.Bar1.Text = "D : 0.0%";
            this.Bar1.TextVisible = true;
            this.Bar1.Visible = false;
            // 
            // Bar2
            // 
            // 
            // 
            // 
            this.Bar2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.tablePanel12.SetColumn(this.Bar2, 0);
            this.Bar2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Bar2.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Bar2.Location = new System.Drawing.Point(3, 54);
            this.Bar2.Name = "Bar2";
            this.tablePanel12.SetRow(this.Bar2, 1);
            this.Bar2.Size = new System.Drawing.Size(188, 44);
            this.Bar2.TabIndex = 3;
            this.Bar2.Text = "D : 0.0%";
            this.Bar2.TextVisible = true;
            this.Bar2.Visible = false;
            // 
            // tablePanel11
            // 
            this.tablePanel5.SetColumn(this.tablePanel11, 0);
            this.tablePanel11.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 110F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 444F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel11.Controls.Add(this.lblModel);
            this.tablePanel11.Controls.Add(this.lblLotNo);
            this.tablePanel11.Controls.Add(this.labelControl54);
            this.tablePanel11.Controls.Add(this.labelControl53);
            this.tablePanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel11.Location = new System.Drawing.Point(3, 3);
            this.tablePanel11.Name = "tablePanel11";
            this.tablePanel5.SetRow(this.tablePanel11, 0);
            this.tablePanel11.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel11.Size = new System.Drawing.Size(557, 101);
            this.tablePanel11.TabIndex = 5;
            // 
            // lblModel
            // 
            this.lblModel.Appearance.Font = new System.Drawing.Font("Tahoma", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblModel.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblModel.Appearance.Options.UseFont = true;
            this.lblModel.Appearance.Options.UseForeColor = true;
            this.lblModel.Appearance.Options.UseTextOptions = true;
            this.lblModel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblModel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel11.SetColumn(this.lblModel, 1);
            this.lblModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblModel.Location = new System.Drawing.Point(113, 3);
            this.lblModel.Name = "lblModel";
            this.tablePanel11.SetRow(this.lblModel, 0);
            this.lblModel.Size = new System.Drawing.Size(438, 45);
            this.lblModel.TabIndex = 3;
            this.lblModel.Text = "-";
            this.lblModel.Click += new System.EventHandler(this.lblModel_Click);
            // 
            // lblLotNo
            // 
            this.lblLotNo.Appearance.Font = new System.Drawing.Font("Tahoma", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLotNo.Appearance.ForeColor = System.Drawing.Color.Yellow;
            this.lblLotNo.Appearance.Options.UseFont = true;
            this.lblLotNo.Appearance.Options.UseForeColor = true;
            this.lblLotNo.Appearance.Options.UseTextOptions = true;
            this.lblLotNo.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblLotNo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel11.SetColumn(this.lblLotNo, 1);
            this.lblLotNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLotNo.Location = new System.Drawing.Point(113, 54);
            this.lblLotNo.Name = "lblLotNo";
            this.tablePanel11.SetRow(this.lblLotNo, 1);
            this.lblLotNo.Size = new System.Drawing.Size(438, 44);
            this.lblLotNo.TabIndex = 2;
            this.lblLotNo.Text = "-";
            // 
            // labelControl54
            // 
            this.labelControl54.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl54.Appearance.Options.UseFont = true;
            this.labelControl54.Appearance.Options.UseTextOptions = true;
            this.labelControl54.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl54.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel11.SetColumn(this.labelControl54, 0);
            this.labelControl54.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl54.Location = new System.Drawing.Point(3, 54);
            this.labelControl54.Name = "labelControl54";
            this.tablePanel11.SetRow(this.labelControl54, 1);
            this.labelControl54.Size = new System.Drawing.Size(104, 44);
            this.labelControl54.TabIndex = 1;
            this.labelControl54.Text = "LOT NO : ";
            // 
            // labelControl53
            // 
            this.labelControl53.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl53.Appearance.Options.UseFont = true;
            this.labelControl53.Appearance.Options.UseTextOptions = true;
            this.labelControl53.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl53.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel11.SetColumn(this.labelControl53, 0);
            this.labelControl53.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl53.Location = new System.Drawing.Point(3, 3);
            this.labelControl53.Name = "labelControl53";
            this.tablePanel11.SetRow(this.labelControl53, 0);
            this.labelControl53.Size = new System.Drawing.Size(104, 45);
            this.labelControl53.TabIndex = 0;
            this.labelControl53.Text = "MODEL : ";
            // 
            // tablePanel8
            // 
            this.tablePanel5.SetColumn(this.tablePanel8, 4);
            this.tablePanel8.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel8.Controls.Add(this.lblNGCnt);
            this.tablePanel8.Controls.Add(this.lblTotalCnt);
            this.tablePanel8.Controls.Add(this.lblOKCnt);
            this.tablePanel8.Controls.Add(this.lblNGRate);
            this.tablePanel8.Controls.Add(this.lblOKRate);
            this.tablePanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel8.Location = new System.Drawing.Point(1166, 3);
            this.tablePanel8.Name = "tablePanel8";
            this.tablePanel5.SetRow(this.tablePanel8, 0);
            this.tablePanel8.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel8.Size = new System.Drawing.Size(174, 101);
            this.tablePanel8.TabIndex = 3;
            // 
            // lblNGCnt
            // 
            this.lblNGCnt.Appearance.BackColor = System.Drawing.Color.Red;
            this.lblNGCnt.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNGCnt.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblNGCnt.Appearance.Options.UseBackColor = true;
            this.lblNGCnt.Appearance.Options.UseFont = true;
            this.lblNGCnt.Appearance.Options.UseForeColor = true;
            this.lblNGCnt.Appearance.Options.UseTextOptions = true;
            this.lblNGCnt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblNGCnt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel8.SetColumn(this.lblNGCnt, 0);
            this.lblNGCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNGCnt.Location = new System.Drawing.Point(3, 71);
            this.lblNGCnt.Name = "lblNGCnt";
            this.tablePanel8.SetRow(this.lblNGCnt, 2);
            this.lblNGCnt.Size = new System.Drawing.Size(81, 27);
            this.lblNGCnt.TabIndex = 5;
            this.lblNGCnt.Text = "0";
            // 
            // lblTotalCnt
            // 
            this.lblTotalCnt.Appearance.BackColor = System.Drawing.Color.White;
            this.lblTotalCnt.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCnt.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblTotalCnt.Appearance.Options.UseBackColor = true;
            this.lblTotalCnt.Appearance.Options.UseFont = true;
            this.lblTotalCnt.Appearance.Options.UseForeColor = true;
            this.lblTotalCnt.Appearance.Options.UseTextOptions = true;
            this.lblTotalCnt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotalCnt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel8.SetColumn(this.lblTotalCnt, 0);
            this.lblTotalCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalCnt.Location = new System.Drawing.Point(3, 3);
            this.lblTotalCnt.Name = "lblTotalCnt";
            this.tablePanel8.SetRow(this.lblTotalCnt, 0);
            this.lblTotalCnt.Size = new System.Drawing.Size(81, 28);
            this.lblTotalCnt.TabIndex = 3;
            this.lblTotalCnt.Text = "0";
            // 
            // lblOKCnt
            // 
            this.lblOKCnt.Appearance.BackColor = System.Drawing.Color.Lime;
            this.lblOKCnt.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOKCnt.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblOKCnt.Appearance.Options.UseBackColor = true;
            this.lblOKCnt.Appearance.Options.UseFont = true;
            this.lblOKCnt.Appearance.Options.UseForeColor = true;
            this.lblOKCnt.Appearance.Options.UseTextOptions = true;
            this.lblOKCnt.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOKCnt.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel8.SetColumn(this.lblOKCnt, 0);
            this.lblOKCnt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOKCnt.Location = new System.Drawing.Point(3, 37);
            this.lblOKCnt.Name = "lblOKCnt";
            this.tablePanel8.SetRow(this.lblOKCnt, 1);
            this.lblOKCnt.Size = new System.Drawing.Size(81, 28);
            this.lblOKCnt.TabIndex = 4;
            this.lblOKCnt.Text = "0";
            // 
            // lblNGRate
            // 
            this.lblNGRate.Appearance.BackColor = System.Drawing.Color.Red;
            this.lblNGRate.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNGRate.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblNGRate.Appearance.Options.UseBackColor = true;
            this.lblNGRate.Appearance.Options.UseFont = true;
            this.lblNGRate.Appearance.Options.UseForeColor = true;
            this.lblNGRate.Appearance.Options.UseTextOptions = true;
            this.lblNGRate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblNGRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel8.SetColumn(this.lblNGRate, 1);
            this.lblNGRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblNGRate.Location = new System.Drawing.Point(90, 71);
            this.lblNGRate.Name = "lblNGRate";
            this.tablePanel8.SetRow(this.lblNGRate, 2);
            this.lblNGRate.Size = new System.Drawing.Size(81, 27);
            this.lblNGRate.TabIndex = 2;
            this.lblNGRate.Text = "0.0%";
            // 
            // lblOKRate
            // 
            this.lblOKRate.Appearance.BackColor = System.Drawing.Color.Lime;
            this.lblOKRate.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOKRate.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblOKRate.Appearance.Options.UseBackColor = true;
            this.lblOKRate.Appearance.Options.UseFont = true;
            this.lblOKRate.Appearance.Options.UseForeColor = true;
            this.lblOKRate.Appearance.Options.UseTextOptions = true;
            this.lblOKRate.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOKRate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel8.SetColumn(this.lblOKRate, 1);
            this.lblOKRate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOKRate.Location = new System.Drawing.Point(90, 37);
            this.lblOKRate.Name = "lblOKRate";
            this.tablePanel8.SetRow(this.lblOKRate, 1);
            this.lblOKRate.Size = new System.Drawing.Size(81, 28);
            this.lblOKRate.TabIndex = 1;
            this.lblOKRate.Text = "0.0%";
            // 
            // tablePanel7
            // 
            this.tablePanel5.SetColumn(this.tablePanel7, 5);
            this.tablePanel7.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel7.Controls.Add(this.btnLog);
            this.tablePanel7.Controls.Add(this.btnMenu);
            this.tablePanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel7.Location = new System.Drawing.Point(1346, 3);
            this.tablePanel7.Name = "tablePanel7";
            this.tablePanel5.SetRow(this.tablePanel7, 0);
            this.tablePanel7.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel7.Size = new System.Drawing.Size(94, 101);
            this.tablePanel7.TabIndex = 2;
            // 
            // btnLog
            // 
            this.btnLog.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLog.Appearance.Options.UseFont = true;
            this.tablePanel7.SetColumn(this.btnLog, 0);
            this.btnLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnLog.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLog.ImageOptions.ImageUri.Uri = "outlook%20inspired/glyph_message";
            this.btnLog.Location = new System.Drawing.Point(3, 54);
            this.btnLog.Name = "btnLog";
            this.tablePanel7.SetRow(this.btnLog, 1);
            this.btnLog.Size = new System.Drawing.Size(88, 44);
            this.btnLog.TabIndex = 2;
            this.btnLog.Text = "LOG";
            this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
            // 
            // btnMenu
            // 
            this.btnMenu.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMenu.Appearance.Options.UseFont = true;
            this.tablePanel7.SetColumn(this.btnMenu, 0);
            this.btnMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnMenu.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnMenu.ImageOptions.ImageUri.Uri = "pdf%20viewer/menu";
            this.btnMenu.Location = new System.Drawing.Point(3, 3);
            this.btnMenu.Name = "btnMenu";
            this.tablePanel7.SetRow(this.btnMenu, 0);
            this.btnMenu.Size = new System.Drawing.Size(88, 45);
            this.btnMenu.TabIndex = 1;
            this.btnMenu.Text = "MENU";
            this.btnMenu.Click += new System.EventHandler(this.btnMenu_Click);
            // 
            // tablePanel10
            // 
            this.tablePanel5.SetColumn(this.tablePanel10, 2);
            this.tablePanel10.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel10.Controls.Add(this.lblLight);
            this.tablePanel10.Controls.Add(this.lblLic);
            this.tablePanel10.Controls.Add(this.lblPLC);
            this.tablePanel10.Controls.Add(this.lblIO);
            this.tablePanel10.Location = new System.Drawing.Point(766, 3);
            this.tablePanel10.Name = "tablePanel10";
            this.tablePanel5.SetRow(this.tablePanel10, 2);
            this.tablePanel10.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel10.Size = new System.Drawing.Size(294, 101);
            this.tablePanel10.TabIndex = 4;
            // 
            // lblLight
            // 
            this.lblLight.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblLight.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLight.Appearance.Options.UseBackColor = true;
            this.lblLight.Appearance.Options.UseFont = true;
            this.lblLight.Appearance.Options.UseTextOptions = true;
            this.lblLight.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLight.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblLight.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblLight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel10.SetColumn(this.lblLight, 1);
            this.lblLight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLight.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblLight.Location = new System.Drawing.Point(150, 54);
            this.lblLight.Name = "lblLight";
            this.tablePanel10.SetRow(this.lblLight, 1);
            this.lblLight.Size = new System.Drawing.Size(141, 44);
            this.lblLight.TabIndex = 4;
            this.lblLight.Text = "LIGHT";
            // 
            // lblLic
            // 
            this.lblLic.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblLic.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLic.Appearance.Options.UseBackColor = true;
            this.lblLic.Appearance.Options.UseFont = true;
            this.lblLic.Appearance.Options.UseTextOptions = true;
            this.lblLic.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLic.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblLic.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel10.SetColumn(this.lblLic, 0);
            this.lblLic.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblLic.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblLic.Location = new System.Drawing.Point(3, 3);
            this.lblLic.Name = "lblLic";
            this.tablePanel10.SetRow(this.lblLic, 0);
            this.lblLic.Size = new System.Drawing.Size(141, 45);
            this.lblLic.TabIndex = 0;
            this.lblLic.Text = "LICENSE";
            this.lblLic.Visible = false;
            // 
            // lblPLC
            // 
            this.lblPLC.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblPLC.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPLC.Appearance.Options.UseBackColor = true;
            this.lblPLC.Appearance.Options.UseFont = true;
            this.lblPLC.Appearance.Options.UseTextOptions = true;
            this.lblPLC.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblPLC.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblPLC.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblPLC.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel10.SetColumn(this.lblPLC, 0);
            this.lblPLC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPLC.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.TopCenter;
            this.lblPLC.Location = new System.Drawing.Point(3, 54);
            this.lblPLC.Name = "lblPLC";
            this.tablePanel10.SetRow(this.lblPLC, 1);
            this.lblPLC.Size = new System.Drawing.Size(141, 44);
            this.lblPLC.TabIndex = 1;
            this.lblPLC.Text = "PLC";
            this.lblPLC.Visible = false;
            // 
            // lblIO
            // 
            this.lblIO.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblIO.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIO.Appearance.Options.UseBackColor = true;
            this.lblIO.Appearance.Options.UseFont = true;
            this.lblIO.Appearance.Options.UseTextOptions = true;
            this.lblIO.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIO.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblIO.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel10.SetColumn(this.lblIO, 1);
            this.lblIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIO.Location = new System.Drawing.Point(150, 3);
            this.lblIO.Name = "lblIO";
            this.tablePanel10.SetRow(this.lblIO, 0);
            this.lblIO.Size = new System.Drawing.Size(141, 45);
            this.lblIO.TabIndex = 3;
            this.lblIO.Text = "I/O";
            this.lblIO.Visible = false;
            // 
            // lblResult
            // 
            this.lblResult.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblResult.Appearance.Font = new System.Drawing.Font("Tahoma", 45F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblResult.Appearance.Options.UseBackColor = true;
            this.lblResult.Appearance.Options.UseFont = true;
            this.lblResult.Appearance.Options.UseTextOptions = true;
            this.lblResult.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblResult.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel5.SetColumn(this.lblResult, 3);
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Location = new System.Drawing.Point(1066, 3);
            this.lblResult.Name = "lblResult";
            this.tablePanel5.SetRow(this.lblResult, 0);
            this.lblResult.Size = new System.Drawing.Size(94, 101);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "-";
            // 
            // lblView
            // 
            this.lblView.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.lblView.Appearance.Options.UseForeColor = true;
            this.lblView.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblView.Location = new System.Drawing.Point(1159, 41);
            this.lblView.Name = "lblView";
            this.lblView.Size = new System.Drawing.Size(443, 0);
            this.lblView.TabIndex = 58;
            // 
            // flyImageSet
            // 
            this.flyImageSet.AutoSize = true;
            this.flyImageSet.Controls.Add(this.flyoutPanelControl4);
            this.flyImageSet.Location = new System.Drawing.Point(1057, 187);
            this.flyImageSet.Name = "flyImageSet";
            this.flyImageSet.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyImageSet.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyImageSet.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyImageSet.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyImageSet.OwnerControl = this.btnImgSet;
            this.flyImageSet.Size = new System.Drawing.Size(672, 385);
            this.flyImageSet.TabIndex = 41;
            // 
            // flyoutPanelControl4
            // 
            this.flyoutPanelControl4.Controls.Add(this.labelControl23);
            this.flyoutPanelControl4.Controls.Add(this.txtOriginImgRate);
            this.flyoutPanelControl4.Controls.Add(this.labelControl24);
            this.flyoutPanelControl4.Controls.Add(this.labelControl21);
            this.flyoutPanelControl4.Controls.Add(this.txtResultImgRate);
            this.flyoutPanelControl4.Controls.Add(this.labelControl22);
            this.flyoutPanelControl4.Controls.Add(this.toggleSwitch1);
            this.flyoutPanelControl4.Controls.Add(this.labelControl91);
            this.flyoutPanelControl4.Controls.Add(this.txtDiskAlarm);
            this.flyoutPanelControl4.Controls.Add(this.lblDiskusage);
            this.flyoutPanelControl4.Controls.Add(this.swAutoImageDelete);
            this.flyoutPanelControl4.Controls.Add(this.lblautoImgdelete);
            this.flyoutPanelControl4.Controls.Add(this.ResetTimer);
            this.flyoutPanelControl4.Controls.Add(this.labelControl67);
            this.flyoutPanelControl4.Controls.Add(this.btnOriginalDelete);
            this.flyoutPanelControl4.Controls.Add(this.labelControl65);
            this.flyoutPanelControl4.Controls.Add(this.txtDiskDelete);
            this.flyoutPanelControl4.Controls.Add(this.btnResultDelete);
            this.flyoutPanelControl4.Controls.Add(this.btnSaveImagePath);
            this.flyoutPanelControl4.Controls.Add(this.panelControl3);
            this.flyoutPanelControl4.Controls.Add(this.labelControl14);
            this.flyoutPanelControl4.Controls.Add(this.panelControl4);
            this.flyoutPanelControl4.Controls.Add(this.btnImgpnlClose);
            this.flyoutPanelControl4.Controls.Add(this.lblOriginImgPath);
            this.flyoutPanelControl4.Controls.Add(this.btnSave);
            this.flyoutPanelControl4.Controls.Add(this.swOriginSave);
            this.flyoutPanelControl4.Controls.Add(this.lblOriginImgsave);
            this.flyoutPanelControl4.Controls.Add(this.txtSaveImagePath);
            this.flyoutPanelControl4.Controls.Add(this.lblOriginImgformat);
            this.flyoutPanelControl4.Controls.Add(this.swResultSave);
            this.flyoutPanelControl4.Controls.Add(this.lblresultImgsave);
            this.flyoutPanelControl4.Controls.Add(this.lblresultImgformat);
            this.flyoutPanelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl4.FlyoutPanel = this.flyImageSet;
            this.flyoutPanelControl4.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl4.Name = "flyoutPanelControl4";
            this.flyoutPanelControl4.Size = new System.Drawing.Size(672, 385);
            this.flyoutPanelControl4.TabIndex = 0;
            // 
            // labelControl23
            // 
            this.labelControl23.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl23.Appearance.Options.UseFont = true;
            this.labelControl23.Location = new System.Drawing.Point(344, 142);
            this.labelControl23.Name = "labelControl23";
            this.labelControl23.Size = new System.Drawing.Size(18, 18);
            this.labelControl23.TabIndex = 45;
            this.labelControl23.Text = "%";
            // 
            // txtOriginImgRate
            // 
            this.txtOriginImgRate.Location = new System.Drawing.Point(238, 140);
            this.txtOriginImgRate.Name = "txtOriginImgRate";
            this.txtOriginImgRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtOriginImgRate.Properties.Appearance.Options.UseFont = true;
            this.txtOriginImgRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtOriginImgRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtOriginImgRate.Size = new System.Drawing.Size(100, 24);
            this.txtOriginImgRate.TabIndex = 44;
            // 
            // labelControl24
            // 
            this.labelControl24.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl24.Appearance.Options.UseFont = true;
            this.labelControl24.Appearance.Options.UseTextOptions = true;
            this.labelControl24.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl24.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl24.Location = new System.Drawing.Point(11, 142);
            this.labelControl24.Name = "labelControl24";
            this.labelControl24.Size = new System.Drawing.Size(220, 19);
            this.labelControl24.TabIndex = 43;
            this.labelControl24.Text = "Origin Image compression : ";
            // 
            // labelControl21
            // 
            this.labelControl21.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl21.Appearance.Options.UseFont = true;
            this.labelControl21.Location = new System.Drawing.Point(345, 250);
            this.labelControl21.Name = "labelControl21";
            this.labelControl21.Size = new System.Drawing.Size(18, 18);
            this.labelControl21.TabIndex = 42;
            this.labelControl21.Text = "%";
            // 
            // txtResultImgRate
            // 
            this.txtResultImgRate.Location = new System.Drawing.Point(239, 247);
            this.txtResultImgRate.Name = "txtResultImgRate";
            this.txtResultImgRate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtResultImgRate.Properties.Appearance.Options.UseFont = true;
            this.txtResultImgRate.Properties.Appearance.Options.UseTextOptions = true;
            this.txtResultImgRate.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtResultImgRate.Size = new System.Drawing.Size(100, 24);
            this.txtResultImgRate.TabIndex = 41;
            // 
            // labelControl22
            // 
            this.labelControl22.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl22.Appearance.Options.UseFont = true;
            this.labelControl22.Appearance.Options.UseTextOptions = true;
            this.labelControl22.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl22.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl22.Location = new System.Drawing.Point(12, 250);
            this.labelControl22.Name = "labelControl22";
            this.labelControl22.Size = new System.Drawing.Size(220, 19);
            this.labelControl22.TabIndex = 40;
            this.labelControl22.Text = "Result Image compression : ";
            // 
            // toggleSwitch1
            // 
            this.toggleSwitch1.Location = new System.Drawing.Point(817, 449);
            this.toggleSwitch1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toggleSwitch1.Name = "toggleSwitch1";
            this.toggleSwitch1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.toggleSwitch1.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitch1.Properties.OffText = "Off";
            this.toggleSwitch1.Properties.OnText = "On";
            this.toggleSwitch1.Size = new System.Drawing.Size(109, 19);
            this.toggleSwitch1.TabIndex = 39;
            this.toggleSwitch1.Visible = false;
            // 
            // labelControl91
            // 
            this.labelControl91.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl91.Appearance.Options.UseFont = true;
            this.labelControl91.Location = new System.Drawing.Point(830, 414);
            this.labelControl91.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl91.Name = "labelControl91";
            this.labelControl91.Size = new System.Drawing.Size(18, 18);
            this.labelControl91.TabIndex = 38;
            this.labelControl91.Text = "%";
            this.labelControl91.Visible = false;
            // 
            // txtDiskAlarm
            // 
            this.txtDiskAlarm.Location = new System.Drawing.Point(710, 411);
            this.txtDiskAlarm.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiskAlarm.Name = "txtDiskAlarm";
            this.txtDiskAlarm.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDiskAlarm.Properties.Appearance.Options.UseFont = true;
            this.txtDiskAlarm.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDiskAlarm.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDiskAlarm.Size = new System.Drawing.Size(114, 24);
            this.txtDiskAlarm.TabIndex = 37;
            this.txtDiskAlarm.Visible = false;
            // 
            // lblDiskusage
            // 
            this.lblDiskusage.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDiskusage.Appearance.Options.UseFont = true;
            this.lblDiskusage.Appearance.Options.UseTextOptions = true;
            this.lblDiskusage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblDiskusage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDiskusage.Location = new System.Drawing.Point(474, 410);
            this.lblDiskusage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblDiskusage.Name = "lblDiskusage";
            this.lblDiskusage.Size = new System.Drawing.Size(230, 25);
            this.lblDiskusage.TabIndex = 36;
            this.lblDiskusage.Text = "Disk capacity Rate :";
            this.lblDiskusage.Visible = false;
            // 
            // swAutoImageDelete
            // 
            this.swAutoImageDelete.Location = new System.Drawing.Point(238, 285);
            this.swAutoImageDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.swAutoImageDelete.Name = "swAutoImageDelete";
            this.swAutoImageDelete.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.swAutoImageDelete.Properties.Appearance.Options.UseFont = true;
            this.swAutoImageDelete.Properties.OffText = "Off";
            this.swAutoImageDelete.Properties.OnText = "On";
            this.swAutoImageDelete.Size = new System.Drawing.Size(87, 19);
            this.swAutoImageDelete.TabIndex = 34;
            // 
            // lblautoImgdelete
            // 
            this.lblautoImgdelete.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblautoImgdelete.Appearance.Options.UseFont = true;
            this.lblautoImgdelete.Appearance.Options.UseTextOptions = true;
            this.lblautoImgdelete.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblautoImgdelete.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblautoImgdelete.Location = new System.Drawing.Point(0, 280);
            this.lblautoImgdelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblautoImgdelete.Name = "lblautoImgdelete";
            this.lblautoImgdelete.Size = new System.Drawing.Size(230, 25);
            this.lblautoImgdelete.TabIndex = 35;
            this.lblautoImgdelete.Text = "Auto Delete Image :";
            // 
            // ResetTimer
            // 
            this.ResetTimer.EditValue = new System.DateTime(2023, 2, 16, 0, 0, 0, 0);
            this.ResetTimer.Location = new System.Drawing.Point(705, 448);
            this.ResetTimer.Name = "ResetTimer";
            this.ResetTimer.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.ResetTimer.Size = new System.Drawing.Size(100, 22);
            this.ResetTimer.TabIndex = 33;
            this.ResetTimer.Visible = false;
            // 
            // labelControl67
            // 
            this.labelControl67.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl67.Appearance.Options.UseFont = true;
            this.labelControl67.Appearance.Options.UseTextOptions = true;
            this.labelControl67.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl67.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl67.Location = new System.Drawing.Point(476, 446);
            this.labelControl67.Name = "labelControl67";
            this.labelControl67.Size = new System.Drawing.Size(220, 19);
            this.labelControl67.TabIndex = 32;
            this.labelControl67.Text = "Reset Timer :";
            this.labelControl67.Visible = false;
            // 
            // btnOriginalDelete
            // 
            this.btnOriginalDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOriginalDelete.Appearance.Options.UseFont = true;
            this.btnOriginalDelete.Location = new System.Drawing.Point(441, 100);
            this.btnOriginalDelete.Name = "btnOriginalDelete";
            this.btnOriginalDelete.Size = new System.Drawing.Size(100, 32);
            this.btnOriginalDelete.TabIndex = 31;
            this.btnOriginalDelete.Text = "1회 삭제";
            this.btnOriginalDelete.Click += new System.EventHandler(this.btnOriginalDelete_Click);
            // 
            // labelControl65
            // 
            this.labelControl65.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl65.Appearance.Options.UseFont = true;
            this.labelControl65.Location = new System.Drawing.Point(437, 284);
            this.labelControl65.Name = "labelControl65";
            this.labelControl65.Size = new System.Drawing.Size(18, 18);
            this.labelControl65.TabIndex = 27;
            this.labelControl65.Text = "%";
            // 
            // txtDiskDelete
            // 
            this.txtDiskDelete.Location = new System.Drawing.Point(331, 282);
            this.txtDiskDelete.Name = "txtDiskDelete";
            this.txtDiskDelete.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDiskDelete.Properties.Appearance.Options.UseFont = true;
            this.txtDiskDelete.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDiskDelete.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDiskDelete.Size = new System.Drawing.Size(100, 24);
            this.txtDiskDelete.TabIndex = 26;
            // 
            // btnResultDelete
            // 
            this.btnResultDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnResultDelete.Appearance.Options.UseFont = true;
            this.btnResultDelete.Location = new System.Drawing.Point(441, 207);
            this.btnResultDelete.Name = "btnResultDelete";
            this.btnResultDelete.Size = new System.Drawing.Size(100, 32);
            this.btnResultDelete.TabIndex = 25;
            this.btnResultDelete.Text = "1회 삭제";
            this.btnResultDelete.Click += new System.EventHandler(this.btnBackupDelete_Click);
            // 
            // btnSaveImagePath
            // 
            this.btnSaveImagePath.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSaveImagePath.Appearance.Options.UseFont = true;
            this.btnSaveImagePath.Appearance.Options.UseTextOptions = true;
            this.btnSaveImagePath.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSaveImagePath.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSaveImagePath.Location = new System.Drawing.Point(632, 34);
            this.btnSaveImagePath.Name = "btnSaveImagePath";
            this.btnSaveImagePath.Size = new System.Drawing.Size(30, 27);
            this.btnSaveImagePath.TabIndex = 23;
            this.btnSaveImagePath.Text = "...";
            this.btnSaveImagePath.Click += new System.EventHandler(this.btnSaveImagePath_Click);
            // 
            // panelControl3
            // 
            this.panelControl3.Controls.Add(this.radResultJPG);
            this.panelControl3.Controls.Add(this.radResultBMP);
            this.panelControl3.Location = new System.Drawing.Point(238, 207);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(197, 33);
            this.panelControl3.TabIndex = 22;
            // 
            // radResultJPG
            // 
            this.radResultJPG.AutoSize = true;
            this.radResultJPG.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.radResultJPG.Location = new System.Drawing.Point(125, 5);
            this.radResultJPG.Name = "radResultJPG";
            this.radResultJPG.Size = new System.Drawing.Size(47, 20);
            this.radResultJPG.TabIndex = 1;
            this.radResultJPG.TabStop = true;
            this.radResultJPG.Text = "JPG";
            this.radResultJPG.UseVisualStyleBackColor = true;
            this.radResultJPG.CheckedChanged += new System.EventHandler(this.radOriginBMP_CheckedChanged);
            // 
            // radResultBMP
            // 
            this.radResultBMP.AutoSize = true;
            this.radResultBMP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.radResultBMP.Location = new System.Drawing.Point(14, 5);
            this.radResultBMP.Name = "radResultBMP";
            this.radResultBMP.Size = new System.Drawing.Size(52, 20);
            this.radResultBMP.TabIndex = 0;
            this.radResultBMP.TabStop = true;
            this.radResultBMP.Text = "BMP";
            this.radResultBMP.UseVisualStyleBackColor = true;
            this.radResultBMP.CheckedChanged += new System.EventHandler(this.radOriginBMP_CheckedChanged);
            // 
            // labelControl14
            // 
            this.labelControl14.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl14.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl14.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl14.Appearance.Options.UseBackColor = true;
            this.labelControl14.Appearance.Options.UseFont = true;
            this.labelControl14.Appearance.Options.UseForeColor = true;
            this.labelControl14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl14.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl14.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl14.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl14.ImageOptions.SvgImage")));
            this.labelControl14.Location = new System.Drawing.Point(2, 2);
            this.labelControl14.Name = "labelControl14";
            this.labelControl14.Size = new System.Drawing.Size(668, 26);
            this.labelControl14.TabIndex = 16;
            this.labelControl14.Text = "Image Setting";
            // 
            // panelControl4
            // 
            this.panelControl4.Controls.Add(this.radOriginJPG);
            this.panelControl4.Controls.Add(this.radOriginBMP);
            this.panelControl4.Location = new System.Drawing.Point(238, 100);
            this.panelControl4.Name = "panelControl4";
            this.panelControl4.Size = new System.Drawing.Size(197, 33);
            this.panelControl4.TabIndex = 21;
            // 
            // radOriginJPG
            // 
            this.radOriginJPG.AutoSize = true;
            this.radOriginJPG.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.radOriginJPG.Location = new System.Drawing.Point(125, 5);
            this.radOriginJPG.Name = "radOriginJPG";
            this.radOriginJPG.Size = new System.Drawing.Size(47, 20);
            this.radOriginJPG.TabIndex = 1;
            this.radOriginJPG.TabStop = true;
            this.radOriginJPG.Text = "JPG";
            this.radOriginJPG.UseVisualStyleBackColor = true;
            this.radOriginJPG.CheckedChanged += new System.EventHandler(this.radOriginBMP_CheckedChanged);
            // 
            // radOriginBMP
            // 
            this.radOriginBMP.AutoSize = true;
            this.radOriginBMP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.radOriginBMP.Location = new System.Drawing.Point(14, 5);
            this.radOriginBMP.Name = "radOriginBMP";
            this.radOriginBMP.Size = new System.Drawing.Size(52, 20);
            this.radOriginBMP.TabIndex = 0;
            this.radOriginBMP.TabStop = true;
            this.radOriginBMP.Text = "BMP";
            this.radOriginBMP.UseVisualStyleBackColor = true;
            this.radOriginBMP.CheckedChanged += new System.EventHandler(this.radOriginBMP_CheckedChanged);
            // 
            // btnImgpnlClose
            // 
            this.btnImgpnlClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnImgpnlClose.Appearance.Options.UseFont = true;
            this.btnImgpnlClose.Appearance.Options.UseTextOptions = true;
            this.btnImgpnlClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnImgpnlClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImgpnlClose.ImageOptions.Image")));
            this.btnImgpnlClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnImgpnlClose.Location = new System.Drawing.Point(340, 318);
            this.btnImgpnlClose.Name = "btnImgpnlClose";
            this.btnImgpnlClose.Size = new System.Drawing.Size(114, 58);
            this.btnImgpnlClose.TabIndex = 20;
            this.btnImgpnlClose.Text = "Close";
            this.btnImgpnlClose.Click += new System.EventHandler(this.btnImgpnlClose_Click);
            // 
            // lblOriginImgPath
            // 
            this.lblOriginImgPath.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOriginImgPath.Appearance.Options.UseFont = true;
            this.lblOriginImgPath.Appearance.Options.UseTextOptions = true;
            this.lblOriginImgPath.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOriginImgPath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOriginImgPath.Location = new System.Drawing.Point(29, 36);
            this.lblOriginImgPath.Name = "lblOriginImgPath";
            this.lblOriginImgPath.Size = new System.Drawing.Size(201, 19);
            this.lblOriginImgPath.TabIndex = 15;
            this.lblOriginImgPath.Text = "Imae Save Path :";
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSave.Appearance.Options.UseFont = true;
            this.btnSave.Appearance.Options.UseTextOptions = true;
            this.btnSave.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(219, 318);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(114, 58);
            this.btnSave.TabIndex = 19;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // swOriginSave
            // 
            this.swOriginSave.Location = new System.Drawing.Point(238, 69);
            this.swOriginSave.Name = "swOriginSave";
            this.swOriginSave.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.swOriginSave.Properties.Appearance.Options.UseFont = true;
            this.swOriginSave.Properties.OffText = "Off";
            this.swOriginSave.Properties.OnText = "On";
            this.swOriginSave.Size = new System.Drawing.Size(95, 19);
            this.swOriginSave.TabIndex = 0;
            // 
            // lblOriginImgsave
            // 
            this.lblOriginImgsave.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOriginImgsave.Appearance.Options.UseFont = true;
            this.lblOriginImgsave.Appearance.Options.UseTextOptions = true;
            this.lblOriginImgsave.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOriginImgsave.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOriginImgsave.Location = new System.Drawing.Point(29, 69);
            this.lblOriginImgsave.Name = "lblOriginImgsave";
            this.lblOriginImgsave.Size = new System.Drawing.Size(201, 19);
            this.lblOriginImgsave.TabIndex = 1;
            this.lblOriginImgsave.Text = "Original Image Save :";
            // 
            // txtSaveImagePath
            // 
            this.txtSaveImagePath.Location = new System.Drawing.Point(238, 34);
            this.txtSaveImagePath.Name = "txtSaveImagePath";
            this.txtSaveImagePath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtSaveImagePath.Properties.Appearance.Options.UseFont = true;
            this.txtSaveImagePath.Size = new System.Drawing.Size(392, 24);
            this.txtSaveImagePath.TabIndex = 0;
            // 
            // lblOriginImgformat
            // 
            this.lblOriginImgformat.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOriginImgformat.Appearance.Options.UseFont = true;
            this.lblOriginImgformat.Appearance.Options.UseTextOptions = true;
            this.lblOriginImgformat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblOriginImgformat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOriginImgformat.Location = new System.Drawing.Point(10, 106);
            this.lblOriginImgformat.Name = "lblOriginImgformat";
            this.lblOriginImgformat.Size = new System.Drawing.Size(220, 19);
            this.lblOriginImgformat.TabIndex = 2;
            this.lblOriginImgformat.Text = "Original Image Save Format :";
            // 
            // swResultSave
            // 
            this.swResultSave.Location = new System.Drawing.Point(238, 174);
            this.swResultSave.Name = "swResultSave";
            this.swResultSave.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.swResultSave.Properties.Appearance.Options.UseFont = true;
            this.swResultSave.Properties.OffText = "Off";
            this.swResultSave.Properties.OnText = "On";
            this.swResultSave.Size = new System.Drawing.Size(95, 19);
            this.swResultSave.TabIndex = 6;
            // 
            // lblresultImgsave
            // 
            this.lblresultImgsave.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblresultImgsave.Appearance.Options.UseFont = true;
            this.lblresultImgsave.Appearance.Options.UseTextOptions = true;
            this.lblresultImgsave.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblresultImgsave.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblresultImgsave.Location = new System.Drawing.Point(29, 174);
            this.lblresultImgsave.Name = "lblresultImgsave";
            this.lblresultImgsave.Size = new System.Drawing.Size(201, 19);
            this.lblresultImgsave.TabIndex = 7;
            this.lblresultImgsave.Text = "Result Image Save :";
            // 
            // lblresultImgformat
            // 
            this.lblresultImgformat.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblresultImgformat.Appearance.Options.UseFont = true;
            this.lblresultImgformat.Appearance.Options.UseTextOptions = true;
            this.lblresultImgformat.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblresultImgformat.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblresultImgformat.Location = new System.Drawing.Point(10, 213);
            this.lblresultImgformat.Name = "lblresultImgformat";
            this.lblresultImgformat.Size = new System.Drawing.Size(220, 19);
            this.lblresultImgformat.TabIndex = 8;
            this.lblresultImgformat.Text = "Result Image Save Format :";
            // 
            // flyLog
            // 
            this.flyLog.AutoSize = true;
            this.flyLog.Controls.Add(this.flyoutPanelControl5);
            this.flyLog.Location = new System.Drawing.Point(1424, 127);
            this.flyLog.Name = "flyLog";
            this.flyLog.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Right;
            this.flyLog.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyLog.Options.CloseOnHidingOwner = false;
            this.flyLog.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyLog.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyLog.OwnerControl = this.lblLog;
            this.flyLog.Size = new System.Drawing.Size(434, 1047);
            this.flyLog.TabIndex = 48;
            // 
            // flyoutPanelControl5
            // 
            this.flyoutPanelControl5.Controls.Add(this.tablePanel9);
            this.flyoutPanelControl5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl5.FlyoutPanel = this.flyLog;
            this.flyoutPanelControl5.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl5.Name = "flyoutPanelControl5";
            this.flyoutPanelControl5.Size = new System.Drawing.Size(434, 1047);
            this.flyoutPanelControl5.TabIndex = 0;
            // 
            // lblLog
            // 
            this.lblLog.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLog.Dock = System.Windows.Forms.DockStyle.Right;
            this.lblLog.Location = new System.Drawing.Point(1443, 132);
            this.lblLog.Name = "lblLog";
            this.lblLog.Size = new System.Drawing.Size(0, 936);
            this.lblLog.TabIndex = 160;
            // 
            // flyLogin
            // 
            this.flyLogin.AutoSize = true;
            this.flyLogin.Controls.Add(this.flyoutPanelControl2);
            this.flyLogin.Location = new System.Drawing.Point(12, 254);
            this.flyLogin.Name = "flyLogin";
            this.flyLogin.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyLogin.Options.CloseOnHidingOwner = false;
            this.flyLogin.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyLogin.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyLogin.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyLogin.OwnerControl = this.btnSetModel;
            this.flyLogin.Size = new System.Drawing.Size(459, 195);
            this.flyLogin.TabIndex = 64;
            // 
            // flyoutPanelControl2
            // 
            this.flyoutPanelControl2.Controls.Add(this.txtUser);
            this.flyoutPanelControl2.Controls.Add(this.labelControl95);
            this.flyoutPanelControl2.Controls.Add(this.btnClose);
            this.flyoutPanelControl2.Controls.Add(this.btnChkPass);
            this.flyoutPanelControl2.Controls.Add(this.txtPassword);
            this.flyoutPanelControl2.Controls.Add(this.lblPW);
            this.flyoutPanelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl2.FlyoutPanel = this.flyLogin;
            this.flyoutPanelControl2.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl2.Name = "flyoutPanelControl2";
            this.flyoutPanelControl2.Size = new System.Drawing.Size(459, 195);
            this.flyoutPanelControl2.TabIndex = 0;
            // 
            // labelControl95
            // 
            this.labelControl95.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl95.Appearance.Options.UseFont = true;
            this.labelControl95.Appearance.Options.UseTextOptions = true;
            this.labelControl95.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl95.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl95.Location = new System.Drawing.Point(8, 26);
            this.labelControl95.Name = "labelControl95";
            this.labelControl95.Size = new System.Drawing.Size(128, 25);
            this.labelControl95.TabIndex = 48;
            this.labelControl95.Text = "USER :";
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseTextOptions = true;
            this.btnClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(231, 115);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(134, 56);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnChkPass
            // 
            this.btnChkPass.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnChkPass.Appearance.Options.UseFont = true;
            this.btnChkPass.Appearance.Options.UseTextOptions = true;
            this.btnChkPass.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnChkPass.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnChkPass.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnChkPass.ImageOptions.Image")));
            this.btnChkPass.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnChkPass.Location = new System.Drawing.Point(94, 115);
            this.btnChkPass.Name = "btnChkPass";
            this.btnChkPass.Size = new System.Drawing.Size(134, 56);
            this.btnChkPass.TabIndex = 3;
            this.btnChkPass.Text = "Check";
            this.btnChkPass.Click += new System.EventHandler(this.btnChkPass_Click);
            // 
            // lblPW
            // 
            this.lblPW.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPW.Appearance.Options.UseFont = true;
            this.lblPW.Appearance.Options.UseTextOptions = true;
            this.lblPW.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPW.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPW.Location = new System.Drawing.Point(8, 66);
            this.lblPW.Name = "lblPW";
            this.lblPW.Size = new System.Drawing.Size(128, 25);
            this.lblPW.TabIndex = 0;
            this.lblPW.Text = "Password :";
            // 
            // btnUserManage
            // 
            this.btnUserManage.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUserManage.Appearance.Options.UseFont = true;
            this.btnUserManage.Appearance.Options.UseTextOptions = true;
            this.btnUserManage.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnUserManage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUserManage.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUserManage.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUserManage.ImageOptions.SvgImage")));
            this.btnUserManage.Location = new System.Drawing.Point(6, 269);
            this.btnUserManage.Name = "btnUserManage";
            this.btnUserManage.Size = new System.Drawing.Size(155, 55);
            this.btnUserManage.TabIndex = 0;
            this.btnUserManage.Text = "User Management";
            this.btnUserManage.Click += new System.EventHandler(this.btnPasswordChange_Click);
            // 
            // flyChangePW
            // 
            this.flyChangePW.AutoSize = true;
            this.flyChangePW.Controls.Add(this.flyoutPanelControl3);
            this.flyChangePW.Location = new System.Drawing.Point(1862, 466);
            this.flyChangePW.Name = "flyChangePW";
            this.flyChangePW.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Center;
            this.flyChangePW.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyChangePW.Options.CloseOnHidingOwner = false;
            this.flyChangePW.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyChangePW.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyChangePW.OwnerControl = this;
            this.flyChangePW.Size = new System.Drawing.Size(606, 492);
            this.flyChangePW.TabIndex = 74;
            // 
            // flyoutPanelControl3
            // 
            this.flyoutPanelControl3.Controls.Add(this.btnUserDel);
            this.flyoutPanelControl3.Controls.Add(this.btnUserAdd);
            this.flyoutPanelControl3.Controls.Add(this.btnPWClose);
            this.flyoutPanelControl3.Controls.Add(this.groupControl8);
            this.flyoutPanelControl3.Controls.Add(this.btnUserEdit);
            this.flyoutPanelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl3.FlyoutPanel = this.flyChangePW;
            this.flyoutPanelControl3.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl3.Name = "flyoutPanelControl3";
            this.flyoutPanelControl3.Size = new System.Drawing.Size(606, 492);
            this.flyoutPanelControl3.TabIndex = 0;
            // 
            // btnUserDel
            // 
            this.btnUserDel.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUserDel.Appearance.Options.UseFont = true;
            this.btnUserDel.Appearance.Options.UseTextOptions = true;
            this.btnUserDel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnUserDel.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUserDel.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUserDel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUserDel.ImageOptions.SvgImage")));
            this.btnUserDel.Location = new System.Drawing.Point(307, 425);
            this.btnUserDel.Name = "btnUserDel";
            this.btnUserDel.Size = new System.Drawing.Size(134, 56);
            this.btnUserDel.TabIndex = 31;
            this.btnUserDel.Text = "Del";
            // 
            // btnUserAdd
            // 
            this.btnUserAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUserAdd.Appearance.Options.UseFont = true;
            this.btnUserAdd.Appearance.Options.UseTextOptions = true;
            this.btnUserAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnUserAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUserAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUserAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUserAdd.ImageOptions.SvgImage")));
            this.btnUserAdd.Location = new System.Drawing.Point(25, 425);
            this.btnUserAdd.Name = "btnUserAdd";
            this.btnUserAdd.Size = new System.Drawing.Size(134, 56);
            this.btnUserAdd.TabIndex = 30;
            this.btnUserAdd.Text = "Add";
            this.btnUserAdd.Click += new System.EventHandler(this.btnUserAdd_Click);
            // 
            // btnPWClose
            // 
            this.btnPWClose.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnPWClose.Appearance.Options.UseFont = true;
            this.btnPWClose.Appearance.Options.UseTextOptions = true;
            this.btnPWClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnPWClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPWClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPWClose.ImageOptions.Image")));
            this.btnPWClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPWClose.Location = new System.Drawing.Point(448, 425);
            this.btnPWClose.Name = "btnPWClose";
            this.btnPWClose.Size = new System.Drawing.Size(134, 56);
            this.btnPWClose.TabIndex = 4;
            this.btnPWClose.Text = "Close";
            this.btnPWClose.Click += new System.EventHandler(this.btnPWClose_Click);
            // 
            // groupControl8
            // 
            this.groupControl8.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl8.AppearanceCaption.Options.UseFont = true;
            this.groupControl8.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl8.CaptionImageOptions.SvgImage")));
            this.groupControl8.Controls.Add(this.dgUser);
            this.groupControl8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl8.Location = new System.Drawing.Point(2, 2);
            this.groupControl8.Name = "groupControl8";
            this.groupControl8.Size = new System.Drawing.Size(602, 412);
            this.groupControl8.TabIndex = 29;
            this.groupControl8.Text = "USER LIST";
            // 
            // dgUser
            // 
            this.dgUser.AllowUserToAddRows = false;
            this.dgUser.AllowUserToDeleteRows = false;
            this.dgUser.AllowUserToResizeColumns = false;
            this.dgUser.AllowUserToResizeRows = false;
            this.dgUser.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUser.ColumnHeadersHeight = 30;
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUser.GridColor = System.Drawing.Color.White;
            this.dgUser.Location = new System.Drawing.Point(2, 33);
            this.dgUser.Name = "dgUser";
            this.dgUser.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgUser.RowHeadersVisible = false;
            this.dgUser.RowHeadersWidth = 51;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            this.dgUser.RowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgUser.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgUser.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dgUser.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgUser.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dgUser.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgUser.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.dgUser.RowTemplate.Height = 23;
            this.dgUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUser.Size = new System.Drawing.Size(598, 377);
            this.dgUser.TabIndex = 1;
            // 
            // btnUserEdit
            // 
            this.btnUserEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUserEdit.Appearance.Options.UseFont = true;
            this.btnUserEdit.Appearance.Options.UseTextOptions = true;
            this.btnUserEdit.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnUserEdit.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUserEdit.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUserEdit.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUserEdit.ImageOptions.SvgImage")));
            this.btnUserEdit.Location = new System.Drawing.Point(166, 425);
            this.btnUserEdit.Name = "btnUserEdit";
            this.btnUserEdit.Size = new System.Drawing.Size(134, 56);
            this.btnUserEdit.TabIndex = 3;
            this.btnUserEdit.Text = "Edit";
            this.btnUserEdit.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // txtChangePW2
            // 
            this.txtChangePW2.Location = new System.Drawing.Point(228, 146);
            this.txtChangePW2.Name = "txtChangePW2";
            this.txtChangePW2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtChangePW2.Properties.Appearance.Options.UseFont = true;
            this.txtChangePW2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtChangePW2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtChangePW2.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Yellow;
            this.txtChangePW2.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtChangePW2.Properties.PasswordChar = '*';
            this.txtChangePW2.Size = new System.Drawing.Size(197, 30);
            this.txtChangePW2.TabIndex = 3;
            this.txtChangePW2.TextChanged += new System.EventHandler(this.txtChangePW1_TextChanged);
            // 
            // lblReenterPW
            // 
            this.lblReenterPW.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblReenterPW.Appearance.Options.UseFont = true;
            this.lblReenterPW.Appearance.Options.UseTextOptions = true;
            this.lblReenterPW.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblReenterPW.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblReenterPW.Location = new System.Drawing.Point(17, 150);
            this.lblReenterPW.Name = "lblReenterPW";
            this.lblReenterPW.Size = new System.Drawing.Size(200, 25);
            this.lblReenterPW.TabIndex = 7;
            this.lblReenterPW.Text = "Re-enter Password : ";
            // 
            // txtChangePW1
            // 
            this.txtChangePW1.Location = new System.Drawing.Point(228, 107);
            this.txtChangePW1.Name = "txtChangePW1";
            this.txtChangePW1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtChangePW1.Properties.Appearance.Options.UseFont = true;
            this.txtChangePW1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtChangePW1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtChangePW1.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Yellow;
            this.txtChangePW1.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtChangePW1.Properties.PasswordChar = '*';
            this.txtChangePW1.Size = new System.Drawing.Size(197, 30);
            this.txtChangePW1.TabIndex = 2;
            this.txtChangePW1.TextChanged += new System.EventHandler(this.txtChangePW1_TextChanged);
            // 
            // lblEnterPW
            // 
            this.lblEnterPW.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblEnterPW.Appearance.Options.UseFont = true;
            this.lblEnterPW.Appearance.Options.UseTextOptions = true;
            this.lblEnterPW.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblEnterPW.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEnterPW.Location = new System.Drawing.Point(17, 111);
            this.lblEnterPW.Name = "lblEnterPW";
            this.lblEnterPW.Size = new System.Drawing.Size(200, 25);
            this.lblEnterPW.TabIndex = 5;
            this.lblEnterPW.Text = "Enter Password : ";
            // 
            // lblPass
            // 
            this.lblPass.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPass.Location = new System.Drawing.Point(1057, 40);
            this.lblPass.Name = "lblPass";
            this.lblPass.Size = new System.Drawing.Size(459, 0);
            this.lblPass.TabIndex = 75;
            // 
            // flyCamCnt
            // 
            this.flyCamCnt.AutoSize = true;
            this.flyCamCnt.Controls.Add(this.flyoutPanelControl7);
            this.flyCamCnt.Location = new System.Drawing.Point(1, 432);
            this.flyCamCnt.Name = "flyCamCnt";
            this.flyCamCnt.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyCamCnt.Options.CloseOnHidingOwner = false;
            this.flyCamCnt.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyCamCnt.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyCamCnt.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyCamCnt.OwnerControl = this.btnSetCam;
            this.flyCamCnt.Size = new System.Drawing.Size(459, 125);
            this.flyCamCnt.TabIndex = 86;
            // 
            // flyoutPanelControl7
            // 
            this.flyoutPanelControl7.Controls.Add(this.btnCamClose);
            this.flyoutPanelControl7.Controls.Add(this.btnCamAdd);
            this.flyoutPanelControl7.Controls.Add(this.txtCamCnt);
            this.flyoutPanelControl7.Controls.Add(this.lblCamCnt);
            this.flyoutPanelControl7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl7.FlyoutPanel = this.flyCamCnt;
            this.flyoutPanelControl7.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl7.Name = "flyoutPanelControl7";
            this.flyoutPanelControl7.Size = new System.Drawing.Size(459, 125);
            this.flyoutPanelControl7.TabIndex = 0;
            // 
            // btnCamClose
            // 
            this.btnCamClose.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCamClose.Appearance.Options.UseFont = true;
            this.btnCamClose.Appearance.Options.UseTextOptions = true;
            this.btnCamClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCamClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCamClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnCamClose.ImageOptions.Image")));
            this.btnCamClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCamClose.Location = new System.Drawing.Point(231, 58);
            this.btnCamClose.Name = "btnCamClose";
            this.btnCamClose.Size = new System.Drawing.Size(134, 56);
            this.btnCamClose.TabIndex = 4;
            this.btnCamClose.Text = "Close";
            this.btnCamClose.Click += new System.EventHandler(this.btnCamClose_Click);
            // 
            // btnCamAdd
            // 
            this.btnCamAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnCamAdd.Appearance.Options.UseFont = true;
            this.btnCamAdd.Appearance.Options.UseTextOptions = true;
            this.btnCamAdd.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnCamAdd.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnCamAdd.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCamAdd.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCamAdd.ImageOptions.SvgImage")));
            this.btnCamAdd.Location = new System.Drawing.Point(94, 58);
            this.btnCamAdd.Name = "btnCamAdd";
            this.btnCamAdd.Size = new System.Drawing.Size(134, 56);
            this.btnCamAdd.TabIndex = 3;
            this.btnCamAdd.Text = "Add";
            this.btnCamAdd.Click += new System.EventHandler(this.btnCamAdd_Click);
            // 
            // txtCamCnt
            // 
            this.txtCamCnt.Location = new System.Drawing.Point(182, 14);
            this.txtCamCnt.Name = "txtCamCnt";
            this.txtCamCnt.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.txtCamCnt.Properties.Appearance.Options.UseFont = true;
            this.txtCamCnt.Properties.Appearance.Options.UseTextOptions = true;
            this.txtCamCnt.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtCamCnt.Properties.AppearanceFocused.BorderColor = System.Drawing.Color.Yellow;
            this.txtCamCnt.Properties.AppearanceFocused.Options.UseBorderColor = true;
            this.txtCamCnt.Size = new System.Drawing.Size(183, 30);
            this.txtCamCnt.TabIndex = 1;
            this.txtCamCnt.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCamCnt_KeyDown);
            this.txtCamCnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPassword_KeyPress);
            // 
            // lblCamCnt
            // 
            this.lblCamCnt.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCamCnt.Appearance.Options.UseFont = true;
            this.lblCamCnt.Location = new System.Drawing.Point(22, 17);
            this.lblCamCnt.Name = "lblCamCnt";
            this.lblCamCnt.Size = new System.Drawing.Size(154, 23);
            this.lblCamCnt.TabIndex = 0;
            this.lblCamCnt.Text = "Camera Count : ";
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelControl5.Appearance.Options.UseFont = true;
            this.labelControl5.Location = new System.Drawing.Point(22, 16);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(189, 23);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "Current password : ";
            // 
            // lblCurrent
            // 
            this.lblCurrent.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblCurrent.Appearance.Options.UseFont = true;
            this.lblCurrent.Appearance.Options.UseTextOptions = true;
            this.lblCurrent.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCurrent.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCurrent.Location = new System.Drawing.Point(22, 16);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(200, 23);
            this.lblCurrent.TabIndex = 0;
            this.lblCurrent.Text = "Current password : ";
            // 
            // lblPasswrod
            // 
            this.lblPasswrod.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPasswrod.Appearance.Options.UseFont = true;
            this.lblPasswrod.Location = new System.Drawing.Point(22, 16);
            this.lblPasswrod.Name = "lblPasswrod";
            this.lblPasswrod.Size = new System.Drawing.Size(111, 23);
            this.lblPasswrod.TabIndex = 0;
            this.lblPasswrod.Text = "Password : ";
            // 
            // labelControl19
            // 
            this.labelControl19.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelControl19.Appearance.Options.UseFont = true;
            this.labelControl19.Location = new System.Drawing.Point(22, 16);
            this.labelControl19.Name = "labelControl19";
            this.labelControl19.Size = new System.Drawing.Size(154, 23);
            this.labelControl19.TabIndex = 0;
            this.labelControl19.Text = "Camera Count : ";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(29, 34);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(201, 18);
            this.labelControl8.TabIndex = 15;
            this.labelControl8.Text = "Imae Save Path :";
            // 
            // flyResImg
            // 
            this.flyResImg.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flyResImg.Appearance.Options.UseBackColor = true;
            this.flyResImg.AutoSize = true;
            this.flyResImg.Controls.Add(this.btnPrevious);
            this.flyResImg.Controls.Add(this.btnNext);
            this.flyResImg.Controls.Add(this.btnListClose);
            this.flyResImg.Controls.Add(this.flyoutPanelControl9);
            this.flyResImg.Location = new System.Drawing.Point(709, 955);
            this.flyResImg.Name = "flyResImg";
            this.flyResImg.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyResImg.Options.CloseOnHidingOwner = false;
            this.flyResImg.OptionsBeakPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            this.flyResImg.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyResImg.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyResImg.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyResImg.Size = new System.Drawing.Size(1284, 661);
            this.flyResImg.TabIndex = 98;
            // 
            // btnPrevious
            // 
            this.btnPrevious.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnPrevious.Appearance.Options.UseFont = true;
            this.btnPrevious.Appearance.Options.UseTextOptions = true;
            this.btnPrevious.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnPrevious.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.ImageOptions.Image")));
            this.btnPrevious.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnPrevious.Location = new System.Drawing.Point(468, 608);
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.Size = new System.Drawing.Size(114, 49);
            this.btnPrevious.TabIndex = 23;
            this.btnPrevious.Text = "Previous";
            this.btnPrevious.Click += new System.EventHandler(this.btnPrevious_Click);
            // 
            // btnNext
            // 
            this.btnNext.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnNext.Appearance.Options.UseFont = true;
            this.btnNext.Appearance.Options.UseTextOptions = true;
            this.btnNext.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.ImageOptions.Image")));
            this.btnNext.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnNext.Location = new System.Drawing.Point(585, 608);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(114, 49);
            this.btnNext.TabIndex = 22;
            this.btnNext.Text = "Next";
            this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
            // 
            // btnListClose
            // 
            this.btnListClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnListClose.Appearance.Options.UseFont = true;
            this.btnListClose.Appearance.Options.UseTextOptions = true;
            this.btnListClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnListClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnListClose.ImageOptions.Image")));
            this.btnListClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnListClose.Location = new System.Drawing.Point(702, 608);
            this.btnListClose.Name = "btnListClose";
            this.btnListClose.Size = new System.Drawing.Size(114, 49);
            this.btnListClose.TabIndex = 21;
            this.btnListClose.Text = "Close";
            this.btnListClose.Click += new System.EventHandler(this.btnListClose_Click);
            // 
            // flyoutPanelControl9
            // 
            this.flyoutPanelControl9.Controls.Add(this.tablePanel3);
            this.flyoutPanelControl9.Dock = System.Windows.Forms.DockStyle.Top;
            this.flyoutPanelControl9.FlyoutPanel = this.flyResImg;
            this.flyoutPanelControl9.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl9.Name = "flyoutPanelControl9";
            this.flyoutPanelControl9.Size = new System.Drawing.Size(1284, 603);
            this.flyoutPanelControl9.TabIndex = 0;
            // 
            // tablePanel3
            // 
            this.tablePanel3.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel3.Controls.Add(this.cogDispOrigin);
            this.tablePanel3.Controls.Add(this.cogDispResult);
            this.tablePanel3.Controls.Add(this.labelControl4);
            this.tablePanel3.Controls.Add(this.labelControl2);
            this.tablePanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel3.Location = new System.Drawing.Point(2, 2);
            this.tablePanel3.Name = "tablePanel3";
            this.tablePanel3.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 33F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 63.72F)});
            this.tablePanel3.Size = new System.Drawing.Size(1280, 599);
            this.tablePanel3.TabIndex = 25;
            // 
            // cogDispOrigin
            // 
            this.cogDispOrigin.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDispOrigin.ColorMapLowerRoiLimit = 0D;
            this.cogDispOrigin.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDispOrigin.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDispOrigin.ColorMapUpperRoiLimit = 1D;
            this.cogDispOrigin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDispOrigin.DoubleTapZoomCycleLength = 2;
            this.cogDispOrigin.DoubleTapZoomSensitivity = 2.5D;
            this.cogDispOrigin.Location = new System.Drawing.Point(3, 36);
            this.cogDispOrigin.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDispOrigin.MouseWheelSensitivity = 1D;
            this.cogDispOrigin.Name = "cogDispOrigin";
            this.cogDispOrigin.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDispOrigin.OcxState")));
            this.cogDispOrigin.Size = new System.Drawing.Size(991, 813);
            this.cogDispOrigin.TabIndex = 142;
            // 
            // cogDispResult
            // 
            this.cogDispResult.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDispResult.ColorMapLowerRoiLimit = 0D;
            this.cogDispResult.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDispResult.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDispResult.ColorMapUpperRoiLimit = 1D;
            this.cogDispResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDispResult.DoubleTapZoomCycleLength = 2;
            this.cogDispResult.DoubleTapZoomSensitivity = 2.5D;
            this.cogDispResult.Location = new System.Drawing.Point(643, 36);
            this.cogDispResult.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDispResult.MouseWheelSensitivity = 1D;
            this.cogDispResult.Name = "cogDispResult";
            this.cogDispResult.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDispResult.OcxState")));
            this.cogDispResult.Size = new System.Drawing.Size(991, 813);
            this.cogDispResult.TabIndex = 141;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl4.Appearance.Options.UseBackColor = true;
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Appearance.Options.UseForeColor = true;
            this.labelControl4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl4.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl4.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl4.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl4.ImageOptions.SvgImage")));
            this.labelControl4.Location = new System.Drawing.Point(643, 3);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(634, 29);
            this.labelControl4.TabIndex = 28;
            this.labelControl4.Text = "Result Image";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.labelControl2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl2.Appearance.Options.UseBackColor = true;
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Appearance.Options.UseForeColor = true;
            this.labelControl2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl2.ImageOptions.Alignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.labelControl2.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl2.ImageOptions.SvgImage")));
            this.labelControl2.Location = new System.Drawing.Point(3, 3);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(634, 29);
            this.labelControl2.TabIndex = 27;
            this.labelControl2.Text = "Original Image";
            // 
            // labelControl72
            // 
            this.labelControl72.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl72.Appearance.Options.UseFont = true;
            this.labelControl72.Appearance.Options.UseTextOptions = true;
            this.labelControl72.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl72.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl72.Location = new System.Drawing.Point(10, 64);
            this.labelControl72.Name = "labelControl72";
            this.labelControl72.Size = new System.Drawing.Size(141, 19);
            this.labelControl72.TabIndex = 21;
            this.labelControl72.Text = "Process Name :";
            // 
            // txtProcName
            // 
            this.txtProcName.Location = new System.Drawing.Point(159, 62);
            this.txtProcName.Name = "txtProcName";
            this.txtProcName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtProcName.Properties.Appearance.Options.UseFont = true;
            this.txtProcName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtProcName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtProcName.Size = new System.Drawing.Size(264, 24);
            this.txtProcName.TabIndex = 1;
            // 
            // flyImgList
            // 
            this.flyImgList.AutoSize = true;
            this.flyImgList.Controls.Add(this.flyoutPanelControl8);
            this.flyImgList.Location = new System.Drawing.Point(168, 693);
            this.flyImgList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flyImgList.Name = "flyImgList";
            this.flyImgList.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyImgList.Options.CloseOnHidingOwner = false;
            this.flyImgList.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyImgList.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyImgList.OptionsButtonPanel.ButtonPanelHeight = 42;
            this.flyImgList.OwnerControl = this.lblMenu;
            this.flyImgList.Size = new System.Drawing.Size(2259, 310);
            this.flyImgList.TabIndex = 128;
            // 
            // flyoutPanelControl8
            // 
            this.flyoutPanelControl8.Controls.Add(this.tablePanel2);
            this.flyoutPanelControl8.Controls.Add(this.pnlImage);
            this.flyoutPanelControl8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl8.FlyoutPanel = this.flyImgList;
            this.flyoutPanelControl8.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.flyoutPanelControl8.Name = "flyoutPanelControl8";
            this.flyoutPanelControl8.Size = new System.Drawing.Size(2259, 310);
            this.flyoutPanelControl8.TabIndex = 0;
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 150F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel2.Controls.Add(this.btnImgListClose);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(2, 240);
            this.tablePanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(2255, 68);
            this.tablePanel2.TabIndex = 7;
            // 
            // btnImgListClose
            // 
            this.btnImgListClose.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnImgListClose.Appearance.Options.UseFont = true;
            this.btnImgListClose.Appearance.Options.UseTextOptions = true;
            this.btnImgListClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnImgListClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.tablePanel2.SetColumn(this.btnImgListClose, 1);
            this.btnImgListClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnImgListClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnImgListClose.ImageOptions.Image")));
            this.btnImgListClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnImgListClose.Location = new System.Drawing.Point(1056, 4);
            this.btnImgListClose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnImgListClose.Name = "btnImgListClose";
            this.tablePanel2.SetRow(this.btnImgListClose, 0);
            this.btnImgListClose.Size = new System.Drawing.Size(144, 60);
            this.btnImgListClose.TabIndex = 6;
            this.btnImgListClose.Text = "Close";
            this.btnImgListClose.Click += new System.EventHandler(this.btnImgListClose_Click);
            // 
            // pnlImage
            // 
            this.pnlImage.AutoScroll = true;
            this.pnlImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlImage.Controls.Add(this.tablePanel1);
            this.pnlImage.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlImage.Location = new System.Drawing.Point(2, 2);
            this.pnlImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlImage.Name = "pnlImage";
            this.pnlImage.Size = new System.Drawing.Size(2255, 238);
            this.pnlImage.TabIndex = 5;
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 200F)});
            this.tablePanel1.Controls.Add(this.cogDisp1);
            this.tablePanel1.Controls.Add(this.cogDisp2);
            this.tablePanel1.Controls.Add(this.cogDisp3);
            this.tablePanel1.Controls.Add(this.cogDisp4);
            this.tablePanel1.Controls.Add(this.cogDisp5);
            this.tablePanel1.Controls.Add(this.cogDisp6);
            this.tablePanel1.Controls.Add(this.cogDisp7);
            this.tablePanel1.Controls.Add(this.cogDisp8);
            this.tablePanel1.Controls.Add(this.cogDisp9);
            this.tablePanel1.Controls.Add(this.cogDisp10);
            this.tablePanel1.Controls.Add(this.cogDisp11);
            this.tablePanel1.Controls.Add(this.cogDisp12);
            this.tablePanel1.Controls.Add(this.cogDisp13);
            this.tablePanel1.Controls.Add(this.cogDisp14);
            this.tablePanel1.Controls.Add(this.cogDisp15);
            this.tablePanel1.Controls.Add(this.cogDisp16);
            this.tablePanel1.Controls.Add(this.cogDisp17);
            this.tablePanel1.Controls.Add(this.cogDisp18);
            this.tablePanel1.Controls.Add(this.cogDisp19);
            this.tablePanel1.Controls.Add(this.cogDisp20);
            this.tablePanel1.Location = new System.Drawing.Point(2, 1);
            this.tablePanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(4000, 209);
            this.tablePanel1.TabIndex = 3;
            // 
            // cogDisp1
            // 
            this.cogDisp1.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp1.ColorMapLowerRoiLimit = 0D;
            this.cogDisp1.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp1.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp1.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp1, 0);
            this.cogDisp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp1.DoubleTapZoomCycleLength = 2;
            this.cogDisp1.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp1.Location = new System.Drawing.Point(3, 3);
            this.cogDisp1.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp1.MouseWheelSensitivity = 1D;
            this.cogDisp1.Name = "cogDisp1";
            this.cogDisp1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp1.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp1, 0);
            this.cogDisp1.Size = new System.Drawing.Size(194, 203);
            this.cogDisp1.TabIndex = 160;
            // 
            // cogDisp2
            // 
            this.cogDisp2.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp2.ColorMapLowerRoiLimit = 0D;
            this.cogDisp2.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp2.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp2.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp2, 1);
            this.cogDisp2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp2.DoubleTapZoomCycleLength = 2;
            this.cogDisp2.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp2.Location = new System.Drawing.Point(203, 3);
            this.cogDisp2.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp2.MouseWheelSensitivity = 1D;
            this.cogDisp2.Name = "cogDisp2";
            this.cogDisp2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp2.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp2, 0);
            this.cogDisp2.Size = new System.Drawing.Size(194, 203);
            this.cogDisp2.TabIndex = 159;
            // 
            // cogDisp3
            // 
            this.cogDisp3.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp3.ColorMapLowerRoiLimit = 0D;
            this.cogDisp3.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp3.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp3.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp3, 2);
            this.cogDisp3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp3.DoubleTapZoomCycleLength = 2;
            this.cogDisp3.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp3.Location = new System.Drawing.Point(403, 3);
            this.cogDisp3.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp3.MouseWheelSensitivity = 1D;
            this.cogDisp3.Name = "cogDisp3";
            this.cogDisp3.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp3.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp3, 0);
            this.cogDisp3.Size = new System.Drawing.Size(194, 203);
            this.cogDisp3.TabIndex = 158;
            // 
            // cogDisp4
            // 
            this.cogDisp4.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp4.ColorMapLowerRoiLimit = 0D;
            this.cogDisp4.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp4.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp4.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp4, 3);
            this.cogDisp4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp4.DoubleTapZoomCycleLength = 2;
            this.cogDisp4.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp4.Location = new System.Drawing.Point(603, 3);
            this.cogDisp4.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp4.MouseWheelSensitivity = 1D;
            this.cogDisp4.Name = "cogDisp4";
            this.cogDisp4.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp4.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp4, 0);
            this.cogDisp4.Size = new System.Drawing.Size(194, 203);
            this.cogDisp4.TabIndex = 157;
            // 
            // cogDisp5
            // 
            this.cogDisp5.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp5.ColorMapLowerRoiLimit = 0D;
            this.cogDisp5.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp5.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp5.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp5, 4);
            this.cogDisp5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp5.DoubleTapZoomCycleLength = 2;
            this.cogDisp5.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp5.Location = new System.Drawing.Point(803, 3);
            this.cogDisp5.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp5.MouseWheelSensitivity = 1D;
            this.cogDisp5.Name = "cogDisp5";
            this.cogDisp5.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp5.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp5, 0);
            this.cogDisp5.Size = new System.Drawing.Size(194, 203);
            this.cogDisp5.TabIndex = 156;
            // 
            // cogDisp6
            // 
            this.cogDisp6.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp6.ColorMapLowerRoiLimit = 0D;
            this.cogDisp6.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp6.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp6.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp6, 5);
            this.cogDisp6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp6.DoubleTapZoomCycleLength = 2;
            this.cogDisp6.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp6.Location = new System.Drawing.Point(1003, 3);
            this.cogDisp6.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp6.MouseWheelSensitivity = 1D;
            this.cogDisp6.Name = "cogDisp6";
            this.cogDisp6.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp6.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp6, 0);
            this.cogDisp6.Size = new System.Drawing.Size(194, 203);
            this.cogDisp6.TabIndex = 155;
            // 
            // cogDisp7
            // 
            this.cogDisp7.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp7.ColorMapLowerRoiLimit = 0D;
            this.cogDisp7.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp7.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp7.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp7, 6);
            this.cogDisp7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp7.DoubleTapZoomCycleLength = 2;
            this.cogDisp7.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp7.Location = new System.Drawing.Point(1203, 3);
            this.cogDisp7.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp7.MouseWheelSensitivity = 1D;
            this.cogDisp7.Name = "cogDisp7";
            this.cogDisp7.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp7.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp7, 0);
            this.cogDisp7.Size = new System.Drawing.Size(194, 203);
            this.cogDisp7.TabIndex = 154;
            // 
            // cogDisp8
            // 
            this.cogDisp8.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp8.ColorMapLowerRoiLimit = 0D;
            this.cogDisp8.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp8.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp8.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp8, 7);
            this.cogDisp8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp8.DoubleTapZoomCycleLength = 2;
            this.cogDisp8.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp8.Location = new System.Drawing.Point(1403, 3);
            this.cogDisp8.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp8.MouseWheelSensitivity = 1D;
            this.cogDisp8.Name = "cogDisp8";
            this.cogDisp8.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp8.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp8, 0);
            this.cogDisp8.Size = new System.Drawing.Size(194, 203);
            this.cogDisp8.TabIndex = 153;
            // 
            // cogDisp9
            // 
            this.cogDisp9.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp9.ColorMapLowerRoiLimit = 0D;
            this.cogDisp9.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp9.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp9.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp9, 8);
            this.cogDisp9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp9.DoubleTapZoomCycleLength = 2;
            this.cogDisp9.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp9.Location = new System.Drawing.Point(1603, 3);
            this.cogDisp9.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp9.MouseWheelSensitivity = 1D;
            this.cogDisp9.Name = "cogDisp9";
            this.cogDisp9.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp9.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp9, 0);
            this.cogDisp9.Size = new System.Drawing.Size(194, 203);
            this.cogDisp9.TabIndex = 152;
            // 
            // cogDisp10
            // 
            this.cogDisp10.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp10.ColorMapLowerRoiLimit = 0D;
            this.cogDisp10.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp10.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp10.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp10, 9);
            this.cogDisp10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp10.DoubleTapZoomCycleLength = 2;
            this.cogDisp10.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp10.Location = new System.Drawing.Point(1803, 3);
            this.cogDisp10.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp10.MouseWheelSensitivity = 1D;
            this.cogDisp10.Name = "cogDisp10";
            this.cogDisp10.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp10.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp10, 0);
            this.cogDisp10.Size = new System.Drawing.Size(194, 203);
            this.cogDisp10.TabIndex = 151;
            // 
            // cogDisp11
            // 
            this.cogDisp11.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp11.ColorMapLowerRoiLimit = 0D;
            this.cogDisp11.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp11.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp11.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp11, 10);
            this.cogDisp11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp11.DoubleTapZoomCycleLength = 2;
            this.cogDisp11.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp11.Location = new System.Drawing.Point(2003, 3);
            this.cogDisp11.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp11.MouseWheelSensitivity = 1D;
            this.cogDisp11.Name = "cogDisp11";
            this.cogDisp11.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp11.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp11, 0);
            this.cogDisp11.Size = new System.Drawing.Size(194, 203);
            this.cogDisp11.TabIndex = 150;
            // 
            // cogDisp12
            // 
            this.cogDisp12.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp12.ColorMapLowerRoiLimit = 0D;
            this.cogDisp12.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp12.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp12.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp12, 11);
            this.cogDisp12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp12.DoubleTapZoomCycleLength = 2;
            this.cogDisp12.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp12.Location = new System.Drawing.Point(2203, 3);
            this.cogDisp12.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp12.MouseWheelSensitivity = 1D;
            this.cogDisp12.Name = "cogDisp12";
            this.cogDisp12.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp12.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp12, 0);
            this.cogDisp12.Size = new System.Drawing.Size(194, 203);
            this.cogDisp12.TabIndex = 149;
            // 
            // cogDisp13
            // 
            this.cogDisp13.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp13.ColorMapLowerRoiLimit = 0D;
            this.cogDisp13.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp13.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp13.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp13, 12);
            this.cogDisp13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp13.DoubleTapZoomCycleLength = 2;
            this.cogDisp13.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp13.Location = new System.Drawing.Point(2403, 3);
            this.cogDisp13.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp13.MouseWheelSensitivity = 1D;
            this.cogDisp13.Name = "cogDisp13";
            this.cogDisp13.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp13.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp13, 0);
            this.cogDisp13.Size = new System.Drawing.Size(194, 203);
            this.cogDisp13.TabIndex = 148;
            // 
            // cogDisp14
            // 
            this.cogDisp14.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp14.ColorMapLowerRoiLimit = 0D;
            this.cogDisp14.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp14.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp14.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp14, 13);
            this.cogDisp14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp14.DoubleTapZoomCycleLength = 2;
            this.cogDisp14.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp14.Location = new System.Drawing.Point(2603, 3);
            this.cogDisp14.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp14.MouseWheelSensitivity = 1D;
            this.cogDisp14.Name = "cogDisp14";
            this.cogDisp14.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp14.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp14, 0);
            this.cogDisp14.Size = new System.Drawing.Size(194, 203);
            this.cogDisp14.TabIndex = 147;
            // 
            // cogDisp15
            // 
            this.cogDisp15.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp15.ColorMapLowerRoiLimit = 0D;
            this.cogDisp15.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp15.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp15.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp15, 14);
            this.cogDisp15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp15.DoubleTapZoomCycleLength = 2;
            this.cogDisp15.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp15.Location = new System.Drawing.Point(2803, 3);
            this.cogDisp15.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp15.MouseWheelSensitivity = 1D;
            this.cogDisp15.Name = "cogDisp15";
            this.cogDisp15.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp15.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp15, 0);
            this.cogDisp15.Size = new System.Drawing.Size(194, 203);
            this.cogDisp15.TabIndex = 146;
            // 
            // cogDisp16
            // 
            this.cogDisp16.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp16.ColorMapLowerRoiLimit = 0D;
            this.cogDisp16.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp16.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp16.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp16, 15);
            this.cogDisp16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp16.DoubleTapZoomCycleLength = 2;
            this.cogDisp16.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp16.Location = new System.Drawing.Point(3003, 3);
            this.cogDisp16.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp16.MouseWheelSensitivity = 1D;
            this.cogDisp16.Name = "cogDisp16";
            this.cogDisp16.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp16.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp16, 0);
            this.cogDisp16.Size = new System.Drawing.Size(194, 203);
            this.cogDisp16.TabIndex = 145;
            // 
            // cogDisp17
            // 
            this.cogDisp17.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp17.ColorMapLowerRoiLimit = 0D;
            this.cogDisp17.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp17.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp17.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp17, 16);
            this.cogDisp17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp17.DoubleTapZoomCycleLength = 2;
            this.cogDisp17.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp17.Location = new System.Drawing.Point(3203, 3);
            this.cogDisp17.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp17.MouseWheelSensitivity = 1D;
            this.cogDisp17.Name = "cogDisp17";
            this.cogDisp17.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp17.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp17, 0);
            this.cogDisp17.Size = new System.Drawing.Size(194, 203);
            this.cogDisp17.TabIndex = 144;
            // 
            // cogDisp18
            // 
            this.cogDisp18.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp18.ColorMapLowerRoiLimit = 0D;
            this.cogDisp18.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp18.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp18.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp18, 17);
            this.cogDisp18.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp18.DoubleTapZoomCycleLength = 2;
            this.cogDisp18.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp18.Location = new System.Drawing.Point(3403, 3);
            this.cogDisp18.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp18.MouseWheelSensitivity = 1D;
            this.cogDisp18.Name = "cogDisp18";
            this.cogDisp18.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp18.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp18, 0);
            this.cogDisp18.Size = new System.Drawing.Size(194, 203);
            this.cogDisp18.TabIndex = 143;
            // 
            // cogDisp19
            // 
            this.cogDisp19.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp19.ColorMapLowerRoiLimit = 0D;
            this.cogDisp19.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp19.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp19.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp19, 18);
            this.cogDisp19.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp19.DoubleTapZoomCycleLength = 2;
            this.cogDisp19.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp19.Location = new System.Drawing.Point(3603, 3);
            this.cogDisp19.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp19.MouseWheelSensitivity = 1D;
            this.cogDisp19.Name = "cogDisp19";
            this.cogDisp19.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp19.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp19, 0);
            this.cogDisp19.Size = new System.Drawing.Size(194, 203);
            this.cogDisp19.TabIndex = 142;
            // 
            // cogDisp20
            // 
            this.cogDisp20.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp20.ColorMapLowerRoiLimit = 0D;
            this.cogDisp20.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp20.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp20.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp20, 19);
            this.cogDisp20.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp20.DoubleTapZoomCycleLength = 2;
            this.cogDisp20.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp20.Location = new System.Drawing.Point(3803, 3);
            this.cogDisp20.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp20.MouseWheelSensitivity = 1D;
            this.cogDisp20.Name = "cogDisp20";
            this.cogDisp20.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp20.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp20, 0);
            this.cogDisp20.Size = new System.Drawing.Size(194, 203);
            this.cogDisp20.TabIndex = 141;
            // 
            // flySetting
            // 
            this.flySetting.AutoSize = true;
            this.flySetting.Controls.Add(this.flyoutPanelControl14);
            this.flySetting.Location = new System.Drawing.Point(6, 563);
            this.flySetting.Name = "flySetting";
            this.flySetting.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Center;
            this.flySetting.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flySetting.Options.CloseOnHidingOwner = false;
            this.flySetting.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flySetting.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flySetting.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flySetting.OwnerControl = this;
            this.flySetting.Size = new System.Drawing.Size(553, 337);
            this.flySetting.TabIndex = 134;
            // 
            // flyoutPanelControl14
            // 
            this.flyoutPanelControl14.Controls.Add(this.labelControl55);
            this.flyoutPanelControl14.Controls.Add(this.lblDLpath);
            this.flyoutPanelControl14.Controls.Add(this.labelControl48);
            this.flyoutPanelControl14.Controls.Add(this.groupControl3);
            this.flyoutPanelControl14.Controls.Add(this.simpleButton1);
            this.flyoutPanelControl14.Controls.Add(this.groupControl14);
            this.flyoutPanelControl14.Controls.Add(this.btnUserManage);
            this.flyoutPanelControl14.Controls.Add(this.labelControl118);
            this.flyoutPanelControl14.Controls.Add(this.btnSetClose);
            this.flyoutPanelControl14.Controls.Add(this.btnSetSave);
            this.flyoutPanelControl14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl14.FlyoutPanel = this.flySetting;
            this.flyoutPanelControl14.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl14.Name = "flyoutPanelControl14";
            this.flyoutPanelControl14.Size = new System.Drawing.Size(553, 337);
            this.flyoutPanelControl14.TabIndex = 0;
            // 
            // labelControl55
            // 
            this.labelControl55.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl55.Appearance.Options.UseFont = true;
            this.labelControl55.Appearance.Options.UseTextOptions = true;
            this.labelControl55.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl55.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl55.Location = new System.Drawing.Point(0, 601);
            this.labelControl55.Name = "labelControl55";
            this.labelControl55.Size = new System.Drawing.Size(73, 19);
            this.labelControl55.TabIndex = 35;
            this.labelControl55.Text = "DL File : ";
            this.labelControl55.Visible = false;
            // 
            // lblDLpath
            // 
            this.lblDLpath.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblDLpath.Appearance.Options.UseFont = true;
            this.lblDLpath.Appearance.Options.UseTextOptions = true;
            this.lblDLpath.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblDLpath.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblDLpath.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblDLpath.Location = new System.Drawing.Point(75, 565);
            this.lblDLpath.Name = "lblDLpath";
            this.lblDLpath.Size = new System.Drawing.Size(435, 28);
            this.lblDLpath.TabIndex = 33;
            this.lblDLpath.Text = "-";
            this.lblDLpath.Visible = false;
            // 
            // labelControl48
            // 
            this.labelControl48.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl48.Appearance.Options.UseFont = true;
            this.labelControl48.Appearance.Options.UseTextOptions = true;
            this.labelControl48.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl48.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl48.Location = new System.Drawing.Point(0, 568);
            this.labelControl48.Name = "labelControl48";
            this.labelControl48.Size = new System.Drawing.Size(73, 19);
            this.labelControl48.TabIndex = 32;
            this.labelControl48.Text = "DL Path : ";
            this.labelControl48.Visible = false;
            // 
            // groupControl3
            // 
            this.groupControl3.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl3.AppearanceCaption.Options.UseFont = true;
            this.groupControl3.Controls.Add(this.labelControl35);
            this.groupControl3.Controls.Add(this.txtLineInfo);
            this.groupControl3.Controls.Add(this.labelControl72);
            this.groupControl3.Controls.Add(this.txtProcName);
            this.groupControl3.Location = new System.Drawing.Point(6, 33);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(540, 94);
            this.groupControl3.TabIndex = 28;
            this.groupControl3.Text = "Infomation";
            // 
            // labelControl35
            // 
            this.labelControl35.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl35.Appearance.Options.UseFont = true;
            this.labelControl35.Appearance.Options.UseTextOptions = true;
            this.labelControl35.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl35.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl35.Location = new System.Drawing.Point(10, 32);
            this.labelControl35.Name = "labelControl35";
            this.labelControl35.Size = new System.Drawing.Size(141, 19);
            this.labelControl35.TabIndex = 23;
            this.labelControl35.Text = "Line Name :";
            // 
            // txtLineInfo
            // 
            this.txtLineInfo.Location = new System.Drawing.Point(159, 30);
            this.txtLineInfo.Name = "txtLineInfo";
            this.txtLineInfo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtLineInfo.Properties.Appearance.Options.UseFont = true;
            this.txtLineInfo.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLineInfo.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLineInfo.Size = new System.Drawing.Size(264, 24);
            this.txtLineInfo.TabIndex = 0;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.Appearance.Options.UseTextOptions = true;
            this.simpleButton1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.simpleButton1.Location = new System.Drawing.Point(821, 805);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(38, 26);
            this.simpleButton1.TabIndex = 27;
            this.simpleButton1.Text = "...";
            this.simpleButton1.Visible = false;
            // 
            // groupControl14
            // 
            this.groupControl14.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl14.AppearanceCaption.Options.UseFont = true;
            this.groupControl14.Controls.Add(this.labelControl92);
            this.groupControl14.Controls.Add(this.txtDBName);
            this.groupControl14.Controls.Add(this.labelControl96);
            this.groupControl14.Controls.Add(this.labelControl101);
            this.groupControl14.Controls.Add(this.txtDBPW);
            this.groupControl14.Controls.Add(this.txtDBPort);
            this.groupControl14.Controls.Add(this.labelControl97);
            this.groupControl14.Controls.Add(this.labelControl102);
            this.groupControl14.Controls.Add(this.txtDBID);
            this.groupControl14.Controls.Add(this.txtDBIP);
            this.groupControl14.Location = new System.Drawing.Point(6, 132);
            this.groupControl14.Name = "groupControl14";
            this.groupControl14.Size = new System.Drawing.Size(540, 131);
            this.groupControl14.TabIndex = 26;
            this.groupControl14.Text = "Database Infomation";
            // 
            // labelControl92
            // 
            this.labelControl92.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl92.Appearance.Options.UseFont = true;
            this.labelControl92.Appearance.Options.UseTextOptions = true;
            this.labelControl92.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl92.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl92.Location = new System.Drawing.Point(10, 99);
            this.labelControl92.Name = "labelControl92";
            this.labelControl92.Size = new System.Drawing.Size(77, 19);
            this.labelControl92.TabIndex = 27;
            this.labelControl92.Text = "DB Name :";
            // 
            // txtDBName
            // 
            this.txtDBName.Location = new System.Drawing.Point(95, 95);
            this.txtDBName.Name = "txtDBName";
            this.txtDBName.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDBName.Properties.Appearance.Options.UseFont = true;
            this.txtDBName.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBName.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDBName.Size = new System.Drawing.Size(146, 24);
            this.txtDBName.TabIndex = 4;
            // 
            // labelControl96
            // 
            this.labelControl96.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl96.Appearance.Options.UseFont = true;
            this.labelControl96.Appearance.Options.UseTextOptions = true;
            this.labelControl96.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl96.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl96.Location = new System.Drawing.Point(272, 65);
            this.labelControl96.Name = "labelControl96";
            this.labelControl96.Size = new System.Drawing.Size(85, 19);
            this.labelControl96.TabIndex = 25;
            this.labelControl96.Text = "Password :";
            // 
            // labelControl101
            // 
            this.labelControl101.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl101.Appearance.Options.UseFont = true;
            this.labelControl101.Appearance.Options.UseTextOptions = true;
            this.labelControl101.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl101.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl101.Location = new System.Drawing.Point(306, 33);
            this.labelControl101.Name = "labelControl101";
            this.labelControl101.Size = new System.Drawing.Size(49, 19);
            this.labelControl101.TabIndex = 19;
            this.labelControl101.Text = "Port :";
            // 
            // txtDBPW
            // 
            this.txtDBPW.Location = new System.Drawing.Point(366, 62);
            this.txtDBPW.Name = "txtDBPW";
            this.txtDBPW.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDBPW.Properties.Appearance.Options.UseFont = true;
            this.txtDBPW.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBPW.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDBPW.Properties.PasswordChar = '*';
            this.txtDBPW.Size = new System.Drawing.Size(124, 24);
            this.txtDBPW.TabIndex = 3;
            // 
            // txtDBPort
            // 
            this.txtDBPort.Location = new System.Drawing.Point(366, 30);
            this.txtDBPort.Name = "txtDBPort";
            this.txtDBPort.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDBPort.Properties.Appearance.Options.UseFont = true;
            this.txtDBPort.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBPort.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDBPort.Size = new System.Drawing.Size(124, 24);
            this.txtDBPort.TabIndex = 1;
            // 
            // labelControl97
            // 
            this.labelControl97.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl97.Appearance.Options.UseFont = true;
            this.labelControl97.Appearance.Options.UseTextOptions = true;
            this.labelControl97.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl97.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl97.Location = new System.Drawing.Point(10, 65);
            this.labelControl97.Name = "labelControl97";
            this.labelControl97.Size = new System.Drawing.Size(77, 19);
            this.labelControl97.TabIndex = 23;
            this.labelControl97.Text = "DB ID :";
            // 
            // labelControl102
            // 
            this.labelControl102.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl102.Appearance.Options.UseFont = true;
            this.labelControl102.Appearance.Options.UseTextOptions = true;
            this.labelControl102.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl102.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl102.Location = new System.Drawing.Point(53, 33);
            this.labelControl102.Name = "labelControl102";
            this.labelControl102.Size = new System.Drawing.Size(33, 19);
            this.labelControl102.TabIndex = 17;
            this.labelControl102.Text = "IP :";
            // 
            // txtDBID
            // 
            this.txtDBID.Location = new System.Drawing.Point(95, 62);
            this.txtDBID.Name = "txtDBID";
            this.txtDBID.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDBID.Properties.Appearance.Options.UseFont = true;
            this.txtDBID.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBID.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDBID.Size = new System.Drawing.Size(146, 24);
            this.txtDBID.TabIndex = 2;
            // 
            // txtDBIP
            // 
            this.txtDBIP.Location = new System.Drawing.Point(95, 30);
            this.txtDBIP.Name = "txtDBIP";
            this.txtDBIP.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtDBIP.Properties.Appearance.Options.UseFont = true;
            this.txtDBIP.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDBIP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtDBIP.Size = new System.Drawing.Size(187, 24);
            this.txtDBIP.TabIndex = 0;
            // 
            // labelControl118
            // 
            this.labelControl118.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl118.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl118.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl118.Appearance.Options.UseBackColor = true;
            this.labelControl118.Appearance.Options.UseFont = true;
            this.labelControl118.Appearance.Options.UseForeColor = true;
            this.labelControl118.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl118.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl118.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl118.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("labelControl118.ImageOptions.Image")));
            this.labelControl118.Location = new System.Drawing.Point(2, 2);
            this.labelControl118.Name = "labelControl118";
            this.labelControl118.Size = new System.Drawing.Size(549, 26);
            this.labelControl118.TabIndex = 16;
            this.labelControl118.Text = "Setting";
            // 
            // btnSetClose
            // 
            this.btnSetClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSetClose.Appearance.Options.UseFont = true;
            this.btnSetClose.Appearance.Options.UseTextOptions = true;
            this.btnSetClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSetClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetClose.ImageOptions.Image")));
            this.btnSetClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSetClose.Location = new System.Drawing.Point(334, 277);
            this.btnSetClose.Name = "btnSetClose";
            this.btnSetClose.Size = new System.Drawing.Size(114, 47);
            this.btnSetClose.TabIndex = 2;
            this.btnSetClose.Text = "Close";
            this.btnSetClose.Click += new System.EventHandler(this.btnSetClose_Click);
            // 
            // btnSetSave
            // 
            this.btnSetSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnSetSave.Appearance.Options.UseFont = true;
            this.btnSetSave.Appearance.Options.UseTextOptions = true;
            this.btnSetSave.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnSetSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSetSave.ImageOptions.Image")));
            this.btnSetSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSetSave.Location = new System.Drawing.Point(213, 277);
            this.btnSetSave.Name = "btnSetSave";
            this.btnSetSave.Size = new System.Drawing.Size(114, 47);
            this.btnSetSave.TabIndex = 1;
            this.btnSetSave.Text = "Save";
            this.btnSetSave.Click += new System.EventHandler(this.btnSetSave_Click);
            // 
            // flyIO
            // 
            this.flyIO.AutoSize = true;
            this.flyIO.Controls.Add(this.flyoutPanelControl6);
            this.flyIO.Location = new System.Drawing.Point(1206, 601);
            this.flyIO.Name = "flyIO";
            this.flyIO.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyIO.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyIO.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyIO.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyIO.OwnerControl = this.btnIOSetting;
            this.flyIO.Size = new System.Drawing.Size(678, 644);
            this.flyIO.TabIndex = 140;
            // 
            // flyoutPanelControl6
            // 
            this.flyoutPanelControl6.Controls.Add(this.groupControl7);
            this.flyoutPanelControl6.Controls.Add(this.btnIOClose);
            this.flyoutPanelControl6.Controls.Add(this.btnIOSave);
            this.flyoutPanelControl6.Controls.Add(this.groupControl6);
            this.flyoutPanelControl6.Controls.Add(this.groupControl5);
            this.flyoutPanelControl6.Controls.Add(this.cbIODev);
            this.flyoutPanelControl6.Controls.Add(this.toggleSwitch2);
            this.flyoutPanelControl6.Controls.Add(this.labelControl34);
            this.flyoutPanelControl6.Controls.Add(this.textEdit6);
            this.flyoutPanelControl6.Controls.Add(this.labelControl36);
            this.flyoutPanelControl6.Controls.Add(this.timeEdit1);
            this.flyoutPanelControl6.Controls.Add(this.labelControl38);
            this.flyoutPanelControl6.Controls.Add(this.labelControl41);
            this.flyoutPanelControl6.Controls.Add(this.labelControl44);
            this.flyoutPanelControl6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl6.FlyoutPanel = this.flyIO;
            this.flyoutPanelControl6.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl6.Name = "flyoutPanelControl6";
            this.flyoutPanelControl6.Size = new System.Drawing.Size(678, 644);
            this.flyoutPanelControl6.TabIndex = 0;
            // 
            // groupControl7
            // 
            this.groupControl7.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl7.AppearanceCaption.ForeColor = System.Drawing.Color.Salmon;
            this.groupControl7.AppearanceCaption.Options.UseFont = true;
            this.groupControl7.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl7.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl7.CaptionImageOptions.SvgImage")));
            this.groupControl7.Controls.Add(this.tablePanel4);
            this.groupControl7.Location = new System.Drawing.Point(8, 75);
            this.groupControl7.Name = "groupControl7";
            this.groupControl7.Size = new System.Drawing.Size(662, 499);
            this.groupControl7.TabIndex = 54;
            this.groupControl7.Text = "IO Status";
            // 
            // tablePanel4
            // 
            this.tablePanel4.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel4.Controls.Add(this.lblOutStatus16);
            this.tablePanel4.Controls.Add(this.lblOutStatus15);
            this.tablePanel4.Controls.Add(this.lblOutStatus14);
            this.tablePanel4.Controls.Add(this.lblOutStatus13);
            this.tablePanel4.Controls.Add(this.lblOutStatus12);
            this.tablePanel4.Controls.Add(this.lblOutStatus11);
            this.tablePanel4.Controls.Add(this.lblOutStatus10);
            this.tablePanel4.Controls.Add(this.lblOutStatus9);
            this.tablePanel4.Controls.Add(this.lblOutStatus8);
            this.tablePanel4.Controls.Add(this.lblOutStatus7);
            this.tablePanel4.Controls.Add(this.lblOutStatus6);
            this.tablePanel4.Controls.Add(this.lblOutStatus5);
            this.tablePanel4.Controls.Add(this.lblOutStatus4);
            this.tablePanel4.Controls.Add(this.lblOutStatus3);
            this.tablePanel4.Controls.Add(this.lblOutStatus2);
            this.tablePanel4.Controls.Add(this.lblOutStatus1);
            this.tablePanel4.Controls.Add(this.lblIOOUT_16);
            this.tablePanel4.Controls.Add(this.lblIOOUT_15);
            this.tablePanel4.Controls.Add(this.lblIOOUT_14);
            this.tablePanel4.Controls.Add(this.lblIOOUT_13);
            this.tablePanel4.Controls.Add(this.lblIOOUT_12);
            this.tablePanel4.Controls.Add(this.lblIOOUT_11);
            this.tablePanel4.Controls.Add(this.lblIOOUT_10);
            this.tablePanel4.Controls.Add(this.lblIOOUT_9);
            this.tablePanel4.Controls.Add(this.lblIOOUT_8);
            this.tablePanel4.Controls.Add(this.lblIOOUT_7);
            this.tablePanel4.Controls.Add(this.lblIOOUT_6);
            this.tablePanel4.Controls.Add(this.lblIOOUT_5);
            this.tablePanel4.Controls.Add(this.lblIOOUT_4);
            this.tablePanel4.Controls.Add(this.lblIOOUT_3);
            this.tablePanel4.Controls.Add(this.lblIOOUT_2);
            this.tablePanel4.Controls.Add(this.lblIOOUT_1);
            this.tablePanel4.Controls.Add(this.lblInStatus16);
            this.tablePanel4.Controls.Add(this.lblInStatus15);
            this.tablePanel4.Controls.Add(this.lblInStatus14);
            this.tablePanel4.Controls.Add(this.lblInStatus13);
            this.tablePanel4.Controls.Add(this.lblInStatus12);
            this.tablePanel4.Controls.Add(this.lblInStatus11);
            this.tablePanel4.Controls.Add(this.lblInStatus10);
            this.tablePanel4.Controls.Add(this.lblInStatus9);
            this.tablePanel4.Controls.Add(this.lblInStatus8);
            this.tablePanel4.Controls.Add(this.lblInStatus7);
            this.tablePanel4.Controls.Add(this.lblInStatus6);
            this.tablePanel4.Controls.Add(this.lblInStatus5);
            this.tablePanel4.Controls.Add(this.lblInStatus4);
            this.tablePanel4.Controls.Add(this.lblInStatus3);
            this.tablePanel4.Controls.Add(this.lblInStatus2);
            this.tablePanel4.Controls.Add(this.lblIOIN_16);
            this.tablePanel4.Controls.Add(this.lblIOIN_15);
            this.tablePanel4.Controls.Add(this.lblIOIN_14);
            this.tablePanel4.Controls.Add(this.lblIOIN_13);
            this.tablePanel4.Controls.Add(this.lblIOIN_12);
            this.tablePanel4.Controls.Add(this.lblIOIN_11);
            this.tablePanel4.Controls.Add(this.lblIOIN_10);
            this.tablePanel4.Controls.Add(this.lblIOIN_9);
            this.tablePanel4.Controls.Add(this.lblIOIN_8);
            this.tablePanel4.Controls.Add(this.lblIOIN_7);
            this.tablePanel4.Controls.Add(this.lblIOIN_6);
            this.tablePanel4.Controls.Add(this.lblIOIN_5);
            this.tablePanel4.Controls.Add(this.lblIOIN_4);
            this.tablePanel4.Controls.Add(this.lblIOIN_3);
            this.tablePanel4.Controls.Add(this.lblIOIN_2);
            this.tablePanel4.Controls.Add(this.lblInStatus1);
            this.tablePanel4.Controls.Add(this.lblIOIN_1);
            this.tablePanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel4.Location = new System.Drawing.Point(2, 33);
            this.tablePanel4.Name = "tablePanel4";
            this.tablePanel4.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 100F)});
            this.tablePanel4.Size = new System.Drawing.Size(658, 464);
            this.tablePanel4.TabIndex = 0;
            // 
            // lblOutStatus16
            // 
            this.lblOutStatus16.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus16.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus16.Appearance.Options.UseBackColor = true;
            this.lblOutStatus16.Appearance.Options.UseFont = true;
            this.lblOutStatus16.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus16.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus16, 3);
            this.lblOutStatus16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus16.Location = new System.Drawing.Point(497, 438);
            this.lblOutStatus16.Name = "lblOutStatus16";
            this.tablePanel4.SetRow(this.lblOutStatus16, 15);
            this.lblOutStatus16.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus16.TabIndex = 121;
            this.lblOutStatus16.Text = "OFF";
            this.lblOutStatus16.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus15
            // 
            this.lblOutStatus15.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus15.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus15.Appearance.Options.UseBackColor = true;
            this.lblOutStatus15.Appearance.Options.UseFont = true;
            this.lblOutStatus15.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus15.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus15, 3);
            this.lblOutStatus15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus15.Location = new System.Drawing.Point(497, 409);
            this.lblOutStatus15.Name = "lblOutStatus15";
            this.tablePanel4.SetRow(this.lblOutStatus15, 14);
            this.lblOutStatus15.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus15.TabIndex = 120;
            this.lblOutStatus15.Text = "OFF";
            this.lblOutStatus15.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus14
            // 
            this.lblOutStatus14.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus14.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus14.Appearance.Options.UseBackColor = true;
            this.lblOutStatus14.Appearance.Options.UseFont = true;
            this.lblOutStatus14.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus14, 3);
            this.lblOutStatus14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus14.Location = new System.Drawing.Point(497, 380);
            this.lblOutStatus14.Name = "lblOutStatus14";
            this.tablePanel4.SetRow(this.lblOutStatus14, 13);
            this.lblOutStatus14.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus14.TabIndex = 119;
            this.lblOutStatus14.Text = "OFF";
            this.lblOutStatus14.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus13
            // 
            this.lblOutStatus13.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus13.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus13.Appearance.Options.UseBackColor = true;
            this.lblOutStatus13.Appearance.Options.UseFont = true;
            this.lblOutStatus13.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus13, 3);
            this.lblOutStatus13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus13.Location = new System.Drawing.Point(497, 351);
            this.lblOutStatus13.Name = "lblOutStatus13";
            this.tablePanel4.SetRow(this.lblOutStatus13, 12);
            this.lblOutStatus13.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus13.TabIndex = 118;
            this.lblOutStatus13.Text = "OFF";
            this.lblOutStatus13.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus12
            // 
            this.lblOutStatus12.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus12.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus12.Appearance.Options.UseBackColor = true;
            this.lblOutStatus12.Appearance.Options.UseFont = true;
            this.lblOutStatus12.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus12, 3);
            this.lblOutStatus12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus12.Location = new System.Drawing.Point(497, 322);
            this.lblOutStatus12.Name = "lblOutStatus12";
            this.tablePanel4.SetRow(this.lblOutStatus12, 11);
            this.lblOutStatus12.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus12.TabIndex = 117;
            this.lblOutStatus12.Text = "OFF";
            this.lblOutStatus12.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus11
            // 
            this.lblOutStatus11.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus11.Appearance.Options.UseBackColor = true;
            this.lblOutStatus11.Appearance.Options.UseFont = true;
            this.lblOutStatus11.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus11, 3);
            this.lblOutStatus11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus11.Location = new System.Drawing.Point(497, 293);
            this.lblOutStatus11.Name = "lblOutStatus11";
            this.tablePanel4.SetRow(this.lblOutStatus11, 10);
            this.lblOutStatus11.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus11.TabIndex = 116;
            this.lblOutStatus11.Text = "OFF";
            this.lblOutStatus11.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus10
            // 
            this.lblOutStatus10.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus10.Appearance.Options.UseBackColor = true;
            this.lblOutStatus10.Appearance.Options.UseFont = true;
            this.lblOutStatus10.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus10, 3);
            this.lblOutStatus10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus10.Location = new System.Drawing.Point(497, 264);
            this.lblOutStatus10.Name = "lblOutStatus10";
            this.tablePanel4.SetRow(this.lblOutStatus10, 9);
            this.lblOutStatus10.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus10.TabIndex = 115;
            this.lblOutStatus10.Text = "OFF";
            this.lblOutStatus10.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus9
            // 
            this.lblOutStatus9.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus9.Appearance.Options.UseBackColor = true;
            this.lblOutStatus9.Appearance.Options.UseFont = true;
            this.lblOutStatus9.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus9, 3);
            this.lblOutStatus9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus9.Location = new System.Drawing.Point(497, 235);
            this.lblOutStatus9.Name = "lblOutStatus9";
            this.tablePanel4.SetRow(this.lblOutStatus9, 8);
            this.lblOutStatus9.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus9.TabIndex = 114;
            this.lblOutStatus9.Text = "OFF";
            this.lblOutStatus9.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus8
            // 
            this.lblOutStatus8.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus8.Appearance.Options.UseBackColor = true;
            this.lblOutStatus8.Appearance.Options.UseFont = true;
            this.lblOutStatus8.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus8, 3);
            this.lblOutStatus8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus8.Location = new System.Drawing.Point(497, 206);
            this.lblOutStatus8.Name = "lblOutStatus8";
            this.tablePanel4.SetRow(this.lblOutStatus8, 7);
            this.lblOutStatus8.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus8.TabIndex = 113;
            this.lblOutStatus8.Text = "OFF";
            this.lblOutStatus8.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus7
            // 
            this.lblOutStatus7.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus7.Appearance.Options.UseBackColor = true;
            this.lblOutStatus7.Appearance.Options.UseFont = true;
            this.lblOutStatus7.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus7, 3);
            this.lblOutStatus7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus7.Location = new System.Drawing.Point(497, 177);
            this.lblOutStatus7.Name = "lblOutStatus7";
            this.tablePanel4.SetRow(this.lblOutStatus7, 6);
            this.lblOutStatus7.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus7.TabIndex = 112;
            this.lblOutStatus7.Text = "OFF";
            this.lblOutStatus7.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus6
            // 
            this.lblOutStatus6.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus6.Appearance.Options.UseBackColor = true;
            this.lblOutStatus6.Appearance.Options.UseFont = true;
            this.lblOutStatus6.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus6, 3);
            this.lblOutStatus6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus6.Location = new System.Drawing.Point(497, 148);
            this.lblOutStatus6.Name = "lblOutStatus6";
            this.tablePanel4.SetRow(this.lblOutStatus6, 5);
            this.lblOutStatus6.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus6.TabIndex = 111;
            this.lblOutStatus6.Text = "OFF";
            this.lblOutStatus6.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus5
            // 
            this.lblOutStatus5.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus5.Appearance.Options.UseBackColor = true;
            this.lblOutStatus5.Appearance.Options.UseFont = true;
            this.lblOutStatus5.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus5, 3);
            this.lblOutStatus5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus5.Location = new System.Drawing.Point(497, 119);
            this.lblOutStatus5.Name = "lblOutStatus5";
            this.tablePanel4.SetRow(this.lblOutStatus5, 4);
            this.lblOutStatus5.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus5.TabIndex = 110;
            this.lblOutStatus5.Text = "OFF";
            this.lblOutStatus5.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus4
            // 
            this.lblOutStatus4.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus4.Appearance.Options.UseBackColor = true;
            this.lblOutStatus4.Appearance.Options.UseFont = true;
            this.lblOutStatus4.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus4, 3);
            this.lblOutStatus4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus4.Location = new System.Drawing.Point(497, 90);
            this.lblOutStatus4.Name = "lblOutStatus4";
            this.tablePanel4.SetRow(this.lblOutStatus4, 3);
            this.lblOutStatus4.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus4.TabIndex = 109;
            this.lblOutStatus4.Text = "OFF";
            this.lblOutStatus4.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus3
            // 
            this.lblOutStatus3.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus3.Appearance.Options.UseBackColor = true;
            this.lblOutStatus3.Appearance.Options.UseFont = true;
            this.lblOutStatus3.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus3, 3);
            this.lblOutStatus3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus3.Location = new System.Drawing.Point(497, 61);
            this.lblOutStatus3.Name = "lblOutStatus3";
            this.tablePanel4.SetRow(this.lblOutStatus3, 2);
            this.lblOutStatus3.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus3.TabIndex = 108;
            this.lblOutStatus3.Text = "OFF";
            this.lblOutStatus3.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus2
            // 
            this.lblOutStatus2.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus2.Appearance.Options.UseBackColor = true;
            this.lblOutStatus2.Appearance.Options.UseFont = true;
            this.lblOutStatus2.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus2, 3);
            this.lblOutStatus2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus2.Location = new System.Drawing.Point(497, 32);
            this.lblOutStatus2.Name = "lblOutStatus2";
            this.tablePanel4.SetRow(this.lblOutStatus2, 1);
            this.lblOutStatus2.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus2.TabIndex = 107;
            this.lblOutStatus2.Text = "OFF";
            this.lblOutStatus2.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblOutStatus1
            // 
            this.lblOutStatus1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblOutStatus1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblOutStatus1.Appearance.Options.UseBackColor = true;
            this.lblOutStatus1.Appearance.Options.UseFont = true;
            this.lblOutStatus1.Appearance.Options.UseTextOptions = true;
            this.lblOutStatus1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblOutStatus1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblOutStatus1, 3);
            this.lblOutStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblOutStatus1.Location = new System.Drawing.Point(497, 3);
            this.lblOutStatus1.Name = "lblOutStatus1";
            this.tablePanel4.SetRow(this.lblOutStatus1, 0);
            this.lblOutStatus1.Size = new System.Drawing.Size(159, 23);
            this.lblOutStatus1.TabIndex = 106;
            this.lblOutStatus1.Text = "OFF";
            this.lblOutStatus1.Click += new System.EventHandler(this.lblOutStatus1_Click);
            // 
            // lblIOOUT_16
            // 
            this.lblIOOUT_16.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_16.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_16.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_16.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_16.Appearance.Options.UseFont = true;
            this.lblIOOUT_16.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_16.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_16.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_16, 2);
            this.lblIOOUT_16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_16.Location = new System.Drawing.Point(332, 438);
            this.lblIOOUT_16.Name = "lblIOOUT_16";
            this.tablePanel4.SetRow(this.lblIOOUT_16, 15);
            this.lblIOOUT_16.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_16.TabIndex = 105;
            this.lblIOOUT_16.Tag = "15";
            this.lblIOOUT_16.Text = "OUT #16";
            // 
            // lblIOOUT_15
            // 
            this.lblIOOUT_15.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_15.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_15.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_15.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_15.Appearance.Options.UseFont = true;
            this.lblIOOUT_15.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_15.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_15.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_15, 2);
            this.lblIOOUT_15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_15.Location = new System.Drawing.Point(332, 409);
            this.lblIOOUT_15.Name = "lblIOOUT_15";
            this.tablePanel4.SetRow(this.lblIOOUT_15, 14);
            this.lblIOOUT_15.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_15.TabIndex = 104;
            this.lblIOOUT_15.Tag = "14";
            this.lblIOOUT_15.Text = "OUT #15";
            // 
            // lblIOOUT_14
            // 
            this.lblIOOUT_14.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_14.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_14.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_14.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_14.Appearance.Options.UseFont = true;
            this.lblIOOUT_14.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_14.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_14, 2);
            this.lblIOOUT_14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_14.Location = new System.Drawing.Point(332, 380);
            this.lblIOOUT_14.Name = "lblIOOUT_14";
            this.tablePanel4.SetRow(this.lblIOOUT_14, 13);
            this.lblIOOUT_14.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_14.TabIndex = 103;
            this.lblIOOUT_14.Tag = "13";
            this.lblIOOUT_14.Text = "OUT #14";
            // 
            // lblIOOUT_13
            // 
            this.lblIOOUT_13.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_13.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_13.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_13.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_13.Appearance.Options.UseFont = true;
            this.lblIOOUT_13.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_13.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_13, 2);
            this.lblIOOUT_13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_13.Location = new System.Drawing.Point(332, 351);
            this.lblIOOUT_13.Name = "lblIOOUT_13";
            this.tablePanel4.SetRow(this.lblIOOUT_13, 12);
            this.lblIOOUT_13.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_13.TabIndex = 102;
            this.lblIOOUT_13.Tag = "12";
            this.lblIOOUT_13.Text = "OUT #13";
            // 
            // lblIOOUT_12
            // 
            this.lblIOOUT_12.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_12.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_12.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_12.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_12.Appearance.Options.UseFont = true;
            this.lblIOOUT_12.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_12.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_12, 2);
            this.lblIOOUT_12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_12.Location = new System.Drawing.Point(332, 322);
            this.lblIOOUT_12.Name = "lblIOOUT_12";
            this.tablePanel4.SetRow(this.lblIOOUT_12, 11);
            this.lblIOOUT_12.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_12.TabIndex = 101;
            this.lblIOOUT_12.Tag = "11";
            this.lblIOOUT_12.Text = "OUT #12";
            // 
            // lblIOOUT_11
            // 
            this.lblIOOUT_11.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_11.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_11.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_11.Appearance.Options.UseFont = true;
            this.lblIOOUT_11.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_11.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_11, 2);
            this.lblIOOUT_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_11.Location = new System.Drawing.Point(332, 293);
            this.lblIOOUT_11.Name = "lblIOOUT_11";
            this.tablePanel4.SetRow(this.lblIOOUT_11, 10);
            this.lblIOOUT_11.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_11.TabIndex = 100;
            this.lblIOOUT_11.Tag = "10";
            this.lblIOOUT_11.Text = "OUT #11";
            // 
            // lblIOOUT_10
            // 
            this.lblIOOUT_10.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_10.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_10.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_10.Appearance.Options.UseFont = true;
            this.lblIOOUT_10.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_10.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_10, 2);
            this.lblIOOUT_10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_10.Location = new System.Drawing.Point(332, 264);
            this.lblIOOUT_10.Name = "lblIOOUT_10";
            this.tablePanel4.SetRow(this.lblIOOUT_10, 9);
            this.lblIOOUT_10.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_10.TabIndex = 99;
            this.lblIOOUT_10.Tag = "9";
            this.lblIOOUT_10.Text = "OUT #10";
            // 
            // lblIOOUT_9
            // 
            this.lblIOOUT_9.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_9.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_9.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_9.Appearance.Options.UseFont = true;
            this.lblIOOUT_9.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_9.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_9, 2);
            this.lblIOOUT_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_9.Location = new System.Drawing.Point(332, 235);
            this.lblIOOUT_9.Name = "lblIOOUT_9";
            this.tablePanel4.SetRow(this.lblIOOUT_9, 8);
            this.lblIOOUT_9.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_9.TabIndex = 98;
            this.lblIOOUT_9.Tag = "8";
            this.lblIOOUT_9.Text = "OUT #9";
            // 
            // lblIOOUT_8
            // 
            this.lblIOOUT_8.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_8.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_8.Appearance.Options.UseFont = true;
            this.lblIOOUT_8.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_8.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_8, 2);
            this.lblIOOUT_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_8.Location = new System.Drawing.Point(332, 206);
            this.lblIOOUT_8.Name = "lblIOOUT_8";
            this.tablePanel4.SetRow(this.lblIOOUT_8, 7);
            this.lblIOOUT_8.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_8.TabIndex = 97;
            this.lblIOOUT_8.Tag = "7";
            this.lblIOOUT_8.Text = "OUT #8";
            // 
            // lblIOOUT_7
            // 
            this.lblIOOUT_7.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_7.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_7.Appearance.Options.UseFont = true;
            this.lblIOOUT_7.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_7.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_7, 2);
            this.lblIOOUT_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_7.Location = new System.Drawing.Point(332, 177);
            this.lblIOOUT_7.Name = "lblIOOUT_7";
            this.tablePanel4.SetRow(this.lblIOOUT_7, 6);
            this.lblIOOUT_7.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_7.TabIndex = 96;
            this.lblIOOUT_7.Tag = "6";
            this.lblIOOUT_7.Text = "OUT #7";
            // 
            // lblIOOUT_6
            // 
            this.lblIOOUT_6.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_6.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_6.Appearance.Options.UseFont = true;
            this.lblIOOUT_6.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_6.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_6, 2);
            this.lblIOOUT_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_6.Location = new System.Drawing.Point(332, 148);
            this.lblIOOUT_6.Name = "lblIOOUT_6";
            this.tablePanel4.SetRow(this.lblIOOUT_6, 5);
            this.lblIOOUT_6.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_6.TabIndex = 95;
            this.lblIOOUT_6.Tag = "5";
            this.lblIOOUT_6.Text = "OUT #6";
            // 
            // lblIOOUT_5
            // 
            this.lblIOOUT_5.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_5.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_5.Appearance.Options.UseFont = true;
            this.lblIOOUT_5.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_5.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_5, 2);
            this.lblIOOUT_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_5.Location = new System.Drawing.Point(332, 119);
            this.lblIOOUT_5.Name = "lblIOOUT_5";
            this.tablePanel4.SetRow(this.lblIOOUT_5, 4);
            this.lblIOOUT_5.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_5.TabIndex = 94;
            this.lblIOOUT_5.Tag = "4";
            this.lblIOOUT_5.Text = "OUT #5";
            // 
            // lblIOOUT_4
            // 
            this.lblIOOUT_4.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_4.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_4.Appearance.Options.UseFont = true;
            this.lblIOOUT_4.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_4.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_4, 2);
            this.lblIOOUT_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_4.Location = new System.Drawing.Point(332, 90);
            this.lblIOOUT_4.Name = "lblIOOUT_4";
            this.tablePanel4.SetRow(this.lblIOOUT_4, 3);
            this.lblIOOUT_4.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_4.TabIndex = 93;
            this.lblIOOUT_4.Tag = "3";
            this.lblIOOUT_4.Text = "OUT #4";
            // 
            // lblIOOUT_3
            // 
            this.lblIOOUT_3.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_3.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_3.Appearance.Options.UseFont = true;
            this.lblIOOUT_3.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_3.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_3, 2);
            this.lblIOOUT_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_3.Location = new System.Drawing.Point(332, 61);
            this.lblIOOUT_3.Name = "lblIOOUT_3";
            this.tablePanel4.SetRow(this.lblIOOUT_3, 2);
            this.lblIOOUT_3.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_3.TabIndex = 92;
            this.lblIOOUT_3.Tag = "2";
            this.lblIOOUT_3.Text = "OUT #3";
            // 
            // lblIOOUT_2
            // 
            this.lblIOOUT_2.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_2.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_2.Appearance.Options.UseFont = true;
            this.lblIOOUT_2.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_2.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_2, 2);
            this.lblIOOUT_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_2.Location = new System.Drawing.Point(332, 32);
            this.lblIOOUT_2.Name = "lblIOOUT_2";
            this.tablePanel4.SetRow(this.lblIOOUT_2, 1);
            this.lblIOOUT_2.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_2.TabIndex = 91;
            this.lblIOOUT_2.Tag = "1";
            this.lblIOOUT_2.Text = "OUT #2";
            // 
            // lblIOOUT_1
            // 
            this.lblIOOUT_1.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOOUT_1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOOUT_1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOOUT_1.Appearance.Options.UseBackColor = true;
            this.lblIOOUT_1.Appearance.Options.UseFont = true;
            this.lblIOOUT_1.Appearance.Options.UseForeColor = true;
            this.lblIOOUT_1.Appearance.Options.UseTextOptions = true;
            this.lblIOOUT_1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOOUT_1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOOUT_1, 2);
            this.lblIOOUT_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOOUT_1.Location = new System.Drawing.Point(332, 3);
            this.lblIOOUT_1.Name = "lblIOOUT_1";
            this.tablePanel4.SetRow(this.lblIOOUT_1, 0);
            this.lblIOOUT_1.Size = new System.Drawing.Size(159, 23);
            this.lblIOOUT_1.TabIndex = 90;
            this.lblIOOUT_1.Tag = "0";
            this.lblIOOUT_1.Text = "OUT #1";
            this.lblIOOUT_1.Click += new System.EventHandler(this.lblIOOUT_1_Click);
            // 
            // lblInStatus16
            // 
            this.lblInStatus16.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus16.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus16.Appearance.Options.UseBackColor = true;
            this.lblInStatus16.Appearance.Options.UseFont = true;
            this.lblInStatus16.Appearance.Options.UseTextOptions = true;
            this.lblInStatus16.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus16, 1);
            this.lblInStatus16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus16.Location = new System.Drawing.Point(168, 438);
            this.lblInStatus16.Name = "lblInStatus16";
            this.tablePanel4.SetRow(this.lblInStatus16, 15);
            this.lblInStatus16.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus16.TabIndex = 89;
            this.lblInStatus16.Text = "OFF";
            // 
            // lblInStatus15
            // 
            this.lblInStatus15.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus15.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus15.Appearance.Options.UseBackColor = true;
            this.lblInStatus15.Appearance.Options.UseFont = true;
            this.lblInStatus15.Appearance.Options.UseTextOptions = true;
            this.lblInStatus15.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus15, 1);
            this.lblInStatus15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus15.Location = new System.Drawing.Point(168, 409);
            this.lblInStatus15.Name = "lblInStatus15";
            this.tablePanel4.SetRow(this.lblInStatus15, 14);
            this.lblInStatus15.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus15.TabIndex = 88;
            this.lblInStatus15.Text = "OFF";
            // 
            // lblInStatus14
            // 
            this.lblInStatus14.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus14.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus14.Appearance.Options.UseBackColor = true;
            this.lblInStatus14.Appearance.Options.UseFont = true;
            this.lblInStatus14.Appearance.Options.UseTextOptions = true;
            this.lblInStatus14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus14, 1);
            this.lblInStatus14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus14.Location = new System.Drawing.Point(168, 380);
            this.lblInStatus14.Name = "lblInStatus14";
            this.tablePanel4.SetRow(this.lblInStatus14, 13);
            this.lblInStatus14.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus14.TabIndex = 87;
            this.lblInStatus14.Text = "OFF";
            // 
            // lblInStatus13
            // 
            this.lblInStatus13.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus13.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus13.Appearance.Options.UseBackColor = true;
            this.lblInStatus13.Appearance.Options.UseFont = true;
            this.lblInStatus13.Appearance.Options.UseTextOptions = true;
            this.lblInStatus13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus13, 1);
            this.lblInStatus13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus13.Location = new System.Drawing.Point(168, 351);
            this.lblInStatus13.Name = "lblInStatus13";
            this.tablePanel4.SetRow(this.lblInStatus13, 12);
            this.lblInStatus13.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus13.TabIndex = 86;
            this.lblInStatus13.Text = "OFF";
            // 
            // lblInStatus12
            // 
            this.lblInStatus12.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus12.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus12.Appearance.Options.UseBackColor = true;
            this.lblInStatus12.Appearance.Options.UseFont = true;
            this.lblInStatus12.Appearance.Options.UseTextOptions = true;
            this.lblInStatus12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus12, 1);
            this.lblInStatus12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus12.Location = new System.Drawing.Point(168, 322);
            this.lblInStatus12.Name = "lblInStatus12";
            this.tablePanel4.SetRow(this.lblInStatus12, 11);
            this.lblInStatus12.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus12.TabIndex = 85;
            this.lblInStatus12.Text = "OFF";
            // 
            // lblInStatus11
            // 
            this.lblInStatus11.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus11.Appearance.Options.UseBackColor = true;
            this.lblInStatus11.Appearance.Options.UseFont = true;
            this.lblInStatus11.Appearance.Options.UseTextOptions = true;
            this.lblInStatus11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus11, 1);
            this.lblInStatus11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus11.Location = new System.Drawing.Point(168, 293);
            this.lblInStatus11.Name = "lblInStatus11";
            this.tablePanel4.SetRow(this.lblInStatus11, 10);
            this.lblInStatus11.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus11.TabIndex = 84;
            this.lblInStatus11.Text = "OFF";
            // 
            // lblInStatus10
            // 
            this.lblInStatus10.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus10.Appearance.Options.UseBackColor = true;
            this.lblInStatus10.Appearance.Options.UseFont = true;
            this.lblInStatus10.Appearance.Options.UseTextOptions = true;
            this.lblInStatus10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus10, 1);
            this.lblInStatus10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus10.Location = new System.Drawing.Point(168, 264);
            this.lblInStatus10.Name = "lblInStatus10";
            this.tablePanel4.SetRow(this.lblInStatus10, 9);
            this.lblInStatus10.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus10.TabIndex = 83;
            this.lblInStatus10.Text = "OFF";
            // 
            // lblInStatus9
            // 
            this.lblInStatus9.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus9.Appearance.Options.UseBackColor = true;
            this.lblInStatus9.Appearance.Options.UseFont = true;
            this.lblInStatus9.Appearance.Options.UseTextOptions = true;
            this.lblInStatus9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus9, 1);
            this.lblInStatus9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus9.Location = new System.Drawing.Point(168, 235);
            this.lblInStatus9.Name = "lblInStatus9";
            this.tablePanel4.SetRow(this.lblInStatus9, 8);
            this.lblInStatus9.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus9.TabIndex = 82;
            this.lblInStatus9.Text = "OFF";
            // 
            // lblInStatus8
            // 
            this.lblInStatus8.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus8.Appearance.Options.UseBackColor = true;
            this.lblInStatus8.Appearance.Options.UseFont = true;
            this.lblInStatus8.Appearance.Options.UseTextOptions = true;
            this.lblInStatus8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus8, 1);
            this.lblInStatus8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus8.Location = new System.Drawing.Point(168, 206);
            this.lblInStatus8.Name = "lblInStatus8";
            this.tablePanel4.SetRow(this.lblInStatus8, 7);
            this.lblInStatus8.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus8.TabIndex = 81;
            this.lblInStatus8.Text = "OFF";
            // 
            // lblInStatus7
            // 
            this.lblInStatus7.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus7.Appearance.Options.UseBackColor = true;
            this.lblInStatus7.Appearance.Options.UseFont = true;
            this.lblInStatus7.Appearance.Options.UseTextOptions = true;
            this.lblInStatus7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus7, 1);
            this.lblInStatus7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus7.Location = new System.Drawing.Point(168, 177);
            this.lblInStatus7.Name = "lblInStatus7";
            this.tablePanel4.SetRow(this.lblInStatus7, 6);
            this.lblInStatus7.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus7.TabIndex = 80;
            this.lblInStatus7.Text = "OFF";
            // 
            // lblInStatus6
            // 
            this.lblInStatus6.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus6.Appearance.Options.UseBackColor = true;
            this.lblInStatus6.Appearance.Options.UseFont = true;
            this.lblInStatus6.Appearance.Options.UseTextOptions = true;
            this.lblInStatus6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus6, 1);
            this.lblInStatus6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus6.Location = new System.Drawing.Point(168, 148);
            this.lblInStatus6.Name = "lblInStatus6";
            this.tablePanel4.SetRow(this.lblInStatus6, 5);
            this.lblInStatus6.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus6.TabIndex = 79;
            this.lblInStatus6.Text = "OFF";
            // 
            // lblInStatus5
            // 
            this.lblInStatus5.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus5.Appearance.Options.UseBackColor = true;
            this.lblInStatus5.Appearance.Options.UseFont = true;
            this.lblInStatus5.Appearance.Options.UseTextOptions = true;
            this.lblInStatus5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus5, 1);
            this.lblInStatus5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus5.Location = new System.Drawing.Point(168, 119);
            this.lblInStatus5.Name = "lblInStatus5";
            this.tablePanel4.SetRow(this.lblInStatus5, 4);
            this.lblInStatus5.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus5.TabIndex = 78;
            this.lblInStatus5.Text = "OFF";
            // 
            // lblInStatus4
            // 
            this.lblInStatus4.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus4.Appearance.Options.UseBackColor = true;
            this.lblInStatus4.Appearance.Options.UseFont = true;
            this.lblInStatus4.Appearance.Options.UseTextOptions = true;
            this.lblInStatus4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus4, 1);
            this.lblInStatus4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus4.Location = new System.Drawing.Point(168, 90);
            this.lblInStatus4.Name = "lblInStatus4";
            this.tablePanel4.SetRow(this.lblInStatus4, 3);
            this.lblInStatus4.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus4.TabIndex = 77;
            this.lblInStatus4.Text = "OFF";
            // 
            // lblInStatus3
            // 
            this.lblInStatus3.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus3.Appearance.Options.UseBackColor = true;
            this.lblInStatus3.Appearance.Options.UseFont = true;
            this.lblInStatus3.Appearance.Options.UseTextOptions = true;
            this.lblInStatus3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus3, 1);
            this.lblInStatus3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus3.Location = new System.Drawing.Point(168, 61);
            this.lblInStatus3.Name = "lblInStatus3";
            this.tablePanel4.SetRow(this.lblInStatus3, 2);
            this.lblInStatus3.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus3.TabIndex = 76;
            this.lblInStatus3.Text = "OFF";
            // 
            // lblInStatus2
            // 
            this.lblInStatus2.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus2.Appearance.Options.UseBackColor = true;
            this.lblInStatus2.Appearance.Options.UseFont = true;
            this.lblInStatus2.Appearance.Options.UseTextOptions = true;
            this.lblInStatus2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus2, 1);
            this.lblInStatus2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus2.Location = new System.Drawing.Point(168, 32);
            this.lblInStatus2.Name = "lblInStatus2";
            this.tablePanel4.SetRow(this.lblInStatus2, 1);
            this.lblInStatus2.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus2.TabIndex = 75;
            this.lblInStatus2.Text = "OFF";
            // 
            // lblIOIN_16
            // 
            this.lblIOIN_16.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_16.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_16.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_16.Appearance.Options.UseBackColor = true;
            this.lblIOIN_16.Appearance.Options.UseFont = true;
            this.lblIOIN_16.Appearance.Options.UseForeColor = true;
            this.lblIOIN_16.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_16.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_16.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_16, 0);
            this.lblIOIN_16.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_16.Location = new System.Drawing.Point(3, 438);
            this.lblIOIN_16.Name = "lblIOIN_16";
            this.tablePanel4.SetRow(this.lblIOIN_16, 15);
            this.lblIOIN_16.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_16.TabIndex = 74;
            this.lblIOIN_16.Tag = "15";
            this.lblIOIN_16.Text = "IN #16";
            // 
            // lblIOIN_15
            // 
            this.lblIOIN_15.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_15.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_15.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_15.Appearance.Options.UseBackColor = true;
            this.lblIOIN_15.Appearance.Options.UseFont = true;
            this.lblIOIN_15.Appearance.Options.UseForeColor = true;
            this.lblIOIN_15.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_15.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_15, 0);
            this.lblIOIN_15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_15.Location = new System.Drawing.Point(3, 409);
            this.lblIOIN_15.Name = "lblIOIN_15";
            this.tablePanel4.SetRow(this.lblIOIN_15, 14);
            this.lblIOIN_15.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_15.TabIndex = 73;
            this.lblIOIN_15.Tag = "14";
            this.lblIOIN_15.Text = "IN #15";
            // 
            // lblIOIN_14
            // 
            this.lblIOIN_14.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_14.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_14.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_14.Appearance.Options.UseBackColor = true;
            this.lblIOIN_14.Appearance.Options.UseFont = true;
            this.lblIOIN_14.Appearance.Options.UseForeColor = true;
            this.lblIOIN_14.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_14.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_14.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_14, 0);
            this.lblIOIN_14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_14.Location = new System.Drawing.Point(3, 380);
            this.lblIOIN_14.Name = "lblIOIN_14";
            this.tablePanel4.SetRow(this.lblIOIN_14, 13);
            this.lblIOIN_14.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_14.TabIndex = 72;
            this.lblIOIN_14.Tag = "13";
            this.lblIOIN_14.Text = "IN #14";
            // 
            // lblIOIN_13
            // 
            this.lblIOIN_13.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_13.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_13.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_13.Appearance.Options.UseBackColor = true;
            this.lblIOIN_13.Appearance.Options.UseFont = true;
            this.lblIOIN_13.Appearance.Options.UseForeColor = true;
            this.lblIOIN_13.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_13.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_13.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_13, 0);
            this.lblIOIN_13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_13.Location = new System.Drawing.Point(3, 351);
            this.lblIOIN_13.Name = "lblIOIN_13";
            this.tablePanel4.SetRow(this.lblIOIN_13, 12);
            this.lblIOIN_13.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_13.TabIndex = 71;
            this.lblIOIN_13.Tag = "12";
            this.lblIOIN_13.Text = "IN #13";
            // 
            // lblIOIN_12
            // 
            this.lblIOIN_12.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_12.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_12.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_12.Appearance.Options.UseBackColor = true;
            this.lblIOIN_12.Appearance.Options.UseFont = true;
            this.lblIOIN_12.Appearance.Options.UseForeColor = true;
            this.lblIOIN_12.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_12.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_12.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_12, 0);
            this.lblIOIN_12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_12.Location = new System.Drawing.Point(3, 322);
            this.lblIOIN_12.Name = "lblIOIN_12";
            this.tablePanel4.SetRow(this.lblIOIN_12, 11);
            this.lblIOIN_12.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_12.TabIndex = 70;
            this.lblIOIN_12.Tag = "11";
            this.lblIOIN_12.Text = "IN #12";
            // 
            // lblIOIN_11
            // 
            this.lblIOIN_11.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_11.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_11.Appearance.Options.UseBackColor = true;
            this.lblIOIN_11.Appearance.Options.UseFont = true;
            this.lblIOIN_11.Appearance.Options.UseForeColor = true;
            this.lblIOIN_11.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_11, 0);
            this.lblIOIN_11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_11.Location = new System.Drawing.Point(3, 293);
            this.lblIOIN_11.Name = "lblIOIN_11";
            this.tablePanel4.SetRow(this.lblIOIN_11, 10);
            this.lblIOIN_11.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_11.TabIndex = 69;
            this.lblIOIN_11.Tag = "10";
            this.lblIOIN_11.Text = "IN #11";
            // 
            // lblIOIN_10
            // 
            this.lblIOIN_10.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_10.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_10.Appearance.Options.UseBackColor = true;
            this.lblIOIN_10.Appearance.Options.UseFont = true;
            this.lblIOIN_10.Appearance.Options.UseForeColor = true;
            this.lblIOIN_10.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_10, 0);
            this.lblIOIN_10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_10.Location = new System.Drawing.Point(3, 264);
            this.lblIOIN_10.Name = "lblIOIN_10";
            this.tablePanel4.SetRow(this.lblIOIN_10, 9);
            this.lblIOIN_10.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_10.TabIndex = 68;
            this.lblIOIN_10.Tag = "9";
            this.lblIOIN_10.Text = "IN #10";
            // 
            // lblIOIN_9
            // 
            this.lblIOIN_9.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_9.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_9.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_9.Appearance.Options.UseBackColor = true;
            this.lblIOIN_9.Appearance.Options.UseFont = true;
            this.lblIOIN_9.Appearance.Options.UseForeColor = true;
            this.lblIOIN_9.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_9.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_9.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_9, 0);
            this.lblIOIN_9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_9.Location = new System.Drawing.Point(3, 235);
            this.lblIOIN_9.Name = "lblIOIN_9";
            this.tablePanel4.SetRow(this.lblIOIN_9, 8);
            this.lblIOIN_9.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_9.TabIndex = 67;
            this.lblIOIN_9.Tag = "8";
            this.lblIOIN_9.Text = "IN #9";
            // 
            // lblIOIN_8
            // 
            this.lblIOIN_8.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_8.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_8.Appearance.Options.UseBackColor = true;
            this.lblIOIN_8.Appearance.Options.UseFont = true;
            this.lblIOIN_8.Appearance.Options.UseForeColor = true;
            this.lblIOIN_8.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_8, 0);
            this.lblIOIN_8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_8.Location = new System.Drawing.Point(3, 206);
            this.lblIOIN_8.Name = "lblIOIN_8";
            this.tablePanel4.SetRow(this.lblIOIN_8, 7);
            this.lblIOIN_8.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_8.TabIndex = 66;
            this.lblIOIN_8.Tag = "7";
            this.lblIOIN_8.Text = "IN #8";
            // 
            // lblIOIN_7
            // 
            this.lblIOIN_7.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_7.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_7.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_7.Appearance.Options.UseBackColor = true;
            this.lblIOIN_7.Appearance.Options.UseFont = true;
            this.lblIOIN_7.Appearance.Options.UseForeColor = true;
            this.lblIOIN_7.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_7, 0);
            this.lblIOIN_7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_7.Location = new System.Drawing.Point(3, 177);
            this.lblIOIN_7.Name = "lblIOIN_7";
            this.tablePanel4.SetRow(this.lblIOIN_7, 6);
            this.lblIOIN_7.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_7.TabIndex = 65;
            this.lblIOIN_7.Tag = "6";
            this.lblIOIN_7.Text = "IN #7";
            // 
            // lblIOIN_6
            // 
            this.lblIOIN_6.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_6.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_6.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_6.Appearance.Options.UseBackColor = true;
            this.lblIOIN_6.Appearance.Options.UseFont = true;
            this.lblIOIN_6.Appearance.Options.UseForeColor = true;
            this.lblIOIN_6.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_6, 0);
            this.lblIOIN_6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_6.Location = new System.Drawing.Point(3, 148);
            this.lblIOIN_6.Name = "lblIOIN_6";
            this.tablePanel4.SetRow(this.lblIOIN_6, 5);
            this.lblIOIN_6.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_6.TabIndex = 64;
            this.lblIOIN_6.Tag = "5";
            this.lblIOIN_6.Text = "IN #6";
            // 
            // lblIOIN_5
            // 
            this.lblIOIN_5.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_5.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_5.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_5.Appearance.Options.UseBackColor = true;
            this.lblIOIN_5.Appearance.Options.UseFont = true;
            this.lblIOIN_5.Appearance.Options.UseForeColor = true;
            this.lblIOIN_5.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_5, 0);
            this.lblIOIN_5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_5.Location = new System.Drawing.Point(3, 119);
            this.lblIOIN_5.Name = "lblIOIN_5";
            this.tablePanel4.SetRow(this.lblIOIN_5, 4);
            this.lblIOIN_5.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_5.TabIndex = 63;
            this.lblIOIN_5.Tag = "4";
            this.lblIOIN_5.Text = "IN #5";
            // 
            // lblIOIN_4
            // 
            this.lblIOIN_4.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_4.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_4.Appearance.Options.UseBackColor = true;
            this.lblIOIN_4.Appearance.Options.UseFont = true;
            this.lblIOIN_4.Appearance.Options.UseForeColor = true;
            this.lblIOIN_4.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_4.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_4, 0);
            this.lblIOIN_4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_4.Location = new System.Drawing.Point(3, 90);
            this.lblIOIN_4.Name = "lblIOIN_4";
            this.tablePanel4.SetRow(this.lblIOIN_4, 3);
            this.lblIOIN_4.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_4.TabIndex = 62;
            this.lblIOIN_4.Tag = "3";
            this.lblIOIN_4.Text = "IN #4";
            // 
            // lblIOIN_3
            // 
            this.lblIOIN_3.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_3.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_3.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_3.Appearance.Options.UseBackColor = true;
            this.lblIOIN_3.Appearance.Options.UseFont = true;
            this.lblIOIN_3.Appearance.Options.UseForeColor = true;
            this.lblIOIN_3.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_3, 0);
            this.lblIOIN_3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_3.Location = new System.Drawing.Point(3, 61);
            this.lblIOIN_3.Name = "lblIOIN_3";
            this.tablePanel4.SetRow(this.lblIOIN_3, 2);
            this.lblIOIN_3.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_3.TabIndex = 61;
            this.lblIOIN_3.Tag = "2";
            this.lblIOIN_3.Text = "IN #3";
            // 
            // lblIOIN_2
            // 
            this.lblIOIN_2.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_2.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_2.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_2.Appearance.Options.UseBackColor = true;
            this.lblIOIN_2.Appearance.Options.UseFont = true;
            this.lblIOIN_2.Appearance.Options.UseForeColor = true;
            this.lblIOIN_2.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_2, 0);
            this.lblIOIN_2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_2.Location = new System.Drawing.Point(3, 32);
            this.lblIOIN_2.Name = "lblIOIN_2";
            this.tablePanel4.SetRow(this.lblIOIN_2, 1);
            this.lblIOIN_2.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_2.TabIndex = 60;
            this.lblIOIN_2.Tag = "1";
            this.lblIOIN_2.Text = "IN #2";
            // 
            // lblInStatus1
            // 
            this.lblInStatus1.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblInStatus1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblInStatus1.Appearance.Options.UseBackColor = true;
            this.lblInStatus1.Appearance.Options.UseFont = true;
            this.lblInStatus1.Appearance.Options.UseTextOptions = true;
            this.lblInStatus1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblInStatus1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblInStatus1, 1);
            this.lblInStatus1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblInStatus1.Location = new System.Drawing.Point(168, 3);
            this.lblInStatus1.Name = "lblInStatus1";
            this.tablePanel4.SetRow(this.lblInStatus1, 0);
            this.lblInStatus1.Size = new System.Drawing.Size(159, 23);
            this.lblInStatus1.TabIndex = 56;
            this.lblInStatus1.Text = "OFF";
            // 
            // lblIOIN_1
            // 
            this.lblIOIN_1.Appearance.BackColor = System.Drawing.Color.White;
            this.lblIOIN_1.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.lblIOIN_1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblIOIN_1.Appearance.Options.UseBackColor = true;
            this.lblIOIN_1.Appearance.Options.UseFont = true;
            this.lblIOIN_1.Appearance.Options.UseForeColor = true;
            this.lblIOIN_1.Appearance.Options.UseTextOptions = true;
            this.lblIOIN_1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblIOIN_1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel4.SetColumn(this.lblIOIN_1, 0);
            this.lblIOIN_1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblIOIN_1.Location = new System.Drawing.Point(3, 3);
            this.lblIOIN_1.Name = "lblIOIN_1";
            this.tablePanel4.SetRow(this.lblIOIN_1, 0);
            this.lblIOIN_1.Size = new System.Drawing.Size(159, 23);
            this.lblIOIN_1.TabIndex = 55;
            this.lblIOIN_1.Tag = "0";
            this.lblIOIN_1.Text = "IN #1";
            this.lblIOIN_1.Click += new System.EventHandler(this.lblIOIN_1_Click);
            // 
            // btnIOClose
            // 
            this.btnIOClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIOClose.Appearance.Options.UseFont = true;
            this.btnIOClose.Appearance.Options.UseTextOptions = true;
            this.btnIOClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnIOClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIOClose.ImageOptions.Image")));
            this.btnIOClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnIOClose.Location = new System.Drawing.Point(342, 580);
            this.btnIOClose.Name = "btnIOClose";
            this.btnIOClose.Size = new System.Drawing.Size(114, 58);
            this.btnIOClose.TabIndex = 20;
            this.btnIOClose.Text = "Close";
            this.btnIOClose.Click += new System.EventHandler(this.btnIOClose_Click);
            // 
            // btnIOSave
            // 
            this.btnIOSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnIOSave.Appearance.Options.UseFont = true;
            this.btnIOSave.Appearance.Options.UseTextOptions = true;
            this.btnIOSave.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnIOSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnIOSave.ImageOptions.Image")));
            this.btnIOSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnIOSave.Location = new System.Drawing.Point(221, 580);
            this.btnIOSave.Name = "btnIOSave";
            this.btnIOSave.Size = new System.Drawing.Size(114, 58);
            this.btnIOSave.TabIndex = 19;
            this.btnIOSave.Text = "Save";
            this.btnIOSave.Click += new System.EventHandler(this.btnIOSave_Click);
            // 
            // groupControl6
            // 
            this.groupControl6.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl6.AppearanceCaption.ForeColor = System.Drawing.Color.Salmon;
            this.groupControl6.AppearanceCaption.Options.UseFont = true;
            this.groupControl6.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl6.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl6.CaptionImageOptions.SvgImage")));
            this.groupControl6.Controls.Add(this.textEdit4);
            this.groupControl6.Controls.Add(this.labelControl93);
            this.groupControl6.Controls.Add(this.txtIOOutSount);
            this.groupControl6.Controls.Add(this.labelControl46);
            this.groupControl6.Controls.Add(this.txtIOOutAir2);
            this.groupControl6.Controls.Add(this.labelControl45);
            this.groupControl6.Controls.Add(this.txtIOOutAir1);
            this.groupControl6.Controls.Add(this.labelControl42);
            this.groupControl6.Controls.Add(this.txtIOOutLight);
            this.groupControl6.Controls.Add(this.labelControl40);
            this.groupControl6.Controls.Add(this.txtIOOutLampR);
            this.groupControl6.Controls.Add(this.labelControl37);
            this.groupControl6.Controls.Add(this.txtIOOutLampG);
            this.groupControl6.Controls.Add(this.labelControl32);
            this.groupControl6.Location = new System.Drawing.Point(8, 211);
            this.groupControl6.Name = "groupControl6";
            this.groupControl6.Size = new System.Drawing.Size(662, 139);
            this.groupControl6.TabIndex = 53;
            this.groupControl6.Text = "Output";
            this.groupControl6.Visible = false;
            // 
            // textEdit4
            // 
            this.textEdit4.Location = new System.Drawing.Point(347, 74);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEdit4.Properties.Appearance.Options.UseFont = true;
            this.textEdit4.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit4.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit4.Size = new System.Drawing.Size(100, 24);
            this.textEdit4.TabIndex = 67;
            // 
            // labelControl93
            // 
            this.labelControl93.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl93.Appearance.Options.UseFont = true;
            this.labelControl93.Appearance.Options.UseTextOptions = true;
            this.labelControl93.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl93.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl93.Location = new System.Drawing.Point(246, 76);
            this.labelControl93.Name = "labelControl93";
            this.labelControl93.Size = new System.Drawing.Size(93, 19);
            this.labelControl93.TabIndex = 66;
            this.labelControl93.Text = "Side Light : ";
            // 
            // txtIOOutSount
            // 
            this.txtIOOutSount.Location = new System.Drawing.Point(136, 106);
            this.txtIOOutSount.Name = "txtIOOutSount";
            this.txtIOOutSount.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOOutSount.Properties.Appearance.Options.UseFont = true;
            this.txtIOOutSount.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOOutSount.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOOutSount.Size = new System.Drawing.Size(100, 24);
            this.txtIOOutSount.TabIndex = 65;
            // 
            // labelControl46
            // 
            this.labelControl46.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl46.Appearance.Options.UseFont = true;
            this.labelControl46.Appearance.Options.UseTextOptions = true;
            this.labelControl46.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl46.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl46.Location = new System.Drawing.Point(5, 108);
            this.labelControl46.Name = "labelControl46";
            this.labelControl46.Size = new System.Drawing.Size(123, 19);
            this.labelControl46.TabIndex = 64;
            this.labelControl46.Text = "Lamp Sound : ";
            // 
            // txtIOOutAir2
            // 
            this.txtIOOutAir2.Location = new System.Drawing.Point(554, 74);
            this.txtIOOutAir2.Name = "txtIOOutAir2";
            this.txtIOOutAir2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOOutAir2.Properties.Appearance.Options.UseFont = true;
            this.txtIOOutAir2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOOutAir2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOOutAir2.Size = new System.Drawing.Size(100, 24);
            this.txtIOOutAir2.TabIndex = 63;
            // 
            // labelControl45
            // 
            this.labelControl45.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl45.Appearance.Options.UseFont = true;
            this.labelControl45.Appearance.Options.UseTextOptions = true;
            this.labelControl45.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl45.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl45.Location = new System.Drawing.Point(453, 76);
            this.labelControl45.Name = "labelControl45";
            this.labelControl45.Size = new System.Drawing.Size(93, 19);
            this.labelControl45.TabIndex = 62;
            this.labelControl45.Text = "Rear Air 2 : ";
            // 
            // txtIOOutAir1
            // 
            this.txtIOOutAir1.Location = new System.Drawing.Point(554, 42);
            this.txtIOOutAir1.Name = "txtIOOutAir1";
            this.txtIOOutAir1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOOutAir1.Properties.Appearance.Options.UseFont = true;
            this.txtIOOutAir1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOOutAir1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOOutAir1.Size = new System.Drawing.Size(100, 24);
            this.txtIOOutAir1.TabIndex = 61;
            // 
            // labelControl42
            // 
            this.labelControl42.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl42.Appearance.Options.UseFont = true;
            this.labelControl42.Appearance.Options.UseTextOptions = true;
            this.labelControl42.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl42.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl42.Location = new System.Drawing.Point(453, 44);
            this.labelControl42.Name = "labelControl42";
            this.labelControl42.Size = new System.Drawing.Size(93, 19);
            this.labelControl42.TabIndex = 60;
            this.labelControl42.Text = "Rear Air 1 : ";
            // 
            // txtIOOutLight
            // 
            this.txtIOOutLight.Location = new System.Drawing.Point(347, 42);
            this.txtIOOutLight.Name = "txtIOOutLight";
            this.txtIOOutLight.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOOutLight.Properties.Appearance.Options.UseFont = true;
            this.txtIOOutLight.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOOutLight.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOOutLight.Size = new System.Drawing.Size(100, 24);
            this.txtIOOutLight.TabIndex = 59;
            // 
            // labelControl40
            // 
            this.labelControl40.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl40.Appearance.Options.UseFont = true;
            this.labelControl40.Appearance.Options.UseTextOptions = true;
            this.labelControl40.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl40.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl40.Location = new System.Drawing.Point(246, 44);
            this.labelControl40.Name = "labelControl40";
            this.labelControl40.Size = new System.Drawing.Size(93, 19);
            this.labelControl40.TabIndex = 58;
            this.labelControl40.Text = "Top Light : ";
            // 
            // txtIOOutLampR
            // 
            this.txtIOOutLampR.Location = new System.Drawing.Point(136, 74);
            this.txtIOOutLampR.Name = "txtIOOutLampR";
            this.txtIOOutLampR.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOOutLampR.Properties.Appearance.Options.UseFont = true;
            this.txtIOOutLampR.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOOutLampR.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOOutLampR.Size = new System.Drawing.Size(100, 24);
            this.txtIOOutLampR.TabIndex = 57;
            // 
            // labelControl37
            // 
            this.labelControl37.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl37.Appearance.Options.UseFont = true;
            this.labelControl37.Appearance.Options.UseTextOptions = true;
            this.labelControl37.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl37.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl37.Location = new System.Drawing.Point(35, 76);
            this.labelControl37.Name = "labelControl37";
            this.labelControl37.Size = new System.Drawing.Size(93, 19);
            this.labelControl37.TabIndex = 56;
            this.labelControl37.Text = "Lamp R : ";
            // 
            // txtIOOutLampG
            // 
            this.txtIOOutLampG.Location = new System.Drawing.Point(136, 42);
            this.txtIOOutLampG.Name = "txtIOOutLampG";
            this.txtIOOutLampG.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOOutLampG.Properties.Appearance.Options.UseFont = true;
            this.txtIOOutLampG.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOOutLampG.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOOutLampG.Size = new System.Drawing.Size(100, 24);
            this.txtIOOutLampG.TabIndex = 55;
            // 
            // labelControl32
            // 
            this.labelControl32.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl32.Appearance.Options.UseFont = true;
            this.labelControl32.Appearance.Options.UseTextOptions = true;
            this.labelControl32.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl32.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl32.Location = new System.Drawing.Point(35, 44);
            this.labelControl32.Name = "labelControl32";
            this.labelControl32.Size = new System.Drawing.Size(93, 19);
            this.labelControl32.TabIndex = 54;
            this.labelControl32.Text = "Lamp G : ";
            // 
            // groupControl5
            // 
            this.groupControl5.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl5.AppearanceCaption.ForeColor = System.Drawing.Color.Lime;
            this.groupControl5.AppearanceCaption.Options.UseFont = true;
            this.groupControl5.AppearanceCaption.Options.UseForeColor = true;
            this.groupControl5.CaptionImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("groupControl5.CaptionImageOptions.SvgImage")));
            this.groupControl5.Controls.Add(this.txtIOInShutter2);
            this.groupControl5.Controls.Add(this.labelControl31);
            this.groupControl5.Controls.Add(this.txtIOInShutter1);
            this.groupControl5.Controls.Add(this.labelControl30);
            this.groupControl5.Controls.Add(this.labelControl39);
            this.groupControl5.Controls.Add(this.txtIOInStartSignal);
            this.groupControl5.Controls.Add(this.txtIOInSensor);
            this.groupControl5.Controls.Add(this.labelControl29);
            this.groupControl5.Location = new System.Drawing.Point(8, 100);
            this.groupControl5.Name = "groupControl5";
            this.groupControl5.Size = new System.Drawing.Size(662, 107);
            this.groupControl5.TabIndex = 52;
            this.groupControl5.Text = "Input";
            this.groupControl5.Visible = false;
            // 
            // txtIOInShutter2
            // 
            this.txtIOInShutter2.Location = new System.Drawing.Point(348, 74);
            this.txtIOInShutter2.Name = "txtIOInShutter2";
            this.txtIOInShutter2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOInShutter2.Properties.Appearance.Options.UseFont = true;
            this.txtIOInShutter2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOInShutter2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOInShutter2.Size = new System.Drawing.Size(100, 24);
            this.txtIOInShutter2.TabIndex = 55;
            // 
            // labelControl31
            // 
            this.labelControl31.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl31.Appearance.Options.UseFont = true;
            this.labelControl31.Appearance.Options.UseTextOptions = true;
            this.labelControl31.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl31.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl31.Location = new System.Drawing.Point(247, 76);
            this.labelControl31.Name = "labelControl31";
            this.labelControl31.Size = new System.Drawing.Size(93, 19);
            this.labelControl31.TabIndex = 54;
            this.labelControl31.Text = "Shutter 2 : ";
            // 
            // txtIOInShutter1
            // 
            this.txtIOInShutter1.Location = new System.Drawing.Point(348, 42);
            this.txtIOInShutter1.Name = "txtIOInShutter1";
            this.txtIOInShutter1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOInShutter1.Properties.Appearance.Options.UseFont = true;
            this.txtIOInShutter1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOInShutter1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOInShutter1.Size = new System.Drawing.Size(100, 24);
            this.txtIOInShutter1.TabIndex = 53;
            // 
            // labelControl30
            // 
            this.labelControl30.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl30.Appearance.Options.UseFont = true;
            this.labelControl30.Appearance.Options.UseTextOptions = true;
            this.labelControl30.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl30.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl30.Location = new System.Drawing.Point(247, 44);
            this.labelControl30.Name = "labelControl30";
            this.labelControl30.Size = new System.Drawing.Size(93, 19);
            this.labelControl30.TabIndex = 52;
            this.labelControl30.Text = "Shutter 1 : ";
            // 
            // labelControl39
            // 
            this.labelControl39.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl39.Appearance.Options.UseFont = true;
            this.labelControl39.Appearance.Options.UseTextOptions = true;
            this.labelControl39.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl39.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl39.Location = new System.Drawing.Point(-90, 44);
            this.labelControl39.Name = "labelControl39";
            this.labelControl39.Size = new System.Drawing.Size(220, 19);
            this.labelControl39.TabIndex = 48;
            this.labelControl39.Text = "Start Signal : ";
            // 
            // txtIOInStartSignal
            // 
            this.txtIOInStartSignal.Location = new System.Drawing.Point(137, 42);
            this.txtIOInStartSignal.Name = "txtIOInStartSignal";
            this.txtIOInStartSignal.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOInStartSignal.Properties.Appearance.Options.UseFont = true;
            this.txtIOInStartSignal.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOInStartSignal.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOInStartSignal.Size = new System.Drawing.Size(100, 24);
            this.txtIOInStartSignal.TabIndex = 49;
            // 
            // txtIOInSensor
            // 
            this.txtIOInSensor.Location = new System.Drawing.Point(137, 74);
            this.txtIOInSensor.Name = "txtIOInSensor";
            this.txtIOInSensor.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.txtIOInSensor.Properties.Appearance.Options.UseFont = true;
            this.txtIOInSensor.Properties.Appearance.Options.UseTextOptions = true;
            this.txtIOInSensor.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtIOInSensor.Size = new System.Drawing.Size(100, 24);
            this.txtIOInSensor.TabIndex = 51;
            // 
            // labelControl29
            // 
            this.labelControl29.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl29.Appearance.Options.UseFont = true;
            this.labelControl29.Appearance.Options.UseTextOptions = true;
            this.labelControl29.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl29.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl29.Location = new System.Drawing.Point(-90, 76);
            this.labelControl29.Name = "labelControl29";
            this.labelControl29.Size = new System.Drawing.Size(220, 19);
            this.labelControl29.TabIndex = 50;
            this.labelControl29.Text = "Sensor : ";
            // 
            // cbIODev
            // 
            this.cbIODev.Location = new System.Drawing.Point(138, 38);
            this.cbIODev.Name = "cbIODev";
            this.cbIODev.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIODev.Properties.Appearance.Options.UseFont = true;
            this.cbIODev.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIODev.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbIODev.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIODev.Size = new System.Drawing.Size(171, 26);
            this.cbIODev.TabIndex = 47;
            // 
            // toggleSwitch2
            // 
            this.toggleSwitch2.Location = new System.Drawing.Point(817, 449);
            this.toggleSwitch2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.toggleSwitch2.Name = "toggleSwitch2";
            this.toggleSwitch2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.toggleSwitch2.Properties.Appearance.Options.UseFont = true;
            this.toggleSwitch2.Properties.OffText = "Off";
            this.toggleSwitch2.Properties.OnText = "On";
            this.toggleSwitch2.Size = new System.Drawing.Size(109, 19);
            this.toggleSwitch2.TabIndex = 39;
            this.toggleSwitch2.Visible = false;
            // 
            // labelControl34
            // 
            this.labelControl34.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl34.Appearance.Options.UseFont = true;
            this.labelControl34.Location = new System.Drawing.Point(830, 414);
            this.labelControl34.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl34.Name = "labelControl34";
            this.labelControl34.Size = new System.Drawing.Size(18, 18);
            this.labelControl34.TabIndex = 38;
            this.labelControl34.Text = "%";
            this.labelControl34.Visible = false;
            // 
            // textEdit6
            // 
            this.textEdit6.Location = new System.Drawing.Point(710, 411);
            this.textEdit6.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textEdit6.Name = "textEdit6";
            this.textEdit6.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.textEdit6.Properties.Appearance.Options.UseFont = true;
            this.textEdit6.Properties.Appearance.Options.UseTextOptions = true;
            this.textEdit6.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.textEdit6.Size = new System.Drawing.Size(114, 24);
            this.textEdit6.TabIndex = 37;
            this.textEdit6.Visible = false;
            // 
            // labelControl36
            // 
            this.labelControl36.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl36.Appearance.Options.UseFont = true;
            this.labelControl36.Appearance.Options.UseTextOptions = true;
            this.labelControl36.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl36.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl36.Location = new System.Drawing.Point(474, 410);
            this.labelControl36.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl36.Name = "labelControl36";
            this.labelControl36.Size = new System.Drawing.Size(230, 25);
            this.labelControl36.TabIndex = 36;
            this.labelControl36.Text = "Disk capacity Rate :";
            this.labelControl36.Visible = false;
            // 
            // timeEdit1
            // 
            this.timeEdit1.EditValue = new System.DateTime(2023, 2, 16, 0, 0, 0, 0);
            this.timeEdit1.Location = new System.Drawing.Point(705, 448);
            this.timeEdit1.Name = "timeEdit1";
            this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeEdit1.Size = new System.Drawing.Size(100, 22);
            this.timeEdit1.TabIndex = 33;
            this.timeEdit1.Visible = false;
            // 
            // labelControl38
            // 
            this.labelControl38.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl38.Appearance.Options.UseFont = true;
            this.labelControl38.Appearance.Options.UseTextOptions = true;
            this.labelControl38.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl38.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl38.Location = new System.Drawing.Point(476, 446);
            this.labelControl38.Name = "labelControl38";
            this.labelControl38.Size = new System.Drawing.Size(220, 19);
            this.labelControl38.TabIndex = 32;
            this.labelControl38.Text = "Reset Timer :";
            this.labelControl38.Visible = false;
            // 
            // labelControl41
            // 
            this.labelControl41.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl41.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl41.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl41.Appearance.Options.UseBackColor = true;
            this.labelControl41.Appearance.Options.UseFont = true;
            this.labelControl41.Appearance.Options.UseForeColor = true;
            this.labelControl41.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl41.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl41.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl41.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl41.ImageOptions.SvgImage")));
            this.labelControl41.Location = new System.Drawing.Point(2, 2);
            this.labelControl41.Name = "labelControl41";
            this.labelControl41.Size = new System.Drawing.Size(674, 26);
            this.labelControl41.TabIndex = 16;
            this.labelControl41.Text = "I/O 설정 및 모니터링";
            // 
            // labelControl44
            // 
            this.labelControl44.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl44.Appearance.Options.UseFont = true;
            this.labelControl44.Appearance.Options.UseTextOptions = true;
            this.labelControl44.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl44.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl44.Location = new System.Drawing.Point(29, 42);
            this.labelControl44.Name = "labelControl44";
            this.labelControl44.Size = new System.Drawing.Size(96, 19);
            this.labelControl44.TabIndex = 2;
            this.labelControl44.Text = "PCI Card : ";
            // 
            // flyUserEdit
            // 
            this.flyUserEdit.AutoSize = true;
            this.flyUserEdit.Controls.Add(this.flyoutPanelControl11);
            this.flyUserEdit.Location = new System.Drawing.Point(26, 576);
            this.flyUserEdit.Name = "flyUserEdit";
            this.flyUserEdit.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.Center;
            this.flyUserEdit.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyUserEdit.Options.CloseOnHidingOwner = false;
            this.flyUserEdit.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyUserEdit.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyUserEdit.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyUserEdit.OwnerControl = this;
            this.flyUserEdit.Size = new System.Drawing.Size(459, 324);
            this.flyUserEdit.TabIndex = 146;
            // 
            // flyoutPanelControl11
            // 
            this.flyoutPanelControl11.Controls.Add(this.labelControl33);
            this.flyoutPanelControl11.Controls.Add(this.cbLevel);
            this.flyoutPanelControl11.Controls.Add(this.txtID);
            this.flyoutPanelControl11.Controls.Add(this.lblUser);
            this.flyoutPanelControl11.Controls.Add(this.lblMatch2);
            this.flyoutPanelControl11.Controls.Add(this.btnUserEditClose);
            this.flyoutPanelControl11.Controls.Add(this.txtChangePW2);
            this.flyoutPanelControl11.Controls.Add(this.btnUserChk);
            this.flyoutPanelControl11.Controls.Add(this.lblReenterPW);
            this.flyoutPanelControl11.Controls.Add(this.txtPW);
            this.flyoutPanelControl11.Controls.Add(this.txtChangePW1);
            this.flyoutPanelControl11.Controls.Add(this.lblEnterPW);
            this.flyoutPanelControl11.Controls.Add(this.lblPassword);
            this.flyoutPanelControl11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl11.FlyoutPanel = this.flyUserEdit;
            this.flyoutPanelControl11.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl11.Name = "flyoutPanelControl11";
            this.flyoutPanelControl11.Size = new System.Drawing.Size(459, 324);
            this.flyoutPanelControl11.TabIndex = 0;
            // 
            // labelControl33
            // 
            this.labelControl33.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.labelControl33.Appearance.Options.UseFont = true;
            this.labelControl33.Appearance.Options.UseTextOptions = true;
            this.labelControl33.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl33.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl33.Location = new System.Drawing.Point(17, 216);
            this.labelControl33.Name = "labelControl33";
            this.labelControl33.Size = new System.Drawing.Size(200, 25);
            this.labelControl33.TabIndex = 50;
            this.labelControl33.Text = "User Level : ";
            // 
            // cbLevel
            // 
            this.cbLevel.Location = new System.Drawing.Point(228, 212);
            this.cbLevel.Name = "cbLevel";
            this.cbLevel.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLevel.Properties.Appearance.Options.UseFont = true;
            this.cbLevel.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbLevel.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbLevel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLevel.Size = new System.Drawing.Size(198, 30);
            this.cbLevel.TabIndex = 49;
            // 
            // lblUser
            // 
            this.lblUser.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Appearance.Options.UseFont = true;
            this.lblUser.Appearance.Options.UseTextOptions = true;
            this.lblUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblUser.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblUser.Location = new System.Drawing.Point(96, 26);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(128, 25);
            this.lblUser.TabIndex = 48;
            this.lblUser.Text = "USER : ";
            // 
            // lblMatch2
            // 
            this.lblMatch2.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold);
            this.lblMatch2.Appearance.ForeColor = System.Drawing.Color.GreenYellow;
            this.lblMatch2.Appearance.Options.UseFont = true;
            this.lblMatch2.Appearance.Options.UseForeColor = true;
            this.lblMatch2.Appearance.Options.UseTextOptions = true;
            this.lblMatch2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblMatch2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblMatch2.Location = new System.Drawing.Point(226, 181);
            this.lblMatch2.Name = "lblMatch2";
            this.lblMatch2.Size = new System.Drawing.Size(200, 25);
            this.lblMatch2.TabIndex = 9;
            this.lblMatch2.Text = "(Match)";
            this.lblMatch2.Visible = false;
            // 
            // btnUserEditClose
            // 
            this.btnUserEditClose.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUserEditClose.Appearance.Options.UseFont = true;
            this.btnUserEditClose.Appearance.Options.UseTextOptions = true;
            this.btnUserEditClose.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnUserEditClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUserEditClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUserEditClose.ImageOptions.Image")));
            this.btnUserEditClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUserEditClose.Location = new System.Drawing.Point(231, 258);
            this.btnUserEditClose.Name = "btnUserEditClose";
            this.btnUserEditClose.Size = new System.Drawing.Size(134, 56);
            this.btnUserEditClose.TabIndex = 4;
            this.btnUserEditClose.Text = "Close";
            this.btnUserEditClose.Click += new System.EventHandler(this.btnUserEditClose_Click);
            // 
            // btnUserChk
            // 
            this.btnUserChk.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.btnUserChk.Appearance.Options.UseFont = true;
            this.btnUserChk.Appearance.Options.UseTextOptions = true;
            this.btnUserChk.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.btnUserChk.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnUserChk.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnUserChk.ImageOptions.Image")));
            this.btnUserChk.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnUserChk.Location = new System.Drawing.Point(94, 258);
            this.btnUserChk.Name = "btnUserChk";
            this.btnUserChk.Size = new System.Drawing.Size(134, 56);
            this.btnUserChk.TabIndex = 4;
            this.btnUserChk.Text = "Check";
            this.btnUserChk.Click += new System.EventHandler(this.btnUserChk_Click);
            // 
            // lblPassword
            // 
            this.lblPassword.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold);
            this.lblPassword.Appearance.Options.UseFont = true;
            this.lblPassword.Appearance.Options.UseTextOptions = true;
            this.lblPassword.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblPassword.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblPassword.Location = new System.Drawing.Point(96, 65);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(128, 25);
            this.lblPassword.TabIndex = 0;
            this.lblPassword.Text = "Password : ";
            // 
            // pnl
            // 
            this.pnl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.pnl.Controls.Add(this.tablePanel5);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnl.Location = new System.Drawing.Point(0, 25);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(1443, 107);
            this.pnl.TabIndex = 152;
            // 
            // flyList
            // 
            this.flyList.AutoSize = true;
            this.flyList.Controls.Add(this.flyoutPanelControl12);
            this.flyList.Location = new System.Drawing.Point(474, 511);
            this.flyList.Name = "flyList";
            this.flyList.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyList.Options.CloseOnHidingOwner = false;
            this.flyList.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyList.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyList.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyList.OwnerControl = this.lblModel;
            this.flyList.Size = new System.Drawing.Size(299, 345);
            this.flyList.TabIndex = 154;
            // 
            // flyoutPanelControl12
            // 
            this.flyoutPanelControl12.Controls.Add(this.listModel);
            this.flyoutPanelControl12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl12.FlyoutPanel = this.flyList;
            this.flyoutPanelControl12.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl12.Name = "flyoutPanelControl12";
            this.flyoutPanelControl12.Size = new System.Drawing.Size(299, 345);
            this.flyoutPanelControl12.TabIndex = 0;
            // 
            // listModel
            // 
            this.listModel.Appearance.Font = new System.Drawing.Font("Tahoma", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listModel.Appearance.Options.UseFont = true;
            this.listModel.Appearance.Options.UseTextOptions = true;
            this.listModel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.listModel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listModel.Items.AddRange(new object[] {
            "TEST",
            "TEST2",
            "TEST3"});
            this.listModel.Location = new System.Drawing.Point(2, 2);
            this.listModel.Name = "listModel";
            this.listModel.Size = new System.Drawing.Size(295, 341);
            this.listModel.TabIndex = 0;
            this.listModel.DrawItem += new DevExpress.XtraEditors.ListBoxDrawItemEventHandler(this.listModel_DrawItem);
            this.listModel.DoubleClick += new System.EventHandler(this.listModel_DoubleClick);
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar4});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.MainMenu = this.bar4;
            this.barManager1.MaxItemId = 1;
            // 
            // bar4
            // 
            this.bar4.BarName = "Main menu";
            this.bar4.DockCol = 0;
            this.bar4.DockRow = 0;
            this.bar4.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar4.OptionsBar.DrawBorder = false;
            this.bar4.OptionsBar.MultiLine = true;
            this.bar4.OptionsBar.UseWholeRow = true;
            this.bar4.Text = "Main menu";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1443, 25);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 1068);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1443, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 25);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 1043);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1443, 25);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 1043);
            // 
            // flyLight
            // 
            this.flyLight.AutoSize = true;
            this.flyLight.Controls.Add(this.flyoutPanelControl15);
            this.flyLight.Location = new System.Drawing.Point(543, 269);
            this.flyLight.Name = "flyLight";
            this.flyLight.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyLight.OptionsBeakPanel.BeakLocation = DevExpress.Utils.BeakPanelBeakLocation.Top;
            this.flyLight.OptionsBeakPanel.CloseOnOuterClick = false;
            this.flyLight.OptionsButtonPanel.ButtonPanelHeight = 32;
            this.flyLight.OwnerControl = this.btnLightSetting;
            this.flyLight.Size = new System.Drawing.Size(537, 381);
            this.flyLight.TabIndex = 172;
            // 
            // flyoutPanelControl15
            // 
            this.flyoutPanelControl15.Controls.Add(this.groupControl10);
            this.flyoutPanelControl15.Controls.Add(this.chkLightUse4);
            this.flyoutPanelControl15.Controls.Add(this.chkLightUse3);
            this.flyoutPanelControl15.Controls.Add(this.chkLightUse2);
            this.flyoutPanelControl15.Controls.Add(this.chkLightUse1);
            this.flyoutPanelControl15.Controls.Add(this.radLightSerial);
            this.flyoutPanelControl15.Controls.Add(this.radLightUDP);
            this.flyoutPanelControl15.Controls.Add(this.labelControl52);
            this.flyoutPanelControl15.Controls.Add(this.swOn4);
            this.flyoutPanelControl15.Controls.Add(this.swOn3);
            this.flyoutPanelControl15.Controls.Add(this.swOn2);
            this.flyoutPanelControl15.Controls.Add(this.barValue4);
            this.flyoutPanelControl15.Controls.Add(this.txtValue4);
            this.flyoutPanelControl15.Controls.Add(this.barValue3);
            this.flyoutPanelControl15.Controls.Add(this.txtValue3);
            this.flyoutPanelControl15.Controls.Add(this.barValue2);
            this.flyoutPanelControl15.Controls.Add(this.txtValue2);
            this.flyoutPanelControl15.Controls.Add(this.swOn1);
            this.flyoutPanelControl15.Controls.Add(this.barValue1);
            this.flyoutPanelControl15.Controls.Add(this.txtValue1);
            this.flyoutPanelControl15.Controls.Add(this.labelControl58);
            this.flyoutPanelControl15.Controls.Add(this.btnLightClose);
            this.flyoutPanelControl15.Controls.Add(this.btnLightSave);
            this.flyoutPanelControl15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl15.FlyoutPanel = this.flyLight;
            this.flyoutPanelControl15.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl15.Name = "flyoutPanelControl15";
            this.flyoutPanelControl15.Size = new System.Drawing.Size(537, 381);
            this.flyoutPanelControl15.TabIndex = 0;
            // 
            // groupControl10
            // 
            this.groupControl10.AppearanceCaption.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupControl10.AppearanceCaption.Options.UseFont = true;
            this.groupControl10.Controls.Add(this.txtChannelNo);
            this.groupControl10.Controls.Add(this.labelControl6);
            this.groupControl10.Controls.Add(this.cbPort_1);
            this.groupControl10.Controls.Add(this.lblLightConStatus1);
            this.groupControl10.Controls.Add(this.txtLightIP_1);
            this.groupControl10.Controls.Add(this.labelControl57);
            this.groupControl10.Controls.Add(this.labelControl56);
            this.groupControl10.Controls.Add(this.cbBaud_1);
            this.groupControl10.Controls.Add(this.txtLightPort_1);
            this.groupControl10.Location = new System.Drawing.Point(10, 66);
            this.groupControl10.Name = "groupControl10";
            this.groupControl10.Size = new System.Drawing.Size(489, 107);
            this.groupControl10.TabIndex = 55;
            this.groupControl10.Text = "컨트롤러_1";
            // 
            // txtChannelNo
            // 
            this.txtChannelNo.Location = new System.Drawing.Point(373, 68);
            this.txtChannelNo.MenuManager = this.barManager1;
            this.txtChannelNo.Name = "txtChannelNo";
            this.txtChannelNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtChannelNo.Properties.Appearance.Options.UseFont = true;
            this.txtChannelNo.Size = new System.Drawing.Size(100, 26);
            this.txtChannelNo.TabIndex = 49;
            this.txtChannelNo.Tag = "0";
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl6.Appearance.Options.UseFont = true;
            this.labelControl6.Appearance.Options.UseTextOptions = true;
            this.labelControl6.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl6.Location = new System.Drawing.Point(256, 72);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(111, 19);
            this.labelControl6.TabIndex = 48;
            this.labelControl6.Text = "CH No. : ";
            // 
            // cbPort_1
            // 
            this.cbPort_1.Location = new System.Drawing.Point(104, 33);
            this.cbPort_1.MenuManager = this.barManager1;
            this.cbPort_1.Name = "cbPort_1";
            this.cbPort_1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPort_1.Properties.Appearance.Options.UseFont = true;
            this.cbPort_1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPort_1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbPort_1.Size = new System.Drawing.Size(147, 26);
            this.cbPort_1.TabIndex = 21;
            // 
            // lblLightConStatus1
            // 
            this.lblLightConStatus1.Appearance.BackColor = System.Drawing.Color.Red;
            this.lblLightConStatus1.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLightConStatus1.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblLightConStatus1.Appearance.Options.UseBackColor = true;
            this.lblLightConStatus1.Appearance.Options.UseFont = true;
            this.lblLightConStatus1.Appearance.Options.UseForeColor = true;
            this.lblLightConStatus1.Appearance.Options.UseTextOptions = true;
            this.lblLightConStatus1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblLightConStatus1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLightConStatus1.Location = new System.Drawing.Point(439, 0);
            this.lblLightConStatus1.Name = "lblLightConStatus1";
            this.lblLightConStatus1.Size = new System.Drawing.Size(50, 20);
            this.lblLightConStatus1.TabIndex = 45;
            // 
            // txtLightIP_1
            // 
            this.txtLightIP_1.Location = new System.Drawing.Point(104, 33);
            this.txtLightIP_1.MenuManager = this.barManager1;
            this.txtLightIP_1.Name = "txtLightIP_1";
            this.txtLightIP_1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightIP_1.Properties.Appearance.Options.UseFont = true;
            this.txtLightIP_1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLightIP_1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLightIP_1.Size = new System.Drawing.Size(147, 26);
            this.txtLightIP_1.TabIndex = 43;
            this.txtLightIP_1.Tag = "0";
            this.txtLightIP_1.Visible = false;
            // 
            // labelControl57
            // 
            this.labelControl57.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl57.Appearance.Options.UseFont = true;
            this.labelControl57.Appearance.Options.UseTextOptions = true;
            this.labelControl57.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl57.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl57.Location = new System.Drawing.Point(-27, 38);
            this.labelControl57.Name = "labelControl57";
            this.labelControl57.Size = new System.Drawing.Size(128, 19);
            this.labelControl57.TabIndex = 22;
            this.labelControl57.Text = "Port : ";
            // 
            // labelControl56
            // 
            this.labelControl56.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl56.Appearance.Options.UseFont = true;
            this.labelControl56.Appearance.Options.UseTextOptions = true;
            this.labelControl56.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl56.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl56.Location = new System.Drawing.Point(-27, 72);
            this.labelControl56.Name = "labelControl56";
            this.labelControl56.Size = new System.Drawing.Size(128, 19);
            this.labelControl56.TabIndex = 25;
            this.labelControl56.Text = "Baudrate : ";
            // 
            // cbBaud_1
            // 
            this.cbBaud_1.Location = new System.Drawing.Point(104, 68);
            this.cbBaud_1.MenuManager = this.barManager1;
            this.cbBaud_1.Name = "cbBaud_1";
            this.cbBaud_1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBaud_1.Properties.Appearance.Options.UseFont = true;
            this.cbBaud_1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbBaud_1.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbBaud_1.Size = new System.Drawing.Size(147, 26);
            this.cbBaud_1.TabIndex = 26;
            // 
            // txtLightPort_1
            // 
            this.txtLightPort_1.Location = new System.Drawing.Point(104, 68);
            this.txtLightPort_1.MenuManager = this.barManager1;
            this.txtLightPort_1.Name = "txtLightPort_1";
            this.txtLightPort_1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLightPort_1.Properties.Appearance.Options.UseFont = true;
            this.txtLightPort_1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtLightPort_1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtLightPort_1.Size = new System.Drawing.Size(147, 26);
            this.txtLightPort_1.TabIndex = 44;
            this.txtLightPort_1.Tag = "0";
            this.txtLightPort_1.Visible = false;
            // 
            // chkLightUse4
            // 
            this.chkLightUse4.Location = new System.Drawing.Point(37, 283);
            this.chkLightUse4.MenuManager = this.barManager1;
            this.chkLightUse4.Name = "chkLightUse4";
            this.chkLightUse4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLightUse4.Properties.Appearance.Options.UseFont = true;
            this.chkLightUse4.Properties.Appearance.Options.UseTextOptions = true;
            this.chkLightUse4.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkLightUse4.Properties.AutoHeight = false;
            this.chkLightUse4.Properties.Caption = "CH 4 : ";
            this.chkLightUse4.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.chkLightUse4.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.Yellow;
            this.chkLightUse4.Size = new System.Drawing.Size(82, 19);
            this.chkLightUse4.TabIndex = 50;
            this.chkLightUse4.Tag = "4";
            this.chkLightUse4.CheckedChanged += new System.EventHandler(this.chkLightUse1_CheckedChanged);
            // 
            // chkLightUse3
            // 
            this.chkLightUse3.Location = new System.Drawing.Point(37, 250);
            this.chkLightUse3.MenuManager = this.barManager1;
            this.chkLightUse3.Name = "chkLightUse3";
            this.chkLightUse3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLightUse3.Properties.Appearance.Options.UseFont = true;
            this.chkLightUse3.Properties.Appearance.Options.UseTextOptions = true;
            this.chkLightUse3.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkLightUse3.Properties.AutoHeight = false;
            this.chkLightUse3.Properties.Caption = "CH 3 : ";
            this.chkLightUse3.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.chkLightUse3.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.Yellow;
            this.chkLightUse3.Size = new System.Drawing.Size(82, 19);
            this.chkLightUse3.TabIndex = 49;
            this.chkLightUse3.Tag = "3";
            this.chkLightUse3.CheckedChanged += new System.EventHandler(this.chkLightUse1_CheckedChanged);
            // 
            // chkLightUse2
            // 
            this.chkLightUse2.Location = new System.Drawing.Point(37, 216);
            this.chkLightUse2.MenuManager = this.barManager1;
            this.chkLightUse2.Name = "chkLightUse2";
            this.chkLightUse2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLightUse2.Properties.Appearance.Options.UseFont = true;
            this.chkLightUse2.Properties.Appearance.Options.UseTextOptions = true;
            this.chkLightUse2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkLightUse2.Properties.AutoHeight = false;
            this.chkLightUse2.Properties.Caption = "CH 2 : ";
            this.chkLightUse2.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.chkLightUse2.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.Yellow;
            this.chkLightUse2.Size = new System.Drawing.Size(82, 19);
            this.chkLightUse2.TabIndex = 48;
            this.chkLightUse2.Tag = "2";
            this.chkLightUse2.CheckedChanged += new System.EventHandler(this.chkLightUse1_CheckedChanged);
            // 
            // chkLightUse1
            // 
            this.chkLightUse1.Location = new System.Drawing.Point(38, 184);
            this.chkLightUse1.MenuManager = this.barManager1;
            this.chkLightUse1.Name = "chkLightUse1";
            this.chkLightUse1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLightUse1.Properties.Appearance.Options.UseFont = true;
            this.chkLightUse1.Properties.Appearance.Options.UseTextOptions = true;
            this.chkLightUse1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkLightUse1.Properties.AutoHeight = false;
            this.chkLightUse1.Properties.Caption = "CH 1 : ";
            this.chkLightUse1.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
            this.chkLightUse1.Properties.CheckBoxOptions.SvgColorChecked = System.Drawing.Color.Yellow;
            this.chkLightUse1.Size = new System.Drawing.Size(82, 19);
            this.chkLightUse1.TabIndex = 47;
            this.chkLightUse1.Tag = "1";
            this.chkLightUse1.CheckedChanged += new System.EventHandler(this.chkLightUse1_CheckedChanged);
            // 
            // radLightSerial
            // 
            this.radLightSerial.AutoSize = true;
            this.radLightSerial.Checked = true;
            this.radLightSerial.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLightSerial.ForeColor = System.Drawing.Color.Yellow;
            this.radLightSerial.Location = new System.Drawing.Point(154, 38);
            this.radLightSerial.Name = "radLightSerial";
            this.radLightSerial.Size = new System.Drawing.Size(61, 20);
            this.radLightSerial.TabIndex = 46;
            this.radLightSerial.TabStop = true;
            this.radLightSerial.Tag = "0";
            this.radLightSerial.Text = "Serial";
            this.radLightSerial.UseVisualStyleBackColor = true;
            this.radLightSerial.CheckedChanged += new System.EventHandler(this.radLightTCP_CheckedChanged);
            // 
            // radLightUDP
            // 
            this.radLightUDP.AutoSize = true;
            this.radLightUDP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radLightUDP.Location = new System.Drawing.Point(238, 38);
            this.radLightUDP.Name = "radLightUDP";
            this.radLightUDP.Size = new System.Drawing.Size(50, 20);
            this.radLightUDP.TabIndex = 45;
            this.radLightUDP.Tag = "1";
            this.radLightUDP.Text = "UDP";
            this.radLightUDP.UseVisualStyleBackColor = true;
            this.radLightUDP.CheckedChanged += new System.EventHandler(this.radLightTCP_CheckedChanged);
            // 
            // labelControl52
            // 
            this.labelControl52.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl52.Appearance.Options.UseFont = true;
            this.labelControl52.Appearance.Options.UseTextOptions = true;
            this.labelControl52.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl52.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl52.Location = new System.Drawing.Point(21, 35);
            this.labelControl52.Name = "labelControl52";
            this.labelControl52.Size = new System.Drawing.Size(128, 19);
            this.labelControl52.TabIndex = 42;
            this.labelControl52.Text = "Connect Type : ";
            // 
            // swOn4
            // 
            this.swOn4.Location = new System.Drawing.Point(394, 283);
            this.swOn4.MenuManager = this.barManager1;
            this.swOn4.Name = "swOn4";
            this.swOn4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swOn4.Properties.Appearance.Options.UseFont = true;
            this.swOn4.Properties.OffText = "Off";
            this.swOn4.Properties.OnText = "On";
            this.swOn4.Size = new System.Drawing.Size(105, 24);
            this.swOn4.TabIndex = 41;
            this.swOn4.Tag = "3";
            this.swOn4.Toggled += new System.EventHandler(this.swOn1_Toggled);
            // 
            // swOn3
            // 
            this.swOn3.Location = new System.Drawing.Point(394, 251);
            this.swOn3.MenuManager = this.barManager1;
            this.swOn3.Name = "swOn3";
            this.swOn3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swOn3.Properties.Appearance.Options.UseFont = true;
            this.swOn3.Properties.OffText = "Off";
            this.swOn3.Properties.OnText = "On";
            this.swOn3.Size = new System.Drawing.Size(105, 24);
            this.swOn3.TabIndex = 40;
            this.swOn3.Tag = "2";
            this.swOn3.Toggled += new System.EventHandler(this.swOn1_Toggled);
            // 
            // swOn2
            // 
            this.swOn2.Location = new System.Drawing.Point(394, 215);
            this.swOn2.MenuManager = this.barManager1;
            this.swOn2.Name = "swOn2";
            this.swOn2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swOn2.Properties.Appearance.Options.UseFont = true;
            this.swOn2.Properties.OffText = "Off";
            this.swOn2.Properties.OnText = "On";
            this.swOn2.Size = new System.Drawing.Size(105, 24);
            this.swOn2.TabIndex = 39;
            this.swOn2.Tag = "1";
            this.swOn2.Toggled += new System.EventHandler(this.swOn1_Toggled);
            // 
            // barValue4
            // 
            this.barValue4.EditValue = null;
            this.barValue4.Location = new System.Drawing.Point(118, 285);
            this.barValue4.MenuManager = this.barManager1;
            this.barValue4.Name = "barValue4";
            this.barValue4.Properties.AutoSize = false;
            this.barValue4.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.barValue4.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barValue4.Properties.LargeChange = 1;
            this.barValue4.Properties.Maximum = 255;
            this.barValue4.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barValue4.Size = new System.Drawing.Size(160, 25);
            this.barValue4.TabIndex = 37;
            this.barValue4.Tag = "3";
            this.barValue4.EditValueChanged += new System.EventHandler(this.barValue1_EditValueChanged);
            // 
            // txtValue4
            // 
            this.txtValue4.Location = new System.Drawing.Point(283, 282);
            this.txtValue4.MenuManager = this.barManager1;
            this.txtValue4.Name = "txtValue4";
            this.txtValue4.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue4.Properties.Appearance.Options.UseFont = true;
            this.txtValue4.Size = new System.Drawing.Size(100, 26);
            this.txtValue4.TabIndex = 36;
            this.txtValue4.Tag = "3";
            // 
            // barValue3
            // 
            this.barValue3.EditValue = null;
            this.barValue3.Location = new System.Drawing.Point(118, 251);
            this.barValue3.MenuManager = this.barManager1;
            this.barValue3.Name = "barValue3";
            this.barValue3.Properties.AutoSize = false;
            this.barValue3.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.barValue3.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barValue3.Properties.LargeChange = 1;
            this.barValue3.Properties.Maximum = 255;
            this.barValue3.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barValue3.Size = new System.Drawing.Size(160, 25);
            this.barValue3.TabIndex = 34;
            this.barValue3.Tag = "2";
            this.barValue3.EditValueChanged += new System.EventHandler(this.barValue1_EditValueChanged);
            // 
            // txtValue3
            // 
            this.txtValue3.Location = new System.Drawing.Point(283, 247);
            this.txtValue3.MenuManager = this.barManager1;
            this.txtValue3.Name = "txtValue3";
            this.txtValue3.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue3.Properties.Appearance.Options.UseFont = true;
            this.txtValue3.Size = new System.Drawing.Size(100, 26);
            this.txtValue3.TabIndex = 33;
            this.txtValue3.Tag = "2";
            // 
            // barValue2
            // 
            this.barValue2.EditValue = null;
            this.barValue2.Location = new System.Drawing.Point(118, 218);
            this.barValue2.MenuManager = this.barManager1;
            this.barValue2.Name = "barValue2";
            this.barValue2.Properties.AutoSize = false;
            this.barValue2.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.barValue2.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barValue2.Properties.LargeChange = 1;
            this.barValue2.Properties.Maximum = 255;
            this.barValue2.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barValue2.Size = new System.Drawing.Size(160, 25);
            this.barValue2.TabIndex = 31;
            this.barValue2.Tag = "1";
            this.barValue2.EditValueChanged += new System.EventHandler(this.barValue1_EditValueChanged);
            // 
            // txtValue2
            // 
            this.txtValue2.Location = new System.Drawing.Point(283, 214);
            this.txtValue2.MenuManager = this.barManager1;
            this.txtValue2.Name = "txtValue2";
            this.txtValue2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue2.Properties.Appearance.Options.UseFont = true;
            this.txtValue2.Size = new System.Drawing.Size(100, 26);
            this.txtValue2.TabIndex = 30;
            this.txtValue2.Tag = "1";
            // 
            // swOn1
            // 
            this.swOn1.Location = new System.Drawing.Point(394, 180);
            this.swOn1.MenuManager = this.barManager1;
            this.swOn1.Name = "swOn1";
            this.swOn1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.swOn1.Properties.Appearance.Options.UseFont = true;
            this.swOn1.Properties.OffText = "Off";
            this.swOn1.Properties.OnText = "On";
            this.swOn1.Size = new System.Drawing.Size(105, 24);
            this.swOn1.TabIndex = 28;
            this.swOn1.Tag = "0";
            this.swOn1.Toggled += new System.EventHandler(this.swOn1_Toggled);
            // 
            // barValue1
            // 
            this.barValue1.EditValue = null;
            this.barValue1.Location = new System.Drawing.Point(118, 184);
            this.barValue1.MenuManager = this.barManager1;
            this.barValue1.Name = "barValue1";
            this.barValue1.Properties.AutoSize = false;
            this.barValue1.Properties.LabelAppearance.Options.UseTextOptions = true;
            this.barValue1.Properties.LabelAppearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barValue1.Properties.LargeChange = 1;
            this.barValue1.Properties.Maximum = 255;
            this.barValue1.Properties.TickStyle = System.Windows.Forms.TickStyle.None;
            this.barValue1.Size = new System.Drawing.Size(160, 25);
            this.barValue1.TabIndex = 24;
            this.barValue1.Tag = "0";
            this.barValue1.EditValueChanged += new System.EventHandler(this.barValue1_EditValueChanged);
            // 
            // txtValue1
            // 
            this.txtValue1.Location = new System.Drawing.Point(283, 181);
            this.txtValue1.MenuManager = this.barManager1;
            this.txtValue1.Name = "txtValue1";
            this.txtValue1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue1.Properties.Appearance.Options.UseFont = true;
            this.txtValue1.Size = new System.Drawing.Size(100, 26);
            this.txtValue1.TabIndex = 23;
            this.txtValue1.Tag = "0";
            this.txtValue1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtValue1_KeyDown);
            // 
            // labelControl58
            // 
            this.labelControl58.Appearance.BackColor = System.Drawing.Color.White;
            this.labelControl58.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold);
            this.labelControl58.Appearance.ForeColor = System.Drawing.Color.Black;
            this.labelControl58.Appearance.Options.UseBackColor = true;
            this.labelControl58.Appearance.Options.UseFont = true;
            this.labelControl58.Appearance.Options.UseForeColor = true;
            this.labelControl58.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl58.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelControl58.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.labelControl58.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("labelControl58.ImageOptions.SvgImage")));
            this.labelControl58.Location = new System.Drawing.Point(2, 2);
            this.labelControl58.Name = "labelControl58";
            this.labelControl58.Size = new System.Drawing.Size(533, 26);
            this.labelControl58.TabIndex = 16;
            this.labelControl58.Text = "Light Setting";
            // 
            // btnLightClose
            // 
            this.btnLightClose.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLightClose.Appearance.Options.UseFont = true;
            this.btnLightClose.Appearance.Options.UseTextOptions = true;
            this.btnLightClose.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLightClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLightClose.ImageOptions.Image")));
            this.btnLightClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLightClose.Location = new System.Drawing.Point(272, 317);
            this.btnLightClose.Name = "btnLightClose";
            this.btnLightClose.Size = new System.Drawing.Size(114, 57);
            this.btnLightClose.TabIndex = 20;
            this.btnLightClose.Text = "Close";
            this.btnLightClose.Click += new System.EventHandler(this.btnLightClose_Click);
            // 
            // btnLightSave
            // 
            this.btnLightSave.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnLightSave.Appearance.Options.UseFont = true;
            this.btnLightSave.Appearance.Options.UseTextOptions = true;
            this.btnLightSave.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.btnLightSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnLightSave.ImageOptions.Image")));
            this.btnLightSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLightSave.Location = new System.Drawing.Point(151, 317);
            this.btnLightSave.Name = "btnLightSave";
            this.btnLightSave.Size = new System.Drawing.Size(114, 57);
            this.btnLightSave.TabIndex = 19;
            this.btnLightSave.Text = "Save";
            this.btnLightSave.Click += new System.EventHandler(this.btnLightSave_Click);
            // 
            // frmMain
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1443, 1068);
            this.Controls.Add(this.flySetting);
            this.Controls.Add(this.flyLight);
            this.Controls.Add(this.flyImgList);
            this.Controls.Add(this.flyIO);
            this.Controls.Add(this.flyImageSet);
            this.Controls.Add(this.lblMenu);
            this.Controls.Add(this.lblLog);
            this.Controls.Add(this.flyList);
            this.Controls.Add(this.pnl);
            this.Controls.Add(this.flyUserEdit);
            this.Controls.Add(this.flyResImg);
            this.Controls.Add(this.flyCamCnt);
            this.Controls.Add(this.lblPass);
            this.Controls.Add(this.flyChangePW);
            this.Controls.Add(this.flyLogin);
            this.Controls.Add(this.lblView);
            this.Controls.Add(this.flyLog);
            this.Controls.Add(this.flyAdmin);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("frmMain.IconOptions.Image")));
            this.IsMdiContainer = true;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VisionSystem";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Resize += new System.EventHandler(this.frmMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel9)).EndInit();
            this.tablePanel9.ResumeLayout(false);
            this.tablePanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUser.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel14)).EndInit();
            this.tablePanel14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyAdmin)).EndInit();
            this.flyAdmin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel5)).EndInit();
            this.tablePanel5.ResumeLayout(false);
            this.tablePanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel12)).EndInit();
            this.tablePanel12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel11)).EndInit();
            this.tablePanel11.ResumeLayout(false);
            this.tablePanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel8)).EndInit();
            this.tablePanel8.ResumeLayout(false);
            this.tablePanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel7)).EndInit();
            this.tablePanel7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel10)).EndInit();
            this.tablePanel10.ResumeLayout(false);
            this.tablePanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyImageSet)).EndInit();
            this.flyImageSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl4)).EndInit();
            this.flyoutPanelControl4.ResumeLayout(false);
            this.flyoutPanelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtOriginImgRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtResultImgRate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiskAlarm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swAutoImageDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ResetTimer.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDiskDelete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl4)).EndInit();
            this.panelControl4.ResumeLayout(false);
            this.panelControl4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.swOriginSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSaveImagePath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swResultSave.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyLog)).EndInit();
            this.flyLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl5)).EndInit();
            this.flyoutPanelControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyLogin)).EndInit();
            this.flyLogin.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl2)).EndInit();
            this.flyoutPanelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyChangePW)).EndInit();
            this.flyChangePW.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl3)).EndInit();
            this.flyoutPanelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl8)).EndInit();
            this.groupControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChangePW2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChangePW1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyCamCnt)).EndInit();
            this.flyCamCnt.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl7)).EndInit();
            this.flyoutPanelControl7.ResumeLayout(false);
            this.flyoutPanelControl7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtCamCnt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyResImg)).EndInit();
            this.flyResImg.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl9)).EndInit();
            this.flyoutPanelControl9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel3)).EndInit();
            this.tablePanel3.ResumeLayout(false);
            this.tablePanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDispOrigin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDispResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyImgList)).EndInit();
            this.flyImgList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl8)).EndInit();
            this.flyoutPanelControl8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.pnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp11)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp12)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp14)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp15)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp17)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp19)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp20)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flySetting)).EndInit();
            this.flySetting.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl14)).EndInit();
            this.flyoutPanelControl14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtLineInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl14)).EndInit();
            this.groupControl14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDBName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPW.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBID.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDBIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyIO)).EndInit();
            this.flyIO.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl6)).EndInit();
            this.flyoutPanelControl6.ResumeLayout(false);
            this.flyoutPanelControl6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl7)).EndInit();
            this.groupControl7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel4)).EndInit();
            this.tablePanel4.ResumeLayout(false);
            this.tablePanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl6)).EndInit();
            this.groupControl6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutSount.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutAir2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutAir1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutLight.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutLampR.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOOutLampG.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
            this.groupControl5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInShutter2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInShutter1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInStartSignal.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIOInSensor.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIODev.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toggleSwitch2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit6.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyUserEdit)).EndInit();
            this.flyUserEdit.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl11)).EndInit();
            this.flyoutPanelControl11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbLevel.Properties)).EndInit();
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyList)).EndInit();
            this.flyList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl12)).EndInit();
            this.flyoutPanelControl12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.listModel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyLight)).EndInit();
            this.flyLight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl15)).EndInit();
            this.flyoutPanelControl15.ResumeLayout(false);
            this.flyoutPanelControl15.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl10)).EndInit();
            this.groupControl10.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtChannelNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbPort_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLightIP_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbBaud_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtLightPort_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkLightUse1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.swOn1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barValue1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtValue1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void btnPrintConnect_Click(object sender, EventArgs e)
        {
            
        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnSetModel;
        private DevExpress.XtraEditors.SimpleButton btnSetCam;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.Utils.ImageCollection imageCollection1;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevExpress.Utils.Layout.TablePanel tablePanel9;
        private DevExpress.Utils.FlyoutPanel flyAdmin;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private DevExpress.Utils.Layout.TablePanel tablePanel14;
        private DevExpress.Utils.FlyoutPanel flyImageSet;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl4;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.RadioButton radResultJPG;
        private System.Windows.Forms.RadioButton radResultBMP;
        private DevExpress.XtraEditors.PanelControl panelControl4;
        private System.Windows.Forms.RadioButton radOriginJPG;
        private System.Windows.Forms.RadioButton radOriginBMP;
        private DevExpress.XtraEditors.SimpleButton btnImgpnlClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtSaveImagePath;
        private DevExpress.XtraEditors.LabelControl lblOriginImgPath;
        private DevExpress.XtraEditors.LabelControl lblresultImgformat;
        private DevExpress.XtraEditors.LabelControl lblresultImgsave;
        private DevExpress.XtraEditors.ToggleSwitch swResultSave;
        private DevExpress.XtraEditors.LabelControl lblOriginImgformat;
        private DevExpress.XtraEditors.LabelControl lblOriginImgsave;
        private DevExpress.XtraEditors.ToggleSwitch swOriginSave;
        private DevExpress.XtraEditors.SimpleButton btnSaveImagePath;
        private DevExpress.XtraEditors.LabelControl labelControl14;
        private DevExpress.Utils.FlyoutPanel flyLog;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl5;
        private DevExpress.XtraEditors.LabelControl lblView;
        private DevExpress.Utils.FlyoutPanel flyLogin;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl2;
        private DevExpress.XtraEditors.SimpleButton bntRecord;
        private DevExpress.XtraEditors.SimpleButton btnImgSet;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl lblPW;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnChkPass;
        private DevExpress.XtraEditors.SimpleButton btnUserManage;
        private DevExpress.Utils.FlyoutPanel flyChangePW;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl3;
        private DevExpress.XtraEditors.TextEdit txtChangePW2;
        private DevExpress.XtraEditors.LabelControl lblReenterPW;
        private DevExpress.XtraEditors.TextEdit txtChangePW1;
        private DevExpress.XtraEditors.LabelControl lblEnterPW;
        private DevExpress.XtraEditors.SimpleButton btnPWClose;
        private DevExpress.XtraEditors.SimpleButton btnUserEdit;
        private DevExpress.XtraEditors.LabelControl lblPass;
        private DevExpress.XtraEditors.SimpleButton btnReset;
        private DevExpress.Utils.FlyoutPanel flyCamCnt;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl7;
        private DevExpress.XtraEditors.SimpleButton btnCamClose;
        private DevExpress.XtraEditors.SimpleButton btnCamAdd;
        private DevExpress.XtraEditors.TextEdit txtCamCnt;
        private DevExpress.XtraEditors.LabelControl lblCamCnt;
        private DevExpress.XtraEditors.SimpleButton bntSetComm;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl lblCurrent;
        private DevExpress.XtraEditors.LabelControl lblPasswrod;
        private DevExpress.XtraEditors.LabelControl labelControl19;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private System.Windows.Forms.PictureBox pictureBox1;
        public DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx listAlarmMsg;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevComponents.DotNetBar.Controls.RichTextBoxEx listMsg;
        private DevExpress.Utils.FlyoutPanel flyResImg;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl9;
        private DevExpress.Utils.Layout.TablePanel tablePanel3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnListClose;
        private DevExpress.XtraEditors.SimpleButton btnLightSetting;
        private DevExpress.XtraEditors.SimpleButton btnPrevious;
        private DevExpress.XtraEditors.SimpleButton btnNext;
        private DevExpress.XtraEditors.SimpleButton btnResultDelete;
        private DevExpress.XtraEditors.LabelControl labelControl65;
        private DevExpress.XtraEditors.TextEdit txtDiskDelete;
        private DevExpress.XtraEditors.TimeEdit ResetTimer;
        private DevExpress.XtraEditors.LabelControl labelControl67;
        private DevExpress.XtraEditors.SimpleButton btnOriginalDelete;
        private DevExpress.XtraEditors.LabelControl labelControl72;
        private DevExpress.XtraEditors.TextEdit txtProcName;
        private DevExpress.Utils.FlyoutPanel flyImgList;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl8;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.SimpleButton btnImgListClose;
        private System.Windows.Forms.Panel pnlImage;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch1;
        private DevExpress.XtraEditors.LabelControl labelControl91;
        private DevExpress.XtraEditors.TextEdit txtDiskAlarm;
        private DevExpress.XtraEditors.LabelControl lblDiskusage;
        private DevExpress.XtraEditors.ToggleSwitch swAutoImageDelete;
        private DevExpress.XtraEditors.LabelControl lblautoImgdelete;
        private DevExpress.XtraEditors.SimpleButton btnSetting;
        private DevExpress.Utils.FlyoutPanel flySetting;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl14;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.GroupControl groupControl14;
        private DevExpress.XtraEditors.LabelControl labelControl96;
        private DevExpress.XtraEditors.LabelControl labelControl101;
        private DevExpress.XtraEditors.TextEdit txtDBPW;
        private DevExpress.XtraEditors.TextEdit txtDBPort;
        private DevExpress.XtraEditors.LabelControl labelControl97;
        private DevExpress.XtraEditors.LabelControl labelControl102;
        private DevExpress.XtraEditors.TextEdit txtDBID;
        private DevExpress.XtraEditors.TextEdit txtDBIP;
        private DevExpress.XtraEditors.LabelControl labelControl118;
        private DevExpress.XtraEditors.SimpleButton btnSetClose;
        private DevExpress.XtraEditors.SimpleButton btnSetSave;
        private DevExpress.XtraEditors.LabelControl labelControl92;
        private DevExpress.XtraEditors.TextEdit txtDBName;
        private Cognex.VisionPro.CogRecordDisplay cogDisp2;
        private Cognex.VisionPro.CogRecordDisplay cogDisp3;
        private Cognex.VisionPro.CogRecordDisplay cogDisp4;
        private Cognex.VisionPro.CogRecordDisplay cogDisp5;
        private Cognex.VisionPro.CogRecordDisplay cogDisp6;
        private Cognex.VisionPro.CogRecordDisplay cogDisp7;
        private Cognex.VisionPro.CogRecordDisplay cogDisp8;
        private Cognex.VisionPro.CogRecordDisplay cogDisp9;
        private Cognex.VisionPro.CogRecordDisplay cogDisp10;
        private Cognex.VisionPro.CogRecordDisplay cogDisp11;
        private Cognex.VisionPro.CogRecordDisplay cogDisp12;
        private Cognex.VisionPro.CogRecordDisplay cogDisp13;
        private Cognex.VisionPro.CogRecordDisplay cogDisp14;
        private Cognex.VisionPro.CogRecordDisplay cogDisp15;
        private Cognex.VisionPro.CogRecordDisplay cogDisp16;
        private Cognex.VisionPro.CogRecordDisplay cogDisp17;
        private Cognex.VisionPro.CogRecordDisplay cogDisp18;
        private Cognex.VisionPro.CogRecordDisplay cogDisp19;
        private Cognex.VisionPro.CogRecordDisplay cogDisp20;
        private Cognex.VisionPro.CogRecordDisplay cogDispResult;
        private Cognex.VisionPro.CogRecordDisplay cogDispOrigin;
        private Cognex.VisionPro.CogRecordDisplay cogDisp1;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.LabelControl labelControl23;
        private DevExpress.XtraEditors.TextEdit txtOriginImgRate;
        private DevExpress.XtraEditors.LabelControl labelControl24;
        private DevExpress.XtraEditors.LabelControl labelControl21;
        private DevExpress.XtraEditors.TextEdit txtResultImgRate;
        private DevExpress.XtraEditors.LabelControl labelControl22;
        private DevExpress.XtraEditors.SimpleButton btnIOSetting;
        private DevExpress.Utils.FlyoutPanel flyIO;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl6;
        private DevExpress.XtraEditors.ToggleSwitch toggleSwitch2;
        private DevExpress.XtraEditors.LabelControl labelControl34;
        private DevExpress.XtraEditors.TextEdit textEdit6;
        private DevExpress.XtraEditors.LabelControl labelControl36;
        private DevExpress.XtraEditors.TimeEdit timeEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl38;
        private DevExpress.XtraEditors.LabelControl labelControl41;
        private DevExpress.XtraEditors.SimpleButton btnIOClose;
        private DevExpress.XtraEditors.SimpleButton btnIOSave;
        private DevExpress.XtraEditors.LabelControl labelControl44;
        private DevExpress.XtraEditors.ComboBoxEdit cbIODev;
        private DevExpress.XtraEditors.GroupControl groupControl6;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraEditors.LabelControl labelControl39;
        private DevExpress.XtraEditors.TextEdit txtIOInStartSignal;
        private DevExpress.XtraEditors.TextEdit txtIOInSensor;
        private DevExpress.XtraEditors.LabelControl labelControl29;
        private DevExpress.XtraEditors.TextEdit txtIOInShutter2;
        private DevExpress.XtraEditors.LabelControl labelControl31;
        private DevExpress.XtraEditors.TextEdit txtIOInShutter1;
        private DevExpress.XtraEditors.LabelControl labelControl30;
        private DevExpress.XtraEditors.TextEdit txtIOOutAir2;
        private DevExpress.XtraEditors.LabelControl labelControl45;
        private DevExpress.XtraEditors.TextEdit txtIOOutAir1;
        private DevExpress.XtraEditors.LabelControl labelControl42;
        private DevExpress.XtraEditors.TextEdit txtIOOutLight;
        private DevExpress.XtraEditors.LabelControl labelControl40;
        private DevExpress.XtraEditors.TextEdit txtIOOutLampR;
        private DevExpress.XtraEditors.LabelControl labelControl37;
        private DevExpress.XtraEditors.TextEdit txtIOOutLampG;
        private DevExpress.XtraEditors.LabelControl labelControl32;
        private DevExpress.XtraEditors.TextEdit txtIOOutSount;
        private DevExpress.XtraEditors.LabelControl labelControl46;
        private DevExpress.XtraEditors.GroupControl groupControl7;
        private DevExpress.Utils.Layout.TablePanel tablePanel4;
        private DevExpress.XtraEditors.LabelControl lblOutStatus14;
        private DevExpress.XtraEditors.LabelControl lblOutStatus13;
        private DevExpress.XtraEditors.LabelControl lblOutStatus12;
        private DevExpress.XtraEditors.LabelControl lblOutStatus11;
        private DevExpress.XtraEditors.LabelControl lblOutStatus10;
        private DevExpress.XtraEditors.LabelControl lblOutStatus9;
        private DevExpress.XtraEditors.LabelControl lblOutStatus8;
        private DevExpress.XtraEditors.LabelControl lblOutStatus7;
        private DevExpress.XtraEditors.LabelControl lblOutStatus6;
        private DevExpress.XtraEditors.LabelControl lblOutStatus5;
        private DevExpress.XtraEditors.LabelControl lblOutStatus4;
        private DevExpress.XtraEditors.LabelControl lblOutStatus3;
        private DevExpress.XtraEditors.LabelControl lblOutStatus2;
        private DevExpress.XtraEditors.LabelControl lblOutStatus1;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_16;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_15;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_14;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_13;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_12;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_11;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_10;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_9;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_8;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_7;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_6;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_5;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_4;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_3;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_2;
        private DevExpress.XtraEditors.LabelControl lblIOOUT_1;
        private DevExpress.XtraEditors.LabelControl lblInStatus16;
        private DevExpress.XtraEditors.LabelControl lblInStatus15;
        private DevExpress.XtraEditors.LabelControl lblInStatus14;
        private DevExpress.XtraEditors.LabelControl lblInStatus13;
        private DevExpress.XtraEditors.LabelControl lblInStatus12;
        private DevExpress.XtraEditors.LabelControl lblInStatus11;
        private DevExpress.XtraEditors.LabelControl lblInStatus10;
        private DevExpress.XtraEditors.LabelControl lblInStatus9;
        private DevExpress.XtraEditors.LabelControl lblInStatus8;
        private DevExpress.XtraEditors.LabelControl lblInStatus7;
        private DevExpress.XtraEditors.LabelControl lblInStatus6;
        private DevExpress.XtraEditors.LabelControl lblInStatus5;
        private DevExpress.XtraEditors.LabelControl lblInStatus4;
        private DevExpress.XtraEditors.LabelControl lblInStatus3;
        private DevExpress.XtraEditors.LabelControl lblInStatus2;
        private DevExpress.XtraEditors.LabelControl lblIOIN_16;
        private DevExpress.XtraEditors.LabelControl lblIOIN_15;
        private DevExpress.XtraEditors.LabelControl lblIOIN_14;
        private DevExpress.XtraEditors.LabelControl lblIOIN_13;
        private DevExpress.XtraEditors.LabelControl lblIOIN_12;
        private DevExpress.XtraEditors.LabelControl lblIOIN_11;
        private DevExpress.XtraEditors.LabelControl lblIOIN_10;
        private DevExpress.XtraEditors.LabelControl lblIOIN_9;
        private DevExpress.XtraEditors.LabelControl lblIOIN_8;
        private DevExpress.XtraEditors.LabelControl lblIOIN_7;
        private DevExpress.XtraEditors.LabelControl lblIOIN_6;
        private DevExpress.XtraEditors.LabelControl lblIOIN_5;
        private DevExpress.XtraEditors.LabelControl lblIOIN_4;
        private DevExpress.XtraEditors.LabelControl lblIOIN_3;
        private DevExpress.XtraEditors.LabelControl lblIOIN_2;
        private DevExpress.XtraEditors.LabelControl lblInStatus1;
        private DevExpress.XtraEditors.LabelControl lblIOIN_1;
        private DevExpress.XtraEditors.LabelControl lblOutStatus16;
        private DevExpress.XtraEditors.LabelControl lblOutStatus15;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl93;
        private DevExpress.XtraEditors.LabelControl labelControl95;
        private DevExpress.XtraEditors.TextEdit txtUser;
        private DevExpress.Utils.FlyoutPanel flyUserEdit;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl11;
        private DevExpress.XtraEditors.TextEdit txtID;
        private DevExpress.XtraEditors.LabelControl lblUser;
        private DevExpress.XtraEditors.SimpleButton btnUserEditClose;
        private DevExpress.XtraEditors.SimpleButton btnUserChk;
        private DevExpress.XtraEditors.TextEdit txtPW;
        private DevExpress.XtraEditors.LabelControl lblPassword;
        private DevExpress.XtraEditors.SimpleButton btnUserAdd;
        private DevExpress.XtraEditors.SimpleButton btnUserDel;
        private DevExpress.XtraEditors.LabelControl lblMatch2;
        private DevExpress.XtraEditors.LabelControl labelControl33;
        private DevExpress.XtraEditors.ComboBoxEdit cbLevel;
        private DevExpress.XtraEditors.LabelControl labelControl35;
        private DevExpress.XtraEditors.TextEdit txtLineInfo;
        private System.Windows.Forms.Panel pnl;
        private DevExpress.Utils.Layout.TablePanel tablePanel5;
        private DevExpress.XtraEditors.LabelControl lblResult;
        private DevExpress.Utils.Layout.TablePanel tablePanel8;
        private DevExpress.XtraEditors.LabelControl lblNGCnt;
        private DevExpress.XtraEditors.LabelControl lblOKCnt;
        private DevExpress.XtraEditors.LabelControl lblTotalCnt;
        private DevExpress.XtraEditors.LabelControl lblNGRate;
        private DevExpress.XtraEditors.LabelControl lblOKRate;
        private DevExpress.Utils.Layout.TablePanel tablePanel7;
        private DevExpress.XtraEditors.SimpleButton btnLog;
        private DevExpress.XtraEditors.SimpleButton btnMenu;
        private DevExpress.Utils.Layout.TablePanel tablePanel11;
        private DevExpress.XtraEditors.LabelControl lblLotNo;
        private DevExpress.XtraEditors.LabelControl labelControl54;
        private DevExpress.XtraEditors.LabelControl labelControl53;
        private DevExpress.Utils.Layout.TablePanel tablePanel10;
        private DevExpress.XtraEditors.LabelControl lblModel;
        private DevExpress.XtraEditors.LabelControl lblIO;
        private DevExpress.XtraEditors.LabelControl lblLic;
        private DevExpress.XtraEditors.LabelControl lblPLC;
        private DevExpress.Utils.Layout.TablePanel tablePanel12;
        private DevComponents.DotNetBar.Controls.ProgressBarX Bar2;
        private DevExpress.Utils.FlyoutPanel flyList;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl12;
        public DevExpress.XtraEditors.ListBoxControl listModel;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar4;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.LabelControl lblLog;
        private DevComponents.DotNetBar.Controls.ProgressBarX Bar1;
        private DevExpress.XtraEditors.LabelControl lblMenu;
        private DevExpress.Utils.FlyoutPanel flyLight;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl15;
        private DevExpress.XtraEditors.TrackBarControl barValue4;
        private DevExpress.XtraEditors.TextEdit txtValue4;
        private DevExpress.XtraEditors.TrackBarControl barValue3;
        private DevExpress.XtraEditors.TextEdit txtValue3;
        private DevExpress.XtraEditors.TrackBarControl barValue2;
        private DevExpress.XtraEditors.TextEdit txtValue2;
        private DevExpress.XtraEditors.ToggleSwitch swOn1;
        private DevExpress.XtraEditors.ComboBoxEdit cbBaud_1;
        private DevExpress.XtraEditors.LabelControl labelControl56;
        private DevExpress.XtraEditors.TrackBarControl barValue1;
        private DevExpress.XtraEditors.TextEdit txtValue1;
        private DevExpress.XtraEditors.LabelControl labelControl57;
        private DevExpress.XtraEditors.ComboBoxEdit cbPort_1;
        private DevExpress.XtraEditors.LabelControl labelControl58;
        private DevExpress.XtraEditors.SimpleButton btnLightClose;
        private DevExpress.XtraEditors.SimpleButton btnLightSave;
        private DevExpress.XtraEditors.ToggleSwitch swOn4;
        private DevExpress.XtraEditors.ToggleSwitch swOn3;
        private DevExpress.XtraEditors.ToggleSwitch swOn2;
        private DevExpress.XtraEditors.LabelControl labelControl52;
        private DevExpress.XtraEditors.TextEdit txtLightPort_1;
        private DevExpress.XtraEditors.TextEdit txtLightIP_1;
        private System.Windows.Forms.RadioButton radLightSerial;
        private System.Windows.Forms.RadioButton radLightUDP;
        private DevExpress.XtraEditors.GroupControl groupControl8;
        private System.Windows.Forms.DataGridView dgUser;
        private DevExpress.XtraEditors.CheckEdit chkLightUse1;
        private DevExpress.XtraEditors.CheckEdit chkLightUse4;
        private DevExpress.XtraEditors.CheckEdit chkLightUse3;
        private DevExpress.XtraEditors.CheckEdit chkLightUse2;
        private DevExpress.XtraEditors.GroupControl groupControl10;
        private DevExpress.XtraEditors.LabelControl lblDLpath;
        private DevExpress.XtraEditors.LabelControl labelControl48;
        private DevExpress.XtraEditors.LabelControl labelControl55;
        private DevExpress.XtraEditors.LabelControl lblLightConStatus1;
        private DevExpress.XtraEditors.LabelControl lblLight;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.TextEdit txtChannelNo;
    }
}

