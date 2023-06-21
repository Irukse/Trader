// using System.Reflection;
// using FluentMigrator.Runner;
//
// namespace Migrations;
//
// public class Startup
// {
//     private const string ENVIROMENT_VARIABLE_NAME = "ASPNETCORE_ENVIRONMENT";
//     private const string DATABASE_NAME = "PSQLDb";
//
//     public Startup(IConfiguration configuration)
//     {
//         Configuration = configuration;
//     }
//
//     public IConfiguration Configuration { get; }
//
//     // This method gets called by the runtime. Use this method to add services to the container.
//     public void ConfigureServices(IServiceCollection services)
//     {
//         services.AddControllers();
//
//         string env = Environment.GetEnvironmentVariable(ENVIROMENT_VARIABLE_NAME);
//         var config = new ConfigurationBuilder()
//                      .AddJsonFile("appsettings.json")
//                      .AddJsonFile($"appsettings.{env}.json", optional: true)
//                      //.AddJsonFile($"Configs/connectionStrings.{env}.json", optional: true)
//                      .AddEnvironmentVariables()
//                      .Build();
//
//         services
//             .AddSingleton<IConfiguration>(config)
//             .AddFluentMigratorCore()
//             .ConfigureRunner(config =>
//                                  config.AddPostgres()
//                                        .WithGlobalConnectionString(provider
//                                                                        => provider
//                                                                           .GetRequiredService<IConfiguration>()
//                                                                           .GetConnectionString(DATABASE_NAME))
//                                        .ScanIn(Assembly.GetExecutingAssembly()).For.All())
//             .AddLogging(config => config.AddFluentMigratorConsole())
//             .BuildServiceProvider(false);
//     }
//
//     // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
//     public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//     {
//         if (env.IsDevelopment())
//         {
//             app.UseDeveloperExceptionPage();
//         }
//
//         app.UseHttpsRedirection();
//
//         app.UseRouting();
//
//         app.UseAuthorization();
//
//         app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
//
//         using var scope = app.ApplicationServices.CreateScope();
//         var migrator = scope.ServiceProvider.GetService<IMigrationRunner>();
//         migrator.MigrateUp();
//     }
// }
