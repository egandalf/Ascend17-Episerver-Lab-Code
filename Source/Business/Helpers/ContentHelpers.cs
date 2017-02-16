using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.Filters;
using EPiServer.ServiceLocation;

namespace Brightfind.EktronToEpiserverLab.Business.Helpers
{
    public static class ContentHelpers
    {
        public static IEnumerable<T> FilterForDisplay<T>(this IEnumerable<T> contents, bool requirePageTemplate = false, bool requireVisibleInMenu = false) where T : IContent
        {
            var accessFilter = new FilterAccess();
            var publishedFilter = new FilterPublished();
            contents = contents.Where(x => !publishedFilter.ShouldFilter(x) && !accessFilter.ShouldFilter(x));
            if(requirePageTemplate)
            {
                var templateFilter = ServiceLocator.Current.GetInstance<FilterTemplate>();
                templateFilter.TemplateTypeCategories = EPiServer.Framework.Web.TemplateTypeCategories.Page;
                contents = contents.Where(x => !templateFilter.ShouldFilter(x));
            }
            if (requireVisibleInMenu) contents = contents.Where(x => VisibleInMenu(x));
            return contents;
        }

        private static bool VisibleInMenu(IContent content)
        {
            var page = content as PageData;
            if (page == null) return false;
            return page.VisibleInMenu;
        }
    }
}