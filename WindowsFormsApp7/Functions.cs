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
using System.Security;
using Tamir.SharpSsh.jsch.examples;
using System.Text.RegularExpressions;
using System.Runtime.InteropServices;
using System.Threading;
using System.Collections;
using System.Globalization;
using System.Diagnostics;

//DO ZROBIENIA
//- wywalic pobieranie pliku niech dziala na pliku z serwera ?/??? DONE ZROBIONE
//- dodac odswierzanie tak by byl an tym samym etapie z ktorego odswiezyl choc nw czy to wazne - plan malo wazny (łatwo zrobic ale duzo funkcji od kazdej opcji inny, ciezko zrobic jedna funkcje dla wszystki, przesylanie obiektu)
//-dodanie dla usera i dla usera z palca// ZROBIONE
//- przy odswiezaniu dodaje liste do wybru raz jeszcze wiec jest tego x2 A PRZY CZYSZCZENIU CZYSZCZE WSZYTSKO I NIC NIE DAJE  ?? ZROBIONE NAPRAWIONE[;
//- jesli w pliku nie ma przerwy czyli biegnie od poczatku jest blad  SQUEUE  !~ ???? ZROBIONE NAPRAWIONE


//-- DODAC BY odswiezanie z ostatniego etapu bylo na tym co skonczylo, sprobowac ZROBIONE
//-- cos mialo byc zale zpaomznialem

//-- zmiana grafiki fixed okienka, datagridview szersze tam gdzie pasek jest na dole, wywalenie minimalizacji i minimalizacji tylko ZROBIONE

namespace WindowsFormsApp7
{
    //partia
    public partial class Functions : Form
    {

        public SinfoListPartition squeueListt;
        public List<sQueue> bazasQueue = new List<sQueue>(); // small // zawiera dane z ostatniego kliknietego z lilisty partition
        public List<sInfo> bazasInfo = new List<sInfo>(); //small
        public static List<string> usersQueueList = new List<string>(); // do listy userow combobox
        public static List<string> partitionsQueueList = new List<string>(); // do listy userow combobox

        private List<sQueue> bazasQueueUSER = new List<sQueue>(); // small // zawiera dane z ostatniego kliknietego z lilisty partition

        public Functions(string userName)
        {
            InitializeComponent();
            buttonCancelMode.Text = "Refreshing";
            buttonCancelMode.BackColor = Color.LightGreen;

            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture; //to set multiple culture time to one to work properly

            buttonUserMyData.Text = Global.user;


            //PROPERTIS IF IT IS A LINUX OR NOT
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
               // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                buttonResize.Visible = true;
                //buttonResetDatagridView.Visible = false;
            }
            else
            {
                //buttonResetDatagridView.Visible = false;
                panelBorderStyle.Visible = false;
                this.panelControlLocation.Location = new Point(0,0);
                buttonResize.Visible = false;
            }

            Global.timeResetHistory=Global.timeRefreshHistory-5; // by po 5 sekundach zaczelo sie odswiezanie hiatori by dane szybciej byly widoczne
            
            SQUEUEBACK(usersQueueList, partitionsQueueList,Global.ALLbazasQueue);
            sInfoDataBACK(Global.ALLbazasInfo, Global.partitionsInfoList);


            aaajobformsAddDataOneTime();


            labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
            lastUpdateHistroyTime = Global.LastUpdateTime;
            for (int i = 0; i < usersQueueList.Count()-1; i++)
            {
                comboBox1.Items.Add(usersQueueList[i]);
                //Console.WriteLine(usersQueueList[i]);
            }

                sQueueMyData(userName);
            //this.dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.changeColorSINFO); // zmiana koloru domyslnie od razu
            //https://stackoverflow.com/questions/2189376/how-to-change-row-color-in-datagridview/12998501#12998501?newreg=c1b677e24a7a41799a0ac68bdfb6ab92
            ColorType colorek = new ColorType();

            this.dataGridView3.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.changeColorSQUEUE); // zmiana koloru domyslnie od razu

            checkBoxSetChecked();

            timer1.Start();

        }
        
        public void aaajobformsAddDataOneTime()
        {
            
            for (int item = 0; item < Global.partitionsInfoList.Count() - 1; item++)
            {

                PartitionTimeLimit temp = new PartitionTimeLimit();
                foreach (var ele in Global.ALLbazasInfo)
                {
                    if (Global.partitionsInfoList[item] != "all")
                    {
                        if (ele.PARTITION == Global.partitionsInfoList[item])
                        {
                            temp.PARTITION = ele.PARTITION;
                            temp.TIMELIMIT = ele.TIMELIMIT;
                            Global.FormNewJobsADD3.bazaPartitionLimitSinfo.Add(temp);
                            break;
                        }
                    }
                }

            }
        }


        
        public void StringToTime(string textBox, TimeClass ClassTime)
        {
          
            if (textBox.Contains("-")  && Regex.Matches(textBox.ToString(), "-").Count == 1) //jesli zawiera - nie moze byc wiecejn niz 1
            {
                try
                {
                    ClassTime.day = textBox[0].ToString(); //dodanie pierwszej liczby
                    if (textBox[1].ToString() != "-" && char.IsDigit(textBox[1]) && textBox[2].ToString() == "-") //jesli bedzie wiecej niz 9 dni i 2 znak jestv liczba
                    {
                        ClassTime.day = (ClassTime.day) + Convert.ToString(textBox[1]);
                    }
                    string result = textBox.Split('-').Skip(1).FirstOrDefault(); //to skip part about days
                    string[] separate = (result).Split(':');
                    if (separate.Length > 0)
                        ClassTime.hour = separate[0];
                    else
                        ClassTime.hour = "0";
                    if (separate.Length > 1)
                        ClassTime.minute = separate[1];
                    else
                        ClassTime.minute = "0";
                    if (separate.Length > 2)
                        ClassTime.second = separate[2];
                    else
                        ClassTime.second = "0";
                }
                catch(Exception ex)
                {
                    Console.WriteLine("elo if");
                    MessageBox.Show("if" + ex.Message);
                }
            }

            else if (textBox.ToString().Contains("UNLIMITED")) //nie zawiera -
            {
                ClassTime.day = "999";
                ClassTime.hour = "0";
                ClassTime.minute = "0";
                ClassTime.second = "0";


            }
            else if (Regex.Matches(textBox.ToString(), "-").Count == 0 && textBox.ToString().Contains(":")) //nie zawiera -
            {
                try
                {
                    string[] separate = (textBox).Split(':');
                    if (separate.Length == 2)//jeśli nie ma godzin
                    {
                        ClassTime.day = "0";
                        ClassTime.hour = "0";
                        ClassTime.minute = separate[0];
                        ClassTime.second = separate[1];
                    }
                    else //jelsi sa godziny
                    {
                        ClassTime.day = "0";
                        ClassTime.hour = separate[0];
                        if (separate.Length > 1)
                            ClassTime.minute = separate[1];
                        else
                            ClassTime.minute = "0";
                        if (separate.Length > 2)
                            ClassTime.second = separate[2];
                        else
                            ClassTime.second = "0";
                    }
                }catch(Exception ex)
                {
                    //Console.WriteLine("elo else");
                    MessageBox.Show("esle if" + ex.Message);
                }

              
            }
            else
            {
               // Console.WriteLine("to z texz box else" +textBox.ToString()); //jesli jakis bez paternu
                ClassTime.day = "0";
                ClassTime.hour = "0";
                ClassTime.minute = "0";
                ClassTime.second = "0";
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int total = 0;
            int run = 0;
            int pending = 0;
            int comleti = 0;
            int configure = 0;

            try
            {
                Global.FunctionsNameUserParamiter = comboBox1.SelectedItem.ToString();
                bazasQueueUSER = new List<sQueue>(); //nowa lista by wyswietlic aktualna

                foreach (var row in Global.ALLbazasQueue)
                {

                    sQueue temp = new sQueue();
                    if (row.User == comboBox1.SelectedItem.ToString())
                    {

                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueueUSER.Add(temp);
                        total++;

                        if (temp.State == "RUNNING")
                            run++;
                        if (temp.State == "PENDING")
                            pending++;
                        if (temp.State == "COMPLETI")
                            comleti++;
                        if (temp.State == "CONFIGUR")
                            configure++;

                    }
                }

                dataGridView3.DataSource = bazasQueueUSER; // przypisanie bazy do gridview
                labelPendingJobsU.Text = "Pending Jobs: " + pending;
                labelRunningJobsU.Text = "Running Jobs: " + run;
                labelTotalJobsU.Text = "Total Jobs: " + total;
                labelCompleteJobsU.Text = "Complete Jobs: " + comleti;
                labelConfigureJobsU.Text = "Configure Jobs: " + configure;
                setSelectedData();
            }
            catch
            {

            }
        }

        private void buttonStopJobs_Click(object sender, EventArgs e)
        {

            if (editCancel)
            {
                //this code is to prevend error if user hide a column and waht cancel jobs
                int nrColWithID = 1;// this code is to prevend error if user hide a column and waht cancel jobs
                if (checkBoxJob.Checked && checkBoxName.Checked)
                {
                    nrColWithID = 1;
                }
                else if (!checkBoxName.Checked && checkBoxJob.Checked)
                {
                    nrColWithID = 0;
                }
                else
                {
                    nrColWithID = 99;
                }

                if (nrColWithID != 99)//this code is to prevend error if user hide a column and waht cancel jobs
                {
                    if (dataGridView3.SelectedRows.Count > 0) //jelsi cos zaznacozne
                    {
                        DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel this jobs?", "Cancel Jobs", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Interrupting selected tasks, please wait...");
                            messageBoxInfo.Show();


                            // bool outRow = false;
                            foreach (DataGridViewRow drv in dataGridView3.SelectedRows)//przechodzi po calym datagridview
                            {
                                // Console.WriteLine(drv.Cells[0].Value);
                                // Console.WriteLine(drv.Cells[1].Value);
                                var val = Convert.ToInt32(drv.Cells[nrColWithID].Value);
                                Global.connectionSession.RunCommand("scancel " + val);
                            }

                            messageBoxInfo.Close();
                        }
                        else if (dialogResult == DialogResult.No)
                        {
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("You must select jobs to cancel");
                    }
                }
                else
                {
                    MessageBox.Show("The job id column must be visible");
                }

            }
            else
            {
                MessageBox.Show("Click green button to stop refreshing and enter cancel mode");
            }
        }

        bool editCancel = false;
        private void buttonCancelMode_Click(object sender, EventArgs e)
        {
            if (!editCancel)
            {
                //timer1.Stop();
                editCancel = true;
                buttonCancelMode.Text = "Refreshing stopped";
                buttonCancelMode.BackColor = Color.LightCoral;
            }
            else
            {
                //timer1.Start();
                editCancel = false;
                buttonCancelMode.Text = "Refreshing";
                buttonCancelMode.BackColor = Color.LightGreen;
            }
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int nrRow = dataGridView3.CurrentCell.RowIndex;
            // Console.WriteLine(nrRow);
            int row1 = 0;
            int col1 = 0;
            bool setSelectYES = false;

            try
            {
                if (bazasQueueUSER.Count >= 1)
                {
                    int nrColumn = dataGridView3.CurrentCell.ColumnIndex;
                    // nrRow = dataGridView3.CurrentCell.RowIndex;
                    string name = dataGridView3.Columns[nrColumn].Name;
                    if (name == "Partition")
                    {

                        if (Application.OpenForms.OfType<SinfoPartition>().Count() >= 1)
                        {
                            Global.SinfoNamePartitionParamiter = dataGridView3.SelectedCells[0].Value.ToString();
                            Global.SinfoPartitionForm.LoadDatabazasInfo(Global.SinfoNamePartitionParamiter, Global.ALLbazasInfo);
                            Global.SinfoPartitionForm.Focus();
                            Global.SinfoPartitionForm.BringToFront();

                        }
                        else
                        {
                            Global.SinfoPartitionForm = new SinfoPartition(dataGridView3.SelectedCells[0].Value.ToString());
                            Global.SinfoNamePartitionParamiter = dataGridView3.SelectedCells[0].Value.ToString();
                            Global.SinfoPartitionForm.Show();
                        }

                    }
                    if (name == "Job")
                    {

                        if (Application.OpenForms.OfType<FormScontrolShow>().Count() >= 1)
                        {
                            MessageBoxInfo mess = new MessageBoxInfo("Loading data");
                            mess.Show();
                            Global.FormScontrolClick.loadData(dataGridView3.SelectedCells[0].Value.ToString());
                            Global.FormScontrolClick.Focus();
                            Global.FormScontrolClick.BringToFront();
                            mess.Close();

                        }
                        else
                        {
                            MessageBoxInfo mess = new MessageBoxInfo("Loading data");
                            mess.Show();
                            Global.FormScontrolClick = new FormScontrolShow();
                            Global.FormScontrolClick.loadData(dataGridView3.SelectedCells[0].Value.ToString());
                            Global.FormScontrolClick.Show();
                            mess.Close();
                        }
                    }
                }

                if (Application.OpenForms.OfType<SinfoPartition>().Count() < 1) //by okno sie nie zastepowalo
                {
                    if (dataGridView3.Rows.Count > 0)
                    {
                        setSelectYES = true;
                    }
                    if (setSelectYES)
                    {
                        row1 = (this.dataGridView3.CurrentCell.RowIndex);
                        col1 = (this.dataGridView3.CurrentCell.ColumnIndex);
                    }
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podczas klikania w elementy tabeli tu" + ex.Message);

            }
            if (setSelectYES)
            {
                this.dataGridView3.CurrentCell = this.dataGridView3[col1, row1]; // zapis nr wiersza
                                                                                 //int nrRow = dataGridView3.CurrentCell.RowIndex;
                for (int t = 0; t < dataGridView3.ColumnCount; t++) //zaznaczeniw calego wiersza
                {
                    this.dataGridView3[t, nrRow].Selected = true;
                }
            }

        }

        private void buttonUserMyData_Click(object sender, EventArgs e)
        {
            Global.FunctionsNameUserParamiter = Global.user;
            sQueueMyData(Global.user);
            setSelectedData();
        }
        int total = 0;
        int run = 0;
        int pending = 0;
        int comleti = 0;
        int configure = 0;

        public void sQueueMyData(string userName)
        {
             total = 0;
             run = 0;
             pending = 0;
             comleti = 0;
             configure = 0;

            bazasQueueUSER = new List<sQueue>(); //nowa lista by wyswietlic aktualna
            foreach (var row in Global.ALLbazasQueue)
            {
                sQueue temp = new sQueue();
                if (userName.Contains(row.User) && userName.StartsWith(row.User)) //SignIn.user
                {
                    temp.Job = row.Job;
                    temp.Partition = row.Partition;
                    temp.Name = row.Name;
                    temp.User = row.User;
                    temp.State = row.State;
                    temp.Time = row.Time;
                    temp.TimeLimit = row.TimeLimit;
                    temp.Nodes = row.Nodes;
                    temp.Nodelist = row.Nodelist;
                    bazasQueueUSER.Add(temp);
                    total++;

                    if (temp.State == "RUNNING")
                        run++;
                    if (temp.State == "PENDING")
                        pending++;
                    if (temp.State == "COMPLETI")
                        comleti++;
                    if (temp.State == "CONFIGUR")
                        configure++;
                }
            }
            if (bazasQueueUSER.Count < 1)
            {
                labelPendingJobsU.Text = "Pending Jobs: 0";
                labelRunningJobsU.Text = "Running Jobs: 0";
                labelTotalJobsU.Text = "Total Jobs: 0";
                labelCompleteJobsU.Text = "Complete Jobs: 0";
                labelConfigureJobsU.Text = "Configure Jobs: 0";
                bazasQueueUSER.Clear();
                dataGridView3.DataSource = bazasQueueUSER;

            }
            else
            {
                dataGridView3.DataSource = bazasQueueUSER; // przypisanie bazy do gridview
                labelPendingJobsU.Text = "Pending Jobs: " + pending;
                labelRunningJobsU.Text = "Running Jobs: " + run;
                labelTotalJobsU.Text = "Total Jobs: " + total;
                labelCompleteJobsU.Text = "Complete Jobs: " + comleti;
                labelConfigureJobsU.Text = "Configure Jobs: " + configure;
            }
        }


        private void buttonLogOut_Click(object sender, EventArgs e)///!
        {
            
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to log out?", "Log Out", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                MessageBox.Show("You have been logged out");
                timer1.Stop();
                Global.connectionSession.Disconnect();

                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();

                Environment.Exit(0);



            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        //---------------------------------------------------------------------- ----------------------------------------------------------------------//

        //---------------------------------------------------------------------- ----------------------------------------------------------------------//

        private void changeColorSQUEUE(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            ColorType colorek = new ColorType();

            if (Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells[3].Value) == "PENDING")
            {
                dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.reserved;// Color.Yellow;
            }
            if (Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells[3].Value) == "RUNNING")
            {
                dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.allocated; //Color.Green;
            }
            if (Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells[3].Value) == "COMPLETI")
            {
                dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.completing;// Color.LightCoral;
            }
            if (Convert.ToString(dataGridView3.Rows[e.RowIndex].Cells[3].Value) == "CONFIGUR")
            {
                dataGridView3.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.power_up;// Color.LightBlue;
            }
        }

        private void Functions_Load(object sender, EventArgs e)
        {

        }

        private void buttonSystemSum_Click(object sender, EventArgs e)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {

                if (Application.OpenForms.OfType<SystemGraph>().Count() >= 1)
                {
                    Application.OpenForms.OfType<SystemGraph>().First().Close();

                }
                SystemGraph systemSUM = new SystemGraph();
                systemSUM.Show();
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (Application.OpenForms.OfType<SystemGraphLinux>().Count() >= 1)
                {
                    Application.OpenForms.OfType<SystemGraphLinux>().First().Close();

                }
                SystemGraphLinux systemSUM = new SystemGraphLinux();
                systemSUM.Show();
            }

        }

        private void buttonSqueueList_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SinfoListPartition>().Count() >= 1)
            {
                Application.OpenForms.OfType<SinfoListPartition>().First().Close();

            }
            squeueListt = new SinfoListPartition();
            squeueListt.Show();
        }

        public void updateGrindViewData() //we need this to update date when a click user from diffrent form after checking bool we run this method in timer
        {
            try
            {
                this.dataGridView3.DataSource = null;
                this.dataGridView3.Rows.Clear();
                this.dataGridView3.Refresh();
                bazasQueueUSER.Clear();

                int total = 0;
                int run = 0;
                int pending = 0;
                int comleti = 0;
                int configure = 0;

                foreach (var row in Global.ALLbazasQueue)
                {

                    sQueue temp = new sQueue();
                    if (Global.FunctionsNameUserParamiter.Contains(row.User) && Global.FunctionsNameUserParamiter.StartsWith(row.User))
                    {

                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueueUSER.Add(temp);
                        total++;

                        if (temp.State == "RUNNING")
                            run++;
                        if (temp.State == "PENDING")
                            pending++;
                        if (temp.State == "COMPLETI")
                            comleti++;
                        if (temp.State == "CONFIGUR")
                            configure++;

                    }
                }

                dataGridView3.DataSource = bazasQueueUSER; // przypisanie bazy do gridview
                                                           //changeColorSQUEUE(); //zmiana koloru PENDING RUNUNG
                labelPendingJobsU.Text = "Pending Jobs: " + pending;
                labelRunningJobsU.Text = "Running Jobs: " + run;
                labelTotalJobsU.Text = "Total Jobs: " + total;
                labelCompleteJobsU.Text = "Complete Jobs: " + comleti;
                labelConfigureJobsU.Text = "Configure Jobs: " + configure;
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error in updateGrindViewData (Functions form), Code error: " + ex.Message);
            }
        }

        int marginGC = 10;
        int actualNumber = 0;
        int Activechecking = 3; //jak czesto ma sprawdzac czy pliki w bazie sa
        int activecheckingCount = 0;

        bool TimeToCloseProgram = false;
        int TimeToCloseCount = 0;

        private void timer1_Tick(object sender, EventArgs e)
        {

            if (!isReadyHistory)
            {
                buttonHistory.Enabled = false;
            }
            else
            {
                buttonHistory.Enabled = true;
            }


                if (Global.FormNewJobsADD3.startchecking) //jelsi ma sprawdzxac czy sa pliki
            {
                activecheckingCount++;
                if (Activechecking <= activecheckingCount)
                {
                    Global.FormNewJobsADD3.activeCheckingIfDatabaseIsIndexedAlready();
                    activecheckingCount = 0;
                   // Console.WriteLine("aktywne sprawdzanie lala");
                }
            }

            Global.timeReset++;
            Global.timeResetHistory++;
            if (Global.timeReset == Global.timeRefresh)
            {
              
                actualNumber++;
                //code to async work to run another work cancel
                if (backgroundWorker1.IsBusy)
                    backgroundWorker1.CancelAsync();

                while (backgroundWorker1.IsBusy)
                    Application.DoEvents();

                    backgroundWorker1.RunWorkerAsync();
                //to here async

                    Global.timeReset = 0;
                    setSelectedData();
                if (actualNumber == marginGC)
                {
                    //MessageBox.Show("czyszcze");
                    actualNumber = 0;
                    //GC.Collect();
                    //GC.WaitForPendingFinalizers();
                   // MessageBox.Show("czyszczenie skonczone xd");
                }
            }


            else if (!Global.actualUserNameFunction) // if selected user name is not actual in main from just update it
            {
                updateGrindViewData();
                Global.actualUserNameFunction = true;
                setSelectedData();
            }

            if (Application.OpenForms.OfType<Functions>().Count() < 1)
            {
                Environment.Exit(0);
            }

            if (Global.timeResetHistory == Global.timeRefreshHistory)
            {

                //--------------------------this part of code is to selfclose program if usage memory is hight----------------------////
                Process currentProc = Process.GetCurrentProcess();
                long memoryUsed = currentProc.PrivateMemorySize64;
                //Console.WriteLine("total memeoryusage:" + memoryUsed / 1000000);

                if (TimeToCloseProgram)
                {
                    TimeToCloseCount++;
                }

                if(Global.limitMBProgram < memoryUsed / 1000000 && TimeToCloseProgram==false)
                {
                        TimeToCloseProgram = true;
                    MessageBox.Show("High memory usage, finish your work and run the program again, the program will close automatically in a few minutes.");
                }
                if (TimeToCloseCount > 10)
                {
                    //MessageBox.Show("You have been logged out");
                    timer1.Stop();
                    Global.connectionSession.Disconnect();

                    if (backgroundWorker1.IsBusy)
                        backgroundWorker1.CancelAsync();

                    Environment.Exit(0);
                }

                //--------------------------this part of code is to selfclose program if usage memory is hight   END----------------------////


                //code to async work to run another work cancel
                if (backgroundWorker2.IsBusy)
                    backgroundWorker2.CancelAsync();

                while (backgroundWorker2.IsBusy)
                    Application.DoEvents();

                backgroundWorker2.RunWorkerAsync();
                //to here async

                Global.timeResetHistory = 0;

            }
        }

        private void buttonSettings_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            SettingsForm SettingsForm = new SettingsForm();
            SettingsForm.ShowDialog();
            timer1.Start();
        }


        public void checkBoxSetChecked()
        {

            checkBoxName.Checked = true;
            checkBoxJob.Checked = true;
            checkBoxUser.Checked = true;
            checkBoxState.Checked = true;
            checkBoxTime.Checked = true;
            checkBoxTimeLimit.Checked = true;
            checkBoxNodes.Checked = true;
            checkBoxNodeList.Checked = true;
            checkBoxPartition.Checked = true;
        }

        private void checkBoxJob_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
                this.dataGridView3.Columns[0].Visible = true;
            else
                this.dataGridView3.Columns[0].Visible = false;
            checkSelectedData();

        }

        private void checkBoxPartition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPartition.Checked)
                this.dataGridView3.Columns[8].Visible = true;
            else
                this.dataGridView3.Columns[8].Visible = false;
            checkSelectedData();
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxJob.Checked)
                this.dataGridView3.Columns[1].Visible = true;
            else
                this.dataGridView3.Columns[1].Visible = false;
            checkSelectedData();
        }

        private void checkBoxUser_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUser.Checked)
                this.dataGridView3.Columns[2].Visible = true;
            else
                this.dataGridView3.Columns[2].Visible = false;
            checkSelectedData();
        }

        private void checkBoxState_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxState.Checked)
                this.dataGridView3.Columns[3].Visible = true;
            else
                this.dataGridView3.Columns[3].Visible = false;
            checkSelectedData();
        }

        private void checkBoxTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTime.Checked)
                this.dataGridView3.Columns[4].Visible = true;
            else
                this.dataGridView3.Columns[4].Visible = false;
            checkSelectedData();

        }

        private void checkBoxTimeLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTimeLimit.Checked)
                this.dataGridView3.Columns[5].Visible = true;
            else
                this.dataGridView3.Columns[5].Visible = false;

            checkSelectedData();
        }

        private void checkBoxNodes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNodes.Checked)
                this.dataGridView3.Columns[6].Visible = true;
            else
                this.dataGridView3.Columns[6].Visible = false;
            checkSelectedData();
        }

        private void checkBoxNodeList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNodeList.Checked)
                this.dataGridView3.Columns[7].Visible = true;
            else
                this.dataGridView3.Columns[7].Visible = false;

            checkSelectedData();
        }

        private int _previousIndex;
        private bool _sortDirection;


        public  List<sQueue> tempList = new List<sQueue>();
        //https://stackoverflow.com/questions/5553100/how-to-enable-datagridview-sorting-when-user-clicks-on-the-column-header
        private void gridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {

            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // zmiana sorotwania ros/mal


            dataGridView3.DataSource = SortData(
                (List<sQueue>)dataGridView3.DataSource, dataGridView3.Columns[e.ColumnIndex].Name, _sortDirection);

            _previousIndex = e.ColumnIndex;
            setSelectedData();
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //to reset scroll to default position after click sort
                dataGridView3.CurrentCell = dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0];
                dataGridView3.CurrentCell = dataGridView3.Rows[0].Cells[0];
                dataGridView3.CurrentCell = dataGridView3.Rows[0].Cells[0];
                dataGridView3.FirstDisplayedScrollingRowIndex = 0;
            }
            /// ///////////////////---------recover selected rows after refresh---------/////////////

            if (dataGridView3.Rows.Count > 1)
            {
                

                for (int t = 0; t < dataGridView3.ColumnCount; t++) //zaznaczeniw calego wiersza
                {
                    this.dataGridView3[t, dataGridView3.FirstDisplayedScrollingRowIndex].Selected = true;
                }
                this.dataGridView3.CurrentCell = this.dataGridView3[0, dataGridView3.FirstDisplayedScrollingRowIndex];// this.dataGridView3[0, dataGridView3.FirstDisplayedScrollingRowIndex]; // zapis nr wiersza
            }
            ///////////////////-----------------------------------------------------/////////////
        }

        public List<sQueue> SortData(List<sQueue> list, string column, bool ascending) //rosnaco?
        {

            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }
        // ############################################### CODE NEEDED FOR LINUX START ###############################################################
        public void setSelectedData()
        {
            if (selectedData[0])
            {
                checkBoxName.Checked = true;
                this.dataGridView3.Columns[0].Visible = true;
            }
            else
            {
                checkBoxName.Checked = false;
                this.dataGridView3.Columns[0].Visible = false;
            }
            if (selectedData[8])
            {
                checkBoxPartition.Checked = true;
                this.dataGridView3.Columns[8].Visible = true;
            }
            else
            {
                checkBoxPartition.Checked = false;
                this.dataGridView3.Columns[8].Visible = false;
            }
            if (selectedData[1])
            {
                checkBoxJob.Checked = true;
                this.dataGridView3.Columns[1].Visible = true;
            }
            else
            {
                checkBoxJob.Checked = false;
                this.dataGridView3.Columns[1].Visible = false;
            }
            if (selectedData[2])
            {
                checkBoxUser.Checked = true;
                this.dataGridView3.Columns[2].Visible = true;
            }
            else
            {
                checkBoxUser.Checked = false;
                this.dataGridView3.Columns[2].Visible = false;
            }
            if (selectedData[3])
            {
                checkBoxState.Checked = true;
                this.dataGridView3.Columns[3].Visible = true;
            }
            else
            {
                checkBoxState.Checked = false;
                this.dataGridView3.Columns[3].Visible = false;
            }
            if (selectedData[4])
            {
                checkBoxTime.Checked = true;
                this.dataGridView3.Columns[4].Visible = true;
            }
            else
            {
                checkBoxTime.Checked = false;
                this.dataGridView3.Columns[4].Visible = false;
            }
            if (selectedData[5])
            {
                checkBoxTimeLimit.Checked = true;
                this.dataGridView3.Columns[5].Visible = true;
            }
            else
            {
                checkBoxTimeLimit.Checked = false;
                this.dataGridView3.Columns[5].Visible = false;
            }
            if (selectedData[6])
            {
                checkBoxNodes.Checked = true;
                this.dataGridView3.Columns[6].Visible = true;
            }
            else
            {
                checkBoxNodes.Checked = false;
                this.dataGridView3.Columns[6].Visible = false;
            }
            if (selectedData[7])
            {
                checkBoxNodeList.Checked = true;
                this.dataGridView3.Columns[7].Visible = true;
            }
            else
            {
                checkBoxNodeList.Checked = false;
                this.dataGridView3.Columns[7].Visible = false;
            }
        }
        public bool[] selectedData = new bool[] { true, true, true, true, true, true, true, true, true };

        public void checkSelectedData()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX)) //DO SPRAWDZENIA, czy cos to robi na l
                //linuxie bo na widowsie gdy sa jakies joby wywala program na linuxie to przechodzi sprawdzic czy bez tego na linuxie cos sie zmienia
            {
                if (dataGridView3.Rows.Count > 1)
                {
                    this.dataGridView3.CurrentCell = this.dataGridView3[0, dataGridView3.FirstDisplayedScrollingRowIndex];
                }
            }
                if (checkBoxName.Checked)
                selectedData[0] = true;
            else
                selectedData[0] = false;
            if (checkBoxPartition.Checked)
                selectedData[8] = true;
            else
                selectedData[8] = false;
            if (checkBoxJob.Checked)
                selectedData[1] = true;
            else
                selectedData[1] = false;
            if (checkBoxUser.Checked)
                selectedData[2] = true;
            else
                selectedData[2] = false;
            if (checkBoxState.Checked)
                selectedData[3] = true;
            else
                selectedData[3] = false;
            if (checkBoxTime.Checked)
                selectedData[4] = true;
            else
                selectedData[4] = false;
            if (checkBoxTimeLimit.Checked)
                selectedData[5] = true;
            else
                selectedData[5] = false;
            if (checkBoxNodes.Checked)
                selectedData[6] = true;
            else
                selectedData[6] = false;
            if (checkBoxNodeList.Checked)
                selectedData[7] = true;
            else
                selectedData[7] = false;
        }
        //method for linux scroll
        public int DatacScrollPosition(DataGridView dataGridView)
        {
            int rowIndex = 0;
            for (int i = 0; i < dataGridView.Rows.Count; i++)
            {
                if (dataGridView.Rows[i].Displayed)
                {
                    rowIndex = i;
                    break;
                }
            }

            return rowIndex;
        }

        //############################################# CODE NEEDED FOR LINUX END ###############################################################

        //############################################# CODE NEEDED FOR BACKGROUDN UPDATE START ###############################################################
        public List<sQueue> ALLbazasQueueBACK = new List<sQueue>(); // ALL
        private List<sQueue> bazasQueueUSERBACK = new List<sQueue>(); // small // zawiera dane z ostatniego 
        public List<string> usersQueueListBACK = new List<string>(); // do listy userow combobox
        public List<string> partitionsQueueListBACK = new List<string>(); // do listy userow combobox
        //public List<string> partitionsInfoListBACK = new List<string>(); // do listy userow combobox
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker1.WorkerSupportsCancellation = true; //chyba zbedne jak sie sypie to wlaczyc
            if (this.backgroundWorker1.CancellationPending)
            {
                e.Cancel = true;
                return;
            }
            //squeue data
                SQUEUEBACK(usersQueueListBACK, partitionsQueueListBACK, ALLbazasQueueBACK);
                
            //sinfo data
                sInfoDataBACK(ALLbazasInfoBACK,partitionsInfoListBACK);
            
        }

        string lastUpdateHistroyTime = Global.LastUpdateTime;
      
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
            try
                {

                //put new data to global list
                bazasQueueUSER =  bazasQueueUSERBACK;
                Global.ALLbazasQueue = ALLbazasQueueBACK;
                usersQueueList = usersQueueListBACK;
                partitionsQueueList = partitionsQueueListBACK;
                Global.partitionsInfoList = partitionsInfoListBACK;
                

                labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
                //save scroll start
                int saveRow = 0;

                ///////////////////---------to save a selected state before refresh---------/////////////
                if (!editCancel) //jesli false to nie doswiezaj bo bedzimey cancelwoac
                {
                    int row1 = 0;
                    int col1 = 0;
                    bool setSelectYES = false;
                    if (dataGridView3.Rows.Count > 0)
                    {
                        setSelectYES = true;
                    }
                    if (setSelectYES)
                    {
                        row1 = (this.dataGridView3.CurrentCell.RowIndex);
                        col1 = (this.dataGridView3.CurrentCell.ColumnIndex);
                    }

                    ///////////////////------------------------------------/////////////

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        if (dataGridView3.Rows.Count > 0)
                            saveRow = DatacScrollPosition(dataGridView3);
                    }

                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        if (dataGridView3.Rows.Count > 0 && dataGridView3.FirstDisplayedCell != null)
                            saveRow = dataGridView3.FirstDisplayedCell.RowIndex;
                    }
                    //save scroll end

                    //update data in main data grid view
                    sQueueMyData(Global.FunctionsNameUserParamiter);


                    comboBox1.Items.Clear(); //to clear combobox

                    for (int i = 0; i < usersQueueList.Count() - 1; i++)
                    {
                        comboBox1.Items.Add(usersQueueList[i]);
                    }

                    // data substitution
                    dataGridView3.DataSource = bazasQueueUSER;
                    //set sortet like before refresh
                    dataGridView3.DataSource = SortData(
                   (List<sQueue>)dataGridView3.DataSource, dataGridView3.Columns[_previousIndex].Name, _sortDirection);
                    setSelectedData();



                    ///////////////////---------recover selected rows after refresh---------/////////////

                    if (setSelectYES && dataGridView3.Rows.Count > 1)
                    {
                        this.dataGridView3.CurrentCell = this.dataGridView3[col1, row1]; // zapis nr wiersza

                        for (int t = 0; t < dataGridView3.ColumnCount; t++) //zaznaczeniw calego wiersza
                        {
                            this.dataGridView3[t, row1].Selected = true;
                        }
                    }
                    ///////////////////-----------------------------------------------------/////////////

                    //save scroll start
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                    {
                        if (saveRow != 0 && saveRow < dataGridView3.Rows.Count)
                            dataGridView3.FirstDisplayedScrollingRowIndex = saveRow;
                    }
                    if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                    {
                        if (saveRow != 0 && saveRow < dataGridView3.Rows.Count)
                        {
                            dataGridView3.CurrentCell = dataGridView3.Rows[dataGridView3.Rows.Count - 1].Cells[0];
                            dataGridView3.CurrentCell = dataGridView3.Rows[saveRow].Cells[0];
                            dataGridView3.CurrentCell = dataGridView3.Rows[saveRow].Cells[0];
                        }

                        ///////////////////---------recover selected rows after refresh---------/////////////

                        if (setSelectYES && dataGridView3.Rows.Count > 1)
                        {
                            this.dataGridView3.CurrentCell = this.dataGridView3[col1, row1]; // zapis nr wiersza

                            for (int t = 0; t < dataGridView3.ColumnCount; t++) //zaznaczeniw calego wiersza
                            {
                                this.dataGridView3[t, row1].Selected = true;
                            }
                        }
                        ///////////////////-----------------------------------------------------/////////////
                    }
                    //Console.WriteLine("seelcted row nr: " + saveRow);

                    labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
                    //save scroll end

                    labelPendingJobsU.Text = "Pending Jobs: " + pending;
                    labelRunningJobsU.Text = "Running Jobs: " + run;
                    labelTotalJobsU.Text = "Total Jobs: " + total;
                    labelCompleteJobsU.Text = "Complete Jobs: " + comleti;
                    labelConfigureJobsU.Text = "Configure Jobs: " + configure;

                }

                Global.ALLbazasInfo = ALLbazasInfoBACK;

                if (Application.OpenForms.OfType<SinfoPartition>().Count() >= 1)
                {
                    //MessageBox.Show("jest wiec update czas");

                    Global.SinfoPartitionForm.LoadDatabazasInfo(Global.SinfoNamePartitionParamiter, ALLbazasInfoBACK);


                }
                if (Application.OpenForms.OfType<SqueuePartition>().Count() >= 1)
                {

                    //MessageBox.Show("jest wiec update czas");
                    Global.SqueuePartitionForm.loadDataBaseSqueu(Global.SqueueNameUserParamiter, Global.ALLbazasQueue);

                }
                if (Application.OpenForms.OfType<SinfoListPartition>().Count() >= 1)
                {

                    //MessageBox.Show("jest wiec update czas");
                    squeueListt.LoadDatabazasInfo(ALLbazasInfoBACK);

                }

            }

            catch (NullReferenceException ex)
            {
                Console.WriteLine("Function selected warning etc" + ex.Message);
            }

            catch (Exception ex)
            {
                MessageBox.Show("Functions \nError substituting background data" + ex.Message);
            }
        }

        //############################################# CODE NEEDED FOR BACKGROUDN UPDATE END ###############################################################

        //############################################# CODE NEEDED FOR LOAD DATA START ###############################################################
        public void SQUEUEBACK(List<string> usersQueueList, List<string> partitionsQueueList, List<sQueue> AllBazaSqueue)
        {
            Global.connectionSession.RunCommand("mkdir .ServerFiles");
            Global.connectionSession.RunCommand("chmod 700 .ServerFiles");
            //----PRZYGOTOWANIE OBROBIONYCH PLIKOW---------//   
            Global.connectionSession.RunCommand("cd .ServerFiles;squeue -all > wynikk.txt");//
            Global.connectionSession.RunCommand("cd .ServerFiles;tr -s \\ <wynikk.txt > wynikkk.txt"); //obrobka pliku
            Global.connectionSession.RunCommand("cd .ServerFiles;cat wynikkk.txt | sed 's/^[ \\t]*//' > wynik.txt"); //wyrazenei regolarne do usuniecia spacji z poczatku pliku
            Global.connectionSession.RunCommand("cd .ServerFiles;tr -s \\ < wynik.txt | (read;read;cat)  > partitionProgress.txt"); //obrobka pliku
            Global.connectionSession.RunCommand("cd .ServerFiles;cut -d ' ' -f2  partitionProgress.txt | sort -u  > partition.txt"); //wyciagniecie partition do pliku partition.txt
            Global.connectionSession.RunCommand("cd .ServerFiles;cut -d ' ' -f4  partitionProgress.txt | sort -u > usersQueueList.txt"); //wyciaganie listy uzytkownikow
            var output = Global.connectionSession.RunCommand("cd .ServerFiles;head -1 wynikk.txt");//wyciagniecie info o ostatniej aktualizaci
            //labelLastUpdateSQUEUE.Text = "Ostatnia aktualizacja: " + output.Result;
            //labelLastUpdateSQUEUE.Text = "Last actualisation: " + output.Result;
            Global.LastUpdateTime = "Last actualisation: " + output.Result;
            //----PRZYGOTOWANIE LISTY PARTITION DO WYBORU----//
            output = Global.connectionSession.RunCommand("cd .ServerFiles;cat partition.txt");
            string newLine = Environment.NewLine;
            // Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----
            string[] lines = (output.Result).Split('\n');

                partitionsQueueList.Clear();

                for (int i = 0; i < lines.Length; i++)
                {
                    ListViewItem item = new ListViewItem(lines[i]); // adding partition to listview
                                                                    //listViewPartitionSQUEUE.Items.Add(item); // lista partition
                    partitionsQueueList.Add(lines[i]); // lista partycji z squeue

                }

            //----ROBIENIE LISTY USEROW----//
            output = Global.connectionSession.RunCommand("cd .ServerFiles;cat usersQueueList.txt");
            lines = (output.Result).Split('\n');
            usersQueueList.Clear();

                for (int i = 0; i < lines.Length; i++)
                {
                    usersQueueList.Add(lines[i]);// lista user z squeue
                }

            //-----------------------------//

            //----PRZYGOTOWANIE CALEGO PLIKU----//
            output = Global.connectionSession.RunCommand("cd .ServerFiles;cat partitionProgress.txt ");
            //Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----
            lines = (output.Result).Split('\n');

            AllBazaSqueue.Clear(); // przy odswiezaniu wazne by wyczywscic pprzedna tablice


            //--------------------JESLI BEDZIEMY ZAPISYWAC STARSZE WERSJE TO TU W SENSIE DO NOWEJ LOSTY KTORA STROWRZYMY PODOBNEJ DO ALLSQUEUE--------------------//

            try
            {
                for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
                {
                    Regex r = new Regex(@"\s+"); //zamiana spacji na nic

                    string result = r.Replace(lines[i], ";");
                    var tempLine = result.Split(';'); //tabliza znakow podzielenie na elementy po napotkaniu ;
                    sQueue temp = new sQueue();

                    temp.Job = tempLine[0];
                   // Console.WriteLine(tempLine[0]);
                    temp.Partition = tempLine[1];
                    //Console.WriteLine(tempLine[1]);
                    temp.Name = tempLine[2];
                    //Console.WriteLine(tempLine[2]);
                    temp.User = tempLine[3];
                    //Console.WriteLine(tempLine[3]);
                    temp.State = tempLine[4];
                    //Console.WriteLine(tempLine[4]);
                    TimeClass timeLimit = new TimeClass();
                    StringToTime(tempLine[5], timeLimit); //convert string to TimeSpan
                    TimeSpan elapsedTime =
           new TimeSpan(Convert.ToInt32(timeLimit.day), Convert.ToInt32(timeLimit.hour), Convert.ToInt32(timeLimit.minute), Convert.ToInt32(timeLimit.second));
                    
                    temp.Time = elapsedTime;
                    //Console.WriteLine(elapsedTime);
                    //temp.Time = tempLine[5];

                        timeLimit = new TimeClass();
                        StringToTime(tempLine[6], timeLimit);//convert string to TimeSpan
                        elapsedTime =
               new TimeSpan(Convert.ToInt32(timeLimit.day), Convert.ToInt32(timeLimit.hour), Convert.ToInt32(timeLimit.minute), Convert.ToInt32(timeLimit.second));
                        //Console.WriteLine(elapsedTime);
                        temp.TimeLimit = elapsedTime;
                    //temp.TimeLimit = tempLine[6];

                    temp.Nodes = Convert.ToInt32(tempLine[7]);

                    StringBuilder builder = new StringBuilder();
                    builder.Append(tempLine[8]).Append(" ");
                    if (tempLine.Length > 8)
                    {
                        for (int u = 9; u < tempLine.Length; u++)
                        {
                            builder.Append(tempLine[u]).Append(" ");
                        }
                    }
                    temp.Nodelist = builder.ToString();
                    //Console.WriteLine(temp.Nodelist);
                    AllBazaSqueue.Add(temp);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("tu blad: " + ex.Message);
            }

        }

        public List<sInfo> ALLbazasInfoBACK = new List<sInfo>(); // ALL
        public List<string> partitionsInfoListBACK = new List<string>();
        //private List<sInfo> bazasQueueUSERBACK = new List<sInfo>(); // small // zawiera dane z ostatniego 

        public void sInfoDataBACK(List<sInfo> ALLbazasInfo,List<string> partitionsInfoList)
        {

            //----PRZYGOTOWANIE OBROBIONYCH PLIKOW---------//   
            Global.connectionSession.RunCommand("cd .ServerFiles;sinfo -all > sinfo.txt");//
            Global.connectionSession.RunCommand("cd .ServerFiles;tr -s \\ < sinfo.txt | (read; read; cat)  > sinfoPartitionProgress.txt"); //obrobka pliku
            Global.connectionSession.RunCommand("cd .ServerFiles;cut -d ' ' -f1 sinfoPartitionProgress.txt | sort -u  > sinfoPartition.txt"); //wyciagniecie partition do pliku partition.txt
            //var output = Global.connectionSession.RunCommand("head -1 sinfo.txt");//wyciagniecie info o ostatniej aktualizaci
            //----PRZYGOTOWANIE LISTY PARTITION DO WYBORU----//
            var output = Global.connectionSession.RunCommand("cd .ServerFiles;cat sinfoPartition.txt");
            string newLine = Environment.NewLine;
            //Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----//
            string[] lines = (output.Result).Split('\n');
            Global.partitionsInfoList.Clear();
            for (int i = 0; i < lines.Length; i++)
            {
                ListViewItem item = new ListViewItem(lines[i]); // adding partition to listview
                partitionsInfoList.Add(lines[i]); // lista partycji z sinfo
            }
            //Console.WriteLine(output.Result);

            //----PRZYGOTOWANIE CALEGO PLIKU, ZAPISANIE DANYCH DO LISTY----//
             output = Global.connectionSession.RunCommand("cd .ServerFiles;cat sinfoPartitionProgress.txt ");
            //Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----
            lines = (output.Result).Split('\n');

            ALLbazasInfo.Clear(); // przy odswiezaniu wazne by wyczywscic pprzedna tablice

            //--------------------JESLI BEDZIEMY ZAPISYWAC STARSZE WERSJE TO TU W SENSIE DO NOWEJ LOSTY KTORA STROWRZYMY PODOBNEJ DO ALLSQUEUE--------------------//
            for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                Regex r = new Regex(@"\s+"); //zamiana spacji na nic

                string result = r.Replace(lines[i], ";");
                var tempLine = result.Split(';'); //tabliza znakow podzielenie na elementy po napotkaniu ;
                sInfo temp = new sInfo();

                if (tempLine[0] != "all")
                {
                    temp.PARTITION = tempLine[0];

                    temp.AVAIL = tempLine[1];

                    //convert string to TimeSpan
                    TimeClass timeLimit = new TimeClass();
                    StringToTime(tempLine[2], timeLimit); //convert string to TimeSpan
                    TimeSpan elapsedTime =
           new TimeSpan(Convert.ToInt32(timeLimit.day), Convert.ToInt32(timeLimit.hour), Convert.ToInt32(timeLimit.minute), Convert.ToInt32(timeLimit.second));
                    temp.TIMELIMIT = elapsedTime;
                    //temp.TIMELIMIT = tempLine[2];

                    temp.JOB_SIZE = tempLine[3];

                    temp.NODES = Convert.ToInt32(tempLine[7]);//4
                    
                    temp.STATE = tempLine[8];//5

                    temp.NODELIST = tempLine[9];//6

                    ALLbazasInfo.Add(temp); //dodanie elementow do listy tymczawsowej
                }
                //temp = null;

            }
        }
       
        //############################################# CODE NEEDED FOR LOAD DATA END ###############################################################
        private void buttonNewJob_Click(object sender, EventArgs e)
        {
            
            if (Application.OpenForms.OfType<FormJobName>().Count() >= 1)
            {
                Global.FormJobNameADD1.Visible = true;
                Global.FormJobNameADD1.setLinuxRight();
                Global.FormJobNameADD1.Show();
                Global.FormJobNameADD1.Focus();
                Global.FormJobNameADD1.BringToFront();

            }

            // FormJobName FormJobNameForm = new FormJobName(); Nic nie slysze...
            Global.FormJobNameADD1.setLinuxRight();
            Global.FormJobNameADD1.Show();

        }


        public  List<ClassHistoryJobs> ListHistoryOfJobsFromFileBACK = new List<ClassHistoryJobs>(); //ALL

        public void ALLHistoryJobsLoadData(List<ClassHistoryJobs> ListHistoryOfJobsFromFile)
        {// Console.WriteLine("wchodze do historyJobs load data");
            try
            {
                Global.CantClick = true;
                
                //----PRZYGOTOWANIE Historii jobow----//
                var output = Global.connectionSession.RunCommand("cd .ServerFiles;cat HistoryJobs.txt");
                //Console.WriteLine(output.Result);
                //----- ZAPISANIE DANYCH Z PLIKU-----//
                string[] lines = (output.Result).Split('\n');

               
                ListHistoryOfJobsFromFile.Clear(); // przy odswiezaniu wazne by wyczywscic pprzedna tablice
                
                StringBuilder stdErr = new StringBuilder ("");
                StringBuilder stdOut = new StringBuilder("");
                StringBuilder path = new StringBuilder("");

                for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
                {
                    
                    var tempLine = lines[i].Split(';'); //tabliza znakow podzielenie na elementy po napotkaniu ;

                        ClassHistoryJobs temp = new ClassHistoryJobs();
                        // Console.WriteLine(tempLine[0]);
                        temp.JobID = Convert.ToInt32(tempLine[0]);

                        temp.JobName = tempLine[1];
                        //Console.WriteLine("job name: " + temp.JobName);
                        temp.DirectoryName = tempLine[2];
                   
                    if (tempLine[2] == "--") //if job added from terminal
                    {
                        temp.ErrorInfo = "--";
                        temp.StdOut = "--";

                        temp.DateOfSubmission = Convert.ToDateTime(tempLine[3]); //date
                        temp.Description = tempLine[4];
                    }
                    else
                    {
                        // Console.WriteLine("directory name: " + temp.DirectoryName);
                        //////create a location path

                        stdErr.Clear();
                        stdOut.Clear();
                        path.Clear();
                        
                        stdErr.Append("stderr-" + temp.JobName + ".txt");
                        stdOut.Append("stdout-" + temp.JobName + ".txt");
                        //stderr
                       
                        path.Append("/home/users/" + Global.user + "/" + temp.DirectoryName + "/" + stdErr);//to jest glowna roznica!!!!!!!!! PAMIEC
                        var output2 = Global.connectionSession.RunCommand("cat " + path + " | head -3"); //zapisanie wyniku z stderr
                        temp.ErrorInfo = output2.Result;
                        //stdout
                        
                        path.Clear();
                        path.Append("/home/users/" + Global.user + "/" + temp.DirectoryName + "/" + stdOut); //to jest glowna roznica!!!!!!!!! PAMIEC
                        output2 = Global.connectionSession.RunCommand("cat " + path + " | head -3");//zapisanie wyniku z stdout //jednak to jest TA PAMIEC CZYLI WYSYALIE KOMEDNY DO LINUXA I CZEKANIE NA ODBIOR OMG
                        
                        if (output2.Result == "")  //jesli stdout  puste daj puste jesli cos jest napisz data to znaczy ze jest ok
                        {
                            temp.StdOut = output2.Result;
                        }
                        else
                        {
                            temp.StdOut = "Data";
                        }
                        
                        temp.DateOfSubmission = Convert.ToDateTime(tempLine[3]); //date

                        temp.Description = tempLine[4];
                        //jesli wywale stdout to juz jest polowa mniejszego zuzyca????
                        //od tego miejsca w dol nie zmiena memory nic
                       
                        var directoryDeletedCheck = Global.connectionSession.RunCommand("[ ! -d \"" + temp.DirectoryName + "\" ] && echo \"No\" "); //if directory was deleted write a monit (-d directory)
                        var stdErrIST = Global.connectionSession.RunCommand("cd " + temp.DirectoryName + ";[ ! -f \"" + stdErr + "\" ] && echo \"No\" "); //if file was deleted write a monit (-f file)
                        var StdOutIST = Global.connectionSession.RunCommand("cd " + temp.DirectoryName + ";[ ! -f \"" + stdOut + "\" ] && echo \"No\" "); //if file was deleted write a monit
                        var checkFileToDelete = Global.connectionSession.RunCommand("cd " + temp.DirectoryName + ";[ -f \"check" + temp.JobName + ".txt\" ] && echo \"Yes\" "); //if check file to work if temp
                                                                                                                                                                                // var dddd= Global.connectionSession.RunCommand("pwd");
                        //Console.WriteLine(dddd.Result);
                        if (temp.ErrorInfo == "") //jelsli stderr nic nie ma zobacz czy sa pliki
                        {
                            if (checkFileToDelete.Result == "") //if checkfile is deleted this mean files from tmp are transported to our directory so we can chceck if there is any error
                            {
                                if (directoryDeletedCheck.Result != "")
                                {
                                    temp.ErrorInfo = "No folder with files";
                                }
                                else if (stdErrIST.Result != "")
                                    temp.ErrorInfo = "No stderr file";
                                else if (StdOutIST.Result != "")
                                    temp.ErrorInfo = "No stdout file";
                            }
                        }
                       
                        ListHistoryOfJobsFromFile.Add(temp);
                       
                    }
                }
                Global.CantClick = false;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("something happened, check the selected parameters " + ex.Message + "   ALLHistoryJobsLoadData ");
            }
        }

        

        public void MainHistoryJobsLoadData(List<ClassMainHistoryJobs> ListHistoryOfJobsFromFile)
        {
            try
            {

                //----PRZYGOTOWANIE Historii jobow----//
                var output = Global.connectionSession.RunCommand("cd .ServerFiles;cat HistoryJobsMainJob.txt");
                //Console.WriteLine(output.Result);
                //----- ZAPISANIE DANYCH Z PLIKU-----//
                string[] lines = (output.Result).Split('\n');

                ListHistoryOfJobsFromFile.Clear(); // przy odswiezaniu wazne by wyczywscic pprzedna tablice

                StringBuilder stdErr = new StringBuilder("");
                StringBuilder stdOut = new StringBuilder("");
                StringBuilder path = new StringBuilder("");

                for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
                {
                    var tempLine = lines[i].Split(';'); //tabliza znakow podzielenie na elementy po napotkaniu ;
                    ClassMainHistoryJobs temp = new ClassMainHistoryJobs();
                    // Console.WriteLine(tempLine[0]);
                    temp.JobName = tempLine[0];
                    temp.Tool = tempLine[1];
                    //Console.WriteLine("Job Name: " + tempLine[0]);

                    //temp.DirectoryName = tempLine[12];
                    //Console.WriteLine("Directory Name: " + tempLine[12]);
                    temp.TypeOfSpliting = tempLine[10];
                    //Console.WriteLine("Type of sploting: " + tempLine[10]);
                    temp.NumberOfParts = Convert.ToInt32(tempLine[11]);
                    //Console.WriteLine("Nr of parts: " + tempLine[11]);
                    temp.DateOfSubmission = Convert.ToDateTime(tempLine[13]); //date
                    //Console.WriteLine("data: " + tempLine[13]);
                    temp.Description = tempLine[14];
                    //Console.WriteLine("opis: " + tempLine[14]);
                    temp.Edit = "    X";
                  
                    ListHistoryOfJobsFromFile.Add(temp);

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("something happened, check the selected parameters" + ex.Message + "   MainHistoryJobsLoadData ");
            }
        }

        private void buttonHistory_Click(object sender, EventArgs e)
        {
            if (isReadyHistory)
            {

                if (Application.OpenForms.OfType<MainHistoryJobs>().Count() >= 1)
                {
                    Global.FormMainHistoryOfJobs.Focus();
                    Global.FormMainHistoryOfJobs.BringToFront();
                }
                else
                {
                    Global.FormMainHistoryOfJobs = new MainHistoryJobs();
                    Global.FormMainHistoryOfJobs.Show();
                    Global.FormMainHistoryOfJobs.LoadDataHistory(Global.ListMainHistoryOfJobsFromFile);
                }
            }
            else
            {
                MessageBox.Show("First History is loading...");
            }
        }

        private void Functions_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("You have been logged out");
            timer1.Stop();
            Global.connectionSession.Disconnect();

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            Environment.Exit(0);

        }

        public bool isJobInFile(string jobId)
        {
            foreach (var item in Global.ALLListHistoryOfJobsFromFile)
            {
                //Console.WriteLine(item.JobID);
                if (item.JobID == Convert.ToInt32(jobId))
                    return true;
            }
            return false;
        }


        public bool isJobFromProgramm(string jobId)
        {
            foreach (var item in Global.JobIDFromProgramm)
            {
                if (item == Convert.ToInt32(jobId))
                    return true;
            }
            return false;
        }

        public void checkTerminalJobs()
        {
            //squeue -O account,jobid,name,submittime,username |grep kgo

            var output = Global.connectionSession.RunCommand("squeue -o %A,%j,%V,%u | grep " + Global.user);
            //Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----//
            string[] lines = (output.Result).Split('\n');

           // HistoryJobsLoadData(Global.ListHistoryOfJobsFromFile); //odswiezenie listy

            for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                var tempLine = lines[i].Split(',');
                if (!isJobFromProgramm(tempLine[0])) //jelsi nie z progrmau 
                {
                   //Console.WriteLine("nie z programu " + tempLine[0]);
                    if (!isJobInFile(tempLine[0])) //jesli nie ma joba w pliku dodaj go
                    {

                            var timeFormat = tempLine[2].Replace("-", ",").Replace("T", ",").Replace(":", ",").Split(',');
                            DateTime dt2 = new DateTime(Convert.ToInt32(timeFormat[0]), Convert.ToInt32(timeFormat[1]), Convert.ToInt32(timeFormat[2]), Convert.ToInt32(timeFormat[3]), Convert.ToInt32(timeFormat[4]), Convert.ToInt32(timeFormat[5]));

                            string description = "Launched in the terminal";

                            string historyJobsAddItme = String.Format("echo \"{0};{2};--;{3};{4}\" >> /home/users/{1}/.ServerFiles/HistoryJobs.txt", tempLine[0], Global.user, tempLine[1], dt2, description);

                            Global.connectionSession.RunCommand(historyJobsAddItme);
                        
                    }
                }

            }
        }


        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            backgroundWorker2.WorkerSupportsCancellation = true; //chyba zbedne jak sie sypie to wlaczyc
            if (this.backgroundWorker2.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            if (!Global.HistoryEditMode) //if not edit mode refresh
            { //dodac boola do timera zeby odblokowal odswiezanie co jakis czas i potem znow je blokowal na minute

                //Console.WriteLine("zaczynam i znika");
                ALLHistoryJobsLoadData(ListHistoryOfJobsFromFileBACK);
                MainHistoryJobsLoadData(ListMainHistoryOfJobsFromFileBACK);
                // checkTerminalJobs();
                isReadyHistory = true; //for firs history load
            }
        }

        bool isReadyHistory = false;

        public  List<ClassMainHistoryJobs> ListMainHistoryOfJobsFromFileBACK = new List<ClassMainHistoryJobs>(); //ALL
        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                try
                {
                    if (!Global.HistoryEditMode) //if not edit mode refresh
                    {
                        Global.ALLListHistoryOfJobsFromFile = ListHistoryOfJobsFromFileBACK;
                        Global.ListMainHistoryOfJobsFromFile = ListMainHistoryOfJobsFromFileBACK;
                        lastUpdateHistroyTime = Global.LastUpdateTime;

                    }
                }
                catch
                {
                    MessageBox.Show("nowy form nowe problemy");
                }

                if (Application.OpenForms.OfType<MainHistoryJobs>().Count() >= 1)
                {
                    if (!Global.HistoryEditMode) //if not edit mode refresh
                    {
                        //Global.FormHistoryOfJobs.LoadDataHistoryJobName(Global.FormHistoryParamiter); //klikniete joby
                        Global.FormMainHistoryOfJobs.LoadDataHistory(Global.ListMainHistoryOfJobsFromFile);
                        lastUpdateHistroyTime = Global.LastUpdateTime;

                    }

                }

                if (Application.OpenForms.OfType<FormHistory>().Count() >= 1)
                {
                    if (!Global.HistoryEditMode) //if not edit mode refresh
                    {
                        //Global.FormHistoryOfJobs.LoadDataHistoryJobName(Global.FormHistoryParamiter); //klikniete joby
                        Global.FormHistoryOfJobs.LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, Global.FormHistoryParamiter);
                        lastUpdateHistroyTime = Global.LastUpdateTime;
                        
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show("Functions \nError substituting background data BACKGROUDNWARKER222" + ex.Message);
            }
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void button__Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            MessageBox.Show("You have been logged out");
            timer1.Stop();
            Global.connectionSession.Disconnect();

            if (backgroundWorker1.IsBusy)
                backgroundWorker1.CancelAsync();

            Environment.Exit(0);
        }

       
        private void panelControlLocation_Paint(object sender, PaintEventArgs e)
        {

        }


        // https://stackoverflow.com/questions/2575216/how-to-move-and-resize-a-form-without-a-border
        //RESIZE FORM LINUX
        int Mx;
        int My;
        int Sw;
        int Sh;

        bool mov;
        
        private void button1_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        private void button1_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void button1_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
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

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
