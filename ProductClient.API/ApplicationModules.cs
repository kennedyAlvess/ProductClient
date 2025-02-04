using ProductClient.API.Services.Client;

namespace ProductClient.API
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        {
            services.AddServices();
                    
            return services;
        }
        
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICadastrarClientService, CadastrarClientService>();

            return services;
        }
    }
}