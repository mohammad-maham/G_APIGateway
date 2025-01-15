using GoldAPIGateway.Models;

namespace GoldAPIGateway.BusinessLogics.IBusinessLogics
{
    public interface IAuthorization
    {
        bool IsValidateMobileNationalCode(string mobile, string nationalCode);
        bool ValidateRealUserInfo(RealUserInfoAuthVM infoAuthVM);
        LegalUserAuthResult? ValidateLegalUserInfo(LegalUserInfoAuthVM infoAuthVM);
    }
}