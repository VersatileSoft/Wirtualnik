using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Wirtualnik.Shared.ApiClient
{
    public abstract class AbstractClient<TModel> : IAbstractClient<TModel>
    {
        protected abstract string ControllerPath { get; }

        protected readonly HttpClient _httpClient;
        protected AbstractClient(HttpClient client)
        {
            _httpClient = client;
        }

        public async Task<IEnumerable<TModel>> AllAsync()
        {
            var response = await _httpClient.GetAsync($"{ControllerPath}/all");
            var result = JsonConvert.DeserializeObject<IEnumerable<TModel>>(await response.Content.ReadAsStringAsync());

            if (result is null) throw new Exception();
            return result;
        }

        public async Task<TModel> ByIdAsync(int id)
        {
            var response = await _httpClient.GetAsync($"{ControllerPath}/{id}");
            var result = JsonConvert.DeserializeObject<TModel>(await response.Content.ReadAsStringAsync());

            if (result is null) throw new Exception();
            return result;
        }

        public async Task CreateAsync(TModel value)
        {
            string myContent = JsonConvert.SerializeObject(value);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            await _httpClient.PostAsync(ControllerPath, content);
        }

        public async Task DeleteAsync(int id)
        {
            await _httpClient.DeleteAsync($"{ControllerPath}/{id}");
        }

        public async Task UpdateAsync(int id, TModel value)
        {
            string myContent = JsonConvert.SerializeObject(value);
            var content = new StringContent(myContent, Encoding.UTF8, "application/json");
            await _httpClient.PutAsync($"{ControllerPath}/{id}", content);
        }
    }
}