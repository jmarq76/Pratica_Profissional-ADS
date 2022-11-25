using Application.Interfaces;

namespace Application.Utils
{
    public class ScopeContext : IScopeContext
    {
        public Guid Id { get; set; }
        public Guid IdPerfil { get; set; }
    }
}
