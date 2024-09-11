using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Errors;
using GoldAPIGateway.Models;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult GetValidateUserInfo([FromBody] UserInfoAuthVM infoAuthVM)
        {
            if (infoAuthVM != null)
            {
                bool isOk = _auth.IsValidateUserInfo(infoAuthVM);
                return Ok(new ApiResponse(data: isOk.ToString().ToLower()));
            }
            return BadRequest(new ApiResponse(400));
        }
    }
}
