using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace GoldAPIGateway.BusinessLogics
{
    public class Prices : IPrices
    {
        private readonly IConfiguration _config;
        private readonly ILogger<Prices> _logger;

        public Prices(ILogger<Prices> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public double GetGoldOnlinePrice()
        {
            double onlinePrice = 0.0;
            IConfigurationSection? configs = _config.GetSection("ApiUrls");
            string host = configs.GetValue<string>("OnlineGoldPrice")!;
            try
            {
                // BaseURL
                RestClient client = new(host);
                RestRequest request = new()
                {
                    Method = Method.Get
                };

                // Headers
                request.AddHeader("content-type", "application/json");

                // Send SMS
                RestResponse response = client.ExecuteGet(request);

                // Check Response
                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
                {
                    GoldOnlinePriceApi apiResponse = JsonConvert.DeserializeObject<GoldOnlinePriceApi>(response.Content)!;
                    if (apiResponse != null && apiResponse.Result != null && apiResponse.Result.Data?.Count > 0)
                    {
                        GoldOnlinePriceApiData? apiDATA = apiResponse.Result.Data.FirstOrDefault();
                        if (apiDATA != null)
                        {
                            onlinePrice = apiDATA.CurrentPrice;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return onlinePrice;
        }
    }
}
