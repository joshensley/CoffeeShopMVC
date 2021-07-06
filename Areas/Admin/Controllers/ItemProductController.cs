using CoffeeShopMVC.Areas.Admin.Models.ProductInformation;
using CoffeeShopMVC.Areas.Admin.Repositories.DTO;
using CoffeeShopMVC.Areas.Admin.Services;
using CoffeeShopMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoffeeShopMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ItemProductController : Controller
    {
        private readonly ItemProductServices _itemProductService;

        public ItemProductController(ItemProductServices itemProductServices)
        {
            _itemProductService = itemProductServices;
        }

        // GET: Admin/ItemProduct/Index
        public async Task<IActionResult> Index()
        {
            var itemProduct = (await _itemProductService.GetItemProductDTO()).Value;

            return View(itemProduct);
        }

        // GET: Admin/ItemProduct/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Category,Name,Price")] ItemProduct model)
        {
            if (ModelState.IsValid)
            {
                var isPosted = await _itemProductService.PostItemProduct(model);

                if (isPosted.Value) return RedirectToAction(nameof(Index));
            }

            return View(model);
        }

        // GET: Admin/ItemProduct/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var itemProduct = await _itemProductService.GetByIdItemProductDTO(id);

            if (itemProduct.Value == null) return NotFound();

            return View(itemProduct.Value);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Category,Name,Price")] ItemProduct model)
        {
            if (id != model.ID) return NotFound();

            if (ModelState.IsValid)
            {
                var isUpdated = await _itemProductService.EditItemProduct(id, model);

                if (isUpdated.Value) return RedirectToAction(nameof(Index));
            }

            var itemProductDTO = new ItemProductDTO()
            {
                ID = model.ID,
                Category = model.Category,
                Name = model.Name,
                Price = model.Price
            };

            return View(itemProductDTO);
        }

        // GET: Admin/ItemProduct/Delete
        public async Task<IActionResult> Delete(int id)
        {
            var itemProduct = await _itemProductService.GetByIdItemProductDTO(id);

            return View(itemProduct.Value);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id, [Bind("ID,Category,Name,Price")] ItemProduct model)
        {
            if (id != model.ID) return NotFound();

            var isDeleted = await _itemProductService.DeleteItemProduct(id, model);

            return RedirectToAction(nameof(Index));
        }
    }
}
