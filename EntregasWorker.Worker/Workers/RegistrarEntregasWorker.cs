using EntregasWorker.Domain.Service.Events;
using static Confluent.Kafka.ConfigPropertyNames;
using System.Threading;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using EntregasWorker.Domain.Models;
using EntregasWorker.Application.CasosUso.AdministrarEntregas.RegistrarEntrega;
using Newtonsoft.Json;

namespace EntregasWorker.Worker.Workers
{
    public class RegistrarEntregasWorker : BackgroundService
    {
        private readonly IConsumerFactory _consumerFactory;
        private readonly IServiceProvider _serviceProvider;

        public RegistrarEntregasWorker(IConsumerFactory consumerFactory, IServiceProvider serviceProvider)
        {
            _consumerFactory = consumerFactory;
            _serviceProvider = serviceProvider;
        }
        protected override async Task ExecuteAsync(CancellationToken cancellationToken)
        {
            var consumer = _consumerFactory.GetConsumer();
            consumer.Subscribe("entregas");

            while (!cancellationToken.IsCancellationRequested)
            {
                using var scope = _serviceProvider.CreateScope();
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();

                var consumeResult = consumer.Consume(cancellationToken);
                //Llamar al handler para registrar la información de la entrega
                RegistrarEntregaRequest request = JsonConvert.DeserializeObject<RegistrarEntregaRequest>(consumeResult.Value);

                await mediator.Send(request);
            }

            consumer.Close();

        }

    }
}
