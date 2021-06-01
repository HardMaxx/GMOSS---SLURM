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


// blad linikia 70 contain moze byc ten sam problem co jest masa ifow i to tych glupich
namespace WindowsFormsApp7
{
    public partial class SqueuePartition : Form
    {
        public List<sQueue> bazasQueue = new List<sQueue>(); // small // zawiera dane z ostatniego kliknietego z lilisty partition

        public SqueuePartition(string partitionName)
        {
            InitializeComponent();

            setLinuxRight();

            labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
            bazasQueue.Clear();
            loadDataBaseSqueu(partitionName, Global.ALLbazasQueue);

            checkBoxSetChecked();

            dataGridView3.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.changeColorSQUEUE); // zmiana koloru domyslnie od razu
        }

        private void queuePartitionSqueue_Load(object sender, EventArgs e)
        {

        }

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

        public void loadDataBaseSqueu(string partitionName, List <sQueue> allBaza)
        {
            try
            {
                ///////////////////---------to save a selected state before refresh---------/////////////
                ///
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

                //save scroll start
                labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
            int saveRow = 0;
            //save scroll start
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

            //MessageBox.Show(saveRow.ToString());

            int total = 0;
            int run = 0;
            int pending = 0;
            int comleti = 0;
            int configure = 0;
            
            bazasQueue.Clear();
            dataGridView3.DataSource = null;
            dataGridView3.Rows.Clear();
            //dataGridView3.Refresh();
            
                foreach (var row in allBaza)
                {
                    int result = row.Partition.Zip(partitionName, (x, y) => x == y).Count(z => !z) + Math.Abs(row.Partition.Length - partitionName.Length); // z racji ze jest standard a w sinfo jest standard* liczenie roznicy miedzy stringami
                    sQueue temp = new sQueue();
                    int dlNazwy = partitionName.Length;
                    int dlNazwyRow = row.Partition.Length;
                    if (partitionName == row.Partition)
                    //if (partitionName.Contains(row.Partition))
                    // if(row.Partition.StartsWith(row.Partition) && (partitionName.Contains(row.Partition)))
                    {
                        //MessageBox.Show("zero");
                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueue.Add(temp);
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
                    else if (partitionName.StartsWith(row.Partition) && result < 2)
                    //if (partitionName.Contains(row.Partition))
                    // if(row.Partition.StartsWith(row.Partition) && (partitionName.Contains(row.Partition)))
                    {
                        // MessageBox.Show("jeden");
                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueue.Add(temp);
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
                    else if (partitionName.Contains(row.Partition) && partitionName.StartsWith(row.Partition) && result < 3)
                    {
                        //  MessageBox.Show(partitionName);
                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueue.Add(temp);
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
                    else if (partitionName.Contains(row.Partition) && partitionName.StartsWith(row.Partition) && result == 3) //biology_fast
                    {
                        //MessageBox.Show("22");
                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueue.Add(temp);
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
                    // if (partitionName.StartsWith(row.Partition) && result < 2)

                    else if (partitionName.Contains(row.Partition) && partitionName.StartsWith(row.Partition) && (result == 6 || result == 5) && dlNazwy > 10 && dlNazwyRow > 8)
                    {
                        // MessageBox.Show("3");
                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueue.Add(temp);
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
                    else if (partitionName.Contains(row.Partition) && partitionName.StartsWith(row.Partition) && (result == 4) && dlNazwy > 10 && dlNazwyRow > 8)
                    {
                        // MessageBox.Show("3");
                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueue.Add(temp);
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
                    else if (partitionName.Contains(row.Partition) && partitionName.StartsWith(row.Partition) && (result == 7) && dlNazwy > 10 && dlNazwyRow > 8)
                    {
                        // MessageBox.Show("3");
                        temp.Job = row.Job;
                        temp.Partition = row.Partition;
                        temp.Name = row.Name;
                        temp.User = row.User;
                        temp.State = row.State;
                        temp.Time = row.Time;
                        temp.TimeLimit = row.TimeLimit;
                        temp.Nodes = row.Nodes;
                        temp.Nodelist = row.Nodelist;
                        bazasQueue.Add(temp);
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
                
                dataGridView3.DataSource = bazasQueue; // przypisanie bazy do gridview
                
                labelPendingJobsU.Text = "Pending Jobs: " + pending;
                labelRunningJobsU.Text = "Running Jobs: " + run;
                labelTotalJobsU.Text = "Total Jobs: " + total;
                labelCompleteJobsU.Text = "Complete Jobs: " + comleti;
                labelConfigureJobsU.Text = "Configure Jobs: " + configure;
                setSortedData();
                setSelectedData();


                ///////////////////---------recover selected rows after refresh---------/////////////
                if (setSelectYES)
                {
                    this.dataGridView3.CurrentCell = this.dataGridView3[col1, row1]; // zapis nr wiersza

                    for (int t = 0; t < dataGridView3.ColumnCount; t++) //zaznaczeniw calego wiersza
                    {
                        this.dataGridView3[t, row1].Selected = true;
                    }
                }
                ///////////////////-----------------------------------------------------/////////////


                labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
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
                }

                //save scroll end

            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("sQueuePartitionSqueue selected warning etc" + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("queuePartitionSqueue \nLoad Data Refresh \n" + ex.Message);
            }

        }

        private void setSortedData()
        {
            dataGridView3.DataSource = SortData(
            (List<sQueue>)dataGridView3.DataSource, dataGridView3.Columns[_previousIndex].Name, _sortDirection);
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //if (bazasQueue.Count >= 1)
            //{
            //    int nrColumn = dataGridView3.CurrentCell.ColumnIndex;
            //    string name = dataGridView3.Columns[nrColumn].Name;
            //    if (name == "User")
            //    {

            //        //if (Application.OpenForms.OfType<Functions>().Count() == 1)
            //        //    Application.OpenForms.OfType<Functions>().First().Close();


            //        //Functions Functions = new Functions(dataGridView3.SelectedCells[0].Value.ToString());
            //        Global.FunctionsNameUserParamiter = dataGridView3.SelectedCells[0].Value.ToString();
            //        Global.actualUserNameFunction = false;
                    
            //        //Functions.Focus();
            //        //Functions.Show();

            //    }
            //}
        }


        public void checkBoxSetChecked()
        {
            checkBoxName.Checked = true;
            checkBoxPartition.Checked = true;
            checkBoxJob.Checked = true;
            checkBoxUser.Checked = true;
            checkBoxState.Checked = true;
            checkBoxTime.Checked = true;
            checkBoxTimeLimit.Checked = true;
            checkBoxNodes.Checked = true;
            checkBoxNodeList.Checked = true;
        }



        private void checkBoxJob_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxName.Checked)
                dataGridView3.Columns[0].Visible = true;
            else
                dataGridView3.Columns[0].Visible = false;
            checkSelectedData();
        }

        private void checkBoxPartition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPartition.Checked)
                dataGridView3.Columns[8].Visible = true;
            else
                dataGridView3.Columns[8].Visible = false;
            checkSelectedData();
        }

        private void checkBoxName_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxJob.Checked)
                dataGridView3.Columns[1].Visible = true;
            else
                dataGridView3.Columns[1].Visible = false;
            checkSelectedData();
        }

        private void checkBoxUser_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxUser.Checked)
                dataGridView3.Columns[2].Visible = true;
            else
                dataGridView3.Columns[2].Visible = false;
            checkSelectedData();
        }

        private void checkBoxState_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxState.Checked)
                dataGridView3.Columns[3].Visible = true;
            else
                dataGridView3.Columns[3].Visible = false;
            checkSelectedData();
        }

        private void checkBoxTime_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTime.Checked)
                dataGridView3.Columns[4].Visible = true;
            else
                dataGridView3.Columns[4].Visible = false;
            checkSelectedData();

        }

        private void checkBoxTimeLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTimeLimit.Checked)
                dataGridView3.Columns[5].Visible = true;
            else
                dataGridView3.Columns[5].Visible = false;
            checkSelectedData();
        }

        private void checkBoxNodes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNodes.Checked)
                dataGridView3.Columns[6].Visible = true;
            else
                dataGridView3.Columns[6].Visible = false;
            checkSelectedData();
        }

        private void checkBoxNodeList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNodeList.Checked)
                dataGridView3.Columns[7].Visible = true;
            else
                dataGridView3.Columns[7].Visible = false;
            checkSelectedData();
        }

        private int _previousIndex;
        private bool _sortDirection;

        private void dataGridView3_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
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

        private  List<sQueue> SortData(List<sQueue> list, string column, bool ascending)
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
                dataGridView3.Columns[0].Visible = true;
            }
            else
            {
                checkBoxName.Checked = false;
                dataGridView3.Columns[0].Visible = false;
            }
            if (selectedData[8])
            {
                checkBoxPartition.Checked = true;
                dataGridView3.Columns[8].Visible = true;
            }
            else
            {
                checkBoxPartition.Checked = false;
                dataGridView3.Columns[8].Visible = false;
            }
            if (selectedData[1])
            {
                checkBoxJob.Checked = true;
                dataGridView3.Columns[1].Visible = true;
            }
            else
            {
                checkBoxJob.Checked = false;
                dataGridView3.Columns[1].Visible = false;
            }
            if (selectedData[2])
            {
                checkBoxUser.Checked = true;
                dataGridView3.Columns[2].Visible = true;
            }
            else
            {
                checkBoxUser.Checked = false;
                dataGridView3.Columns[2].Visible = false;
            }
            if (selectedData[3])
            {
                checkBoxState.Checked = true;
                dataGridView3.Columns[3].Visible = true;
            }
            else
            {
                checkBoxState.Checked = false;
                dataGridView3.Columns[3].Visible = false;
            }
            if (selectedData[4])
            {
                checkBoxTime.Checked = true;
                dataGridView3.Columns[4].Visible = true;
            }
            else
            {
                checkBoxTime.Checked = false;
                dataGridView3.Columns[4].Visible = false;
            }
            if (selectedData[5])
            {
                checkBoxTimeLimit.Checked = true;
                dataGridView3.Columns[5].Visible = true;
            }
            else
            {
                checkBoxTimeLimit.Checked = false;
                dataGridView3.Columns[5].Visible = false;
            }
            if (selectedData[6])
            {
                checkBoxNodes.Checked = true;
                dataGridView3.Columns[6].Visible = true;
            }
            else
            {
                checkBoxNodes.Checked = false;
                dataGridView3.Columns[6].Visible = false;
            }
            if (selectedData[7])
            {
                checkBoxNodeList.Checked = true;
                dataGridView3.Columns[7].Visible = true;
            }
            else
            {
                checkBoxNodeList.Checked = false;
                dataGridView3.Columns[7].Visible = false;
            }
        }
        public bool[] selectedData = new bool[] { true, true, true, true, true, true, true, true, true };
        public void checkSelectedData() //for linux to not reset selection data 
        {


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


        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
        public void setLinuxRight()
        {

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Squeue Partition";
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nrRow = dataGridView3.CurrentCell.RowIndex;
            // Console.WriteLine(nrRow);
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

            if (bazasQueue.Count >= 1)
            {
                int nrColumn = dataGridView3.CurrentCell.ColumnIndex;
                string name = dataGridView3.Columns[nrColumn].Name;
                if (name == "User")
                {

                    //if (Application.OpenForms.OfType<Functions>().Count() == 1)
                    //    Application.OpenForms.OfType<Functions>().First().Close();


                    //Functions Functions = new Functions(dataGridView3.SelectedCells[0].Value.ToString());
                    Global.FunctionsNameUserParamiter = dataGridView3.SelectedCells[0].Value.ToString();
                    Global.actualUserNameFunction = false;

                    //Functions.Focus();
                    //Functions.Show();

                }
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

        private void dataGridView3_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (dataGridView3.Rows.Count > 1)
                {
                    // Console.WriteLine(dataGridView3[0, e.RowIndex]);

                    this.dataGridView3.CurrentCell = this.dataGridView3[0, e.RowIndex]; // zapis nr wiersza
                                                                                        //int nrRow = dataGridView3.CurrentCell.RowIndex;
                    for (int t = 0; t < dataGridView3.ColumnCount; t++) //zaznaczeniw calego wiersza
                    {
                        this.dataGridView3[t, e.RowIndex].Selected = true;
                    }

                }
            }
        }
        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM END ###############################################################
        // ############################################### CODE NEEDED FOR LINUX END ###############################################################

    }

}
