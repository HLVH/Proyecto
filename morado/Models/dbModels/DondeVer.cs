using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace morado.Models.dbModels
{
    [Table("Donde ver")]
    public partial class DondeVer
    {
        [Key]
        public int IdComentarios { get; set; }
        [StringLength(200)]
        public string Comentario { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }
        public int IdUsuario { get; set; }
        public int IdContenido { get; set; }

        [ForeignKey("IdContenido")]
        [InverseProperty("DondeVers")]
        public virtual Contenido IdContenidoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("DondeVers")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
