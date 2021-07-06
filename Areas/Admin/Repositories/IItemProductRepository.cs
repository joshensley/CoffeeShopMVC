using CoffeeShopMVC.Areas.Admin.Models.ProductInformation;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Areas.Admin.Repositories
{
    public interface IItemProductRepository
    {
        Task<ActionResult<IEnumerable<TResult>>> Get<TResult>(Expression<Func<ItemProduct, TResult>> selector);

        Task<ActionResult<TResult>> GetById<TResult>(int id, Expression<Func<ItemProduct, TResult>> selector);

        Task<ActionResult<bool>> Post(ItemProduct model);

        Task<ActionResult<bool>> Edit(int id, ItemProduct model);

        Task<ActionResult<bool>> Delete(int id, ItemProduct model);
    }
}
