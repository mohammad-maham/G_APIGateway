using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Models;
using GoldHelpers.Models;
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

        public double GetOnlineAmount(long amountId)
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
                    GoldOnlinePriceApi result = JsonConvert.DeserializeObject<GoldOnlinePriceApi>(response.Content)!;
                    switch (amountId)
                    {
                        case 11:
                            // Gold
                            if (result != null && result.geram18 != null && result.geram18.value > 0)
                            {
                                Geram18? apiDATA = result.geram18;
                                if (apiDATA != null)
                                    onlinePrice = (double)apiDATA.value;
                            }
                            break;
                        case 12:
                            // Silver
                            // Silver not available in api
                            if (result != null && result.geram18 != null && result.geram18.value > 0)
                            {
                                Geram18? apiDATA = result.geram18;
                                if (apiDATA != null)
                                    onlinePrice = (double)apiDATA.value;
                            }
                            break;
                        case 13:
                            // USD
                            if (result != null && result.dolar != null && result.dolar.value > 0)
                            {
                                Dolar? apiDATA = result.dolar;
                                if (apiDATA != null)
                                    onlinePrice = (double)apiDATA.value;
                            }
                            break;
                        case 14:
                            // USDT
                            // Tether not available in api
                            if (result != null && result.geram18 != null && result.geram18.value > 0)
                            {
                                Geram18? apiDATA = result.geram18;
                                if (apiDATA != null)
                                    onlinePrice = (double)apiDATA.value;
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return onlinePrice;
        }

        public GoldAPIResult? GetOnlineAmountWithDetail(long amountId)
        {
            GoldAPIResult? detail = new();
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

                detail.StatusCode = (int)response.StatusCode;
                // Check Response
                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
                {
                    GoldOnlinePriceApi result = JsonConvert.DeserializeObject<GoldOnlinePriceApi>(response.Content)!;
                    switch (amountId)
                    {
                        case 11:
                            // Gold
                            if (result != null && result.geram18 != null && result.geram18.value > 0)
                            {
                                Geram18? apiDATA = result.geram18;
                                string jsonData = JsonConvert.SerializeObject(apiDATA);
                                detail.Data = jsonData;
                            }
                            break;
                        case 12:
                            // Silver
                            // Silver not available in api
                            if (result != null && result.geram18 != null && result.geram18.value > 0)
                            {
                                Geram18? apiDATA = result.geram18;
                                string jsonData = JsonConvert.SerializeObject(apiDATA);
                                detail.Data = jsonData;
                            }
                            break;
                        case 13:
                            // USD
                            if (result != null && result.dolar != null && result.dolar.value > 0)
                            {
                                Dolar? apiDATA = result.dolar;
                                string jsonData = JsonConvert.SerializeObject(apiDATA);
                                detail.Data = jsonData;
                            }
                            break;
                        case 14:
                            // USDT
                            // Tether not available in api
                            if (result != null && result.geram18 != null && result.geram18.value > 0)
                            {
                                Geram18? apiDATA = result.geram18;
                                string jsonData = JsonConvert.SerializeObject(apiDATA);
                                detail.Data = jsonData;
                            }
                            break;
                        default:
                            break;
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return detail;
        }
    }
}
