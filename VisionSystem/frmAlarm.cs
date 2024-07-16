using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VisionSystem
{
    public partial class frmAlarm : DevExpress.XtraEditors.XtraForm
    {
        public frmAlarm()
        {
            InitializeComponent();

            this.SetStyle(ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint, true);
            this.UpdateStyles();
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

        public void SetMsg(string strMsg, string strProcess)
        {
            this.Text = strMsg;
            lblMsg.Text = strMsg;
            lblProcess.Text = strProcess;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}