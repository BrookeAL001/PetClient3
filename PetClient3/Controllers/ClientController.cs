using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PetClient3.Models;

namespace Testing.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository repo;

        public ClientController(IClientRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            var clients = repo.GetAllClients();

            return View(clients);
        }

        public IActionResult ViewClient(int clientId)
        {
            var client = repo.GetClient(clientId);

            return View(client);
        }

        public IActionResult UpdateClient(Client client)
        {
            Client cli = repo.GetClient(client.ClientId);

            repo.UpdateClient(cli);

            if (cli == null)
            {
                return View("ClientNotFound");
            }

            return View(cli);
        }

        public IActionResult UpdateClientToDatabase(Client client)
        {
            repo.UpdateClient(client);

            return RedirectToAction("ViewClient", new { clientId = client.ClientId });
        }

        public IActionResult InsertClient(Client clientToInsert)
        {
            Client cli = repo.InsertClient(client.ClientId);
            
            repo.InsertClient(cli);

            return View();

        }

        public IActionResult InsertClientToDatabase(Client clientToInsert)
        {
            repo.InsertClient(clientToInsert);

            return RedirectToAction("Index");
        }

    }
}
