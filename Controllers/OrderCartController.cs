using CoffeeShopMVC.Repositories.DTO;
using CoffeeShopMVC.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Controllers
{
    public class OrderCartController : Controller
    {
        private readonly OrderCartService _orderCartService;

        public OrderCartController(OrderCartService orderCartService)
        {
            _orderCartService = orderCartService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /* ---------- jQuery ---------- */
        [HttpGet]
        public async Task<IEnumerable<OrderCartDTO>> GetOrderCartDTO(string id)
        {
            var orderCartDTO = (await _orderCartService.GetOrderCartDTO(id)).Value;

            return orderCartDTO;
        }

        [HttpPost]
        public async Task<int> DeleteItemById(int id)
        {
            var deletedItemId = (await _orderCartService.DeleteItemById(id)).Value;

            return deletedItemId;
        }

    }
}
