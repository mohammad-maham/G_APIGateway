namespace GoldAPIGateway.BusinessLogics.IBusinessLogics
{
    public interface ISMTP
    {
        Task<string> SendOTPSMS(string Mobile, string OTP);
        Task<string> SendSMS(string[] Mobiles, string Message);
    }
}
