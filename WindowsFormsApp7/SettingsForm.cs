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

namespace WindowsFormsApp7
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
            setLinuxRight();

            TextBoxRefreshingTime.Text = Global.timeRefresh.ToString();
            TextBoxRefreshingTimeHistory.Text = Global.timeRefreshHistory.ToString();
            textBoxLimitMBProgram.Text = Global.limitMBProgram.ToString();
        }

        public void RefreshTime()
        {
            int refreshingTime = 0;
            try
            {
                refreshingTime = Convert.ToInt32(TextBoxRefreshingTime.Text);
                if (refreshingTime < 10)
                {
                    MessageBox.Show("The recommended refresh time should not be less than 10 seconds");
                }
                else
                {
                    Global.timeRefresh = refreshingTime;
                    MessageBox.Show("Refresh time has been changed");
                    Global.timeReset = 0;
                    if(Convert.ToInt32(TextBoxRefreshingTimeHistory.Text) == Global.timeRefreshHistory) //jesli nie byla zmienian historia odswiezania to zamknij
                         this.Close();
                }
            }
            catch
            {
                MessageBox.Show("You must enter the number itself");
                TextBoxRefreshingTime.Text = "";
            }
        }

        public void RefreshTimeHistory()
        {
            int refreshingTime = 0;
            try
            {
                refreshingTime = Convert.ToInt32(TextBoxRefreshingTimeHistory.Text);
                if (refreshingTime < 50)
                {
                    MessageBox.Show("The recommended refresh time should not be less than 50 seconds, remember the more jobs you have ordered, the longer it will take to load your job history");
                }
                else
                {
                    Global.timeRefreshHistory = refreshingTime;
                    MessageBox.Show("Refresh time history has been changed");
                    Global.timeResetHistory = 0;
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("You must enter the number itself");
                TextBoxRefreshingTimeHistory.Text = "";
            }
        }

        public void LimitMemoryForProgram()
        {
            int limitMBProgram = 0;
            try
            {
                limitMBProgram = Convert.ToInt32(textBoxLimitMBProgram.Text);
                if (limitMBProgram < 4000)
                {
                    MessageBox.Show("The recommended limit memory for program is 4000 mb");
                }
                else
                {
                    Global.limitMBProgram = limitMBProgram;
                    MessageBox.Show("Limit memory for the program has been changed");
                    this.Close();
                }
            }
            catch
            {
                MessageBox.Show("You must enter the number itself");
                textBoxLimitMBProgram.Text = "";
            }
        }

        private void buttonConfirmRefresh_Click(object sender, EventArgs e)
        {
            if (TextBoxRefreshingTime.Text != Global.timeRefresh.ToString())
            {
                RefreshTime();
            }
            if (TextBoxRefreshingTimeHistory.Text != Global.timeRefreshHistory.ToString())
            {
                RefreshTimeHistory();
            }
            if (textBoxLimitMBProgram.Text != Global.limitMBProgram.ToString())
            {
                LimitMemoryForProgram();
            }

        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {

        }

        private void TextBoxRefreshingTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void buttonClosewindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Settings";
                //buttonResetDatagridView.Visible = false;
            }
            else
            {
                //buttonResetDatagridView.Visible = false;
                panelBorderStyle.Visible = false;
                //buttonResize.Visible = false;
                // this.panelControlLocation.Location = new Point(0, 0);
            }
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        //https://stackoverflow.com/questions/1592876/make-a-borderless-form-movable?noredirect=1&lq=1

        // MOVE PANEL LINUX
        private bool mouseDown;
        private Point lastLocation;
        private void panelBorderStyle_MouseMove(object sender, MouseEventArgs e)
        {
            if (mouseDown)
            {
                this.Location = new Point(
                    (this.Location.X - lastLocation.X) + e.X, (this.Location.Y - lastLocation.Y) + e.Y);

                this.Update();
            }
        }

        private void panelBorderStyle_MouseUp(object sender, MouseEventArgs e)
        {
            mouseDown = false;
        }

        private void panelBorderStyle_MouseDown(object sender, MouseEventArgs e)
        {
            mouseDown = true;
            if (mouseDown && this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
            }
            else
            {
                lastLocation = e.Location;
            }

        }

        private void textBoxLimitMBProgram_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
