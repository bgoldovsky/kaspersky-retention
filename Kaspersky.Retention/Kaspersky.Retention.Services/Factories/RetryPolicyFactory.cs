using System;
using Polly;
using Polly.Retry;

namespace Kaspersky.Retention.Services.Factories
{
    public static class RetryPolicyFactory
    {
        public static RetryPolicy Create()
            => Policy
                .Handle<Exception>()
                .Retry(3);
    }
}