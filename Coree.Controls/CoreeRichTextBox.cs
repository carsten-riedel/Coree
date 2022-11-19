using System.ComponentModel;
using System.Windows.Forms;

namespace Coree.Controls
{
    public class CoreeRichTextBox : RichTextBox
    {

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

        public CoreeRichTextBox() : base() { this.BorderStyle = System.Windows.Forms.BorderStyle.None; }


        public void AppendLine(string text,bool ScrollToEnd = true)
        {
            base.AppendText($@"{text}{Environment.NewLine}");
            base.SelectionStart = base.Text.Length;
            // scroll it automatically
            base.ScrollToCaret();
        }
    }
}