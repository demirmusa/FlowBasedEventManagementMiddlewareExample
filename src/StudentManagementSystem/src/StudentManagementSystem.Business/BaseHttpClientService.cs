using Example.CoreShareds;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Business
{
    public abstract class BaseHttpClientService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseHttpClientService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<GenericResult<TReturnType>> RequestGenericResultReturnsEndPointAsync<TReturnType>(Func<HttpClient, Task<HttpResponseMessage>> clientFunc)
        {
            try
            {
                return await RequestEndPointAsync<GenericResult<TReturnType>>(clientFunc);
            }
            catch (Exception e)
            {
                return GenericResult<TReturnType>.Error(e);
            }
        }
        public async Task<TReturnType> RequestEndPointAsync<TReturnType>(Func<HttpClient, Task<HttpResponseMessage>> clientFunc)
        {
            var client = _httpClientFactory.CreateClient();
            var endPointResult = await clientFunc(client);

            endPointResult.EnsureSuccessStatusCode();

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReturnType>(await endPointResult.Content.ReadAsStringAsync());
            return result;
        }
    }
}
