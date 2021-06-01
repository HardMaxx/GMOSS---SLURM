using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Renci.SshNet;
using Renci.SshNet.Sftp;
using System.IO;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Runtime.InteropServices;

namespace WindowsFormsApp7
{

    public partial class SignIn : Form
    {
        public SignIn()
        {
            InitializeComponent();

            setLinuxRight();

             //button1.Visible = false;
        }

        public  SshClient connection(string user, string password) //create client
        {
            AuthenticationMethod metod = new PasswordAuthenticationMethod(user, password);
            ConnectionInfo connection = new ConnectionInfo(Global.host, user, metod);
            SshClient client = new SshClient(connection);

            return client;
        }

        public void clearUser()
        {
            textBoxLogin.Text = "";
            textBoxPassword.Text = "";
        }
        public void shutDownConnection(ref SignIn SignIn)
        {
            SignIn.Close();
        }

        public void assignUser(string userIN, string passIN)
        {
            Global.user = userIN;
            Global.pass = passIN;
        }

        private void buttonSignIn_Click(object sender, EventArgs e)
        {

            if (textBoxLogin.Text == "" || textBoxPassword.Text == "")
                MessageBox.Show("You must enter your login and password!");
            else
            {

                assignUser(textBoxLogin.Text, textBoxPassword.Text);
                Global.connectionSession = connection(Global.user, Global.pass);

                try
                {
                    Global.connectionSession.Connect();
                    this.Visible = false;


                    //new Functions(SignIn.user).ShowDialog();
                    Global.FunctionsNameUserParamiter = Global.user;
                    PleaseWait pl = new PleaseWait();
                    pl.Show();
                    Functions Functions = new Functions(Global.user);
                    Functions.Show();
                    pl.Close();
                    clearUser();
                }
                catch (Exception er)
                {
                    MessageBox.Show(" Failed to connect to server " + er.ToString());
                    Console.WriteLine(" Failed to connect to server " + er.ToString());
                    Global.connectionSession.Disconnect();
                    this.Close();
                    Environment.Exit(0);// zapykanie wszytskich watkow, petli windows
                }

                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if u want login to server without writing every time password and login just write it here and uncomend (comend sign in function below) just for testing
            string userTest = "...";
            string passTest = "...";
            //string userTest = ".";
            assignUser(userTest, passTest);
            
            //assignUser(textBoxLogin.Text, textBoxPassword.Text);
            Global.connectionSession = connection(Global.user, Global.pass);

            try
            {
                Global.connectionSession.Connect();
                this.Visible = false;

                // new Functions(SignIn.user).ShowDialog();
                Global.FunctionsNameUserParamiter = Global.user;
                PleaseWait pl = new PleaseWait();
                pl.Show();
                Functions Functions = new Functions(Global.user);
                Functions.Show();
                pl.Close();
                
                clearUser();

            }
            catch (Exception er)
            {
                MessageBox.Show(" Failed to connect to server ");
                Console.WriteLine(" Failed to connect to server " + er.ToString());
                Global.connectionSession.Disconnect();
                this.Close();
                Environment.Exit(0);// zapykanie wszytskich watkow, petli windows
            }
        }

        
        private void SignIn_Load(object sender, EventArgs e)
        {

        }
        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Sign in";
            }
            else
            {
                panelBorderStyle.Visible = false;
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
    public static class Global
    {
        public static List<sQueue> ALLbazasQueue = new List<sQueue>(); // ALL
        public static List<sInfo> ALLbazasInfo = new List<sInfo>(); //ALL
        public static List<ClassHistoryJobs> ALLListHistoryOfJobsFromFile = new List<ClassHistoryJobs>(); //ALL
        public static List<ClassMainHistoryJobs> ListMainHistoryOfJobsFromFile = new List<ClassMainHistoryJobs>(); //ALL

        public static string LastUpdateTime = ""; // keep time when was last update
        public static string SinfoNamePartitionParamiter = ""; //keep info what data is going to this frame
        public static string SqueueNameUserParamiter = "";//keep info what data is going to this frame
        public static string FunctionsNameUserParamiter = "";//keep info what data is going to this frame
        public static string FormHistoryParamiter = "";//keep info what data is going to this frame
        public static int timeReset = 0; // actual time  info how is going when timeReset == timeRefresh we update data
        public static int timeRefresh = 20; //time how often shoudl data update
        public static int timeResetHistory = 0; // actual time  info how is going when timeReset == timeRefresh we update data
        public static int timeRefreshHistory = 60; //time how often shoudl data update

        public static int limitMBProgram = 8000; //time how often shoudl data update

        public static bool actualUserNameFunction = true; //to refresh datagridview if picket username isnt corest to actual view data in form Functions
        public static string user = "";
        public static string host = "eagle.man.poznan.pl";
        public static string pass = "";
        public static SshClient connectionSession; // for acces into connection from everywhere

        public static SinfoPartition SinfoPartitionForm;
        public static SqueuePartition SqueuePartitionForm;
        public static FormHistory FormHistoryOfJobs;
        public static MainHistoryJobs FormMainHistoryOfJobs;

        public static List<string> partitionsInfoList = new List<string>(); // do listy userow combobox
        public static bool HistoryEditMode = false; //if editmode is true dont refresh history
        public static List<int> JobIDFromProgramm = new List<int>(); //ALL

        //add job forms
        public static FormJobName FormJobNameADD1 = new FormJobName();
        public static FormToolsToChoose FormToolsToChooseADD2 = new FormToolsToChoose();
        public static AddJobForm FormNewJobsADD3 = new AddJobForm();
        public static FormDirectoryRunJob FormNewJobADD4 = new FormDirectoryRunJob();
        public static FormScontrolShow FormScontrolClick = new FormScontrolShow();
        public static string directoryQueryLocation;
        public static string directoryDatabaseLocation;
        public static string directoryTypeLocation;

        public static string SplitedFilesQueryLocation;
        public static bool SequencePerFile=false;
        public static int numberSplitedFiles;

        public static string makeblastdbComand;

        public static bool splitQueryMultiplyJobs = false; // daj einfo czy robimy mase jobow
                                                          
        public static List<ClassHistoryJobs> ClickedTMPListHistoryOfJobs = new List<ClassHistoryJobs>(); //lista tymczasowych elementow z kliknietego joba przechowuje te dane ktore chemy zoba zyc
       
        public static bool CantClick = false; // jesli false to blokuje klikanie na element bo odswieza

        public static int minimalTotalJobGraph = 200;
        // FormJobNameForm.Show();
    }
}