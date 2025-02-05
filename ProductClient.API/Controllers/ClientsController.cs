using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.Clients;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

// ReSharper disable All

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ClientsController : ControllerBase
{
    private readonly ICadastrarClientService _cadastrarClientService;
    private readonly IDeletarClientService _deletarClientService;
    public ClientsController(ICadastrarClientService cadastrarClientService, IDeletarClientService deletarClientService)
    {
        _cadastrarClientService = cadastrarClientService;
        _deletarClientService = deletarClientService;
    }
    [HttpGet("ListarClients")]
    public IActionResult ListarClients()
    {
        return Ok();
    }

    [HttpGet("ListarClientById/{id:Long}")]
    public IActionResult GetClientById([FromRoute] long id)
    {
        return Ok();
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
    public async Task<IActionResult> DeletarClient([FromRoute] long id)
    {
        await _deletarClientService.Executar(id);
        return Ok();
    }
}

