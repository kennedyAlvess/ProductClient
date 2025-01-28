using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.Client;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;
using ProductCliente.Exceptions.ExceptionsBase;

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
        [ProducesResponseType(typeof(ReponseErros), StatusCodes.Status400BadRequest)]
        public IActionResult CadastrarClient([FromBody] RequestClient client)
        {
            try
            {
                CadastrarClientService response = new();
                return Created(string.Empty, response.Executar(client));
            }
            catch (ProductClientException ex)
            {
                return BadRequest(new ReponseErros(ex.GetErrorsMessages()));
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new ReponseErros("Erro desconhecido, entre em contato com o suporte técnico."));
            }
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
