using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "BlogPage", GUID = "15c30365-4bc6-41bd-a089-edc72847d749", Description = "", GroupName = Global.GroupNames.Standard)]
    public class BlogPage : SpockPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        public virtual XhtmlString Introduction { get; set; }
    }
}