using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer.Core;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc.Html;
using EPiServer.Web.Routing;
using EPiServer;

namespace Brightfind.EktronToEpiserverLab.Business.Helpers
{
    public static class HtmlHelpers
    {
        public static string BuildUrl(this HtmlHelper helper, string urlString, params KeyValuePair<string, object>[] queryParams)
        {
            if (string.IsNullOrWhiteSpace(urlString)) return string.Empty;

            var uriBuilder = new UriBuilder(GetAbsoluteUrl(urlString));
            var qs = HttpUtility.ParseQueryString(uriBuilder.Query);
            foreach (var item in queryParams)
            {
                if (qs[item.Key] != null)
                    qs.Set(item.Key, item.Value.ToString());
                else
                    qs.Add(item.Key, item.Value.ToString());
            }
            uriBuilder.Query = qs.ToString();
            return uriBuilder.ToString();
        }

        private static Uri GetAbsoluteUrl(string urlString)
        {
            Uri uri;
            if (Uri.TryCreate(urlString, UriKind.Absolute, out uri)) return uri;
            var baseUri = HttpContext.Current.Request.Url.GetLeftPart(UriPartial.Authority);
            return (Uri.TryCreate(new Uri(baseUri), urlString, out uri)) ? uri : null;
        }

        public static IHtmlString MenuList(this HtmlHelper helper, ContentReference rootLink, Func<MenuItemViewModel, HelperResult> itemTemplate = null, bool includeRoot = false, bool requireVisibleInMenu = true, bool requirePageTemplate = true)
        {
            itemTemplate = itemTemplate ?? GetDefaultItemTemplate(helper);
            var currentContentLink = helper.ViewContext.RequestContext.GetContentLink();
            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            Func<IEnumerable<PageData>, IEnumerable<PageData>> filter = pages => pages.FilterForDisplay(requirePageTemplate, requireVisibleInMenu);
            var pagePath = contentLoader.GetAncestors(currentContentLink)
                .Reverse()
                .Select(x => x.ContentLink)
                .SkipWhile(x => !x.CompareToIgnoreWorkID(rootLink))
                .ToList();

            var menuItems = contentLoader.GetChildren<PageData>(rootLink)
                .FilterForDisplay(requirePageTemplate, requireVisibleInMenu)
                .Select(x => CreateMenuItem(x, currentContentLink, pagePath, contentLoader, filter))
                .ToList();

            if (includeRoot)
            {
                menuItems.Insert(0, CreateMenuItem(contentLoader.Get<PageData>(rootLink), currentContentLink, pagePath, contentLoader, filter));
            }

            var buffer = new StringBuilder();
            using (var writer = new StringWriter(buffer))
            {
                foreach (var item in menuItems)
                {
                    itemTemplate(item).WriteTo(writer);
                }
            }
            return new MvcHtmlString(buffer.ToString());
        }

        private static MenuItemViewModel CreateMenuItem(PageData pageData, ContentReference currentContentLink, List<ContentReference> pagePath, IContentLoader contentLoader, Func<IEnumerable<PageData>, IEnumerable<PageData>> filter)
        {
            var menuItem = new MenuItemViewModel(pageData)
            {
                Selected = pageData.ContentLink.CompareToIgnoreWorkID(currentContentLink) || pagePath.Contains(pageData.ContentLink),
                HasChildren = new Lazy<bool>(() => filter(contentLoader.GetChildren<PageData>(pageData.ContentLink)).Any())
            };
            return menuItem;
        }

        private static Func<MenuItemViewModel, HelperResult> GetDefaultItemTemplate(HtmlHelper helper) => x => new HelperResult(writer => writer.Write(helper.PageLink(x.Page)));
    }
}