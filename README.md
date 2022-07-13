# gerar-guia
Sistema responsável por pegar os dados de uma guia de pagamento enviados via mensageria, e solicitar a sua geração de acordo com o Cliente configurado.

- O projeto se encontra em .Net Core 6.0
- Utilizado o RabbitMQ como serviço de mensageria
- Atualmente preparado para receber 2 tipos de guias, com modelos de dados já definido pelo cliente (Sistema parceiro que irá de fato enviar os dados para Receita)
- Utiliza uma API simples para simular o envio da dados para o Rabbit, apenas para testes (na prática esse envio ocorrerá por outra aplicação)
- Utiliza uma console application para como um receiver para o RabbitMQ.

Configurações para o appsettings.json dos projetos:

- RabbitMqConfig = Configurção do Rabbit
  - Exchange = Não utilizado
  - Queue = Nome da Queue utilizada
- ClientApiConfiguration = Configuração da API para o sistema parceiro
  - Auth = Caso necessite de autenticação
    - AuthApi = URL para a API de autenticação
  - DarfApi / GnreApi = Configuração das APIS dos dois tipos de guia
    - SendApi = API ao qual o sistema irá enviar os dados
    - RequestApi = API para buscar a guia no sistema parceiro.

Ex:


```
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "RabbitMqConfig": {
    "Exchange": "",
    "Host": "localhost",
    "Username": "guest",
    "Password": "guest",
    "Port": 5672,
    "Queue": "gerar-guia"
  },
  "ClientApiConfiguration": {
    "BaseUrl": "https://api-sistema.com.br",
    "Auth": {
      "User": "user",
      "Password": "senha",
      "AuthApi": "/api/v1/autenticacao"
    },
    "DarfApi": {
      "SendApi": "/api/v1/guia/darf/adiciona",
      "RequestApi": "/api/v1/guia/darf/obter-por-id/"
    },
    "GnreApi": {
      "SendApi": "/api/v1/guia/gnre/adiciona",
      "RequestApi": "/api/v1/guia/gnre/obter-por-id/"
    }
  }
}
