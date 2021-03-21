using CustomerOrderApi.Common.Interfaces;
using CustomerOrderApi.Common.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApi.DataAccess.Access
{
    public class OrdersAccess : IOrdersAccess
    {
        private readonly OrderDbContext _dbContext;

        public OrdersAccess(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetLatestOrder(string customerId)
        {
            var orderEntity = _dbContext.Orders
                .Include(o => o.Orderitems)
                .ThenInclude(item => item.Product)
                .Where(o => o.Customerid == customerId)
                .OrderByDescending(o => o.Orderdate)
                .Take(1)
                .SingleOrDefault();

            return MapOrder(orderEntity);
        }

        private static Order MapOrder(Entities.Order orderEntity)
        {
            if (orderEntity == null) return null;

            return new Order
            {
                OrderNumber = orderEntity.Orderid,
                OrderDate = orderEntity.Orderdate?.ToString("dd-MMM-yyyy"), 
                DeliveryAddress = "Not available!",
                DeliveryExpected = orderEntity.Deliveryexpected?.ToString("dd-MMM-yyyy"), 
                OrderItems = orderEntity.Orderitems?
                                .Select(item => new OrderItem
                                {
                                    Product = orderEntity.Containsgift == true ? "Gift" : item.Product.Productname,
                                    Quantity = item.Quantity ?? 0,
                                    PriceEach = item.Price ?? 0
                                })
            };
        }
    }
}
