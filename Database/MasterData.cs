using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Linq.Mapping;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ColumnAttribute = System.Data.Linq.Mapping.ColumnAttribute;
using TableAttribute = System.Data.Linq.Mapping.TableAttribute;

namespace DataBase
{
    [Table(Name = "MASTER_DATA")]
    public class MasterData
    {
        [Column(Name = "MASTER_DATA_ID", IsDbGenerated = true, IsPrimaryKey = true, DbType = "INTEGER")]
        [Key]
        public int MasterTypeId { get; set; }

        [Column(Name = "CODIGO", CanBeNull = false, DbType = "STRING")]
        public string Codigo { get; set; }

        [Column(Name = "TEXTO", CanBeNull = false, DbType = "STRING")]
        public string Texto { get; set; }

        [Column(Name = "FK_MASTER_TYPE_ID", CanBeNull = false, DbType = "INTEGER")]
        [ForeignKey("MasterType")]
        public string TipoId { get; set; }

        public MasterType MasterType { get; }
    }
}
