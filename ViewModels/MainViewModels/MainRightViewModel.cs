using KKOK.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.ViewModels.MainViewModels
{
    internal class MainRightViewModel :ViewModelBase
    {
        private ViewModelBase _rightContent;

        public ViewModelBase RightContent
        {
            get => _rightContent;
            set
            {
                SetProperty(ref _rightContent, value);
                RaisePropertyChanged(nameof(RightContent));
            }
        }
    }
}
