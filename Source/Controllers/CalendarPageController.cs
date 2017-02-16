using System;
using System.Linq;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer;
using EPiServer.ServiceLocation;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class CalendarPageController : PageControllerBase<CalendarPage>
    {
        private readonly IContentLoader _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();

        public ActionResult Index(CalendarPage currentPage)
        {
            var model = new CalendarViewModel(currentPage);

            var month = DateTime.Now.Month;
            var year = DateTime.Now.Year;
            
            var events = _contentLoader.GetChildren<EventPage>(currentPage.ContentLink)
                .Select(d => new EventViewModel(d))
                .Where(vm => vm.Occurrences.Any(d => d.Month == month && d.Year == year));
            model.EventsList = events;
            
            return View(model);
        }
    }
}