using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBase;

namespace FinancialWallet.Messages
{
    public class ResponseEntity : ResponseBase
    {
        public Entidad Entidad { get; set; }

        public IList<Entidad> ListaEntidades { get; set; }
    }
}
