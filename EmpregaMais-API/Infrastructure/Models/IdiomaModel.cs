using Infrastructure.BaseClasses;
using Infrastructure.Constantes;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    [Table(ConstantesTabelas.IDIOMAS)]
    public class IdiomaModel : BaseModel
    {
        public Guid IdVaga { get; set; }
        public string? NomeIdioma { get; set; }
        public string? Nivel { get; set; }

        [NotMapped]
        public VagaModel Vaga { get; set; }
    }
}
