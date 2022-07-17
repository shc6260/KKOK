using GalaSoft.MvvmLight.Command;
using KKOK.Models;
using KKOK.ViewModels.Main;
using System;
using System.Collections.Generic;
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
        
        
        #region properties
        private string workTitle;
        public string WorkTitle
        {
            get { return workTitle; }
            set { workTitle = value; }
        }
        private string detailWorkData;
        public string DetailWorkData
        {
            get { return detailWorkData; }
            set { detailWorkData = value; }
        }
        private string secheduleData;
        public string SecheduleData
        {
            get { return secheduleData; }
            set { secheduleData = value; }
        }
        private string manager;
        public string Manager
        {
            get { return manager; }
            set { manager = value; }
        }
        private string state;
        public string State
        {
            get { return state; }
            set { state = value; }
        }
        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value; }
        }

        private string workType;

        public string WorkType
        {
            get { return workType; }
            set { workType = value; }
        }

        private ICommand btnAddCmd;

        public ICommand BtnAddCmd => btnAddCmd = btnAddCmd ?? new RelayCommand(ButtonAddCmd, ButtonCanCmd);
        #endregion

        #region ButtonEvent
        private void ButtonAddCmd()
        {
            MessageBox.Show(WorkTitle);
            MessageBox.Show(DetailWorkData);
            MessageBox.Show(SecheduleData);
            MessageBox.Show(Manager);
            MessageBox.Show(State);
            MessageBox.Show(EndDate.ToString("yyyy/MM/dd"));
            MessageBox.Show(WorkType);
        }
        private bool ButtonCanCmd()
        {
            return true;
        } 
        #endregion
    }
}
