using CoffeeShopMVC.Areas.Admin.Models.ProductInformation;
using CoffeeShopMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Areas.Admin.Repositories
{


    public class ItemProductRepository : IItemProductRepository
    {
        private readonly ApplicationDbContext _db;

        public ItemProductRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ActionResult<IEnumerable<TResult>>> Get<TResult>(Expression<Func<ItemProduct, TResult>> selector)
        {
            var itemProducts = await _db.ItemProducts
                .OrderBy(i => i.Name)
                .Select(selector)
                .ToListAsync();

            return itemProducts;
        }

        public async Task<ActionResult<TResult>> GetById<TResult>(int id, Expression<Func<ItemProduct, TResult>> selector)
        {
            var itemProduct = await _db.ItemProducts
                .Where(i => i.ID == id)
                .Select(selector)
                .FirstOrDefaultAsync();
                
            return itemProduct;
        }

        public async Task<ActionResult<bool>> Post(ItemProduct model)
        {
            _db.Add(model);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ActionResult<bool>> Edit(int id, ItemProduct model)
        {
            _db.Update(model);
            await _db.SaveChangesAsync();
            return true;
        }

        public async Task<ActionResult<bool>> Delete(int id, ItemProduct model)
        {
            _db.ItemProducts.Remove(model);
            await _db.SaveChangesAsync();
            return true;
        }
    }
}
