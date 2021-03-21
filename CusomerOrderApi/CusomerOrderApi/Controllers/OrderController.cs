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
            if (customer == null)
            {
                return BadRequest("Invalid Request!");
            }
            
            var customerOrder = _customerOrderService.GetOrder(customer);
            return Ok(customerOrder);
        }
    }
}
