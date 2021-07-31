// ------------------------------------------------------------
// Copyright (c) James Eastham
// ------------------------------------------------------------

using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using JEasthamDev.Core.Entity;
using JEasthamDev.Core.Events;
using Microsoft.Extensions.DependencyInjection;

namespace JEasthamDev.Infrastructure
{
	public static class InfrastructureConfig
	{
		public static IServiceCollection AddPersistence(this IServiceCollection services)
		{
			services.AddSingleton(
				Settings.IsLocal || Settings.IsDocker
					? new AmazonDynamoDBClient(
						new BasicAWSCredentials("test", "test"),
						new AmazonDynamoDBConfig()
							{ RegionEndpoint = RegionEndpoint.USEast1, ServiceURL = Settings.IsDocker ? "http://localstack:4566" : "http://localhost:4566"})
					: new AmazonDynamoDBClient(new AmazonDynamoDBConfig() { RegionEndpoint = RegionEndpoint.EUWest2 }));
			
			services.AddTransient<Orders, OrdersInMemoryRepository>();
			services.AddTransient<OrderEventStore, OrdersOrderEventStore>();

			return services;
		}
	}
}