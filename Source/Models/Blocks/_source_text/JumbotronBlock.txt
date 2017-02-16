using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Brightfind.EktronToEpiserverLab.Models.Blocks
{
    [ContentType(DisplayName = "Jumbotron", GUID = "27868a21-c834-437d-9dcf-2879a03deb4b", Description = "", GroupName = Global.GroupNames.Specialized)]
    public class JumbotronBlock : SpockBlockBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        [CultureSpecific]
        public virtual string Heading { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 300)]
        [UIHint(UIHint.Textarea)]
        [CultureSpecific]
        public virtual string Subheading { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 400)]
        [CultureSpecific]
        public virtual string ButtonText { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 500)]
        public virtual Url ButtonLink { get; set; }
    }
}