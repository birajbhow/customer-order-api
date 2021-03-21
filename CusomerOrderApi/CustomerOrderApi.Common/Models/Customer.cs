using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace CustomerOrderApi.Common.Models
{
    public class Customer
    {
        [JsonIgnore]
        public string CustomerId { get; set; }
        [JsonIgnore]
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
