using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "CalendarPage", GUID = "e4bbc462-a8fd-4bcc-b035-43a64c314fe8", Description = "", GroupName = Global.GroupNames.Standard)]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        Include = new[] { typeof(EventPage)})]
    public class CalendarPage : SpockPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        public virtual string Introduction { get; set; }
    }
}