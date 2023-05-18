using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace morado.Models.dbModels
{
    [Table("Tempora")]
    public partial class Tempora
    {
        public Tempora()
        {
            Episodios = new HashSet<Episodio>();
        }

        [Key]
        public int IdTemporadas { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        public int NumerodeTemporadas { get; set; }
        public int IdContenido { get; set; }

        [ForeignKey("IdContenido")]
        [InverseProperty("Temporas")]
        public virtual Contenido IdContenidoNavigation { get; set; } = null!;
        [InverseProperty("IdTemporaNavigation")]
        public virtual ICollection<Episodio> Episodios { get; set; }
    }
}
