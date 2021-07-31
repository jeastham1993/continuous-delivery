// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;
using JEasthamDev.Core.Entity;
using JEasthamDev.Core.Events;
using Newtonsoft.Json;

namespace JEasthamDev.Infrastructure
{
	public class OrdersOrderEventStore : OrderEventStore
	{
		private readonly AmazonDynamoDBClient _client;

		public OrdersOrderEventStore(AmazonDynamoDBClient client)
		{
			this._client = client;
		}

		/// <inheritdoc />
		public async Task Store(OrderEvent evt)
		{
			await this._client.PutItemAsync(new PutItemRequest()
			{
				TableName = Settings.TableName,
				Item = new Dictionary<string, AttributeValue>()
				{
					{"PK", new AttributeValue($"ORDER#{evt.OrderNumber.ToUpper()}")},
					{"SK", new AttributeValue($"{evt.EventDate:O}")},
					{"Type", new AttributeValue(evt.EventName)},
					{"Data", new AttributeValue(JsonConvert.SerializeObject(evt))}
				}
			});
		}

		/// <inheritdoc />
		public async Task<Order> Get(string orderNumber)
		{
			var results = await this._client.QueryAsync(new QueryRequest()
			{
				TableName = Settings.TableName,
				KeyConditionExpression = "PK = :orderNumber",
				ExpressionAttributeValues = new Dictionary<string, AttributeValue>(2)
				{
					{":orderNumber", new AttributeValue($"ORDER#{orderNumber.ToUpper()}")},
				}
			});

			Order response = new Order();

			foreach (var result in results.Items)
			{
				switch (result["Type"].S)
				{
					case "order-created":
						var evtData = JsonConvert.DeserializeObject<OrderCreatedOrderEvent>(result["Data"].S);
						response.Apply(evtData);
						break;
				}
			}

			return response;
		}
	}
}