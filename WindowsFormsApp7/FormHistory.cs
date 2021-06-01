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
    public partial class FormHistory : Form
    {
        public FormHistory(string JobName)
        {
            InitializeComponent();
            // LoadDataHistoryJobName(JobName);

            setLinuxRight();

            LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, JobName);


            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.ColorDataGrid); // zmiana koloru domyslnie od razu

        }


        public void LoadDataHistory(List<ClassHistoryJobs> ListHistory, string jobName)
        {

            if (Global.CantClick)
            {
                panel1.Visible = true;
            }
            else
            {
                panel1.Visible = false;

            }
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

            //// odswiezanie listy
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
            // odswiezanie listy

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
        }

        private void FormHistory_Load(object sender, EventArgs e)
        {

        }


        private int _previousIndex;
        private bool _sortDirection;

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // zmiana sorotwania ros/mal

            dataGridView1.DataSource = SortData(
                (List<ClassHistoryJobs>)dataGridView1.DataSource, dataGridView1.Columns[e.ColumnIndex].Name, _sortDirection);

            _previousIndex = e.ColumnIndex;

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //to reset scroll to default position after click sort
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private List<ClassHistoryJobs> SortData(List<ClassHistoryJobs> list, string column, bool ascending)
        {
            return ascending ?
                list.OrderBy(_ => _.GetType().GetProperty(column).GetValue(_)).ToList() :
                list.OrderByDescending(_ => _.GetType().GetProperty(column).GetValue(_)).ToList();
        }

        private void setSortedData()
        {
            dataGridView1.DataSource = SortData(
            (List<ClassHistoryJobs>)dataGridView1.DataSource, dataGridView1.Columns[_previousIndex].Name, _sortDirection);
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


        public void ColorDataGrid(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            ColorType colorek = new ColorType();

            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[6].Value) == ("Launched in the terminal")) 
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.maint;// Color.Green;
            }
            else
            {
                if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value) == ("Data") && Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == ("")) //error empty daat is ok
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.idle;// Color.Green;
                }
                if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value) != "") //error
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.error_fail;// Color.Green;
                }
                else if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[3].Value) == ("") && Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value) != ("Data")) //in prgores
                {
                    dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.reserved;// Color.Green;
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       

        private void buttonEditMode_Click(object sender, EventArgs e)
        {

        }

        public void FileUploadSFTP()
        {
            var port = 22;

            Global.connectionSession.RunCommand("cd .ServerFiles/ ; cp HistoryJobs.txt HistoryJobsLastCopy.txt"); //kopia historii
            Global.connectionSession.RunCommand("cd .ServerFiles/ ; rm HistoryJobs.txt"); //delete aktualnego pliku zhistoria by zastapix go nowym
            // path for file you want to upload
            var uploadFile = @"HistoryJobs.txt";
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
            Global.connectionSession.RunCommand("dos2unix /home/users/" + Global.user + "/.ServerFiles/HistoryJobs.txt");//to convert file from windows format to linux after delete and move to linux from windows
        }

        private void DeleteDataHistory_Click(object sender, EventArgs e)
        {
            if (Global.HistoryEditMode)
            {

                if (dataGridView1.SelectedRows.Count > 0) //jelsi cos zaznacozne
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this data from history? You will not be able to recover them", "Delete data", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Deleting task from history, please wait...");
                        messageBoxInfo.Show();

                        var valueOfHistroyOfJobs = Global.connectionSession.RunCommand("cd .ServerFiles/ ;cat HistoryJobs.txt");

                        string[] lines = (valueOfHistroyOfJobs.Result).Split('\n');

                        List<string> dataHistory = new List<string>();

                        // bool outRow= false;
                        for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres   po pliku historii z servera
                        {
                            bool outRow = false;
                            foreach (DataGridViewRow drv in dataGridView1.SelectedRows)//przechodzi po calym datagridview
                            {

                                if (lines[i].Contains(drv.Cells[0].Value.ToString())) //jesli linia z pliku zawera idjoba z wybranego to wywal go z listy datagridview
                                {
                                    var val = (int)drv.Cells[0].Value;
                                    Global.ALLListHistoryOfJobsFromFile.Remove(Global.ALLListHistoryOfJobsFromFile.Find(d => d.JobID == val));
                                    //Console.WriteLine("wywalamy: " + lines[i]);
                                    Global.JobIDFromProgramm.Add(val);
                                    Global.connectionSession.RunCommand("scancel " + val);

                                    outRow = true;
                                    break;
                                }
                            }
                            if (!outRow)
                            {
                                dataHistory.Add(lines[i]);
                                //Console.WriteLine("Zostaje: " + lines[i]);
                            }
                        }


                        //zapis pliku lokalnie by potem go podmienic na server

                        TextWriter tw = new StreamWriter("HistoryJobs.txt");

                        foreach (var line in dataHistory)
                        {
                            tw.WriteLine(line.TrimStart().Replace("\n", Environment.NewLine).Replace("\r", Environment.NewLine)); //wywalic linie dodatkowa
                        }

                        tw.Close();
                        FileUploadSFTP();
                        LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, Global.FormHistoryParamiter);
                        messageBoxInfo.Close();
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("You must select lines to delete");
                }
            }
            else
            {
                MessageBox.Show("You must enter edit mode to delete stories, turn on edit mode in history");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }


        private void buttonCancelJobs_Click_1(object sender, EventArgs e)
        {
            if (Global.HistoryEditMode)
            {

                foreach (DataGridViewRow drv in dataGridView1.SelectedRows)//przechodzi po calym datagridview
                {
                    //Console.WriteLine(drv.Cells[3].Value.ToString() +"|"+ drv.Cells[4].Value.ToString());
                    if ((drv.Cells[3].Value.ToString() != "" || drv.Cells[4].Value.ToString() != "") && drv.Cells[6].Value.ToString() != "Launched in the terminal")
                    {
                        MessageBox.Show("You can't cancel this jobs, some of the selected jobs are not active");
                        return;
                    }
                }



                if (dataGridView1.SelectedRows.Count > 0) //jelsi cos zaznacozne
                {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to cancel this jobs?", "Cancel Jobs", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        MessageBoxInfo messageBoxInfo = new MessageBoxInfo("Interrupting selected tasks, please wait...");
                        messageBoxInfo.Show();

                        var valueOfHistroyOfJobs = Global.connectionSession.RunCommand("cd .ServerFiles/ ;cat HistoryJobs.txt");

                        string[] lines = (valueOfHistroyOfJobs.Result).Split('\n');

                        List<string> dataHistory = new List<string>();

                        // bool outRow= false;
                        for (int i = 0; i < lines.Length - 1; i++) //-1 bo wyjdze bo za zakres   po pliku historii z servera
                        {
                            bool outRow = false;
                            foreach (DataGridViewRow drv in dataGridView1.SelectedRows)//przechodzi po calym datagridview
                            {

                                if (lines[i].Contains(drv.Cells[0].Value.ToString())) //jesli linia z pliku zawera idjoba z wybranego to wywal go z listy datagridview
                                {
                                    var val = (int)drv.Cells[0].Value;
                                    // Global.ALLListHistoryOfJobsFromFile.Remove(Global.ALLListHistoryOfJobsFromFile.Find(d => d.JobID == val));
                                    // Console.WriteLine("wywalamy: " + lines[i]);
                                    // Console.WriteLine("id " + val);
                                    Global.JobIDFromProgramm.Add(val);
                                    Global.connectionSession.RunCommand("scancel " + val);
                                    // Console.WriteLine(drv.Cells[1].Value);
                                    //Console.WriteLine(drv.Cells[2].Value);
                                    string deleteCheckFile = ("rm /home/users/" + Global.user + "/" + drv.Cells[2].Value + "check" + drv.Cells[1].Value + ".txt");
                                    Global.connectionSession.RunCommand(deleteCheckFile); //delete a check file if canceled
                                    outRow = true;
                                    break;
                                }
                            }
                        }

                        LoadDataHistory(Global.ClickedTMPListHistoryOfJobs, Global.FormHistoryParamiter);

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
                MessageBox.Show("You must enter edit mode to cancel jobs");
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
                labelFormName.Text = "History of Jobs";
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

        private void buttonX_Click_1(object sender, EventArgs e)
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
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                ReRunForm formReRun = new ReRunForm(row.Cells["JobName"].Value.ToString(), row.Cells["DirectoryName"].Value.ToString(), Convert.ToInt32(row.Cells["JobID"].Value));
                formReRun.ShowDialog();
            }
        }


        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM END ###############################################################
    }
}
