using MassTransit;

namespace ServicoDePagamento;

public static class AppExtrensions
{
    public static void AddRabbit(this IServiceCollection services)
    {
        services.AddMassTransit(busConfigurator => 
        {
            busConfigurator.AddConsumer<ClienteEventConsumer>();

            busConfigurator.UsingRabbitMq((ctx,cfg) =>{
                cfg.Host(new Uri("amqp://localhost:5672"),host =>
                 {
                    host.Username("guest");
                    host.Password("guest");
                });

                cfg.ConfigureEndpoints(ctx);
            });
        });
    }
}
