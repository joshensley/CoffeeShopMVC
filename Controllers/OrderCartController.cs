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


        // OrderCartGroup IS HARDCODED
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orderCartDTO = (await _orderCartService.GetOrderCartDTO("0.6896846620376818")).Value;

            return View(orderCartDTO);
        }

        /* ---------- jQuery ---------- */
        [HttpPost]
        public async Task<int> DeleteItemById(int id)
        {
            var deletedItemId = (await _orderCartService.DeleteItemById(id)).Value;

            return deletedItemId;
        }

    }
}
