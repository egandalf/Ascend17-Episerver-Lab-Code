using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brightfind.EktronToEpiserverLab.Models.Pages
{
    public interface IPageBase
    {
        string Name { get; set; }
        string MetaTitle { get; set; }
        string MetaDescription { get; set; }
        string[] MetaKeywords { get; set; }
    }
}