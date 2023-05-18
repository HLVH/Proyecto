using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace morado.Models.dbModels
{
    [Table("Directorio")]
    public partial class Directorio
    {
        public Directorio()
        {
            Contenidos = new HashSet<Contenido>();
        }

        [Key]
        public int IdDirectorio { get; set; }
        [StringLength(100)]
        public string Nombre { get; set; } = null!;

        [InverseProperty("IdDirectorioNavigation")]
        public virtual ICollection<Contenido> Contenidos { get; set; }
    }
}
