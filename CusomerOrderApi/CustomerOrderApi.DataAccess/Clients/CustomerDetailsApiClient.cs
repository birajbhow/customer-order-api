using CustomerOrderApi.Common.Interfaces;
using CustomerOrderApi.Common.Models;
using Flurl.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerOrderApi.DataAccess.Clients
{
    public class CustomerDetailsApiClient : ICustomerDetailsApiClient
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<CustomerDetailsApiClient> _logger;

        public CustomerDetailsApiClient(IConfiguration configuration, 
            ILogger<CustomerDetailsApiClient> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        /// <summary>
        /// This method will fetch customer details by email from external api using fluent url package (flurl)
        /// <see cref="https://flurl.dev/"/>
        /// </summary>
        /// <returns>A customer object</returns>
        public async Task<Customer> GetCustomer(string email)
        {
            try
            {
                var customer = await BuildUrl(email).GetJsonAsync<Customer>();

                _logger.LogDebug($"{nameof(CustomerDetailsApiClient)} Customer={customer}");

                return customer;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, nameof(CustomerDetailsApiClient));
            }
            return null;
        }

        private string BuildUrl(string email)
        {
            var baseUrl = _configuration["CustomerDetailsApi:BaseUrl"];
            var apiKey = _configuration["CustomerDetailsApi:ApiKey"];
            return $"{baseUrl}?code={apiKey}&email={email}";
        }
    }
}
