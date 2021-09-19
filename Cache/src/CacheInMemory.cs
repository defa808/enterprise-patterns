using System.Collections.Generic;

namespace cache {
    public class CacheInMemory<T> : ICache<T> {
        private Dictionary<int, T> cache { get; } = new Dictionary<int, T>();

        public T Get(int key) {
            return cache.GetValueOrDefault(key);
        }

        public void Put(int key, T value) {
            cache.Add(key, value);
        }

        public void Remove(int key) {
            cache.Remove(key);
        }

        public void Clear() {
            cache.Clear();
        }
    }
}