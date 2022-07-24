using KKOK.Views.WorkView;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.ViewModels.WorkViewModels
{
    public class Popup
    {
        public void ButtonStateShow()
        {
            StateChangeView stateChangeView = new StateChangeView();
            var viewModel = new StateChangeViewModel();
            stateChangeView.DataContext = viewModel;
            stateChangeView.Show();
        }
    }
}
