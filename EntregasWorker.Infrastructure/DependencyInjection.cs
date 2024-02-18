using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using EntregasWorker.Domain.Repositories;
using MongoDB.Driver;
using Confluent.Kafka;
using EntregasWorker.Domain.Service.Events;
using EntregasWorker.Infrastructure.Services.Events;
using EntregasWorker.CrossCutting.Configs;
using System.Net;
using Microsoft.Extensions.Configuration;
using EntregasWorker.Infrastructure.Repositories;


namespace EntregasWorker.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddInfraestructure(
            this IServiceCollection services, IConfiguration configInfo)
        {

            services.AddDataBaseFactories(configInfo);
            services.AddRepositories();
            services.AddProducer(configInfo);
            services.AddEventServices();
            services.AddConsumer(configInfo);
        }

        private static void AddDataBaseFactories(this IServiceCollection services, IConfiguration configInfo)
        {
            var appConfiguration = new AppConfiguration(configInfo);

            services.AddSingleton(mongoDatabase =>
            {
                var mongoClient = new MongoClient(appConfiguration.DbEntregasCnx);
                return mongoClient.GetDatabase(appConfiguration.DbEntregasDb);
            });

        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IEntregaRepository, EntregaRepository>();

        }

        private static IServiceCollection AddProducer(this IServiceCollection services, IConfiguration configInfo)
        {
            var appConfiguration = new AppConfiguration(configInfo);

            var config = new ProducerConfig
            {
                Acks = Acks.Leader,
                BootstrapServers = appConfiguration.UrlKafkaServer,
                ClientId = Dns.GetHostName(),
            };

            services.AddSingleton<IPublisherFactory>(sp => new PublisherFactory(config));
            return services;
        }

        private static IServiceCollection AddConsumer(this IServiceCollection services, IConfiguration configInfo)
        {
            var appConfiguration = new AppConfiguration(configInfo);

            var config = new ConsumerConfig
            {
                BootstrapServers = appConfiguration.UrlKafkaServer,
                GroupId = "venta-registrar-entregas",
                AutoOffsetReset = AutoOffsetReset.Latest
            };

            services.AddSingleton<IConsumerFactory>(sp => new ConsumerFactory(config));
            return services;
        }

        private static void AddEventServices(this IServiceCollection services)
        {
            services.AddSingleton<IEventSender, EventSender>();
        }
    }
}
