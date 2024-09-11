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
            try
            {
                // BaseURL
                RestClient client = new(host);
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
                    AuthorizationVM apiResponse = JsonConvert.DeserializeObject<AuthorizationVM>(response.Content)!;
                    if (apiResponse != null && apiResponse.Result != null)
                    {
                        AuthResult? apiDATA = apiResponse.Result;
                        if (apiDATA != null)
                        {
                            isOk = apiDATA.Mobile && apiDATA.NationalId;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isOk;
        }

        public bool IsValidateUserInfo(UserInfoAuthVM infoAuthVM)
        {
            bool isOk = false;
            IConfigurationSection? configs = _config.GetSection("ApiUrls");
            string host = configs.GetValue<string>("Authorizations")!;
            string token = _config.GetSection("Tokens").GetValue<string>("MobileAuthorization")!;
            try
            {
                // BaseURL
                RestClient client = new(host);
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
                    AuthorizationVM apiResponse = JsonConvert.DeserializeObject<AuthorizationVM>(response.Content)!;
                    if (apiResponse != null && apiResponse.Result != null)
                    {
                        AuthResult? apiDATA = apiResponse.Result;
                        if (apiDATA != null)
                        {
                            isOk = apiDATA.Mobile && apiDATA.NationalId && apiDATA.IdCode && apiDATA.Family && apiDATA.Name;
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return isOk;
        }
    }
}
