using APIRHIU.Core.DomainObjects;
using APIRHIU.Data.Network;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using AutoMapper;
using MediatR;

namespace APIRHUI.Application.Services
{
    public class ProcessarDocumentoColaboradorService : IProcessarDocumentoColaboradoService
    {
        private readonly ICapaEnvelopeEmpregadoRepository _capaEnvelopeEmpregadoRepository;
        //private readonly IMediator _mediator;
        private readonly IHttpClientService _client;
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public ProcessarDocumentoColaboradorService(ICapaEnvelopeEmpregadoRepository capaEnvelopeEmpregadoRepository,
                                                    //IMediator mediator,
                                                    IHttpClientService client,
                                                    ITokenRepository tokenRepository,
                                                    IMapper mapper)
        {
            _capaEnvelopeEmpregadoRepository = capaEnvelopeEmpregadoRepository;
            //_mediator = mediator;
            _client = client;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public Task<bool> PopularTabelasControleDocumento(List<CapaEnvelopeEmpregado> envelopes)
        {
            throw new NotImplementedException();
        }

        public async Task<List<CapaEnvelopeEmpregado>> RecuperarEnvelopeColaboradorPlataformaUnico(List<string> cpfs)
        {
            string? access_token = string.Empty;

            List<TokenAcessoUnico> tokensGerados = await _tokenRepository.ObterTodos();

            TokenAcessoUnico? ultimoTokenGerado = tokensGerados.MaxBy(x => x.DataExpiracaoToken);

            if (ultimoTokenGerado?.DataExpiracaoToken >= DateTime.Now)

                access_token = ultimoTokenGerado.CodigoTokenAcesso;
            else

                access_token = await _client.GerarBearerToken();

            RetornoUnico? data = await _client.ObterEnvelopeColaborador(access_token);

            return new List<CapaEnvelopeEmpregado>();
        }
    }
}
