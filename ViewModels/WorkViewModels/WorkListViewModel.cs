﻿using GalaSoft.MvvmLight.Command;
using KKOK.ViewModels.Main;
using KKOK.ViewModels.WorkViewModels;
using KKOK.Views.WorkView;
using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace KKOK.ViewModels
{
    internal class WorkListViewModel : ViewModelBase
    {
        #region Constructor
        public WorkListViewModel()
        {
            WorkListCollection = CollectionViewSource.GetDefaultView(Items);
        } 
        #endregion

        #region NameFilter
        private bool FilterByName(object workList)
        {
            if (!string.IsNullOrEmpty(NameToFillter))
            {
                var WorkList = workList as WorkListItemViewModel;
                return WorkList != null && WorkList.Manager.Contains(NameToFillter);
            }
            return true;
        }

        private string nameToFillter;
   
        public string NameToFillter
        {
            get => nameToFillter;
            set
            {
                SetProperty(ref nameToFillter, value);
                workListCollection.Filter = FilterByName;
            }
        }


        private ICollectionView workListCollection;

        public ICollectionView WorkListCollection
        {
            get => workListCollection;
            set => SetProperty(ref workListCollection, value);
        } 
        #endregion

        /*public WorkListViewModel(ViewModelBase parent):base(parent)
{

}*/

        #region properties
        private ObservableCollection<WorkListItemViewModel> inneritems
        { get; } = new ObservableCollection<WorkListItemViewModel>();

        private ReadOnlyObservableCollection<WorkListItemViewModel> items;
        public ReadOnlyObservableCollection<WorkListItemViewModel> Items
        {
            get
            {
                if (items == null)
                {
                    items = new ReadOnlyObservableCollection<WorkListItemViewModel>(inneritems);
                    inneritems.Add(new WorkListItemViewModel() {No=1,WorkTitle="test1",Manager="이선웅",State="열기"});
                    inneritems.Add(new WorkListItemViewModel() { No = 2, WorkTitle = "test1", Manager = "신희찬", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 3, WorkTitle = "test1", Manager = "김태홍", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 4, WorkTitle = "test1", Manager = "이석종", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 5, WorkTitle = "test1", Manager = "황성진", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 1, WorkTitle = "test1", Manager = "이선웅", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 2, WorkTitle = "test1", Manager = "신희찬", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 3, WorkTitle = "test1", Manager = "김태홍", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 4, WorkTitle = "test1", Manager = "이석종", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 5, WorkTitle = "test1", Manager = "황성진", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 1, WorkTitle = "test1", Manager = "이선웅", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 2, WorkTitle = "test1", Manager = "신희찬", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 3, WorkTitle = "test1", Manager = "김태홍", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 4, WorkTitle = "test1", Manager = "이석종", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 5, WorkTitle = "test1", Manager = "황성진", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 1, WorkTitle = "test1", Manager = "이선웅", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 2, WorkTitle = "test1", Manager = "신희찬", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 3, WorkTitle = "test1", Manager = "김태홍", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 4, WorkTitle = "test1", Manager = "이석종", State = "열기" });
                    inneritems.Add(new WorkListItemViewModel() { No = 5, WorkTitle = "test1", Manager = "황성진", State = "열기" });
                }
                return items;
            }
        }
        #endregion

        #region DelegateCommands
        private Popup popup = new Popup();

        private DelegateCommand buttonAddPopup;
        public ICommand ButtonAddPopup => buttonAddPopup = buttonAddPopup ?? new DelegateCommand(ButtonAddWorkShow);

        private DelegateCommand buttonStatePopup;
        public ICommand ButtonStatePopup => buttonStatePopup = buttonStatePopup ?? new DelegateCommand(popup.ButtonStateShow);
        #endregion
        


        #region ButtonAddWorkShow
        public void ButtonAddWorkShow()
        {
            AddWorkView add = new AddWorkView();
            var viewModel = new AddWorkViewModel();
            add.DataContext = viewModel;
            add.Show();
            
            viewModel.AddButtonClick += (_, __) => inneritems.Add(WorkListItemViewModel.From(viewModel.GetAddWorkListData()));
        } 
        #endregion

        #region SelectedItem
        private WorkListItemViewModel selectedItem;

        public WorkListItemViewModel SelectedItem
        {
            get => selectedItem;
            set
            {
                if (SetProperty(ref selectedItem, value))
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
        #endregion

    }
}

