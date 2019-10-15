using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Random_Generator
{

    public partial class Randomizer : Form
    {
        private const int WM_NCHITTEST = 132;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;

        private int X, Y;

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
            styleColor = generateRandomColor();
            initColors();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangeSelectColor(Color.FromArgb(7, 123, 220));
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
                //Saves the style colour hexadecimal code in the clipboard
                case 'h':
					Clipboard.SetText(styleColor.R.ToString("X2") + styleColor.G.ToString("X2") + styleColor.B.ToString("X2"));
					MessageBox.Show("Application color RGB Hex value copied in clipboard", "Data Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
					break;
                //Generates a new random style color
                case 'r':
                    styleColor = generateRandomColor();
                    initColors();
                    MessageBox.Show("Syle Color Refreshed", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                //Triggers the "Generate" button
                case ' ':
                    btnGen_Click(sender, e);
                    break;
				default:
					MessageBox.Show("Key not assigned to anything", "Huh?");
					break;
			}
		}

        //Generates a new random color
        private Color generateRandomColor()
        {
            Random r = new Random();
            return Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }

        //Sets the style color to all the components of the application
        private void initColors()
        {
            BackColor = styleColor;
            btnGen.ForeColor = styleColor;
            btnClose.ForeColor = styleColor;
            btnMin.ForeColor = styleColor;
            btnHelp.ForeColor = styleColor;
            intInput.ForeColor = styleColor;
            ChangeSelectColor(styleColor);
            //Used with the old DotNetBar IntegerInput
            //intInput.FocusHighlightColor = styleColor;
            //intInput.Colors.Highlight = styleColor;
        }

        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Special Function keys: \n 1. 'h' Copies the current color hex code to the clipboard  \n 2. 'r' Refreshes application style color \n 3. 'SPACEBAR' Clicks the 'Generate' button \n\n(To make sure these keys function properly pls disable CAPS lock and be sure not to focus any control)\n\n This application is designed and coded by Davoleo", 
                "Ya need help?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }


        [DllImport("user32.dll")]
        static extern bool SetSysColors(int cElements, int[] lpaElements, uint[] lpaRgbValues);

        private void ChangeSelectColor(Color color)
        {
            const int COLOR_HIGHLIGHT = 13;
            const int COLOR_HIGHLIGHTTEXT = 14;
            // You will have to set the HighlightText colour if you want to change that as well.


            //array of elements to change
            int[] elements = { COLOR_HIGHLIGHT };


            List<uint> colours = new List<uint>();
            colours.Add((uint)ColorTranslator.ToWin32(color));

            //set the desktop color using p/invoke
            SetSysColors(elements.Length, elements, colours.ToArray());

        }

        //Generates a random number from 1 to the counter value
        private void btnGen_Click(object sender, EventArgs e)
        {
            Random r = new Random(); 
            if (intInput != null)
                lblResult.Text = r.Next(1, (int) intInput.Value + 1).ToString();
            else
                MessageBox.Show("Invalid Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }
    }
}
