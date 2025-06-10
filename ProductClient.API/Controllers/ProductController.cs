using Microsoft.AspNetCore.Mvc;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;
using ProductClient.API.Services.Products;

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ProductController(IRegisterProductService registerProductService, IDeleteProductService deleteProductService, IListProductService listProductsService
                            , IGetProductService getProductsService) : ControllerBase
{

    private readonly IRegisterProductService _registerProductService = registerProductService;
    private readonly IDeleteProductService _deleteProductService = deleteProductService;
    private readonly IListProductService _listProductsService = listProductsService;
    private readonly IGetProductService _getProductService = getProductsService;

    [HttpGet("ListProducts")]
    [ProducesResponseType(typeof(List<ResponseProduct>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListProducts()
    {
        return Ok(await _listProductsService.Execute());
    }

    [HttpGet("GetProductById/{Id}")]
    [ProducesResponseType(typeof(List<ResponseProduct>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetProductById(long Id)
    {
        return Ok(await _getProductService.Execute(Id));
    }

    [HttpPost("RegisterProduct")]
    [ProducesResponseType(typeof(ResponseProduct), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterProduct([FromBody] RequestProduct Product)
    {
        var result = await _registerProductService.Execute(Product);
        return Created(string.Empty, result);
    }

    [HttpDelete("DeleteProduct/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteProduct([FromRoute] long Id)
    {
        await _deleteProductService.Execute(Id);
        return Ok("Produto deletado com sucesso.");
    }
}

