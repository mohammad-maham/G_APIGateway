using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;
using Microsoft.AspNetCore.Mvc;

namespace GoldAPIGateway.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SMTPController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SMTPController> _logger;

        public SMTPController(ILogger<SMTPController> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SendOTPSMS(string mobile, string otp)
        {
            IConfigurationSection? configs = _config.GetSection("SMSSettings");
            int templateId = configs.GetValue<int>("templateId");
            string api_key = configs.GetValue<string>("key")!;
            SmsIr smsIr = new SmsIr(api_key);
            VerifySendParameter[] verifySendParameters = { new VerifySendParameter("OTP", otp) };
            SmsIrResult<VerifySendResult> response = await smsIr.VerifySendAsync(mobile, templateId, verifySendParameters);
            VerifySendResult sendResult = response.Data;
            int messageId = sendResult.MessageId;
            decimal cost = sendResult.Cost;
            return Ok(messageId);
        }


        [HttpPost]
        [Route("[action]")]
        public async Task<IActionResult> SendSMS(string[] mobiles, string message)
        {
            IConfigurationSection? configs = _config.GetSection("SMSSettings");
            string api_key = configs.GetValue<string>("key")!;
            long lineNumber = configs.GetValue<long>("linenumber")!;
            SmsIr smsIr = new SmsIr(api_key);
            int? sendDateTime = null; // unix time - for instance: 1704094200
            SmsIrResult<SendResult> response = await smsIr.BulkSendAsync(lineNumber, message, mobiles, sendDateTime);
            SendResult sendResult = response.Data;
            Guid packId = sendResult.PackId;
            int?[] messageIds = sendResult.MessageIds;
            decimal cost = sendResult.Cost;
            return Ok(messageIds);
        }
    }
}
