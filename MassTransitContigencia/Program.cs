using MassTransit;
using MassTransitContigencia.Consumers;
using MassTransitContigencia.ModulesIoc;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<ConsumerOperante>();
    x.AddConsumer<ConsumerInoperante>();

    x.UsingRabbitMq((context, config) =>
    {
        config.Host(builder.Configuration.GetConnectionString("RabbitMq"));

        config.ReceiveEndpoint("operacional", e =>
        {
            e.ConfigureConsumer<ConsumerInoperante>(context);
            e.ConfigureConsumer<ConsumerOperante>(context);
            config.UseMessageRetry(r => r.Interval(5, 100));

        });
    });
});

builder.Services.AddHostedService<MassTransitHostedService>();

Modules.RegisterModules(builder.Services);

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
