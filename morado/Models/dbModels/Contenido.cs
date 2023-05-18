using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace morado.Models.dbModels
{
    [Table("Contenido")]
    public partial class Contenido
    {
        public Contenido()
        {
            DondeVers = new HashSet<DondeVer>();
            Opiniones = new HashSet<Opinione>();
            Temporas = new HashSet<Tempora>();
        }

        [Key]
        public int IdContenido { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        [StringLength(300)]
        public string Sinopsis { get; set; } = null!;
        [StringLength(150)]
        public string ImagenDelContenido { get; set; } = null!;
        public int Vistas { get; set; }
        public int IdDirectorio { get; set; }
        public int IdGeneros { get; set; }

        [ForeignKey("IdDirectorio")]
        [InverseProperty("Contenidos")]
        public virtual Directorio IdDirectorioNavigation { get; set; } = null!;
        [ForeignKey("IdGeneros")]
        [InverseProperty("Contenidos")]
        public virtual Genero IdGenerosNavigation { get; set; } = null!;
        [InverseProperty("IdContenidoNavigation")]
        public virtual ICollection<DondeVer> DondeVers { get; set; }
        [InverseProperty("IdContenidoNavigation")]
        public virtual ICollection<Opinione> Opiniones { get; set; }
        [InverseProperty("IdContenidoNavigation")]
        public virtual ICollection<Tempora> Temporas { get; set; }
    }
}
