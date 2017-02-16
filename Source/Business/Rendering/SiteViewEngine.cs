using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Brightfind.EktronToEpiserverLab.Business.Rendering
{
    public class SiteViewEngine : RazorViewEngine
    {
        private static readonly string[] AdditionalPartialViewFormats = new[]
        {
            Global.ViewPaths.BlockFolder + "{0}.cshtml",
            Global.ViewPaths.PagePartialsFolder + "{0}.cshtml"
        };

        public SiteViewEngine()
        {
            PartialViewLocationFormats = PartialViewLocationFormats.Union(AdditionalPartialViewFormats).ToArray();
        }
    }
}