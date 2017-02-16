using System;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Web.Mvc;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    [TemplateDescriptor(Inherited = true)]
    public class DefaultPageController : PageController<SpockPageBase>
    {
        public ActionResult Index(SpockPageBase currentPage)
        {
            var model = CreateModel(currentPage);
            return View($"~/Views/{currentPage.GetOriginalType().Name}/index.cshtml", model);
        }

        private static IPageViewModel<SpockPageBase> CreateModel(SpockPageBase currentPage)
        {
            var type = typeof(PageViewModel<>).MakeGenericType(currentPage.GetOriginalType());
            return Activator.CreateInstance(type, currentPage) as IPageViewModel<SpockPageBase>;
        }
    }
}