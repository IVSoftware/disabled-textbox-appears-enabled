using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace enabled_false_textbox_has_no_pointer
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            checkBoxEnabled.Checked = true;
            checkBoxEnabled.CheckedChanged += (sender, e) =>
            {
                button1.Enabled =
                    textBox1.Enabled = 
                    checkBoxEnabled.Checked;   
            };
        }
    }
    class TextBoxEx : TextBox
    {
        const int WM_PAINT = 0x000F;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg.Equals(WM_PAINT) && !Enabled)
            {
                paintDisabled();
                return;
            }
            base.WndProc(ref m);
        }
        private void paintDisabled()
        {
            using (Graphics graphics = CreateGraphics())
            {
                TextBoxRenderer.DrawTextBox(graphics, Bounds, System.Windows.Forms.VisualStyles.TextBoxState.Normal);
            }
        }
    }
    class ButtonEx : Button
    {
        const int WM_PAINT = 0x000F;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg.Equals(WM_PAINT) && !Enabled)
            {
                paintDisabled();
                return;
            }
            base.WndProc(ref m);
        }
        private void paintDisabled()
        {
            using (Graphics graphics = CreateGraphics())
            {
                ButtonRenderer.DrawButton(
                    graphics,
                    Bounds,
                    System.Windows.Forms.VisualStyles.PushButtonState.Normal
               );
            }
        }
    }
}
