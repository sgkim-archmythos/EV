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

using static GlovalVar;

namespace VisionSystem
{
    
    public partial class frmMDI : DevExpress.XtraEditors.XtraForm
    {
        frmMain _frmMain;
        int _nIdx;
        IniFiles ini = new IniFiles();

        public frmMDI(frmMain MainFrm, int nIdx)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            MdiParent = MainFrm;
            _frmMain = MainFrm;
            _nIdx = nIdx;

            var strName = ini.ReadIniFile("Name", "Value", Application.StartupPath + "\\Config", "Config.ini");

            this.Text = strName == "" ? "Camera #" + (_nIdx + 1).ToString() : strName;
            WindowState = FormWindowState.Maximized;
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

        private void frmMDI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason != CloseReason.MdiFormClosing)
            {
                if (MessageBox.Show(Str.FormDel, "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                    return;
                }

                if (_nScreenCnt > 0)
                {
                    _nScreenCnt--;
                    ini.WriteIniFile("ScreenCnt", "Value", _nScreenCnt.ToString(), _strConfigPath, "Config.ini");
                }
            }
        }

        private void frmMDI_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void frmMDI_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] strFilePath = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string str in strFilePath)
                {
                    using (Bitmap bmp = new Bitmap(Bitmap.FromFile(str)))
                    {
                        _frmMain._CAM[_nIdx].cogDisp.StaticGraphics.Clear();
                        _frmMain._CAM[_nIdx].cogDisp.InteractiveGraphics.Clear();

                        using(var cogImg = new CogImage24PlanarColor(bmp))
                        {
                            _frmMain._CAM[_nIdx].cogDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                            _frmMain._CAM[_nIdx].SendImg = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                        }
                    }

                    _frmMain._CAM[_nIdx].cogDisp.AutoFit = true;
                }
            }
            catch { }
        }

        private void frmMDI_Resize(object sender, EventArgs e)
        {
            try
            {
                _frmMain._CAM[_nIdx].SetMenuPosition(this.Width);
            }
            catch { }
        }

        public void ChangeName(string strName)
        {
            try
            {
                this.Text = strName == "" ? "Camera #" + (_nIdx + 1).ToString() : strName;
                ini.WriteIniFile("Name", "Value", strName, Application.StartupPath + "\\Config", "Config.ini");
            }
            catch { }
        }
    }
}