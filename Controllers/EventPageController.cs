using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class EventPageController : PageControllerBase<EventPage>
    {
        public ActionResult Index(EventPage currentPage)
        {
            var model = new EventViewModel(currentPage);

            return View(model);
        }
    }
}