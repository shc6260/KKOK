using GalaSoft.MvvmLight.Command;
using KKOK.Models.ScheduleModel;
using KKOK.Views.ScheduleViews;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels.ViewModel.ScheduleViewModels
{
    class ScheduleDiagramDetailViewModel
    {
        #region Constructs
        public ScheduleDiagramDetailViewModel()
        {

        }
        #endregion

        #region Proprety
        private ScheduleDiagramDetailModel items;
        public ScheduleDiagramDetailModel Items
        {
            get
            {
                if (items == null)
                {
                    items = new ScheduleDiagramDetailModel();
                    items.ExpectationEndDate = DateTime.Now;
                    items.TotalDate = DateTime.Now;
                }
                return items;
            }
        }
        private ScheduleModuleViewModel scheduleModuleViewModel;
        public ScheduleModuleViewModel ScheduleModuleViewModel
        {
            get
            {
                if (scheduleModuleViewModel == null)
                {
                    scheduleModuleViewModel = new ScheduleModuleViewModel();
                }
                return scheduleModuleViewModel;
            }
        } 
        #endregion

        private DelegateCommand noticeAddButtonClick;
        public DelegateCommand NoticeAddButtonClick => noticeAddButtonClick =
            noticeAddButtonClick ?? new DelegateCommand(AddButtonClick, CanButtonCmdExe);

        #region ButtonEvent
        private void AddButtonClick()
        {
            ScheduleAddView sub = new ScheduleAddView();
            var viewModel = new ScheduleAddViewModel();
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
