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

        public HomeController(ILogger<HomeController> logger,ISalesService salesService)
        {
            _logger = logger;
            _salesService = salesService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.sales = await _salesService.getAll();
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
