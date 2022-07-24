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
    class NoticeListViewModel
    {
        #region Constructs
        public NoticeListViewModel()
        {

        } 
        #endregion

        private RelayCommand noticeAddViewButtonClick;
        public ICommand NoticeAddViewButtonClick => noticeAddViewButtonClick =
            noticeAddViewButtonClick ?? new RelayCommand(NoticeButtonClick, CanButtonCmdExe);

        private ObservableCollection<NoticeListModel> notice;
        public ObservableCollection<NoticeListModel> Notice
        {
            get
            {
                if (notice == null)
                {
                    notice = new ObservableCollection<NoticeListModel>();
                    notice.Add(new NoticeListModel() { Date=DateTime.Now, NoticeContent="11231212",Writer="이석종", NoticeDetailContent="AAAAAA"});
                }
                return notice;
            }
        }
        #region ButtonEvent
        private void NoticeButtonClick()
        {
            NoticeAddView sub = new NoticeAddView();
            var viewModel = new NoticeAddViewModel();
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
