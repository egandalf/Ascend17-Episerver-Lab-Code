using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Brightfind.EktronToEpiserverLab.Models.Properties;
using EPiServer.Cms.Shell.UI.ObjectEditing.EditorDescriptors;
using EPiServer.Core;
using EPiServer.DataAbstraction;
using EPiServer.DataAnnotations;
using EPiServer.Shell.ObjectEditing;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    [ContentType(DisplayName = "Event Page", GUID = "a77bbbf0-9c0e-41b2-a963-af6929954c4a", Description = "", GroupName = Global.GroupNames.Standard)]
    [AvailableContentTypes(
        Availability = Availability.Specific,
        IncludeOn = new[] { typeof(CalendarPage) })]
    public class EventPage : SpockPageBase
    {
        [Display(GroupName = SystemTabNames.Content, Order = 200)]
        public virtual string Location { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 300)]
        [EditorDescriptor(EditorDescriptorType = typeof(CollectionEditorDescriptor<PropertyEventDate>))]
        public virtual IList<PropertyEventDate> Dates { get; set; }

        [Display(GroupName = SystemTabNames.Content, Order = 400)]
        public virtual XhtmlString Description { get; set; }
    }
}