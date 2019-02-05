using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWallet.Messages
{
    public class ContactoRequest
    {
        public int ContactoId { get; set; }
        public int EntidadId { get; set; }
        public int ContactoTelefono { get; set; }
        public string ContactoCorreo { get; set; }
        public string ContactoDetalle { get; set; }
    }
}
