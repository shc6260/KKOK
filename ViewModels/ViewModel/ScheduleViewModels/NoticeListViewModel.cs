using GalaSoft.MvvmLight.Command;
using KKOK.Models.ScheduleModel;
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
        public NoticeListViewModel()
        {

        }

        private ICommand noticeAddButtonClick;
        public ICommand NoticeAddButtonClick => noticeAddButtonClick =
            noticeAddButtonClick ?? new RelayCommand(NoticeButtonClick, CanButtonCmdExe);

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
            MessageBox.Show("1");
        }
        private bool CanButtonCmdExe()
        {
            return true;
        } 
        #endregion
    }
}
