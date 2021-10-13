using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;
using TestWeb.Services.Interfaces;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ISalesService _salesService;
        private IProductsService _productsService;
        private IClientsService _clientsService;

        public HomeController(ILogger<HomeController> logger,ISalesService salesService,IClientsService clientsService,IProductsService productsService)
        {
            _logger = logger;
            _salesService = salesService;
            _productsService = productsService;
            _clientsService = clientsService;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.clients = await _clientsService.getAll();
            ViewBag.products = await _productsService.getAll();
            ViewBag.sales = await _salesService.getAll();
            return View(new Sales());
        }

        [HttpPost]
        public async Task<JsonResult> Create(Sales sale)
        {
            var response = new JsonResponse<Sales>();
            try
            {
                sale.product = await _productsService.getById(sale.product.id);
                sale.client = await _clientsService.getById(sale.client.id);
                sale.totalAmount = sale.quantity * sale.product.unitValue;
                response.data = await _salesService.createUpdate(0, sale);
                response.msg = "Venta realizada correctamentente!";
                response.redirect = Url.Action("Index", "Home");
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
                response.error = true;
            }

            return Json(response);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
