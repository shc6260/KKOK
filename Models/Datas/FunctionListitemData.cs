using KKOK.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KKOK.Models.Datas
{
    internal class FunctionListitemData
    {
        public FunctionListitemData(FunctionsType type, string name, string iconpath)
        {
            this.Type = type;
            this.Name = name;
            this.IconPath = iconpath;
        }

        public FunctionsType Type { get;  }

        public string Name { get;  }

        public string IconPath { get;  } //from만들기
    }
}
