using Confluent.Kafka;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntregasWorker.Domain.Service.Events
{
    public interface IConsumerFactory
    {
        IConsumer<string, string> GetConsumer();
    }
}
