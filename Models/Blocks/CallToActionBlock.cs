﻿using System.ComponentModel.DataAnnotations;
using EPiBootstrapArea;
using EPiServer;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Web;

namespace Brightfind.EktronToEpiserverLab.Models.Blocks
{
    [ContentType(DisplayName = "CallToActionBlock", GUID = "5093dddf-b882-498e-8bb8-1732348bbae0", Description = "", GroupName = Global.GroupNames.Specialized)]
    [DefaultDisplayOption(ContentAreaTags.OneQuarterWidth)]
    public class CallToActionBlock : SpockBlockBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        [UIHint(UIHint.Image)]
        public virtual ContentReference Image { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        public virtual string Proverb { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 300, Name = "Button Text")]
        public virtual string ButtonText { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 400, Name = "Button Link")]
        public virtual Url ButtonLink { get; set; }
    }
}