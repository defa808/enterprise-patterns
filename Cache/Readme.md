# Cache
Cache patterns define strategies for integrating caching into your applications and middleware components

## Patterns

### These patterns address how to utilize caches rather than how to implement caches directly:
### Cache Accessor
Decouples caching logic from the data model and the data access details

### Demand Cache
Populates a cache on-demand as applications request data. This is useful for data that is read frequently but unpredictably.

### Primed Cache
Populates a cache with a predicted set of data. This is useful for data that is read frequently and  predictably.

### Cache Search Sequence
Inserts short cuts into a cache to optimize the number of operations that future searches require.

### These patterns describe strategies for efficient caching implementations
### Cache Collector
The equivalent of a .NET Garbage Collector - purges unneeded entries.

### Cache Replicator
Replicates operations across multiple caches.

### Cache Statistics
Record/Publish cache and pool statistics.

----
Data was taken from this site: <br/>
http://www.diranieh.com/DataAccessPatterns/Introduction.htm#Cache%20Patterns

----

### Done
#### Cache Accessor
It was implemented in interface and the corresponding class:
```
public interface ICacheAccessor {
        void Clear();
        Client GetClient(int key);
        void RemoveClient(int key);
    }
```

#### Needs to be done
- [Demand Cache](http://www.diranieh.com/DataAccessPatterns/DemandCache.htm)
- [Primed Cache](http://www.diranieh.com/DataAccessPatterns/PrimedCache.htm)
- [Cache Search Sequence](http://www.diranieh.com/DataAccessPatterns/CacheSearchSequence.htm)
- [Cache Collector](http://www.diranieh.com/DataAccessPatterns/CacheCollector.htm)
- [Cache Replicator](http://www.diranieh.com/DataAccessPatterns/CacheReplicator.htm)
- [Cache Statistics](http://www.diranieh.com/DataAccessPatterns/CacheStatistics.htm)


