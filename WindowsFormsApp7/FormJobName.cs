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
    public partial class FormJobName : Form
    {
        public FormJobName()
        {
            InitializeComponent();
        }


        public bool checkFormOne()
        {
            if(textBoxJobName.Text != "")
            {
                return true;
            }
            else
            {
                MessageBox.Show("You must provide a job name");
                return false;
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (checkFormOne())
            {
                //FormToolsToChoose FormToolsToChoose = new FormToolsToChoose(textBoxJobName.Text, textBoxDescription.Text);
                if (Application.OpenForms.OfType<FormToolsToChoose>().Count() >= 1)
                {
                    Global.FormToolsToChooseADD2.setDataToJob(textBoxJobName.Text.Replace(" ","").Replace(";", ""), textBoxDescription.Text.Replace(";", ""));
                    Global.FormToolsToChooseADD2.Visible = true;
                    Global.FormToolsToChooseADD2.Focus();
                    Global.FormToolsToChooseADD2.BringToFront();
                    this.Visible = false;

                }
                else
                {
                   // Global.FormToolsToChooseADD2 = new FormToolsToChoose(textBoxJobName.Text, textBoxDescription.Text);
                    Global.FormToolsToChooseADD2.setDataToJob(textBoxJobName.Text.Replace(" ", "").Replace(";", ""), textBoxDescription.Text.Replace(";", ""));
                    this.Visible = false;
                    Global.FormToolsToChooseADD2.Show();
                    

                }

            }
        }


        private void FormJobName_Load(object sender, EventArgs e)
        {

        }
        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Add Jobs";
                buttonClosewindow.Visible = false;
                //buttonResetDatagridView.Visible = false;
            }
            else
            {
                //buttonResetDatagridView.Visible = false;
                panelBorderStyle.Visible = false;
                buttonClosewindow.Visible = true;
               // buttonResize.Visible = false;
                // this.panelControlLocation.Location = new Point(0, 0);
            }
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            this.Visible = false;
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

        private void buttonClosewindow_Click(object sender, EventArgs e)
        {
            this.Visible = false;
        }
    }
}
