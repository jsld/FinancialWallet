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
        public int MontoTotal { get; set; }
        public int TotalAbonado { get; set; }
        public int TipoTransaccionId { get; set; }
        public int EstadoTransaccionId { get; set; }
    }
}
