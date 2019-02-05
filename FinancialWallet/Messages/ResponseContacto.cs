using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialWallet.Messages
{
    public class ResponseContacto : ResponseBase
    {
        public Contacto Contacto { get; set; }
        public IList<Contacto> ListaContactos { get; set; }
    }
}
