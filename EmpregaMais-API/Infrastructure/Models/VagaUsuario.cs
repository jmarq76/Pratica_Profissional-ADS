using Infrastructure.BaseClasses;

namespace Infrastructure.Models
{
    public class VagaUsuario : BaseModel
    {
        public Guid IdVaga { get; set; }
        public Guid IdPerfilPf { get; set; }
        public Guid IdPerfilPj { get; set; }
        public DateTime DataEnvioPerfilPf { get; set; }
        public DateTime DataRespostaPerfilPj { get; set; }
    }
}
