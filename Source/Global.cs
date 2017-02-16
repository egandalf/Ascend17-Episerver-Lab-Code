using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brightfind.EktronToEpiserverLab
{
    public class Global
    {
        public class GroupNames
        {
            public const string Metadata = "SEO";
            public const string Specialized = "Specialized";
            public const string SiteSettings = "Site Settings";
            public const string Standard = "Standard";
        }

        public class SiteUiHints
        {
            public const string Strings = "StringList";
        }

        public class ViewPaths
        {
            public const string BlockFolder = "~/Views/Shared/Blocks/";
            public const string PagePartialsFolder = "~/Views/Shared/PagePartials/";
        }

        public class RenderingValues
        {
            public const string TitleSuffix = "// Episerver Lab";
        }
    }
}