using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class StartPageController : PageControllerBase<StartPage>
    {
        public ActionResult Index(StartPage currentPage)
        {
            var model = PageViewModel.Create(currentPage);
            if(SiteDefinition.Current.StartPage.CompareToIgnoreWorkID(currentPage.ContentLink))
            {
                var editHints = ViewData.GetEditHints<PageViewModel<StartPage>, StartPage>();
                editHints.AddConnection(m => m.Layout.Logo, p => p.SiteLogo);
                editHints.AddConnection(m => m.Layout.Copyright, p => p.Copyright);
            }
            return View(model);
        }
    }
}