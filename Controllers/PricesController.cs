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

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetDollarOnlinePrice()
        {
            double price = _prices.GetGoldOnlinePrice();
            return Ok(new ApiResponse(data: price.ToString()));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetSilverOnlinePrice()
        {
            double price = _prices.GetGoldOnlinePrice();
            return Ok(new ApiResponse(data: price.ToString()));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetTetherOnlinePrice()
        {
            double price = _prices.GetGoldOnlinePrice();
            return Ok(new ApiResponse(data: price.ToString()));
        }
    }
}
