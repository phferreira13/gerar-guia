﻿

namespace GerarGuia.Domain.Shared.Configuration
{
    public class RabbitMqConfiguration
    {
        public string? Host { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Exchange { get; set; }
        public string? Queue { get; set; }
        public int Port { get; set; }
    }
}

