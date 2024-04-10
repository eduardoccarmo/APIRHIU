using APIRHIU.Data.Context;
using APIRHIU.Data.Network;
using APIRHIU.Data.Repository;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using APIRHUI.Application.Services;

namespace APIRHIU.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region DbContext

            services.AddScoped<ApirhiuContext>();

            #endregion


            #region HttpClient

            services.AddHttpClient<IHttpClientService, HttpClientService>();

            #endregion

            #region Services

            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<IProcessarDocumentoColaboradoService, ProcessarDocumentoColaboradorService>();

            #endregion

            #region Repositories

            services.AddScoped<ITokenRepository, TokenRepository>();

            #endregion
        }
    }
}
