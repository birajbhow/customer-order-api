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
        [JsonIgnore]
        public string HouseNumber { get; set; }
        [JsonIgnore]
        public string Street { get; set; }
        [JsonIgnore]
        public string Town { get; set; }
        [JsonIgnore]
        public string Postcode { get; set; }
        [JsonIgnore]
        public string Address
        {
            get
            {
                var address = new StringBuilder();
                if (!string.IsNullOrWhiteSpace(HouseNumber))
                {
                    address.Append(HouseNumber);
                    address.Append(" ");
                }
                if (!string.IsNullOrWhiteSpace(Street))
                {
                    address.Append(Street);
                    address.Append(", ");
                }
                if (!string.IsNullOrWhiteSpace(Town))
                {
                    address.Append(Town);
                    address.Append(", ");
                }
                if (!string.IsNullOrWhiteSpace(Postcode))
                {
                    address.Append(Postcode);
                }
                return address.ToString().Trim().TrimEnd(',');
            }
        }
    }
}