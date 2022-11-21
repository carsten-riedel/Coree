using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Coree.Controls
{
    public class CoreeRichTextBox : RichTextBox
    {

        [DefaultValue(typeof(Font), "Consolas, 12pt")]
        public override Font Font
        {
            get { return base.Font; }
            set { base.Font = value; }
        }

        [DefaultValue(typeof(System.Windows.Forms.BorderStyle), "None")]
        public new System.Windows.Forms.BorderStyle BorderStyle
        {
            get
            {
                return base.BorderStyle;
            }
            set
            {
                base.BorderStyle = value;
            }
        }

        [DefaultValue(typeof(bool), "false")]
        public new bool WordWrap
        {
            get
            {
                return base.WordWrap;
            }
            set
            {
                base.WordWrap = value;
            }
        }

        [DefaultValue(typeof(RichTextBoxScrollBars), "ForcedVertical")]
        public new RichTextBoxScrollBars ScrollBars
        {
            get
            {
                return base.ScrollBars;
            }
            set
            {
                base.ScrollBars = value;
            }
        }

        public CoreeRichTextBox()
        {
            this.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.WordWrap = false;
            this.ScrollBars = RichTextBoxScrollBars.ForcedVertical;
            this.Font = new Font(new FontFamily("Consolas"), 12, FontStyle.Regular, GraphicsUnit.Point);
        }


        public void AppendLine(string text,bool ScrollToEnd = true)
        {
            base.AppendText($@"{text}{Environment.NewLine}");
            base.SelectionStart = base.Text.Length;
            // scroll it automatically
            base.ScrollToCaret();
        }
    }
}