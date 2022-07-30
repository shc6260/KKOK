using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.ViewModels.ViewModel.ScheduleViewModels
{
    class ProjectProgressViewModel : ViewModelBase.ViewModelBase
    {

        #region Constructs
        public ProjectProgressViewModel()
        {
            ProjectPersent = (ProjectNowSuccess / ProjectWork) * 100;
            PersonalPersent = (PersonalNowSuccess / PersonalWork) * 100;
        } 
        #endregion

        #region Property
        private double projectPersent;
        public double ProjectPersent
        {
            get { return projectPersent; }
            set
            {
                projectPersent = value;
                OnPropertyChanged("ProjectPersent");
            }
        }

        private double projectWork = 5;
        public double ProjectWork
        {
            get { return projectWork; }
            set
            {
                projectWork = value;
                OnPropertyChanged("ProjectWork");
            }
        }

        private double projectNowSuccess = 1;
        public double ProjectNowSuccess
        {
            get { return projectNowSuccess; }
            set
            {
                projectNowSuccess = value;
                OnPropertyChanged("ProjectNowSuccess");
            }
        }

        private double personalPersent;
        public double PersonalPersent
        {
            get { return personalPersent; }
            set
            {
                personalPersent = value;
                OnPropertyChanged("PersonalPersent");
            }
        }

        private double personalWork =10;
        public double PersonalWork
        {
            get { return personalWork; }
            set
            {
                personalWork = value;
                OnPropertyChanged("PersonalWork");
            }
        }

        private double personalNowSuccess =1;
        public double PersonalNowSuccess
        {
            get { return personalNowSuccess; }
            set
            {
                personalNowSuccess = value;
                OnPropertyChanged("PersonalNowSuccess");
            }
        } 
        #endregion


    }
}
