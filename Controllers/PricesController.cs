using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Errors;
using Microsoft.AspNetCore.Mvc;

namespace GoldAPIGateway.Controllers
{
    [ApiController]
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
        public IActionResult GetGoldOnlinePrice()
        {
            double price = _prices.GetGoldOnlinePrice();
            return Ok(new ApiResponse(data: price.ToString()));
        }
    }
}
