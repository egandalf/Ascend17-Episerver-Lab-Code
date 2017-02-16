using System;
using System.Linq;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Business.Filters;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace Brightfind.EktronToEpiserverLab.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class FilterConfigInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            GlobalFilters.Filters.Add(ServiceLocator.Current.GetInstance<PageContextActionFilter>());
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}