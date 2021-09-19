using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cache {
    public class CacheAccessor : ICacheAccessor {
        private readonly ICache<Client> CacheClient;
        private readonly IDatabase Database;

        public CacheAccessor(IDatabase database, ICache<Client> cacheClient) {
            CacheClient = cacheClient;
            Database = database;
        }

        public Client GetClient(int key) {
            Client item = CacheClient.Get(key);
            if (item == null) {
                item = Database.Clients.Where(x => x.Id == key).FirstOrDefault();

                if (item != null)
                    CacheClient.Put(key, item);
            }
            return item;
        }

        // I am not sure that Cache Accessor should remove entity in database. It's not the cache's responsibility.
        public void RemoveClient(int key) {
            CacheClient.Remove(key);
        }


        public void Clear() {
            CacheClient.Clear();
        }
    }
}
