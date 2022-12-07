using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace Coree.Controls
{
    public class CoreeRichTextBox : RichTextBox
    {

        [DefaultValue(typeof(Font), "Consolas, 11pt")]
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
            this.Font = new Font(new FontFamily("Consolas"), 11, FontStyle.Regular, GraphicsUnit.Point);
        }


        public void AppendLine(string text,Color? color = null,bool ScrollToEnd = true)
        {
            if (color == null)
            {
                color = base.ForeColor;
            }
            base.SelectionColor = color.Value;
            base.AppendText($@"{text}");
            base.SelectionColor = base.ForeColor;
            base.AppendText($@"{Environment.NewLine}");
            base.SelectionStart = base.Text.Length;
            // scroll it automatically
            base.ScrollToCaret();
        }
    }
}