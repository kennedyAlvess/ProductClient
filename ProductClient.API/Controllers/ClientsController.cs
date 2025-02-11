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
    private readonly IAtualizarClienteServicie _atualizarClientsService;
    public ClientsController(ICadastrarClientService cadastrarClientService, IDeletarClientService deletarClientService, IListarClientsService listarClientsService
                            , IBuscarClienteService buscarClientsService, IAtualizarClienteServicie atualizarClientsService)
    {
        _cadastrarClientService = cadastrarClientService;
        _deletarClientService = deletarClientService;
        _listarClientsService = listarClientsService;
        _buscarClientsService = buscarClientsService;
        _atualizarClientsService = atualizarClientsService;
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

    [HttpPatch("AtualizarClient")]
    [ProducesResponseType(typeof(List<ResponseClient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> AtualizarClient([FromBody] RequestClient client)
    {
        await _atualizarClientsService.Executar(client);
        return Ok("Cliente atualizado com sucesso.");
    }

    [HttpDelete("DeletarClient/{id:long}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletarClient([FromRoute] long id)
    {
        await _deletarClientService.Executar(id);
        return Ok();
    }
}

