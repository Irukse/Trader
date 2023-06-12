using FluentMigrator.Runner;
using Migrations;

public class Program
{
    public static void Main(string[] args)
    {
        CreateHostBuilder(args).Build().Run();
    }

    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder => { webBuilder.UseStartup<Startup>(); });
}


// using FluentMigrator.Runner;
// using Microsoft.Extensions.Configuration;
// using Microsoft.Extensions.DependencyInjection;
// using Microsoft.Extensions.Logging;
// using Serilog;
// using System;
// using System.Threading.Tasks;
//
//
// namespace Tolar.Reports.Migrations
// {
//     public class Program
//     {
//         private const string ENVIROMENT_VARIABLE_NAME = "ASPNETCORE_ENVIRONMENT";
//         private const string DATABASE_NAME = "PSQLDb";
//
//         static async Task<int> Main(string[] args)
//         {
//             var serviceProvider = CreateServices();
//             var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
//
//             int returnCode = 0;
//             using (var scope = serviceProvider.CreateScope())
//             {
//                 returnCode = UpdateDatabase(scope.ServiceProvider);
//             }
//
//
//             return returnCode;
//         }
//
//         /// <summary>
//         /// Configure the dependency injection services
//         /// </summary>
//         private static IServiceProvider CreateServices()
//         {
//             string env = Environment.GetEnvironmentVariable(ENVIROMENT_VARIABLE_NAME);
//             var config = new ConfigurationBuilder()
//                 .AddJsonFile("appsettings.json")
//                 .AddJsonFile($"appsettings.{env}.json", optional: true)
//                 .AddJsonFile($"Configs/connectionStrings.{env}.json", optional: true)
//                 .AddEnvironmentVariables()
//                 .Build();
//
//             return new ServiceCollection()
//                 .AddSingleton<IConfiguration>(config)
//                 .AddFluentMigratorCore()
//                 .ConfigureRunner(rb => rb
//                     .AddPostgres10_0()
//                     .WithGlobalConnectionString(x => x.GetRequiredService<IConfiguration>()
//                         .GetConnectionString(DATABASE_NAME))
//                     .ScanIn(typeof(Program).Assembly).For.Migrations())
//                 .AddLogging(lb => { lb.AddSerilog(new LoggerConfiguration().ReadFrom.Configuration(config).CreateLogger()); })
//                 .BuildServiceProvider(false);
//         }
//
//         /// <summary>
//         /// Update the database
//         /// </summary>
//         private static int UpdateDatabase(IServiceProvider serviceProvider)
//         {
//             var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
//             var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
//
//             try
//             {
//                 runner.MigrateUp();
//                 return 0;
//             }
//             catch (Exception ex)
//             {
//                 logger.LogError(ex.Message, ex);
//                 return 1;
//             }
//         }
//     }
// }