using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataBase
{
    [Table("ENTIDAD")]
    public class Entidad
    {
        [Column("ENTIDAD_ID")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntidadId { get; set; }

        [Column("NOMBRE")]
        public string Codigo { get; set; }

        [Column("CODIGO")]
        public string Texto { get; set; }

        [Column("TIPO")]
        [ForeignKey("MasterData")]
        public int TipoId { get; set; }

        public virtual MasterData MasterData { get; set; }
    }
}
