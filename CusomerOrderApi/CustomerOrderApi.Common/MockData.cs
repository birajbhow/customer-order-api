using CustomerOrderApi.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApi.Common
{
    public static class MockData
    {
        public static CustomerOrder GetCustomerOrder(Customer customer)
        {
            var orders = CustomerOrders();
            return orders.FirstOrDefault(order => order.Customer.CustomerId == customer.CustomerId);
        }

        private static IEnumerable<CustomerOrder> CustomerOrders()
        {
            return new List<CustomerOrder>
            {
                new CustomerOrder
                {
                    Customer = new Customer
                    {
                        CustomerId = "C34454",
                        Email = "cat.owner@mmtdigital.co.uk",
                        FirstName = "cat",
                        LastName = "owner"
                    },
                    Order = new Order
                    {
                        OrderNumber = 1,
                        OrderDate = DateTime.UtcNow.AddDays(-1).ToString("dd-MMM-yyyy"),
                        DeliveryAddress = "address1",
                        DeliveryExpected = DateTime.UtcNow.AddDays(1).ToString("dd-MMM-yyyy"),
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Product = "Shoes",
                                Quantity = 1,
                                PriceEach = 50
                            }
                        }
                    }
                },
                new CustomerOrder
                {
                    Customer = new Customer
                    {
                        CustomerId = "R34788",
                        Email = "dog.owner@fake-customer.com",
                        FirstName = "dog",
                        LastName = "owner"
                    },
                    Order = new Order
                    {
                        OrderNumber = 1,
                        OrderDate = DateTime.UtcNow.AddDays(-1).ToShortDateString(),
                        DeliveryAddress = "address1",
                        DeliveryExpected = DateTime.UtcNow.AddDays(1).ToShortDateString(),
                        OrderItems = new List<OrderItem>
                        {
                            new OrderItem
                            {
                                Product = "Shoes",
                                Quantity = 1,
                                PriceEach = 50
                            }
                        }
                    }
                }
            };
        }
    }
}


