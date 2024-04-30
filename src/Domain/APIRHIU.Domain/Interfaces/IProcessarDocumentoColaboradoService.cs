using APIRHIU.Domain.Models;

namespace APIRHIU.Domain.Interfaces
{
    public interface IProcessarDocumentoColaboradoService
    {
        Task<List<CapaEnvelopeEmpregado>> ProcessarDadosEnvelopeEmpregado(List<string> cpfs);

        Task DisponibilizarDocumentoEmpregadoNoFileServer(List<CapaEnvelopeEmpregado> capas);
    }
}
