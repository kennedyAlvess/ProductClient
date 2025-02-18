using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.ClientProducts;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ClientProductController : ControllerBase
{
    private readonly IListarClientProducts _listarClientProducts;
    public ClientProductController(IListarClientProducts listarClientProducts)
    {
        _listarClientProducts = listarClientProducts;
    }
    
    [HttpGet("ListarClientProducts/{Id}")]
    [ProducesResponseType(typeof(List<ResponseClientProducts>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarClients(long Id)
    {
        return Ok(await _listarClientProducts.Executar(Id));
    }

    // [HttpGet("ListarClientById/{Id:Long}")]
    // [ProducesResponseType(typeof(List<ResponseClientProducts>), StatusCodes.Status200OK)]
    // public async Task<IActionResult> GetClientById([FromRoute] long Id)
    // {
    //     return Ok(await _buscarClientsService.Executar(Id));
    // }

    // [HttpPost("CadastrarClient")]
    // [ProducesResponseType(typeof(ResponseClientProducts), StatusCodes.Status201Created)]
    // public async Task<IActionResult> CadastrarClient()
    // {
    //     var result = await _cadastrarClientService.Executar(client);
    //     return Created(string.Empty, result);
    // }

    // [HttpPatch("AtualizarClient/{Id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<IActionResult> AtualizarClient()
    // {
    //     await _atualizarClientsService.Executar(client, Id);
    //     return Ok("Cliente atualizado com sucesso.");
    // }

    // [HttpDelete("DeletarClient/{Id}")]
    // [ProducesResponseType(StatusCodes.Status200OK)]
    // public async Task<IActionResult> DeletarClient()
    // {
    //     return await _deletarClientService.Executar(Id);
    // }
}