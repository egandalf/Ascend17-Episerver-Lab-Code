using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Framework.Cache;

namespace Brightfind.EktronToEpiserverLab.Business.Caching
{
    public class CustomSynchronizedCache : ISynchronizedObjectInstanceCache
    {
        private readonly ISynchronizedObjectInstanceCache _defaultCache;
        public CustomSynchronizedCache(ISynchronizedObjectInstanceCache defaultCache)
        {
            // Allows us to use Episerver's default instance of ISynchronizedObjectInstanceCache. We could omit this to totally roll our own.
            _defaultCache = defaultCache;
        }


        /*
         * Each of the following simply returns the result of the default Episerver cache methods. 
         * But illustrates how much can be overridden if, for example, you wanted to use a distributed cache provider.
         */
        public void Insert(string key, object value, CacheEvictionPolicy evictionPolicy) => _defaultCache.Insert(key, value, evictionPolicy);

        public object Get(string key) => _defaultCache.Get(key);

        public void Remove(string key) => _defaultCache.Remove(key);

        public void Clear() => _defaultCache.Clear();

        public void RemoveLocal(string key) => _defaultCache.RemoveLocal(key);

        public void RemoveRemote(string key) => _defaultCache.RemoveRemote(key);

        public FailureRecoveryAction SynchronizationFailedStrategy
        {
            get { return _defaultCache.SynchronizationFailedStrategy; }
            set { _defaultCache.SynchronizationFailedStrategy = value; }
        }
        public IObjectInstanceCache ObjectInstanceCache => _defaultCache.ObjectInstanceCache;
    }
}