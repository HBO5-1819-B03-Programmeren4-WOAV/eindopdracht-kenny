using System;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace B03.EE.BlanckeK.Lib.Helpers
{
    public static class ApiConverter
    {
        #region GetApiResult Method
        public static T GetApiResult<T>(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                Task<String> response = httpClient.GetStringAsync(uri);
                return Task.Factory.StartNew
                (
                    () => JsonConvert.DeserializeObject<T>(response.Result)
                ).Result;
            }
        }
        #endregion

        #region CallApi Method
        private static async Task<TOut> CallApi<TOut, TIn>(string uri, TIn entity, HttpMethod method)
        {
            TOut result = default(TOut);
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response;
                if (method == HttpMethod.Post)
                {
                    response = await httpClient.PostAsJsonAsync(uri, entity);
                }
                else if (method == HttpMethod.Put)
                {
                    response = await httpClient.PutAsJsonAsync(uri, entity);
                }
                else
                {
                    response = await httpClient.DeleteAsync(uri);
                }
                result = await response.Content.ReadAsAsync<TOut>();
            }
            return result;
        }
        #endregion
        // test 
        #region Put
        public static async Task<TOut> PutCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Put);
        }
        #endregion

        #region Post
        public static async Task<TOut> PostCallApi<TOut, TIn>(string uri, TIn entity)
        {
            return await CallApi<TOut, TIn>(uri, entity, HttpMethod.Post);
        }
        #endregion

        #region Delete
        public static async Task<TOut> DelCallApi<TOut>(string uri)
        {
            return await CallApi<TOut, object>(uri, null, HttpMethod.Delete);
        }
        #endregion

    }
}
