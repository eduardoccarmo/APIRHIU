using APIRHIU.Data.Network;
using APIRHIU.Data.Network.TokenService;

namespace APIRHIU.Api.Configurations
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IHttpClientService, HttpClientService>();
            services.AddScoped<ITokenService, TokenService>();
        }
    }
}
