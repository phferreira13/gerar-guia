using GerarGuia.ApiClient.Interface;
using GerarGuia.Domain.Entities;
using GerarGuia.Domain.Entities.DadosGuia.Envio;
using GerarGuia.Domain.Entities.DadosGuia.Retorno;
using GerarGuia.Domain.Shared.Configuration;
using GerarGuia.Domain.Shared.Enum;
using Microsoft.Extensions.Options;

namespace GerarGuia.ApiClient.Services
{
    public class GuiaService: IGuiaService
    {
        private readonly IApiClientService apiClientService;
        private readonly ClientApiConfiguration apiConfiguration;
        public GuiaService(IApiClientService apiClientService, IOptions<ClientApiConfiguration> options)
        {
            apiConfiguration = options.Value;
            this.apiClientService = apiClientService;
        }

        public void Gerar(Guia<Object> guia)
        {
            switch (guia.TipoGuia)
            {
                case ETipoGuia.DARF:
                    {
                        GerarDarf(guia.Cast<Guia<DarfEnvio>>());
                        break;
                    }
                case ETipoGuia.GNRE:
                    {
                        GerarGnreAsync(guia.Cast<Guia<GnreEnvio>>());
                        break;
                    }
            }
        }

        private async void GerarDarf(Guia<DarfEnvio> darf)
        {
            var authObject = new
            {
                Email = apiConfiguration.Auth.User,
                Senha = apiConfiguration.Auth.Password
            };
            var auth = await apiClientService.GetAuthResultAsync<AuthResponse>(authObject, apiConfiguration.BaseUrl, apiConfiguration.Auth.AuthApi);
            await apiClientService.SendDataAsync<AuthResponse, GuiaReturn, DarfEnvio>(darf,
                apiConfiguration.BaseUrl,
                apiConfiguration.DarfApi.SendApi, auth);
        }

        private async void GerarGnreAsync(Guia<GnreEnvio> gnre)
        {
            var authObject = new
            {
                Email = apiConfiguration.Auth.User,
                Senha = apiConfiguration.Auth.Password
            };
            var auth = await apiClientService.GetAuthResultAsync<AuthResponse>(authObject, apiConfiguration.BaseUrl, apiConfiguration.Auth.AuthApi);
            await apiClientService.SendDataAsync<AuthResponse, GuiaReturn, GnreEnvio>(gnre,
                apiConfiguration.BaseUrl,
                apiConfiguration.GnreApi.SendApi, auth);
        }
    }
}
