using System.ComponentModel;
using System.Diagnostics;

namespace Coree.Controls
{
    public class CoreeTextBox : System.Windows.Forms.TextBox
    {
        private const int WM_PAINT = 0x0F;
        private const int WM_NCPAINT = 0x85;
        private const int WM_COMMAND = 0x111;
        private const int WM_USER = 0x400;
        private const int WM_REFLECT = WM_USER + 0x1C00;
        private const int WM_KILLFOCUS = 0x0008;

        [DefaultValue("Hint")]
        public string TextHint { get; set; } = "Hint";

        public CoreeTextBox()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.DoubleBuffer, true);
            SetStyle(ControlStyles.UserPaint, true);
            this.TextHint = "Hint";
        }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            switch (m.Msg)
            {
                case WM_PAINT | WM_NCPAINT:
                    Debug.WriteLine(m.Msg);
                    paint(m.HWnd);
                    break;

                case WM_KILLFOCUS:
                    Debug.WriteLine(m.Msg);
                    paint(m.HWnd);
                    break;
            }
        }

        private void paint(IntPtr handle)
        {
            if (String.IsNullOrEmpty(this.Text))
            {
                using (Graphics g = System.Drawing.Graphics.FromHwnd(handle))
                {
                    g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.AntiAlias;

                    g.DrawString("cddd", this.Font, new SolidBrush(Color.LightGray), new PointF(0, 0));
                }
            }
        }
    }
}