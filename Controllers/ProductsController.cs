using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Products.Models;
using Products.Services;
using System;
using System.Threading.Tasks;

namespace Products.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(IProductService service, ILogger<ProductsController> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _service.List();
            return View(products);
        }

        public async Task<IActionResult> New()
        {
            return View();
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
                return NotFound();

            var product = await _service.Get(id.Value);

            if (product == null)
                return NotFound();

            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int id, [Bind("Id,Name,Price,Quantity,Provider")] Product product)
        {
            if (ModelState.IsValid)
            {
                if (await _service.Update(product))
                    RedirectToAction(nameof(Index));
                else
                    return View(product);
            }

            return View(product);
        }

        [HttpPost("Products/Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _service.Get(id);
            if (product == null)
                return NotFound();

            if (await _service.Remove(product))
                return Ok("Product removed successful!");

            return Ok();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> New(Product product)
        {
            if (ModelState.IsValid)
            {
                if (await _service.Add(product))
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    _logger.LogInformation("Error to add new product");
                    return View();
                }
            }
            return View();
        }
    }
}
