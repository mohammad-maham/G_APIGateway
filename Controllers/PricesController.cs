using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldHelpers.Models;
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
        public IActionResult GetOnlineAmount([FromBody] long amountId)
        {
            double price = _prices.GetOnlineAmount(amountId);
            return Ok(new GoldAPIResult(data: price.ToString()));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetOnlineAmountWithDetail([FromBody] long amountId)
        {
            GoldAPIResult? detail = _prices.GetOnlineAmountWithDetail(amountId);
            return Ok(detail);
        }
    }
}
