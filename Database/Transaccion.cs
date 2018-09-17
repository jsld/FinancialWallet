using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Transaccion
    {
        public int Id { get; set; }
        public int TipoTransaccionId { get; set; }
        public string Descripcion { get; set; }
        public int ServicioId { get; set; }
        public int EmpresaId { get; set; }
        public int MontoTotal { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }
        
        public MasterData TipoTransaccion { get; set; }
        public Servicio Servicio { get; set; }
        public Empresa Empresa { get; set; }
        public MasterData Estado { get; set; }
    }
}
