using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace cache {
    public class Database : IDatabase {

        public ICollection<Client> Clients { get {

                var json = File.ReadAllText("database.json");
                return JsonSerializer.Deserialize<List<Client>>(json); } }

        public Database() {
            //initialize data
            var data = JsonSerializer.Serialize(new List<Client>() { new Client() { Id = 1 }, new Client() { Id = 2 }, new Client() { Id = 3 } });
            File.WriteAllText("database.json", data);
        }
    }

    public class Client {
        public int Id { get; set; }
    }
}
