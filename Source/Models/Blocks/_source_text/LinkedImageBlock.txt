using System.ComponentModel.DataAnnotations;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Blocks
{
    [ContentType(DisplayName = "Linked Image", GUID = "05e02d59-4802-487c-94b3-68009b822413", Description = "", GroupName = Global.GroupNames.Standard)]
    public class LinkedImageBlock : SpockBlockBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 1300)]
        public virtual ContentReference Image { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 1100)]
        [CultureSpecific]
        public virtual string Title { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 1200)]
        public virtual Url Link { get; set; }
    }
}