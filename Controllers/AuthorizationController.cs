using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Errors;
using GoldAPIGateway.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GoldAPIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IAuthorization _auth;
        private readonly ILogger<AuthorizationController> _logger;

        public AuthorizationController(ILogger<AuthorizationController> logger, IAuthorization auth)
        {
            _logger = logger;
            _auth = auth;
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetValidateMobileNationalCode([FromBody] MobileAuthVM authVM)
        {
            if (authVM != null && !string.IsNullOrEmpty(authVM.Mobile) && !string.IsNullOrEmpty(authVM.NationalCode))
            {
                bool isOk = _auth.IsValidateMobileNationalCode(authVM.Mobile, authVM.NationalCode);
                return Ok(new ApiResponse(data: isOk.ToString().ToLower()));
            }
            return BadRequest(new ApiResponse(400));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetValidateRealUserInfo([FromBody] RealUserInfoAuthVM infoAuthVM)
        {
            if (infoAuthVM != null)
            {
                bool isOk = _auth.ValidateRealUserInfo(infoAuthVM);
                return Ok(new ApiResponse(data: isOk.ToString().ToLower()));
            }
            return BadRequest(new ApiResponse(400));
        }

        [HttpPost]
        [Route("[action]")]
        public IActionResult GetValidateLegalUserInfo([FromBody] LegalUserInfoAuthVM infoAuthVM)
        {
            if (infoAuthVM != null)
            {
                LegalUserAuthResult? result = _auth.ValidateLegalUserInfo(infoAuthVM);
                string jsonData = JsonConvert.SerializeObject(result);
                if (result != null && !string.IsNullOrEmpty(result.NationalId))
                    return Ok(new ApiResponse(data: jsonData));
            }
            return BadRequest(new ApiResponse(400));
        }
    }
}
