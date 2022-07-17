using GalaSoft.MvvmLight.Command;
using KKOK.ViewModels.Main;
using KKOK.Views.MainViews;
using KKOK.Views.WorkView;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace KKOK.ViewModels.MainViewModels
{
    internal class MainListViewModel : ViewModelBase
    {

        private ObservableCollection<MainListItemViewModel> _items;

        public ObservableCollection<MainListItemViewModel> Items
        {
            get => _items;
            set => SetProperty(ref _items, value);
        }

        private MainListItemViewModel _selectedType;

        public MainListItemViewModel SelectedType
        {
            get => _selectedType;
            set
            {
                if (SetProperty(ref _selectedType, value))
                {
                    OnChangedSelectedType();
                }
            }
        }

        public EventHandler ChangedSelectedType;

        private void OnChangedSelectedType()
        {
            ChangedSelectedType?.Invoke(this, EventArgs.Empty);
        }
    }
}
