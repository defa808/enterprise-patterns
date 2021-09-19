namespace cache {
    public interface ICacheAccessor {
        void Clear();
        Client GetClient(int key);
        void RemoveClient(int key);
    }
}