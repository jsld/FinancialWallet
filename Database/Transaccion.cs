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
        public string FechaCreacion { get; set; }
        public string FechaModificacion { get; set; }
        public int ServicioId { get; set; }
        public int EmpresaId { get; set; }
    }
}
