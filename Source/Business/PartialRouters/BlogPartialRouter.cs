using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Routing;
using Brightfind.EktronToEpiserverLab.Business.Ektron;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.Routed;
using EPiServer.Core;
using EPiServer.Web.Routing;
using EPiServer.Web.Routing.Segments;

namespace Brightfind.EktronToEpiserverLab.Business.PartialRouters
{
    public class BlogPartialRouter : IPartialRouter<BlogPage, BlogArticle>
    {
        private Lazy<BlogManager> BlogManager => new Lazy<BlogManager>(() => new BlogManager());
        private ContentReference _blogPageReference;

        public BlogPartialRouter(ContentReference blogPageReference)
        {
            _blogPageReference = blogPageReference;
        }

        public object RoutePartial(BlogPage content, SegmentContext segmentContext)
        {
            var nextSegment = segmentContext.GetNextValue(segmentContext.RemainingPath);
            long blogId;
            var article = long.TryParse(nextSegment.Next, out blogId) ? BlogManager.Value.GetItem(blogId) : BlogManager.Value.GetItem(nextSegment.Next, true);
            segmentContext.RemainingPath = nextSegment.Remaining;
            return article;
        }

        public PartialRouteData GetPartialVirtualPath(BlogArticle content, string language, RouteValueDictionary routeValues,
            RequestContext requestContext)
        {
            if (ContentReference.IsNullOrEmpty(_blogPageReference)) throw new InvalidOperationException("BlogPageReference must be set to a valid content reference");

            return new PartialRouteData()
            {
                BasePathRoot = _blogPageReference,
                PartialVirtualPath = content.Id.ToString() //HttpUtility.UrlPathEncode($"{content.Name}")
            };
        }
    }

    public static class BlogPartialRouterHelper
    {
        public static string GetUrl(this BlogArticle content, ContentReference reference)
        {
            var router = new BlogPartialRouter(reference);
            var routeData = router.GetPartialVirtualPath(content, "en-us", null, null);
            return routeData.PartialVirtualPath;
        }
    }
}