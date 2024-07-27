namespace GoldAPIGateway.BusinessLogics.IBusinessLogics
{
    public interface IPrices
    {
        Task<double> GetGoldOnlinePriceAsync();
    }
}
