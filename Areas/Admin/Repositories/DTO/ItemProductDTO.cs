using CoffeeShopMVC.Areas.Admin.Models.ProductInformation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Areas.Admin.Repositories.DTO
{
    public class ItemProductDTO
    {
        public int ID { get; set; }
        public string Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }

        public static Expression<Func<ItemProduct, ItemProductDTO>> ItemProductSelector
        {
            get
            {
                return itemProduct => new ItemProductDTO()
                {
                    ID = itemProduct.ID,
                    Category = itemProduct.Category,
                    Name = itemProduct.Name,
                    Price = itemProduct.Price
                };
            }
        }
    }
}
