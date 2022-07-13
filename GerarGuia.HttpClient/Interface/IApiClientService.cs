using GerarGuia.Domain.Entities;
using GerarGuia.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerarGuia.ApiClient.Interface
{
    public interface IApiClientService
    {
        Task<T> GetAuthResultAsync<T>(Object jsonAuthModel, string baseUrl, string authApi) where T : IAuthResult;
        Task<R> SendDataAsync<A, R, G>(Guia<G> guia, string baseUrl, string apiUrl, A? auth) where A : IAuthResult;
    }
}
