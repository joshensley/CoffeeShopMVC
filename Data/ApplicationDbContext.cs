using CoffeeShopMVC.Areas.Admin.Models.ProductInformation;
using CoffeeShopMVC.Models.Purchase;
using CoffeeShopMVC.Models.User;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeShopMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        // Admin Models
        public DbSet<ItemProduct> ItemProducts { get; set; }

        // Purchase
        public DbSet<OrderCart> OrderCart { get; set; }
    }
}
