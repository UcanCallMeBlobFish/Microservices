using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using WebApplication1.DTO;

namespace WebApplication1.AsyncDataServices
{
    public class MessageBusClient : IMessageBusClient
    {
        private readonly IConfiguration _configuration;
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public MessageBusClient(IConfiguration configuration)
        {
            _configuration = configuration;
            var factory = new ConnectionFactory()
            {
                HostName = _configuration["RabbitMQHost"],
                Port =int.Parse( _configuration["RabbitMQPort"])

            };
            try
            {
                _connection = factory.CreateConnection();
                _channel = _connection.CreateModel();

                _channel.ExchangeDeclare(exchange: "trigger", type: ExchangeType.Fanout);

                _connection.ConnectionShutdown += RabitMQ_ConnectionShutDown;

                Console.WriteLine("-->connected to messagebus")
;            }
            catch(Exception ex)
            {
                Console.WriteLine($"Cannot connect to messagebus{ex.Message}");
            }
        }

        public void PublishNewPlatform(PlatformPublishDTO pulatformPublishedDTO)
        {
            var message = JsonSerializer.Serialize(pulatformPublishedDTO);
            if (_connection.IsOpen)
            {
                Console.WriteLine("--> rabbitmq connection open.Sending a message");
                SendMessage(message);
            }
            else
            {
                Console.WriteLine("Connection is closed.");
            }
        }
        private void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "trigger",
                routingKey: "",
                basicProperties: null,
                body: body);
            Console.WriteLine($"We have sent {message}");
        }

        public void Dispose()
        {
            Console.WriteLine("messagebus disposed");
            if(_channel.IsOpen) 
            {
                _channel.Close();
                _connection.Close();
            }
        }
        private void RabitMQ_ConnectionShutDown(object sender, ShutdownEventArgs e)
        {
            Console.WriteLine("==> conenection shuttdown");
        }
    }
}
