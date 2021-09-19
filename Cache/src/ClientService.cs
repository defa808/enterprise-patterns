using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cache {

    public class ClientService : IClientService {
        private readonly ICacheAccessor CacheAccessor;
        private readonly IDatabase Database;

        public ClientService(IDatabase database, ICacheAccessor cacheAccessor) {
            CacheAccessor = cacheAccessor;
            Database = database;
        }

        public Client GetById(int id) {
            return CacheAccessor.GetClient(id);
        }

        public void RemoveClient(int id) {
            Client client = Database.Clients.Where(x => x.Id == id).FirstOrDefault();
            Database.Clients.Remove(client);
            CacheAccessor.RemoveClient(id);
        }
    }
}
