using CustomerOrderApi.Common.Interfaces;
using CustomerOrderApi.Common.Models;

namespace CustomerOrderApi.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        private readonly IOrdersAccess _ordersAccess;

        public CustomerOrderService(IOrdersAccess ordersAccess)
        {
            _ordersAccess = ordersAccess;
        }
        public CustomerOrder GetOrder(Customer customer)
        {
            //return MockData.GetCustomerOrder(customer);
            var order = _ordersAccess.GetLatestOrder(customer.CustomerId);
            return new CustomerOrder
            {
                Customer = new Customer
                {
                    CustomerId = customer.CustomerId,
                    Email = customer.Email,
                    FirstName = customer.FirstName,
                    LastName = customer.LastName
                },
                Order = order
            };
        }
    }
}
