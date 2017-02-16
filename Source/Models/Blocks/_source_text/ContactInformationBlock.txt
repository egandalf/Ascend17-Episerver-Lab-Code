using System.ComponentModel.DataAnnotations;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;

namespace Brightfind.EktronToEpiserverLab.Models.Blocks
{
    [ContentType(DisplayName = "Contact Information Block", GUID = "8c163a81-1fb4-4d0b-88b0-c39654495513", Description = "", GroupName = Global.GroupNames.Standard)]
    public class ContactInformationBlock : SpockBlockBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 100)]
        public virtual string Name { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        public virtual string Email { get; set; }
        [Display(GroupName = SystemTabNames.Content, Order = 300)]
        public virtual string Phone { get; set; }
    }
}