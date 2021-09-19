namespace cache {
    public interface IClientService {
        Client GetById(int id);
        void RemoveClient(int id);
    }
}