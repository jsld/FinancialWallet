using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class MasterData
    {
        public int Id { get; set; }
        public int MasterTypeId { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }

        public MasterType MasterType { get; set; }
    }
}
