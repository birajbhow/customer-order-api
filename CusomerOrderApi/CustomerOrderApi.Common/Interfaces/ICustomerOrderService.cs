using CustomerOrderApi.Common.Models;

namespace CustomerOrderApi.Common.Interfaces
{
    public interface ICustomerOrderService
    {
        CustomerOrder GetOrder(Customer customer);
    }
}
