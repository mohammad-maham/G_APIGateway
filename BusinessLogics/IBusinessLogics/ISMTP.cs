namespace GoldAPIGateway.BusinessLogics.IBusinessLogics
{
    public interface ISMTP
    {
        string SendOTPSMS(string Mobile, string OTP);
        string SendSMS(string[] Mobiles, string Message);
    }
}
