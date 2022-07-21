using GalaSoft.MvvmLight.Command;
using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using KKOK.Views.WorkView;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels
{
    internal class StateChangeViewModel : ViewModelBase
    {
        public StateChangeViewModel()
        {
            StateItem = new ObservableCollection<string>();
            StateItem.Add("열기");
            StateItem.Add("진행");
            StateItem.Add("완료");
            StateItem.Add("재진행");
            StateItem.Add("닫힘");
            ButtonSave = new DelegateCommand(ButtonSaveCommand);
        }

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
            set { manager = value;
                OnPropertyChanged(Manager);
            }
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
            set { workType = value;
                OnPropertyChanged(WorkType);
            }
        }


        public DelegateCommand ButtonSave { get; set; }

        private ObservableCollection<string> stateItem;

        public ObservableCollection<string> StateItem
        {
            get { return stateItem; }
            set { stateItem = value;
                
            }
        }

        private string selectedState;
        public string SelectedState
        {
            get { return selectedState; }
            set { selectedState = value;
                OnPropertyChanged(SelectedState);
            }
        }
        #endregion

        #region ButtonEvent
        private void ButtonSaveCommand()
        {
            MessageBox.Show("상태 : " + SelectedState +" 담당자 : " + Manager + " 종류 : " + WorkType + " 상세 내용 : " + DetailWorkData);
        }
        #endregion
    }
}
