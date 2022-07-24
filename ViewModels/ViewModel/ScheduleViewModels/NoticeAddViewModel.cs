using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels.ViewModel.ScheduleViewModels
{
    class NoticeAddViewModel
    {
        #region Constructs
        public NoticeAddViewModel()
        {

        } 
        #endregion

        #region Property
        private string noticeName;
        public string NoticeName
        {
            get { return noticeName; }
            set
            {
                noticeName = value;
            }
        }

        private string noticeContent;
        public string NoticeContent
        {
            get { return noticeContent; }
            set
            {
                noticeContent = value;
            }
        } 
        #endregion

        private RelayCommand noticeAddButtonClick;
        public ICommand NoticeAddButtonClick => noticeAddButtonClick =
            noticeAddButtonClick ?? new RelayCommand(AddButtonClick, CanButtonCmdExe);

        #region ButtonEvent
        private void AddButtonClick()
        {
            MessageBox.Show(NoticeName);
            MessageBox.Show(NoticeContent);
        }
        private bool CanButtonCmdExe()
        {
            return true;
        } 
        #endregion
    }
}
