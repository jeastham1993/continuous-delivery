using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Newtonsoft.Json;
using Xunit;

namespace JEasthamDev.AcceptanceTest
{
    public class OrderTests
    {
        [Fact]
        public async Task GivenAValidEmailAddress_WhenCreatingOrder_ShouldGenerateNewOrder()
        {
            using var client = new HttpClient();

            var result = await client.PostAsync($"{TestConstants.ApiUrl}/order", new StringContent(
                JsonConvert.SerializeObject(new CreateOrderRequest()
                {
                    CustomerId = "test@test.com",
                }), Encoding.UTF8, "application/json"));

            result.StatusCode.Should().Be(200);
        }
    }

    public class CreateOrderRequest
    {
        public string CustomerId { get; set; }
    }
}