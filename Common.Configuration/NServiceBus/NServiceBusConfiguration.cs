namespace Common.Configuration.NServiceBus
{
    public class NServiceBusConfiguration
    {
        public string CreateUserServiceBusConnection { get; init; } = string.Empty;
        public int NumberOfImmediateRetries { get; init; } = 2;
        public int NumberOfDelayedRetries { get; init; } = 3;
        public int IntervalInSecondsBetweenDelayedRetries { get; init; } = 10;
    }
}
