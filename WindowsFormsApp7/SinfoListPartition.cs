﻿using System;
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
    public partial class SinfoListPartition : Form
    {
        public  List<sInfo> squeueLista = new List<sInfo>(); //small
        public SinfoListPartition()
        {
            InitializeComponent();
            setLinuxRight(); //if linux set form

            labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
            //squeueLista.Clear();
            LoadDatabazasInfo(Global.ALLbazasInfo);
            checkBoxSetChecked();
            dataGridView1.RowPrePaint += new DataGridViewRowPrePaintEventHandler(this.changeColorSINFO); // zmiana koloru domyslnie od razu
        }

       

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

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

        public void LoadDatabazasInfo(List <sInfo> allBaza)
        {
            try
            {
               
                ///////////////////---------to save a selected state before refresh---------/////////////
                int row1 = 0;
                int col1 = 0;
                bool setSelectYES = false;
                if (dataGridView1.Rows.Count > 0)
                {
                    setSelectYES = true;
                }
                if (setSelectYES)
                {
                    row1 = (this.dataGridView1.CurrentCell.RowIndex);
                    col1 = (this.dataGridView1.CurrentCell.ColumnIndex);
                }
                ///////////////////------------------------------------/////////////

                //save scroll start
                labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;
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

                squeueLista = new List<sInfo>();

                squeueLista.Clear();
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Clear();
                // dataGridView1.Refresh();

                foreach (var row in allBaza) // zebranie danych tych co spejniaja wybrana partycje
                {
                    sInfo temp = new sInfo();

                    if (row.STATE.Contains("idle") || row.STATE.Contains("mixed"))  //jesli small roznica  //|| row.STATE.Contains("allocated") || row.STATE.Contains("mixed")
                    {
                        temp.PARTITION = row.PARTITION;
                        temp.AVAIL = row.AVAIL;
                        temp.TIMELIMIT = row.TIMELIMIT;
                        temp.JOB_SIZE = row.JOB_SIZE;
                        temp.NODES = row.NODES;
                        temp.STATE = row.STATE;
                        temp.NODELIST = row.NODELIST;
                        squeueLista.Add(temp);
                    }

                }
                dataGridView1.DataSource = squeueLista;
                setSortedData();
                setSelectedData();

                //save scroll end
                labelLastUpdateSQUEUE.Text = Global.LastUpdateTime;

                ///////////////////---------recover selected rows after refresh---------/////////////
                if (setSelectYES)
                {
                    this.dataGridView1.CurrentCell = this.dataGridView1[col1, row1]; // zapis nr wiersza

                    for (int t = 0; t < dataGridView1.ColumnCount; t++) //zaznaczeniw calego wiersza
                    {
                        this.dataGridView1[t, row1].Selected = true;
                    }
                }
                ///////////////////-----------------------------------------------------/////////////

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
                //save scroll end
                 



            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine("SinfoListPartition selected warning etc" + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("squeueList \nLoad Data Refresh xxx \n" +ex.Message);
            }
        }

        private void setSortedData()
        {
            dataGridView1.DataSource = SortData(
            (List<sInfo>)dataGridView1.DataSource, dataGridView1.Columns[_previousIndex].Name, _sortDirection);
        }

        public void changeColorSINFO(object sender, DataGridViewRowPrePaintEventArgs e)
        {

            ColorType colorek = new ColorType();

            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("allocated"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.allocated;// Color.Green;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("drained"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.drained;// Color.Gray;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("draining"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.drained;// Color.LightGray;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("idle"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.idle;// Color.LightSteelBlue;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("mixed"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.mixed;// Color.Yellow;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("completing"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.completing;//Color.LightSalmon;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("reserved"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.reserved;// Color.LightPink;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("down"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.power_down;// Color.Aqua;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("error"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.error_fail;// Color.LightSalmon;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("failing"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.error_fail;// Color.LightGreen;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("fail"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.error_fail;// Color.LightSlateGray;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("future"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.reserved;// Color.LightYellow;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("maint"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.maint;// Color.LightCoral;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("reboot"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.reboot;// Color.LightCyan;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("power_down"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.power_down;// Color.LightCyan;
            }
            if (Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[4].Value).Contains("power_up"))
            {
                dataGridView1.Rows[e.RowIndex].DefaultCellStyle.BackColor = colorek.power_up;// Color.LightGoldenrodYellow;
            }


        }


        public void checkBoxSetChecked()
        {
            checkBoxNodeList.Checked = true;
            checkBoxAvail.Checked = true;
            checkBoxPartition.Checked = true;
            checkBoxTimeLimit.Checked = true;
            checkBoxJobSize.Checked = true;
            checkBoxState.Checked = true;
            checkBoxNode.Checked = true;
        }


        private void checkBoxPartition_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNodeList.Checked)
                dataGridView1.Columns[6].Visible = true;
            else
                dataGridView1.Columns[6].Visible = false;
            checkSelectedData();
        }

        private void checkBoxAvail_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxAvail.Checked)
                dataGridView1.Columns[0].Visible = true;
            else
                dataGridView1.Columns[0].Visible = false;
            checkSelectedData();
        }

        private void checkBoxTimeLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPartition.Checked)
                dataGridView1.Columns[1].Visible = true;
            else
                dataGridView1.Columns[1].Visible = false;
            checkSelectedData();
        }

        private void checkBoxJobSize_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxTimeLimit.Checked)
                dataGridView1.Columns[2].Visible = true;
            else
                dataGridView1.Columns[2].Visible = false;
            checkSelectedData();
        }

        private void checkBoxNodes_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxJobSize.Checked)
                dataGridView1.Columns[3].Visible = true;
            else
                dataGridView1.Columns[3].Visible = false;
            checkSelectedData();
        }

        private void checkBoxState_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxState.Checked)
                dataGridView1.Columns[4].Visible = true;
            else
                dataGridView1.Columns[4].Visible = false;
            checkSelectedData();
        }

        private void checkBoxNodeList_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxNode.Checked)
                dataGridView1.Columns[5].Visible = true;
            else
                dataGridView1.Columns[5].Visible = false;
            checkSelectedData();
        }

        private int _previousIndex;
        private bool _sortDirection;

        private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == _previousIndex)
                _sortDirection ^= true; // zmiana sorotwania ros/mal

            dataGridView1.DataSource = SortData(
                (List<sInfo>)dataGridView1.DataSource, dataGridView1.Columns[e.ColumnIndex].Name, _sortDirection);

            _previousIndex = e.ColumnIndex;
            setSelectedData();

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                //to reset scroll to default position after click sort
                dataGridView1.CurrentCell = dataGridView1.Rows[dataGridView1.Rows.Count - 1].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.FirstDisplayedScrollingRowIndex = 0;
            }
            /// ///////////////////---------recover selected rows after refresh---------/////////////

            if (dataGridView1.Rows.Count > 1)
            {
                for (int t = 0; t < dataGridView1.ColumnCount; t++) //zaznaczeniw calego wiersza
                {
                    this.dataGridView1[t, dataGridView1.FirstDisplayedScrollingRowIndex].Selected = true;
                }
                this.dataGridView1.CurrentCell = this.dataGridView1[0, dataGridView1.FirstDisplayedScrollingRowIndex];// this.dataGridView3[0, dataGridView3.FirstDisplayedScrollingRowIndex]; // zapis nr wiersza
            }
            ///////////////////-----------------------------------------------------/////////////
        }

        private List<sInfo> SortData(List<sInfo> list, string column, bool ascending)
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
                checkBoxAvail.Checked = true;
                dataGridView1.Columns[0].Visible = true;
            }
            else
            {
                checkBoxAvail.Checked = false;
                dataGridView1.Columns[0].Visible = false;
            }
            if (selectedData[1])
            {
                checkBoxPartition.Checked = true;
                dataGridView1.Columns[1].Visible = true;
            }
            else
            {
                checkBoxPartition.Checked = false;
                dataGridView1.Columns[1].Visible = false;
            }
            if (selectedData[2])
            {
                checkBoxTimeLimit.Checked = true;
                dataGridView1.Columns[2].Visible = true;
            }
            else
            {
                checkBoxTimeLimit.Checked = false;
                dataGridView1.Columns[2].Visible = false;
            }
            if (selectedData[3])
            {
                checkBoxJobSize.Checked = true;
                dataGridView1.Columns[3].Visible = true;
            }
            else
            {
                checkBoxJobSize.Checked = false;
                dataGridView1.Columns[3].Visible = false;
            }
            if (selectedData[4])
            {
                checkBoxState.Checked = true;
                dataGridView1.Columns[4].Visible = true;
            }
            else
            {
                checkBoxState.Checked = false;
                dataGridView1.Columns[4].Visible = false;
            }
            if (selectedData[5])
            {
                checkBoxNode.Checked = true;
                dataGridView1.Columns[5].Visible = true;
            }
            else
            {
                checkBoxNode.Checked = false;
                dataGridView1.Columns[5].Visible = false;
            }
            if (selectedData[6])
            {
                checkBoxNodeList.Checked = true;
                dataGridView1.Columns[6].Visible = true;
            }
            else
            {
                checkBoxNodeList.Checked = false;
                dataGridView1.Columns[6].Visible = false;
            }
        }
     
        public bool[] selectedData = new bool[] { true, true, true, true, true, true, true };
        public void checkSelectedData()
        {


            if (checkBoxAvail.Checked)
                selectedData[0] = true;
            else
                selectedData[0] = false;
            if (checkBoxPartition.Checked)
                selectedData[1] = true;
            else
                selectedData[1] = false;
            if (checkBoxTimeLimit.Checked)
                selectedData[2] = true;
            else
                selectedData[2] = false;
            if (checkBoxJobSize.Checked)
                selectedData[3] = true;
            else
                selectedData[3] = false;
            if (checkBoxState.Checked)
                selectedData[4] = true;
            else
                selectedData[4] = false;
            if (checkBoxNode.Checked)
                selectedData[5] = true;
            else
                selectedData[5] = false;
            if (checkBoxNodeList.Checked)
                selectedData[6] = true;
            else
                selectedData[6] = false;
        }


        private void SinfoListPartition_Load(object sender, EventArgs e)
        {

        }

        // ############################################### CODE NEEDED FOR LINUX END ###############################################################
        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
        public void setLinuxRight()
        {
            
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "Sinfo List Partition";
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


        // https://stackoverflow.com/questions/2575216/how-to-move-and-resize-a-form-without-a-border
        //RESIZE FORM LINUX
        int Mx;
        int My;
        int Sw;
        int Sh;

        bool mov;

        private void button1_MouseDown_1(object sender, MouseEventArgs e)
        {
            mov = true;
            My = MousePosition.Y;
            Mx = MousePosition.X;
            Sw = Width;
            Sh = Height;
        }

        private void button1_MouseMove_1(object sender, MouseEventArgs e)
        {
            if (mov == true)
            {
                Width = MousePosition.X - Mx + Sw;
                Height = MousePosition.Y - My + Sh;
            }
        }

        private void button1_MouseUp_1(object sender, MouseEventArgs e)
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

        //butons panel
        private void button__Click_1(object sender, EventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int nrRow = dataGridView1.CurrentCell.RowIndex;
            // Console.WriteLine(nrRow);
            int row1 = 0;
            int col1 = 0;
            bool setSelectYES = false;
            if (dataGridView1.Rows.Count > 0)
            {
                setSelectYES = true;
            }
            if (setSelectYES)
            {
                row1 = (this.dataGridView1.CurrentCell.RowIndex);
                col1 = (this.dataGridView1.CurrentCell.ColumnIndex);
            }

            try
            {
                if (squeueLista.Count >= 1)
            {
                int nrColumn = dataGridView1.CurrentCell.ColumnIndex;

                string name = dataGridView1.Columns[nrColumn].Name;
                if (name == "PARTITION")
                {
                    if (Application.OpenForms.OfType<SinfoPartition>().Count() >= 1)
                    {
                        //Application.OpenForms.OfType<SinfoPartition>().First().Close();
                        Global.SinfoNamePartitionParamiter = dataGridView1.SelectedCells[0].Value.ToString();
                        Global.SinfoPartitionForm.LoadDatabazasInfo(Global.SinfoNamePartitionParamiter, Global.ALLbazasInfo);
                        Global.SinfoPartitionForm.Focus();
                        Global.SinfoPartitionForm.BringToFront();

                        }
                    else
                    {
                        Global.SinfoPartitionForm = new SinfoPartition(dataGridView1.SelectedCells[0].Value.ToString());
                        Global.SinfoNamePartitionParamiter = dataGridView1.SelectedCells[0].Value.ToString();
                        Global.SinfoPartitionForm.Show();
                    }

                }
            }


            }
            catch (Exception ex)
            {
                MessageBox.Show("Blad podczas klikania w elementy tabeli tu" + ex.Message);

            }


            if (setSelectYES)
            {
                this.dataGridView1.CurrentCell = this.dataGridView1[col1, row1]; // zapis nr wiersza
                                                                                 //int nrRow = dataGridView3.CurrentCell.RowIndex;
                for (int t = 0; t < dataGridView1.ColumnCount; t++) //zaznaczeniw calego wiersza
                {
                    this.dataGridView1[t, nrRow].Selected = true;
                }
            }
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux) || RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                if (dataGridView1.Rows.Count > 1)
                {
                    // Console.WriteLine(dataGridView3[0, e.RowIndex]);

                    this.dataGridView1.CurrentCell = this.dataGridView1[0, e.RowIndex]; // zapis nr wiersza
                                                                                        //int nrRow = dataGridView3.CurrentCell.RowIndex;
                    for (int t = 0; t < dataGridView1.ColumnCount; t++) //zaznaczeniw calego wiersza
                    {
                        this.dataGridView1[t, e.RowIndex].Selected = true;
                    }

                }
            }
        }
        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM END ###############################################################
    }
}
