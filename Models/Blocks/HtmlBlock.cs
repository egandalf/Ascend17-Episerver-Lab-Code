using System.ComponentModel.DataAnnotations;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Blocks
{
    [ContentType(DisplayName = "HtmlBlock", GUID = "e139048d-3597-4df7-a461-ee9ff91c833f", Description = "An open block of HTML.", GroupName = Global.GroupNames.Standard)]
    public class HtmlBlock : SpockBlockBase
    {
                [CultureSpecific]
                [Display(
                    Name = "HTML",
                    GroupName = SystemTabNames.Content,
                    Order = 100)]
                public virtual XhtmlString Html { get; set; }
    }
}