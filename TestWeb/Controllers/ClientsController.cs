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
        public async Task<IActionResult> Edit(Int64 id)
        {
            Client client = await _clientsService.getById(id);
            return View("Create", client);
        }
        [HttpPost]
        public async Task<JsonResult> Create(Client client)
        {
            var response = new JsonResponse<Client>();
            try
            {
                response.data = await _clientsService.createUpdate(0, client);
                response.msg = "Cliente creado correctamentente!";
                response.redirect = Url.Action("Index", "Clients");
            }
            catch (Exception ex)
            {
                response.msg = ex.Message;
                response.error = true;
            }

            return Json(response);
        }
        [HttpPut]
        public async Task<JsonResult> Update(Int64 id, Client client)
        {
            var response = new JsonResponse<Client>();
            try
            {
                response.data = await _clientsService.createUpdate(id, client);
                response.msg = "Cliente actualizado correctamentente!";
                response.redirect = Url.Action("Index", "Clients");
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
            var response = new JsonResponse<Client>();
            try
            {
                var result = await _clientsService.delete(id);
                if (result != -1)
                {
                    response.msg = "Cliente eliminado correctamentente!";
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
