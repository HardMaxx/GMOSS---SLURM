using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{
    public class sInfo
    {
       
        public string AVAIL { get; set; }
        public string PARTITION { get; set; }
        public TimeSpan TIMELIMIT { get; set; }
        public string JOB_SIZE { get; set; }
        public string STATE { get; set; }
        public int NODES { get; set; }
        public string NODELIST { get; set; }
        

        public sInfo()
        {
        }



    }
}
