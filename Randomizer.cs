using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;
// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement

namespace Random_Generator
{

    public partial class Randomizer : Form
    {
        private const int WM_NCHITTEST = 132;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;

        private const int COLOR_HIGHLIGHT = 13;

        private Color styleColor;

        public Randomizer()
        {
            InitializeComponent();
        }

        #region Application Controls

        /// <summary>
        /// Handles Application Exit
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Handles Window Minimization
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMin_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        /// <summary>
        /// Handles click on the Help button
        /// Shows a Message box with useful info on using the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnHelp_Click(object sender, EventArgs e)
        {
            MessageBox.Show(@"Special Function keys:
1. 'h' Copies the current color hex code to the clipboard
2. 'r' Refreshes application style color
3. 'g' Clicks the 'Generate' button
4. 's' Sets the current style color as default highlight color

This application was designed and coded by Davoleo", 

                @"Need help?", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Handles the generation of random numbers
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGen_Click(object sender, EventArgs e)
        {
            Random r = new Random(); 
            if (intInput != null)
                lblResult.Text = r.Next(1, (int) intInput.Value + 1).ToString();
            else
                MessageBox.Show("Invalid Input!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        #endregion

        #region Other Event Handlers

        /// <summary>
        /// Generates the initial random color and calls the function that sets it to all the application controls
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            styleColor = generateRandomColor();
            initColors();
        }

        /// <summary>
        /// Handles the pressing of function keys to do specific actions inside of the application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Randomizer_KeyPress(object sender, KeyPressEventArgs e)
        {
            switch (e.KeyChar)
            {
                //Saves the style colour hexadecimal code in the clipboard
                case 'h':
                case 'H':
                    string colorText = styleColor.R.ToString("X2") + styleColor.G.ToString("X2") + styleColor.B.ToString("X2");
                    Clipboard.SetText(colorText);
                    MessageBox.Show("Application color RGB Hex value copied in clipboard", "Data Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                //Generates a new random style color
                case 'r':
                case 'R':
                    styleColor = generateRandomColor();
                    initColors();
                    MessageBox.Show("Syle Color Refreshed", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                //Triggers the "Generate" button
                case 'g':
                case 'G':
                    btnGen_Click(sender, e);
                    break;
                case 's':
                case 'S':
                    Color currentColor = GetCurrentSelectionColor();

                    ChangeSelectionColor(styleColor == currentColor
                        ? Color.FromArgb(7, 123, 220)
                        : styleColor);

                    MessageBox.Show(styleColor == currentColor
                        ? "Windows Highlight Color has been restored to its original state!"
                        : "Windows Highlight Color has been updated to match the current style color!");
                    break;
                default:
                    MessageBox.Show("Key not assigned to anything", "Huh?");
                    break;
            }
        }

        #endregion

        #region Other Functions

        /// <summary>
        /// Handles Window Dragging from the body of the application form
        /// </summary>
        /// <param name="m"></param>
        protected override void WndProc(ref Message m)
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

        /// <summary>
        /// Generates a random RGB color
        /// </summary>
        /// <returns>A random RGB color</returns>
        private Color generateRandomColor()
        {
            Random r = new Random();
            return Color.FromArgb(r.Next(256), r.Next(256), r.Next(256));
        }

        /// <summary>
        /// Sets the style color to all the UI Components of the application
        /// </summary>
        private void initColors()
        {
            BackColor = styleColor;
            btnGen.ForeColor = styleColor;
            btnClose.ForeColor = styleColor;
            btnMin.ForeColor = styleColor;
            btnHelp.ForeColor = styleColor;
            intInput.ForeColor = styleColor;
            //Used with the old DotNetBar IntegerInput
            //intInput.FocusHighlightColor = styleColor;
            //intInput.Colors.Highlight = styleColor;
        }

        #endregion

        #region Highlight Color Change Functions

        [DllImport("user32.dll")]
        static extern bool SetSysColors(int cElements, int[] lpaElements, uint[] lpaRgbValues);

        /// <summary>
        /// Changes the Default Windows Selection color to the passed parameter
        /// </summary>
        /// <param name="color">The new value applied as highlight color</param>
        private void ChangeSelectionColor(Color color)
        {
            //const int COLOR_HIGHLIGHTTEXT = 14;
            // You will have to set the HighlightText colour if you want to change that as well.


            //array of elements to change
            int[] elements = { COLOR_HIGHLIGHT };


            List<uint> colours = new List<uint>();
            colours.Add((uint)ColorTranslator.ToWin32(color));

            //set the desktop color using p/invoke
            SetSysColors(elements.Length, elements, colours.ToArray());
        }

        [DllImport("user32.dll")]
        static extern uint GetSysColor(int nIndex);

        /// <summary>
        /// </summary>
        /// <returns>The current highlight color</returns>
        private Color GetCurrentSelectionColor()
        {
            return ColorTranslator.FromWin32((int) GetSysColor(COLOR_HIGHLIGHT));
        }

        #endregion
    }
}
