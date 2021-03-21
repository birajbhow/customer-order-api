using CustomerOrderApi.Common.Interfaces;
using CustomerOrderApi.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CusomerOrderApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly ICustomerDetailsApiClient _customerDetailsApiClient;
        private readonly ICustomerOrderService _customerOrderService;

        public OrderController(ILogger<OrderController> logger,
            ICustomerDetailsApiClient customerDetailsApiClient,
            ICustomerOrderService customerOrderService)
        {
            _logger = logger;
            _customerDetailsApiClient = customerDetailsApiClient;
            _customerOrderService = customerOrderService;
        }

        [HttpPost]
        public async Task<IActionResult> Get(OrderRequest orderRequest)
        {
            var customer = await _customerDetailsApiClient.GetCustomer(orderRequest.User);
            if (string.IsNullOrWhiteSpace(customer.CustomerId))
            {
                return BadRequest("Customer not found!");
            }
            if (customer == null)
            {
                return Problem(detail: "Some Error Occurred", statusCode: 500);
            }
            var customerOrder = _customerOrderService.GetOrder(customer);
            return Ok(customerOrder);
        }
    }
}
