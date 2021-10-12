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
    public class ClientsController : Controller
    {
        private readonly ILogger<ClientsController> _logger;
        private IClientsService _clientsService;

        public ClientsController(ILogger<ClientsController> logger, IClientsService clientsService)
        {
            _logger = logger;
            _clientsService = clientsService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.clients = await _clientsService.getAll();
            return View();
        }
        
        public IActionResult Create()
        {
            return View(new Client());
        }
        [HttpPost]
        public async Task<JsonResult> NewClient(Client client)
        {
            return Json(new { Success = ModelState.IsValid, Errors = false, LogOff = false });
        }
    }
}
