using CurrentAccountAPI.Api.Configurations;
using CurrentAccountAPI.Api.Filters;
using CurrentAccountAPI.Api.Health;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Configuration
IConfiguration configuration = builder.Configuration;

// Services
IServiceCollection services = builder.Services;

// Configure controllers
services.AddControllers(setup => setup.Filters.Add<ExceptionFilterAttribute>())
        .AddNewtonsoftJson(options =>
        {            
            options.SerializerSettings.Converters.Add(new StringEnumConverter());
            options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
        });

services.AddAutoMapper(typeof(Program));

// API and swagger versioning
services.AddEndpointsApiExplorer();
services.AddCustomAuthorization();
services.AddCustomSwagger(configuration);

// CORS, HTTP context, memory cache and custom services
services.AddCustomCors();
services.AddHttpContextAccessor();
services.AddHttpClient();
services.AddMemoryCache();
services.AddCustomServicesConfiguration(configuration);

// Health checks
services.AddHealthChecks()
        .AddCheck<CustomHealthCheck>("");

var app = builder.Build();

app.UseSwagger();

bool useSwagger;
if (bool.TryParse(configuration["UseSwagger"], out useSwagger) && useSwagger)
{
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHealthChecks("/health");
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
