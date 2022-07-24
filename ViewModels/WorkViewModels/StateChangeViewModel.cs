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
        #region Constructor
        public StateChangeViewModel()
        {
            StateItem = new ObservableCollection<string>();
            StateItem.Add("열기");
            StateItem.Add("진행");
            StateItem.Add("완료");
            StateItem.Add("재진행");
            StateItem.Add("닫힘");
        } 
        #endregion

        #region properties
        private string detailWorkData;
        public string DetailWorkData
        {
            get => detailWorkData;
            set => SetProperty(ref detailWorkData, value);
        }
        private string manager;
        public string Manager
        {
            get => manager;
            set => SetProperty(ref manager, value);
        }

        private string workType;

        public string WorkType
        {
            get => workType;
            set => SetProperty(ref workType, value);
        }

        private ObservableCollection<string> stateItem;

        public ObservableCollection<string> StateItem
        {
            get => stateItem;
            set => SetProperty(ref stateItem, value);
        }

        private string selectedState;
        public string SelectedState
        {
            get => selectedState;
            set => SetProperty(ref selectedState, value);
        }
        #endregion

        #region DelegateCommand
        private DelegateCommand buttonSave { get; set; }
        public DelegateCommand ButtonSave => buttonSave = buttonSave ?? new DelegateCommand(ButtonSaveCommand); 
        #endregion

        #region ButtonEvent
        private void ButtonSaveCommand()
        {
            MessageBox.Show("상태 : " + SelectedState + " 담당자 : " + Manager + " 종류 : " + WorkType + " 상세 내용 : " + DetailWorkData);
        }
        #endregion
    }
}
