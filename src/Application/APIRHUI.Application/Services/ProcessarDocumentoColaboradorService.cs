using APIRHIU.Core.Communication;
using APIRHIU.Core.DomainObjects;
using APIRHIU.Core.Message.CommomMessage;
using APIRHIU.Data.Network;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using APIRHUI.Application.Commands;
using AutoMapper;
using System.Linq.Expressions;

namespace APIRHUI.Application.Services
{
    public class ProcessarDocumentoColaboradorService : IProcessarDocumentoColaboradoService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IHttpClientService _client;
        private readonly ITokenRepository _tokenRepository;
        private readonly ICapaEnvelopeEmpregadoRepository _capaEnvelopeRepository;
        private readonly IMapper _mapper;

        public ProcessarDocumentoColaboradorService(IMediatorHandler mediator,
                                                    IHttpClientService client,
                                                    ITokenRepository tokenRepository,
                                                    IMapper mapper,
                                                    ICapaEnvelopeEmpregadoRepository capaEnvelopeRepository)
        {
            _mediator = mediator;
            _client = client;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _capaEnvelopeRepository = capaEnvelopeRepository;
        }

        public async Task DisponibilizarDocumentoEmpregadoNoFileServer(List<CapaEnvelopeEmpregado> capas)
        {
            foreach (var capaEnvelopeEmpregado in capas)
            {
                foreach (var documento in capaEnvelopeEmpregado.DocumentosEnvelope)
                {
                    byte[] hashCodeDocumento = await _client.ObterDocumentoColaborador(documento.CodigoIdentificacaoDocumento);

                    var caminhoArquivo = @$"C:\Users\eduar\OneDrive\Área de Trabalho\Documento Empregado Itg Sign\{documento.IdCapaEvelopeEmpregado}";

                    if (!Directory.Exists(caminhoArquivo))
                        Directory.CreateDirectory(caminhoArquivo);

                    caminhoArquivo += @$"\{documento.NomeDocumento}";

                    File.WriteAllBytes(caminhoArquivo, hashCodeDocumento);
                }
            }
        }

        public async Task<List<CapaEnvelopeEmpregado>> ProcessarDadosEnvelopeEmpregado(List<string> cpfs)
        {
            string? access_token = string.Empty;

            List<CapaEnvelopeEmpregado> capas = new();

            List<TokenAcessoUnico> tokensGerados = await _tokenRepository.ObterTodos();
            TokenAcessoUnico? ultimoTokenGerado = tokensGerados.MaxBy(x => x.DataExpiracaoToken);

            if (ultimoTokenGerado?.DataExpiracaoToken >= DateTime.Now)

                access_token = ultimoTokenGerado.CodigoTokenAcesso;
            else

                access_token = await _client.GerarBearerToken();

            RetornoUnico envelopeDocumentosColaboradorPlataformaUnico = await _client.ObterEnvelopeColaborador(access_token);

            foreach (var envelope in envelopeDocumentosColaboradorPlataformaUnico.Data.Envelopes.Where(x => x.EnvelopeStatus == "Concluído"))
            {
                IEnumerable<CapaEnvelopeEmpregado> envelopesProcessados = await _capaEnvelopeRepository
                                                                                .Buscar(x => x.CodigoIdentificaoEnvelope == envelope.UUID);

                if (!envelopesProcessados.Any())
                {
                    InserirCapaEnvelopeCommand command = _mapper.Map<InserirCapaEnvelopeCommand>(envelope);

                    await _mediator.EnviarComando(command);

                    capas.Add(_mapper.Map<CapaEnvelopeEmpregado>(command));
                }
                else
                {
                    await _mediator.PublicarNotificacao(new DomainNotification("ProcessarDocumentColaboradorService",
                                                                               $"O envelope {envelope.UUID} já foi processado anteriormente."));
                }
            }

            await DisponibilizarDocumentoEmpregadoNoFileServer(capas);

            return capas;
        }
    }
}
