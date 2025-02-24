using Microsoft.AspNetCore.Mvc;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;
using ProductClient.API.Services.Products;

// ReSharper disable All

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ProductController(ICadastrarProdutoService cadastrarProductService, IDeletarProdutoService deletarProductService, IListarProdutoService listarProductsService
                            , IBuscarProdutoService buscarProductsService) : ControllerBase
{

    private readonly ICadastrarProdutoService _cadastrarProductService = cadastrarProductService;
    private readonly IDeletarProdutoService _deletarProductService = deletarProductService;
    private readonly IListarProdutoService _listarProductsService = listarProductsService;
    private readonly IBuscarProdutoService _buscarProductsService = buscarProductsService;

    [HttpGet("ListarProdutos")]
    [ProducesResponseType(typeof(List<ResponseProduct>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListarProductes()
    {
        return Ok(await _listarProductsService.Executar());
    }

    [HttpGet("ListarProdutoPorId/{Id}")]
    [ProducesResponseType(typeof(List<ResponseProduct>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductById(long Id)
    {
        return Ok(await _buscarProductsService.Executar(Id));
    }

    [HttpPost("CadastrarProduto")]
    [ProducesResponseType(typeof(ResponseProduct), StatusCodes.Status201Created)]
    public async Task<IActionResult> CadastrarProducte([FromBody] RequestProduct Product)
    {
        var result = await _cadastrarProductService.Executar(Product);
        return Created(string.Empty, result);
    }

    [HttpDelete("DeletarProduto/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeletarProducte([FromRoute] long Id)
    {
        await _deletarProductService.Executar(Id);
        return Ok("Produto deletado com sucesso.");
    }
}

