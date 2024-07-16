using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraCharts;
using DevExpress.XtraBars.Navigation;
using System.Data.SqlClient;
using System.IO;
using DevExpress.Emf;
using DevExpress.XtraEditors.ViewInfo;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.Data.Linq.Helpers;
using DevExpress.XtraEditors;
using Cognex.VisionPro;

using static GlovalVar;
using Microsoft.VisualBasic;

namespace VisionSystem
{
    public partial class frmJobList : DevExpress.XtraEditors.XtraForm
    {
        frmMain _frmMain = null;
        IniFiles _ini = new IniFiles();

        public enum GraphMode
        {
            Daily,
            Weekly,
            Monthly,
            Custom
        }

        //SQL _sql = new SQL();

        GraphMode _graphMode = GraphMode.Daily;

        DataTable _dataTotal = new DataTable("Total");
        DataTable _dataOK = new DataTable("OK");
        DataTable _dataNG = new DataTable("NG");

        DataRow row = null;


        public frmJobList(frmMain MainFrm)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            _frmMain = MainFrm;
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

        private void frmHistory_Load(object sender, EventArgs e)
        {
            try
            {
                dateStart.DateTime = DateTime.Now;
                dateEnd.DateTime = DateTime.Now;

                dateHistoryStart.DateTime = DateTime.Now;
                dateHistoryEnd.DateTime = DateTime.Now;

                dateAlarmStart.DateTime = DateTime.Now;
                dateAlarmEnd.DateTime = DateTime.Now;

                cbModel.Properties.Items.Add("ALL");
                cbHistoryModel.Properties.Items.Add("ALL");

                for (var i = 0; i < _listModel.Count; i++)
                {
                    cbModel.Properties.Items.Add(_listModel[i]);
                    cbHistoryModel.Properties.Items.Add(_listModel[i]);
                }

                for (var i = 0; i<_nScreenCnt; i++)
                    cbCamNo.Properties.Items.Add(string.Format("#{0} CAM", i+1));

                if (_listModel.Count> 0)
                {
                    cbModel.EditValue = "ALL";
                    cbHistoryModel.EditValue = "ALL";
                }

                gpDate.Enabled = true;
                dateEnd.Enabled = false;

                DrawDoguhnutChart();
                DrawBarChart();

                SearchData();
                SearchAlarm();
            }
            catch { }
        }

        private void DrawDoguhnutChart()
        {
            SQL sql = new SQL();
            try
            {                
                int[] nTotalCnt = new int[24];
                int[] nOKCnt = new int[24];
                int[] nNGCnt = new int[24];

                int nFinalTotal = 0;
                int nFinalOK = 0;
                int nFinalNG = 0;

                int nTime = 0;

                double[] dValue = new double[2];

                Series series = new Series("Series 1", ViewType.Doughnut);
                ChartTitle title = new ChartTitle();
                chartDoughnut.Series.Clear();
                chartDoughnut.Titles.Clear();

                if (_graphMode == GraphMode.Daily)
                {
                    DateTime dateStartTime = dateStart.DateTime;
                    DateTime dateEndTime = dateStart.DateTime;
                    GetDailyTime(ref dateStartTime, ref dateEndTime);

                    sql.GetDailyCount(_strProcName, cbModel.SelectedItem.ToString(), true, dateStartTime, dateEndTime, _dbInfo, ref nTotalCnt, ref nOKCnt, ref nNGCnt);

                    for (var i = 0; i < nTotalCnt.Length; i++)
                    {
                        nFinalTotal += nTotalCnt[i];
                        nFinalOK += nOKCnt[i];
                        nFinalNG += nNGCnt[i];
                    }

                    title.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    title.Alignment = StringAlignment.Center;

                    title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                    title.Font = new Font("Tahoma", 11, FontStyle.Bold);
                    title.TextColor = Color.Yellow;
                    title.Indent = 10;
                }
                else if (_graphMode == GraphMode.Weekly || _graphMode == GraphMode.Monthly || _graphMode == GraphMode.Custom)
                {
                    var dateTimeStart = DateTime.Now;
                    var dateTimeEnd = DateTime.Now;

                    if (_graphMode == GraphMode.Weekly)
                    {
                        dateTimeStart = DateTime.Now.AddDays(-7);
                        dateTimeEnd = DateTime.Now;
                    }
                    else if (_graphMode == GraphMode.Monthly)
                    {
                        dateTimeStart = Convert.ToDateTime(string.Format("{0}-{1}-01 00:00:00", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM")));
                        dateTimeEnd = DateTime.Now;
                    }
                    else
                    {
                        dateTimeStart = Convert.ToDateTime(dateStart.DateTime.ToString("yyyy-MM-dd 00:00:00"));
                        dateTimeEnd = Convert.ToDateTime(dateEnd.DateTime.ToString("yyyy-MM-dd 23:59:59"));
                    }

                    TimeSpan duration = dateTimeEnd - dateTimeStart;
                    nTime = duration.Days;

                    title.Text = string.Format("{0} ~ {1}", dateTimeStart.ToString("yyyy-MM-dd"), dateTimeEnd.ToString("yyyy-MM-dd"));
                    title.Alignment = StringAlignment.Center;

                    title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                    title.Font = new Font("Tahoma", 11, FontStyle.Bold);
                    title.TextColor = Color.Yellow;
                    title.Indent = 10;

                    for (var i = 0; i < nTime + 1; i++)
                    {
                        dateTimeStart = dateTimeStart.AddDays(i);
                        dateTimeStart = Convert.ToDateTime(dateTimeStart.ToString("yyyy-MM-dd 00:00:00"));
                        dateTimeEnd = dateTimeStart;

                        GetDailyTime(ref dateTimeStart, ref dateTimeEnd);

                        sql.GetDailyCount(_strProcName, cbModel.SelectedItem.ToString(), true, dateTimeStart, dateTimeEnd, _dbInfo, ref nTotalCnt, ref nOKCnt, ref nNGCnt);

                        for (var j = 0; j < nTotalCnt.Length; j++)
                        {
                            nFinalTotal += nTotalCnt[j];
                            nFinalOK += nOKCnt[j];
                            nFinalNG += nNGCnt[j];
                        }
                    }
                }

                lblTotal.Text = nFinalTotal.ToString();
                lblOK.Text = nFinalOK.ToString();
                lblNG.Text = nFinalNG.ToString();

                dValue[0] = ((double)nFinalOK / (double)nFinalTotal) * 100.0;
                dValue[1] = 100.0 - dValue[0];

                series.Label.TextPattern = "{A}: {VP:P1}";
                series.Label.BackColor = Color.FromArgb(38, 38, 38);

                series.Points.Add(new SeriesPoint("OK", dValue[0]));
                series.Points.Add(new SeriesPoint("NG", dValue[1]));

                chartDoughnut.Titles.Add(title);
                chartDoughnut.Series.Add(series);

                chartDoughnut.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

                series.Points[0].Color = Color.Lime;
                series.Points[1].Color = Color.Red;

                series.SeriesPointsSorting = SortingMode.Ascending;
                series.SeriesPointsSortingKey = SeriesPointKey.Argument;

                ((DoughnutSeriesLabel)series.Label).Position = PieSeriesLabelPosition.Outside;
                ((SimpleDiagram)chartDoughnut.Diagram).Dimension = 1;
            }
            catch{ }

            sql.Dispose();
        }

        private void GetDailyTime(ref DateTime dateStartTime, ref DateTime dateEndTime)
        {
            try
            {
                if (lblDay.BackColor == lime)
                {
                    dateStartTime = Convert.ToDateTime(dateStartTime.ToString("yyyy-MM-dd 00:00:00"));
                    dateEndTime = Convert.ToDateTime(dateEndTime.ToString("yyyy-MM-dd 23:59:59"));
                }
                else
                {
                    dateStartTime = Convert.ToDateTime(dateStartTime.ToString("yyyy-MM-dd 00:00:00"));

                    dateEndTime = dateEndTime.AddDays(1);
                    dateEndTime = Convert.ToDateTime(dateEndTime.ToString("yyyy-MM-dd 23:59:59"));
                }
            }
            catch { }
        }

        private void DrawBarChart()
        {
            SQL sql = new SQL();
            try
            {
                int[] nTotalCnt = new int[24];
                int[] nOKCnt = new int[24];
                int[] nNGCnt = new int[24];

                int nFinalTotal = 0;
                int nFinalOK = 0;
                int nFinalNG = 0;

                int nMax = 0;
                int nTime = 0;

                Series[] series = new Series[3];

                series[0] = new Series("TOTAL", ViewType.Bar);
                series[1] = new Series("OK", ViewType.Bar);
                series[2] = new Series("NG", ViewType.Bar);

                ChartTitle title = new ChartTitle();

                chartBar.Series.Clear();
                chartBar.Titles.Clear();

                _dataTotal.Rows.Clear();
                _dataTotal.Rows.Clear();

                _dataTotal.Columns.Clear();
                _dataTotal.Columns.Clear();

                _dataOK.Rows.Clear();
                _dataOK.Rows.Clear();

                _dataOK.Columns.Clear();
                _dataOK.Columns.Clear();

                _dataNG.Rows.Clear();
                _dataNG.Rows.Clear();

                _dataNG.Columns.Clear();
                _dataNG.Columns.Clear();

                row = null;

                _dataTotal.Columns.Add("Argument", typeof(string));
                _dataTotal.Columns.Add("Value", typeof(int));

                _dataOK.Columns.Add("Argument", typeof(string));
                _dataOK.Columns.Add("Value", typeof(int));

                _dataNG.Columns.Add("Argument", typeof(string));
                _dataNG.Columns.Add("Value", typeof(int));

                if (_graphMode == GraphMode.Daily)
                {
                    DateTime dateStartTime = dateStart.DateTime;
                    DateTime dateEndTime = dateStart.DateTime;
                    GetDailyTime(ref dateStartTime, ref dateEndTime);

                    sql.GetDailyCount(_strProcName, cbModel.SelectedItem.ToString(), true, dateStartTime, dateEndTime, _dbInfo, ref nTotalCnt, ref nOKCnt, ref nNGCnt);;

                    nTime = lblDay.BackColor == lime ? 8 : 20;

                    for (var i = 0; i < 12; i++)
                    {
                        row = _dataTotal.NewRow();
                        row["Argument"] = string.Format("{0:D2}", nTime + i);
                        row["Value"] = nTotalCnt[i];

                        _dataTotal.Rows.Add(row);

                        row = _dataOK.NewRow();
                        row["Argument"] = string.Format("{0:D2}", nTime + i);
                        row["Value"] = nOKCnt[i];
                        _dataOK.Rows.Add(row);

                        row = _dataNG.NewRow();
                        row["Argument"] = string.Format("{0:D2}", nTime + i);

                        row["Value"] = nNGCnt[i];
                        _dataNG.Rows.Add(row);
                    }

                    title.Text = DateTime.Now.ToString("yyyy-MM-dd");
                    title.Alignment = StringAlignment.Center;

                    title.EnableAntialiasing = DevExpress.Utils.DefaultBoolean.True;
                    title.Font = new Font("Tahoma", 11, FontStyle.Bold);
                    title.TextColor = Color.Yellow;
                    title.Indent = 10;

                }
                else if (_graphMode == GraphMode.Weekly || _graphMode == GraphMode.Monthly || _graphMode == GraphMode.Custom)
                {
                    var dateTimeStart = DateTime.Now;
                    var dateTimeEnd = DateTime.Now;

                    if (_graphMode == GraphMode.Weekly)
                    {
                        dateTimeStart = DateTime.Now.AddDays(-7);
                        dateTimeEnd = DateTime.Now;
                    }
                    else if (_graphMode == GraphMode.Monthly)
                    {
                        dateTimeStart = Convert.ToDateTime(string.Format("{0}-{1}-01 00:00:00", DateTime.Now.ToString("yyyy"), DateTime.Now.ToString("MM")));
                        dateTimeEnd = DateTime.Now;
                    }
                    else
                    {
                        dateTimeStart = Convert.ToDateTime(dateStart.DateTime.ToString("yyyy-MM-dd 00:00:00"));
                        dateTimeEnd = Convert.ToDateTime(dateEnd.DateTime.ToString("yyyy-MM-dd 23:59:59"));
                    }

                    TimeSpan duration = dateTimeEnd - dateTimeStart;
                    nTime = duration.Days;

                    for (var i = 0; i < nTime + 1; i++)
                    {
                        dateTimeStart = dateTimeStart.AddDays(i);
                        dateTimeStart = Convert.ToDateTime(dateTimeStart.ToString("yyyy-MM-dd 00:00:00"));
                        dateTimeEnd = dateTimeStart;

                        GetDailyTime(ref dateTimeStart, ref dateTimeEnd);

                        sql.GetDailyCount(_strProcName, cbModel.SelectedItem.ToString(), true, dateTimeStart, dateTimeEnd, _dbInfo, ref nTotalCnt, ref nOKCnt, ref nNGCnt);

                        nFinalTotal = 0;
                        nFinalOK = 0;
                        nFinalNG = 0;

                        for (var j = 0; j < nTotalCnt.Length; j++)
                        {
                            nFinalTotal += nTotalCnt[j];
                            nFinalOK += nOKCnt[j];
                            nFinalNG += nNGCnt[j];
                        }

                        row = _dataTotal.NewRow();
                        row["Argument"] = dateTimeStart.ToString("yyyy-MM-dd");
                        row["Value"] = nFinalTotal;
                        _dataTotal.Rows.Add(row);

                        row = _dataOK.NewRow();
                        row["Argument"] = dateTimeStart.ToString("yyyy-MM-dd");
                        row["Value"] = nFinalOK;
                        _dataOK.Rows.Add(row);

                        row = _dataNG.NewRow();
                        row["Argument"] = dateTimeStart.ToString("yyyy-MM-dd");
                        row["Value"] = nFinalNG;
                        _dataNG.Rows.Add(row);
                    }
                }

                chartBar.Series.Add(series[0]);
                chartBar.Series.Add(series[1]);
                chartBar.Series.Add(series[2]);

                series[0].DataSource = _dataTotal;
                series[0].ArgumentScaleType = ScaleType.Auto;
                series[0].ArgumentDataMember = "Argument";
                series[0].ValueScaleType = ScaleType.Numerical;
                series[0].ValueDataMembers.AddRange(new string[] { "Value" });
                series[0].View.Color = Color.Gray;

                series[1].DataSource = _dataOK;
                series[1].ArgumentScaleType = ScaleType.Auto;
                series[1].ArgumentDataMember = "Argument";
                series[1].ValueScaleType = ScaleType.Numerical;
                series[1].ValueDataMembers.AddRange(new string[] { "Value" });
                series[1].View.Color = Color.Lime;

                series[2].DataSource = _dataNG;
                series[2].ArgumentScaleType = ScaleType.Auto;
                series[2].ArgumentDataMember = "Argument";
                series[2].ValueScaleType = ScaleType.Numerical;
                series[2].ValueDataMembers.AddRange(new string[] { "Value" });
                series[2].View.Color = Color.Red;

                ((XYDiagram)chartBar.Diagram).EnableAxisXZooming = true;
                ((XYDiagram)chartBar.Diagram).EnableAxisYZooming = true;

                XYDiagram diagram1 = (XYDiagram)chartBar.Diagram;
                diagram1.AxisY.WholeRange.SetMinMaxValues(0, nMax);
                diagram1.AxisX.WholeRange.SetMinMaxValues(nTime, nTime + 12);

                diagram1.AxisY.WholeRange.Auto = true;

                diagram1.AxisX.WholeRange.SideMarginsValue = 0.5;
                diagram1.AxisY.WholeRange.AutoSideMargins = false;
                diagram1.EnableAxisXScrolling = true;

                ((XYDiagram)chartBar.Diagram).Rotated = false;

                chartBar.Titles.Add(title);
            }
            catch { }

            sql.Dispose();
        }

        private void radDaily_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                (sender as RadioButton).ForeColor = Color.Yellow;

                var strTag = (sender as RadioButton).Tag.ToString();
                int.TryParse(strTag, out var nValue);

                _graphMode = (GraphMode)nValue;
                gpDate.Enabled = true;

                if (_graphMode == GraphMode.Custom || _graphMode == GraphMode.Daily)
                {
                    if (_graphMode == GraphMode.Daily)
                    {
                        //lblDay.Visible = true;
                        //lblNight.Visible = true;

                        dateStart.Enabled = true;
                        dateEnd.Enabled = false;

                        ChangeDayNight("Day");
                    }
                    else
                    {

                        dateStart.Enabled = true;
                        dateEnd.Enabled = true;

                        //lblDay.Visible = false;
                        //lblNight.Visible = false;
                    }
                }
                else
                {
                    dateStart.Enabled = false;
                    dateEnd.Enabled = false;

                    //lblDay.Visible = false;
                    //lblNight.Visible = false;
                }

                _frmMain.ShowSplash(true);
                DrawDoguhnutChart();
                DrawBarChart();
                _frmMain.ShowSplash(false);
            }
            else
                (sender as RadioButton).ForeColor = Color.White;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cbModel.SelectedIndex == -1)
            {
                MessageBox.Show("모델을 선택하여 주십시오.");
                return;
            }

            _frmMain.ShowSplash(true);

            DrawDoguhnutChart();
            DrawBarChart();

            _frmMain.ShowSplash(false);
        }

        private void dgHistory_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 1;
            Color borderColor = Color.White;

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor,
             borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,

            ButtonBorderStyle.Solid, borderColor, borderWidth,
             ButtonBorderStyle.Solid,

            borderColor, borderWidth, ButtonBorderStyle.Solid);
        }

        private void chk2D_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as CheckEdit).Checked)
                (sender as CheckEdit).ForeColor = Color.Yellow;
            else
                (sender as CheckEdit).ForeColor = Color.White;
        }

        private void btnHistorySearch_Click(object sender, EventArgs e)
        {
            if (cbHistoryModel.SelectedIndex == -1)
            {
                MessageBox.Show("모델을 선택하여 주십시오.");
                return;
            }

            SearchData();
        }

        private void SearchData()
        {
            SQL sql = new SQL();
            try
            {
                var ds = sql.SearchData(_strProcName, cbCamNo.SelectedIndex, cbHistoryModel.SelectedText, txtLotNo.Text, cbResult.SelectedText, Convert.ToDateTime(dateHistoryStart.DateTime.ToString("yyyy-MM-dd 00:00:00")), Convert.ToDateTime(dateHistoryEnd.DateTime.ToString("yyyy-MM-dd 23:59:59")), _dbInfo);

                dgHistory.DataSource = ds.Tables[0];

                if (ds.Tables[0].Rows.Count > 0)
                {
                    using (Font font = new Font("Tahoma", 13, FontStyle.Bold))
                        dgHistory.ColumnHeadersDefaultCellStyle.Font = font;

                    dgHistory.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgHistory.ColumnHeadersHeight = 35;

                    dgHistory.Columns["NO"].Visible = false;
                    dgHistory.Columns["IMGPATH"].Visible = false;

                    dgHistory.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    if (!chk2D.Checked)
                        dgHistory.Columns[8].Visible = false;

                    if (!chkAlign.Checked)
                    {
                        dgHistory.Columns[9].Visible = false;
                        dgHistory.Columns[10].Visible = false;
                        dgHistory.Columns[11].Visible = false;
                    }

                    if (!chkDimension.Checked)
                    {
                        dgHistory.Columns[12].Visible = false;
                        dgHistory.Columns[13].Visible = false;
                    }

                    if (!chkPin.Checked)
                        dgHistory.Columns[14].Visible = false;

                    dgHistory.Columns[0].Width = 0;
                    dgHistory.Columns[1].Width = 200;
                    dgHistory.Columns[2].Width = 150;
                    dgHistory.Columns[3].Width = 250;
                    dgHistory.Columns[4].Width = 100;
                    dgHistory.Columns[5].Width = 200;
                    dgHistory.Columns[6].Width = 100;
                    dgHistory.Columns[7].Width = 100;
                    dgHistory.Columns[8].Width = 50;
                    dgHistory.Columns[9].Width = 50;
                    dgHistory.Columns[10].Width = 50;
                    dgHistory.Columns[11].Width = 50;
                    dgHistory.Columns[12].Width = 50;
                    dgHistory.Columns[13].Width = 50;
                    dgHistory.Columns[14].Width = 50;
                    dgHistory.Columns[16].Width = 100;
                    dgHistory.Columns[17].Width = 700;
                }

                ds.Dispose();
            }
            catch { }

            sql.Dispose();

            if (flySearch.IsPopupOpen)
                flySearch.HidePopup();
        }

        private void dgHistory_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            try
            {
                for (int i = 0; i < dgHistory.ColumnCount; i++)
                {
                    if (dgHistory.Columns[i].Name == "RESULT")
                    {
                        if (dgHistory.Rows[e.RowIndex].Cells[i].Value.ToString() == "OK")
                        {
                            dgHistory.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.Lime;
                            dgHistory.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.Black;
                        }
                        else if (dgHistory.Rows[e.RowIndex].Cells[i].Value.ToString() == "NG")
                        {
                            dgHistory.Rows[e.RowIndex].Cells[i].Style.BackColor = Color.Red;
                            dgHistory.Rows[e.RowIndex].Cells[i].Style.ForeColor = Color.White;
                        }
                    }
                }
            }
            catch { }
        }

        private void btnSearchMenu_Click(object sender, EventArgs e)
        {
            if (flySearch.IsPopupOpen)
                flySearch.HidePopup();
            else
                flySearch.ShowPopup();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            //Close();
            flySearch.HidePopup();
        }

        private void btnSaveTocvs_Click(object sender, EventArgs e)
        {
            if (dgHistory.Rows.Count > 0)
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.InitialDirectory = "C:\\";
                sfd.Title = "SaveToCSV";
                sfd.Filter = "csv File(*.csv) | *.csv | All Files(*.*) | *.*";

                if (sfd.ShowDialog() == DialogResult.OK)
                    SaveToCSV(sfd.FileName);
            }
            else
            {
                _frmMain.AddMsg("There is no data to save.", Color.Red, true, true, GlovalVar.MsgType.Alarm);
            }
        }

        private void SaveToCSV(string strPath)
        {
            try
            {
                DirectoryInfo dr = new DirectoryInfo(System.IO.Path.GetDirectoryName(strPath));
                if (!dr.Exists)
                    dr.Create();

                using (StreamWriter System_Log = new StreamWriter(strPath, append: true))
                {
                    var strData = "";
                    for (int i = 0; i < dgHistory.RowCount; i++)
                    {
                        strData = "";
                        for (var j = 0; j < dgHistory.ColumnCount; j++)
                        {
                            if (strData == "")
                                strData += dgHistory.Rows[i].Cells[j + 1].FormattedValue.ToString();
                            else
                                strData += "," + dgHistory.Rows[i].Cells[j + 1].FormattedValue.ToString();
                        }
                        System_Log.WriteLine(strData);
                    }

                    System_Log.Close();

                    _frmMain.AddMsg("File Saved", Color.GreenYellow, false, false, GlovalVar.MsgType.Alarm);
                }
            }
            catch (Exception ex)
            {
                _frmMain.AddMsg("File Save Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }
        }

        private void dgHistory_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dgHistory.CurrentRow.Index == -1)
                return;

            var strCamNo = dgHistory.Rows[dgHistory.CurrentRow.Index].Cells["CAMNO"].Value.ToString();
            var strCode = dgHistory.Rows[dgHistory.CurrentRow.Index].Cells["CODE"].Value.ToString();
            var strFileName = dgHistory.Rows[dgHistory.CurrentRow.Index].Cells["IMGPATH"].Value.ToString();

            var strOriginFile = "";
            var strResultFile = "";

            int.TryParse(strCamNo, out var nCamNo);

            strOriginFile = Application.StartupPath + "\\MasterImage\\" + string.Format("Camera_{0:D2}\\{1}.jpg", nCamNo, strCode);

            if (_SaveImgParam._ResultImageFormat == IMGFormat.bmp)
                strResultFile = strFileName + ".bmp";
            else
                strResultFile = strFileName + ".jpg";

            try
            {
                cogOriginDisp.AutoFit = true;
                cogResultDisp.AutoFit = true;

                using (Bitmap bmpImg = new Bitmap(Bitmap.FromFile(strOriginFile)))
                {
                    using (var cogImg = new CogImage24PlanarColor(bmpImg))
                        cogOriginDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                }

                using (Bitmap bmpImg = new Bitmap(strResultFile))
                {
                    using(var cogImg = new CogImage24PlanarColor(bmpImg))
                        cogResultDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                }
            }
            catch { }
        }

        private void btnAlarmSearch_Click(object sender, EventArgs e)
        {
            SearchAlarm();
        }

        private void SearchAlarm()
        {
            
            SQL sql = new SQL();

            try
            {
                var ds = sql.GetAlarm(_strProcName, _dbInfo, Convert.ToDateTime(dateAlarmStart.DateTime.ToString("yyyy-MM-dd 00:00:00")), Convert.ToDateTime(dateAlarmStart.DateTime.ToString("yyyy-MM-dd 23:59:59")), cbAlarmType.EditValue.ToString());
                dgAlarm.DataSource = ds.Tables[0];

                if (ds.Tables[0].Rows.Count > 0)
                {
                    using (Font font = new Font("Tahoma", 13, FontStyle.Bold))
                        dgAlarm.ColumnHeadersDefaultCellStyle.Font = font;

                    dgAlarm.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgAlarm.ColumnHeadersHeight = 35;

                    dgAlarm.RowsDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    dgAlarm.Columns[0].Visible = false;
                    dgAlarm.Columns[1].Visible = false;

                    dgAlarm.Columns[2].Width = 200;
                    dgAlarm.Columns[3].Width = 100;
                    dgAlarm.Columns[4].Width = 900;
                    dgAlarm.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
                }

                ds.Dispose();
            }
            catch { }

            sql.Dispose();
        }

        private void lblDay_Click(object sender, EventArgs e)
        {
            ChangeDayNight("Day");

            _frmMain.ShowSplash(true);
            DrawDoguhnutChart();
            DrawBarChart();
            _frmMain.ShowSplash(false);
        }

        private void ChangeDayNight(string strType)
        {
            try
            {
                if (strType == "Day")
                {
                    lblDay.BackColor = lime;
                    lblDay.ForeColor = black;

                    lblNight.BackColor = Color.Transparent;
                    lblNight.ForeColor = white;
                }
                else if (strType == "Night")
                {
                    lblDay.BackColor = Color.Transparent;
                    lblDay.ForeColor = white;

                    lblNight.BackColor = lime;
                    lblNight.ForeColor = black;
                }

                if (cbModel.SelectedIndex == -1)
                {
                    MessageBox.Show("모델을 선택하여 주십시오.");
                    return;
                }                
            }
            catch { }
        }

        private void lblNight_Click(object sender, EventArgs e)
        {
            ChangeDayNight("Night");

            _frmMain.ShowSplash(true);
            DrawDoguhnutChart();
            DrawBarChart();
            _frmMain.ShowSplash(false);
        }
    }
}
