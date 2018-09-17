using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Empresa
    {
        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int TipoEmpresaId { get; set; }

        public MasterData TipoEmpresa { get; set; }
    }
}
