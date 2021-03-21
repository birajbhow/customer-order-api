using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrderApi.Common.Models
{
    public class CustomerOrder
    {
        public Customer Customer { get; set; }
        public Order Order { get; set; }
    }
}
