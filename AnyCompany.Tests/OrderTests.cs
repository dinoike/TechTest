using AnyCompany.Core.Models;
using AnyCompany.Core.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AnyCompany.Tests
{
    [TestClass]
    public class OrderTests
    {
        private readonly Mock<IOrderService> _mockOrderService;
        private readonly IOrderService _orderService;

        public OrderTests(Mock<IOrderService> mockOrderService, IOrderService orderService)
        {
            _mockOrderService=mockOrderService;
            _orderService = orderService;
        }

        [TestMethod]
        public void PlaceOrder()
        {
            Order order = new Order
            {
                Amount = 20,
                VAT = 0,
                CustomerId = 1
            };


            //Testing using Mock / Fake objects 

            var orderService = new Mock<IOrderService>();
            orderService.Setup(x => x.PlaceOrder(order)).Returns(true);

            var orderObject = orderService.Object;

            bool placeOrderResults = orderObject.PlaceOrder(order);

            Assert.IsTrue(placeOrderResults);
        }

        [TestMethod]
        public void GetCustomerOrdersTest()
        {
            // Testing without Mocks

            int customerId = 1;

            var customerOrdersResult = _orderService.GetCustomerOrders(customerId);

            Assert.IsNotNull(customerOrdersResult);
        }

    }
}
