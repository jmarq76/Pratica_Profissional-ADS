﻿using Infrastructure.Models;

namespace Domain.Interfaces
{
    public interface IPerfilPfService
    {
        void CadastraPerfilPf(PerfilPfModel perfilPf);
        void ObtemPerfilPf(Guid id);
        void DeletaPerfilPf(Guid id);
    }
}