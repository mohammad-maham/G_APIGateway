namespace GoldAPIGateway.BusinessLogics.IBusinessLogics
{
    public interface IPrices
    {
        double GetGoldOnlinePrice();
        double GetSilverOnlinePrice();
        double GetDollarOnlinePrice();
        double GetTetherOnlinePrice();
    }
}
