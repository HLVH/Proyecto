using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace morado.Models.dbModels
{
    public partial class Opinione
    {
        [StringLength(200)]
        public string Comentario { get; set; } = null!;
        [Column(TypeName = "date")]
        public DateTime FechaDePublicado { get; set; }
        [Column("EstrellasDadas(1-5)")]
        [StringLength(120)]
        public string EstrellasDadas15 { get; set; } = null!;
        [Key]
        public int IdUsuario { get; set; }
        [Key]
        public int IdContenido { get; set; }

        [ForeignKey("IdContenido")]
        [InverseProperty("Opiniones")]
        public virtual Contenido IdContenidoNavigation { get; set; } = null!;
        [ForeignKey("IdUsuario")]
        [InverseProperty("Opiniones")]
        public virtual ApplicationUser IdUsuarioNavigation { get; set; } = null!;
    }
}
