using GalaSoft.MvvmLight.Command;
using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels
{
    internal class StateChangeViewModel : ViewModelBase
    {
        WorkListModel list = new WorkListModel();

        #region properties
        private string detailWorkData;
        public string DetailWorkData
        {
            get { return detailWorkData; }
            set { detailWorkData = value;
                OnPropertyChanged(DetailWorkData);
            }
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
            set { state = value;
                OnPropertyChanged(State);
            }
        }
        private string workType;

        public string WorkType
        {
            get { return workType; }
            set { workType = value; }
        }

        private ICommand btnSaveCmd;

        public ICommand BtnSaveCmd => btnSaveCmd = btnSaveCmd ?? new RelayCommand(ButtonSaveCmd, ButtonCanCmd);
        #endregion

        #region ButtonEvent
        private void ButtonSaveCmd()
        {
            MessageBox.Show(DetailWorkData);
            MessageBox.Show(Manager);
            MessageBox.Show(State);
            MessageBox.Show(WorkType);
        }
        private bool ButtonCanCmd()
        {
            return true;
        }
        #endregion
    }
}
