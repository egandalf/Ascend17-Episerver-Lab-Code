using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brightfind.EktronToEpiserverLab.Models.Pages;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class CalendarViewModel : PageViewModel<CalendarPage>
    {
        public IEnumerable<EventViewModel> EventsList { get; set; }

        public CalendarViewModel(CalendarPage currentPage) : base(currentPage)
        {

        }
    }
}