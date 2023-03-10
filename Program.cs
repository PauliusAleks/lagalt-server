 using System.Text.Json.Serialization;
using lagalt_back_end.Repositories;
using lagalt_web_api.Repositories.Interface;
using lagalt_back_end.Repositories.Base;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Net; 

ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;



var builder = WebApplication.CreateBuilder(args);
var Configuration = builder.Configuration;

builder.Services.AddSingleton(Configuration);

builder.Services.AddMvc().AddJsonOptions(options => {
    options.JsonSerializerOptions.WriteIndented = true; });


builder.Services.AddScoped<IProjectRepository, DbProjectRepository>();
builder.Services.AddScoped<IUserRepository, DbUserRepository>(); 
builder.Services.AddScoped<IApplicationRepository, DbApplicationRepository>();
builder.Services.AddScoped<ISkillRepository, DbSkillRepository>();
builder.Services.AddScoped<IImageURLRepository, DbImageURLRepository>();
builder.Services.AddScoped<IAdminRepository, DbAdminRepository>();
builder.Services.AddScoped<IContributorRepository, DbContributorRepository>();

// Use this for accessing data
builder.Services.AddScoped<IRepositories, Repositories>();

builder.Services.AddHttpClient();

builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddControllers().
    AddJsonOptions(x => x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); 
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
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
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);

});

//builder.Services.AddControllers();
//// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();


app.MapControllers();

app.Run();
