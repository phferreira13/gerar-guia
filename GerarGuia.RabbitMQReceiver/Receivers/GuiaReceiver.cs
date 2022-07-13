using GerarGuia.ApiClient.Interface;
using GerarGuia.Domain.Entities;
using GerarGuia.Domain.Shared.Configuration;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;

namespace GerarGuia.RabbitMQReceiver.Receivers
{
    public class GuiaReceiver: BackgroundService
    {
        private readonly ConnectionFactory _factory;
        private readonly RabbitMqConfiguration _config;
        private readonly IConnection _connection;
        private readonly IModel _channel;
        private readonly IGuiaService guiaService;
        public GuiaReceiver(IOptions<RabbitMqConfiguration> options, IGuiaService guiaService, IOptions<ClientApiConfiguration> options2)
        {
            this.guiaService = guiaService;
            _config = options.Value;

            _factory = new ConnectionFactory
            {
                HostName = _config.Host,
                Port = _config.Port,
                UserName = _config.Username,
                Password = _config.Password
            };

            _connection = _factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(
                        queue: _config.Queue,
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var consumer = new EventingBasicConsumer(_channel);

            consumer.Received += async (sender, eventArgs) =>
            {
                var contentArray = eventArgs.Body.ToArray();
                var contentString = Encoding.UTF8.GetString(contentArray);
                var guia = JsonSerializer.Deserialize<Guia<Object>>(contentString);    
                guiaService.Gerar(guia);
            };
            _channel.BasicConsume(_config.Queue, false, consumer);
            return Task.CompletedTask;
        }
    }
}
