using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Servicio
    {
        public int Id { get; set; }
        public int DescripcionId { get; set; }
        public string Nombre { get; set; }
        public int TipoAdjudicacionId { get; set; }
        public int EstadoId { get; set; }
        public string FechaAdjudicacion { get; set; }
        public string FechaInicio { get; set; }
        public string FechaTermino { get; set; }
    }
}
