namespace GerarGuia.Rabbit.Interface.Services
{
    /// <summary>
    /// Serviço de envio de mensagens para o RabbitMQ
    /// </summary>
    public interface IMessageService
    {
        /// <summary>
        /// Método que irá postar uma mensagen no Rabbit, de acordo com os parâmetros configurados
        /// no appsettings.json
        /// </summary>
        /// <param name="stringfiedMessage"></param>
        void SendMessage(string stringfiedMessage);
    }
}
