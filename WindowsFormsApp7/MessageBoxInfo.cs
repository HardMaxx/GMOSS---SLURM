using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
{
    public partial class MessageBoxInfo : Form
    {
        public MessageBoxInfo(string monit)
        {
            InitializeComponent();
            if (monit == "1")
            {
               // label1.Refresh();
                label1.Text = "Adds selected files, Please wait...";
                label1.Text = "Adds selected files, Please wait..."; 
                label1.Text = "Adds selected files, Please wait...";
                label1.Refresh();
            }
            else
            {
                label1.Refresh();
                label1.Text = monit;
                label1.Refresh();
            }
        }

        private void MessageBoxInfo_Load(object sender, EventArgs e)
        {

        }
    }
}
