using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.Models.ScheduleModel
{
    class ScheduleDiagramDetailModel
    {
        public string? NameFilter { get; set; }
        public DateTime TotalDate { get; set; }
        public DateTime ExpectationEndDate { get; set; }
    }
}
