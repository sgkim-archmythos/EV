namespace VisionSystem
{
    partial class frmCamera
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCamera));
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.lblcamcntTitle = new DevComponents.DotNetBar.LabelX();
            this.lblCamCnt = new DevComponents.DotNetBar.LabelX();
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.cogView = new Cognex.VisionPro.Display.CogDisplay();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.radKeyenceVJ = new System.Windows.Forms.RadioButton();
            this.tabCam = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.lblConnect = new DevExpress.XtraEditors.LabelControl();
            this.labelControl15 = new DevExpress.XtraEditors.LabelControl();
            this.cbPixelFormat = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnWhiteOff = new DevExpress.XtraEditors.SimpleButton();
            this.btnWhiteOnce = new DevExpress.XtraEditors.SimpleButton();
            this.lblWhiteBalance = new DevExpress.XtraEditors.LabelControl();
            this.sliderExpose = new DevComponents.DotNetBar.Controls.Slider();
            this.lblSerial = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cbIP = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.txtExpose = new DevExpress.XtraEditors.TextEdit();
            this.radHIK = new System.Windows.Forms.RadioButton();
            this.lblCam = new DevExpress.XtraEditors.LabelControl();
            this.btnCopy = new DevExpress.XtraEditors.SimpleButton();
            this.cbCamNo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnLive = new DevExpress.XtraEditors.SimpleButton();
            this.btnConnect = new DevExpress.XtraEditors.SimpleButton();
            this.btnCamSearch = new DevExpress.XtraEditors.SimpleButton();
            this.btnGrab = new DevExpress.XtraEditors.SimpleButton();
            this.radBalser = new System.Windows.Forms.RadioButton();
            this.cbCogPort = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.highlighter1 = new DevComponents.DotNetBar.Validator.Highlighter();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::VisionSystem.WaitForm1), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCam)).BeginInit();
            this.tabCam.SuspendLayout();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cbPixelFormat.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIP.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpose.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCamNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCogPort.Properties)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Appearance.Options.UseFont = true;
            this.highlighter1.SetHighlightOnFocus(this.btnSave, true);
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnSave.Location = new System.Drawing.Point(497, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(121, 41);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.Options.UseFont = true;
            this.highlighter1.SetHighlightOnFocus(this.btnClose, true);
            this.btnClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.ImageOptions.Image")));
            this.btnClose.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnClose.Location = new System.Drawing.Point(624, 5);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(121, 41);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblcamcntTitle
            // 
            // 
            // 
            // 
            this.lblcamcntTitle.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblcamcntTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblcamcntTitle.Location = new System.Drawing.Point(8, 4);
            this.lblcamcntTitle.Name = "lblcamcntTitle";
            this.lblcamcntTitle.Size = new System.Drawing.Size(135, 23);
            this.lblcamcntTitle.TabIndex = 2;
            this.lblcamcntTitle.Text = "Camera Count : ";
            this.lblcamcntTitle.TextAlignment = System.Drawing.StringAlignment.Far;
            // 
            // lblCamCnt
            // 
            // 
            // 
            // 
            this.lblCamCnt.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblCamCnt.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCamCnt.Location = new System.Drawing.Point(148, 4);
            this.lblCamCnt.Name = "lblCamCnt";
            this.lblCamCnt.Size = new System.Drawing.Size(111, 23);
            this.lblCamCnt.TabIndex = 3;
            this.lblCamCnt.Text = "0";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 5F)});
            this.tablePanel1.Controls.Add(this.tablePanel2);
            this.tablePanel1.Controls.Add(this.panel1);
            this.tablePanel1.Controls.Add(this.panelControl2);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(0, 0);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 30F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 438.3F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.AutoSize, 40F)});
            this.tablePanel1.Size = new System.Drawing.Size(1248, 768);
            this.tablePanel1.TabIndex = 5;
            // 
            // tablePanel2
            // 
            this.tablePanel1.SetColumn(this.tablePanel2, 0);
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 524F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 33.4F)});
            this.tablePanel2.Controls.Add(this.cogView);
            this.tablePanel2.Controls.Add(this.panelControl3);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(3, 40);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel1.SetRow(this.tablePanel2, 1);
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel2.Size = new System.Drawing.Size(1242, 666);
            this.tablePanel2.TabIndex = 7;
            // 
            // cogView
            // 
            this.cogView.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogView.ColorMapLowerRoiLimit = 0D;
            this.cogView.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogView.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogView.ColorMapUpperRoiLimit = 1D;
            this.tablePanel2.SetColumn(this.cogView, 1);
            this.cogView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogView.DoubleTapZoomCycleLength = 2;
            this.cogView.DoubleTapZoomSensitivity = 2.5D;
            this.cogView.Location = new System.Drawing.Point(527, 3);
            this.cogView.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogView.MouseWheelSensitivity = 1D;
            this.cogView.Name = "cogView";
            this.cogView.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogView.OcxState")));
            this.tablePanel2.SetRow(this.cogView, 0);
            this.cogView.Size = new System.Drawing.Size(712, 660);
            this.cogView.TabIndex = 7;
            // 
            // panelControl3
            // 
            this.tablePanel2.SetColumn(this.panelControl3, 0);
            this.panelControl3.Controls.Add(this.radKeyenceVJ);
            this.panelControl3.Controls.Add(this.tabCam);
            this.panelControl3.Controls.Add(this.radHIK);
            this.panelControl3.Controls.Add(this.lblCam);
            this.panelControl3.Controls.Add(this.btnCopy);
            this.panelControl3.Controls.Add(this.cbCamNo);
            this.panelControl3.Controls.Add(this.btnLive);
            this.panelControl3.Controls.Add(this.btnConnect);
            this.panelControl3.Controls.Add(this.btnCamSearch);
            this.panelControl3.Controls.Add(this.btnGrab);
            this.panelControl3.Controls.Add(this.radBalser);
            this.panelControl3.Controls.Add(this.cbCogPort);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(3, 3);
            this.panelControl3.Name = "panelControl3";
            this.tablePanel2.SetRow(this.panelControl3, 0);
            this.panelControl3.Size = new System.Drawing.Size(518, 660);
            this.panelControl3.TabIndex = 6;
            this.panelControl3.Tag = "1";
            // 
            // radKeyenceVJ
            // 
            this.radKeyenceVJ.AutoSize = true;
            this.radKeyenceVJ.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radKeyenceVJ.Location = new System.Drawing.Point(11, 144);
            this.radKeyenceVJ.Name = "radKeyenceVJ";
            this.radKeyenceVJ.Size = new System.Drawing.Size(159, 22);
            this.radKeyenceVJ.TabIndex = 32;
            this.radKeyenceVJ.TabStop = true;
            this.radKeyenceVJ.Tag = "3";
            this.radKeyenceVJ.Text = "KEYENCE_VJ SDK";
            this.radKeyenceVJ.UseVisualStyleBackColor = true;
            this.radKeyenceVJ.CheckedChanged += new System.EventHandler(this.radBalser_CheckedChanged);
            this.radKeyenceVJ.Click += new System.EventHandler(this.radBalser_Click);
            // 
            // tabCam
            // 
            this.tabCam.Appearance.Options.UseTextOptions = true;
            this.tabCam.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tabCam.AppearancePage.Header.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCam.AppearancePage.Header.Options.UseFont = true;
            this.tabCam.AppearancePage.Header.Options.UseTextOptions = true;
            this.tabCam.AppearancePage.Header.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.tabCam.AppearancePage.HeaderActive.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabCam.AppearancePage.HeaderActive.ForeColor = System.Drawing.Color.Yellow;
            this.tabCam.AppearancePage.HeaderActive.Options.UseFont = true;
            this.tabCam.AppearancePage.HeaderActive.Options.UseForeColor = true;
            this.tabCam.Location = new System.Drawing.Point(5, 188);
            this.tabCam.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabCam.Name = "tabCam";
            this.tabCam.SelectedTabPage = this.xtraTabPage2;
            this.tabCam.Size = new System.Drawing.Size(508, 245);
            this.tabCam.TabIndex = 31;
            this.tabCam.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage2});
            this.tabCam.TabPageWidth = 100;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.lblConnect);
            this.xtraTabPage2.Controls.Add(this.labelControl15);
            this.xtraTabPage2.Controls.Add(this.cbPixelFormat);
            this.xtraTabPage2.Controls.Add(this.btnWhiteOff);
            this.xtraTabPage2.Controls.Add(this.btnWhiteOnce);
            this.xtraTabPage2.Controls.Add(this.lblWhiteBalance);
            this.xtraTabPage2.Controls.Add(this.sliderExpose);
            this.xtraTabPage2.Controls.Add(this.lblSerial);
            this.xtraTabPage2.Controls.Add(this.labelControl8);
            this.xtraTabPage2.Controls.Add(this.cbIP);
            this.xtraTabPage2.Controls.Add(this.labelControl10);
            this.xtraTabPage2.Controls.Add(this.labelControl11);
            this.xtraTabPage2.Controls.Add(this.txtExpose);
            this.xtraTabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(506, 217);
            this.xtraTabPage2.Text = "Information";
            // 
            // lblConnect
            // 
            this.lblConnect.Appearance.BackColor = System.Drawing.Color.Red;
            this.lblConnect.Appearance.Font = new System.Drawing.Font("Tahoma", 17.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblConnect.Appearance.ForeColor = System.Drawing.Color.White;
            this.lblConnect.Appearance.Options.UseBackColor = true;
            this.lblConnect.Appearance.Options.UseFont = true;
            this.lblConnect.Appearance.Options.UseForeColor = true;
            this.lblConnect.Appearance.Options.UseTextOptions = true;
            this.lblConnect.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblConnect.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblConnect.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lblConnect.Location = new System.Drawing.Point(0, 179);
            this.lblConnect.Name = "lblConnect";
            this.lblConnect.Size = new System.Drawing.Size(506, 38);
            this.lblConnect.TabIndex = 36;
            this.lblConnect.Text = "Disconnected";
            // 
            // labelControl15
            // 
            this.labelControl15.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl15.Appearance.Options.UseFont = true;
            this.labelControl15.Appearance.Options.UseTextOptions = true;
            this.labelControl15.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl15.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl15.Location = new System.Drawing.Point(11, 80);
            this.labelControl15.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl15.Name = "labelControl15";
            this.labelControl15.Size = new System.Drawing.Size(121, 18);
            this.labelControl15.TabIndex = 34;
            this.labelControl15.Text = "Pixel Format : ";
            // 
            // cbPixelFormat
            // 
            this.cbPixelFormat.Location = new System.Drawing.Point(145, 76);
            this.cbPixelFormat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbPixelFormat.Name = "cbPixelFormat";
            this.cbPixelFormat.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPixelFormat.Properties.Appearance.Options.UseFont = true;
            this.cbPixelFormat.Properties.Appearance.Options.UseTextOptions = true;
            this.cbPixelFormat.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.cbPixelFormat.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPixelFormat.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbPixelFormat.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbPixelFormat.Size = new System.Drawing.Size(258, 26);
            this.cbPixelFormat.TabIndex = 35;
            // 
            // btnWhiteOff
            // 
            this.btnWhiteOff.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhiteOff.Appearance.Options.UseFont = true;
            this.btnWhiteOff.Location = new System.Drawing.Point(237, 138);
            this.btnWhiteOff.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWhiteOff.Name = "btnWhiteOff";
            this.btnWhiteOff.Size = new System.Drawing.Size(86, 30);
            this.btnWhiteOff.TabIndex = 33;
            this.btnWhiteOff.Text = "Off";
            this.btnWhiteOff.Visible = false;
            // 
            // btnWhiteOnce
            // 
            this.btnWhiteOnce.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnWhiteOnce.Appearance.Options.UseFont = true;
            this.btnWhiteOnce.Location = new System.Drawing.Point(145, 138);
            this.btnWhiteOnce.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnWhiteOnce.Name = "btnWhiteOnce";
            this.btnWhiteOnce.Size = new System.Drawing.Size(86, 30);
            this.btnWhiteOnce.TabIndex = 32;
            this.btnWhiteOnce.Text = "Once";
            this.btnWhiteOnce.Visible = false;
            // 
            // lblWhiteBalance
            // 
            this.lblWhiteBalance.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWhiteBalance.Appearance.Options.UseFont = true;
            this.lblWhiteBalance.Appearance.Options.UseTextOptions = true;
            this.lblWhiteBalance.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblWhiteBalance.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWhiteBalance.Location = new System.Drawing.Point(11, 142);
            this.lblWhiteBalance.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblWhiteBalance.Name = "lblWhiteBalance";
            this.lblWhiteBalance.Size = new System.Drawing.Size(121, 18);
            this.lblWhiteBalance.TabIndex = 31;
            this.lblWhiteBalance.Text = "White Balance : ";
            this.lblWhiteBalance.Visible = false;
            // 
            // sliderExpose
            // 
            // 
            // 
            // 
            this.sliderExpose.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.sliderExpose.Enabled = false;
            this.highlighter1.SetHighlightOnFocus(this.sliderExpose, true);
            this.sliderExpose.LabelVisible = false;
            this.sliderExpose.Location = new System.Drawing.Point(146, 105);
            this.sliderExpose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.sliderExpose.Name = "sliderExpose";
            this.sliderExpose.Size = new System.Drawing.Size(161, 30);
            this.sliderExpose.Style = DevComponents.DotNetBar.eDotNetBarStyle.VS2005;
            this.sliderExpose.TabIndex = 29;
            this.sliderExpose.Value = 0;
            this.sliderExpose.ValueChanged += new System.EventHandler(this.sliderExpose_ValueChanged);
            // 
            // lblSerial
            // 
            this.lblSerial.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSerial.Appearance.Options.UseFont = true;
            this.lblSerial.Appearance.Options.UseTextOptions = true;
            this.lblSerial.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.lblSerial.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSerial.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.lblSerial.Location = new System.Drawing.Point(145, 38);
            this.lblSerial.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lblSerial.Name = "lblSerial";
            this.lblSerial.Size = new System.Drawing.Size(261, 33);
            this.lblSerial.TabIndex = 26;
            this.lblSerial.Text = "-";
            // 
            // labelControl8
            // 
            this.labelControl8.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl8.Appearance.Options.UseFont = true;
            this.labelControl8.Appearance.Options.UseTextOptions = true;
            this.labelControl8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl8.Location = new System.Drawing.Point(11, 11);
            this.labelControl8.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(121, 18);
            this.labelControl8.TabIndex = 14;
            this.labelControl8.Text = "IP Address : ";
            // 
            // cbIP
            // 
            this.cbIP.Location = new System.Drawing.Point(145, 7);
            this.cbIP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbIP.Name = "cbIP";
            this.cbIP.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIP.Properties.Appearance.Options.UseFont = true;
            this.cbIP.Properties.Appearance.Options.UseTextOptions = true;
            this.cbIP.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Near;
            this.cbIP.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIP.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbIP.Properties.AutoHeight = false;
            this.cbIP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbIP.Size = new System.Drawing.Size(355, 27);
            this.cbIP.TabIndex = 15;
            this.cbIP.SelectedIndexChanged += new System.EventHandler(this.cbIP_SelectedIndexChanged);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl10.Appearance.Options.UseFont = true;
            this.labelControl10.Appearance.Options.UseTextOptions = true;
            this.labelControl10.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl10.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl10.Location = new System.Drawing.Point(11, 43);
            this.labelControl10.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(121, 18);
            this.labelControl10.TabIndex = 16;
            this.labelControl10.Text = "Serial No : ";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl11.Appearance.Options.UseFont = true;
            this.labelControl11.Appearance.Options.UseTextOptions = true;
            this.labelControl11.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.labelControl11.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.labelControl11.Location = new System.Drawing.Point(11, 112);
            this.labelControl11.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(121, 18);
            this.labelControl11.TabIndex = 21;
            this.labelControl11.Text = "Exposure : ";
            // 
            // txtExpose
            // 
            this.txtExpose.Enabled = false;
            this.txtExpose.Location = new System.Drawing.Point(313, 106);
            this.txtExpose.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExpose.Name = "txtExpose";
            this.txtExpose.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtExpose.Properties.Appearance.Options.UseFont = true;
            this.txtExpose.Properties.Appearance.Options.UseTextOptions = true;
            this.txtExpose.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.txtExpose.Size = new System.Drawing.Size(90, 26);
            this.txtExpose.TabIndex = 20;
            this.txtExpose.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtExpose_KeyDown);
            // 
            // radHIK
            // 
            this.radHIK.AutoSize = true;
            this.radHIK.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radHIK.Location = new System.Drawing.Point(11, 111);
            this.radHIK.Name = "radHIK";
            this.radHIK.Size = new System.Drawing.Size(89, 22);
            this.radHIK.TabIndex = 30;
            this.radHIK.TabStop = true;
            this.radHIK.Tag = "2";
            this.radHIK.Text = "HIK SDK";
            this.radHIK.UseVisualStyleBackColor = true;
            this.radHIK.CheckedChanged += new System.EventHandler(this.radBalser_CheckedChanged);
            this.radHIK.Click += new System.EventHandler(this.radBalser_Click);
            // 
            // lblCam
            // 
            this.lblCam.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCam.Appearance.Options.UseFont = true;
            this.lblCam.Location = new System.Drawing.Point(11, 26);
            this.lblCam.Name = "lblCam";
            this.lblCam.Size = new System.Drawing.Size(95, 18);
            this.lblCam.TabIndex = 0;
            this.lblCam.Text = "Camera No : ";
            // 
            // btnCopy
            // 
            this.btnCopy.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Appearance.Options.UseFont = true;
            this.highlighter1.SetHighlightOnFocus(this.btnCopy, true);
            this.btnCopy.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCopy.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCopy.ImageOptions.SvgImage")));
            this.btnCopy.Location = new System.Drawing.Point(249, 18);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(91, 33);
            this.btnCopy.TabIndex = 28;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // cbCamNo
            // 
            this.highlighter1.SetHighlightOnFocus(this.cbCamNo, true);
            this.cbCamNo.Location = new System.Drawing.Point(111, 23);
            this.cbCamNo.Name = "cbCamNo";
            this.cbCamNo.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamNo.Properties.Appearance.Options.UseFont = true;
            this.cbCamNo.Properties.AppearanceDropDown.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCamNo.Properties.AppearanceDropDown.Options.UseFont = true;
            this.cbCamNo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCamNo.Size = new System.Drawing.Size(123, 24);
            this.cbCamNo.TabIndex = 1;
            this.cbCamNo.SelectedIndexChanged += new System.EventHandler(this.cbCamNo_SelectedIndexChanged);
            // 
            // btnLive
            // 
            this.btnLive.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLive.Appearance.Options.UseFont = true;
            this.highlighter1.SetHighlightOnFocus(this.btnLive, true);
            this.btnLive.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnLive.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnLive.ImageOptions.SvgImage")));
            this.btnLive.Location = new System.Drawing.Point(325, 440);
            this.btnLive.Name = "btnLive";
            this.btnLive.Size = new System.Drawing.Size(121, 41);
            this.btnLive.TabIndex = 2;
            this.btnLive.Text = "Live";
            this.btnLive.Click += new System.EventHandler(this.btnLive_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Appearance.Options.UseFont = true;
            this.highlighter1.SetHighlightOnFocus(this.btnConnect, true);
            this.btnConnect.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnConnect.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnConnect.ImageOptions.SvgImage")));
            this.btnConnect.Location = new System.Drawing.Point(73, 440);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(121, 41);
            this.btnConnect.TabIndex = 26;
            this.btnConnect.Text = "Connect";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // btnCamSearch
            // 
            this.btnCamSearch.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCamSearch.Appearance.Options.UseFont = true;
            this.highlighter1.SetHighlightOnFocus(this.btnCamSearch, true);
            this.btnCamSearch.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnCamSearch.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnCamSearch.ImageOptions.SvgImage")));
            this.btnCamSearch.Location = new System.Drawing.Point(396, 5);
            this.btnCamSearch.Name = "btnCamSearch";
            this.btnCamSearch.Size = new System.Drawing.Size(118, 54);
            this.btnCamSearch.TabIndex = 27;
            this.btnCamSearch.Text = "Search";
            this.btnCamSearch.Click += new System.EventHandler(this.btnCamSearch_Click);
            // 
            // btnGrab
            // 
            this.btnGrab.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGrab.Appearance.Options.UseFont = true;
            this.highlighter1.SetHighlightOnFocus(this.btnGrab, true);
            this.btnGrab.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.btnGrab.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnGrab.ImageOptions.SvgImage")));
            this.btnGrab.Location = new System.Drawing.Point(199, 440);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(121, 41);
            this.btnGrab.TabIndex = 1;
            this.btnGrab.Text = "Grab";
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // radBalser
            // 
            this.radBalser.AutoSize = true;
            this.radBalser.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radBalser.Location = new System.Drawing.Point(11, 78);
            this.radBalser.Name = "radBalser";
            this.radBalser.Size = new System.Drawing.Size(109, 22);
            this.radBalser.TabIndex = 9;
            this.radBalser.TabStop = true;
            this.radBalser.Tag = "1";
            this.radBalser.Text = "Basler SDK";
            this.radBalser.UseVisualStyleBackColor = true;
            this.radBalser.CheckedChanged += new System.EventHandler(this.radBalser_CheckedChanged);
            this.radBalser.Click += new System.EventHandler(this.radBalser_Click);
            // 
            // cbCogPort
            // 
            this.cbCogPort.Location = new System.Drawing.Point(152, 547);
            this.cbCogPort.Name = "cbCogPort";
            this.cbCogPort.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCogPort.Properties.Appearance.Options.UseFont = true;
            this.cbCogPort.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbCogPort.Size = new System.Drawing.Size(188, 24);
            this.cbCogPort.TabIndex = 7;
            this.cbCogPort.Visible = false;
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl4.Appearance.Options.UseFont = true;
            this.labelControl4.Location = new System.Drawing.Point(101, 550);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(45, 18);
            this.labelControl4.TabIndex = 6;
            this.labelControl4.Text = "Port : ";
            this.labelControl4.Visible = false;
            // 
            // panel1
            // 
            this.tablePanel1.SetColumn(this.panel1, 0);
            this.panel1.Controls.Add(this.btnSave);
            this.panel1.Controls.Add(this.btnClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 712);
            this.panel1.Name = "panel1";
            this.tablePanel1.SetRow(this.panel1, 2);
            this.panel1.Size = new System.Drawing.Size(1242, 53);
            this.panel1.TabIndex = 6;
            // 
            // panelControl2
            // 
            this.tablePanel1.SetColumn(this.panelControl2, 0);
            this.panelControl2.Controls.Add(this.lblcamcntTitle);
            this.panelControl2.Controls.Add(this.lblCamCnt);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl2.Location = new System.Drawing.Point(3, 3);
            this.panelControl2.Name = "panelControl2";
            this.tablePanel1.SetRow(this.panelControl2, 0);
            this.panelControl2.Size = new System.Drawing.Size(1242, 31);
            this.panelControl2.TabIndex = 4;
            // 
            // highlighter1
            // 
            this.highlighter1.ContainerControl = this;
            this.highlighter1.FocusHighlightColor = DevComponents.DotNetBar.Validator.eHighlightColor.Orange;
            this.highlighter1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // frmCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1248, 768);
            this.Controls.Add(this.tablePanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.IconOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("frmCamera.IconOptions.SvgImage")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1250, 800);
            this.MinimumSize = new System.Drawing.Size(1250, 800);
            this.Name = "frmCamera";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Camera Setting";
            this.Load += new System.EventHandler(this.frmCamera_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabCam)).EndInit();
            this.tabCam.ResumeLayout(false);
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cbPixelFormat.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbIP.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpose.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCamNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbCogPort.Properties)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevComponents.DotNetBar.LabelX lblcamcntTitle;
        private DevComponents.DotNetBar.LabelX lblCamCnt;
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton btnLive;
        private DevExpress.XtraEditors.SimpleButton btnGrab;
        private DevExpress.XtraEditors.LabelControl lblCam;
        private DevExpress.XtraEditors.ComboBoxEdit cbCamNo;
        private DevExpress.XtraEditors.ComboBoxEdit cbCogPort;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private System.Windows.Forms.RadioButton radBalser;
        private DevExpress.XtraEditors.SimpleButton btnConnect;
        private DevExpress.XtraEditors.SimpleButton btnCamSearch;
        private DevComponents.DotNetBar.Validator.Highlighter highlighter1;
        private DevExpress.XtraEditors.SimpleButton btnCopy;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private System.Windows.Forms.RadioButton radHIK;
        private DevExpress.XtraTab.XtraTabControl tabCam;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.LabelControl lblConnect;
        private DevExpress.XtraEditors.LabelControl labelControl15;
        private DevExpress.XtraEditors.ComboBoxEdit cbPixelFormat;
        private DevExpress.XtraEditors.SimpleButton btnWhiteOff;
        private DevExpress.XtraEditors.SimpleButton btnWhiteOnce;
        private DevExpress.XtraEditors.LabelControl lblWhiteBalance;
        private DevComponents.DotNetBar.Controls.Slider sliderExpose;
        private DevExpress.XtraEditors.LabelControl lblSerial;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cbIP;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit txtExpose;
        private Cognex.VisionPro.Display.CogDisplay cogView;
        private System.Windows.Forms.RadioButton radKeyenceVJ;
    }
}