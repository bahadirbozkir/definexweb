using DefinexCase.Service.DTO.Request;
using DefinexCase.Service.DTO.Response;
using DefinexCase.Service.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexCase.Service.Services
{
    public class BasketService : IBasketService
    {
        private readonly IBasketServiceClient _basketServiceClient;

        public BasketService(IBasketServiceClient basketServiceClient)
        {
            _basketServiceClient = basketServiceClient;
        }
        public async Task<BasketResponse> AddItemToBasket(BasketRequest request)
        {
            var response = await _basketServiceClient.AddItemToBasket(request);

            return response;
        }

        public async Task<List<ProductResponse>> GetAllProducts()
        {
            var response = await _basketServiceClient.GetAllProducts();

            return response;
        }

        public async Task<BasketResponse> GetBasket(long id)
        {
            var response = await _basketServiceClient.GetBasket(id);

            return response;
        }
    }
}
