using GoldHelpers.Models;

namespace GoldAPIGateway.BusinessLogics.IBusinessLogics
{
    public interface IPrices
    {
        double GetOnlineAmount(long amountId);
        GoldAPIResult? GetOnlineAmountWithDetail(long amountId);
    }
}
