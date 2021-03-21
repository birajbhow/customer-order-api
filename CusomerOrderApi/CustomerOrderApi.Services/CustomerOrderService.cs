using CustomerOrderApi.Common;
using CustomerOrderApi.Common.Interfaces;
using CustomerOrderApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApi.Services
{
    public class CustomerOrderService : ICustomerOrderService
    {
        public CustomerOrder GetOrder(Customer customer)
        {
            return MockData.GetCustomerOrder(customer);
        }
    }
}
