using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKOK.Managers;
using KKOK.Types;
using KKOK.ViewModels;
using KKOK.ViewModels.Main;

namespace KKOK.ViewModels.MainViewModels
{
    internal class MainViewModel : ViewModelBase 
    {
        private MainListViewModel _mainListViewModel;

        public MainListViewModel MainListViewModel
        {
            get
            {
                if(_mainListViewModel == null)
                {
                    _mainListViewModel = new MainListViewModel();
                    _mainListViewModel.Items = new ObservableCollection<MainListItemViewModel>(FunctionListDataManager.Instance.GetFunctionListData().Select(MainListItemViewModel.From));
                    _mainListViewModel.ChangedSelectedType += (_, __) => OnChangedViewModel();
                }
                return _mainListViewModel;
            }
        }

        private MainLeftViewModel _mainLeftViewModel;

        public MainLeftViewModel MainLeftViewModel
        {
            get
            {
                if (_mainLeftViewModel == null)
                {
                    _mainLeftViewModel = new MainLeftViewModel();
                }
                return _mainLeftViewModel;
            }
        }

        private ViewModelBase _leftContent;

        public ViewModelBase LeftContent
        {
            get => _leftContent;
            set => SetProperty(ref _leftContent, value);
        }

        private MainRightViewModel _mainRightViewModel;

        public MainRightViewModel MainRightViewModel
        {
            get
            {
                if (_mainRightViewModel == null)
                {
                    _mainRightViewModel = new MainRightViewModel();
                }
                return _mainRightViewModel;
            }
        }

        private ViewModelBase _rightContent;

        public ViewModelBase RightContent
        {
            get => _rightContent;
            set => SetProperty(ref _rightContent, value);
        }

        private void OnChangedViewModel()
        {
            switch (_mainListViewModel.SelectedType.Type)
            {
                /*case FunctionsType.Home:
                    MainLeftViewModel.LeftContent = new HomeViewModel();
                    break;*/
                case FunctionsType.Chart:
                    MainLeftViewModel.LeftContent = new ScheduleDiagramViewModel();
                    MainRightViewModel.RightContent = new ScheduleDiagramDetailViewModel();
                    break;
                case FunctionsType.Work:
                    MainLeftViewModel.LeftContent = new WorkListViewModel();
                    MainRightViewModel.RightContent = new DetailWorkViewModel();
                    break;
                /*case FunctionsType.Chat:
                    MainLeftViewModel.LeftContent = new CheatListViewModel();
                    break;*/
                case FunctionsType.Team:
                    MainLeftViewModel.LeftContent = new MemberViewModel();
                    MainRightViewModel.RightContent = null;
                    break;
            }
        }
    }
}
