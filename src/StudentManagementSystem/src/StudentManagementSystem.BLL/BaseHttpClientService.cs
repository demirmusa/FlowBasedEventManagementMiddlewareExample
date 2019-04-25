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
        protected async Task<TReturnType> RequestEndPointAsync<TReturnType>(Func<HttpClient, Task<HttpResponseMessage>> clientFunc)
        {
            var client = _httpClientFactory.CreateClient();
            var endPointResult = await clientFunc(client);

            endPointResult.EnsureSuccessStatusCode();

            var result = Newtonsoft.Json.JsonConvert.DeserializeObject<TReturnType>(await endPointResult.Content.ReadAsStringAsync());
            return result;
        }
        protected async Task<GenericResult<TReturnType>> RequestGenericResultReturnsEndPointAsync<TReturnType>(Func<HttpClient, Task<HttpResponseMessage>> clientFunc)
        {
            try
            {
                return await RequestEndPointAsync<GenericResult<TReturnType>>(clientFunc);
            }
            catch (Exception e)
            {
                //TODO: log
                return GenericResult<TReturnType>.Error(e);
            }
        }
     
        /// <summary>
        ///  Calls http GetAsync with given url. Does not handle exception
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<TReturnType> Get<TReturnType>(string url) =>
             await RequestEndPointAsync<TReturnType>(async (HttpClient client) => await client.GetAsync(url));

        /// <summary>
        ///  Calls http PostAsync with given url. Does not handle exception
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<TReturnType> Post<TReturnType, TPostValue>(string url, TPostValue postData) =>
            await RequestEndPointAsync<TReturnType>(async (HttpClient client) =>
            {
                if (postData != null)
                    return await client.PostAsync(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json"));
                else
                    return await client.PostAsync(url, new StringContent(""));
            });
        /// <summary>
        ///  Calls http PutAsync with given url. Does not handle exception
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <typeparam name="TPutValue"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        protected async Task<TReturnType> Put<TReturnType, TPutValue>(string url, TPutValue postData) =>
           await RequestEndPointAsync<TReturnType>(async (HttpClient client) =>
           {
               if (postData != null)
                   return await client.PutAsync(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json"));
               else
                   return await client.PostAsync(url, new StringContent(""));
           });

        /// <summary>
        ///  Calls http DeleteAsync with given url. Does not handle exception
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<TReturnType> Delete<TReturnType>(string url) =>
          await RequestEndPointAsync<TReturnType>(async (HttpClient client) => await client.DeleteAsync(url));

        /// <summary>
        /// Call get whose endpoint return generic result. If an error happens it will handle it
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <typeparam name="TPostValue"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        protected async Task<GenericResult<TReturnType>> GetG<TReturnType>(string url) =>
            await RequestGenericResultReturnsEndPointAsync<TReturnType>(async (HttpClient client) => await client.GetAsync(url));
        /// <summary>
        /// Call post whose endpoint return generic result. If an error happens it will handle it
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <typeparam name="TPostValue"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        protected async Task<GenericResult<TReturnType>> PostG<TReturnType, TPostValue>(string url, TPostValue postData) =>
            await RequestGenericResultReturnsEndPointAsync<TReturnType>(async (HttpClient client) =>
            {
                if (postData != null)
                    return await client.PostAsync(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json"));
                else
                    return await client.PostAsync(url, new StringContent(""));
            });
        /// <summary>
        ///  Call put whose endpoint return generic result. If an error happens it will handle it
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <typeparam name="TPutValue"></typeparam>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <returns></returns>
        protected async Task<GenericResult<TReturnType>> PutG<TReturnType, TPutValue>(string url, TPutValue postData) =>
            await RequestGenericResultReturnsEndPointAsync<TReturnType>(async (HttpClient client) =>
            {
                if (postData != null)
                    return await client.PutAsync(url, new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(postData), System.Text.Encoding.UTF8, "application/json"));
                else
                    return await client.PostAsync(url, new StringContent(""));
            });
        /// <summary>
        /// Call delete whose endpoint return generic result. If an error happens it will handle it
        /// </summary>
        /// <typeparam name="TReturnType"></typeparam>
        /// <param name="url"></param>
        /// <returns></returns>
        protected async Task<GenericResult<TReturnType>> DeleteG<TReturnType>(string url) =>
            await RequestGenericResultReturnsEndPointAsync<TReturnType>(async (HttpClient client) => await client.DeleteAsync(url));





    }
}
