using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWallet.Messages
{
    public class EntidadRequest
    {

        public int EntidadTipoId { get; set; }

        public string EntidadTipoCode { get; set; }

        public string EntidadNombre { get; set; }

        public string EntidadCode { get; set; }
    }
}
