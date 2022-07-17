using KKOK.Models.ScheduleModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.ViewModels.ViewModel.ScheduleViewModels
{
    class ScheduleModuleViewModel : ViewModelBase.ViewModelBase
    {

        public ScheduleModuleViewModel()
        {

        }

        private ObservableCollection<ScheduleModuleModel> schedule;
        public ObservableCollection<ScheduleModuleModel> Schedule
        {
            get
            {
                if (schedule == null)
                {
                    schedule = new ObservableCollection<ScheduleModuleModel>();
                    schedule.Add(new ScheduleModuleModel() { TotalDate = "1", ManagerName = "1", WorkName = "12", WorkNumber = 12 });
                }
                return schedule;
            }
        }
    }
}
