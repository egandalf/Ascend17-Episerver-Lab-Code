using System.ComponentModel.DataAnnotations;
using Brightfind.EktronToEpiserverLab.Models.Blocks;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "Start Page", GUID = "b6d824ce-e467-4561-b8d9-93e2bc2e128b", Description = "", GroupName = Global.GroupNames.Specialized)]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        Include = new[] { typeof(BlogPage), typeof(CalendarPage), typeof(NewsListPage), typeof(ServicePage), typeof(LandingPage)})]
    public class StartPage : SpockPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 300)]
        [CultureSpecific]
        public virtual ContentArea MainContentArea { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings, Name = "Linked Logo")]
        public virtual LinkedImageBlock SiteLogo { get; set; }

        [Display(GroupName = Global.GroupNames.SiteSettings, Name = "Copyright")]
        [CultureSpecific]
        public virtual string Copyright { get; set; }
    }
}