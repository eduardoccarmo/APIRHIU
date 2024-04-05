﻿using APIRHIU.Core.DomainObjects;

namespace APIRHIU.Data.Network
{
    public interface IHttpClientService
    {
        Task<BearerToken> GerarBearerToken();
        Task<RetornoUnico> ObterEnvelopeColaborador(string token);
    }
}
