using GalaSoft.MvvmLight.Command;
using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using KKOK.Views.WorkView;
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
    internal class WorkListViewModel : ViewModelBase
    {
        #region properties
        private ObservableCollection<WorkListModel> items;

        public ObservableCollection<WorkListModel> Items
        {
            get
            {
                if(items == null)
                {
                    items = new ObservableCollection<WorkListModel>();
                    items.Add(new WorkListModel() { No = 1, WorkTitle = "test1",Manager="이선웅", State = "열림" });
                    items.Add(new WorkListModel() { No = 2, WorkTitle = "test2", Manager = "이선웅", State = "닫힘" });
                }
                return items;
            }
        }

        private ICommand btnAddWorkShow;
        private ICommand btnStateShow;

        public ICommand BtnAddWorkShow => btnAddWorkShow = btnAddWorkShow ?? new RelayCommand(ButtonAddWorkShow, CanBtn);
        public ICommand BtnStateShow => btnStateShow = btnStateShow ?? new RelayCommand(ButtonStateShow, CanBtn);
        #endregion

        private WorkListModel _selectedType;

        public WorkListModel SelectedType
        {
            get => _selectedType;
            set
            {
                if(SetProperty(ref _selectedType, value))
                {
                    OnChangedSelectedType();
                    MessageBox.Show(SelectedType.State + " " + SelectedType.WorkTitle + " " + SelectedType.Manager);
                }
            }
        }
        public EventHandler ChangedSelectedType;

        private void OnChangedSelectedType()
        {
            ChangedSelectedType?.Invoke(this, EventArgs.Empty);
        }


        #region ButtonEvent
        private void ButtonAddWorkShow()
        {
            AddWorkView add = new AddWorkView();
            var viewModel = new AddWorkViewModel();
            add.DataContext = viewModel;
            add.Show();
        }

        private void ButtonStateShow()
        {
            StateChangeView stateChangeView = new StateChangeView();
             var viewModel = new StateChangeViewModel();
             stateChangeView.DataContext = viewModel;
             viewModel.WorkType = SelectedType.WorkTitle;
             stateChangeView.Show();
        }

        private bool CanBtn()
        {
            return true;
        } 
        #endregion
    }
}
