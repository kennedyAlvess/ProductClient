using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.Clients;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ClientController(IRegisterClientService registerClientService, IDeleteClientService deleteClientService, IListAllClientsService ListAllClientsService
                            , IGetClientService getClientService, IUpdateClientServicie atualizarClientsService) : ControllerBase
{
    private readonly IRegisterClientService _registerClientService = registerClientService;
    private readonly IDeleteClientService _deleteClientService = deleteClientService;
    private readonly IListAllClientsService _ListAllClientsService = ListAllClientsService;
    private readonly IGetClientService _getClientService = getClientService;
    private readonly IUpdateClientServicie _updateClientService = atualizarClientsService;

    [HttpGet("ListAllClients")]
    [ProducesResponseType(typeof(List<ResponseClient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListAllClients()
    {
        List<ResponseClient> data = await _ListAllClientsService.Execute();
        return Ok(new Response<List<ResponseClient>>(data, true));
    }

    [HttpGet("GetClientById/{Id}")]
    [ProducesResponseType(typeof(List<ResponseClient>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetClientById(long Id)
    {
        ResponseClient data = await _getClientService.Execute(Id);
        return Ok(new Response<ResponseClient>(data, true));
    }

    [HttpPost("RegisterClient")]
    [ProducesResponseType(typeof(ResponseClient), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterClient([FromBody] RequestClient client)
    {
        var data = await _registerClientService.Execute(client);
        return Created(string.Empty, new Response<ResponseClient>(data, true));
    }

    [HttpPatch("UpdateClient/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateClient([FromBody] RequestAtualizarClient client, long Id)
    {
        ResponseClient data = await _updateClientService.Execute(client, Id);
        return Ok(new Response<ResponseClient>(data, true));
    }

    [HttpDelete("DeleteClient/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteClient([FromRoute] long Id)
    {
        await _deleteClientService.Execute(Id);
        return Ok();
    }
}

