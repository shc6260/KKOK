﻿using GalaSoft.MvvmLight.Command;
using KKOK.ViewModels.Main;
using KKOK.ViewModels.WorkViewModels;
using KKOK.Views.WorkView;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KKOK.ViewModels
{
    internal class DetailWorkViewModel : ViewModelBase
    {
        #region Constructor
        public DetailWorkViewModel()
        {

        }
        #endregion

        #region properties
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
        Popup popup = new Popup();
        private DelegateCommand buttonStatePopup;
        public DelegateCommand ButtonStatePopup => buttonStatePopup = buttonStatePopup ?? new DelegateCommand(popup.ButtonStateShow); 
        #endregion
    }
}
