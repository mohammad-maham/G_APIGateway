using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Errors;
using GoldHelpers.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace GoldAPIGateway.Controllers
{
    [ApiController]
    //[GoldAuthorize]
    [Route("api/[controller]")]
    public class PricesController : ControllerBase
    {
        private readonly IPrices _prices;
        private readonly ILogger<PricesController> _logger;

        public PricesController(ILogger<PricesController> logger, IPrices prices)
        {
            _logger = logger;
            _prices = prices;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> GetGoldOnlinePrice()
        {
            double price = await _prices.GetGoldOnlinePriceAsync();
            return Ok(new ApiResponse(data: price.ToString()));
        }
    }
}
