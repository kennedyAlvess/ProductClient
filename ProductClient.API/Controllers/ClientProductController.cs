using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.ClientProducts;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ClientProductController : ControllerBase
{
    private readonly IListarClientProductsService _listarClientProducts;
    private readonly IInserirClienteProdutosService _inserirClienteProdutosService;
    private readonly IDevolverProdutosService _devolverProdutos;
    private readonly IDevolverVendaService _devolverVenda;
    public ClientProductController(IListarClientProductsService listarClientProducts, IInserirClienteProdutosService inserirClienteProdutosService, IDevolverProdutosService devolverProdutos
                                    , IDevolverVendaService devolverVenda)
    {
        _listarClientProducts = listarClientProducts;
        _inserirClienteProdutosService = inserirClienteProdutosService;
        _devolverProdutos = devolverProdutos;
        _devolverVenda = devolverVenda;
    }
    
    [HttpGet("ListarProdutosPorCliente/{ClienteId}")]
    [ProducesResponseType(typeof(List<ResponseClientProducts>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarClientsProduc([FromRoute] long ClienteId)
    {
        return Ok(await _listarClientProducts.Executar(ClienteId));
    }

    [HttpPost("CadastrarClienteVenda")]
    [ProducesResponseType(typeof(ResponseClientProducts), StatusCodes.Status201Created)]
    public async Task<IActionResult> CadastrarClienteVenda([FromBody] RequestClientProducts model)
    {
        await _inserirClienteProdutosService.Executar(model);
        return Created(string.Empty, "Venda cadastrada com sucesso.");
    }

    [HttpPut("DevolverProduto/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DevolverProduto([FromBody] RequestClientProducts model, [FromRoute] long Id)
    {
        await _devolverProdutos.Executar(model, Id);
        return Ok("Produto devolvido com sucesso.");
    }

    [HttpDelete("DevolverVenda/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DevolverVenda(long Id)
    {
        await _devolverVenda.Executar(Id);
        return Ok("Venda devolvida com sucesso.");
    }
}