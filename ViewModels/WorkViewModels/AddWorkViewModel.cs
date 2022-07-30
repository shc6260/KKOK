using GalaSoft.MvvmLight.Command;
using KKOK.Models;
using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels
{
    internal class AddWorkViewModel : ViewModelBase
    {
        #region Constructor
        public AddWorkViewModel()
        {
            
        }
        #endregion

        #region properties

        private int no =1;
        
        private string workTitle;
        public string WorkTitle
        {
            get => workTitle;
            set => SetProperty(ref workTitle, value);
        }
        private string detailWorkData;
        public string DetailWorkData
        {
            get => detailWorkData;
            set => SetProperty(ref detailWorkData, value);
        }
        private string secheduleData;
        public string SecheduleData
        {
            get => secheduleData;
            set => SetProperty(ref secheduleData, value);
        }
        private string manager;
        public string Manager
        {
            get => manager;
            set => SetProperty(ref manager, value);
        }

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get => endDate;
            set => SetProperty(ref endDate, value);
        }

        private string workType;

        public string WorkType
        {
            get => workType;
            set => SetProperty(ref workType, value);
        }

        #endregion

        #region DelegateCommand
        private DelegateCommand buttonAddCommand;
        public ICommand ButtonAddCommand => buttonAddCommand = buttonAddCommand ?? new DelegateCommand(ButtonAddWork); 
        #endregion

        #region ButtonEvent
        private void ButtonAddWork()
        {
            MessageBox.Show("업무를 추가했습니다.");
            OnAddWorkButtonClick();
        }

        public WorkListData GetAddWorkListData()
        {
            return WorkListData.From((no++, WorkTitle, Manager, "열기"));
        }

        public EventHandler AddButtonClick;

        private void OnAddWorkButtonClick()
        {
            AddButtonClick?.Invoke(this, new EventArgs());
        }

        
        #endregion

    }
}
