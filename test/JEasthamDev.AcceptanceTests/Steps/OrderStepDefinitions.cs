using System;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using JEasthamDev.AcceptanceTests.Drivers;
using TechTalk.SpecFlow;

namespace JEasthamDev.AcceptanceTests.Steps
{
    [Binding]
    public sealed class OrderStepDefinitions
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private readonly OrderDriver     _orderDriver;
        private          string          _emailAddress;
        private          string          _createdOrderNumber;
        

        public OrderStepDefinitions(ScenarioContext scenarioContext)
        {
            this._scenarioContext = scenarioContext;
            this._orderDriver = new OrderDriver();
        }


        [Given(@"an email address of (.*) is used")]
        public void GivenAnEmailAddressIsUsed(string emailAddress)
        {
            this._emailAddress = emailAddress;
        }

        [When(@"a new order is created")]
        public async Task WhenANewOrderIsCreated()
        {
            this._createdOrderNumber = await this._orderDriver.CreateOrder(this._emailAddress).ConfigureAwait(false);
        }

        [Then(@"a new order should be created for the email address (.*)")]
        public async Task ThenANewOrderShouldBeCreatedForTheCustomer(string emailAddress)
        {
            var customerOrders = await this._orderDriver.GetCustomerOrders(emailAddress);

            customerOrders.Any().Should().BeTrue();
        }

        [Then(@"the order should be found in the database")]
        public async Task ThenTheOrderShouldBeFoundInTheDatabase()
        {
            (await this._orderDriver.GetOrder(this._createdOrderNumber)).OrderNumber.Should().NotBeNullOrEmpty();
        }
    }
}