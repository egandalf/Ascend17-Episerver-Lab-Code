using System.ComponentModel.DataAnnotations;
using Brightfind.EktronToEpiserverLab.Models.Properties;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    public abstract class SpockPageBase : PageData
    {
        [Display(Name = "Title", GroupName = Global.GroupNames.Metadata, Order = 100)]
        [CultureSpecific]
        public virtual string MetaTitle { get; set; }

        [Display(Name = "Description", GroupName = Global.GroupNames.Metadata, Order = 200)]
        [UIHint(UIHint.LongString)]
        [CultureSpecific]
        public virtual string MetaDescription { get; set; }

        [Display(Name = "Keywords", GroupName = Global.GroupNames.Metadata, Order = 300)]
        [BackingType(typeof(PropertyStringList))]
        [CultureSpecific]
        public virtual string[] MetaKeywords { get; set; }

        [Display(Name = "Page Image", GroupName = SystemTabNames.Content, Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference PageImage { get; set; }

        [Display(Name = "Teaser", GroupName = SystemTabNames.Content, Order = 200)]
        [UIHint(UIHint.Textarea)]
        [CultureSpecific]
        public virtual string TeaserText { get; set; }

        [Display(Name = "Hide Site Header", GroupName = SystemTabNames.Settings, Order = 200)]
        public virtual bool HideHeader { get; set; }

        [Display(Name = "Hide Site Footer", GroupName = SystemTabNames.Settings, Order = 300)]
        public virtual bool HideFooter { get; set; }
    }
}