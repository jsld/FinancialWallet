using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWallet.Models
{
    public class EmpresaViewModel
    {
        public int? Id;
        public string Code;
        public string Name;
        public int Type;

        public EmpresaViewModel(int? Id, string Code, string Name, int Type )
        {
            this.Id = Id;
            this.Code = Code;
            this.Name = Name;
            this.Type = Type;
        }
    }
}
