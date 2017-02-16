using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "Landing Page", GUID = "ff07239b-fe5c-4679-8bfa-4e1fd4797e95", Description = "", GroupName = Global.GroupNames.Standard)]
    public class LandingPage : SpockPageBase
    {
        [Display(Name = "Main Content Area", GroupName = SystemTabNames.Content)]
        [EPiBootstrapArea.DefaultDisplayOption(EPiBootstrapArea.ContentAreaTags.HalfWidth)]
        public virtual ContentArea MainContentArea { get; set; }
    }
}