using Roadtrip.Clients;
using Polly;
using Polly.Timeout;

namespace Roadtrip.Utilities
{
    public static class GMapsHttpClient
    {   
        private static string GMapsAPIAddress  = "https://maps.googleapis.com";
        public static string apiKey = "";

        //Registers an injectable HttpClient that connect to Google Maps api
        public static IServiceCollection AddGMapsHttpClient<T>(this IServiceCollection services) where T : GoogleMapsBaseClient
        {
            Random jitter = new Random();

            services.AddHttpClient<T>(client =>
            {
                client.BaseAddress = new Uri(GMapsAPIAddress);
            })
            
            //Retries
            .AddTransientHttpErrorPolicy(builder => builder.Or<TimeoutRejectedException>().WaitAndRetryAsync(
                3,
                retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)) + TimeSpan.FromMilliseconds(jitter.Next(0, 1000))))
            
            //Circuit Breaker
            .AddTransientHttpErrorPolicy(builder => builder.Or<TimeoutRejectedException>().CircuitBreakerAsync(
                3,
                TimeSpan.FromSeconds(15)
            ))
            //Timeout Policy
            .AddPolicyHandler(Policy.TimeoutAsync<HttpResponseMessage>(5));

            return services;
        }

    }
}