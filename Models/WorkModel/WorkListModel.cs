using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.Models.WorkModel
{
    public class WorkListModel
    {
        public int No { get; set; }
        public string WorkTitle { get; set; }
        public string State { get; set; }
        public string DetailWorkData { get; set; }
        public string Manager { get; set; }
        public DateTime EndDate { get; set; }
        public string WorkType { get; set; }
        public string Comment { get; set; }
        public string SecheduleData { get; set; }
    }
    
}
