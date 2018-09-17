using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Tarjetas
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int BancoId { get; set; }
        public int TipoTarjetaId { get; set; }
        
        public MasterData Banco { get; set; }
        public MasterData TipoTarjeta { get; set; }
    }
}
