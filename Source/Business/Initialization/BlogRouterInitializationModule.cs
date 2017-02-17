using System;
using System.Linq;
using System.Web.Routing;
using Brightfind.EktronToEpiserverLab.Business.PartialRouters;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.Routed;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;
using EPiServer.Web.Routing;

namespace Brightfind.EktronToEpiserverLab.Business.Initialization
{
    [InitializableModule]
    [ModuleDependency(typeof(EPiServer.Web.InitializationModule))]
    public class BlogRouterInitializationModule : IInitializableModule
    {
        private Injected<IContentLoader> _contentLoader;
        private Injected<IContentRepository> _contentRepo;

        public void Initialize(InitializationEngine context)
        {
            // Get or create Blog Page
            var blogPage = _contentLoader.Service.GetChildren<BlogPage>(ContentReference.StartPage).FirstOrDefault();
            if (blogPage == null)
            {
                blogPage = _contentRepo.Service.GetDefault<BlogPage>(ContentReference.StartPage);
                blogPage.Name = "Blog";
                _contentRepo.Service.Save(blogPage, EPiServer.DataAccess.SaveAction.Publish, EPiServer.Security.AccessLevel.NoAccess);
            }

            // Register partial router
            var partialRouter = new BlogPartialRouter(blogPage.ContentLink.ToReferenceWithoutVersion());
            RouteTable.Routes.RegisterPartialRouter<BlogPage, BlogArticle>(partialRouter);
        }

        public void Uninitialize(InitializationEngine context)
        {
            //Add uninitialization logic
        }
    }
}