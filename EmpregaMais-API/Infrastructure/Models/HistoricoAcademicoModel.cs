using Infrastructure.BaseClasses;
using Infrastructure.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class HistoricoAcademicoModel : BaseModel
    {
        public Guid IdPerfil { get; set; }
        public NivelEscolaridade NivelEscolaridade { get; set; }
        public string NomeInstituicao { get; set; }
        public string NomeCurso { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public bool Cursando { get; set; }

        [NotMapped]
        public PerfilPfModel PerfilPf { get; set; }
    }
}
