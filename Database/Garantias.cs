using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Garantias
    {
        public int Id { get; set; }
        public int? ServicioId { get; set; }
        public int? TransaccionId { get; set; }
        public int TipoDePagoId { get; set; }
        public int Monto { get; set; }
        public int EmpresaOtorgaId { get; set; }
        public int EmpresaRecibeId { get; set; }

        public Servicio Servicio { get; set; }
        public Transaccion Transaccion { get; set; }
        public MasterData TipoDePago { get; set; }
        public Empresa EmpresaOtorga { get; set; }
        public Empresa EmpresaRecibe { get; set; }
    }
}
