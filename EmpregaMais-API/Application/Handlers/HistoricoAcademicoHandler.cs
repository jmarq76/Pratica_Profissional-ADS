using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Models;
using Newtonsoft.Json;

namespace Application.Handlers
{
    public class HistoricoAcademicoHandler : IHistoricoAcademicoHandler
    {
        private readonly IHistoricoAcademicoService _historicoAcademicoService;
        private readonly IScopeContext _scopeContext;
        public HistoricoAcademicoHandler(IHistoricoAcademicoService historicoAcademicoService, IScopeContext scopeContext)
        {
            _historicoAcademicoService = historicoAcademicoService;
            _scopeContext = scopeContext;
        }

        public void CadastrarAtualizarHistoricoAcademico(string dadosHistAcademico)
        {
            var histAcademicos = JsonConvert.DeserializeObject<IEnumerable<HistoricoAcademicoModel>>(dadosHistAcademico);

            if (histAcademicos != null && histAcademicos.Any())
            {
                foreach (var histAcademico in histAcademicos)
                {
                    histAcademico.IdPerfil = _scopeContext.IdPerfil;

                    if (histAcademico.Id == Guid.Empty)
                    {
                        _historicoAcademicoService.CadastrarHistoricoAcademico(histAcademico);
                    }
                    else
                    {
                        _historicoAcademicoService.AtualizarHistoricoAcademico(histAcademico);
                    }
                }
            }
        }

        public IEnumerable<HistoricoAcademicoModel> ObterHistoricosAcademicos()
        {
            return _historicoAcademicoService.ObtemHistoricosAcademicos(_scopeContext.IdPerfil);
        }
    }
}
