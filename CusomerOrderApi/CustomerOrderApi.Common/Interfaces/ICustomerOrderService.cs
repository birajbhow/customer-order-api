using CustomerOrderApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApi.Common.Interfaces
{
    public interface ICustomerOrderService
    {
        CustomerOrder GetOrder(Customer customer);
    }
}
