using Infrastructure.BaseClasses;

namespace Infrastructure.Models
{
    public class Usuario : BaseModel
    {
        public Guid IdPerfil { get; set; }
        public Guid IdLogin { get; set; }
        public string? Nome { get; set; }
        public string? CpfCnpj { get; set; }
        public List<Contato>? Contatos { get; set; }
        public List<Endereco>? Enderecos { get; set; }
    }
}
