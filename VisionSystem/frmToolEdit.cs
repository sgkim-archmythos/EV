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
using System.Threading;
using System.IO;

using Cognex.VisionPro;
using Cognex.VisionPro.ToolGroup;
using Cognex.VisionPro.ImageProcessing;
using Cognex.VisionPro.Dimensioning;
using Cognex.VisionPro.Caliper;
using Cognex.VisionPro.PMAlign;
using Cognex.VisionPro.CalibFix;
using Cognex.VisionPro.Blob;
using Cognex.VisionPro.ColorMatch;
using Cognex.VisionPro.ColorExtractor;
using Cognex.VisionPro.ColorSegmenter;
using Cognex.VisionPro.CompositeColorMatch;
using Cognex.VisionPro.OCRMax;
using Cognex.VisionPro.OCVMax;
using Cognex.VisionPro.LineMax;
using Cognex.VisionPro.ResultsAnalysis;
using Cognex.VisionPro.ID;
using Cognex.VisionPro.ToolBlock;
using Cognex.VisionPro.Display;
using static GlovalVar;
using System.Security.Cryptography;

namespace VisionSystem
{
    public partial class frmToolEdit : DevExpress.XtraEditors.XtraForm
    {
        CAM _cam;
        int _nCamNo = 0;

        ToolEdit _toolEdit = new ToolEdit();

        IniFiles ini = new IniFiles();
        //public CogToolGroup _JobTool = null;
        List<CogImageConvertTool> _listConvertTool = new List<CogImageConvertTool>();

        int _nCurrentIndx = 0;
        bool _bLoad = false;

        Font font = new Font("굴림", 9, FontStyle.Bold);

        ToolType _toolType = ToolType.Light;

        int _nDispNo = -1;
        int _nImgListCnt = 0;

        int _nWidth = 0;
        int _nHeight = 0;

        Bitmap[] _bmpImg = null;

        VproInspection _vPro = new VproInspection();

        private enum PanelType
        {
            ToolEdit,
            ToolDetail,
            ToolGroup
        }

        private enum ToolRes
        {
            Green,
            Red,
            Gray,
            Yellow
        }

        private enum ControlType
        {
            PMAlign,
            Blob
        }

        public frmToolEdit(CAM cam, int nCameraNo)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            _cam = cam;
            _nCamNo = nCameraNo;

            lblCamName.Text = string.Format("#{0} Camera", _nCamNo + 1);
            lblDate.Text = "-";

            var strCodes = Directory.GetFiles(string.Format("{0}\\vpp\\Camera_{1:D2}", Application.StartupPath, _nCamNo + 1), "*.vpp");

            for (var i = 0; i < strCodes.Length; i++)
                cbCodeName.Properties.Items.Add(Path.GetFileNameWithoutExtension(strCodes[i]));

            cbCodeName.EditValue = _modelParam[_nCamNo].strCode;

            this.ResizeRedraw = true;
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


        private void GetFileLastWriteTime()
        {
            if (cbCodeName.SelectedIndex >-1)
            {
                DateTime dt = File.GetLastWriteTime(string.Format("{0}\\vpp\\Camera_{1:D2}\\{2}.vpp", Application.StartupPath, _nCamNo + 1, cbCodeName.SelectedItem.ToString()));
                lblDate.Text = dt.ToString("yy-MM-dd HH:mm:ss");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Hide();
            Close();
        }

        public void LoadSet(ICogImage cogImg)
        {
            try
            {
                _nCurrentIndx = -1;
                string[] strName = typeof(ToolEdit.ToolList).GetEnumNames();

                for (int i = 0; i < strName.Length; i++)
                {
                    tabToolList.TabPages[i].Text = strName[i];
                    tabToolList.TabPages[i].PageVisible = false;
                }

                if (cbCodeName.SelectedIndex >-1) 
                    _vPro.VJoblode(string.Format("{0}\\vpp\\Camera_{1:D2}\\{2}.vpp", Application.StartupPath, _nCamNo + 1, cbCodeName.SelectedItem.ToString()), cogImg);

                SetToolList();

                cogToolGroup.Subject = _vPro.GetJob;

                GetFileLastWriteTime();
                ToolDisp.Tool = null;

                ToolLoading(cogImg);

                _vPro.GetJob.Run();
                RunStatus();

                btnAllTool.PerformClick();

                Thread threadShowPopup = new Thread(ShowDisp);
                threadShowPopup.Start();
            }
            catch (Exception ex)
            {
                _cam._OnMessage("ToolEdit Load Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private void ShowDisp()
        {
            _toolType = ToolType.Light;
            ToolLoad(_nCurrentIndx);
        }

        private void ToolLoading(ICogImage cogImg)
        {
            if (_vPro.GetJob.Tools.Count == 0)
                return;

            bool bLoad = false;
            int nCnt = 0;

            for (var i = 0; i < _vPro.GetJob.Tools.Count; i++)
            {
                if (_vPro.GetJob.Tools[i].GetType() == typeof(CogImageConvertTool))
                {
                    _listConvertTool.Add(_vPro.GetJob.Tools[i] as CogImageConvertTool);

                    if (cogImg != null)
                    {
                        _listConvertTool[nCnt].InputImage = cogImg;

                        cogInspImg.AutoFit = true;
                        cogInspImg.Image = cogImg;
                    }

                    if (!bLoad)
                    {
                        _nCurrentIndx = i;

                        Thread threadLoad = new Thread(() => imageConvertControl.LoadSet(_listConvertTool[nCnt]));
                        threadLoad.Start();
                        Delay(100);
                    }

                    nCnt++;
                }
            }
        }

        private void SetToolList()
        {
            listcontrol.Items.Clear();

            try
            {
                if (_vPro.GetJob == null)
                {
                    MessageBox.Show("The task file was not loaded", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var nCnt = _vPro.GetJob.Tools.Count;
                var nListCnt = 0;

                for (int i = 0; i < nCnt; i++)
                {
                    listcontrol.Items.Add(_vPro.GetJob.Tools[i].Name);
                    listcontrol.Items[nListCnt++].ImageOptions.ImageIndex = (int)ToolRes.Gray;
                }
            }
            catch (Exception ex)
            {
                _cam._OnMessage("ToolEdit Init Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private void btnGrab_Click(object sender, EventArgs e)
        {
            _cam.Grab(true, _modelParam[_nCamNo].dExpose);

            Thread.Sleep(200);

            if (_cam.cogDisp.Image != null)
            {
                if (_listConvertTool != null)
                {
                    for (var i = 0; i<_listConvertTool.Count; i++)
                        _listConvertTool[i].InputImage = _cam.cogDisp.Image;

                    //JobRun();
                    //JobRun();
                }
            }
            else
                MessageBox.Show("No Input Image", "No Image", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private DateTime Delay(int MS)
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


        private void btnOpenImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Title = "Image Open";
            ofd.InitialDirectory = _SaveImgParam._strSaveImagePath;
            ofd.Filter = "Image File (*.bmp,*.jpg,*.png) | *.bmp;*.jpg;*.png; | All Files (*.*) | *.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var strFiles = ofd.FileNames;
                Thread threadOpemImgs = new Thread(() => OpenImgs(strFiles));
                threadOpemImgs.Start();
            }
        }

        private void OpenImgs(string[] strImgFiles)
        {
            var strFiles = strImgFiles;

            try
            {
                _nDispNo = 0;
                _nImgListCnt = 0;

                _bmpImg = null;
                _bmpImg = new Bitmap[strFiles.Length];

                for (var i = 0; i < strFiles.Length; i++)
                {
                    using (FileStream fs = new FileStream(strFiles[i], FileMode.Open, FileAccess.Read, FileShare.Read))
                    {
                        using (Image img = Image.FromStream(fs))
                        {
                            using (Bitmap bmpimg = new Bitmap(img))
                                _bmpImg[i] = (Bitmap)bmpimg.Clone();
                        }
                    }

                    if (i == 0 || i==1)
                    {
                        if (i == 0)
                        {
                            if (_listConvertTool != null)
                            {
                                cogInspImg.AutoFit = true;
                                cogInspImg.Image = new CogImage24PlanarColor((Bitmap)_bmpImg[_nDispNo].Clone());

                                for (var j = 0; j < _listConvertTool.Count; j++)
                                    _listConvertTool[j].InputImage = cogInspImg.Image;
                                //_CogImageConvertTool.InputImage = cogInspImg.Image;
                                
                                JobRun();
                            }
                        }
                        else if (i == 1)
                        {
                            cogDispNext.AutoFit = true;
                            cogDispNext.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo]);
                        }
                    }
                }
            }
            catch { }
        }

        private void JobRun()
        {
            try
            {
                if (_vPro.GetJob == null)
                    return;

                _vPro.GetJob.Run();

                if (_vPro.GetJob.RunStatus.Result == CogToolResultConstants.Accept)
                {
                    for (int i = 0; i < listcontrol.ItemCount; i++)
                        listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Green;
                }
                else
                {
                    for (int i = 0; i < listcontrol.ItemCount; i++)
                        listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Red;

                    for (int i = 0; i < _vPro.GetJob.Tools.Count; i++)
                    {
                        if (_vPro.GetJob.Tools[i].RunStatus.Result == CogToolResultConstants.Error)
                        {
                            listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Red;
                            MessageBox.Show(string.Format("{0} RunStatus Error : {1}", _vPro.GetJob.Tools[i].Name, _vPro.GetJob.Tools[i].RunStatus.Message), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else if (_vPro.GetJob.Tools[i].RunStatus.Result == CogToolResultConstants.Accept)
                            listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Green;
                        else if (_vPro.GetJob.Tools[i].RunStatus.Result == CogToolResultConstants.Warning)
                            listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Yellow;
                    }
                }
            }
            catch (Exception ex)
            {
                _cam._OnMessage("Image Open Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private enum ToolType
        {
            Light,
            Detail,
            All
        }

        private void listcontrol_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            int nSel = listcontrol.SelectedIndex;
            if (nSel == -1)
                return;

            if (_vPro.GetJob == null)
                return;

            if (_nCurrentIndx == nSel)
                return;

            if (!splashScreenManager1.IsSplashFormVisible)
                splashScreenManager1.ShowWaitForm();

            _nCurrentIndx = nSel;

            _toolType = ToolType.Light;
            ToolLoad(_nCurrentIndx);

            if (splashScreenManager1.IsSplashFormVisible)
                splashScreenManager1.CloseWaitForm();
        }

        private void SetToolPage(string strToolnName)
        {
            var nNo = 0;
            var strNames = typeof(ToolEdit.ToolList).GetEnumNames();
            var strTemp = strToolnName.Split('.');

            Invoke(new EventHandler(delegate
            {
                for (int i = 0; i < strNames.Length; i++)
                {
                    tabToolList.TabPages[i].PageVisible = false;

                    if (strNames[i].Contains(strTemp[strTemp.Length - 1]))
                        nNo = i;
                }

                tabToolList.TabPages[nNo].PageVisible = true;
            }));
        }

        private void ToolLoad(int nSelectNo)
        {
            var nSel = nSelectNo;

            _bLoad = false;

            Thread threadSetPage = new Thread(() => SetToolPage(_vPro.GetJob.Tools[nSel].GetType().ToString()));
            threadSetPage.Start();

            Invoke(new EventHandler(delegate
            {
                try
                {
                    pnlDeltailTool.Controls.Clear();

                    if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogImageConvertTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogImageConvertTool;

                        if (_toolType == ToolType.Detail)
                        {
                            var cogImageConvertEditV2 = new CogImageConvertEditV2();
                            pnlDeltailTool.Controls.Add(cogImageConvertEditV2);
                            cogImageConvertEditV2.Dock = DockStyle.Fill;
                            cogImageConvertEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogImageConvertTool;
                            cogImageConvertEditV2.Font = font;
                            cogImageConvertEditV2.ForeColor = Color.Black;
                        }
                        else
                            imageConvertControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogImageConvertTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIPOneImageTool))
                    {
                        _toolType = ToolType.Detail;
                        var cogIPOneImageEditV2 = new CogIPOneImageEditV2();
                        pnlDeltailTool.Controls.Add(cogIPOneImageEditV2);
                        cogIPOneImageEditV2.Dock = DockStyle.Fill;
                        cogIPOneImageEditV2.Font = font;
                        cogIPOneImageEditV2.ForeColor = Color.Black;
                        cogIPOneImageEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIPOneImageTool;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogBlobTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogBlobTool;

                        if (_toolType == ToolType.Detail)
                        {
                            var cogBlobEditV2 = new CogBlobEditV2();
                            pnlDeltailTool.Controls.Add(cogBlobEditV2);
                            cogBlobEditV2.Dock = DockStyle.Fill;
                            cogBlobEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogBlobTool;
                            cogBlobEditV2.Font = font;
                            cogBlobEditV2.ForeColor = Color.Black;
                        }
                        else
                            blobControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogBlobTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogCaliperTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogCaliperTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogCaliperEditV2 cogCaliperEditV2 = new CogCaliperEditV2();
                            pnlDeltailTool.Controls.Add(cogCaliperEditV2);
                            cogCaliperEditV2.Dock = DockStyle.Fill;
                            cogCaliperEditV2.Font = font;
                            cogCaliperEditV2.ForeColor = Color.Black;
                            cogCaliperEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogCaliperTool;
                        }
                        else
                            caliperControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogCaliperTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDataAnalysisTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDataAnalysisEditV2 CogDataAnalysisEditV = new CogDataAnalysisEditV2();
                        pnlDeltailTool.Controls.Add(CogDataAnalysisEditV);
                        CogDataAnalysisEditV.Dock = DockStyle.Fill;
                        CogDataAnalysisEditV.Font = font;
                        CogDataAnalysisEditV.ForeColor = Color.Black;
                        CogDataAnalysisEditV.Subject = _vPro.GetJob.Tools[nSel] as CogDataAnalysisTool;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogPMAlignTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogPMAlignTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogPMAlignEditV2 cogPMAlignEditV2 = new CogPMAlignEditV2();
                            pnlDeltailTool.Controls.Add(cogPMAlignEditV2);
                            cogPMAlignEditV2.Dock = DockStyle.Fill;
                            cogPMAlignEditV2.Subject = (_vPro.GetJob.Tools[nSel] as CogPMAlignTool);
                        }
                        else
                            pmAlignControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogPMAlignTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogResultsAnalysisTool))
                    {
                        _toolType = ToolType.Detail;

                        CogResultsAnalysisEdit cogResultsAnalysisEdit = new CogResultsAnalysisEdit();
                        pnlDeltailTool.Controls.Add(cogResultsAnalysisEdit);
                        cogResultsAnalysisEdit.Font = font;
                        cogResultsAnalysisEdit.ForeColor = Color.Black;
                        cogResultsAnalysisEdit.Dock = DockStyle.Fill;
                        cogResultsAnalysisEdit.Subject = (_vPro.GetJob.Tools[nSel] as CogResultsAnalysisTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogCreateCircleTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogCreateCircleTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogCreateCircleEditV2 cogCreateCircleEditV2 = new CogCreateCircleEditV2();
                            pnlDeltailTool.Controls.Add(cogCreateCircleEditV2);
                            cogCreateCircleEditV2.Font = font;
                            cogCreateCircleEditV2.ForeColor = Color.Black;
                            cogCreateCircleEditV2.Dock = DockStyle.Fill;
                            cogCreateCircleEditV2.Subject = (_vPro.GetJob.Tools[nSel] as CogCreateCircleTool);
                        }
                        else
                            createCircle.LoadSet(_vPro.GetJob.Tools[nSel] as CogCreateCircleTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogCreateEllipseTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogCreateEllipseTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogCreateEllipseEditV2 cogCreateEllipseEditV2 = new CogCreateEllipseEditV2();
                            pnlDeltailTool.Controls.Add(cogCreateEllipseEditV2);
                            cogCreateEllipseEditV2.Dock = DockStyle.Fill;
                            cogCreateEllipseEditV2.Font = font;
                            cogCreateEllipseEditV2.ForeColor = Color.Black;
                            cogCreateEllipseEditV2.Subject = (_vPro.GetJob.Tools[nSel] as CogCreateEllipseTool);
                        }
                        else
                            createEllipse.LoadSet(_vPro.GetJob.Tools[nSel] as CogCreateEllipseTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogCreateLineTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogCreateLineTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogCreateLineEditV2 cogCreateLineEditV2 = new CogCreateLineEditV2();
                            pnlDeltailTool.Controls.Add(cogCreateLineEditV2);
                            cogCreateLineEditV2.Dock = DockStyle.Fill;
                            cogCreateLineEditV2.Font = font;
                            cogCreateLineEditV2.ForeColor = Color.Black;
                            cogCreateLineEditV2.Subject = (_vPro.GetJob.Tools[nSel] as CogCreateLineTool);
                        }
                        else
                            createLine.LoadSet(_vPro.GetJob.Tools[nSel] as CogCreateLineTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogCreateSegmentAvgSegsTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogCreateSegmentAvgSegsTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogCreateSegmentAvgSegsEditV2 cogCreateSegmentAvgSegsEditV2 = new CogCreateSegmentAvgSegsEditV2();
                            pnlDeltailTool.Controls.Add(cogCreateSegmentAvgSegsEditV2);
                            cogCreateSegmentAvgSegsEditV2.Dock = DockStyle.Fill;
                            cogCreateSegmentAvgSegsEditV2.Font = font;
                            cogCreateSegmentAvgSegsEditV2.ForeColor = Color.Black;
                            cogCreateSegmentAvgSegsEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogCreateSegmentAvgSegsTool;
                        }
                        else
                            createSegmentAvg.LoadSet(_vPro.GetJob.Tools[nSel] as CogCreateSegmentAvgSegsTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogCreateSegmentTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogCreateSegmentTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogCreateSegmentEditV2 cogCreateSegmentEditV2 = new CogCreateSegmentEditV2();
                            pnlDeltailTool.Controls.Add(cogCreateSegmentEditV2);
                            cogCreateSegmentEditV2.Dock = DockStyle.Fill;
                            cogCreateSegmentEditV2.Font = font;
                            cogCreateSegmentEditV2.ForeColor = Color.Black;
                            cogCreateSegmentEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogCreateSegmentTool;
                        }
                        else
                            createSegment.LoadSet(_vPro.GetJob.Tools[nSel] as CogCreateSegmentTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogFindCircleTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogFindCircleTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogFindCircleEditV2 cogFindCircleEditV2 = new CogFindCircleEditV2();
                            pnlDeltailTool.Controls.Add(cogFindCircleEditV2);
                            cogFindCircleEditV2.Dock = DockStyle.Fill;
                            cogFindCircleEditV2.Font = font;
                            cogFindCircleEditV2.ForeColor = Color.Black;
                            cogFindCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogFindCircleTool;
                        }
                        else
                            findCircleControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogFindCircleTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogFindCornerTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogFindCornerTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogFindCornerEditV2 cogFindCornerEditV2 = new CogFindCornerEditV2();
                            pnlDeltailTool.Controls.Add(cogFindCornerEditV2);
                            cogFindCornerEditV2.Dock = DockStyle.Fill;
                            cogFindCornerEditV2.Font = font;
                            cogFindCornerEditV2.ForeColor = Color.Black;
                            cogFindCornerEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogFindCornerTool;
                        }
                        else
                            findCornerControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogFindCornerTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogFindEllipseTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogFindEllipseTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogFindEllipseEditV2 cogFindEllipseEditV2 = new CogFindEllipseEditV2();
                            pnlDeltailTool.Controls.Add(cogFindEllipseEditV2);
                            cogFindEllipseEditV2.Dock = DockStyle.Fill;
                            cogFindEllipseEditV2.Font = font;
                            cogFindEllipseEditV2.ForeColor = Color.Black;
                            cogFindEllipseEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogFindEllipseTool;
                        }
                        else
                            findEllipseControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogFindEllipseTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogFindLineTool))
                    {
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogFindLineTool;

                        if (_toolType == ToolType.Detail)
                        {
                            CogFindLineEditV2 cogFindLineEditV2 = new CogFindLineEditV2();
                            pnlDeltailTool.Controls.Add(cogFindLineEditV2);
                            cogFindLineEditV2.Dock = DockStyle.Fill;
                            cogFindLineEditV2.Font = font;
                            cogFindLineEditV2.ForeColor = Color.Black;
                            cogFindLineEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogFindLineTool;
                        }
                        else
                            findLineControl.LoadSet(_vPro.GetJob.Tools[nSel] as CogFindLineTool);
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogFitCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogFitCircleEditV2 cogFitCircleEditV2 = new CogFitCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogFitCircleEditV2);
                        cogFitCircleEditV2.Dock = DockStyle.Fill;
                        cogFitCircleEditV2.Font = font;
                        cogFitCircleEditV2.ForeColor = Color.Black;
                        cogFitCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogFitCircleTool;

                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogFitEllipseTool))
                    {
                        _toolType = ToolType.Detail;

                        CogFitEllipseEditV2 cogFitEllipseEditV2 = new CogFitEllipseEditV2();
                        pnlDeltailTool.Controls.Add(cogFitEllipseEditV2);
                        cogFitEllipseEditV2.Dock = DockStyle.Fill;
                        cogFitEllipseEditV2.Font = font;
                        cogFitEllipseEditV2.ForeColor = Color.Black;
                        cogFitEllipseEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogFitEllipseTool;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogFitLineTool))
                    {
                        _toolType = ToolType.Detail;

                        CogFitLineEditV2 cogFitLineEditV2 = new CogFitLineEditV2();
                        pnlDeltailTool.Controls.Add(cogFitLineEditV2);
                        cogFitLineEditV2.Dock = DockStyle.Fill;
                        cogFitLineEditV2.Font = font;
                        cogFitLineEditV2.ForeColor = Color.Black;
                        cogFitLineEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogFitLineTool;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogLineMaxTool))
                    {
                        _toolType = ToolType.Detail;

                        CogLineMaxEditV2 cogLineMaxEditV2 = new CogLineMaxEditV2();
                        pnlDeltailTool.Controls.Add(cogLineMaxEditV2);
                        cogLineMaxEditV2.Dock = DockStyle.Fill;
                        cogLineMaxEditV2.Font = font;
                        cogLineMaxEditV2.ForeColor = Color.Black;
                        cogLineMaxEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogLineMaxTool;
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogLineMaxTool;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectCircleCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectCircleCircleEditV2 cogIntersectCircleCircleEditV2 = new CogIntersectCircleCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectCircleCircleEditV2);
                        cogIntersectCircleCircleEditV2.Dock = DockStyle.Fill;
                        cogIntersectCircleCircleEditV2.Font = font;
                        cogIntersectCircleCircleEditV2.ForeColor = Color.Black;
                        cogIntersectCircleCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectCircleCircleTool;
                        ToolDisp.Tool = cogIntersectCircleCircleEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectLineCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectLineCircleEditV2 cogIntersectLineCircleEditV2 = new CogIntersectLineCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectLineCircleEditV2);
                        cogIntersectLineCircleEditV2.Dock = DockStyle.Fill;
                        cogIntersectLineCircleEditV2.Font = font;
                        cogIntersectLineCircleEditV2.ForeColor = Color.Black;
                        cogIntersectLineCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectLineCircleTool;
                        ToolDisp.Tool = cogIntersectLineCircleEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectLineEllipseTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectLineEllipseEditV2 cogIntersectLineEllipseEditV2 = new CogIntersectLineEllipseEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectLineEllipseEditV2);
                        cogIntersectLineEllipseEditV2.Dock = DockStyle.Fill;
                        cogIntersectLineEllipseEditV2.Font = font;
                        cogIntersectLineEllipseEditV2.ForeColor = Color.Black;
                        cogIntersectLineEllipseEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectLineEllipseTool;
                        ToolDisp.Tool = cogIntersectLineEllipseEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectLineLineTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectLineLineEditV2 cogIntersectLineLineEditV2 = new CogIntersectLineLineEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectLineLineEditV2);
                        cogIntersectLineLineEditV2.Dock = DockStyle.Fill;
                        cogIntersectLineLineEditV2.Font = font;
                        cogIntersectLineLineEditV2.ForeColor = Color.Black;
                        cogIntersectLineLineEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectLineLineTool;
                        ToolDisp.Tool = cogIntersectLineLineEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectSegmentCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectSegmentCircleEditV2 cogIntersectSegmentCircleEditV2 = new CogIntersectSegmentCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectSegmentCircleEditV2);
                        cogIntersectSegmentCircleEditV2.Dock = DockStyle.Fill;
                        cogIntersectSegmentCircleEditV2.Font = font;
                        cogIntersectSegmentCircleEditV2.ForeColor = Color.Black;
                        cogIntersectSegmentCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectSegmentCircleTool;
                        ToolDisp.Tool = cogIntersectSegmentCircleEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectSegmentEllipseTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectSegmentEllipseEditV2 cogIntersectSegmentEllipseEditV2 = new CogIntersectSegmentEllipseEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectSegmentEllipseEditV2);
                        cogIntersectSegmentEllipseEditV2.Dock = DockStyle.Fill;
                        cogIntersectSegmentEllipseEditV2.Font = font;
                        cogIntersectSegmentEllipseEditV2.ForeColor = Color.Black;
                        cogIntersectSegmentEllipseEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectSegmentEllipseTool;
                        ToolDisp.Tool = cogIntersectSegmentEllipseEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectSegmentLineTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectSegmentLineEditV2 cogIntersectSegmentLineEditV2 = new CogIntersectSegmentLineEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectSegmentLineEditV2);
                        cogIntersectSegmentLineEditV2.Dock = DockStyle.Fill;
                        cogIntersectSegmentLineEditV2.Font = font;
                        cogIntersectSegmentLineEditV2.ForeColor = Color.Black;
                        cogIntersectSegmentLineEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectSegmentLineTool;
                        ToolDisp.Tool = cogIntersectSegmentLineEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIntersectSegmentSegmentTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIntersectSegmentSegmentEditV2 cogIntersectSegmentSegmentEditV2 = new CogIntersectSegmentSegmentEditV2();
                        pnlDeltailTool.Controls.Add(cogIntersectSegmentSegmentEditV2);
                        cogIntersectSegmentSegmentEditV2.Dock = DockStyle.Fill;
                        cogIntersectSegmentSegmentEditV2.Font = font;
                        cogIntersectSegmentSegmentEditV2.ForeColor = Color.Black;
                        cogIntersectSegmentSegmentEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIntersectSegmentSegmentTool;
                        ToolDisp.Tool = cogIntersectSegmentSegmentEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogAngleLineLineTool))
                    {
                        _toolType = ToolType.Detail;

                        CogAngleLineLineEditV2 cogAngleLineLineEditV2 = new CogAngleLineLineEditV2();
                        pnlDeltailTool.Controls.Add(cogAngleLineLineEditV2);
                        cogAngleLineLineEditV2.Dock = DockStyle.Fill;
                        cogAngleLineLineEditV2.Font = font;
                        cogAngleLineLineEditV2.ForeColor = Color.Black;
                        cogAngleLineLineEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogAngleLineLineTool;
                        ToolDisp.Tool = cogAngleLineLineEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogAnglePointPointTool))
                    {
                        _toolType = ToolType.Detail;

                        CogAnglePointPointEditV2 cogAnglePointPointEditV2 = new CogAnglePointPointEditV2();
                        pnlDeltailTool.Controls.Add(cogAnglePointPointEditV2);
                        cogAnglePointPointEditV2.Dock = DockStyle.Fill;
                        cogAnglePointPointEditV2.Font = font;
                        cogAnglePointPointEditV2.ForeColor = Color.Black;
                        cogAnglePointPointEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogAnglePointPointTool;
                        ToolDisp.Tool = cogAnglePointPointEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistanceCircleCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistanceCircleCircleEditV2 cogDistanceCircleCircleEditV2 = new CogDistanceCircleCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogDistanceCircleCircleEditV2);
                        cogDistanceCircleCircleEditV2.Dock = DockStyle.Fill;
                        cogDistanceCircleCircleEditV2.Font = font;
                        cogDistanceCircleCircleEditV2.ForeColor = Color.Black;
                        cogDistanceCircleCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistanceCircleCircleTool;
                        ToolDisp.Tool = cogDistanceCircleCircleEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistanceLineCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistanceLineCircleEditV2 cogDistanceLineCircleEditV2 = new CogDistanceLineCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogDistanceLineCircleEditV2);
                        cogDistanceLineCircleEditV2.Dock = DockStyle.Fill;
                        cogDistanceLineCircleEditV2.Font = font;
                        cogDistanceLineCircleEditV2.ForeColor = Color.Black;
                        cogDistanceLineCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistanceLineCircleTool;
                        ToolDisp.Tool = cogDistanceLineCircleEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistanceLineEllipseTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistanceLineEllipseEditV2 cogDistanceLineEllipseEditV2 = new CogDistanceLineEllipseEditV2();
                        pnlDeltailTool.Controls.Add(cogDistanceLineEllipseEditV2);
                        cogDistanceLineEllipseEditV2.Dock = DockStyle.Fill;
                        cogDistanceLineEllipseEditV2.Font = font;
                        cogDistanceLineEllipseEditV2.ForeColor = Color.Black;
                        cogDistanceLineEllipseEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistanceLineEllipseTool;
                        ToolDisp.Tool = _vPro.GetJob.Tools[nSel] as CogDistanceLineEllipseTool;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistancePointCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistancePointCircleEditV2 cogDistancePointCircleEditV2 = new CogDistancePointCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogDistancePointCircleEditV2);
                        cogDistancePointCircleEditV2.Dock = DockStyle.Fill;
                        cogDistancePointCircleEditV2.Font = font;
                        cogDistancePointCircleEditV2.ForeColor = Color.Black;
                        cogDistancePointCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistancePointCircleTool;
                        ToolDisp.Tool = cogDistancePointCircleEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistancePointEllipseTool))
                    {
                        CogDistancePointEllipseEditV2 cogDistancePointEllipseEditV2 = new CogDistancePointEllipseEditV2();
                        pnlDeltailTool.Controls.Add(cogDistancePointEllipseEditV2);
                        cogDistancePointEllipseEditV2.Dock = DockStyle.Fill;
                        cogDistancePointEllipseEditV2.Font = font;
                        cogDistancePointEllipseEditV2.ForeColor = Color.Black;
                        cogDistancePointEllipseEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistancePointEllipseTool;
                        ToolDisp.Tool = cogDistancePointEllipseEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistancePointLineTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistancePointLineEditV2 cogDistancePointLineEditV2 = new CogDistancePointLineEditV2();
                        pnlDeltailTool.Controls.Add(cogDistancePointLineEditV2);
                        cogDistancePointLineEditV2.Dock = DockStyle.Fill;
                        cogDistancePointLineEditV2.Font = font;
                        cogDistancePointLineEditV2.ForeColor = Color.Black;
                        cogDistancePointLineEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistancePointLineTool;
                        ToolDisp.Tool = cogDistancePointLineEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistancePointPointTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistancePointPointEditV2 cogDistancePointPointEditV2 = new CogDistancePointPointEditV2();
                        pnlDeltailTool.Controls.Add(cogDistancePointPointEditV2);
                        cogDistancePointPointEditV2.Dock = DockStyle.Fill;
                        cogDistancePointPointEditV2.Font = font;
                        cogDistancePointPointEditV2.ForeColor = Color.Black;
                        cogDistancePointPointEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistancePointPointTool;
                        ToolDisp.Tool = cogDistancePointPointEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistancePointSegmentTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistancePointSegmentEditV2 cogDistancePointSegmentEditV2 = new CogDistancePointSegmentEditV2();
                        pnlDeltailTool.Controls.Add(cogDistancePointSegmentEditV2);
                        cogDistancePointSegmentEditV2.Dock = DockStyle.Fill;
                        cogDistancePointSegmentEditV2.Font = font;
                        cogDistancePointSegmentEditV2.ForeColor = Color.Black;
                        cogDistancePointSegmentEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistancePointSegmentTool;
                        ToolDisp.Tool = cogDistancePointSegmentEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistanceSegmentCircleTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistanceSegmentCircleEditV2 cogDistanceSegmentCircleEditV2 = new CogDistanceSegmentCircleEditV2();
                        pnlDeltailTool.Controls.Add(cogDistanceSegmentCircleEditV2);
                        cogDistanceSegmentCircleEditV2.Dock = DockStyle.Fill;
                        cogDistanceSegmentCircleEditV2.Font = font;
                        cogDistanceSegmentCircleEditV2.ForeColor = Color.Black;
                        cogDistanceSegmentCircleEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistanceSegmentCircleTool;
                        ToolDisp.Tool = cogDistanceSegmentCircleEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistanceSegmentEllipseTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistanceSegmentEllipseEditV2 cogDistanceSegmentEllipseEditV2 = new CogDistanceSegmentEllipseEditV2();
                        pnlDeltailTool.Controls.Add(cogDistanceSegmentEllipseEditV2);
                        cogDistanceSegmentEllipseEditV2.Dock = DockStyle.Fill;
                        cogDistanceSegmentEllipseEditV2.Font = font;
                        cogDistanceSegmentEllipseEditV2.ForeColor = Color.Black;
                        cogDistanceSegmentEllipseEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistanceSegmentEllipseTool;
                        ToolDisp.Tool = cogDistanceSegmentEllipseEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistanceSegmentLineTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistanceSegmentLineEditV2 cogDistanceSegmentLineEditV2 = new CogDistanceSegmentLineEditV2();
                        pnlDeltailTool.Controls.Add(cogDistanceSegmentLineEditV2);
                        cogDistanceSegmentLineEditV2.Dock = DockStyle.Fill;
                        cogDistanceSegmentLineEditV2.Font = font;
                        cogDistanceSegmentLineEditV2.ForeColor = Color.Black;
                        cogDistanceSegmentLineEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistanceSegmentLineTool;
                        ToolDisp.Tool = cogDistanceSegmentLineEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogDistanceSegmentSegmentTool))
                    {
                        _toolType = ToolType.Detail;

                        CogDistanceSegmentSegmentEditV2 cogDistanceSegmentSegmentEditV2 = new CogDistanceSegmentSegmentEditV2();
                        pnlDeltailTool.Controls.Add(cogDistanceSegmentSegmentEditV2);
                        cogDistanceSegmentSegmentEditV2.Dock = DockStyle.Fill;
                        cogDistanceSegmentSegmentEditV2.Font = font;
                        cogDistanceSegmentSegmentEditV2.ForeColor = Color.Black;
                        cogDistanceSegmentSegmentEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogDistanceSegmentSegmentTool;
                        ToolDisp.Tool = cogDistanceSegmentSegmentEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogIDTool))
                    {
                        _toolType = ToolType.Detail;

                        CogIDEditV2 cogIDEditV2 = new CogIDEditV2();
                        pnlDeltailTool.Controls.Add(cogIDEditV2);
                        cogIDEditV2.Dock = DockStyle.Fill;
                        cogIDEditV2.Font = font;
                        cogIDEditV2.ForeColor = Color.Black;
                        cogIDEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogIDTool;
                        ToolDisp.Tool = cogIDEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogOCRMaxTool))
                    {
                        _toolType = ToolType.Detail;

                        CogOCRMaxEditV2 cogOCRMaxEditV2 = new CogOCRMaxEditV2();
                        pnlDeltailTool.Controls.Add(cogOCRMaxEditV2);
                        cogOCRMaxEditV2.Dock = DockStyle.Fill;
                        cogOCRMaxEditV2.Font = font;
                        cogOCRMaxEditV2.ForeColor = Color.Black;
                        cogOCRMaxEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogOCRMaxTool;
                        ToolDisp.Tool = cogOCRMaxEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogOCVMaxTool))
                    {
                        _toolType = ToolType.Detail;

                        CogOCVMaxEdit cogOCVMaxEdit = new CogOCVMaxEdit();
                        pnlDeltailTool.Controls.Add(cogOCVMaxEdit);
                        cogOCVMaxEdit.Dock = DockStyle.Fill;
                        cogOCVMaxEdit.Font = font;
                        cogOCVMaxEdit.ForeColor = Color.Black;
                        cogOCVMaxEdit.Subject = _vPro.GetJob.Tools[nSel] as CogOCVMaxTool;
                        ToolDisp.Tool = cogOCVMaxEdit.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogColorExtractorTool))
                    {
                        _toolType = ToolType.Detail;

                        CogColorExtractorEditV2 cogColorExtractorEditV2 = new CogColorExtractorEditV2();
                        pnlDeltailTool.Controls.Add(cogColorExtractorEditV2);
                        cogColorExtractorEditV2.Dock = DockStyle.Fill;
                        cogColorExtractorEditV2.Font = font;
                        cogColorExtractorEditV2.ForeColor = Color.Black;
                        cogColorExtractorEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogColorExtractorTool;
                        ToolDisp.Tool = cogColorExtractorEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogColorMatchTool))
                    {
                        _toolType = ToolType.Detail;

                        CogColorMatchEditV2 cogColorMatchEditV2 = new CogColorMatchEditV2();
                        pnlDeltailTool.Controls.Add(cogColorMatchEditV2);
                        cogColorMatchEditV2.Dock = DockStyle.Fill;
                        cogColorMatchEditV2.Font = font;
                        cogColorMatchEditV2.ForeColor = Color.Black;
                        cogColorMatchEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogColorMatchTool;
                        ToolDisp.Tool = cogColorMatchEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogColorSegmenterTool))
                    {
                        _toolType = ToolType.Detail;

                        CogColorSegmenterEditV2 cogColorSegmenterEditV2 = new CogColorSegmenterEditV2();
                        pnlDeltailTool.Controls.Add(cogColorSegmenterEditV2);
                        cogColorSegmenterEditV2.Dock = DockStyle.Fill;
                        cogColorSegmenterEditV2.Font = font;
                        cogColorSegmenterEditV2.ForeColor = Color.Black;
                        cogColorSegmenterEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogColorSegmenterTool;
                        ToolDisp.Tool = cogColorSegmenterEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogCompositeColorMatchTool))
                    {
                        _toolType = ToolType.Detail;

                        CogCompositeColorMatchEditV2 cogCompositeColorMatchEditV2 = new CogCompositeColorMatchEditV2();
                        pnlDeltailTool.Controls.Add(cogCompositeColorMatchEditV2);
                        cogCompositeColorMatchEditV2.Dock = DockStyle.Fill;
                        cogCompositeColorMatchEditV2.Font = font;
                        cogCompositeColorMatchEditV2.ForeColor = Color.Black;
                        cogCompositeColorMatchEditV2.Subject = _vPro.GetJob.Tools[nSel] as CogCompositeColorMatchTool;
                        ToolDisp.Tool = cogCompositeColorMatchEditV2.Subject;
                    }
                    else if (_vPro.GetJob.Tools[nSel].GetType() == typeof(CogToolBlock))
                    {
                        _toolType = ToolType.Detail;

                        CogToolBlockEditV2 cogToolBlockEditV = new CogToolBlockEditV2();
                        pnlDeltailTool.Controls.Add(cogToolBlockEditV);
                        cogToolBlockEditV.Dock = DockStyle.Fill;
                        cogToolBlockEditV.Font = font;
                        cogToolBlockEditV.ForeColor = Color.Black;
                        cogToolBlockEditV.Subject = _vPro.GetJob.Tools[nSel] as CogToolBlock;
                        ToolDisp.Tool = cogToolBlockEditV.Subject;
                    }

                    tabTool.Visible = false;
                    tabTool.SelectedTabPageIndex = (int)_toolType;
                    tabTool.Visible = true;

                    _bLoad = true;
                }
                catch (Exception ex) { }
            }));
        }

        private double AngleToRad(double Angle)
        {
            return (Angle * Math.PI) / 180;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                _paramCode = ParamCode.ModelChange;
                if (_vPro.GetJob != null)
                    _vPro.GetJob = cogToolGroup.Subject;

                CogSerializer.SaveObjectToFile(_vPro.GetJob, string.Format("{0}\\vpp\\Camera_{1:D2}\\{2}.vpp", Application.StartupPath, _nCamNo+ 1, cbCodeName.SelectedItem.ToString()), typeof(System.Runtime.Serialization.Formatters.Binary.BinaryFormatter), CogSerializationOptionsConstants.Minimum);

                _cam.ModelChange(true);
                //_cam._vPro.FileLoad(string.Format("{0}\\vpp\\Camera_{1:D2}\\{2}.vpp", Application.StartupPath, _nCamNo + 1, cbCodeName.SelectedItem.ToString()), cogInspImg.Image);
                _cam.SetGraphicview();

                MessageBox.Show("Job File Saved", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                GetFileLastWriteTime();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Job File Save Error : " + ex.Message, "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            _paramCode = ParamCode.ModelChangeEnd;
        }


        private void btnRun_Click(object sender, EventArgs e)
        {
            try
            {
                if (_listConvertTool != null)
                {
                    if (_nImgListCnt != 0)
                    {
                        if (_nImgListCnt != _nDispNo + 1)
                            _nDispNo++;
                        else
                            _nDispNo = 0;
                    }

                    if (_listConvertTool != null)
                    {
                        for (var j = 0; j < _listConvertTool.Count; j++)
                            _listConvertTool[j].InputImage = cogInspImg.Image;

                        _vPro.GetJob = cogToolGroup.Subject;
                        _vPro.GetJob.Run();
                        RunStatus();
                    }
                }
            }
            catch (Exception ex)
            {
                _cam._OnMessage("Manual Run Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private void RunStatus()
        {
            try
            {
                for (int i = 0; i < listcontrol.ItemCount; i++)
                    listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Red;

                if (_vPro.GetJob.RunStatus.Result != CogToolResultConstants.Error)
                {
                    for (int i = 0; i < listcontrol.ItemCount; i++)
                        listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Green;
                }
                else
                {
                    for (int i = 0; i < _vPro.GetJob.Tools.Count; i++)
                    {
                        if (_vPro.GetJob.Tools[i].RunStatus.Result == CogToolResultConstants.Error)
                        {
                            listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Red;
                            //break;
                        }
                        else if (_vPro.GetJob.Tools[i].RunStatus.Result == CogToolResultConstants.Accept || _vPro.GetJob.Tools[i].RunStatus.Result == CogToolResultConstants.Reject)
                            listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Green;
                        else if (_vPro.GetJob.Tools[i].RunStatus.Result == CogToolResultConstants.Warning)
                            listcontrol.Items[i].ImageOptions.ImageIndex = (int)ToolRes.Yellow;
                    }
                }
            }
            catch { }

        }

        private void btnAllTool_Click(object sender, EventArgs e)
        {
            tabTool.Visible = false;
            if (_toolType != ToolType.All)
            {
                _toolType = ToolType.All;
                tabTool.SelectedTabPageIndex = (int)ToolType.All;
            }
            else
            {
                _toolType = ToolType.Light;
                tabTool.SelectedTabPageIndex = (int)ToolType.Light;
            }

            tabTool.Visible = true;
        }

        private void btnToolDetail_Click(object sender, EventArgs e)
        {
            int nSel = listcontrol.SelectedIndex;
            if (nSel == -1)
                return;

            try
            {
                if (!splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.ShowWaitForm();

                _toolType = ToolType.Detail;
                ToolLoad(nSel);

                if (splashScreenManager1.IsSplashFormVisible)
                    splashScreenManager1.CloseWaitForm();
            }
            catch { }
        }

        private void btnDetaliClose_Click(object sender, EventArgs e)
        {
            tabTool.Visible = false;
            _toolType = ToolType.Light;
            tabTool.SelectedTabPageIndex = (int)ToolType.Light;
            tabTool.Visible = true;
        }

        private void txtGraphicSize_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
                e.Handled = true;
        }

        private void frmToolEdit_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void frmToolEdit_DragDrop(object sender, DragEventArgs e)
        {
            if (_listConvertTool == null)
                return;

            try
            {
                string[] strFilePath = (string[])e.Data.GetData(DataFormats.FileDrop);

                foreach (string str in strFilePath)
                {
                    using (Bitmap bmp = new Bitmap(Bitmap.FromFile(str)))
                    {
                        using(var cogImg = new CogImage24PlanarColor(bmp))
                        {
                            cogInspImg.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);

                            for (var i = 0; i < _listConvertTool.Count; i++)
                                _listConvertTool[i].InputImage = cogInspImg.Image;

                            //_CogImageConvertTool.InputImage = cogInspImg.Image;
                        }
                    }
                }
            }
            catch { }
        }


        private void frmToolEdit_Load(object sender, EventArgs e)
        {
            tabTool.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;

            tabTool.SelectedTabPageIndex = 0;
            _cam.splashScreenManager1.CloseWaitForm();

            listcontrol.SelectedIndex = _nCurrentIndx;

            Delay(200);
            //this.Opacity = 100;
        }


        private void btnStart_Click(object sender, EventArgs e)
        {
            var strTag = (sender as SimpleButton).Tag.ToString();
            int.TryParse(strTag, out int nImgMove);

            try
            {
                if (_bmpImg != null)
                {
                    if (_bmpImg.Length < 2)
                    {
                        cogInspImg.AutoFit = true;
                        cogInspImg.Image = new CogImage24PlanarColor(_bmpImg[0]);

                        cogDispNext.AutoFit = true;
                        cogDispNext.Image = new CogImage24PlanarColor(_bmpImg[1]);
                    }
                    else if (_bmpImg.Length >= 2)
                    {
                        if ((ImageMove)nImgMove == ImageMove.START) 
                        {
                            _nDispNo = 0;

                            cogDispPrev.Image = null;

                            cogInspImg.AutoFit = true;
                            cogInspImg.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo]);

                            if (_bmpImg.Length >= _nDispNo + 1)
                            {
                                cogDispNext.AutoFit = true;
                                cogDispNext.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo + 1]);
                            }
                            else
                            {
                                cogDispNext.Image = null;
                                cogDispNext.StaticGraphics.Clear();
                            }
                        }
                        else if ((ImageMove)nImgMove == ImageMove.PREVIOUS)
                        {
                            _nDispNo--;

                            if (_nDispNo > 1)
                            {
                                cogDispPrev.AutoFit = true;
                                cogDispPrev.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo - 1]);

                                cogInspImg.AutoFit = true;
                                cogInspImg.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo]);

                                cogDispNext.AutoFit = true;
                                cogDispNext.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo + 1]);
                            }
                            else if (_nDispNo == 0)
                            {
                                cogDispPrev.Image = null;

                                cogInspImg.AutoFit = true;
                                cogInspImg.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo]);

                                cogDispNext.AutoFit = true;
                                cogDispNext.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo + 1]);
                            }
                        }
                        else if ((ImageMove)nImgMove == ImageMove.NEXT)
                        {
                            _nDispNo++;

                            if (_nDispNo < _bmpImg.Length-1)
                            {
                                cogDispPrev.AutoFit = true;
                                cogDispPrev.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo - 1]);

                                cogInspImg.AutoFit = true;
                                cogInspImg.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo]);

                                cogDispNext.AutoFit = true;
                                cogDispNext.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo + 1]);
                            }
                            else if (_nDispNo == _bmpImg.Length - 1)
                            {
                                cogDispPrev.AutoFit = true;
                                cogDispPrev.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo - 1]);

                                cogInspImg.AutoFit = true;
                                cogInspImg.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo]);

                                cogDispNext.Image = null;
                            }
                        }
                        else
                        {
                            _nDispNo = _bmpImg.Length - 1;

                            cogDispNext.AutoFit = true;
                            cogDispNext.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo - 1]);

                            cogInspImg.AutoFit = true;
                            cogInspImg.Image = new CogImage24PlanarColor(_bmpImg[_nDispNo]);

                            cogDispNext.Image = null;
                        }
                    }
                }
            }
            catch { }
        }

        private void frmToolEdit_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Hide();
            //e.Cancel = true;
        }
    }
}
