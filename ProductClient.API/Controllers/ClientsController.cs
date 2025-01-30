using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.Client;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

// ReSharper disable All

namespace ProductClient.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
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
        public IActionResult CadastrarClient([FromBody] RequestClient client)
        {
            CadastrarClientService response = new();
            var result = response.Executar(client);
            return Created(string.Empty, result);
        }

        [HttpPut("AtualizarClient/{id:long}")]
        public IActionResult AtualizarClient([FromRoute] long id, [FromBody] string value)
        {
            return Ok();
        }

        [HttpDelete("DeletarClient/{id:long}")]
        public IActionResult DeletarClient([FromRoute] long id)
        {
            return Ok();
        }
    }
}
