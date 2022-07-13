using GerarGuia.Domain.Shared.Configuration;
using GerarGuia.Rabbit.Interface.Services;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using System.Text;

namespace GerarGuia.Rabbit.Services
{
    /// <summary>
    /// Classe referente ao serviço de envio de mensagens para o RabbitMQ
    /// </summary>
    public class MessageService: IMessageService
    {
        private readonly ConnectionFactory _factory;
        private readonly RabbitMqConfiguration _config;
        public MessageService(IOptions<RabbitMqConfiguration> options)
        {
            _config = options.Value;

            _factory = new ConnectionFactory
            {
                HostName = _config.Host,
                Port = _config.Port,
                UserName = _config.Username,
                Password = _config.Password
            };
        }
        public void SendMessage(string stringfiedMessage)
        {
            using (var connection = _factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: _config.Queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);

                    var bytesMessage = Encoding.UTF8.GetBytes(stringfiedMessage);

                    channel.BasicPublish(
                        exchange: "",
                        routingKey: _config.Queue,
                        basicProperties: null,
                        body: bytesMessage);
                }
            }
        }
    }
}
