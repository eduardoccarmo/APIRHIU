using APIRHIU.Domain.Models;

namespace APIRHIU.Domain.Interfaces
{
    public interface IProcessarDocumentoColaboradoService
    {
        Task<List<CapaEnvelopeEmpregado>> GravarDadosControleIntegracao(List<string> cpfs);
    }
}
