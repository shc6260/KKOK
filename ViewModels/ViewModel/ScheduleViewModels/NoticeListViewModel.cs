using GalaSoft.MvvmLight.Command;
using KKOK.Models.ScheduleModel;
using KKOK.Views.ScheduleViews;
using Prism.Commands;
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

        

        private DelegateCommand noticeAddViewButtonClick;
        public DelegateCommand NoticeAddViewButtonClick => noticeAddViewButtonClick =
            noticeAddViewButtonClick ?? new DelegateCommand(NoticeButtonClick, CanButtonCmdExe);

        private ObservableCollection<NoticeListModel> innernotice { get; } = new ObservableCollection<NoticeListModel>();
        private ReadOnlyObservableCollection<NoticeListModel> notice;
        public ReadOnlyObservableCollection<NoticeListModel> Notice
        {
            get
            {
                if (notice == null)
                {
                    notice = new ReadOnlyObservableCollection<NoticeListModel>(innernotice);

                    innernotice.Add(new NoticeListModel() { Date=DateTime.Now, NoticeContent="11231212",Writer="이석종", NoticeDetailContent="AAAAAA"});
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
