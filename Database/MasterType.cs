using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBase
{
    [Table(Name = "MASTER_TYPE")]
    public class MasterType
    {
        [Column(Name = "MASTER_TYPE_ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int MasterTypeId { get; set; }

        [Column(Name = "CODIGO", CanBeNull = false, DbType = "STRING")]
        public string Codigo { get; set; }

        [Column(Name = "TIPO", CanBeNull = false, DbType = "STRING")]
        public string Tipo { get; set; }
    }
}
