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
using System.Text.RegularExpressions;
using System.Threading;
using DevExpress.Pdf.Native;
using static GlovalVar;

namespace VisionSystem
{
    public partial class frmComm : DevExpress.XtraEditors.XtraForm
    {
        frmMain _frmMain;
        IniFiles ini = new IniFiles();
        string[] strCpuType = new string[7] { "S7300", "S7400", "S71200", "S71500", "S7200", "S7200Smart", "Logo0BA8" };

        bool _bRead = false;
        bool _bSave = false;

        DataType _DataType = DataType.DEC;
        bool _bChangeDataType = false;

        List<string> _listData = new List<string>();

        

        //GlovalVar.PLCPram _plcParam = new GlovalVar.PLCPram();
        public frmComm(frmMain MainFrm)
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

        private void frmComm_Load(object sender, EventArgs e)
        {
            LoadSet();

            if (_frmMain._plc == null) return;
            if (_frmMain._plc.isConnected)
            {
                btnWrite.Enabled = true;
                lblStatus.Text = "CONNECTED";
                lblStatus.BackColor = Color.Lime;
                lblStatus.ForeColor = Color.Black;

                if (!_bRead)
                {
                    _bRead = true;
                    Thread threadReadData = new Thread(ReadData);
                    threadReadData.Start();
                }
            }
        }

        private void InitControl()
        {
            try
            {
                Invoke(new EventHandler(delegate
                {
                    if (_plcParam.strRead != "" && _plcParam.strReadCnt != "")
                    {
                        int.TryParse(_plcParam.strReadCnt, out var nLen);
                        int.TryParse(_plcParam.strRead, out var nAddr);

                        dgRead.Rows.Clear();

                        for (int i = 0; i < nLen; i++)
                        {
                            if (_plcParam.plcType == PLCType.Simens)
                                dgRead.Rows.Add(string.Format("{0}.DBW{1}", _plcParam.strReadDev, nAddr + (i * 2)), "0");
                            else
                                dgRead.Rows.Add(string.Format("{0}{1}", _plcParam.strReadDev, nAddr + i), "0");
                        }
                    }

                    if (_plcParam.strWrite != "")
                    {
                        int.TryParse(_plcParam.strWrite, out var nAddr);
                        dgWrite.Rows.Clear();

                        for (int i = 0; i < 100; i++)
                        {
                            if (_plcParam.plcType == PLCType.Simens)
                                dgWrite.Rows.Add(string.Format("{0}.DBW{1}", _plcParam.strWriteDev, nAddr + (i * 2)), "0");
                            else
                                dgWrite.Rows.Add(string.Format("{0}{1}", _plcParam.strWriteDev, nAddr + i), "0");

                            _listData.Add("0");
                        }
                    }
                }));
            }
            catch { }
        }

        private void LoadSet()
        {
            SetPlcParam();

            if (_frmMain._plc == null)
                return;

            if (_frmMain._plc.isConnected)
            {
                lblStatus.BackColor = Color.Lime;
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = "Connect";
            }

            dgRead.Columns.Clear();
            dgRead.Columns.Add("Addr", "Addr");
            dgRead.Columns.Add("Data", "Data");

            dgWrite.Columns.Clear();
            dgWrite.Columns.Add("Addr", "Addr");
            dgWrite.Columns.Add("Data", "Data");

            dgRead.Columns[0].Width = 150;
            dgRead.Columns[1].Width = 157;

            dgWrite.Columns[0].Width = 150;
            dgWrite.Columns[1].Width = 157;

            dgRead.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgWrite.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            for (int i = 0; i < 2; i++)
            {
                dgRead.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgRead.Columns[i].ReadOnly = true;
                dgRead.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                dgWrite.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                dgWrite.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                if (i == 0)
                    dgWrite.Columns[i].ReadOnly = true;
                else
                    dgWrite.Columns[i].ReadOnly = false;
            }

            InitControl();

            radDec.Checked = true;
        }

        private void SetPlcParam()
        {
            SQL sql = new SQL();
            try
            {
                sql.GetPLCParam(_strProcName, _dbInfo, ref _plcParam);
                cbCpuType.Properties.Items.AddRange(strCpuType);

                if (_plcParam.plcType == PLCType.MX)
                    swMX.IsOn = true;
                else if (_plcParam.plcType == PLCType.Simens)
                    swSiemens.IsOn = true;
                else if (_plcParam.plcType == PLCType.LS)
                    swLS.IsOn = true;

                cbCpuType.EditValue = _plcParam.strCPUType;
                txtIP.Text = _plcParam.strPLCIP;
                txtPort.Text = _plcParam.strPLCPort;
                txtWrite.Text = _plcParam.strWrite;
                txtWriteStartDev.Text = _plcParam.strWriteDev;
                txtTriggerSignal.Text = _plcParam.strTriggerSignal;
                txtOKSignal.Text = _plcParam.strOKSignal;
                txtNGSignal.Text = _plcParam.strNGSignal;
                txtRead.Text = _plcParam.strRead;
                txtReadDev.Text = _plcParam.strReadDev;
                txtReadCnt.Text = _plcParam.strReadCnt;
                txtReadInterval.Text = _plcParam.strReadInterval;
                txtReadTrigger.Text = _plcParam.strReadTrigger;
                txtReadTriggerCnt.Text = _plcParam.strReadTriggerCnt;
                txtReadModel.Text = _plcParam.strReadModel;
                txtReadModelCnt.Text = _plcParam.strReadModelCnt;
                txtReadLot.Text = _plcParam.strReadLot;
                txtReadLotCnt.Text = _plcParam.strReadLotCnt;
                txtHeartbeat.Text = _plcParam.strWriteHeartbeat;
                txtHeartbeatInterval.Text = _plcParam.strWriteHeartbeatInterval;
                txtGrabComplete.Text = _plcParam.strWriteGrabComplete;
                txtModelChangeComplete.Text = _plcParam.strWriteModelChange;
                txtLotNoRecvComplete.Text = _plcParam.strWriteLotComplete;
                txtPointResut.Text = _plcParam.strWritePointResult;
                txtTotalResult.Text = _plcParam.strWriteTotalResult;
                txt2DData.Text = _plcParam.strWrite2DData;
                txtAlignX.Text = _plcParam.strWriteAlignX;
                txtAlignY.Text = _plcParam.strWriteAlignY;
                txtAlignR.Text = _plcParam.strWriteAlignR;
                txtWidth.Text = _plcParam.strWriteWidth;
                txtHeight.Text = _plcParam.strWriteHeight;
                txtPinChange.Text = _plcParam.strWritePinChange;
                txtReadModelDetailNo.Text = _plcParam.strReadModelDetailNo;
                txtReadModelDetailNoCnt.Text = _plcParam.strReadModelDetailNoCnt;

                if (_plcParam.ReadFormat == PLCDataType.Binary)
                    radReadBinary.Checked = true;
                else if (_plcParam.ReadFormat == PLCDataType.ASCII)
                    radReadAscii.Checked = true;

                if (_plcParam.SignalFormat == SignalFormat.DEC)
                    radSignalDec.Checked = true;
                else if (_plcParam.SignalFormat == SignalFormat.HEX)
                    radSignalHex.Checked = true;

                if (_plcParam.bConnect)
                {
                    lblStatus.BackColor = lime;
                    lblStatus.ForeColor = black;
                    lblStatus.Text = "CONNECTED";
                }
                else
                {
                    lblStatus.BackColor = red;
                    lblStatus.ForeColor = white;
                    lblStatus.Text = "DISCONNECTED";
                }
            }
            catch { }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            _bRead = false;

            Thread.Sleep(100);

            Close();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            _bSave = true;
            Thread.Sleep(50);

            try
            {                
                if (swMX.IsOn)
                    _plcParam.plcType = PLCType.MX;
                else if (swSiemens.IsOn)
                    _plcParam.plcType = PLCType.Simens;
                else if (swLS.IsOn)
                    _plcParam.plcType = PLCType.LS;

                _plcParam.strCPUType = cbCpuType.SelectedText;
                _plcParam.strPLCIP = txtIP.Text;
                _plcParam.strPLCPort = txtPort.Text;
                _plcParam.strWrite = txtWrite.Text;
                _plcParam.strWriteDev = txtWriteStartDev.Text;
                _plcParam.strTriggerSignal = txtTriggerSignal.Text;
                _plcParam.strOKSignal = txtOKSignal.Text;
                _plcParam.strNGSignal = txtNGSignal.Text;
                _plcParam.strRead = txtRead.Text;
                _plcParam.strReadDev = txtReadDev.Text;
                _plcParam.strReadCnt = txtReadCnt.Text;
                _plcParam.strReadInterval = txtReadInterval.Text;
                _plcParam.strReadTrigger = txtReadTrigger.Text;
                _plcParam.strReadTriggerCnt = txtReadTriggerCnt.Text;
                _plcParam.strReadModel = txtReadModel.Text;
                _plcParam.strReadModelCnt = txtReadModelCnt.Text;
                _plcParam.strReadLot = txtReadLot.Text;
                _plcParam.strReadLotCnt = txtReadLotCnt.Text;
                _plcParam.strWriteHeartbeat = txtHeartbeat.Text;
                _plcParam.strWriteHeartbeatInterval = txtHeartbeatInterval.Text;
                _plcParam.strWriteGrabComplete = txtGrabComplete.Text;
                _plcParam.strWriteModelChange = txtModelChangeComplete.Text;
                _plcParam.strWriteLotComplete = txtLotNoRecvComplete.Text;
                _plcParam.strWritePointResult = txtPointResut.Text;
                _plcParam.strWriteTotalResult = txtTotalResult.Text;
                _plcParam.strWrite2DData = txt2DData.Text;
                _plcParam.strWriteAlignX = txtAlignX.Text;
                _plcParam.strWriteAlignY = txtAlignY.Text;
                _plcParam.strWriteAlignR = txtAlignR.Text;
                _plcParam.strWriteWidth = txtWidth.Text;
                _plcParam.strWriteHeight = txtHeight.Text;
                _plcParam.strWritePinChange = txtPinChange.Text;
                _plcParam.strReadModelDetailNo = txtReadModelDetailNo.Text;
                _plcParam.strReadModelDetailNoCnt = txtReadModelDetailNoCnt.Text;

                if (radReadBinary.Checked)
                    _plcParam.ReadFormat = PLCDataType.Binary;
                else if (radReadAscii.Checked)
                    _plcParam.ReadFormat = PLCDataType.ASCII;

                if (radSignalDec.Checked)
                    _plcParam.SignalFormat = SignalFormat.DEC;
                else if (radSignalHex.Checked)
                    _plcParam.SignalFormat = SignalFormat.HEX;

                _frmMain._plc.plcParams = _plcParam;
                _frmMain._plc.SavePLCParam();

                InitControl();

                _frmMain.AddMsg("PLC Parameters Saved", Color.GreenYellow, true, false, GlovalVar.MsgType.Alarm);
            }
            catch { }

            _bSave = false;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            try
            {               
                _frmMain._plc.plcParams = _plcParam;
                _frmMain._plc.Connect();

                if (_frmMain._plc.isConnected)
                {
                    lblStatus.BackColor = Color.Lime;
                    lblStatus.ForeColor = Color.Black;
                    lblStatus.Text = "Connect";

                    btnWrite.Enabled = true;

                    MessageBox.Show("PLC Connected", "Connect", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                else
                {
                    lblStatus.BackColor = Color.Red;
                    lblStatus.ForeColor = Color.White;

                    lblStatus.Text = "Disconnect";

                    MessageBox.Show("PLC Disconnected", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }


        private void ReadData()
        {
            string strTemp = "";
            ushort[] usData = null;
            int[] nData = null;

            ushort[] usTemp = null;
            int[] nTemp = null;
            byte[] bytes = null;

            while (true)
            {
                if (!_bRead)
                    return;

                try
                {
                    Invoke(new EventHandler(delegate
                    {
                        bytes = _frmMain._plc.GetData;

                        if (_plcParam.plcType == PLCType.MX)
                        {
                            if (nData == null || (nData.Length != bytes.Length / 2))
                            {
                                nData = new int[bytes.Length / 2];
                                nTemp = new int[bytes.Length / 2];
                            }
                        }
                        else
                        {
                            if (usData == null || (usData.Length != bytes.Length / 2))
                            {
                                usData = new UInt16[bytes.Length / 2];
                                usTemp = new UInt16[bytes.Length / 2];
                            }
                        }

                        if (bytes != null)
                        {
                            for (var i = 0; i < bytes.Length / 2; i++)
                            {
                                if (_plcParam.plcType == PLCType.MX)
                                    nData[i] = BitConverter.ToInt16(bytes, i * 2);
                                else
                                    usData[i] = BitConverter.ToUInt16(bytes, i * 2);
                            }
                        }

                        if (_plcParam.plcType == PLCType.MX)
                        {
                            if (!_bChangeDataType)
                            {
                                for (var i = 0; i < nData.Length; i++)
                                {
                                    if (nData[i] != nTemp[i])
                                    {
                                        nTemp[i] = nData[i];
                                        strTemp = GetIntReadData(nData[i]);
                                        dgRead.Rows[i].Cells[1].Value = strTemp;
                                    }
                                }
                            }
                            else
                            {
                                for (var i = 0; i < nData.Length; i++)
                                {
                                    strTemp = GetIntReadData(nData[i]);
                                    dgRead.Rows[i].Cells[1].Value = strTemp;
                                }

                                _bChangeDataType = false;
                            }

                        }
                        else
                        {
                            if (!_bChangeDataType)
                            {
                                for (var i = 0; i < usData.Length; i++)
                                {
                                    if (usData[i] != usTemp[i])
                                    {
                                        usTemp[i] = usData[i];
                                        strTemp = GetuShortReadData(usData[i]);
                                        dgRead.Rows[i].Cells[1].Value = strTemp;
                                    }
                                }
                            }
                            else
                            {
                                for (var i = 0; i < usData.Length; i++)
                                {
                                    strTemp = GetuShortReadData(usData[i]);
                                    dgRead.Rows[i].Cells[1].Value = strTemp;
                                }

                                _bChangeDataType = false;
                            }
                        }

                    }));
                }
                catch { }


                Thread.Sleep(50);
            }
        }

        private string GetuShortReadData(ushort usData)
        {
            var strData = "";

            if (_DataType == DataType.DEC)
                strData = usData.ToString();
            else if (_DataType == DataType.BINARY)
                strData = Convert.ToString(usData, 2).PadLeft(16, '0');
            else if (_DataType == DataType.HEX)
                strData = usData.ToString("X4");
            else
            {
                var strTemp = usData.ToString("X4");
                strData = string.Format("{0}{1}", Convert.ToChar(Convert.ToByte(strTemp.Substring(2, 2), 16)), Convert.ToChar(Convert.ToByte(strTemp.Substring(0, 2), 16))).Trim();
            }

            return strData;
        }

        private string GetIntReadData(int nData)
        {
            var strData = "";

            if (_DataType == DataType.DEC)
                strData = nData.ToString();
            else if (_DataType == DataType.BINARY)
                strData = Convert.ToString(nData, 2).PadLeft(16, '0');
            else if (_DataType == DataType.HEX)
                strData = nData.ToString("X4");
            else
            {
                var strTemp = nData.ToString("X4");
                strData = string.Format("{0}{1}", Convert.ToChar(Convert.ToByte(strTemp.Substring(2, 2), 16)), Convert.ToChar(Convert.ToByte(strTemp.Substring(0, 2), 16))).Trim();
            }

            return strData;
        }

        private void txtMXPort_KeyPress(object sender, KeyPressEventArgs e)
        {
            //if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            //{
            //    e.Handled = true;
            //}
        }

        private void btnWrite_Click(object sender, EventArgs e)
        {
            //_bWrite = !_bWrite;
            //if (_bWrite)
            //{
            //    if (swMX.IsOn)
            //        InitControl((int)GlovalVar.PLCType.MX, "Write");
            //    else if (swSiemens.IsOn)
            //        InitControl((int)GlovalVar.PLCType.Simens, "Write");
            //    else if (sw_IO.IsOn)
            //        InitControl((int)GlovalVar.PLCType.IO, "Write");
            //    else if (swLS.IsOn)
            //        InitControl((int)GlovalVar.PLCType.LS, "Write");
            //    else
            //    {
            //        MessageBox.Show(new Form { TopMost = true }, "Please select the equipment to connect.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //        return;
            //    }
            //}

            //if (_bWrite)
            //{
            //    btnWrite.ImageOptions.ImageIndex = 0;

            //    Thread threadWrite = new Thread(WriteData);
            //    threadWrite.Start();

            //    lblWriteRun.BackColor = Color.Lime;
            //    lblWriteRun.ForeColor = Color.Black;
            //    lblWriteRun.Text = "Run";
            //}
            //else
            //{
            //    btnWrite.ImageOptions.ImageIndex = 1;

            //    lblWriteRun.BackColor = Color.Red;
            //    lblWriteRun.ForeColor = Color.White;
            //    lblWriteRun.Text = "Stop";

            //    for (int i = 0; i < dgWrite.Rows.Count; i++)
            //        dgWrite.Rows[i].Cells[1].Value = "";
            //}

        }

        private void WriteData(int nidx)
        {
            var strTemp = "";
            ushort usData = 0;
            short sData = 0;
            byte[] bytes = null;
            var strData = "";

            try
            {
                if (dgWrite.Rows[nidx].Cells[1].Value.ToString() != _listData[nidx])
                {
                    if (_DataType == DataType.DEC)
                    {
                        if (string.IsNullOrEmpty(dgWrite.Rows[nidx].Cells[1].Value.ToString()))
                            strTemp = "";
                        else
                            strTemp = dgWrite.Rows[nidx].Cells[1].Value.ToString();
                    }
                    else if (_DataType == DataType.HEX)
                    {
                        if (string.IsNullOrEmpty(dgWrite.Rows[nidx].Cells[1].Value.ToString()))
                            strTemp = "";
                        else
                        {
                            if (swMX.IsOn)
                            {
                                sData = MAKEShortWORD(Convert.ToByte(dgWrite.Rows[nidx].Cells[1].Value.ToString().Substring(2, 2), 16), Convert.ToByte(dgWrite.Rows[nidx].Cells[1].Value.ToString().Substring(0, 2), 16));
                                strTemp = sData.ToString();
                            }
                            else
                            {
                                usData = MAKEushortWORD(Convert.ToByte(dgWrite.Rows[nidx].Cells[1].Value.ToString().Substring(2, 2), 16), Convert.ToByte(dgWrite.Rows[nidx].Cells[1].Value.ToString().Substring(0, 2), 16));
                                strTemp = usData.ToString();
                            }
                        }
                    }
                    else
                    {
                        if (string.IsNullOrEmpty(dgWrite.Rows[nidx].Cells[1].Value.ToString()))
                            strTemp = "";
                        else
                        {
                            if (dgWrite.Rows[nidx].Cells[1].Value.ToString().Length <= 2)
                            {
                                if (dgWrite.Rows[nidx].Cells[1].Value.ToString().Length == 1)
                                    strData = dgWrite.Rows[nidx].Cells[1].Value.ToString() + " ";

                                bytes = null;
                                bytes = Encoding.UTF8.GetBytes(strData);

                                if (swMX.IsOn)
                                {
                                    sData = MAKEShortWORD(bytes[1], bytes[0]);
                                    strTemp = sData.ToString();
                                }
                                else
                                {
                                    usData = MAKEushortWORD(bytes[1], bytes[0]);
                                    strTemp = usData.ToString();
                                }
                            }
                        }
                    }

                    int nAddr = 0;
                    string strAddr = "";

                    if (swMX.IsOn || swLS.IsOn)
                    {
                        int.TryParse(Regex.Replace(dgWrite.Rows[nidx].Cells[0].Value.ToString(), @"\D", ""), out nAddr);
                        strAddr = Regex.Replace(dgWrite.Rows[nidx].Cells[0].Value.ToString(), @"\d", "");
                    }
                    else if (swLS.IsOn)
                    {
                        var strWriteAddr = dgWrite.Rows[nidx].Cells[0].Value.ToString().Split('.');
                        int.TryParse(Regex.Replace(strWriteAddr[1], @"\D", ""), out nAddr);
                        strAddr = Regex.Replace(dgWrite.Rows[nidx].Cells[0].Value.ToString(), @"\d", "");
                    }
                    else
                    {

                    }

                    _frmMain._plc.SetData = string.Format("{0},{1},{2}", strAddr, nAddr, strTemp);
                    _listData[nidx] = strTemp;
                }
            }
            catch { }
        }


        private static Int16 MAKEShortWORD(byte low, byte high)
        {
            return (Int16)((high << 8) | low);
        }

        private static UInt16 MAKEushortWORD(byte low, byte high)
        {
            return (UInt16)((high << 8) | low);
        }

        private void radDec_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
            {
                var DataType = _DataType;
                (sender as RadioButton).ForeColor = Color.Yellow;

                int.TryParse((sender as RadioButton).Tag.ToString(), out var nDataType);
                _DataType = (DataType)nDataType;

                _bChangeDataType = true;
            }
            else
            {
                (sender as RadioButton).ForeColor = Color.White;
            }
        }

        private void radMXBinary_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                (sender as RadioButton).ForeColor = Color.Yellow;
            else
                (sender as RadioButton).ForeColor = Color.White;
        }

        private void dgWrite_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var nidx = e.RowIndex;
            WriteData(nidx);
        }

        private void radSignalDec_CheckedChanged(object sender, EventArgs e)
        {
            if ((sender as RadioButton).Checked)
                (sender as RadioButton).ForeColor = Color.Yellow;
            else
                (sender as RadioButton).ForeColor = Color.White;
        }


        private void swMX_Toggled(object sender, EventArgs e)
        {
            var strTag = (sender as ToggleSwitch).Tag.ToString();
            int.TryParse(strTag, out var nPlcType);


            if ((sender as ToggleSwitch).IsOn)
            {
                if (nPlcType == (int)GlovalVar.PLCType.MX)
                {
                    swSiemens.IsOn = false;
                    sw_IO.IsOn = false;
                    swLS.IsOn = false;

                    lblCpuType.Visible = false;
                    cbCpuType.Visible = false;
                    lblRack.Visible = false;
                    lblSlot.Visible = false;
                    txtRack.Visible = false;
                    txtSlot.Visible = false;

                    gpInfo.Enabled = true;
                    gpSignal.Enabled = true;

                    grDataFormat.Visible = true;

                    lblMX.ForeColor = Color.Yellow;
                }
                else if (nPlcType == (int)GlovalVar.PLCType.LS)
                {
                    swSiemens.IsOn = false;
                    sw_IO.IsOn = false;
                    swMX.IsOn = false;
                    swLS.IsOn = true;

                    lblCpuType.Visible = false;
                    cbCpuType.Visible = false;
                    lblRack.Visible = false;
                    lblSlot.Visible = false;
                    txtRack.Visible = false;
                    txtSlot.Visible = false;
                    grDataFormat.Visible = false;

                    gpInfo.Enabled = true;
                    gpSignal.Enabled = true;

                    lblLS.ForeColor = Color.Yellow;
                }
                else if (nPlcType == (int)GlovalVar.PLCType.Simens)
                {
                    swLS.IsOn = false;
                    swMX.IsOn = false;
                    sw_IO.IsOn = false;
                    swSiemens.IsOn = true;

                    lblCpuType.Visible = true;
                    cbCpuType.Visible = true;
                    lblRack.Visible = true;
                    lblSlot.Visible = true;
                    txtRack.Visible = true;
                    txtSlot.Visible = true;
                    grDataFormat.Visible = false;

                    gpInfo.Enabled = true;
                    gpSignal.Enabled = true;

                    lblSiemens.ForeColor = Color.Yellow;
                }
            }
            else
            {
                if (nPlcType == (int)GlovalVar.PLCType.MX)
                {
                    lblMX.ForeColor = Color.White;
                    grDataFormat.Visible = false;
                }
                else if (nPlcType == (int)GlovalVar.PLCType.LS)
                {
                    lblLS.ForeColor = Color.White;
                }
                else if (nPlcType == (int)GlovalVar.PLCType.Simens)
                {
                    lblCpuType.Visible = false;
                    cbCpuType.Visible = false;
                    lblRack.Visible = false;
                    lblSlot.Visible = false;
                    txtRack.Visible = false;
                    txtSlot.Visible = false;

                    lblSiemens.ForeColor = Color.White;
                }
            }
        }
    }
}
