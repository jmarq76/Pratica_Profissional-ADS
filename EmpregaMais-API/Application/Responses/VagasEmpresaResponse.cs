using Infrastructure.Models;

namespace Application.Responses
{
    public class VagasEmpresaResponse
    {
        public List<VagaModel> VagasAtivas { get; set; }
        public List<VagaModel> VagasInativas { get; set; }

        public VagasEmpresaResponse()
        {
            VagasAtivas = new List<VagaModel>();
            VagasInativas = new List<VagaModel>();
        }
    }
}
