using CoffeeShopMVC.Models.Purchase;
using CoffeeShopMVC.Repositories;
using CoffeeShopMVC.Repositories.DTO;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Services
{
    public class OrderCartService
    {
        public readonly IOrderCartRepository _orderCartRepository;

        public OrderCartService(IOrderCartRepository orderCartRepository)
        {
            _orderCartRepository = orderCartRepository;
        }

        public class PostData
        {
            public int ItemValue { get; set; }
            public int InputCountValue { get; set; }
            public string OrderCartGroup { get; set; }
        }

        // GET: Order Cart
        public async Task<ActionResult<IEnumerable<OrderCartDTO>>> GetOrderCartDTO(string orderCartGroup)
        {
            return await _orderCartRepository.Get(orderCartGroup, OrderCartDTO.OrderCartSelector);
        }

        // Get: Order Cart Item by Id
        public async Task<ActionResult<OrderCartDTO>> GetByIdOrderCartDTO(int id)
        {
            return await _orderCartRepository.GetById(id, OrderCartDTO.OrderCartSelector);
        }

        // DESERIALIZE: Deserialize new cart order post data
        public PostData DeserializeCartOrderPostData(string requestBody)
        {
            int itemValue = 0;
            int inputCountValue = 0;
            string orderCartGroup = "";

            var obj = JsonConvert.DeserializeObject<PostData>(requestBody);
            if (obj != null)
            {
                itemValue = obj.ItemValue;
                inputCountValue = obj.InputCountValue;
                orderCartGroup = obj.OrderCartGroup;
            }

            PostData postData = new()
            {
                ItemValue = itemValue,
                InputCountValue = inputCountValue,
                OrderCartGroup = orderCartGroup
            };

            return postData;
        }

        // POST: Post new order in cart
        public async Task<ActionResult<OrderCart>> PostOrderCart(OrderCart model)
        {
            return await _orderCartRepository.Post(model);
        }

        // DELETE: Delete item in order cart
        public async Task<ActionResult<int>> DeleteItemById(int id)
        {
            return await _orderCartRepository.Delete(id);
        }
    }
}
