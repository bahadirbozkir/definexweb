using DefinexCase.Models;
using DefinexCase.Service.DTO.Enum;
using DefinexCase.Service.DTO.Request;
using DefinexCase.Service.Interface;
using DefinexCase.Session;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefinexCase.Controllers
{
    public class BasketController : Controller
    {
        private readonly IBasketService _basketService;
        private readonly ICreditApplicationService _creditApplicationService;

        public BasketController(IBasketService basketService, ICreditApplicationService creditApplicationService)
        {
            _basketService = basketService;
            _creditApplicationService = creditApplicationService;
        }
        public async Task<IActionResult> Index()
        {
            var basketId = SessionHelper.GetObjectFromJson<long>(HttpContext.Session, "cart");
            if (basketId != 0)
            {
                var result = await _basketService.GetBasket(basketId);
                ViewBag.basket = result;
            }
            
            return View();
        }

        [HttpPost]
        [Route("Basket/AddToBasket")]
        public async Task<IActionResult> AddToBasket(BasketRequest request)
        {
            //var allProducts = await _basketService.GetAllProducts();
            //var selectedProduct = allProducts.FirstOrDefault(x => x.Id == long.Parse(id));
            var basketId = SessionHelper.GetObjectFromJson<long>(HttpContext.Session, "cart");
            var basketRequest = new BasketRequest
            {
                Id = basketId,
                BasketItem = new BasketItemRequest
                {
                    Id = request.BasketItem.Id,
                    Quantity = 1
                }
            };
            
            var result = await _basketService.AddItemToBasket(basketRequest);

            if (SessionHelper.GetObjectFromJson<long>(HttpContext.Session, "cart") == 0)
            {                
                SessionHelper.SetObjectAsJson(HttpContext.Session, "cart", result.Id.ToString());
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [Route("Basket/CreditApplication")]
        public async Task<IActionResult> CreditApplication(CreditApplicationRequest request)
        {
            var result = await _basketService.GetBasket(request.BasketId);
            var basketItems = result.BasketItems;
            var basketTotal = basketItems.Sum(x => x.Price);

            var products = await _basketService.GetAllProducts();

            var categoryIds = new List<long>();
            foreach (var basketItem in basketItems)
            {
                categoryIds.Add(products.FirstOrDefault(x => x.Id == basketItem.ProductId).Category.Id);
            }

            var paymentRequest = new PaymentRequest
            {
                BankType = (BankType)request.BankType,
                PaymentMethodType = (PaymentMethodType)request.PaymentMethodType,
                Order = new OrderRequest
                {
                    Total = basketTotal,
                    CategoryList = categoryIds
                }
            };

            var response = await _creditApplicationService.Proceed(paymentRequest);
            var creditApplicationViewModel = new CreditApplicationViewModel
            {
                IsSuccess = false
            };
            if (response.IsSuccess)
            {
                creditApplicationViewModel.IsSuccess = true;
            }
            else
            {
                creditApplicationViewModel.IsSuccess = false;
            }

            return Json(new { success = true, responseText = response.IsSuccess });
        }
    }
}
