namespace APIRHIU.Core.DomainObjects
{
    public class AppSettings
    {
        public string? BaseAdressIdentity { get; set; } = null;
        public string? BaseAdressSign { get; set; }
        public string? EndPointAutenticacao { get; set; } = null;
        public string? EndPointEnvelope { get; set; } = null;
        public string? EndPointArquivo { get; set; } = null;
        public string? PrivateKey { get; set; } = null;
        public string? CaminhoBaseGravacaoDocumentoEmpregado { get; set; }
        

    }
}
