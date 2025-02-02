using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Net;

namespace GoldAPIGateway.BusinessLogics
{
    public class Authorization : IAuthorization
    {
        private readonly IConfiguration _config;
        private readonly ILogger<Authorization> _logger;

        public Authorization(ILogger<Authorization> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public bool IsValidateMobileNationalCode(string mobile, string nationalCode)
        {
            bool isOk = false;
            IConfigurationSection? configs = _config.GetSection("ApiUrls");
            string host = configs.GetValue<string>("Authorizations")!;
            string token = _config.GetSection("Tokens").GetValue<string>("MobileAuthorization")!;
            string port = configs.GetValue<string>("Port1")!;

            try
            {
                // BaseURL
                RestClient client = new($"{host}/{port}");
                RestRequest request = new()
                {
                    Method = Method.Get
                };

                // Parameters
                request.AddParameter("Token", token);
                request.AddParameter("IdCode", nationalCode);
                request.AddParameter("Mobile", mobile);

                // Send SMS
                RestResponse response = client.ExecuteGet(request);

                // Check Response
                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
                {
                    MobileAuth GoldAPIResult = JsonConvert.DeserializeObject<MobileAuth>(response.Content)!;
                    if (GoldAPIResult != null && GoldAPIResult.Result != null)
                    {
                        UserMobileAuthVM? apiDATA = GoldAPIResult.Result;
                        if (apiDATA != null)
                        {
                            isOk = apiDATA.Validation!.Value
                                && !string.IsNullOrEmpty(apiDATA.Detail)
                                && apiDATA.Detail == "شماره موبایل با کد ملی مطابقت دارد";
                        }
                    }
                }
            }
            catch (Exception)
            {
                return isOk = false;
            }
            return isOk;
        }

        public LegalUserAuthResult? ValidateLegalUserInfo(LegalUserInfoAuthVM infoAuthVM)
        {
            LegalUserAuthResult result = new();

            IConfigurationSection? configs = _config.GetSection("ApiUrls");
            string host = configs.GetValue<string>("Authorizations")!;
            string token = _config.GetSection("Tokens").GetValue<string>("MobileAuthorization")!;
            string port = configs.GetValue<string>("Port2")!;

            try
            {
                // BaseURL
                RestClient client = new($"{host}/{port}");
                RestRequest request = new()
                {
                    Method = Method.Get
                };

                // Parameters
                request.AddParameter("Token", token);
                request.AddParameter("IdCode", infoAuthVM.NationalCode);

                // Send SMS
                RestResponse response = client.ExecuteGet(request);

                // Check Response
                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
                {
                    LegalUserAuth GoldAPIResult = JsonConvert.DeserializeObject<LegalUserAuth>(response.Content)!;
                    if (GoldAPIResult != null && GoldAPIResult.Result != null)
                    {
                        result = GoldAPIResult.Result;
                    }
                }
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }

        public bool ValidateRealUserInfo(RealUserInfoAuthVM infoAuthVM)
        {
            bool isOk = false;
            IConfigurationSection? configs = _config.GetSection("ApiUrls");
            string host = configs.GetValue<string>("Authorizations")!;
            string token = _config.GetSection("Tokens").GetValue<string>("MobileAuthorization")!;
            string port = configs.GetValue<string>("Port1")!;

            try
            {
                // BaseURL
                RestClient client = new($"{host}/{port}");
                RestRequest request = new()
                {
                    Method = Method.Get
                };

                // Parameters
                request.AddParameter("Token", token);
                request.AddParameter("IdCode", infoAuthVM.NationalCode);
                request.AddParameter("Mobile", infoAuthVM.Mobile);
                request.AddParameter("Name", infoAuthVM.Name);
                request.AddParameter("Family", infoAuthVM.Family);
                request.AddParameter("BirthDate", infoAuthVM.BirthDate);
                request.AddParameter("NationalId", infoAuthVM.NationalId);

                // Send SMS
                RestResponse response = client.ExecuteGet(request);

                // Check Response
                if (response.StatusCode == HttpStatusCode.OK && !string.IsNullOrEmpty(response.Content))
                {
                    RealUserAuth GoldAPIResult = JsonConvert.DeserializeObject<RealUserAuth>(response.Content)!;
                    if (GoldAPIResult != null && GoldAPIResult.Result != null)
                    {
                        RealUserAuthResult? apiDATA = GoldAPIResult.Result;
                    }
                }
            }
            catch (Exception)
            {
                return isOk = false;
            }
            return isOk;
        }
    }
}
