using Infrastructure.BaseClasses;

namespace Infrastructure.Models
{
    public class PerfilPf : BaseModel
    {
        public Guid IdUsuario { get; set; }
        public string? CargoDesejado { get; set; }
        public string? AreasDesejads { get; set; }
        public int PretensaoSalarial { get; set; }
        public string? ResumoProfissional { get; set; }
        public string? InformacoesComplementares { get; set; }
        public string? Escolaridade { get; set; }
    }
}
