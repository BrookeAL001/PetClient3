using System;
using System.Collections.Generic;

namespace PetClient3.Models
{
    public interface IClientRepository
    {
        public IEnumerable<Client> GetAllClients();
        public Client GetClient(int id);
        public void UpdateClient(Client client);
        public void InsertClient(Client clientToInsert);

    }
}