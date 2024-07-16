namespace VisionSystem
{
    partial class CodeControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CodeControl));
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.lblComment = new DevExpress.XtraEditors.LabelControl();
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.lblCodeName = new DevExpress.XtraEditors.LabelControl();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.chkUse = new DevExpress.XtraEditors.CheckEdit();
            this.pnl = new DevExpress.XtraEditors.PanelControl();
            this.cogDisp = new Cognex.VisionPro.Display.CogDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkUse.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl)).BeginInit();
            this.pnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp)).BeginInit();
            this.SuspendLayout();
            // 
            // tablePanel1
            // 
            this.tablePanel1.Appearance.BorderColor = System.Drawing.Color.Lime;
            this.tablePanel1.Appearance.Options.UseBorderColor = true;
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 87F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 205F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 50F)});
            this.tablePanel1.Controls.Add(this.cogDisp);
            this.tablePanel1.Controls.Add(this.lblComment);
            this.tablePanel1.Controls.Add(this.panelControl3);
            this.tablePanel1.Controls.Add(this.panelControl1);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(2, 2);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 26F)});
            this.tablePanel1.Size = new System.Drawing.Size(486, 185);
            this.tablePanel1.TabIndex = 0;
            // 
            // lblComment
            // 
            this.lblComment.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblComment.Appearance.Options.UseFont = true;
            this.lblComment.Appearance.Options.UseTextOptions = true;
            this.lblComment.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblComment.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblComment.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.tablePanel1.SetColumn(this.lblComment, 3);
            this.lblComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblComment.Location = new System.Drawing.Point(345, 3);
            this.lblComment.Name = "lblComment";
            this.tablePanel1.SetRow(this.lblComment, 0);
            this.lblComment.Size = new System.Drawing.Size(138, 179);
            this.lblComment.TabIndex = 3;
            this.lblComment.Text = "Comment";
            this.lblComment.MouseClick += new System.Windows.Forms.MouseEventHandler(this.lblCodeName_MouseClick);
            // 
            // panelControl3
            // 
            this.tablePanel1.SetColumn(this.panelControl3, 1);
            this.panelControl3.Controls.Add(this.lblCodeName);
            this.panelControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl3.Location = new System.Drawing.Point(53, 3);
            this.panelControl3.Name = "panelControl3";
            this.tablePanel1.SetRow(this.panelControl3, 0);
            this.panelControl3.Size = new System.Drawing.Size(81, 179);
            this.panelControl3.TabIndex = 1;
            // 
            // lblCodeName
            // 
            this.lblCodeName.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeName.Appearance.Options.UseFont = true;
            this.lblCodeName.Appearance.Options.UseTextOptions = true;
            this.lblCodeName.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCodeName.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblCodeName.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblCodeName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCodeName.Location = new System.Drawing.Point(2, 2);
            this.lblCodeName.Name = "lblCodeName";
            this.lblCodeName.Size = new System.Drawing.Size(77, 175);
            this.lblCodeName.TabIndex = 3;
            this.lblCodeName.Text = "Test";
            // 
            // panelControl1
            // 
            this.tablePanel1.SetColumn(this.panelControl1, 0);
            this.panelControl1.Controls.Add(this.chkUse);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControl1.Location = new System.Drawing.Point(3, 3);
            this.panelControl1.Name = "panelControl1";
            this.tablePanel1.SetRow(this.panelControl1, 0);
            this.panelControl1.Size = new System.Drawing.Size(44, 179);
            this.panelControl1.TabIndex = 0;
            // 
            // chkUse
            // 
            this.chkUse.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chkUse.Location = new System.Drawing.Point(2, 2);
            this.chkUse.Name = "chkUse";
            this.chkUse.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkUse.Properties.Appearance.Options.UseFont = true;
            this.chkUse.Properties.AutoHeight = false;
            this.chkUse.Properties.Caption = "";
            this.chkUse.Properties.ContentAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.chkUse.Size = new System.Drawing.Size(40, 175);
            this.chkUse.TabIndex = 5;
            this.chkUse.CheckedChanged += new System.EventHandler(this.chkUse_CheckedChanged);
            // 
            // pnl
            // 
            this.pnl.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.pnl.Controls.Add(this.tablePanel1);
            this.pnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl.Location = new System.Drawing.Point(0, 0);
            this.pnl.Name = "pnl";
            this.pnl.Size = new System.Drawing.Size(490, 189);
            this.pnl.TabIndex = 1;
            this.pnl.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // cogDisp
            // 
            this.cogDisp.ColorMapLowerClipColor = System.Drawing.Color.Black;
            this.cogDisp.ColorMapLowerRoiLimit = 0D;
            this.cogDisp.ColorMapPredefined = Cognex.VisionPro.Display.CogDisplayColorMapPredefinedConstants.None;
            this.cogDisp.ColorMapUpperClipColor = System.Drawing.Color.Black;
            this.cogDisp.ColorMapUpperRoiLimit = 1D;
            this.tablePanel1.SetColumn(this.cogDisp, 2);
            this.cogDisp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cogDisp.DoubleTapZoomCycleLength = 2;
            this.cogDisp.DoubleTapZoomSensitivity = 2.5D;
            this.cogDisp.Location = new System.Drawing.Point(140, 3);
            this.cogDisp.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.cogDisp.MouseWheelSensitivity = 1D;
            this.cogDisp.Name = "cogDisp";
            this.cogDisp.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("cogDisp.OcxState")));
            this.tablePanel1.SetRow(this.cogDisp, 0);
            this.cogDisp.Size = new System.Drawing.Size(199, 179);
            this.cogDisp.TabIndex = 4;
            // 
            // CodeControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnl);
            this.MaximumSize = new System.Drawing.Size(490, 189);
            this.MinimumSize = new System.Drawing.Size(490, 189);
            this.Name = "CodeControl";
            this.Size = new System.Drawing.Size(490, 189);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkUse.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnl)).EndInit();
            this.pnl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cogDisp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        public DevExpress.XtraEditors.LabelControl lblComment;
        public DevExpress.XtraEditors.PanelControl panelControl1;
        public DevExpress.XtraEditors.PanelControl pnl;
        public DevExpress.XtraEditors.CheckEdit chkUse;
        public DevExpress.XtraEditors.LabelControl lblCodeName;
        private Cognex.VisionPro.Display.CogDisplay cogDisp;
    }
}
