using Infrastructure.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class RedeSocialModel : BaseModel
    {
        public Guid IdPerfil { get; set; }
        public string Nome { get; set; }
        public string Link { get; set; }

        [NotMapped]
        public PerfilPfModel PerfilPf { get; set; }
        [NotMapped]
        public PerfilPjModel PerfilPj { get; set; }
    }
}
