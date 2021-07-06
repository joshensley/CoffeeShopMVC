using CoffeeShopMVC.Areas.Admin.Models.ProductInformation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Models.Purchase
{
    public class OrderCart
    {
        public int ID { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string OrderCartGroup { get; set; }

        [Required]
        public int ItemProductID { get; set; }

        public ItemProduct ItemProduct { get; set; }

        public string ApplicationUserID { get; set; }


    }
}
