using CustomerOrderApi.Common.Models;
using System.Threading.Tasks;

namespace CustomerOrderApi.Common.Interfaces
{
    public interface ICustomerDetailsApiClient
    {
        Task<Customer> GetCustomer(string email);
    }
}
