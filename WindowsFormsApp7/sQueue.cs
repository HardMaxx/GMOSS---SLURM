using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    public class sQueue
    {
        public string Name { get; set; }
        public string Job { get; set; }
        public string User { get; set; }
        public string State { get; set; }
        public TimeSpan Time { get; set; }
        public TimeSpan TimeLimit { get; set; }
        public int Nodes { get; set; }
        public string Nodelist { get; set; }
        public string Partition { get; set; }


        public sQueue()
        {
        }

    }
}
