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
    [Table("CONTACTO")]
    public class Contacto
    {
        [Column("CONTACTO_ID")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ContactoId { get; set; }

        [Column("FK_ENTIDAD_ID")]
        [ForeignKey("Entidad")]
        public int EntidadId { get; set; }

        [Column("TELEFONO")]
        public int Telefono { get; set; }

        [Column("CORREO")]
        public string Correo { get; set; }

        [Column("DETALLE")]
        public string Detalle { get; set; }

        public virtual Entidad Entidad { get; set; }
    }
}
