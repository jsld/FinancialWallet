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
        public int TipoDeServicioId { get; set; }
        public string Name { get; set; }
        public int TipoAdjudicacionId { get; set; }
        public int EstadoId { get; set; }
        public bool Facturado { get; set; }
        public int Valor { get; set; }
        public int? Costo { get; set; }
        public DateTime FechaAdjudicacion { get; set; }
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaTermino { get; set; }

        public MasterData TipoDeServicio { get; set; }
        public MasterData TipoAdjudicacion { get; set; }
        public MasterData Estado { get; set; }
    }
}
