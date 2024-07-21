using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoldAPIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMTPController : ControllerBase
    {
        private readonly ILogger<SMTPController> _logger;
        private readonly ISMTP _smtp;
        public SMTPController(ILogger<SMTPController> logger, ISMTP smtp)
        {
            _logger = logger;
            _smtp = smtp;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SendOTPSMS([FromBody] OTPsms otpSMS)
        {
            string messageId = string.Empty;
            if (!string.IsNullOrEmpty(otpSMS.Mobile) && !string.IsNullOrEmpty(otpSMS.OTP))
            {
                messageId = await _smtp.SendOTPSMS(otpSMS.Mobile, otpSMS.OTP);
            }
            return Ok(messageId);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SendSMS([FromBody] SMS sms)
        {
            string messageIds = string.Empty;
            if (sms.Mobiles!.Length > 0 && sms.Mobiles != null && !string.IsNullOrEmpty(sms.Message))
            {
                messageIds = await _smtp.SendSMS(sms.Mobiles, sms.Message);
            }
            return Ok(messageIds);
        }
    }
}
