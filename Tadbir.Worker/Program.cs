using Microsoft.Extensions.Configuration;
using Serilog;
using Serilog.Events;
using Tadbir.DapperDataAccess;
using Tadbir.DapperDataAccess.Repositories;
using Tadbir.Domain.Cofiguration;
using Tadbir.Domain.Consumer;
using Tadbir.Domain.Core;
using Tadbir.Domain.Domain;
using Tadbir.Domain.Dto;
using Tadbir.Domain.Mappers;
using Tadbir.Domain.Repositories;
using Tadbir.Domain.Service;
using Tadbir.Redis;
using Tadbir.Service.Consumer;
using Tadbir.Service.Services;
using Tadbir.Worker;

HostApplicationBuilder builder = Host.CreateApplicationBuilder(args);

builder.Services.AddHostedService<Worker>();
builder.Services.AddSingleton<IMessageBrokerSettings, RabbitMqConfiguration>();
builder.Services.AddSingleton<IPersonConsumerService, PersonConsumerService>();
builder.Services.AddSingleton<IPersonService, PersonService>();
builder.Services.AddSingleton<IPersonRepository, PersonRepository>();
builder.Services.AddSingleton<IEntityMapper<Person,PersonDto>, PersonMapper>();
builder.Services.AddSingleton<ICacheService,CacheService>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddLogging(b =>
{
var configuration = new ConfigurationBuilder()
.AddJsonFile("appsettings.json")
.Build();
var logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .Enrich.WithMachineName()
                .Enrich.WithThreadId()
                
                .CreateLogger();
    b.AddSerilog(logger);
});





IHost host = builder.Build();
host.Run();
