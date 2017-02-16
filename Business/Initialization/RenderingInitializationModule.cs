using System;
using System.Linq;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Business.Rendering;
using Brightfind.EktronToEpiserverLab.Controllers;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.Web;

namespace Brightfind.EktronToEpiserverLab.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class RenderingInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
            ViewEngines.Engines.Insert(0, new SiteViewEngine());

            context.Locate.TemplateResolver().TemplateResolved += RenderingInitializationModule_TemplateResolved;

        }

        private static void RenderingInitializationModule_TemplateResolved(object sender, TemplateResolverEventArgs e)
        {
            if(e.ItemToRender is IContainerPage && e.SelectedTemplate != null && e.SelectedTemplate.TemplateType == typeof(DefaultPageController))
            {
                e.SelectedTemplate = null;
            }
        }

        public void Uninitialize(InitializationEngine context)
        {
            context.Locate.TemplateResolver().TemplateResolved -= RenderingInitializationModule_TemplateResolved;
        }
    }
}