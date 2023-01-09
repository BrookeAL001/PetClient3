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

        public IActionResult ViewClient(int id)
        {
            var client = repo.GetClient(id);

            return View(client);
        }

        public IActionResult UpdateClient(int id)
        {
            Client cli = repo.GetClient(id);

            if (cli == null)
            {
                return View("ClientNotFound");
            }

            return View(cli);
        }

        public IActionResult UpdateClientToDatabase(Client client)
        {
            repo.UpdateClient(client);

            return RedirectToAction("ViewClient", new { id = client.ID });
        }

        public IActionResult InsertClient()
        {
            

            return View();

        }

        public IActionResult InsertClientToDatabase(Client clientToInsert)
        {
            repo.InsertClient(clientToInsert);

            return RedirectToAction("Index");
        }

    }
}
