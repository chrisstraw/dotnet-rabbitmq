using RabbitMQ.Client;
using System.Text;

namespace Sandbox.RabbitMQ.WebApi.AppCode
{
    
    public class SendMessage
    {
        public void Send()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello", durable: false, exclusive: false, autoDelete: false, arguments: null);

                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "", routingKey: "hello", basicProperties: null, body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }



    //public interface IMessageProducer
    //{
    //    void SendMessage<T>(T message);
    //}

    //public class RabbitMQProducer : IMessageProducer
    //{
    //    public void SendMessage<T>(T message)
    //    {
    //    }
    //}


    //namespace Examples.AdvancedConfiguration.MessageHandlers
    //{
    //    public class CustomMessageHandler : IMessageHandler
    //    {
    //        private readonly ILogger<CustomMessageHandler> _logger;

    //        public CustomMessageHandler(ILogger<CustomMessageHandler> logger)
    //        {
    //            _logger = logger;
    //        }

    //        public void Handle(MessageHandlingContext context, string matchingRoute)
    //        {
    //            _logger.LogInformation(matchingRoute);

    //            // The message handler does not do anything.
    //            // It is just an example.
    //        }
    //    }
    //}

    //public class CustomAsyncMessageHandler : IAsyncMessageHandler
    //{
    //    private readonly ILogger<CustomAsyncMessageHandler> _logger;

    //    public CustomAsyncMessageHandler(ILogger<CustomAsyncMessageHandler> logger)
    //    {
    //        _logger = logger;
    //    }

    //    public async Task Handle(MessageHandlingContext context, string matchingRoute)
    //    {

    //        _logger.LogInformation(matchingRoute);

    //        // The message handler does not do anything.
    //        // It is just an example.
    //        await Task.CompletedTask;
    //    }
    //}


}
