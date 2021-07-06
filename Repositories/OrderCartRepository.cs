using CoffeeShopMVC.Data;
using CoffeeShopMVC.Models.Purchase;
using CoffeeShopMVC.Repositories.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Repositories
{
    public class OrderCartRepository : IOrderCartRepository
    {
        private readonly ApplicationDbContext _db;

        public OrderCartRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult<IEnumerable<TResult>>> Get<TResult>(string orderCartGroup, Expression<Func<OrderCart, TResult>> selector)
        {
            var orderCart = await _db.OrderCart
                .Where(o => o.OrderCartGroup == orderCartGroup)
                .OrderBy(o => o.ItemProduct.Name)
                .Select(selector)
                .ToListAsync();

            return orderCart;
        }

        public async Task<ActionResult<TResult>> GetById<TResult>(int id, Expression<Func<OrderCart, TResult>> selector)
        {
            var orderCartItem = await _db.OrderCart
                .Where(o => o.ID == id)
                .Select(selector)
                .FirstOrDefaultAsync();

            return orderCartItem;
        }

        public async Task<ActionResult<OrderCart>> Post(OrderCart model)
        {
            _db.Add(model);
            await _db.SaveChangesAsync();
            return model;
        }

        public async Task<ActionResult<int>> Delete(int id)
        {
            var orderCart = await _db.OrderCart.FindAsync(id);

            _db.OrderCart.Remove(orderCart);
            await _db.SaveChangesAsync();
            return orderCart.ID;

        }
    }
}
