using KKOK.ViewModels.Main;
using KKOK.ViewModels.ViewModel.ScheduleViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.ViewModels
{
    class ScheduleDiagramViewModel : ViewModelBase
    {

        #region Property
        private NoticeListViewModel noticeListViewModel;
        public NoticeListViewModel NoticeListViewModel
        {
            get
            {
                if (noticeListViewModel == null)
                {
                    noticeListViewModel = new NoticeListViewModel();
                }
                return noticeListViewModel;
            }
        }

        private ProjectProgressViewModel projectProgressViewModel;
        public ProjectProgressViewModel ProjectProgressViewModel
        {
            get
            {
                if (projectProgressViewModel == null)
                {
                    projectProgressViewModel = new ProjectProgressViewModel();
                }
                return projectProgressViewModel;
            }
        } 
        #endregion

    }
}
