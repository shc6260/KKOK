using GalaSoft.MvvmLight.Command;
using KKOK.Models.ScheduleModel;
using KKOK.Views.ScheduleViews;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels.ViewModel.ScheduleViewModels
{
    class ScheduleModuleViewModel : ViewModelBase.ViewModelBase
    {

        #region Constructs
        public ScheduleModuleViewModel()
        {

        } 
        #endregion

        #region Property
        private ObservableCollection<ScheduleModuleModel> schedule;
        public ObservableCollection<ScheduleModuleModel> Schedule
        {
            get
            {
                if (schedule == null)
                {
                    schedule = new ObservableCollection<ScheduleModuleModel>();
                    schedule.Add(new ScheduleModuleModel() { TotalDate = "일정", ManagerName = "담당자", Period = "소요기간", WorkName = "일정내용(상태)", WorkNumber = 11 });
                }
                return schedule;
            }
        } 
        #endregion

        private RelayCommand workAddButtonClick;
        public ICommand WorkAddButtonClick => workAddButtonClick =
            workAddButtonClick ?? new RelayCommand(AddButtonClick, CanButtonCmdExe);
        #region ButtonEvent
        private void AddButtonClick()
        {
            WorkAddView sub = new WorkAddView();
            var viewModel = new WorkAddViewModel();
            sub.DataContext = viewModel;
            sub.Show();
        }
        private bool CanButtonCmdExe()
        {
            return true;
        } 
        #endregion
    }
}
