using CustomerOrderApi.Common.Models;

namespace CustomerOrderApi.Common.Interfaces
{
    public interface IOrdersAccess
    {
        Order GetLatestOrder(string customerId);
    }
}
