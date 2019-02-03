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
    [Table("MASTER_DATA")]
    public class MasterData
    {
        [Column("MASTER_DATA_ID")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MasterDataId { get; set; }

        [Column("CODIGO")]
        public string Codigo { get; set; }

        [Column("TEXTO")]
        public string Texto { get; set; }

        [Column("FK_MASTER_TYPE_ID")]
        [ForeignKey("MasterType")]
        public int TipoId { get; set; }
        
        public virtual MasterType MasterType { get; set; }
    }
}
