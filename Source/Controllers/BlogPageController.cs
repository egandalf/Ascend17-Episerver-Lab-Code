using System;
using System.Linq;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer;
using EPiServer.Web.Mvc;
using EPiServer.ServiceLocation;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class BlogPageController : PageController<BlogPage>
    {
        public ActionResult Index(BlogPage currentPage)
        {
            var pageSize = 5;

            var model = new BlogListViewModel(currentPage);

            var contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
            var blogPosts = contentLoader.GetChildren<BlogPostPage>(currentPage.ContentLink)
                .OrderByDescending(b => b.Created);

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
    }
}