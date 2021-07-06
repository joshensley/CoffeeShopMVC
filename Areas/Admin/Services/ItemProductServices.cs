using CoffeeShopMVC.Areas.Admin.Models.ProductInformation;
using CoffeeShopMVC.Areas.Admin.Repositories;
using CoffeeShopMVC.Areas.Admin.Repositories.DTO;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Areas.Admin.Services
{
    public class ItemProductServices
    {
        public readonly IItemProductRepository _itemProductRepository;

        public ItemProductServices(IItemProductRepository itemProductRepository)
        {
            _itemProductRepository = itemProductRepository;
        }

        // GET: Get all item products
        public async Task<ActionResult<IEnumerable<ItemProductDTO>>> GetItemProductDTO()
        {
            return await _itemProductRepository.Get(ItemProductDTO.ItemProductSelector);
        }

        // GET: Get item product by id
        public async Task<ActionResult<ItemProductDTO>> GetByIdItemProductDTO(int id)
        {
            return await _itemProductRepository.GetById(id, ItemProductDTO.ItemProductSelector);
        }

        // POST: Post new item product
        public async Task<ActionResult<bool>> PostItemProduct(ItemProduct model)
        {
            return await _itemProductRepository.Post(model);
        }

        // EDIT: Edit item product
        public async Task<ActionResult<bool>> EditItemProduct(int id, ItemProduct model)
        {
            return await _itemProductRepository.Edit(id, model);
        }

        // DELETE: Delete item product
        public async Task<ActionResult<bool>> DeleteItemProduct(int id, ItemProduct model)
        {
            return await _itemProductRepository.Delete(id, model);
        }
    }
}
