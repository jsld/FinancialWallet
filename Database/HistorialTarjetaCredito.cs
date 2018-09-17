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
        public int TarjetaId { get; set; }
        public int NumeroCuotas { get; set; }
        public int MontoTotal { get; set; }
        public int? HistorialTarjetaId { get; set; }
        public int? Cuota { get; set; }
        public int? MontoCuota { get; set; }
        public DateTime? VencimientoCuota { get; set; }

        public Pagos Pagos { get; set; }
        public Tarjetas Tarjetas { get; set; }
        public HistorialTarjetaCredito HistorialTC { get; set; }
    }
}
