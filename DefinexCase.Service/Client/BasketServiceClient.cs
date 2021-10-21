using DefinexCase.Service.DTO.Request;
using DefinexCase.Service.DTO.Response;
using DefinexCase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net.Http.Json;

namespace DefinexCase.Service.Client
{
    public class BasketServiceClient : IBasketServiceClient
    {
        private readonly IHttpClientFactory _httpClient;
        public BasketServiceClient(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<BasketResponse> AddItemToBasket(BasketRequest request)
        {
            var httpClient = _httpClient.CreateClient();
            var httpRequest = new Uri("http://localhost:54819/api/basket/add-item");

            var response = await httpClient.PostAsJsonAsync(httpRequest, request);
            //var response = await httpClient.PostAsync(httpRequest, requestJson);

            var model = await response.Content.ReadFromJsonAsync<BasketResponse>();

            return model;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var httpClient = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
            "http://localhost:54819/api/basket/get-all");

            var response = await httpClient.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<List<ProductResponse>>();

            return model;
        }

        public async Task<BasketResponse> GetBasket(long id)
        {
            var httpClient = _httpClient.CreateClient();
            var request = new HttpRequestMessage(HttpMethod.Get,
            $"http://localhost:54819/api/basket/get-basket/{id}");

            var response = await httpClient.SendAsync(request);

            var model = await response.Content.ReadFromJsonAsync<BasketResponse>();

            return model;
        }
    }
}
