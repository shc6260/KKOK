using GalaSoft.MvvmLight.Command;
using KKOK.Models.ScheduleModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels.ViewModel.ScheduleViewModels
{
    class ScheduleAddViewModel
    {
        #region Constructs
        public ScheduleAddViewModel()
        {

        } 
        #endregion

        #region Proprety
        private string scheduleContent;
        public string ScheduleContent
        {
            get { return scheduleContent; }
            set
            {
                scheduleContent = value;
            }
        }

        private string name;
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
            }
        }

        private DateTime selectedStartDate;
        public DateTime SelectedStartDate
        {
            get { return selectedStartDate; }
            set
            {
                selectedStartDate = value;
            }
        }

        private DateTime selectedEndDate;
        public DateTime SelectedEndDate
        {
            get { return selectedEndDate; }
            set
            {
                selectedEndDate = value;
            }
        }
        #endregion

        
        private ICommand scheduleAddButtonClick;
        public ICommand ScheduleAddButtonClick => scheduleAddButtonClick = 
            scheduleAddButtonClick ?? new RelayCommand(AddButtonClick, CanButtonCmdExe);

        #region ButtonEvent
        private void AddButtonClick()
        {
            MessageBox.Show(ScheduleContent);
            MessageBox.Show(Name);
            MessageBox.Show(SelectedStartDate.ToString("yyyy/MM/dd"));
            MessageBox.Show(SelectedEndDate.ToString("yyyy/MM/dd"));
        }
        private bool CanButtonCmdExe()
        {
            return true;
        }
        #endregion

    }
}
