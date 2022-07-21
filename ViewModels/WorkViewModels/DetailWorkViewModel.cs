using GalaSoft.MvvmLight.Command;
using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using KKOK.ViewModels.WorkViewModels;
using KKOK.Views.WorkView;
using Prism.Commands;
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
        public DetailWorkViewModel()
        {
            Popup popup = new Popup();
            ButtonStatePopup = new DelegateCommand(popup.ButtonStateShow);
        }

        public DelegateCommand ButtonStatePopup { get; set; }

    }
}
