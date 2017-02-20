using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.Routed;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer;
using EPiServer.Web.Mvc;
using EPiServer.Web.Mvc.Html;
using EPiServer.ServiceLocation;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class BlogPageController : PageController<BlogPage>
    {
        private Business.Ektron.BlogManager _blogManager = new Business.Ektron.BlogManager();

        public ActionResult Index(BlogPage currentPage)
        {
            var pageSize = 5;

            var model = new BlogListViewModel(currentPage);

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

            // Get Episerver blog posts
            var blogPosts = contentLoader.GetChildren<BlogPostPage>(currentPage.ContentLink)
                .Select(b => new BlogArticle
                {
                    Name = b.Name,
                    Teaser = b.TeaserText,
                    Url = this.Url.ContentUrl(b.ContentLink),
                    Published = b.Created
                }).ToList();

            // Get Ektron blog posts (cached)
            blogPosts.AddRange(_blogManager.GetList());

            // Select distinct using custom comparer & order by pub date desc
            blogPosts = blogPosts.Distinct(new BlogComparer()).OrderByDescending(b => b.Published).ToList();

            model.TotalArticles = blogPosts.Count();
            model.TotalPages = Math.Ceiling(model.TotalArticles / (double)pageSize);

            var q = Request.QueryString;
            int p;
            if (string.IsNullOrEmpty(q["p"]) || !int.TryParse(q["p"], out p) || p <= 1)
            {
                model.CurrentPageNumber = 1;
                model.Articles = blogPosts.Take(pageSize);
            }
            else
            {
                model.CurrentPageNumber = p;
                model.Articles = blogPosts.Skip((p - 1) * pageSize).Take(pageSize);
            }

            return View(model);
        }

        public class BlogComparer : IEqualityComparer<BlogArticle>
        {
            public bool Equals(BlogArticle x, BlogArticle y)
            {
                return x.Name == y.Name;
            }

            public int GetHashCode(BlogArticle obj) => base.GetHashCode();
        }
    }
}