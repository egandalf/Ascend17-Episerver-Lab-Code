using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Shell.ObjectEditing;
using EPiServer.Shell.ObjectEditing.EditorDescriptors;

namespace Brightfind.EktronToEpiserverLab.Business.EditorDescriptors
{
    [EditorDescriptorRegistration(TargetType = typeof(string[]), UIHint = Global.SiteUiHints.Strings)]
    public class StringListEditorDescriptor : EditorDescriptor
    {
        public override void ModifyMetadata(ExtendedMetadata metadata, IEnumerable<Attribute> attributes)
        {
            ClientEditingClass = "/clientresources/scripts/editors/StringList.js";
            base.ModifyMetadata(metadata, attributes);
        }
    }
}