using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KKOK.ViewModels.Main;
using KKOK.ViewModels;

namespace KKOK.ViewModels.MainViewModels
{
    internal class MainLeftViewModel :ViewModelBase
    {
        private ViewModelBase _leftContent;

        public ViewModelBase LeftContent
        {
            get => _leftContent;
            set
            {
                SetProperty(ref _leftContent, value);
                RaisePropertyChanged(nameof(LeftContent));
            }
        }
    }
}
