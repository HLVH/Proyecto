using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace morado.Models.dbModels
{
    public class ApplicationUser: IdentityUser<int>
    {
        public ApplicationUser()
        {
            DondeVers = new HashSet<DondeVer>();
            Opiniones = new HashSet<Opinione>();
        }

     
        [Column(TypeName = "date")]
        public DateTime FechaDeCreacion { get; set; }
        [StringLength(150)]
        public string FotoDePerfil { get; set; } = null!;

       
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<DondeVer> DondeVers { get; set; }
        [InverseProperty("IdUsuarioNavigation")]
        public virtual ICollection<Opinione> Opiniones { get; set; }
    }
}
