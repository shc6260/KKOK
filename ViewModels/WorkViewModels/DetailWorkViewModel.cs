using GalaSoft.MvvmLight.Command;
using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using KKOK.Views.WorkView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace KKOK.ViewModels
{
    internal class DetailWorkViewModel : ViewModelBase
    {
        private ICommand btnStateShow;

        public ICommand BtnStateShow => btnStateShow = btnStateShow ?? new RelayCommand(ButtonStateShow, CanBtn);

        private void ButtonStateShow()
        {
            StateChangeView stateChangeView = new StateChangeView();
            var viewModel = new StateChangeViewModel();
            stateChangeView.DataContext = viewModel;
            stateChangeView.Show();
        }

        private bool CanBtn()
        {
            return true;
        }
    }
}
