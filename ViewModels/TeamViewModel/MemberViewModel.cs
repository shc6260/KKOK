using KKOK.Models.WorkModel;
using KKOK.ViewModels.Main;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.ViewModels
{
    internal class MemberViewModel : ViewModelBase
    {
        #region Properties
        private ObservableCollection<MemberListItemViewModel> innermembers
        { get; } = new ObservableCollection<MemberListItemViewModel>();

        private ReadOnlyObservableCollection<MemberListItemViewModel> members;

        public ReadOnlyObservableCollection<MemberListItemViewModel> Members
        {
            get
            {
                if (members == null)
                {
                    members = new ReadOnlyObservableCollection<MemberListItemViewModel>(innermembers);
                    innermembers.Add(new MemberListItemViewModel() { Name = "신희찬", Job = "팀장" });
                    innermembers.Add(new MemberListItemViewModel() { Name = "김태홍", Job = "팀장" });
                    innermembers.Add(new MemberListItemViewModel() { Name = "이선웅", Job = "팀원" });
                    innermembers.Add(new MemberListItemViewModel() { Name = "이석종", Job = "팀원" });
                    innermembers.Add(new MemberListItemViewModel() { Name = "황성진", Job = "팀원" });

                }
                return members;
            }
        } 
        #endregion
    }
}
