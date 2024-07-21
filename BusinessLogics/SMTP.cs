using GoldAPIGateway.BusinessLogics.IBusinessLogics;
using IPE.SmsIrClient;
using IPE.SmsIrClient.Models.Requests;
using IPE.SmsIrClient.Models.Results;

namespace GoldAPIGateway.BusinessLogics
{
    public class SMTP : ISMTP
    {
        private readonly IConfiguration _config;
        private readonly ILogger<SMTP> _logger;
        public SMTP(ILogger<SMTP> logger, IConfiguration config)
        {
            _logger = logger;
            _config = config;
        }

        public async Task<string> SendOTPSMS(string Mobile, string OTP)
        {
            IConfigurationSection? configs = _config.GetSection("SMSSettings");
            int templateId = configs.GetValue<int>("templateId");
            string api_key = configs.GetValue<string>("key")!;
            SmsIr smsIr = new(api_key);
            VerifySendParameter[] verifySendParameters = { new("OTP", OTP) };
            SmsIrResult<VerifySendResult> response = await smsIr.VerifySendAsync(Mobile, templateId, verifySendParameters);
            VerifySendResult sendResult = response.Data;
            int messageId = sendResult.MessageId;
            decimal cost = sendResult.Cost;
            _logger.LogInformation($"OTP msgId: {messageId.ToString()}");
            return messageId.ToString();
        }

        public async Task<string> SendSMS(string[] Mobiles, string Message)
        {
            IConfigurationSection? configs = _config.GetSection("SMSSettings");
            string api_key = configs.GetValue<string>("key")!;
            long lineNumber = configs.GetValue<long>("linenumber")!;
            SmsIr smsIr = new(api_key);
            int? sendDateTime = null; // unix time - for instance: 1704094200
            SmsIrResult<SendResult> response = await smsIr.BulkSendAsync(lineNumber, Message, Mobiles, sendDateTime);
            SendResult sendResult = response.Data;
            Guid packId = sendResult.PackId;
            int?[] messageIds = sendResult.MessageIds;
            decimal cost = sendResult.Cost;
            _logger.LogInformation($"SMS msgId: {messageIds.ToString()}");
            return messageIds.ToArray().ToString();
        }
    }
}
