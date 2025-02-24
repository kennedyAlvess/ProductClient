using ProductClient.API.Services.ClientProducts;
using ProductClient.API.Services.Clients;
using ProductClient.API.Services.Products;

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
        //Cliente
        services.AddScoped<IAtualizarClienteServicie, AtualizarClienteServicie>();
        services.AddScoped<IBuscarClienteService, BuscarClienteService>();
        services.AddScoped<ICadastrarClienteService, CadastrarClienteService>();
        services.AddScoped<IDeletarClienteService, DeletarClienteService>();
        services.AddScoped<IListarClientesService, ListarClientesService>();
        
        //ClientProducts
        services.AddScoped<IDevolverProdutosService, DevolverProdutosService>();
        services.AddScoped<IInserirClienteProdutosService, InserirClienteProdutosService>();
        services.AddScoped<IListarClientProductsService, ListarClientProductsService>();
        services.AddScoped<IDevolverVendaService, DevolverVendaService>();

        //Produto
        services.AddScoped<IBuscarProdutoService, BuscarProdutoService>();
        services.AddScoped<ICadastrarProdutoService, CadastrarProdutoService>();
        services.AddScoped<IDeletarProdutoService, DeletarProdutoService>();
        services.AddScoped<IListarProdutoService, ListarProdutoService>();

        return services;
    }
}
