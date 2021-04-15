using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleJobsProcessing.Models
{
    class Task
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public Nullable<System.DateTime> TaskCreateDate { get; set; }
        public string TaskType { get; set; }
        public string TaskDescription { get; set; }
        public bool TaskIsProcessed { get; set; }
        public Nullable<System.DateTime> TaskProcessedDate { get; set; }
    }
}
