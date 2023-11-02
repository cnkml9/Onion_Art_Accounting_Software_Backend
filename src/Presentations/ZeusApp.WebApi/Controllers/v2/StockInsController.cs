using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZeusApp.Application.Features.Ayarlar.Commands.Create;
using ZeusApp.Application.Features.StockIns.Commands.Create;

namespace ZeusApp.WebApi.Controllers.v2;
public class StockInsController :  BaseApiController<StockInsController>
{

    [HttpPost]
    public async Task<IActionResult> Post(CreateStockInCommand command)
    {
        var createResult = await _mediator.Send(command);
        return Ok(createResult);
    }

}
