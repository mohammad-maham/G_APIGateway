﻿using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using GoldAPIGateway.Models;
using GoldHelpers.Helpers;
using GoldHelpers.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoldAPIGateway.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SMTPController : ControllerBase
    {
        private readonly ISMTP _smtp;
        private readonly ILogger<SMTPController> _logger;

        public SMTPController(ILogger<SMTPController> logger, ISMTP smtp)
        {
            _logger = logger;
            _smtp = smtp;
        }

        [HttpPost]
        //[GoldAuthorize]
        [Route("[action]")]
        public IActionResult SendOTPSMS([FromBody] OTPsms otpSMS)
        {
            string messageId = string.Empty;
            if (!string.IsNullOrEmpty(otpSMS.Mobile) && !string.IsNullOrEmpty(otpSMS.OTP))
            {
                messageId = _smtp.SendOTPSMS(otpSMS.Mobile, otpSMS.OTP);
            }
            return Ok(new GApiResponse<string>() { Data = messageId });
        }


        [HttpPost]
        //[GoldAuthorize]
        [Route("[action]")]
        public IActionResult SendSMS([FromBody] SMS sms)
        {
            string messageIds = string.Empty;
            if (sms.Mobiles!.Length > 0 && sms.Mobiles != null && !string.IsNullOrEmpty(sms.Message))
            {
                messageIds = _smtp.SendSMS(sms.Mobiles, sms.Message);
            }
            return Ok(new GApiResponse<string>() { Data = messageIds });
        }
    }
}
