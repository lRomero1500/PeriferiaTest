using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;
using TestWeb.Services.Interfaces;

namespace TestWeb.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private IProductsService _productsService;
        public ProductsController(ILogger<ProductsController> logger, IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.products = await _productsService.getAll();
            return View();
        }
        public IActionResult Create()
        {
            return View(new Product());
        }
        public async Task<IActionResult> Edit(Int64 id)
        {
            Product product = await _productsService.getById(id);
            return View("Create", product);
        }
        [HttpPost]
        public async Task<JsonResult> Create(Product client)
        {
            var response = new JsonResponse<Product>();
            try
            {
                response.data = await _productsService.createUpdate(0, client);
                response.msg = "Producto creado correctamentente!";
                response.redirect = Url.Action("Index", "Products");
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
                response.error = true;
            }

            return Json(response);
        }
        [HttpPut]
        public async Task<JsonResult> Update(Int64 id, Product client)
        {
            var response = new JsonResponse<Product>();
            try
            {
                response.data = await _productsService.createUpdate(id, client);
                response.msg = "Producto actualizado correctamentente!";
                response.redirect = Url.Action("Index", "Products");
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
                response.error = true;
            }

            return Json(response);
        }
        [HttpDelete]
        public async Task<JsonResult> Delete(Int64 id)
        {
            var response = new JsonResponse<Product>();
            try
            {
                var result = await _productsService.delete(id);
                if (result != -1)
                {
                    response.msg = "Producto eliminado correctamentente!";
                }
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
                response.error = true;
            }

            return Json(response);
        }
    }
}
