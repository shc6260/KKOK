using KKOK.Models.Datas;
using KKOK.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.Managers
{
    internal class FunctionListDataManager 
    {
        private static FunctionListDataManager _instance;
        public static FunctionListDataManager Instance => _instance ?? (_instance = new FunctionListDataManager());

        private IEnumerable<FunctionListitemData> _items = null;

        public IEnumerable<FunctionListitemData> GetFunctionListData()
        {
            if (_items != null)
            {
                return _items;
            }

            var items = new List<FunctionListitemData>();

            items.Add(new FunctionListitemData(FunctionsType.Home, "홈화면", "/Icons/home.png"));
            items.Add(new FunctionListitemData(FunctionsType.Chart, "상황도", "/Icons/chart.png"));
            items.Add(new FunctionListitemData(FunctionsType.Work, "개인업무", "/Icons/work.png"));
            items.Add(new FunctionListitemData(FunctionsType.Chat, "채팅채널", "/Icons/chat.png"));
            items.Add(new FunctionListitemData(FunctionsType.Team, "멤버", "/Icons/group.png"));
            
            

            return items;
        }
    }
}
