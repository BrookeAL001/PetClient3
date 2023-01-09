using Dapper;
using System.Data;

namespace PetClient3.Models
{
    public class ClientRepository : IClientRepository
    {
        private readonly IDbConnection _conn;

        public ClientRepository(IDbConnection conn)
        {
            _conn = conn;
        }

        public IEnumerable<Client> GetAllClients()
        {
            return _conn.Query<Client>("SELECT * FROM PETCLIENT.CLIENTS;");
        }

        public Client GetClient(int id)
        {
            return _conn.QuerySingle<Client>("SELECT * FROM PETCLIENT.CLIENTS WHERE ID = @id",
                new { id = id });
        }

        public void UpdateClient(Client client)
        {
            _conn.Execute("UPDATE petclient.clients SET FullName = @fullname, Phone = @phone, Email = @email WHERE Id = @id",
                new {fullname = client.FullName, phone = client.Phone, email = client.Email, id = client.ID});
        }

        public void InsertClient(Client clientToInsert)
        {
            _conn.Execute("INSERT INTO petclient.clients (FULLNAME, PHONE, EMAIL) VALUES (@fullname, @phone, @email);",
                new { fullname = clientToInsert.FullName, phone = clientToInsert.Phone, email = clientToInsert.Email });
        }





    }



}