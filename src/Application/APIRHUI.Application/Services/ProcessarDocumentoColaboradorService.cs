using APIRHIU.Core.Communication;
using APIRHIU.Core.DomainObjects;
using APIRHIU.Core.Message.CommomMessage;
using APIRHIU.Data.Network;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using APIRHUI.Application.Commands;
using AutoMapper;
using Microsoft.Extensions.Options;

namespace APIRHUI.Application.Services
{
    public class ProcessarDocumentoColaboradorService : IProcessarDocumentoColaboradoService
    {
        private readonly IMediatorHandler _mediator;
        private readonly IHttpClientService _client;
        private readonly ITokenRepository _tokenRepository;
        private readonly ICapaEnvelopeEmpregadoRepository _capaEnvelopeRepository;
        private readonly IMapper _mapper;
        private readonly IOptions<AppSettings> _configuration;

        public ProcessarDocumentoColaboradorService(IMediatorHandler mediator,
                                                    IHttpClientService client,
                                                    ITokenRepository tokenRepository,
                                                    IMapper mapper,
                                                    ICapaEnvelopeEmpregadoRepository capaEnvelopeRepository,
                                                    IOptions<AppSettings> configuration)
        {
            _mediator = mediator;
            _client = client;
            _tokenRepository = tokenRepository;
            _mapper = mapper;
            _capaEnvelopeRepository = capaEnvelopeRepository;
            _configuration = configuration;
            _configuration = configuration;
        }

        public async Task<List<CapaEnvelopeEmpregado>> ProcessarDadosEnvelopeEmpregado(List<string> cpfs)
        {
            string? access_token = string.Empty;

            List<InserirCapaEnvelopeCommand> capas = new();

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

                    capas.Add(command);
                }
                else
                {
                    await _mediator.PublicarNotificacao(new DomainNotification("Aviso",
                                                                               $"O envelope {envelope.UUID} já foi processado anteriormente."));
                }
            }

            await DisponibilizarDocumentoEmpregadoNoFileServer(capas);

            return new List<CapaEnvelopeEmpregado>();
        }


        private async Task DisponibilizarDocumentoEmpregadoNoFileServer(List<InserirCapaEnvelopeCommand> capas)
        {
            foreach (var capaEnvelopeEmpregado in capas)
            {
                string diretorioAquivo = @_configuration.Value.CaminhoBaseGravacaoDocumentoEmpregado
                    .Replace("#matriculaEmpregado", capaEnvelopeEmpregado.MatriculaEmpregado)
                    .Replace("#idCapaEnvelopeEmpregado", capaEnvelopeEmpregado.Id.ToString());

                if (!Directory.Exists(diretorioAquivo))
                    Directory.CreateDirectory(diretorioAquivo);

                foreach (var documento in capaEnvelopeEmpregado.DocumentosEnvelope)
                {
                    byte[]? hashCodeDocumento = await _client.ObterDocumentoColaborador(documento.CodigoIdentificacaoDocumento);

                    string caminhoFisicoDocumentoEmpregado = diretorioAquivo + @$"\{documento.CodigoIdentificacaoDocumento} - {documento.NomeDocumento}.pdf";
                    
                    if(hashCodeDocumento != null)
                    {
                        await File.WriteAllBytesAsync(caminhoFisicoDocumentoEmpregado, hashCodeDocumento);

                        AtualizarCaminhoDocumentoEmpregadoCommand command = new AtualizarCaminhoDocumentoEmpregadoCommand(documento.Id, caminhoFisicoDocumentoEmpregado);

                        await _mediator.EnviarComando(command);
                    }                    
                }
            }
        }
    }
}
