using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Pagos
    {
        public int Id { get; set; }
        public int TransaccionId { get; set; }
        public int Monto { get; set; }
        public int TipoDePagoId { get; set; }

        public Transaccion Transaccion { get; set; }
        public MasterData TipoDePago { get; set; }
    }
}
