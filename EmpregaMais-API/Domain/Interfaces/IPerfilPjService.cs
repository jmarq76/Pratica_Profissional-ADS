﻿using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IPerfilPjService
    {
        void CadastrarPerfilPj(PerfilPjModel perfilPj);
        void ObtemPerfilPj(Guid id);
        void DeletarPerfilPj(Guid id);
    }
}
