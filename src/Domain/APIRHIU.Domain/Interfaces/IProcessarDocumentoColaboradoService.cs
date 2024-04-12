using APIRHIU.Domain.Models;

namespace APIRHIU.Domain.Interfaces
{
    public interface IProcessarDocumentoColaboradoService
    {
        Task<bool> PopularTabelasControleDocumento(List<CapaEnvelopeEmpregado> envelopes);

        Task<List<CapaEnvelopeEmpregado>> RecuperarEnvelopeColaboradorPlataformaUnico(List<string> cpfs);
    }
}
