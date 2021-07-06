using CoffeeShopMVC.Models.Purchase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Repositories.DTO
{
    public class OrderCartDTO
    {
        public int ID { get; set; }
        public int Quantity { get; set; }
        public int ItemProductID { get; set; }
        public string ItemProductCategory { get; set; }
        public string ItemProductName { get; set; }
        public decimal ItemProductPrice { get; set; }
        public decimal ItemProductTotalPrice { get; set; }

        public static Expression<Func<OrderCart, OrderCartDTO>> OrderCartSelector
        {
            get
            {
                return orderCart => new OrderCartDTO()
                {
                    ID = orderCart.ID,
                    Quantity = orderCart.Quantity,
                    ItemProductID = orderCart.ItemProductID,
                    ItemProductCategory = orderCart.ItemProduct.Category,
                    ItemProductName = orderCart.ItemProduct.Name,
                    ItemProductPrice = orderCart.ItemProduct.Price,
                    ItemProductTotalPrice = (orderCart.ItemProduct.Price * orderCart.Quantity)
                };
            }
        }
    }
}
