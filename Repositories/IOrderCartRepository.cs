using CoffeeShopMVC.Data;
using CoffeeShopMVC.Models.Purchase;
using CoffeeShopMVC.Repositories.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Repositories
{
    public interface IOrderCartRepository
    {
        Task<ActionResult<IEnumerable<TResult>>> Get<TResult>(string orderCartGroup, Expression<Func<OrderCart, TResult>> selector);

        Task<ActionResult<TResult>> GetById<TResult>(int id, Expression<Func<OrderCart, TResult>> selector);

        Task<ActionResult<OrderCart>> Post(OrderCart model);

        Task<ActionResult<OrderCart>> Delete(int id);
    }
}
