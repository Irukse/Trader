using Microsoft.OpenApi.Models;

namespace SimulatorBroker;

public class ConfigSwagger
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c => { c.SwaggerDoc("v2", new OpenApiInfo { Title = "MyAPI-V1", Version = "v2" }); });
        services.AddControllers();
    }
}