using GalaSoft.MvvmLight.Command;
using KKOK.Models.ScheduleModel;
using KKOK.Views.ScheduleViews;
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
        public ScheduleDiagramDetailViewModel()
        {

        }

        private ScheduleDiagramDetailModel items;
        public ScheduleDiagramDetailModel Items
        {
            get
            {
                if(items == null)
                {
                    items = new ScheduleDiagramDetailModel();
                    items.ExpectationEndDate = DateTime.Now;
                    items.TotalDate = DateTime.Now;
                }
                return items;
            }
        }

        private ICommand noticeAddButtonClick;
        public ICommand NoticeAddButtonClick => noticeAddButtonClick =
            noticeAddButtonClick ?? new RelayCommand(AddButtonClick, CanButtonCmdExe);

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
    }
}
