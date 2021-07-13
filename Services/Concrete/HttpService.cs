using API.PowerBI.Models;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace API.PowerBI.Services.Concrete
{
    public class HttpService
    {
        private HttpService() { }

        private static HttpClient _client;
        private static Lazy<HttpService> _instance = new Lazy<HttpService>(()=>new HttpService());

        public static HttpService Inastnce
        {
            get
            {   
                return _instance.Value;
            }
        }

        public async Task<HttpResponseMessage> Get(HttpInputModel model)
        {
            GetClient(model);
            return await _client.GetAsync(model.Url);
        }

        public async Task<HttpResponseMessage> Post(HttpInputModel model)
        {
            HttpResponseMessage res;
           GetClient(model);
            res = await _client.PostAsync(model.Url, model.Content);         
            return res;
        }

        public async Task<HttpResponseMessage> Put(HttpInputModel model)
        {
            GetClient(model);
            var res = await _client.PutAsync(model.Url, model.Content);
            return res;
        }
        public async Task<HttpResponseMessage> Delete(HttpInputModel model)
        {
            GetClient(model);
            var res = await _client.DeleteAsync(model.Url);
            return res;
        }


        private void GetClient(HttpInputModel model)
        {
            _client = new HttpClient();
            _client.BaseAddress = new Uri(model.BaseAddress);
            if (model.Headers != null && model.Headers.Count > 0)
            {
                foreach (var header in model.Headers)
                {
                    if (header.Key.ToLower() == "authorization")
                    {
                        var split = header.Value.Split(' ');
                        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(split[0], split[1]);
                    }
                    else
                    {
                        _client.DefaultRequestHeaders.TryAddWithoutValidation(header.Key, header.Value);
                    }
                }
            }
        }
    }
}
