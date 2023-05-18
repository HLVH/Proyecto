using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace morado.Models.dbModels
{
    public partial class Episodio
    {
        [Key]
        public int IdEpisodios { get; set; }
        [StringLength(50)]
        public string Nombre { get; set; } = null!;
        public int NumeroDeEpisodios { get; set; }
        public int IdTempora { get; set; }

        [ForeignKey("IdTempora")]
        [InverseProperty("Episodios")]
        public virtual Tempora IdTemporaNavigation { get; set; } = null!;
    }
}
