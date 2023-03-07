using Microsoft.EntityFrameworkCore; 
using lagalt_back_end.Data;
using System.Text.Json.Serialization;
using lagalt_back_end.Repositories; 
using Microsoft.OpenApi.Models;
using System.Reflection; 

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMvc().AddJsonOptions(options => { 
    options.JsonSerializerOptions.WriteIndented = true; });

builder.Services.AddDbContext<LagaltDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LAGALT_DB")));

builder.Services.AddScoped<IRepositoryWrapper, DbRepositoryWrapper>();

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
}
);