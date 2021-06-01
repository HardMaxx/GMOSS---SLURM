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
    public partial class FormScontrolShow : Form
    {
        string JOB_ID;
        public FormScontrolShow()
        {
            InitializeComponent();
            setLinuxRight();
        }

        public class scontrolINFO
        {
            public string Item { get; set; }
            public string Value { get; set; }

            public scontrolINFO()
            {

            }
        }

        public  BindingList<scontrolINFO> scontrolLIST = new BindingList<scontrolINFO>(); //ALL

        public void loadData(string job_id)
        {
            scontrolLIST.Clear();
            
            //listBox1.Items.Clear();
            var command = Global.connectionSession.RunCommand("scontrol show job " + job_id);
            //Console.WriteLine(command.Result);
           
            string[] lines = (command.Result).Split('\n');

            for (int i = 0; i < lines.Length; i++)
            {
                string[] partLines = lines[i].Split(' ');
                for (int j = 0; j < partLines.Length; j++)
                {
                    if (partLines[j] != "")
                    {
                        scontrolINFO tmp = new scontrolINFO();
                        if (partLines[j].StartsWith("TRES")) // dużo "=" wiec tu trzeba inaczej to podzielic
                        {
                            string xxxD = "";
                            string[] strlist2 = partLines[j].Split('=');
                            bool items2 = true;

                            foreach (string s in strlist2)
                            {
                                //scontrolINFO tmp = new scontrolINFO();
                                if (items2)
                                {
                                    tmp.Item = "TRES";
                                    items2 = false;
                                }
                                else
                                {
                                    xxxD =xxxD + s+" ";

                                }
                            }
                            tmp.Value = xxxD;
                            scontrolLIST.Add(tmp);
                        }
                        else //reszte dziel normalnie
                        {
                            //Console.WriteLine(i + ": " + partLines[j]);
                            //listBox1.Items.Add(partLines[j]);
                            String[] strlist = partLines[j].Split('=');
                            bool items = true;

                            foreach (String s in strlist)
                            {
                                //scontrolINFO tmp = new scontrolINFO();
                                if (items)
                                {
                                    tmp.Item = s;
                                    items = false;
                                }
                                else
                                {
                                    tmp.Value = s;
                                    items = true;
                                }
                                // Console.WriteLine(s);

                            }
                            scontrolLIST.Add(tmp);
                        }
                        //scontrolLIST.Add(tmp);

                    }
                }
            }
            dataGridView1.DataSource = scontrolLIST;
           // dataGridView1.Columns[0].Width = 40;
        }

        private void FormScontrolShow_Load(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
                labelFormName.Text = "Scontrol Info";
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
        // ############################################### CODE NEEDED FOR LINUX RESIZE AND  MOVE FORM END ###############################################################
    }
}
