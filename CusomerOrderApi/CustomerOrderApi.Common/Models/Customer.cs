using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerOrderApi.Common.Models
{
    public class Customer
    {
        public string CustomerId { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
