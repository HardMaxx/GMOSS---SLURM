using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;

namespace WindowsFormsApp7
{
    public partial class SystemGraphLinux : Form
    {
        public List<User> BazaUser = new List<User>();
        public List<squeueChart> BazaSqueueChart = new List<squeueChart>();

        public SystemGraphLinux()
        {
            InitializeComponent();

            try
            {
                setLinuxRight();
                zedGraphControl1.Visible = false;
                zedGraphControl3.Visible = false;
                textBoxMinimalTotalJobs.Text = Global.minimalTotalJobGraph.ToString();
                comboBox1.Items.Clear(); //to clear combobox

            for (int i = 0; i < Functions.usersQueueList.Count() - 1; i++)
            {
                comboBox1.Items.Add(Functions.usersQueueList[i]);
            }

            CountUserValues();
            CountSqueueValues();

         
            ZedGraphUser();
            ZedGraphPartition();

            CountUserValuesONE2();
            ZedGraphUserONE2();


            }
            catch (Exception ex)
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
                //dataGridView1.DataSource = BazaUser;
                //return ;
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
                else
                {
                    temp.total = all;
                    temp.running = run;
                    temp.pending = pen;
                    BazaSqueueChart.Add(temp);
                }
                //dataGridView1.DataSource = BazaUser;
                //return ;
            }
        }

        public List<PieItem> Bazaczegos = new List<PieItem>();

        List<Color> colors = new List<Color>
        {
            Color.AliceBlue,
            Color.ForestGreen,
            Color.Aqua,
            Color.Aquamarine,
            Color.Azure,
            Color.Beige,
            Color.Bisque,
            Color.BlanchedAlmond,
            Color.Blue,
            Color.Brown,
            Color.BurlyWood,
            Color.CadetBlue,
            Color.Chartreuse,
            Color.Chocolate,
            Color.Coral,
            Color.CornflowerBlue,
            Color.Cornsilk,
            Color.Crimson,
            Color.Cyan
        };

        public void ZedGraphUser()
        {
            Bazaczegos = new List<PieItem>();
            GraphPane myPane = zedGraphControl1.GraphPane;
            Bazaczegos.Clear();
            BazaUser = BazaUser.OrderByDescending(oo => oo.total).ToList();

            for (int i = 0; i < BazaUser.Count() - 1; i++)
            {
                if (BazaUser[i].total > Global.minimalTotalJobGraph)
                {
                    zedGraphControl1.Visible = true;
                    PieItem temp = myPane.AddPieSlice(BazaUser[i].total, colors[i], 0F, BazaUser[i].user + ": " + BazaUser[i].total);
                    //PieItem pieSlice= myPane.AddPieSlice(10, Color.Blue, 0F, "Label1");
                    Bazaczegos.Add(temp);
                }
            }

            int o = 0;
            myPane.Title.Text = "Users jobs";
            foreach (var item in Bazaczegos)
            {
                o++;
                FontSpec xd2 = new FontSpec();
                Location xd3 = new Location();
                xd2.Size =15;
                item.Label.FontSpec = xd2;

            }

           
            zedGraphControl1.GraphPane.Border.IsVisible = false;
            zedGraphControl1.GraphPane.Margin.All=3;

            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();

        }
        public void ZedGraphPartition()
        {
            Bazaczegos = new List<PieItem>();
            Bazaczegos.Clear();
            GraphPane myPane = zedGraphControl2.GraphPane;
            
            // PieItem temp = new PieItem();
            BazaSqueueChart = BazaSqueueChart.OrderByDescending(oo => oo.total).ToList();

            for (int i = 0; i < BazaSqueueChart.Count() - 1; i++)
            {
                PieItem temp = myPane.AddPieSlice(BazaSqueueChart[i].total, colors[i], 0F, BazaSqueueChart[i].partition + ": " + BazaSqueueChart[i].total + " (" + BazaSqueueChart[i].pending + ")");

                Bazaczegos.Add(temp);
            }

            int o = 0;
            myPane.Title.Text = "Partitions jobs";

            foreach (var item in Bazaczegos)
            {
                o++;
                FontSpec xd2 = new FontSpec();
                xd2.Size = 15;
                item.Label.FontSpec = xd2;

            }

            zedGraphControl1.GraphPane.Border.IsVisible = false;
            zedGraphControl1.GraphPane.Margin.All = 3;
            zedGraphControl2.AxisChange();
            zedGraphControl2.Invalidate();

        }

        private void zedGraphControl1_Load(object sender, EventArgs e)
        {

        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            if (Application.OpenForms.OfType<SystemGraphLinux>().Count() >= 1)
            {
                Application.OpenForms.OfType<SystemGraphLinux>().First().Close();

            }
            SystemGraphLinux systemSUM = new SystemGraphLinux();
            systemSUM.Show();
        }

        //int allONE = 0;
        int runONE = 0;
        int penONE = 0;

        bool ONE = false;

        public List<int> liczby = new List<int>();
        public List<string> typy = new List<string>();
        public void CountUserValuesONE2()
        {
            //allONE = 0;
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
                        temp.user = row.User;
                        if (row.State == "RUNNING")
                            runONE++;//temp.running = temp.running + Convert.ToInt32(row.);
                        else if (row.State == "PENDING")
                            penONE++;//temp.running = temp.running + Convert.ToInt32(row.State);
                        ONE = true;

                    liczby.Add(runONE);
                    liczby.Add(penONE);
                    //typy.Add("TOTAL");
                    typy.Add("RUNNI");
                    typy.Add("PENDI");
                    break;
                    //}
                }
            }
        }
        public void CountUserValuesONE()
        {
           // allONE = 0;
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
                        //allONE++;
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
                    //liczby.Add(allONE);
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
        public void ZedGraphUserONE2()
        {
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.GraphObjList.Clear();
            zedGraphControl3.Visible = true;
            Bazaczegos = new List<PieItem>();
            GraphPane myPane = zedGraphControl3.GraphPane;
            Bazaczegos.Clear();

            int xxx = 0;
            
            PieItem temp = myPane.AddPieSlice(1, colors[xxx], 0F, "NULL" + ": " + 1);
            //PieItem pieSlice= myPane.AddPieSlice(10, Color.Blue, 0F, "Label1");
            Bazaczegos.Add(temp);
            xxx++;


            // optional depending on whether you want labels within the graph legend
            // myPane.Legend.IsVisible = false;
            int o = 0;
            if (!oneTitle)
            {
                myPane.Title.Text = "Users jobs";
                
            }

            oneTitle = true;

            foreach (var item in Bazaczegos)
            {
                o++;
                FontSpec xd2 = new FontSpec();
                Location xd3 = new Location();
                xd2.Size = 14;
                //item.Displacement = 0.1f;
                // item.Label.FontSpec = xd2;
                item.Label.FontSpec = xd2;

            }

            zedGraphControl1.GraphPane.Border.IsVisible = false;
            zedGraphControl1.GraphPane.Margin.All = 3;
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();
        }
        public void ZedGraphUserONE()
        {
            zedGraphControl3.GraphPane.CurveList.Clear();
            zedGraphControl3.GraphPane.GraphObjList.Clear();
            //zedGraphControl3.Visible = true;
            Bazaczegos = new List<PieItem>();
            GraphPane myPane = zedGraphControl3.GraphPane;
            Bazaczegos.Clear();
            // PieItem temp = new PieItem();
            //BazaUser = BazaUser.OrderByDescending(oo => oo.total).ToList();
            int xxx = 0;
            foreach (var item in liczby)
            {
                zedGraphControl3.Visible = true;
                PieItem temp = myPane.AddPieSlice(item, colors[xxx], 0F, typy[xxx] + ": " + item);
                //PieItem pieSlice= myPane.AddPieSlice(10, Color.Blue, 0F, "Label1");
                Bazaczegos.Add(temp);
                xxx++;
            }

            int o = 0;
            if (!oneTitle)
            {
                myPane.Title.Text = "Users jobs";

            }
            //myPane.YAxis.Scale.FontSpec.Size = 14;
            oneTitle = true;

            foreach (var item in Bazaczegos)
            {
                o++;
                FontSpec xd2 = new FontSpec();
                Location xd3 = new Location();
                xd2.Size = 14;
                //item.Displacement = 0.1f;
                // item.Label.FontSpec = xd2;
                item.Label.FontSpec = xd2;

            }
            zedGraphControl1.GraphPane.Border.IsVisible = false;
            zedGraphControl1.GraphPane.Margin.All = 3;
            zedGraphControl3.AxisChange();
            zedGraphControl3.Invalidate();

        }


        private void SystemGraphLinux_Load(object sender, EventArgs e)
        {

        }

        private void buttonClosewindow_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void zedGraphControl3_Load(object sender, EventArgs e)
        {

        }

        private void zedGraphControl2_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //zedGraphControl3.Visible = true ;
            CountUserValuesONE();
            ZedGraphUserONE();
        }

        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM ###############################################################
        public void setLinuxRight()
        {


                // buttonResetDatagridView.Visible = true;
                panelBorderStyle.Visible = true;
                this.FormBorderStyle = FormBorderStyle.None;
                labelFormName.Text = "System Graph";
                //buttonResetDatagridView.Visible = false;

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

        private void textBoxMinimalTotalJobs_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            Global.minimalTotalJobGraph = Convert.ToInt32(textBoxMinimalTotalJobs.Text);
            //chart3.Visible = true;
            if (Application.OpenForms.OfType<SystemGraphLinux>().Count() >= 1)
            {
                Application.OpenForms.OfType<SystemGraphLinux>().First().Close();

            }
            SystemGraphLinux systemSUM = new SystemGraphLinux();
            systemSUM.Show();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM END ###############################################################
    }
}
