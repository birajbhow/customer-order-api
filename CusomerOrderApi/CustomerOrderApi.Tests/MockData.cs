using CustomerOrderApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApi.Tests
{
    internal static class MockData
    {
        internal static Customer GetCustomer()
        {
            return new Customer
            {
                CustomerId = "C34454",
                Email = "cat.owner@mmtdigital.co.uk",
                FirstName = "cat",
                LastName = "owner"
            };
        }

        internal static Order GetOrder(bool gift = false)
        {
            return new Order
            {
                OrderNumber = 1,
                OrderDate = DateTime.UtcNow.AddDays(-1).ToString("dd-MMM-yyyy"),
                DeliveryAddress = "address1",
                DeliveryExpected = DateTime.UtcNow.AddDays(1).ToString("dd-MMM-yyyy"),
                OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Product = gift ? "Gift" : "Shoes",
                                Quantity = 1,
                                PriceEach = 50
                            }
                        }
            };
        }
    }
}


