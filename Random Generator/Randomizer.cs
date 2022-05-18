using System;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.AccessControl;
using System.Windows.Forms;
using Microsoft.Win32;

// ReSharper disable InconsistentNaming
// ReSharper disable LocalizableElement

namespace Random_Generator
{

    public partial class Randomizer : Form
    {
        //Body drag values
        private const int WM_NCHITTEST = 132;
        private const int HTCLIENT = 1;
        private const int HTCAPTION = 2;

        private readonly Color DEFAULT_HIGHLIGHT_COLOR = Color.FromArgb(7, 123, 220);

        private readonly RegistrySecurity registrySecurity = new RegistrySecurity();

        private Color styleColor;

        public Randomizer()
        {
            InitializeComponent();
            registrySecurity.AddAccessRule(new RegistryAccessRule($"{Environment.UserDomainName}\\{Environment.UserName}",
            RegistryRights.SetValue, InheritanceFlags.None, PropagationFlags.None, AccessControlType.Allow));
        }

        #region Application Components

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
1. <Ctrl + H> Copies the current style color hex code to the clipboard
2. <Ctrl + R> Refreshes application style color
3. <Ctrl + G> Generates a new Random Number
4. <Ctrl + S> Sets the current style color as default text highlight color

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
        private void Randomizer_KeyDown(object sender, KeyEventArgs e)
        {
            // The Event corresponds to pressing of Control key (but it should be treated as a dead key so we ignore events coming from it)
            if (e.KeyCode == Keys.ControlKey)
                return;

            //If Control is not pressed in the key combo -> ignore the combo (decreases pollution of Message Boxes)
            if (!e.Control)
                return;

            e.Handled = true;
            switch (e.KeyCode)
            {
                //Saves the style colour hexadecimal code in the clipboard
                case Keys.H:
                    string colorText = styleColor.R.ToString("X2") + styleColor.G.ToString("X2") + styleColor.B.ToString("X2");
                    Clipboard.SetText(colorText);
                    MessageBox.Show("Application color RGB Hex value copied in clipboard", "Data Copied", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                //Generates a new random style color
                case Keys.R:
                    styleColor = generateRandomColor();
                    initColors();
                    MessageBox.Show("Syle Color Refreshed", "Succesful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                //Triggers the "Generate" button
                case Keys.G:
                    btnGen_Click(sender, e);
                    break;
                case Keys.S:
                    DialogResult result = MessageBox.Show("Are you sure you want to change the text highlight color?",
                        "Randomizer", MessageBoxButtons.OKCancel);
                    if (result == DialogResult.OK)
                    {
                        Color currentColor = GetCurrentSelectionColor();
                        ChangeSelectionColor(styleColor == currentColor
                            ? DEFAULT_HIGHLIGHT_COLOR
                            : styleColor);
                    }
                    break;
                default:
                    if (!(sender is NumericUpDown))
                        MessageBox.Show("Need help? Click on the '?' button to know the available keybinds", "This key doesn't do anything!");
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

        /// <summary>
        /// Changes the Default Windows Selection color to the passed parameter
        /// </summary>
        /// <param name="color">The new value applied as highlight color</param>
        private void ChangeSelectionColor(Color color)
        {
            int intColor = ColorTranslator.ToWin32(color);

            try
            {
                RegistryKey colorScheme =
                    Registry.LocalMachine.OpenSubKey(
                        "SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Themes\\DefaultColors\\Standard", true);

                colorScheme.SetValue("Hilight", intColor, RegistryValueKind.DWord);
                colorScheme.SetValue("HilightText", color.GetBrightness() > 0.5 ? 0x0 : 0xFFFFFF,
                    RegistryValueKind.DWord);
            }
            catch (SecurityException)
            {
                DialogResult securityResult = MessageBox.Show(
                    "Security Exception! You need to run this app with administrator privileges to do this!",
                    "Randomizer", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error);

                if (securityResult == DialogResult.Retry)
                {
                    ProcessStartInfo process = new ProcessStartInfo();
                    process.UseShellExecute = true;
                    process.FileName = Application.ExecutablePath;
                    process.Verb = "runas";
                    try
                    {
                        Process.Start(process);
                    }
                    catch
                    {
                        //User Refused the elevation -> return;
                        return;
                    }

                    Application.Exit();
                }
                return;
            }
            catch (Exception)
            {
                MessageBox.Show("Error while Editing Registry values");
                return;
            }

            const string question = "\nDo you want to Lock and Unlock your account to apply the changes?";
            DialogResult result = MessageBox.Show(color == DEFAULT_HIGHLIGHT_COLOR
                ? ("Windows Highlight Color has been restored to its original state!" + question)
                : ("Windows Highlight Color has been updated to match the current style color!" + question), 
                "Randomizer", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk);

            if (result == DialogResult.Yes)
                LockWorkStation();
                
        }

        [DllImport("user32.dll")]
        private static extern uint GetSysColor(int nIndex);

        [DllImport("user32.dll")]
        internal static extern void LockWorkStation();

        /// <summary>
        /// </summary>
        /// <returns>The current highlight color</returns>
        private Color GetCurrentSelectionColor()
        {
            const int COLOR_HIGHLIGHT = 13;
            return ColorTranslator.FromWin32((int) GetSysColor(COLOR_HIGHLIGHT));
        }

        #endregion
    }
}
