using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "Blog Post", GUID = "ee09dcdd-30a0-47ef-9200-8c1c9bc03648", Description = "", GroupName = Global.GroupNames.Standard)]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        IncludeOn = new [] { typeof(BlogPage) })]
    public class BlogPostPage : SpockPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        public virtual XhtmlString Article { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        public virtual ContentArea RailContentArea { get; set; }
    }
}