using HelpTrader;
using HelpTrader.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
builder.Services.AddHostedService<InitialDataOfTheDatabase>();
var app = builder.Build();

Startup.Configure(app); // calling Configure method