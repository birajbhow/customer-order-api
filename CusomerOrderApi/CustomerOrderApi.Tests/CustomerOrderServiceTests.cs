using CustomerOrderApi.Common.Interfaces;
using CustomerOrderApi.Common.Models;
using CustomerOrderApi.Services;
using Moq;
using NUnit.Framework;
using System.Linq;

namespace CustomerOrderApi.Tests
{
    [TestFixture]
    public class CustomerOrderServiceTests
    {
        private Mock<IOrdersAccess> mockOrdersAccess;
        private CustomerOrderService subject;

        [SetUp]
        public void Setup()
        {
            mockOrdersAccess = new Mock<IOrdersAccess>();
            subject = new CustomerOrderService(mockOrdersAccess.Object);
        }

        [Test]
        public void GetOrder_Returns_Valid_CustomerOrder()
        {
            // arrange
            var customer = MockData.GetCustomer();
            var order = MockData.GetOrder();
            mockOrdersAccess.Setup(x => x.GetLatestOrder(customer.CustomerId)).Returns(order);

            // act
            var result = subject.GetOrder(customer);

            // assert
            mockOrdersAccess.Verify(x => x.GetLatestOrder(customer.CustomerId), Times.Once);
            Assert.IsAssignableFrom<CustomerOrder>(result);
            Assert.IsNotNull(result.Customer);
            Assert.IsNotNull(result.Order);

        }

        [Test]
        public void GetOrder_Returns_CustomerOrder_With_Only_Customer()
        {
            // arrange
            var customer = MockData.GetCustomer();
            //var order = MockData.GetOrder();
            mockOrdersAccess.Setup(x => x.GetLatestOrder(customer.CustomerId)).Returns(() => null);

            // act
            var result = subject.GetOrder(customer);

            // assert
            mockOrdersAccess.Verify(x => x.GetLatestOrder(customer.CustomerId), Times.Once);
            Assert.IsAssignableFrom<CustomerOrder>(result);
            Assert.IsNotNull(result.Customer);
            Assert.IsNull(result.Order);
        }

        [Test]
        public void GetOrder_Returns_CustomerOrder_With_Gift_Product()
        {
            // arrange
            var customer = MockData.GetCustomer();
            var order = MockData.GetOrder(gift: true);
            mockOrdersAccess.Setup(x => x.GetLatestOrder(customer.CustomerId)).Returns(order);

            // act
            var result = subject.GetOrder(customer);

            // assert
            mockOrdersAccess.Verify(x => x.GetLatestOrder(customer.CustomerId), Times.Once);
            Assert.AreEqual("Gift", result.Order.OrderItems.First().Product);
        }
    }
}
