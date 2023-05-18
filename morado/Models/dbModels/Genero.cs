using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace morado.Models.dbModels
{
    public partial class Genero
    {
        public Genero()
        {
            Contenidos = new HashSet<Contenido>();
        }

        [Key]
        public int IdGeneros { get; set; }
        [StringLength(50)]
        public string Descripcion { get; set; } = null!;

        [InverseProperty("IdGenerosNavigation")]
        public virtual ICollection<Contenido> Contenidos { get; set; }
    }
}
