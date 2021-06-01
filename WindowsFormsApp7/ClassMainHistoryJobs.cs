using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp7
{

    public class ClassMainHistoryJobs
    {
        public DateTime DateOfSubmission { get; set; }
        public string JobName { get; set; }
       // public string DirectoryName { get; set; }
        public string TypeOfSpliting { get; set; }
        public int NumberOfParts { get; set; }
        //public string ErrorInfo { get; set; }
        //public string StdOut { get; set; }
        public string Description { get; set; }
        public string Tool { get; set; }
        public string Edit { get; set; }

        public ClassMainHistoryJobs()
        {

        }

    }


}
