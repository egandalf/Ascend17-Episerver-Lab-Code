using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.PlugIn;

namespace Brightfind.EktronToEpiserverLab.Models.Properties
{
    [EditorHint(Global.SiteUiHints.Strings)]
    [PropertyDefinitionTypePlugIn(Description = "A property for a list of strings", DisplayName = "String List")]
    public class PropertyStringList : PropertyLongString
    {
        protected string Separator = "\n";

        public string[] List => (string[])Value;

        public override Type PropertyValueType => typeof(string[]);

        public override object SaveData(PropertyDataCollection properties) => LongString;

        public override object Value
        {
            get
            {
                var value = base.Value as string;
                return value?.Split(Separator.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            }
            set
            {
                var v = value as string[];
                if (v != null)
                {
                    var s = string.Join(Separator, v);
                    base.Value = s;
                }
                else
                {
                    base.Value = value;
                }
            }
        }

        public override IPropertyControl CreatePropertyControl() => null;
    }
}