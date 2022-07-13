using GerarGuia.ApiClient.Interface;
using GerarGuia.Domain.Entities;
using GerarGuia.Domain.Entities.DadosGuia.Envio;
using GerarGuia.Domain.Interface;
using GerarGuia.Domain.Shared.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GerarGuia.ApiClient.Services
{
    public class ApiClientService: IApiClientService
    {
        private StringContent ConstructBody(object obj)
        {
            var json = new StringContent(JsonSerializer.Serialize(obj));

            json.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            return json;
        }
        private T DeserializeResponse<T>(string jsonReturn)
        {
            return JsonSerializer.Deserialize<T>(jsonReturn, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });
        }
        public async Task<T> GetAuthResultAsync<T>(Object jsonAuthModel, string baseUrl, string authApi) where T : IAuthResult
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            HttpResponseMessage httpResponseMessage = await httpClient.PostAsync(authApi, ConstructBody(jsonAuthModel));
            var jsonResponseAuth = await httpResponseMessage.Content.ReadAsStringAsync();

            var authResponse = DeserializeResponse<T>(jsonResponseAuth);
            return authResponse;
        }

        public async Task<R> SendDataAsync<A, R, G>(Guia<G> guia, string baseUrl, string apiUrl, A? auth) where A : IAuthResult
        {
            var httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseUrl)
            };
            httpClient.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json; charset=utf-8");
            if (auth?.AuthKey != null)
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(auth.AuthType, auth.AuthKey);
            }
            StringContent guiaBody = ConstructBody(guia);
            switch (guia.TipoGuia)
            {
                case ETipoGuia.DARF:
                    {
                        guiaBody = ConstructBody(guia.Cast<Guia<DarfEnvio>>().Dados);
                        break;
                    }
                case ETipoGuia.GNRE:
                    {
                        guiaBody = ConstructBody(guia.Cast<Guia<GnreEnvio>>().Dados);
                        break;
                    }
            }

            var response = await httpClient.PostAsync(apiUrl, guiaBody);
            return DeserializeResponse<R>(await response.Content.ReadAsStringAsync());

        }
    }
}
