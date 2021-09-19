namespace cache {
    public interface ICache<T> {
        void Clear();
        T Get(int key);
        void Put(int key, T value);
        void Remove(int key);
    }
}