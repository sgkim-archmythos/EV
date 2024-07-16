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

using static GlovalVar;

namespace VisionSystem
{
    public partial class frmModel : DevExpress.XtraEditors.XtraForm
    {
        frmMain _frmMain;
        frmToolSetup _frmToolSetup;
        IniFiles ini = new IniFiles();
        CodeControl[] _codeControl = null;
        bool _bPass = false;

        CamParamControl[] _camParamControl = new CamParamControl[30];
        public frmModel(frmMain MainFrm)
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();

            _frmMain = MainFrm;

            ActiveControl = labelControl1;
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

        private void ShowPanel(SimpleButton btn1, SimpleButton btn2, SimpleButton btn3, SimpleButton btn4)
        {
            tabModel.Visible = false;
            int.TryParse(btn1.Tag.ToString(), out int nNo1);
            int.TryParse(btn2.Tag.ToString(), out int nNo2);
            int.TryParse(btn3.Tag.ToString(), out int nNo3);
            int.TryParse(btn4.Tag.ToString(), out int nNo4);

            tabModel.TabPages[nNo1].PageVisible = true;
            tabModel.TabPages[nNo2].PageVisible = false;
            tabModel.TabPages[nNo3].PageVisible = false;
            tabModel.TabPages[nNo4].PageVisible = false;

            txtAddModelName.Text = "";
            cbModel.SelectedIndex = -1;
            cbDelModel.SelectedIndex = -1;
            txtPassword.Text = "";

            _bPass = false;
            if (flyModel.IsPopupOpen)
                flyModel.HideBeakForm();

            flyModel.OwnerControl = btn1;

            tabModel.Visible = true;
            flyModel.ShowBeakForm();

            if (btn1.Tag.ToString() == "0")
                txtAddModelName.Focus();
            else if (btn1.Tag.ToString() == "1")
                cbModel.Focus();
            else if (btn1.Tag.ToString() == "2")
                cbDelModel.Focus();
            else if (btn1.Tag.ToString() == "3")
            {
                btnToolCreate.DialogResult = DialogResult.Yes;
                txtPassword.Focus();
            }
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
        private void btnToolCreate_Click(object sender, EventArgs e)
        {

            if (_frmToolSetup != null)
            {
                _frmToolSetup.Dispose();
                _frmToolSetup = null;
            }

            splashScreenManager1.ShowWaitForm();

            _frmToolSetup = new frmToolSetup(this, _frmMain);
            _frmToolSetup.Show();

            splashScreenManager1.CloseWaitForm();

            //ShowPanel(btnToolCreate, btnModelAdd, btnModelCopy, btnModelDel);
        }

        private void Loading()
        {
            InitControl();

            try
            {
                cbModel.Properties.Items.Clear();
                cbDelModel.Properties.Items.Clear();
                foreach (string str in _listModel)
                {
                    dg_List.Rows.Add((dg_List.Rows.Count + 1).ToString(), str);
                    cbModel.Properties.Items.Add(str);
                    cbDelModel.Properties.Items.Add(str);
                }

                for (int i = 0; i < tabCam.TabPages.Count; i++)
                {
                    tabCam.TabPages[i].Text = string.Format("Camera{0}", i + 1);
                    if (_nScreenCnt > i)
                        tabCam.TabPages[i].PageVisible = true;
                    else
                        tabCam.TabPages[i].PageVisible = false;
                }

                tabCam.SelectedTabPageIndex = 0;

                if (_listModel.Count > 0)
                {
                    if (_strModelNo == "")
                        lblModel.Text = _listModel[0];
                    else
                    {
                        for (int i = 0; i < _listModel.Count; i++)
                        {
                            if (_listModel[i].Contains(_strModelNo))
                            {
                                lblModel.Text = _listModel[i];
                                dg_List.CurrentCell = dg_List.Rows[i].Cells[0];
                            }
                        }
                    }
                }

                Model_Load(lblModel.Text, true);
            }
            catch { }
        }
        private void frmModel_Load(object sender, EventArgs e)
        {
            Loading();
            ChangeLanguage();
        }

        private void ChangeLanguage()
        {
            if (_Language == Language.English)
            {
                btnModelAdd.Text = "Add Model";
                btnModelCopy.Text = "Model Copy";
                btnModelDel.Text = "Delete Model";
                btnToolCreate.Text = "Tool Create";
                btnSave.Text = "Save";
                btnClose.Text = "Close";

                tabModel.TabPages[0].Text = "New Model";
                tabModel.TabPages[1].Text = "Copy Model";
                tabModel.TabPages[2].Text = "Delete Model";
                tabModel.TabPages[3].Text = "password Change";
            }
            else
            {

            }
        }
        private void Model_Load(string model, bool bSameModel)
        {
            for (int i = 0; i < _nScreenCnt; i++)
            {
                if (_camParamControl[i] == null)
                {
                    _camParamControl[i] = new CamParamControl(_frmMain, i, model);
                    tabCam.TabPages[i].Controls.Add(_camParamControl[i]);
                    _camParamControl[i].Dock = DockStyle.Fill;
                    
                }

                Thread threadLoad = new Thread(()=>_camParamControl[i].LoadSet(model, bSameModel));
                threadLoad.Start();

                Thread.Sleep(30);
            }

            //tabCam.TabIndex = 1;
            //tabCam.TabIndex = 0;
        }

        private void InitControl()
        {
            dg_List.Columns.Clear();
            dg_List.Columns.Add("No", "No");
            dg_List.Columns.Add("ModelName", "ModelName");

            dg_List.Columns[0].Width = 46;
            dg_List.Columns[1].Width = 248;

            dg_List.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < 2; i++)
            {
                dg_List.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dg_List.Columns[i].ReadOnly = true;
                dg_List.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
            }
        }


        private void btnModelAdd_Click(object sender, EventArgs e)
        {
            ShowPanel(btnModelAdd, btnToolCreate, btnModelCopy, btnModelDel);
        }

        private void btnModelCopy_Click(object sender, EventArgs e)
        {
            ShowPanel(btnModelCopy, btnModelAdd, btnToolCreate, btnModelDel);
        }

        private void btnModelDel_Click(object sender, EventArgs e)
        {
            ShowPanel(btnModelDel, btnModelCopy, btnModelAdd, btnToolCreate);
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("Please Input Password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_strAdminPW == txtPassword.Text)
            {
                if (flyModel.IsPopupOpen)
                    flyModel.HideBeakForm();

                btnModelAdd.Enabled = true;
                btnModelCopy.Enabled = true;
                btnModelDel.Enabled = true;

                if (_frmToolSetup != null)
                {
                    _frmToolSetup.Dispose();
                    _frmToolSetup = null;
                }

                splashScreenManager1.ShowWaitForm();

                _frmToolSetup = new frmToolSetup(this, _frmMain);
                _frmToolSetup.Show();

                splashScreenManager1.CloseWaitForm();
            }
        }

        private void btnNewModelClose_Click(object sender, EventArgs e)
        {
            btnToolCreate.DialogResult = DialogResult.No;

            if (flyModel.IsPopupOpen)
                flyModel.HideBeakForm();
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCheck.PerformClick();
        }

        private void btnNewModel_Click(object sender, EventArgs e)
        {
            if (txtAddModelName.Text == "")
            {
                MessageBox.Show("Please Input Model Name", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach(string strModel in _listModel)
            {
                if (strModel == txtAddModelName.Text)
                {
                    MessageBox.Show(new Form { TopMost = true}, "중복되는 모델명이 있습니다."+ "\r\n" + "다시 입력하여 주십시오", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtAddModelName.Text = "";
                    txtAddModelName.Focus();
                    return;
                }
            }

            flyModel.HideBeakForm();
            SQL sql = new SQL();

            if (lblModel.Text == "" || lblModel.Text == "-")
            {
                _strModelNo = "01";
                lblModel.Text = txtAddModelName.Text;
            }

            _frmMain.listModel.Items.Add(txtAddModelName.Text);
            _listModel.Add(txtAddModelName.Text);

            dg_List.Rows.Add((dg_List.Rows.Count + 1).ToString(), txtAddModelName.Text);

            cbModel.Properties.Items.Add(txtAddModelName.Text);
            cbDelModel.Properties.Items.Add(txtAddModelName.Text);

            string strTemp = "";
            for (int i = 0; i < _listModel.Count; i++)
                strTemp += _listModel[i] + ",";

            int.TryParse(_strModelNo, out var nModelNo);
            sql.SaveModelInfo(_strProcName, _dbInfo, strTemp, nModelNo, _strLotNo);

            DirectoryInfo dr = new DirectoryInfo(_strModelPath + "\\" + txtAddModelName.Text);
            if (!dr.Exists)
                dr.Create();

            txtAddModelName.Text = "";

            _paramCode = ParamCode.ModelListChange;
            _frmMain.AddMsg("Model created successfully.", white, true, false, GlovalVar.MsgType.Alarm);
        }

        private void txtAddModelName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnNewModel.PerformClick();
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            if (cbModel.SelectedIndex == -1 || txtCopyModel.Text == "")
            {
                MessageBox.Show("Please select the model you want to copy.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int i = 0; i < _listModel.Count; i++)
            {
                if (_listModel[i] == txtCopyModel.Text)
                {
                    MessageBox.Show("Duplicate model name found." + "\r\n" + "Please re - enter", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            }

            flyModel.HideBeakForm();

            _frmMain.listModel.Items.Add(txtCopyModel.Text);
            _listModel.Add(txtCopyModel.Text);
            dg_List.Rows.Add((dg_List.Rows.Count + 1).ToString(), txtCopyModel.Text);

            cbModel.Properties.Items.Add(txtCopyModel.Text);
            cbDelModel.Properties.Items.Add(txtCopyModel.Text);

            string strTemp = "";
            for (int i = 0; i < _listModel.Count; i++)
                strTemp += _listModel[i] + ",";

            //ini.WriteIniFile("Modellist", "Value", strTemp, _strModelPath, "Modellist.ini");

            int.TryParse(_strModelNo, out var nModelNo);
            SQL sql = new SQL();

            ModelParam modelParam = new ModelParam();
            GraphicResViewParam graphicResViewParam = new GraphicResViewParam();

            for (var i = 0; i<_nScreenCnt; i++)
            {
                sql.GetRecipe(_strProcName, _dbInfo, i, cbModel.EditValue.ToString(), ref modelParam);
                sql.GetGraphicResViewParam(_strProcName, cbModel.EditValue.ToString(), i, _dbInfo, ref graphicResViewParam);
                sql.SaveRecipe(_strProcName, _dbInfo, i, txtCopyModel.Text, modelParam);
                sql.SaveGraphicResViewlParam(_strProcName, txtCopyModel.Text, i, _dbInfo, graphicResViewParam);

            }
            //int nModelNo = 0;
            //sql.GetModelInfo(_strProcName, _dbInfo, ref strModelList, ref nModelNo, ref strLotNo)
            sql.SaveModelInfo(_strProcName, _dbInfo, strTemp, nModelNo, _strLotNo);

            var strSourceFolder = Application.StartupPath + "\\Model\\" + cbModel.SelectedItem.ToString();
            var strdestFolder = Application.StartupPath + "\\Model\\" + txtCopyModel.Text;
            CopyFolder(strSourceFolder, strdestFolder);

            txtCopyModel.Text = "";
            cbModel.SelectedIndex = -1;

            _paramCode = ParamCode.ModelListChange;
            _frmMain.AddMsg("Model copied successfully.", white, true, false, GlovalVar.MsgType.Alarm);
        }

        public void CopyFolder(string sourceFolder, string destFolder)
        {
            try
            {
                if (!Directory.Exists(destFolder))
                    Directory.CreateDirectory(destFolder);

                string[] files = Directory.GetFiles(sourceFolder);
                string[] folders = Directory.GetDirectories(sourceFolder);

                foreach (string file in files)
                {
                    string name = Path.GetFileName(file);
                    string dest = Path.Combine(destFolder, name);
                    File.Copy(file, dest);
                }

                foreach (string folder in folders)
                {
                    string name = Path.GetFileName(folder);
                    string dest = Path.Combine(destFolder, name);
                    CopyFolder(folder, dest);
                }
            }
            catch { }
            
        }

        private void ModelCopy(string strOriginPath, string strTargetPath)
        {
            try
            {
                DirectoryInfo dr = new DirectoryInfo(_strModelPath + "\\" + strTargetPath);

                if (!dr.Exists)
                    dr.Create();

                string[] strFiles = Directory.GetFiles(_strModelPath + "\\" + strOriginPath);

                string strFileName = "";
                foreach (string strFile in strFiles)
                {
                    strFileName = Path.GetFileName(strFile);
                    File.Copy(strFile, _strModelPath + "\\" + strTargetPath + "\\" + strFileName, true);
                }
            }
            catch (Exception ex)
            {
                _frmMain.AddMsg("Model Copy Error : " + ex.Message, Color.Red, true, true, GlovalVar.MsgType.Alarm);
            }
        }

        private void ModelDelete(string strTargetPath)
        {
            try
            {
                string[] strFolders = Directory.GetDirectories(_strModelPath + "\\");

                foreach (string stfFoler in strFolders)
                {
                    if (stfFoler.Contains(strTargetPath))
                    {
                        Directory.Delete(stfFoler, true);
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                _frmMain.AddMsg("Model Delete Error : " + ex.Message, Color.Red, true, true, GlovalVar.MsgType.Alarm);
            }
        }

        private void txtCopyModel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                btnCopy.PerformClick();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbDelModel.SelectedIndex == -1)
            {
                MessageBox.Show("Please select the model you want to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show("Are you sure you want to delete the selected model?", "Delete Model", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.No)
                return;

            flyModel.HideBeakForm();
            int nSel = cbDelModel.SelectedIndex;
            string strModelName = cbDelModel.EditValue.ToString();
            string strFolderName = _listModel[nSel];
            _listModel.RemoveAt(nSel);
            dg_List.Rows.RemoveAt(nSel);

            for (var i = 0; i < dg_List.RowCount; i++)
                dg_List.Rows[i].Cells[0].Value = (i+1).ToString();

            cbModel.Properties.Items.RemoveAt(nSel);
            cbDelModel.Properties.Items.RemoveAt(nSel);
            _frmMain.listModel.Items.RemoveAt(nSel);

            string strTemp = "";
            for (int i = 0; i < _listModel.Count; i++)
                strTemp += _listModel[i] + ",";

            int.TryParse(_strModelNo, out var nModelNo);
            SQL sql = new SQL();
            sql.DeleteRecipe(_strProcName, _dbInfo, cbDelModel.EditValue.ToString());
            sql.DeleteGraphicResParam(_strProcName, _dbInfo, cbDelModel.EditValue.ToString());
            sql.SaveModelInfo(_strProcName, _dbInfo, strTemp, nModelNo, _strLotNo);

            ModelDelete(strModelName);
            cbDelModel.SelectedIndex = -1;

            if (lblModel.Text == strFolderName)
            {
                lblModel.Text = "";

                _strModelNo = "";
                ini.WriteIniFile("ModelNo", "Value", _strModelNo, _strConfigPath, "Config.ini");
            }

            _paramCode = ParamCode.ModelListChange;
            _frmMain.AddMsg("Model deleted successfully", white, true, false, GlovalVar.MsgType.Alarm);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            splashScreenManager1.ShowWaitForm();

            try
            {
                bool[] bSave = new bool[_nScreenCnt];
                for (int i = 0; i < _nScreenCnt; i++)
                    bSave[i] = _camParamControl[i].SaveSet(lblModel.Text);

                for (int i = 0; i < bSave.Length; i++)
                {
                    if (!bSave[i])
                    {
                        _frmMain.AddMsg("Failed to save", Color.Red, false, false, GlovalVar.MsgType.Alarm);
                        splashScreenManager1.CloseWaitForm();
                        return;
                    }
                }

                _frmMain.AddMsg("Reicpe Saved", Color.GreenYellow, false, false, GlovalVar.MsgType.Alarm);
                //MessageBox.Show("Reicpe Saved", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                
                _frmMain.AddMsg("Model Parameters Save Error : " + ex.Message, Color.Red, false, false, GlovalVar.MsgType.Alarm);
            }

            splashScreenManager1.CloseWaitForm();
        }

        private void dg_List_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int nSel = dg_List.CurrentRow.Index;
            if (nSel > -1)
            {
                lblModel.Text = dg_List.Rows[nSel].Cells[1].FormattedValue.ToString();

                var bModelSame = _strModelName == lblModel.Text ? true : false;
                Model_Load(lblModel.Text, bModelSame);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            if (txtPassword.Text == "")
            {
                lblPassInput.Visible = false;
                return;
            }

            if (txtPassword.Text == _strAdminPW)
            {
                lblPassInput.Text = "Match";
                lblPassInput.ForeColor = Color.Lime;
            }
            else
            {
                lblPassInput.Text = "Not Match";
                lblPassInput.ForeColor = Color.Red;
            }

            lblPassInput.Visible = true;
        }
    }
}