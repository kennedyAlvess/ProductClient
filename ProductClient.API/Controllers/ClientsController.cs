using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.Clients;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

// ReSharper disable All

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ClientsController : ControllerBase
{
    private readonly ICadastrarClientService _cadastrarClientService;
    private readonly IDeletarClientService _deletarClientService;
    private readonly IListarClientsService _listarClientsService;
    private readonly IBuscarClienteService _buscarClientsService;
    public ClientsController(ICadastrarClientService cadastrarClientService, IDeletarClientService deletarClientService, IListarClientsService listarClientsService
                            , IBuscarClienteService buscarClientsService)
    {
        _cadastrarClientService = cadastrarClientService;
        _deletarClientService = deletarClientService;
        _listarClientsService = listarClientsService;
        _buscarClientsService = buscarClientsService;
    }
    
    [HttpGet("ListarClients")]
    [ProducesResponseType(typeof(List<ResponseClient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarClients()
    {
        return Ok(await _listarClientsService.Executar());
    }

    [HttpGet("ListarClientById/{id:Long}")]
    [ProducesResponseType(typeof(List<ResponseClient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClientById([FromRoute] long id)
    {
        return Ok(await _buscarClientsService.Executar(id));
    }

    [HttpPost("CadastrarClient")]
    [ProducesResponseType(typeof(ResponseClient), StatusCodes.Status201Created)]
    public async Task<IActionResult> CadastrarClient([FromBody] RequestClient client)
    {
        var result = await _cadastrarClientService.Executar(client);
        return Created(string.Empty, result);
    }

    [HttpPut("AtualizarClient/{id:long}")]
    public IActionResult AtualizarClient([FromRoute] long id, [FromBody] string value)
    {
        return Ok();
    }

    [HttpDelete("DeletarClient/{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletarClient([FromRoute] long id)
    {
        await _deletarClientService.Executar(id);
        return Ok();
    }
}

