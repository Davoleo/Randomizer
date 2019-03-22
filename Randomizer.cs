using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Generator
{
    public partial class Randomizer : Form
    {
        const int WM_NCHITTEST = 132;
        const int HTCLIENT = 1;
        const int HTCAPTION = 2;
        int X, Y;

        private Color styleColor;

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            switch (m.Msg)
            {
                case WM_NCHITTEST:
                    base.WndProc(ref m);
                    if ((m.Result == (IntPtr)HTCLIENT))
                    {
                        m.Result = (IntPtr)HTCAPTION;
                    }

                    break;
                default:
                    base.WndProc(ref m);
                    break;
            }
        }

        private System.Drawing.Point newpoint = new System.Drawing.Point();

        public Randomizer()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            Color style = Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
            styleColor = style;
            BackColor = style;
            btnGen.ForeColor = style;
            btnClose.ForeColor = style;
            btnMin.ForeColor = style;
            intInput.ForeColor = style;
            intInput.FocusHighlightColor = style;
            intInput.Colors.Highlight = style;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

		private void Randomizer_KeyPress(object sender, KeyPressEventArgs e)
		{
			switch (e.KeyChar)
			{
				case 'c':
					Clipboard.SetText(styleColor.R.ToString("X") + styleColor.G.ToString("X") + styleColor.B.ToString("X"));
					MessageBox.Show("Application color RGB Hex value copied in clipboard", "Data Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
				default:
					MessageBox.Show("Error", "Error");
					break;
			}
		}

		private void btnGen_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            if (intInput != null)
                lblResult.Text = r.Next(1, intInput.Value + 1).ToString();
            else
                MessageBox.Show("Invalid Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
