using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.Clients;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

// ReSharper disable All

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ClientsController(ICadastrarClienteService cadastrarClientService, IDeletarClienteService deletarClientService, IListarClientesService listarClientsService
                            , IBuscarClienteService buscarClientsService, IAtualizarClienteServicie atualizarClientsService) : ControllerBase
{
    private readonly ICadastrarClienteService _cadastrarClientService = cadastrarClientService;
    private readonly IDeletarClienteService _deletarClientService = deletarClientService;
    private readonly IListarClientesService _listarClientsService = listarClientsService;
    private readonly IBuscarClienteService _buscarClientsService = buscarClientsService;
    private readonly IAtualizarClienteServicie _atualizarClientsService = atualizarClientsService;

    [HttpGet("ListarClientes")]
    [ProducesResponseType(typeof(List<ResponseClient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarClientes()
    {
        return Ok(await _listarClientsService.Execute());
    }

    [HttpGet("ListarClientePorId/{Id}")]
    [ProducesResponseType(typeof(List<ResponseClient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClientById(long Id)
    {
        return Ok(await _buscarClientsService.Execute(Id));
    }

    [HttpPost("CadastrarCliente")]
    [ProducesResponseType(typeof(ResponseClient), StatusCodes.Status201Created)]
    public async Task<IActionResult> CadastrarCliente([FromBody] RequestClient client)
    {
        var result = await _cadastrarClientService.Execute(client);
        return Created(string.Empty, result);
    }

    [HttpPatch("AtualizarCliente/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> AtualizarCliente([FromBody] RequestAtualizarClient client, long Id)
    {
        await _atualizarClientsService.Execute(client, Id);
        return Ok("Cliente atualizado com sucesso.");
    }

    [HttpDelete("DeletarCliente/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletarCliente([FromRoute] long Id)
    {
        await _deletarClientService.Execute(Id);
        return Ok("Cliente deletado com sucesso.");
    }
}

