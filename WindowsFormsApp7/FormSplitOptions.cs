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
    public partial class FormSplitOptions : Form
    {
        string locationDir = "";
        string locationQue = "";
        string jobNa = "";
        public FormSplitOptions(string locationDirectory, string locationQuery, string jobName)
        {
            InitializeComponent();
            setLinuxRight();
            labelCheckDependent.Text = "";
            locationDir = locationDirectory;
            locationQue = locationQuery;
            jobNa = jobName;
        }

        private void checkBoxSequencePerFile_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNumberOfFiles.Checked)
                checkBoxSequencePerFile.Checked = false;
            checkSplitOptionLabel();
        }

        private void checkBoxNumberOfFiles_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxSequencePerFile.Checked)
                checkBoxNumberOfFiles.Checked = false;
            checkSplitOptionLabel();
        }

        public void checkSplitOptionLabel()
        {
            if (checkBoxNumberOfFiles.Checked)
                labelCheckDependent.Text = "files";
            else if (checkBoxSequencePerFile.Checked)
                labelCheckDependent.Text = "sequence per file";
            else if (!checkBoxSequencePerFile.Checked && !checkBoxNumberOfFiles.Checked)
                labelCheckDependent.Text = "";
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                   (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            if(textBox1.Text!="" && (checkBoxNumberOfFiles.Checked || checkBoxSequencePerFile.Checked))
            {
                Global.FormNewJobsADD3.splitNumber = textBox1.Text;
                if (checkBoxSequencePerFile.Checked)
                    Global.FormNewJobsADD3.splitFiles = false;
                else
                    Global.FormNewJobsADD3.splitFiles = true;

                splitFilesFunction(textBox1.Text, checkBoxNumberOfFiles.Checked);

                this.Close();



            }
            else
            {
                MessageBox.Show("You must select the type of division and enter the number");
            }
        }
        string directorySplitFilesName = "";
        public void splitFilesFunction(string splitNR, bool nrOfFiles)
        {
            
            string SplitOption = "";
            if (nrOfFiles)
            {
                SplitOption = "p";
                Global.SequencePerFile = false;
                Global.numberSplitedFiles = Convert.ToInt32(splitNR);
            }
            else
            {
                SplitOption = "s";
                Global.SequencePerFile = true;
                Global.numberSplitedFiles = Convert.ToInt32(splitNR);
            }
            directorySplitFilesName = jobNa + "-" + SplitOption.ToUpper() + "-" + textBox1.Text;
            
            string splitingComand = String.Format("./seqkit split {0} -{1} {2} -f -O {3}", locationQue, SplitOption, splitNR, directorySplitFilesName);

            something(splitingComand);//puszczamy program
            
        }

        public void something(string splitingComand)
        {

            string fileNameSH = "run_"+ directorySplitFilesName + "-Spliting.sh";
            string JobName = directorySplitFilesName + "-Spliting";
            string timeLimit = "1:00:00";
            string partition = "fast";
            int taskPerNode = 1;
            int memory = 8;

            string mkdirDirectory = String.Format("mkdir /tmp/lustre_shared/{0}/{1} > /dev/null 2>&1", Global.user, locationDir); //ditrctorydatabase?
            Global.connectionSession.RunCommand(mkdirDirectory);//create directory in tmp

            //przeniesienie makeblastdb do tmp
            string seqkitYesNo = "seqkit";
            string lineseqkit = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{3} ", Global.user, Global.directoryTypeLocation, seqkitYesNo, locationDir); //FilesToTMP, fileNameSH, tmpZnak);
            Global.connectionSession.RunCommand(lineseqkit);//przeniesienie programu seqkit do folderu tmp

            ////--------------
            string filesToCopy = @"{stdout-" + JobName + @".txt,stderr-" + JobName + @".txt}";//", + directorySplitFilesName + @".* //nazwy plikow wynikowych i folder z plikami
            string CopyFiles = String.Format("cp /tmp/lustre_shared/{0}/{1}{2} /home/users/{0}/{1}",
                Global.user, locationDir, filesToCopy); //kopiowanie wynikow obliczen do katalog domowego
            ////--------------

            ////--------------
           // string deleteTmpDirectory = @"rm -r /tmp/lustre_shared/" + Global.user + @"/" + Global.directoryDatabaseLocation; //for delete directory from a tmp                                                 
            string deleteCheckFile = ("rm /home/users/" + Global.user + "/" + locationDir + "check" + JobName + ".txt"); //for display good info and infor us if the data is

            ////--------------
            string lineQuery = String.Format("cp -n /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1}", Global.user, locationDir, locationQue); //FilesToTMP, fileNameSH, tmpZnak);
            string sleepBeforeFinish = "sleep 2";
            ////--------------\
            ///przenoszenie zawartosci pliku stder do stdout i czyszczenie esterr
            string stdErrToOUT = "cp stderr-" + JobName + ".txt stdout-" + JobName + ".txt"; //sed -n '10,15p' file1.txt > file2.txt
            string stdErrClear = "> stderr-" + JobName + ".txt";
            //

            string line = String.Format("cd {0};echo  \"#!/bin/bash\" >{1};echo  \"#SBATCH --job-name={2}\" >>{1};echo  \"#SBATCH --time={3}\" >>{1};" +
   " echo  \"#SBATCH -p {4}\" >>{1};echo  \"#SBATCH --nodes=1\" >>{1};echo  \"#SBATCH --ntasks-per-node={5}\" >>{1};" +
   "echo  \"#SBATCH --mem={6}gb\" >>{1};echo  \"#SBATCH -e stderr-{2}.txt\" >>{1};echo  \"#SBATCH -o stdout-{2}.txt\" >>{1};" +
   " echo \"{11}\" >>{1}; echo \"{7}\" >>{1}; echo  \"{12}\" >>{1}; echo  \"{13}\" >>{1}; echo  \"{14}\" >>{1}; echo \"{9}\" >>{1}; echo \"{10}\" >>{1}",
   locationDir, fileNameSH, JobName, timeLimit, partition, taskPerNode, memory, splitingComand, Global.user, CopyFiles, deleteCheckFile,
   lineQuery, sleepBeforeFinish, stdErrToOUT, stdErrClear); //zrobienie pliku sbatch

            Global.connectionSession.RunCommand(line); //create plik batch z zawartoscia


            string lineRUNCOPY = String.Format("cp /home/users/{0}/{1}{2} /tmp/lustre_shared/{0}/{1} ", Global.user, locationDir, fileNameSH); //FilesToTMP, fileNameSH, tmpZnak);
            Global.connectionSession.RunCommand(lineRUNCOPY);//przeniesienie plika run do folderu tmp
            //Console.WriteLine(line);
            Global.connectionSession.RunCommand("cd /home/users/" + Global.user + "/" + locationDir + ";touch check" + JobName + ".txt"); //create file check to if in function

            line = String.Format("cd /tmp/lustre_shared/{0}/{1}; sbatch {2}", Global.user, locationDir, fileNameSH);
            // Console.WriteLine(line);
            //wydobycie job id i jobname
            Global.SplitedFilesQueryLocation = directorySplitFilesName;
            string line2 = string.Format("{0} > /home/users/{1}/.ServerFiles/jobIDtmp.txt; cat /home/users/{1}/.ServerFiles/jobIDtmp.txt | cut -d \" \" -f4 > /home/users/{1}/.ServerFiles/jobID.txt", line, Global.user);
            Global.connectionSession.RunCommand(line2); //uruchomienie sbatch na tmp i zapisanie job id

            //etap dodawanie info o dodanym jobie
            AddInfoHistoryAboutAddedJob(JobName);


        }

        public void AddInfoHistoryAboutAddedJob(string JobName) //funkcja ktora uzupelnia onfo o dodanej jobie w plikach
        {

            MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Preparation for spliting the Query, please wait...");
            messageBoxInfo.Show();

            string JobID = String.Format("cat /home/users/{0}/.ServerFiles/jobID.txt", Global.user);

            var outputJobID = Global.connectionSession.RunCommand(JobID);

            //Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----//
            string[] linessss = (outputJobID.Result).Split('\n');


            for (int i = 0; i < linessss.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                var tempLine = linessss[i].Split(' ');
                for (int oo = 0; oo < tempLine.Length; oo++)
                {
                  //  Console.WriteLine(tempLine[oo]);
                }
            }

            var isNumericJobID = int.TryParse(outputJobID.Result, out int JobIdCheck);
           // Console.WriteLine(outputJobID.Result);

            DateTime nowTime = DateTime.Now;

            string historyJobsAddItme = String.Format("echo \"{0};{2};{3};{4};QuerySpliting\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", outputJobID.Result.Replace("\n", ""), Global.user, JobName, locationDir, nowTime);

            Global.connectionSession.RunCommand(historyJobsAddItme);
            // zapisanie job id i job name to remember history of file END
            Global.JobIDFromProgramm.Add(JobIdCheck);
            messageBoxInfo.Close();

            MessageBox.Show("Job for splitting files has been added");

            //sacct -u tomaszkuzma --format=JobID,JobName,Submit,State |grep -v '.ba+'
        }


        private void FormSplitOptions_Load(object sender, EventArgs e)
        {

        }

        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Split Options";
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
            Global.FormNewJobsADD3.splitNumber = "";
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
