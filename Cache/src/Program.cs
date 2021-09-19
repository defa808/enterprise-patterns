using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace cache
{
    class Program
    {
        
        //Client part
        static void Main(string[] args)
        {
            IDatabase database = new Database();
            ICacheAccessor cacheAccessor = new CacheAccessor(database, new CacheInMemory<Client>());
            IClientService clientService = new ClientService(database, cacheAccessor);
            var client1 = clientService.GetById(1);
            Console.WriteLine($"Client 1.1: {client1.Id}");
            var client2 = clientService.GetById(1);
            var clientDb = database.Clients.Where(x => x.Id == 1).FirstOrDefault();
            
            Console.WriteLine($"Client 1.2: {client2.Id}");
            Console.WriteLine($@"Clients: {client1.GetHashCode()}
Second query {client2.GetHashCode()}
Database query {clientDb.GetHashCode()}");
            Console.WriteLine("Clearing Cache...");
            cacheAccessor.Clear();
            client1 = clientService.GetById(1);
            Console.WriteLine($@"Clients: {client1.GetHashCode()}
Second query {client2.GetHashCode()}
Database query {clientDb.GetHashCode()}");

            var client3 = clientService.GetById(2);
            var client4 = clientService.GetById(2);
            Console.WriteLine($"Client 2.1: {client3.Id}");

            Console.WriteLine($"Client 2.2: {client4.Id}");
            Console.WriteLine($"Clients: {client3.GetHashCode()} vs {client4.GetHashCode()}");

        }
    }
}
