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
            ButtonAddCommand = new DelegateCommand(ButtonAddPush);
        } 
        #endregion

        #region properties
        private string workTitle;
        public string WorkTitle
        {
            get { return workTitle; }
            set { workTitle = value;
                OnPropertyChanged(WorkTitle);
            }
        }
        private string detailWorkData;
        public string DetailWorkData
        {
            get { return detailWorkData; }
            set { detailWorkData = value;
                OnPropertyChanged(DetailWorkData);
            }
        }
        private string secheduleData;
        public string SecheduleData
        {
            get { return secheduleData; }
            set { secheduleData = value;
                OnPropertyChanged(SecheduleData);
            }
        }
        private string manager;
        public string Manager
        {
            get { return manager; }
            set { manager = value;
                OnPropertyChanged(Manager);
            }
        }

        private DateTime endDate = DateTime.Now;
        public DateTime EndDate
        {
            get { return endDate; }
            set { endDate = value;
            }
        }

        private string workType;

        public string WorkType
        {
            get { return workType; }
            set { workType = value;
                OnPropertyChanged(WorkType);
            }
        }

        #endregion


        public DelegateCommand ButtonAddCommand { get; set; }


        #region ButtonEvent
        private void ButtonAddPush()
        {
            MessageBox.Show(WorkTitle);
            MessageBox.Show(DetailWorkData);
            MessageBox.Show(SecheduleData);
            MessageBox.Show(Manager);
            MessageBox.Show(EndDate.ToString("yyyy/MM/dd"));
            MessageBox.Show(WorkType);
        }
        #endregion
    }
}
