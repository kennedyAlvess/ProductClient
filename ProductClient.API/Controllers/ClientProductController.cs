using Microsoft.AspNetCore.Mvc;
using ProductClient.API.Services.ClientProducts;
using ProductClient.Communication.RequestsDTO;
using ProductClient.Communication.ResponseDTO;

namespace ProductClient.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[ProducesResponseType(StatusCodes.Status500InternalServerError)]
public class ClientProductController(IListClientSalesOrderService listClientSalesOrder, IInsertClientProductService insertClientProductService, 
                                    IRefundProductService refundProduct, IRefundSalesOrderService refundSalesOrderService) : ControllerBase
{
    private readonly IListClientSalesOrderService _ListClientSalesOrder = listClientSalesOrder;
    private readonly IInsertClientProductService _insertClientProductService = insertClientProductService;
    private readonly IRefundProductService _refundProduct = refundProduct;
    private readonly IRefundSalesOrderService _refundSalesOrderService = refundSalesOrderService;

    [HttpGet("ListClientSalesOrder/{ClienteId}")]
    [ProducesResponseType(typeof(List<ResponseClientProducts>), StatusCodes.Status200OK)]
    public async Task<IActionResult> ListClientSalesOrder([FromRoute] long ClienteId)
    {
        return Ok(await _ListClientSalesOrder.Execute(ClienteId));
    }

    [HttpPost("RegisterClientSalesOrder")]
    [ProducesResponseType(typeof(ResponseClientProducts), StatusCodes.Status201Created)]
    public async Task<IActionResult> RegisterClientSalesOrder([FromBody] RequestClientProducts model)
    {
        await _insertClientProductService.Execute(model);
        return Created(string.Empty, "Venda cadastrada com sucesso.");
    }

    [HttpPut("RefundProduct/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RefundProduct([FromBody] RequestClientProducts model, [FromRoute] long Id)
    {
        await _refundProduct.Execute(model, Id);
        return Ok("Produto devolvido com sucesso.");
    }

    [HttpDelete("refundSalesOrderService/{Id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> RefundSalesOrderService(long Id)
    {
        await _refundSalesOrderService.Execute(Id);
        return Ok("Venda devolvida com sucesso.");
    }
}