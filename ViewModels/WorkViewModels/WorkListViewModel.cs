using GalaSoft.MvvmLight.Command;
using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using KKOK.ViewModels.WorkViewModels;
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
    internal class WorkListViewModel : ViewModelBase
    {
        public WorkListViewModel()
        {
            Popup popup = new Popup();
            ButtonAddPopup = new DelegateCommand(popup.ButtonAddWorkShow);
            ButtonStatePopup = new DelegateCommand(popup.ButtonStateShow);
        }
   /*     public WorkListViewModel(ViewModelBase parent):base(parent)
        {

        }*/
        #region properties
        /*private ObservableCollection<WorkListModel> inneritems
        { get; } = new ObservableCollection<WorkListModel>();

        private ReadOnlyObservableCollection<WorkListModel> items;
        public ReadOnlyObservableCollection<WorkListModel> Items
        {
            get
            {
                if(items == null) 
                {
                    items = new ReadOnlyObservableCollection<WorkListModel>(inneritems);
                    inneritems.Add();
                }
                return items;
            }
        }*/

        private ObservableCollection<WorkListModel> item;

        public ObservableCollection<WorkListModel> Item
        {
            get
            {
                if (item == null)
                {
                    item = new ObservableCollection<WorkListModel>();
                    item.Add(new WorkListModel() { No = 1, WorkTitle = "test1", Manager = "이선웅", State = "열림" });
                    item.Add(new WorkListModel() { No = 2, WorkTitle = "test2", Manager = "이선웅", State = "닫힘" });
                }
                return item;
            }
        }

        #region DelegateCommands
        public DelegateCommand ButtonAddPopup { get; set; }
        public DelegateCommand ButtonStatePopup { get; set; } 
        #endregion


        #endregion

        private WorkListModel _selectedItem;

        public WorkListModel SelectedItem
        {
            get => _selectedItem;
            set
            {
                if(SetProperty(ref _selectedItem, value))
                {
                    OnChangedSelectedType();
                    MessageBox.Show(SelectedItem.State + " " + SelectedItem.WorkTitle + " " + SelectedItem.Manager);
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
