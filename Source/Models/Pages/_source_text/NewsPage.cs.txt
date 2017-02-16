using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "NewsPage", GUID = "26592a6c-a3f9-415d-9702-39ecd9d33806", Description = "", GroupName = Global.GroupNames.Standard)]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        IncludeOn = new[] { typeof(NewsListPage) })]
    public class NewsPage : SpockPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        public virtual string Headline { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        public virtual string Subhead { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 300)]
        public virtual string Byline { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 400)]
        public virtual XhtmlString ArticleBody { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 500)]
        public virtual ContentArea Contact { get; set; }
    }
}