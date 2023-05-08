using Microsoft.OpenApi.Models;

namespace HelpTrader;

public class ConfigSwagger
{
    public static void ConfigureServices(IServiceCollection services)
    {
        // Register the Swagger generator, defining 1 or more Swagger documents
        services.AddSwaggerGen(c => { c.SwaggerDoc("v2", new OpenApiInfo { Title = "MVCCallWebAPI", Version = "v2" }); });
        services.AddControllers();
    }
}