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
