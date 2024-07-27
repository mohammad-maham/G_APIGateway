using GoldAPIGateway.BusinessLogics.IBusinessLogics;

namespace GoldAPIGateway.BusinessLogics
{
    public class Prices : IPrices
    {
        private readonly ILogger<Prices> _logger;
        private const double G750 = 33734000;

        public Prices(ILogger<Prices> logger)
        {
            _logger = logger;
        }

        public async Task<double> GetGoldOnlinePriceAsync()
        {
            return await Task.FromResult(G750);
        }
    }
}
