namespace Infrastructure.BaseClasses
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string? UsuarioCriacao { get; set; }
        public DateTime DataCriacao { get; set; }
        public string? UsuarioAlteracao { get; set; }
        public DateTime DataAlteracao { get; set; }
    }
}
