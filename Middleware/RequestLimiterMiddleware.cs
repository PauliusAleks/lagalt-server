using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace lagalt_web_api.Middleware
{
    /// <summary>
    /// Middleware that limits the number of requests a client can make within a specified time period.
    /// </summary>
    public class RequestLimiterMiddleware : ClientRateLimitMiddleware
    {
        public RequestLimiterMiddleware(RequestDelegate next, 
            IProcessingStrategy processingStrategy, 
            IOptions<ClientRateLimitOptions> options, 
            IClientPolicyStore policyStore, 
            IRateLimitConfiguration config, 
            ILogger<ClientRateLimitMiddleware> logger) : base(next, processingStrategy, options, policyStore, config, logger) 
        {

        }

        /// <summary>
        /// Returns a response when the API calls quota has been exceeded.
        /// </summary>
        /// <param name="httpContext">The current HttpContext.</param>
        /// <param name="rule">The rule that was exceeded.</param>
        /// <param name="retryAfter">The time until the client can make more requests.</param>
        public override Task ReturnQuotaExceededResponse(HttpContext httpContext, 
            RateLimitRule rule, 
            string retryAfter)
        {
            string? path = httpContext?.Request?.Path.Value;
            var result = JsonSerializer.Serialize("API calls quota exceeded!");
            httpContext.Response.Headers["Retry-After"] = retryAfter;
            httpContext.Response.StatusCode = 429;
            httpContext.Response.ContentType= "application/json";
             
            return httpContext.Response.WriteAsync(result);
        }
    }
}
