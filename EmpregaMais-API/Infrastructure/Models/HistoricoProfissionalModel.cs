using Infrastructure.BaseClasses;
using System.ComponentModel.DataAnnotations.Schema;

namespace Infrastructure.Models
{
    public class HistoricoProfissionalModel : BaseModel
    {
        public Guid IdPerfil { get; set; }
        public string? NomeEmpresa { get; set; }
        public string? Cargo { get; set; }
        public string? DescricaoFuncoes { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }
        public bool? EmpresaAtual { get; set; }

        [NotMapped]
        public PerfilPfModel PerfilPf { get; set; }
    }
}
