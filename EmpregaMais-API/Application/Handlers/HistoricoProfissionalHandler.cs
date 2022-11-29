using Application.Interfaces;
using Domain.Interfaces;
using Infrastructure.Models;
using Newtonsoft.Json;

namespace Application.Handlers
{
    public class HistoricoProfissionalHandler : IHistoricoProfissionalHandler
    {
        private readonly IHistoricoProfissionalService _historicoProfissionalService;
        private readonly IScopeContext _scopeContext;
        public HistoricoProfissionalHandler(IHistoricoProfissionalService historicoProfissionalService, IScopeContext scopeContext)
        {
            _historicoProfissionalService = historicoProfissionalService;
            _scopeContext = scopeContext;
        }
        public void CadastraAtualizaHistoricoProfissional(string dadosHistProfissional)
        {
            var histProfissionais = JsonConvert.DeserializeObject<IEnumerable<HistoricoProfissionalModel>>(dadosHistProfissional);

            if(histProfissionais != null && histProfissionais.Any())
            {
                foreach(var histProfissional in histProfissionais)
                {
                    histProfissional.IdPerfil = _scopeContext.IdPerfil;
                    histProfissional.DataEntrada = DateTime.Parse(histProfissional.DataEntrada.ToString()).ToUniversalTime();
                    histProfissional.DataSaida = histProfissional.DataSaida == null ? null : DateTime.Parse(histProfissional.DataSaida.ToString()).ToUniversalTime();

                    if (histProfissional.Id == Guid.Empty)
                    {
                        _historicoProfissionalService.CadastrarHistoricoProfissional(histProfissional);
                    }
                    else
                    {
                        _historicoProfissionalService.AtualizarHistoricoProfissional(histProfissional);
                    }
                }
            }
        }

        public IEnumerable<HistoricoProfissionalModel> ObtemHistoricosProfissionais()
        {
            return _historicoProfissionalService.ObtemHistoricosProfssionais(_scopeContext.IdPerfil);
        }
    }
}
