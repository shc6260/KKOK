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
        private ObservableCollection<MemberModel> innermember
        { get; } = new ObservableCollection<MemberModel>();

        private ReadOnlyObservableCollection<MemberModel> members;

        public ReadOnlyObservableCollection<MemberModel> Members
        {
            get
            {
                if (members == null)
                {
                    members = new ReadOnlyObservableCollection<MemberModel>(innermember);
                    innermember.Add(new MemberModel() { Name = "신희찬", Job = "팀장" });
                    innermember.Add(new MemberModel() { Name = "김태홍", Job = "팀장" });
                    innermember.Add(new MemberModel() { Name = "이선웅", Job = "팀원" });
                    innermember.Add(new MemberModel() { Name = "이석종", Job = "팀원" });
                    innermember.Add(new MemberModel() { Name = "황성진", Job = "팀원" });

                }
                return members;
            }
        } 
        #endregion
    }
}
