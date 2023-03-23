using System.Text.Json.Serialization;
using lagalt_web_api.Repositories;
using lagalt_web_api.Repositories.Interface;
using lagalt_web_api.Repositories.Database;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Net;
using lagalt_web_api.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using lagalt_web_api.Hubs;
using lagalt_web_api.Middleware;
using AspNetCoreRateLimit;
using lagalt_web_api.Repositories.API;

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;



var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddDbContext<LagaltDbContext>();

builder.Services.AddSingleton(Configuration);

builder.Services.AddOptions();
builder.Services.AddMemoryCache();
builder.Services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));
builder.Services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));
builder.Services.AddInMemoryRateLimiting();
builder.Services.Configure<ClientRateLimitOptions>(options =>
{
    options.EnableEndpointRateLimiting = true;
    options.StackBlockedRequests = true;
    options.HttpStatusCode = ((int)HttpStatusCode.TooManyRequests);
    options.GeneralRules = new List<RateLimitRule>
    {
        new RateLimitRule
        {
            Endpoint = "/chathub",
            Period = "1s",
            Limit = 5
        },
        //new RateLimitRule
        //{
        // Endpoint = "POST:/chathub",
        // Period = "1s",
        // Limit = 2,
        //}
    };
});
builder.Services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
builder.Services.AddMvc().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.WriteIndented = true;
});

builder.Services.AddScoped<IProjectRepository, DbProjectRepository>();
builder.Services.AddScoped<IUserRepository, DbUserRepository>();
builder.Services.AddScoped<IApplicationRepository, DbApplicationRepository>();
builder.Services.AddScoped<ISkillRepository, DbSkillRepository>();
builder.Services.AddScoped<IImageURLRepository, DbImageURLRepository>();

// Use this for accessing data
builder.Services.AddScoped<IRepositories, Repositories>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(options =>
           {
               options.TokenValidationParameters = new TokenValidationParameters
               {
                   //Access token for postman can be found at http://localhost:8000/#
                   //requires token from keycloak instance - location stored in secret manager
                   IssuerSigningKeyResolver = (token, securityToken, kid, parameters) =>
                   {
                       var client = new HttpClient();
                       var keyuri = builder.Configuration["TokenSecrets:KeyURI"];
                       Console.WriteLine(keyuri);
                       //Retrieves the keys from keycloak instance to verify token
                       var response = client.GetAsync(keyuri).Result;
                       var responseString = response.Content.ReadAsStringAsync().Result;
                       var keys = JsonConvert.DeserializeObject<JsonWebKeySet>(responseString);
                       Console.WriteLine(keys);
                       return keys.Keys;
                   },

                   ValidIssuers = new List<string>
                   {
                        builder.Configuration["TokenSecrets:IssuerURI"]
                   },

                   //This checks the token for a the 'aud' claim value
                   ValidAudience = "account",
               };
           });

builder.Services.AddHttpClient();
builder.Services.AddScoped<ISkillsAPIRepository, SkillsAPIRepository>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Debug", builder => builder
    .WithOrigins("https://localhost:7125", "http://localhost:3000", "https://localhost:3000")
    .AllowAnyHeader()
    .AllowAnyMethod()
    .AllowCredentials());
});

builder.Services.AddSignalR();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers().
    AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
/*
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddSwaggerGen();
    builder.Services.AddSwaggerGen(options =>
    {
        options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
        options.SwaggerDoc("v1", new OpenApiInfo
        {
            Title = "Lagalt API",
            Version = "v1",
            Description = "Web API for lagalt.no.",
            Contact = new OpenApiContact
            {
                Name = "Fredrik Christensen Paulius Aleksandravicius " +
                "Erik Aardal Jarand Larsen Ida Huun Michelsen"
            }

        });
        var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

    });
}
*/
var app = builder.Build();
app.UseCors("Debug");
//Configure the HTTP request pipeline.
/*
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
*/
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.UseIpRateLimiting();
app.UseMiddleware<RequestLimiterMiddleware>();
app.MapHub<ChatHub>("/chathub");
app.MapControllers();
app.Run();
