using DefinexCase.Service.Interface;
using DefinexCase.Session;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefinexCase.Controllers
{
    public class ProductController : Controller
    {
        private readonly IBasketService _basketService;

        public ProductController(IBasketService basketService)
        {
            _basketService = basketService;
        }
        public async Task<IActionResult> Index()
        {
            var result = await _basketService.GetAllProducts();

            ViewBag.produtList = result;
            return View();
        }
    }
}
