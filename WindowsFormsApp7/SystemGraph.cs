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
using System.Windows.Forms.DataVisualization.Charting;
using ZedGraph;

namespace WindowsFormsApp7
{
    public partial class SystemGraph : Form
    {
        public List<User> BazaUser = new List<User>();
        public List<squeueChart> BazaSqueueChart = new List<squeueChart>();

        public SystemGraph()
        {
            InitializeComponent();
            try
            {
                chart3.Visible = false;
                chart1.Visible = false;
                textBoxMinimalTotalJobs.Text = Global.minimalTotalJobGraph.ToString();

                comboBox1.Items.Clear(); //to clear combobox
                for (int i = 0; i < Functions.usersQueueList.Count() - 1; i++)
                {
                    comboBox1.Items.Add(Functions.usersQueueList[i]);
                }

                CountUserValues();

                CountSqueueValues();

                chartUser();
                chartSqueue();

            }
            catch(Exception ex)
            {
                MessageBox.Show("Refresh data");
            }
            
        }



        public void CountUserValues()
        {
            BazaUser = new List<User>();

            foreach (var user in Functions.usersQueueList) //dodatnie listy do sinfo pozniej zbedne
            {
                int all = 0;
                int run = 0;
                int pen = 0;
                User temp = new User();
                foreach (var row in Global.ALLbazasQueue)
                {

                    if (user == row.User)
                    {
                        all++;
                        temp.user = row.User;
                        if (row.State == "RUNNING")
                            run++;//temp.running = temp.running + Convert.ToInt32(row.);
                        else if (row.State == "PENDING")
                            pen++;//temp.running = temp.running + Convert.ToInt32(row.State);
                    }
                }
                temp.total = all;
                temp.running = run;
                temp.pending = pen;
                BazaUser.Add(temp);
            }
        }

        public void CountSqueueValues()
        {
            BazaSqueueChart = new List<squeueChart>();

            foreach (var partition in Functions.partitionsQueueList) //dodatnie listy do sinfo pozniej zbedne
            {
                int all = 0;
                int run = 0;
                int pen = 0;
                squeueChart temp = new squeueChart();
                foreach (var row in Global.ALLbazasQueue)
                {

                    if (partition == row.Partition)
                    {

                        all++;
                        temp.partition = row.Partition;
                        if (row.State == "RUNNING")
                            run++;//temp.running = temp.running + Convert.ToInt32(row.);
                        else if (row.State == "PENDING")
                            pen++;//temp.running = temp.running + Convert.ToInt32(row.State);
                    }
                    

                }
                if (all < 1)
                {
                    temp.partition = partition;
                    temp.total = 0;
                    temp.running = 0;
                    temp.pending = 0;
                    BazaSqueueChart.Add(temp);
                }
                else {
                    temp.total = all;
                    temp.running = run;
                    temp.pending = pen;
                    BazaSqueueChart.Add(temp);
                }
                //dataGridView1.DataSource = BazaUser;
                //return ;
            }
        }

        //sztos ustawienie
        //http://www.nullskull.com/q/10311753/how-to-display-labels-outside-the-pie-chart.aspx

        public void chartSqueue()
        {
            BazaSqueueChart = BazaSqueueChart.OrderByDescending(o => o.total).ToList();
            int xd = 0;
            chart2.Titles.Add("Partitions jobs");
            for (int i = 0; i < BazaSqueueChart.Count()-1; i++)
            {
                //  chart1.Series["s1"].IsValueShownAsLabel = true;
                chart2.Series["s2"].Points.AddXY(" ", BazaSqueueChart[i].total);
                chart2.Series["s2"].Points[xd].Label = BazaSqueueChart[i].partition + ": " + BazaSqueueChart[i].total + " (" + BazaSqueueChart[i].pending + ")";
                chart2.Series["s2"]["PieLabelStyle"] = "Outside";
                chart2.Series["s2"].BorderWidth = 1;
                chart2.Series["s2"].BorderDashStyle = ChartDashStyle.Solid;
                chart2.Series["s2"].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);
                chart2.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart2.ChartAreas[0].Area3DStyle.Inclination = 0;
                xd++;
            }
        }

        public void chartUser()
        {
            BazaUser = BazaUser.OrderByDescending(o => o.total).ToList();

            int xd = 0;
            chart1.Titles.Add("Users jobs");
            for (int i = 0; i < BazaUser.Count(); i++)
            {
                //  chart1.Series["s1"].IsValueShownAsLabel = true;
                if (BazaUser[i].total >= Global.minimalTotalJobGraph)
                {
                    chart1.Visible = true;
                    chart1.Series["s1"].Points.AddXY(" ", BazaUser[i].total);

                    
                    chart1.Series["s1"].BorderWidth = 1;
                    chart1.Series["s1"].BorderDashStyle = ChartDashStyle.Solid;
                    chart1.Series["s1"].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);

                    chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                    chart1.ChartAreas[0].Area3DStyle.Inclination = 0;

                    chart1.Series["s1"].Points[xd].Label = BazaUser[i].user + ": " + BazaUser[i].total;

                    chart1.Series["s1"]["PieLabelStyle"] = "Outside";
                    xd++;
                }
            }
        }

       // int allONE = 0;
        int runONE = 0;
        int penONE = 0;

        bool ONE = false;

        public List<int> liczby = new List<int>();
        public List<string> typy = new List<string>();
        public void CountUserValuesONE()
        {
           //  allONE = 0;
             runONE = 0;
             penONE = 0;
           

            liczby.Clear();
            typy.Clear();
            foreach (var user in Functions.usersQueueList) //dodatnie listy do sinfo pozniej zbedne
            {
                //int all = 0;
                //int run = 0;
                //int pen = 0;
                User temp = new User();
               
                foreach (var row in Global.ALLbazasQueue)
                {

                    if (comboBox1.SelectedItem.ToString() == row.User)
                    {
                       // allONE++;
                        temp.user = row.User;
                        if (row.State == "RUNNING")
                            runONE++;//temp.running = temp.running + Convert.ToInt32(row.);
                        else if (row.State == "PENDING")
                            penONE++;//temp.running = temp.running + Convert.ToInt32(row.State);
                        ONE = true;
                    }
                }

                if (ONE)
                {
                   // liczby.Add(allONE);
                    liczby.Add(runONE);
                    liczby.Add(penONE);
                   // typy.Add("TOTAL");
                    typy.Add("RUNNI");
                    typy.Add("PENDI");

                    break;
                }
            }
        }

        bool oneTitle = false;
        public void chartUserONE()
        {
            foreach (var series in chart3.Series)
            {
                series.Points.Clear();
            }

            
            int xd = 0;

            if (!oneTitle)
            {
                chart3.Titles.Add("User jobs");
            }
            oneTitle = true;

            int typyID = 0;
            foreach (var item in liczby)
            {
                //TOTAL

                chart3.Series["s2"].Points.AddXY(" ", item);


                chart3.Series["s2"].BorderWidth = 1;
                chart3.Series["s2"].BorderDashStyle = ChartDashStyle.Solid;
                chart3.Series["s2"].BorderColor = System.Drawing.Color.FromArgb(200, 26, 59, 105);

                chart3.ChartAreas[0].Area3DStyle.Enable3D = true;
                chart3.ChartAreas[0].Area3DStyle.Inclination = 0;

                
                chart3.Series["s2"].Points[xd].Label = typy[typyID]+": " + item;
                //chart3.Series["s2"].Points[xd].Label = item.user + ": " + item.pending + "TOTAL" + item.total;
                //chart3.Series["s2"].Points[xd].Label = item.user + ": " + item.running + "TOTAL" + item.total;

                chart3.Series["s2"]["PieLabelStyle"] = "Outside";
                typyID++;
                xd++;
                //PENDING
            }

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SystemGraph>().Count() >= 1)
            {
                Application.OpenForms.OfType<SystemGraph>().First().Close();

            }
            SystemGraph systemSUM = new SystemGraph();
            systemSUM.Show();
        }

        private void buttonClosewindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chart3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            chart3.Visible = true;
            CountUserValuesONE();
                chartUserONE();
        }

        private void SystemGraph_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBoxMinimalTotalJobs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Global.minimalTotalJobGraph =Convert.ToInt32(textBoxMinimalTotalJobs.Text);
            //chart3.Visible = true;
            if (Application.OpenForms.OfType<SystemGraph>().Count() >= 1)
            {
                Application.OpenForms.OfType<SystemGraph>().First().Close();

            }
            SystemGraph systemSUM = new SystemGraph();
            systemSUM.Show();

        }
    }
     
}
