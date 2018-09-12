using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class HistorialTarjetaCredito
    {
        public int Id { get; set; }
        public int PagoId { get; set; }
        public int NumeroCuotas { get; set; }
        public int CuotaActual { get; set; }
        public int MontoTotal { get; set; }
        public string FechaVencimiento { get; set; }
    }
}
