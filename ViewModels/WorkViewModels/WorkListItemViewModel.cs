using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.ViewModels.WorkViewModels
{
    public class WorkListItemViewModel
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

        public static WorkListItemViewModel From(WorkListData data)
        {
            return new WorkListItemViewModel()
            {
                No = data.No,
                WorkTitle = data.WorkTitle,
                Manager = data.Manager,
                State = data.State,
            };
        }
    }

    public class WorkListData
    {
        public WorkListData(int no, string workTitle, string manager, string state)
        {
            No = no;
            WorkTitle = workTitle;
            Manager = manager;
            State = state;

        }
        public int No { get; }
        public string WorkTitle { get; }
        public string Manager { get; }
        public string State { get; }

        public static WorkListData From((int No, string WorkTitle, string Manager, string State) data)
        {
            return new WorkListData(
                data.No,
                data.WorkTitle,
                data.Manager,
                data.State
                );
        }
    }
}
