using FluentMigrator.Runner;
using Migrations;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddHostedService<MigrationHostedService>();
builder.Services.AddFluentMigratorCore();
builder.Services.ConfigureRunner(rb => {
    rb.AddPostgres()
      .WithGlobalConnectionString("Host=localhost;Port=5433;Database=helpTrader;Username=root;Password=root")
      .ScanIn(typeof(Program).Assembly).For.Migrations();
});

builder.Services.AddLogging(lb => lb.AddFluentMigratorConsole());

var app = builder.Build();

app.Run();

// using System;
// using System.Linq;
//
// using FluentMigrator.Runner;
// using FluentMigrator.Runner.Initialization;
//
// using Microsoft.Extensions.DependencyInjection;

// namespace test
// {
//     class Program
//     {
//         static void Main(string[] args)
//         {
//             using (var serviceProvider = CreateServices())
//             using (var scope = serviceProvider.CreateScope())
//             {
//                 // Put the database update into a scope to ensure
//                 // that all resources will be disposed.
//                 UpdateDatabase(scope.ServiceProvider);
//             }
//         }
//
//         /// <summary>
//         /// Configure the dependency injection services
//         /// </summary>
//         private static ServiceProvider CreateServices()
//         {
//             return new ServiceCollection()
//                 // Add common FluentMigrator services
//                 .AddFluentMigratorCore()
//                 .ConfigureRunner(rb => rb
//                     // Add SQLite support to FluentMigrator
//                     .AddPostgres()
//                     // Set the connection string
//                     .WithGlobalConnectionString("Host=localhost;Port=5433;Database=helpTrader;Username=root;Password=root")
//                     // Define the assembly containing the migrations
//                     .ScanIn(typeof(Program).Assembly).For.Migrations())
//                 // Enable logging to console in the FluentMigrator way
//                 .AddLogging(lb => lb.AddFluentMigratorConsole())
//                 // Build the service provider
//                 .BuildServiceProvider(false);
//         }
//
//         /// <summary>
//         /// Update the database
//         /// </summary>
//         private static void UpdateDatabase(IServiceProvider serviceProvider)
//         {
//             // Instantiate the runner
//             var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
//
//             // Execute the migrations
//             runner.MigrateUp();
//         }
//     }
// }