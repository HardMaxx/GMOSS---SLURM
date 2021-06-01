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
    public partial class FormToolsToChoose : Form
    {
        public FormToolsToChoose()
        {
            InitializeComponent();


        }

        public void setDataToJob(string jobName, string description)
        {
            setLinuxRight();
            labelJobName.Text = jobName;
            if (description == "")
                labelDescription.Text = "Empty";
            else
                labelDescription.Text = description;
        }

        //FormToolsToChoose FormToolsToChoose = new FormToolsToChoose(textBoxJobName.Text, textBoxDescription.Text);

        private void buttonBlast_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<AddJobForm>().Count() >= 1)
            {
                Global.FormNewJobsADD3.setDataToJob(labelJobName.Text, labelDescription.Text, "Blast");
                this.Visible = false;
                Global.FormNewJobsADD3.Visible = true;
                Global.FormNewJobsADD3.Focus();
                Global.FormNewJobsADD3.BringToFront();

            }
            else
            {
               // AddJobForm newJobsss = new AddJobForm(labelJobName.Text, labelDescription.Text, "Blast");
                Global.FormNewJobsADD3.setDataToJob(labelJobName.Text, labelDescription.Text, "Blast");
                this.Visible = false;
                Global.FormNewJobsADD3.Visible = true;
                Global.FormNewJobsADD3.Focus();
                Global.FormNewJobsADD3.Show();
                Global.FormNewJobsADD3.BringToFront();

            }

        }


        private void buttonPrevious_Click_1(object sender, EventArgs e)
        {
            this.Visible = false;
            Global.FormJobNameADD1.Visible = true;
            Global.FormJobNameADD1.Focus();
            Global.FormJobNameADD1.BringToFront();

        }

        private void FormToolsToChoose_Load(object sender, EventArgs e)
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
                //buttonResize.Visible = false;
                // this.panelControlLocation.Location = new Point(0, 0);
            }
        }

        private void buttonX_Click_1(object sender, EventArgs e)
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


