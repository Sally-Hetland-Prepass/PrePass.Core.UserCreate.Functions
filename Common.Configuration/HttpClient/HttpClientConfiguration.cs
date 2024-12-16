using System.Diagnostics.CodeAnalysis;

namespace Common.Configuration.HttpClient
{
    [ExcludeFromCodeCoverage]
    public class HttpClientConfiguration
    {
        /// <summary>
        /// The number of times the Polly Retry policy will try to execute an http request
        /// that originally failed.
        /// </summary>
        public int HttpRetryAttempts { get; init; } = 3;

        /// <summary>
        /// 
        /// </summary>
        public double SleepDurationInSeconds { get; set; } = 10;

        /// <summary>
        /// Http Handler Lifetime (in minutes)
        /// </summary>
        public int HttpHandlerLifetimeInMinutes { get; init; } = 5;
    }
}

