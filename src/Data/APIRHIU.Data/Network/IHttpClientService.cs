using APIRHIU.Core.DomainObjects;

namespace APIRHIU.Data.Network
{
    public interface IHttpClientService
    {
        Task<string?> GerarBearerToken();
        Task<RetornoUnico> ObterEnvelopeColaborador(string? token);
        Task<byte[]> ObterDocumentoColaborador(string uiid);
    }
}
