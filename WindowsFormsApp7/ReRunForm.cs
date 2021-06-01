using Renci.SshNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class ReRunForm : Form
    {
        public ReRunForm(string jobName, string directoryName, int jobID)
        {
            InitializeComponent();
            setLinuxRight();
            JobName = jobName;
            DirectoryName = directoryName;
            JobIDToCancel = jobID;
            labelDirecotryName.Text = directoryName;
            labelJobName.Text = jobName;
            labelDirecotryName.Visible = false;
        }

        string JobName;
        string DirectoryName;
        int JobIDToCancel;

        private void ReRunForm_Load(object sender, EventArgs e)
        {

        }

        private void DeleteJobFromFileAndDataGiordview()
        {
                        var valueOfHistroyOfJobs = Global.connectionSession.RunCommand("cd .ServerFiles/ ; sed -i '/"+JobName+"/d' ./HistoryJobs.txt");

                        Global.ALLListHistoryOfJobsFromFile.Remove(Global.ALLListHistoryOfJobsFromFile.Find(d => d.JobName == JobName));
                        Global.FormHistoryOfJobs.LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, Global.FormHistoryParamiter);

        }


        private void buttonRunJobAgain_Click(object sender, EventArgs e)
        {
            Global.connectionSession.RunCommand("scancel " + JobIDToCancel); ; //canselowanie jesli  jest aktywne jeszcze

            string stderr = "stderr-" + JobName + ".txt";
            string stdout = "stdout-" + JobName + ".txt";
            Global.connectionSession.RunCommand("cd " + DirectoryName + "; rm " + stderr+ "; rm " + stdout); //walanie starego error i stdout
            Global.connectionSession.RunCommand("cd //;cd tmp/lustre_shared/" + Global.user + "/" + DirectoryName + "; rm " + stderr+"; rm " + stdout); //walanie starego error i stdout

            DeleteJobFromFileAndDataGiordview();

            //dodanie nowego joba ktory byl uruhcomiony raz jescze

            string line = "cd //;cd tmp/lustre_shared/" + Global.user + "/" + DirectoryName + "; sbatch run_" + JobName + ".sh";
            //wydobycie job id i jobname
            string line2 = string.Format("{0} > /home/users/{1}/.ServerFiles/jobIDtmp.txt; cat /home/users/{1}/.ServerFiles/jobIDtmp.txt | cut -d \" \" -f4 > /home/users/{1}/.ServerFiles/jobID.txt", line, Global.user);
            Global.connectionSession.RunCommand(line2); //uruchomienie sbatch na tmp i zapisanie job id
                                                        //zapisanie job id i job name to remember history of file
            string JobID = String.Format("cat /home/users/{0}/.ServerFiles/jobID.txt", Global.user);

            var outputJobID = Global.connectionSession.RunCommand(JobID);

            //----- ZAPISANIE DANYCH Z PLIKU-----//
            string[] linessss = (outputJobID.Result).Split('\n');


            for (int i = 0; i < linessss.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                var tempLine = linessss[i].Split(' ');
                for (int oo = 0; oo < tempLine.Length; oo++)
                {
                    //Console.WriteLine(tempLine[oo]);
                }
            }

            var isNumericJobID = int.TryParse(outputJobID.Result, out int JobIdCheck);
           // Console.WriteLine(outputJobID.Result);
            if (!isNumericJobID)
            {
                MessageBox.Show("No access to the selected partition or diffrent problem " + outputJobID.Result);
              //  Console.WriteLine(outputJobID.Result);
                Global.connectionSession.RunCommand("rm /home/users/" + Global.user + "/" + DirectoryName + " run_" + JobName + ".sh");
                //Global.connectionSession.RunCommand(deleteCheckFile);
                //jesli wybrano partycje do ktorej nie mamy dostepu usun plik
            }
            else
            {
                DateTime nowTime = DateTime.Now;
                string description = "Launched again";
                string historyJobsAddItme = String.Format("echo \"{0};{2};{3};{4};{5}\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", outputJobID.Result.Replace("\n", ""), Global.user, JobName, DirectoryName, nowTime, description);

                Global.connectionSession.RunCommand(historyJobsAddItme);
                                                                         // zapisanie job id i job name to remember history of file END
                Global.JobIDFromProgramm.Add(JobIdCheck);

                Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + DirectoryName + ";touch check" + JobName + ".txt"); //create file check to if in function

                MessageBox.Show("Job has been added");
                this.Close();
                //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+'
            }
        }

        private void buttonNo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void labelDirecotryName_Click(object sender, EventArgs e)
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
                labelFormName.Text = "Rerun job";
                //buttonResetDatagridView.Visible = false;
            }
            else
            {
                //buttonResetDatagridView.Visible = false;
                panelBorderStyle.Visible = false;
               // buttonResize.Visible = false;
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
    }
}
