using System.Collections.Generic;

namespace cache {
    public interface IDatabase {
        ICollection<Client> Clients { get; }
    }
}