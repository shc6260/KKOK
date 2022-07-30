    using KKOK.Models.Datas;
using KKOK.Types;
using KKOK.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace KKOK.ViewModels.MainViewModels
{
    internal class MainListItemViewModel : ViewModelBase
    {
        #region Constructors
        public MainListItemViewModel(FunctionsType type, string name, string iconPath)
        {
            Type = type;
            Name = name;
            IconPath = iconPath;
        }
        #endregion


        #region Bindable Properties
        private FunctionsType _type;

        public FunctionsType Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }

        private string _name;


        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private string _iconPath;

        public string IconPath
        {
            get => _iconPath;
            set => SetProperty(ref _iconPath, value);
        }

        #endregion

        #region Helpers
        public static MainListItemViewModel From(FunctionListitemData data)
        {
            return new MainListItemViewModel
            (
                type: data.Type,
                name: data.Name,
                iconPath: data.IconPath
            );
        }
        #endregion
    }
}
