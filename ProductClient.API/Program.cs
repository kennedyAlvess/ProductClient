using ProductClient.API;
using ProductClient.API.Filters;
using ProductClient.API.Infrastructure.Configuration;
using System.Diagnostics;
using System.Runtime.InteropServices;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure()
                .AddApplicationModules()
                .AddMvc(options => options.Filters.Add(typeof(ExceptionsFilter)));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Redirecionar a rota raiz para o Swagger
app.MapGet("/", () => Results.Redirect("/swagger"));

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Abrir o navegador automaticamente em desenvolvimento
if (app.Environment.IsDevelopment())
{
    var urls = app.Urls;
    if (urls.Count > 0)
    {
        var url = urls.First().Replace("http://", "https://") + "/swagger";
        OpenBrowser(url);
    }
}

app.Run();

static void OpenBrowser(string url)
{
    try
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
        {
            Process.Start("xdg-open", url);
        }
        else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
        {
            Process.Start("open", url);
        }
    }
    catch
    {
        // Se não conseguir abrir o navegador, não faz nada
    }
}