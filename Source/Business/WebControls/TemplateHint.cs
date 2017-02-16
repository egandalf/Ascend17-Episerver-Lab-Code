using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace Brightfind.EktronToEpiserverLab.Business.WebControls
{
    [ToolboxData("<{0}:TemplateHint runat=server></{0}:TemplateHint>")]
    public class TemplateHint : HtmlGenericControl
    {
        public TemplateHint(string tag) : base(tag.ToLower().Contains("templatehint") || string.IsNullOrWhiteSpace(tag) ? "p" : tag)
        {
            Attributes.Add("class", "alert alert-info");
        }

        public TemplateHint() : this("p") { }
    }
}