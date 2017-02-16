using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Data;
using EPiServer.Web;
using EPiServer.Web.Routing;

namespace Brightfind.EktronToEpiserverLab.Business.Factories
{
    public class PageViewContextFactory
    {
        private readonly IContentLoader _contentLoader;
        private readonly UrlResolver _urlResolver;
        private readonly IDatabaseMode _databaseMode;

        public PageViewContextFactory(IContentLoader contentLoader, UrlResolver urlResolver, IDatabaseMode databaseMode)
        {
            _contentLoader = contentLoader;
            _urlResolver = urlResolver;
            _databaseMode = databaseMode;
        }

        public virtual LayoutModel CreateLayoutModel(ContentReference currentContentLink, RequestContext requestContext)
        {
            var startPageContentLink = SiteDefinition.Current.StartPage;
            if (currentContentLink.CompareToIgnoreWorkID(startPageContentLink))
            {
                startPageContentLink = currentContentLink;
            }
            var startPage = _contentLoader.Get<StartPage>(startPageContentLink);
            return new LayoutModel
            {
                Logo = startPage.SiteLogo,
                IsLoggedIn = requestContext.HttpContext.User.Identity.IsAuthenticated,
                IsInReadOnlyMode = _databaseMode.DatabaseMode == DatabaseMode.ReadOnly,
                Copyright = startPage.Copyright
            };
        }

        public virtual IContent GetSection(ContentReference contentLink)
        {
            var currentContent = _contentLoader.Get<IContent>(contentLink);
            if(currentContent.ParentLink != null && currentContent.ParentLink.CompareToIgnoreWorkID(SiteDefinition.Current.StartPage))
            {
                return currentContent;
            }

            return _contentLoader.GetAncestors(contentLink)
                .OfType<PageData>()
                .SkipWhile(x => x.ParentLink == null || !x.ParentLink.CompareToIgnoreWorkID(SiteDefinition.Current.StartPage))
                .FirstOrDefault();
        }
    }
}