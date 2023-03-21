﻿using AspNetCoreRateLimit;
using Microsoft.Extensions.Options;
using System.Text.Json;

namespace lagalt_web_api.Middleware
{
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
