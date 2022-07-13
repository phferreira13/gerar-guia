using GerarGuia.Domain.Entities;
using GerarGuia.Domain.Entities.DadosGuia.Envio;
using GerarGuia.Domain.Shared.Enum;
using GerarGuia.Rabbit.Interface.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace GerarGuia.Controllers
{
    public class GuiaController : ControllerBase
    {
        private readonly IMessageService messageService;
        public GuiaController(IMessageService messageService)
        {   
            this.messageService = messageService;
        }
        /// <summary>
        /// API para simular a solicitação de geração da guia.
        /// Esta API irá enviar uma message para o RabbitMQ, simulando o sistema de origem.
        /// </summary>
        /// <param name="darf"></param>
        /// <returns></returns>
        [HttpPost("TestDarf")]
        public IActionResult TestDarf([FromBody] DarfEnvio darf)
        {
            Guia<DarfEnvio> guia = new Guia<DarfEnvio>
            {
                TipoGuia = ETipoGuia.DARF,
                Dados = darf
            };
            var message = JsonSerializer.Serialize(guia);
            messageService.SendMessage(message);
            return Ok();
        }
    }
}
