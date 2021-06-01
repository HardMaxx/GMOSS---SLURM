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
    public partial class MainHistoryJobs : Form
    {
        public MainHistoryJobs()
        {
            InitializeComponent();

            setLinuxRight();
            // dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.ColorDataGrid); // zmiana koloru domyslnie od razu

            if (Global.HistoryEditMode)
            {
                buttonEditMode.Text = "Edit Mode ON";
                labelLastUpdateSQUEUE.BackColor = Color.LightCoral;
                label1.Text = "Edit mode on means that the history is not refreshed and you can delete old jobs, cancel currently running jobs";
            }
            else
            {
                buttonEditMode.Text = "Edit Mode OFF";
                labelLastUpdateSQUEUE.BackColor = Color.LightGreen;
                label1.Text = "Edit mode off means that the history is refreshing and you can't delete old jobs, cancel currently running jobs";

            }


        }

        public void ColorDataGrid(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            ColorType colorek = new ColorType();


              //  dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.maint;// Color.Green;

                if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value) == ("P")) //error empty daat is ok
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.mixed;// Color.Green;
                }
                else if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value) == "NO SPLITING") //error
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.maint;// Color.Green;
            }
                else if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[2].Value) == ("S")) //in prgores
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.reserved;// Color.Green;
                }
            
        }


        public void LoadDataHistory(List<ClassMainHistoryJobs> ListHistory)
        {
            int saveRow = 0;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (dataGridView1.Rows.Count > 0 && dataGridView1.FirstDisplayedCell != null)
                    saveRow = dataGridView1.FirstDisplayedCell.RowIndex;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (dataGridView1.Rows.Count > 0)
                    saveRow = DatacScrollPosition(dataGridView1);
            }
            //save scroll end


            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.DataSource = ListHistory;

            setSortedData();

            //save scroll end
            labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                if (saveRow != 0 && saveRow < dataGridView1.Rows.Count)
                    dataGridView1.FirstDisplayedScrollingRowIndex = saveRow;
            }
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (saveRow != 0 && saveRow < dataGridView1.Rows.Count)
                {
                    dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                    dataGridView1.CurrentCell = dataGridView1.Rows[saveRow].Cells[0];
                    dataGridView1.CurrentCell = dataGridView1.Rows[saveRow].Cells[0];
                }
            }
            makeActualList(); //squeue robione by sprawdzic czy sa joby aktywne czy nie jest lista bo inaczej za akzdym razem zapytanie do bazy a to trudne obliczeniowo
            makeColorDatagridview();  // na podstawie jobow z squeue kolorowane sa wiersze
        }

        private int _previousIndex;
        private bool _sortDirection;

        private void dataGridView1_ColumnHeaderMouseClick_1(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // zmiana sorotwania ros/mal

            dataGridView1.DataSource = SortData(
                (List<ClassMainHistoryJobs>)dataGridView1.DataSource, dataGridView1.Columns[e.ColumnIndex].Name, _sortDirection);

            _previousIndex = e.ColumnIndex;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //to reset scroll to default position after click sort
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
            makeColorDatagridview();  // na podstawie jobow z squeue kolorowane sa wiersze
        }


        private List<ClassMainHistoryJobs> SortData(List<ClassMainHistoryJobs> list, string column, bool ascending)
        {
            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }

        private void setSortedData()
        {
            dataGridView1.DataSource = SortData(
            (List<ClassMainHistoryJobs>)dataGridView1.DataSource, dataGridView1.Columns[_previousIndex].Name, _sortDirection);
        }

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

        public string setGoodIndex(int index)
        {
            string numberGood = "";
            if (index < 10)
            {
                numberGood = "00" + index;
            }
            else if (index > 9 && index < 100)
            {
                numberGood = "0" + index;
            }
            else
            {
                numberGood = index.ToString();
            }

            return numberGood;
        }

        
        List<string> listStringTmp = new List<string>();
        void makeActualList() // lista pozwala wyknac raz zapytanie do bazy  zamiast za kazdym razem do kazdej lini co powoduje szybsze obliczenia
        {
            listStringTmp.Clear();
            var output = Global.connectionSession.RunCommand("squeue -o %A,%j,%V,%u | grep " + Global.user);
            //Console.WriteLine(output.Result);
            //----- ZAPISANIE DANYCH Z PLIKU-----//
            string[] lines = (output.Result).Split('\n');

            for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
            {
                var tempLine = lines[i].Split(',');
                listStringTmp.Add(tempLine[1]); //dodawanie tylko jobname do listy
            }
        }

        public bool checkColorToMainJob(List<string> listStringTmp,string jobName, string nrOfParts)
        {

            for (int i = 0; i < listStringTmp.Count()-1; i++) //-1 bo wyjdze bo za zakres // przechodiz po job name z squque ostatniego malego
            {

                    if (listStringTmp[i].Contains(jobName)) // zawezenie przegladania jesli linia z dzialajacych zawiera name joba z main
                    {
                        for (int index = 1; index < (Convert.ToInt32(nrOfParts)) + 1; index++)
                        {
                            string namex = jobName + "-" + setGoodIndex(index);
                            if (listStringTmp[i] == namex) //jesli job name odpowiada job name z squeue to znaczy ze job jest aktywny wiec szary bo jeszcze pracuje
                            {
                                //Console.WriteLine(namex);
                                //szary
                                return true;
                            }
                        }
                    }
                
            }
            //zieolny
            return false; // nie ma joba w squeue wiec zielony niewazne czy udane cyz nie
        }

        void makeColorDatagridview()
        {
            
            ColorType colorek = new ColorType();

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                //Console.WriteLine(dataGridView1.Rows[i].Cells[1].Value.ToString());
                if (checkColorToMainJob(listStringTmp, dataGridView1.Rows[i].Cells[1].Value.ToString(), dataGridView1.Rows[i].Cells[3].Value.ToString()))
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = colorek.reserved;

                }
                else
                {
                    dataGridView1.Rows[i].DefaultCellStyle.BackColor = colorek.idle;

                }
            }
           
        }

        public void FileUploadSFTP()
        {
            var port = 22;

            Global.connectionSession.RunCommand("cd .ServerFiles/ ; cp HistoryJobsMainJob.txt HistoryJobsMainJobLastCopy.txt"); //kopia historii
            Global.connectionSession.RunCommand("cd .ServerFiles/ ; rm HistoryJobsMainJob.txt"); //delete aktualnego pliku zhistoria by zastapix go nowym
            // path for file you want to upload
            var uploadFile = @"HistoryJobsMainJob.txt";
            string workingdirectory = "/home/users/" + Global.user + "/.ServerFiles/";
            using (var client = new SftpClient(Global.host, port, Global.user, Global.pass))
            {
                client.Connect();
                if (client.IsConnected)
                {
                    // Debug.WriteLine("I'm connected to the client");
                    client.ChangeDirectory(workingdirectory);
                    using (var fileStream = new FileStream(uploadFile, FileMode.Open))
                    {

                        client.BufferSize = 4 * 1024; // bypass Payload error large files
                        client.UploadFile(fileStream, Path.GetFileName(uploadFile));
                    }
                }
                else
                {
                    Debug.WriteLine("I couldn't connect");
                }
            }
            Global.connectionSession.RunCommand("dos2unix /home/users/" + Global.user + "/.ServerFiles/HistoryJobsMainJob.txt");//to convert file from windows format to linux after delete and move to linux from windows
        }

        List<ClassHistoryJobs> ListHistoryTMP = new List<ClassHistoryJobs>();
        public void LoadTMpFilesList(List<ClassHistoryJobs> ListHistory, string jobName)
        {
            ListHistory.Clear();

            foreach (var ele in Global.ALLListHistoryOfJobsFromFile)
            {
                if (ele.JobName.StartsWith(jobName) && ele.JobName.Contains(jobName))
                {
                    ClassHistoryJobs temp = new ClassHistoryJobs();
                    temp.JobID = ele.JobID;
                    temp.JobName = ele.JobName;
                    temp.DirectoryName = ele.DirectoryName;
                    temp.ErrorInfo = ele.ErrorInfo;
                    temp.StdOut = ele.StdOut;
                    temp.DateOfSubmission = ele.DateOfSubmission;
                    temp.Description = ele.Description;

                    ListHistory.Add(temp);
                }

            }
        }

        private string getDirectoryName(string JobName)
        {
            foreach (var ele in ListHistoryTMP)
            {
                if (ele.JobName == JobName)
                    return ele.DirectoryName;
            }
            return "nicxDDDDD";

        }
        private int getJobID(string JobName)
        {
            foreach (var ele in ListHistoryTMP)
            {
                if (ele.JobName == JobName)
                    return ele.JobID;
            }
            return 1;

        }

      
        private void buttonCancelJobs_Click_1(object sender, EventArgs e)
        {
            if (Global.HistoryEditMode)
            {

                if (dataGridView1.SelectedRows.Count > 0) //jelsi cos zaznacozne
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to stop this jobs?", "Stop Jobs", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Stopping task, please wait...");
                        messageBoxInfo.Show();

                        foreach (DataGridViewRow drv in dataGridView1.SelectedRows)
                        {//przechodzi po calym datagridview
                         //                    {
                            string mainJobName = (string)drv.Cells[1].Value;
                            int nrOfParts = (int)drv.Cells[3].Value;
                            LoadTMpFilesList(ListHistoryTMP, mainJobName);
                            for (int i = 1; i < nrOfParts + 1; i++)
                            {
                                string JobName = mainJobName + "-" + setGoodIndex(i);
                                // Console.WriteLine("wywalamy joba o nazwie: " + JobName);
                                Global.connectionSession.RunCommand("scancel " + getJobID(JobName)); //canselowanie jesli  jest aktywne jeszcze

                            }
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
                    MessageBox.Show("You must select jobs to stop");
                }
            }
            else
            {
                MessageBox.Show("You must enter edit mode to Delete jobs");
            }
        }


        private void DeleteJobFromFileAndDataGiordview(string JobName)
        {


            var valueOfHistroyOfJobs = Global.connectionSession.RunCommand("cd .ServerFiles/ ; sed -i '/" + JobName + "/d' ./HistoryJobs.txt");

            var LineDataGridView = Global.ALLListHistoryOfJobsFromFile.Find(d => d.JobName == JobName);

            string stderr = "stderr-" + JobName + "*.txt";
            string stdout = "stdout-" + JobName + "*.txt";
           // Console.WriteLine(getDirectoryName(JobName));
            //Console.WriteLine(LineDataGridView.ToString());
            Global.connectionSession.RunCommand("cd " + getDirectoryName(JobName) + "; rm " + stderr + "; rm " + stdout); //walanie starego error i stdout
            Global.connectionSession.RunCommand("cd //;cd tmp/lustre_shared/" + Global.user + "/" + getDirectoryName(JobName) + "; rm " + stderr + "; rm " + stdout); //walanie starego error i stdout

            Global.connectionSession.RunCommand("scancel " + getJobID(JobName)); //canselowanie jesli  jest aktywne jeszcze
            try
            {
                Global.ALLListHistoryOfJobsFromFile.Remove(Global.ALLListHistoryOfJobsFromFile.Find(d => d.JobName == JobName));
            }
            catch
            {
                Console.WriteLine("brak tego joba: " + JobName);
            }
        }



        private void buttonCancelJobs_Click(object sender, EventArgs e)
        {

            if (Global.HistoryEditMode)
            {

                if (dataGridView1.SelectedRows.Count > 0) //jelsi cos zaznacozne
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this jobs?", "Delete Jobs", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Deleting task from history, please wait...");
                        messageBoxInfo.Show();

                        foreach (DataGridViewRow drv in dataGridView1.SelectedRows)
                        {//przechodzi po calym datagridview
                         //                    {
                            string mainJobName = (string)drv.Cells[1].Value;
                            int nrOfParts = (int)drv.Cells[3].Value;
                            LoadTMpFilesList(ListHistoryTMP, mainJobName);
                            for (int i = 1; i < nrOfParts + 1; i++)
                            {
                                string JobName = mainJobName +"-"+ setGoodIndex(i);
                               // Console.WriteLine("wywalamy joba o nazwie: " + JobName);
                                DeleteJobFromFileAndDataGiordview(JobName);

                                if (i == 1)
                                {
                                    //drv.Cells[2].Value;
                                    DeleteJobFromFileAndDataGiordview(mainJobName + "-"+(string)drv.Cells[2].Value); //wywalenie splitowania
                                    Global.connectionSession.RunCommand("cd .ServerFiles/ ; sed -i '/" + mainJobName + "-Indexing/d' ./HistoryJobs.txt");
                                    //Console.WriteLine("wywalamy joba o nazwie: " + mainJobName + "-" + (string)drv.Cells[2].Value);
                                }
                            }

                            //DeleteJobFromFileAndDataGiordview(mainJobName+ "-Indexing"); //wywalenie indexowania
                           // Console.WriteLine("wywalamy joba o nazwie: " + mainJobName + "-Indexing");
                            // Global.FormHistoryOfJobs.LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, Global.FormHistoryParamiter); //pu usunieciu wszytsich podjobow odswiez h
                            //usuwanie main joba

                            var valueOfHistroyOfJobs = Global.connectionSession.RunCommand("cd .ServerFiles/ ; sed -i '/" + mainJobName + "/d' ./HistoryJobsMainJob.txt");

                            Global.ListMainHistoryOfJobsFromFile.Remove(Global.ListMainHistoryOfJobsFromFile.Find(d => d.JobName == mainJobName));
                            LoadDataHistory(Global.ListMainHistoryOfJobsFromFile);
                            //Console.WriteLine("wywalamy main joba o nazwie: " + mainJobName);
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
                    MessageBox.Show("You must select jobs to delete");
                }
            }
            else
            {
                MessageBox.Show("You must enter edit mode to Delete jobs");
            }
        }


        private void MainHistoryJobs_Load(object sender, EventArgs e)
        {

        }


        private int LineWithData(string JobName)
        {
            for(int i=0; i< Global.ListMainHistoryOfJobsFromFile.Count(); i++)
            {
                if (Global.ListMainHistoryOfJobsFromFile[i].JobName == JobName)
                    return i;
            }
            return 0;
        }

       



        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void buttonEditMode_Click(object sender, EventArgs e)
        {

            if (buttonEditMode.Text == "Edit Mode OFF")
            {
                Global.HistoryEditMode = true;
                buttonEditMode.Text = "Edit Mode ON";
                labelLastUpdateSQUEUE.BackColor = Color.LightCoral;
            }
            else if (buttonEditMode.Text == "Edit Mode ON")
            {
                Global.HistoryEditMode = false;
                buttonEditMode.Text = "Edit Mode OFF";
                labelLastUpdateSQUEUE.BackColor = Color.LightGreen;
            }
        }

        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Main History of Jobs";
                //buttonResetDatagridView.Visible = false;
            }
            else
            {
                //buttonResetDatagridView.Visible = false;
                panelBorderStyle.Visible = false;
                buttonResize.Visible = false;
                // this.panelControlLocation.Location = new Point(0, 0);
            }
        }

        private void button__Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonM_Click(object sender, EventArgs e)
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

        // https://stackoverflow.com/questions/2575216/how-to-move-and-resize-a-form-without-a-border
        //RESIZE FORM LINUX
        int Mx;
        int My;
        int Sw;
        int Sh;

        bool mov;

        private void buttonResize_MouseDown(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        private void buttonResize_MouseMove(object sender, MouseEventArgs e)
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void buttonResize_MouseUp(object sender, MouseEventArgs e)
        {
            mov = false;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Global.ListMainHistoryOfJobsFromFile.Count >= 1)
            {
                int nrColumn = dataGridView1.CurrentCell.ColumnIndex;
                string name = dataGridView1.Columns[nrColumn].Name;
                //Console.WriteLine(name);
                if (name == "JobName")
                {
                    if (Global.CantClick)
                    {

                        string smallJob = dataGridView1.SelectedCells[0].Value.ToString();

                        if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "NO SPLITING")
                        {
                            smallJob = dataGridView1.SelectedCells[0].Value.ToString() + "-";
                            //Console.WriteLine("Smal po  podstawce: " + smallJob);
                            //Console.WriteLine("type z podstawki: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        }
                        //Console.WriteLine("Smal: " + smallJob);
                        if (Application.OpenForms.OfType<FormHistory>().Count() >= 1)
                        {
                            //nowe

                            Global.FormHistoryParamiter = smallJob;

                            //Global.FormHistoryOfJobs.LoadDataHistoryJobName(dataGridView1.SelectedCells[0].Value.ToString());
                            Global.FormHistoryOfJobs.LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, smallJob);
                            //Console.WriteLine("ladowanie loaddaata 22222");
                            Global.FormHistoryOfJobs.Focus();
                            Global.FormHistoryOfJobs.BringToFront();


                        }
                        else
                        {
                            Global.FormHistoryOfJobs = new FormHistory(smallJob);
                            Global.FormHistoryParamiter = smallJob;
                            Global.FormHistoryOfJobs.Show();
                        }
                    }
                    else
                    {

                        string smallJob = dataGridView1.SelectedCells[0].Value.ToString();

                        if (dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() != "NO SPLITING")
                        {
                            smallJob = dataGridView1.SelectedCells[0].Value.ToString() + "-";
                            //Console.WriteLine("Smal po  podstawce: " + smallJob);
                            //Console.WriteLine("type z podstawki: " + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
                        }
                        //Console.WriteLine("Smal: " + smallJob);
                        if (Application.OpenForms.OfType<FormHistory>().Count() >= 1)
                        {
                            //nowe

                            Global.FormHistoryParamiter = smallJob;

                            //Global.FormHistoryOfJobs.LoadDataHistoryJobName(dataGridView1.SelectedCells[0].Value.ToString());
                            Global.FormHistoryOfJobs.LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, smallJob);
                            // Console.WriteLine("ladowanie loaddaata 111111");
                            Global.FormHistoryOfJobs.Focus();
                            Global.FormHistoryOfJobs.BringToFront();


                        }
                        else
                        {
                            Global.FormHistoryOfJobs = new FormHistory(smallJob);
                            Global.FormHistoryParamiter = smallJob;
                            Global.FormHistoryOfJobs.Show();
                        }
                    }

                }
                if (name == "Edit")
                {
                    string JobName = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                    int rowNumber = LineWithData(JobName);

                    var output = Global.connectionSession.RunCommand("cd .ServerFiles;cat HistoryJobsMainJob.txt");
                    //Console.WriteLine(output.Result);
                    //----- ZAPISANIE DANYCH Z PLIKU-----//
                    string[] lines = (output.Result).Split('\n');

                    for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres
                    {

                        var tempLine = lines[i].Split(';'); //tabliza znakow podzielenie na elementy po napotkaniu ;

                        if (JobName == tempLine[0])
                        {
                            bool splited = false;
                            //wez dane z lini i wczytaj okno
                            if (Application.OpenForms.OfType<FormDirectoryRunJob>().Count() >= 1)
                            {
                                if (tempLine[10] == "P" || tempLine[10] == "S")
                                    splited = true;
                                Global.FormNewJobADD4.setDataToJobReRun(tempLine[0], tempLine[14], tempLine[1], tempLine[2], tempLine[3], tempLine[4], tempLine[5], tempLine[6], tempLine[7], tempLine[8], tempLine[16],
                                    tempLine[11], tempLine[9], splited, tempLine[10], tempLine[12], tempLine[17], tempLine[18], tempLine[19], tempLine[20]);
                                Global.FormNewJobADD4.Visible = true;
                                Global.FormNewJobADD4.Focus();
                                Global.FormNewJobADD4.BringToFront();
                                // this.Visible = false;Global.splitQueryMultiplyJobs
                                break;
                            }
                            else
                            {
                                if (tempLine[10] == "P" || tempLine[10] == "S")
                                    splited = true;
                                Global.FormNewJobADD4.setDataToJobReRun(tempLine[0], tempLine[14], tempLine[1], tempLine[2], tempLine[3], tempLine[4], tempLine[5], tempLine[6], tempLine[7], tempLine[8], tempLine[16],
                                    tempLine[11], tempLine[9], splited, tempLine[10], tempLine[12], tempLine[17], tempLine[18], tempLine[19], tempLine[20]);
                                // this.Visible = false;
                                Global.FormNewJobADD4.Show();
                                break;
                            }


                        }
                    }

                }
            }
        }


        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM END ###############################################################
    }
}
