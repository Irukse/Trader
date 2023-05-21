using HelpTrader;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
var startup = new Startup(builder.Configuration);
startup.ConfigureServices(builder.Services); // calling ConfigureServices method
var app = builder.Build();
startup.Configure(app); // calling Configure method