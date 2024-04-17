using APIRHIU.Core.Communication;
using APIRHIU.Data.Context;
using APIRHIU.Data.Network;
using APIRHIU.Data.Repository;
using APIRHIU.Domain.Interfaces;
using APIRHIU.Domain.Models;
using APIRHUI.Application.AutoMapper;
using APIRHUI.Application.Commands;
using APIRHUI.Application.Services;
using MediatR;

namespace APIRHIU.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region AutoMapper

            services.AddAutoMapper(typeof(AutoMapperConfiguration));

            #endregion


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
            services.AddScoped<ICapaEnvelopeEmpregadoRepository, CapaEnvelopeEmpregadoRepository>();
            services.AddScoped<IDocumentoEnvelopeEmpregadoRepository, DocumentoEnvelopeEmpregadoRepository>();

            #endregion

            #region Mediatr

            services.AddMediatR(typeof(Program));

            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<IRequestHandler<InserirCapaEnvelopeCommand, bool>, CapaEnvelopeCommandHandler>();

            #endregion
        }
    }
}
