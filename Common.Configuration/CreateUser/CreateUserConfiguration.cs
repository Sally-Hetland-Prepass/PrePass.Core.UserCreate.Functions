using System.Diagnostics.CodeAnalysis;

namespace Common.Configuration.CreateUser
{
    [ExcludeFromCodeCoverage]
    public class CreateUserConfiguration
    {
        public string OcpApimSubscriptionKey { get; set; } = string.Empty;
        //public string CRMApiBaseUrl { get; init; } = string.Empty;

        //public string CRMApiVersion { get; init; } = string.Empty;
    }
}

