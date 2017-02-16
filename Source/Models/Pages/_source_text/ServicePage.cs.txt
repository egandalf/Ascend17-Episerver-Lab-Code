using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "Service Page", GUID = "a09690a1-71cd-488b-956b-9a2db48cc34b", Description = "", GroupName = Global.GroupNames.Standard)]
    public class ServicePage : SpockPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        public virtual int Price { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        public virtual XhtmlString Description { get; set; }
    }
}