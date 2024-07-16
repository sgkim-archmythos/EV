using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.ImageFile;

using static GlovalVar;


namespace VisionSystem
{
    public partial class frmToolSetup : DevExpress.XtraEditors.XtraForm
    {
        frmMain _frmMain;
        frmModel _frmModel;
        CogToolGroup _toolGrp = new CogToolGroup();
        CogImageConvertTool _cogImageConvertTool = new CogImageConvertTool();
        ICogImage _cogImg = null;
        IniFiles ini = new IniFiles();

        public frmToolSetup(frmModel ModelFrm, frmMain MainFrm)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            _frmModel = ModelFrm;
            _frmMain = MainFrm;

            this.Width = _frmMain.Width;
            this.Height = _frmMain.Height;

            cbModel.Properties.Items.Clear();
            cbModel.Properties.Items.Add("Select Model");

            foreach (string str in _listModel)
                cbModel.Properties.Items.Add(str);

            cbModel.SelectedIndex = 0;

            cbCamera.Properties.Items.Clear();
            cbCamera.Properties.Items.Add("Select Camera");

            for (int i = 0; i < _nScreenCnt; i++)
                cbCamera.Properties.Items.Add(string.Format("Camera{0}", i + 1));

            cbCamera.SelectedIndex = 0;

            _toolGrp = CogSerializer.LoadObjectFromFile(Application.StartupPath + "\\vpp\\Default.vpp") as CogToolGroup;
            _cogImageConvertTool = _toolGrp.Tools["CogImageConvertTool1"] as CogImageConvertTool;

            cogToolGroupEdit.Subject = _toolGrp;
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

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void frmToolSetup_Load(object sender, EventArgs e)
        {
            ActiveControl = cogToolGroupEdit;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (cbModel.SelectedIndex == -1 || cbCamera.SelectedIndex == -1 || lblCodeName.Text == "")
            {
                MessageBox.Show("Please enter the model information to save.", "Input Model Infomation", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                string strPath = string.Format("{0}\\vpp\\Camera_{1:D2}", Application.StartupPath, cbCamera.SelectedIndex);
                DirectoryInfo dr = new DirectoryInfo(strPath);
                var strFileName = "";

                if (!dr.Exists)
                    dr.Create();

                if (_cogImageConvertTool.InputImage != null)
                {
                    using (CogImageFileJPEG cogJPG = new CogImageFileJPEG())
                    {
                        cogJPG.Open(string.Format(Application.StartupPath + "\\MasterImage\\Camera_{0:D2}\\{1}.jpg", cbCamera.SelectedIndex, txtCodeName.Text), CogImageFileModeConstants.Write);
                        cogJPG.Append(_cogImageConvertTool.InputImage);
                        cogJPG.Close();
                        cogJPG.Dispose();
                    }
                }
                    
                _toolGrp = cogToolGroupEdit.Subject;
                CogSerializer.SaveObjectToFile(_toolGrp, strPath + "\\" + txtCodeName.Text + ".vpp", typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);

                _frmMain.AddMsg("New Model file saved", Color.GreenYellow, true, false, GlovalVar.MsgType.Alarm);
            }
            catch { }
        }

        private void frmToolSetup_FormClosing(object sender, FormClosingEventArgs e)
        {
            //_frmModel.Show();
            //_frmModel.TopMost = true;
        }

        private void frmToolSetup_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
            else e.Effect = DragDropEffects.None;
        }

        private void frmToolSetup_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                string[] strFilePath = (string[])e.Data.GetData(DataFormats.FileDrop);
                
                foreach (string str in strFilePath)
                {
                    using (Bitmap bmp = new Bitmap(Bitmap.FromFile(str)))
                    {
                        _cogImageConvertTool.InputImage = new CogImage24PlanarColor(bmp);
                        _cogImageConvertTool.Run();

                        _cogImg = _cogImageConvertTool.InputImage;
                    }
                }
            }
            catch { }
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Image Open";
            ofd.InitialDirectory = Application.StartupPath + "\\MasterImage";
            ofd.Filter = "Image File (*.bmp,*.jpg,*.png) | *.bmp;*.jpg;*.png; | All Files (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                using (Bitmap bmp = new Bitmap(Bitmap.FromFile(ofd.FileName)))
                {
                    try
                    {
                        _cogImageConvertTool.InputImage = new CogImage24PlanarColor(bmp);
                        _cogImageConvertTool.Run();
                        _cogImg = _cogImageConvertTool.InputImage;
                    }
                    catch { }
                }
            }
        }
    }
}