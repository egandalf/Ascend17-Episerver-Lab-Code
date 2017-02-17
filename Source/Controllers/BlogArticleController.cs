using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Models.Routed;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer.Web;
using EPiServer.Web.Routing;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class BlogArticleController : Controller, IRenderTemplate<BlogArticle>
    {
        // GET: BlogArticle
        public ActionResult Index()
        {
            var blogContent = Request.RequestContext.GetRoutedData<BlogArticle>();
            var model = PageViewModel.Create(blogContent);

            model.Layout = new LayoutModel
            {
                
            };

            return View(model);
        }
    }
}