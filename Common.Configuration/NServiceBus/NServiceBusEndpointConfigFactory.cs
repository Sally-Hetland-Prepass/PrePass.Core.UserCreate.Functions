namespace Common.Configuration.NServiceBus
{
    public static class NServiceBusEndpointConfigFactory
    {
        public static EndpointConfiguration ConfigureEndpoint(string endpointName, string connectionString, int immediateRetries, int delayedRetires, int delayedRetryIntervalInSeconds)
        {
            var endpointConfiguration = new EndpointConfiguration(endpointName);
            var transport = endpointConfiguration.UseTransport<AzureServiceBusTransport>();

            // Connection String from Azure Service Bus
            transport.ConnectionString(connectionString);

            // Other transport settings
            transport.Routing().RouteToEndpoint(typeof(Core.Services.Common.Account.Commands.CreateUser), "CreateUserMessageHandler.Handle");
          
            // Enable message retries
            var recoverability = endpointConfiguration.Recoverability();
            recoverability.Immediate(immediate => immediate.NumberOfRetries(immediateRetries));
            recoverability.Delayed(delayed => delayed.NumberOfRetries(delayedRetires).TimeIncrease(TimeSpan.FromSeconds(delayedRetryIntervalInSeconds)));

            // Enable serialization (default is JSON)
            endpointConfiguration.UseSerialization<NewtonsoftJsonSerializer>();

            // Other configurations
            endpointConfiguration.AuditProcessedMessagesTo("audit");
            endpointConfiguration.EnableInstallers();
            return endpointConfiguration;
        }
    }
}

