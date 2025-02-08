using ProductClient.API.Services.Clients;

namespace ProductClient.API;
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
        services.AddScoped<IDeletarClientService, DeletarClientService>();
        services.AddScoped<IListarClientsService, ListarClientsService>();
        services.AddScoped<IBuscarClienteService, BuscarClienteService>();

        return services;
    }
}
