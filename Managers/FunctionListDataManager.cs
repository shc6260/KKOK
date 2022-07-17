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

            items.Add(new FunctionListitemData(FunctionsType.home, "홈"));
            items.Add(new FunctionListitemData(FunctionsType.chart, "상황도"));
            items.Add(new FunctionListitemData(FunctionsType.work, "개인업무"));
            items.Add(new FunctionListitemData(FunctionsType.cheat, "채팅채널"));
            items.Add(new FunctionListitemData(FunctionsType.team, "팀"));

            return items;
        }
    }
}
