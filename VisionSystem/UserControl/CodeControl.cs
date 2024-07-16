using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using System.IO;

using Cognex.VisionPro;

namespace VisionSystem
{
    public delegate void OnClickEvent(int nIdx, string strCode, bool bChk);
    public partial class CodeControl : DevExpress.XtraEditors.XtraUserControl
    {
        public OnClickEvent onClick;

        int _nIdx = 0;
        //GlovalVar _var = new GlovalVar();
        IniFiles ini = new IniFiles();


        public CodeControl(int nIdx)
        {
            InitializeComponent();
            _nIdx = nIdx;
        }

        public void LoadSet(FileInfo fi)
        {
            try
            {
                var strFileName = Path.GetFileNameWithoutExtension(fi.FullName);
                var strPath = Path.GetDirectoryName(fi.FullName);
                lblCodeName.Text = strFileName;
                lblComment.Text = ini.ReadIniFile(strFileName, "Value", strPath, "Comment.ini");

                using (FileStream fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (Image img = Image.FromStream(fs))
                    {
                        using (Bitmap bmpimg = new Bitmap(img))
                        {
                            using (var cogImg = new CogImage24PlanarColor(bmpimg))
                            {
                                cogDisp.AutoFit = true;
                                cogDisp.Image = cogImg.CopyBase(CogImageCopyModeConstants.CopyPixels);
                            }
                        }
                    }
                }
            }
            catch { }
        }

        private void lblCodeName_MouseClick(object sender, MouseEventArgs e)
        {
            SelectChange();
        }

        private void cogDisp_MouseDown(object sender, MouseEventArgs e)
        {
            SelectChange();
        }

        private void chkUse_CheckedChanged(object sender, EventArgs e)
        {
            SelectChange();
        }

        public void SelectChange()
        {
            if (chkUse.Checked)
            {
                lblCodeName.ForeColor = Color.Yellow;
                lblComment.ForeColor = Color.Yellow;

                using (Font font = new Font("Tahoma", 11, FontStyle.Bold))
                {
                    lblCodeName.Font = font;
                    lblComment.Font = font;
                }
            }
            else
            {
                lblCodeName.ForeColor = Color.White;
                lblComment.ForeColor = Color.White;

                using (Font font = new Font("Tahoma", 11, FontStyle.Regular))
                {
                    lblCodeName.Font = font;
                    lblComment.Font = font;
                }
            }

            pnl.Invalidate();

            if (onClick != null)
                onClick(_nIdx, lblCodeName.Text, chkUse.Checked);
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            int borderWidth = 2;
            Color borderColor = Color.Orange;

            if (chkUse.Checked == false)
                borderColor = Color.FromArgb(38, 38, 38);

            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, borderColor, borderWidth, ButtonBorderStyle.Solid, borderColor, borderWidth,
            ButtonBorderStyle.Solid, borderColor, borderWidth, ButtonBorderStyle.Solid,
            borderColor, borderWidth, ButtonBorderStyle.Solid);
        }
    }
}
