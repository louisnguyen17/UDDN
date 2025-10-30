using Microsoft.AspNetCore.Mvc;
using ProductManagement.Models;
using ProductManagement.Services.Interfaces;

namespace ProductManagement.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        public ProductsController(IProductService service) => _service = service;

        public async Task<IActionResult> Index() =>
            View(await _service.GetAllAsync());

        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Product p)
        {
            if (!ModelState.IsValid) return View(p);
            await _service.AddAsync(p);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var p = await _service.GetByIdAsync(id);
            return p == null ? NotFound() : View(p);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Product p)
        {
            if (!ModelState.IsValid) return View(p);
            await _service.UpdateAsync(p);
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var p = await _service.GetByIdAsync(id);
            return p == null ? NotFound() : View(p);
        }

        public async Task<IActionResult> Delete(int id)
        {
            var p = await _service.GetByIdAsync(id);
            return p == null ? NotFound() : View(p);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
