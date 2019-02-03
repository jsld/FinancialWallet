using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    [Table("MASTER_TYPE")]
    public class MasterType
    {
        [Column("MASTER_TYPE_ID")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MasterTypeId { get; set; }

        [Column("CODIGO")]
        public string Codigo { get; set; }

        [Column("TIPO")]
        public string Tipo { get; set; }
    }
}
