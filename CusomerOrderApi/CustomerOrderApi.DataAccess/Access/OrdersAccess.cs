using CustomerOrderApi.Common.Interfaces;
using CustomerOrderApi.Common.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace CustomerOrderApi.DataAccess.Access
{
    public class OrdersAccess : IOrdersAccess
    {
        private readonly OrderDbContext _dbContext;

        public OrdersAccess(OrderDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Order GetLatestOrder(Customer customer)
        {
            var orderEntity = _dbContext.Orders
                .Include(o => o.Orderitems)
                .ThenInclude(item => item.Product)
                .Where(o => o.Customerid == customer.CustomerId)
                .OrderByDescending(o => o.Orderdate)
                .Take(1)
                .SingleOrDefault();

            return MapOrder(orderEntity, customer);
        }

        private static Order MapOrder(Entities.Order orderEntity, Customer customer)
        {
            if (orderEntity == null) return null;

            return new Order
            {
                OrderNumber = orderEntity.Orderid,
                OrderDate = orderEntity.Orderdate?.ToString("dd-MMM-yyyy"), 
                DeliveryAddress = customer.Address,
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
