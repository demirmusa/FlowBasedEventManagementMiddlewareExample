using Example.CoreShareds;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.BLL
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
        public async Task<TReturnType> Get<TReturnType>(string url) =>
             await RequestEndPointAsync<TReturnType>(async (HttpClient client) =>
             {
                 return await client.GetAsync(url);
             });

        public async Task<TReturnType> Post<TReturnType, TPostValue>(string url, TPostValue postData) =>
            await RequestEndPointAsync<TReturnType>(async (HttpClient client) =>
            {
                if (postData != null)
                    return await client.PostAsync(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json"));
                else
                    return await client.PostAsync(url, new StringContent(""));
            });
        public async Task<TReturnType> Put<TReturnType, TPutValue>(string url, TPutValue postData) =>
           await RequestEndPointAsync<TReturnType>(async (HttpClient client) =>
           {
               if (postData != null)
                   return await client.PutAsync(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json"));
               else
                   return await client.PostAsync(url, new StringContent(""));
           });
        public async Task<TReturnType> Delete<TReturnType>(string url) =>
          await RequestEndPointAsync<TReturnType>(async (HttpClient client) =>
          {
              return await client.DeleteAsync(url);
          });
    }
}
