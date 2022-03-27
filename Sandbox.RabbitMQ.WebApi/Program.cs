using OLT.Core;
using OLT.Logging.Serilog;
using RabbitMQ.Client.Core.DependencyInjection;
using RabbitMQ.Client.Core.DependencyInjection.Configuration;
using Sandbox.RabbitMQ.WebApi.AppCode;
using Sandbox.RabbitMQ.WebApi.LocalServices;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var services = builder.Services;

services.AddOltInjection(Assembly.GetEntryAssembly());
services.AddScoped<IOltIdentity, AppIdentity>();

services.AddOltSerilog(configOptions => configOptions.ShowExceptionDetails = true);

//var rabbitMqConfiguration = new RabbitMqServiceOptions
//{
//    HostName = "127.0.0.1",
//    Port = 5672,
//    UserName = "admin",
//    Password = "admin"
//};

//var exchangeOptions = new RabbitMqExchangeOptions
//{
//    Queues = new List<RabbitMqQueueOptions>
//                {
//                    new RabbitMqQueueOptions
//                    {
//                        Name = "myqueue",
//                        RoutingKeys = new HashSet<string> { "routing.key" }
//                    }
//                }
//};

//services.AddRabbitMqProducer(rabbitMqConfiguration)
//    .AddProductionExchange("olt.default", exchangeOptions)
    //.AddConsumptionExchange<CustomAsyncMessageHandler>("olt.");

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseOltSerilogRequestLogging();

app.UseAuthorization();

app.MapControllers();

app.Run();
