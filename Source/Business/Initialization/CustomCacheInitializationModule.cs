using System;
using System.Linq;
using Brightfind.EktronToEpiserverLab.Business.Caching;
using EPiServer.Framework;
using EPiServer.Framework.Cache;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace Brightfind.EktronToEpiserverLab.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class CustomCacheInitializationModule : IConfigurableModule
    {
        public void Initialize(InitializationEngine context)
        {
            //Add initialization logic, this method is called once after CMS has been initialized
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }

        public void ConfigureContainer(ServiceConfigurationContext context)
        {
            /*
             * Allows our custom cache class to be used in place of Episerver's. 
             * 
             * Since our cache implements and uses Episerver's own interface and default instance, 
             * it functions the same. But it also gives us a way to view what's going on with the cache
             * as well as apply custom logic in and around those functions when desired.
             */
            context.Services.Intercept<ISynchronizedObjectInstanceCache>((locator, defaultCache) => new CustomSynchronizedCache(defaultCache));
        }
    }
}