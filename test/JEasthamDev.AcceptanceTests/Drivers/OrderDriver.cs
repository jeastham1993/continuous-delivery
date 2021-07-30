using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JEasthamDev.AcceptanceTests.Drivers
{
    public class OrderDriver
    {
        public async Task CreateOrder(string customerId)
        {
            using var client = new HttpClient();

            await client.PostAsync($"{TestConstants.ApiUrl}/order", new StringContent(
                JsonConvert.SerializeObject(new CreateOrderRequest()
                {
                    CustomerId = "test@test.com",
                }), Encoding.UTF8, "application/json"));
        }
        
        public async Task<IEnumerable<Order>> GetCustomerOrders(string emailAddress)
        {
            using var client = new HttpClient();

            var result = await client.GetAsync($"{TestConstants.ApiUrl}/order/{emailAddress}");

            return JsonConvert.DeserializeObject<IEnumerable<Order>>(await result.Content.ReadAsStringAsync());
        }
    }

    public class Order
    {
        public string CustomerId { get; set; }
        
        public string OrderNumber { get; set; }
		
        public DateTime OrderDate { get; set; }
    }
    
    public class CreateOrderRequest
    {
        public string CustomerId { get; set; }
    }
}