using DefinexCase.Service.DTO.Request;
using DefinexCase.Service.DTO.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DefinexCase.Service.Interface
{
    public interface IBasketService
    {
        Task<BasketResponse> AddItemToBasket(BasketRequest request);
        Task<List<ProductResponse>> GetAllProducts();
        Task<BasketResponse> GetBasket(long id);
    }
}
