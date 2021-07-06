using CoffeeShopMVC.Areas.Admin.Services;
using CoffeeShopMVC.Models;
using CoffeeShopMVC.Models.Purchase;
using CoffeeShopMVC.Repositories.DTO;
using CoffeeShopMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static CoffeeShopMVC.Services.OrderCartService;

namespace CoffeeShopMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ItemProductServices _itemProductServices;
        private readonly OrderCartService _orderCartServices;

        public HomeController(
            ILogger<HomeController> logger, 
            ItemProductServices itemProductServices,
            OrderCartService orderCartService)
        {
            _logger = logger;
            _itemProductServices = itemProductServices;
            _orderCartServices = orderCartService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var itemProductDTO = (await _itemProductServices.GetItemProductDTO()).Value;

            return View(itemProductDTO);
        }


        /* ---------- jQuery ---------- */
        [HttpGet]
        public async Task<IEnumerable<OrderCartDTO>> GetOrderCartDTO(string orderCartGroup)
        {
            var orderCart = (await _orderCartServices.GetOrderCartDTO(orderCartGroup)).Value;

            return orderCart;
        }

       
        [HttpGet]
        public async Task<OrderCartDTO> GetByIdOrderCartDTO(int id)
        {
            var orderCartItem = (await _orderCartServices.GetByIdOrderCartDTO(id)).Value;

            return orderCartItem;
        }

        [HttpPost]
        public async Task<OrderCartDTO> AddToOrder()
        {
            MemoryStream stream = new MemoryStream();
            await Request.Body.CopyToAsync(stream);
            stream.Position = 0;

            var postData = new PostData();
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    postData = _orderCartServices.DeserializeCartOrderPostData(requestBody);
                }
            }

            OrderCart model = new ()
            {
                ItemProductID = postData.ItemValue,
                Quantity = postData.InputCountValue,
                OrderCartGroup = postData.OrderCartGroup
            };

            var orderCart = (await _orderCartServices.PostOrderCart(model)).Value;

            var orderCartDTO = (await _orderCartServices.GetByIdOrderCartDTO(id: orderCart.ID)).Value;

            return orderCartDTO;
        }



        [HttpPost]
        public int Add(int number1, int number2)
        {
            return number1 + number2;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
