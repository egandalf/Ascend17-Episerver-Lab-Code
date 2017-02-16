using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using EPiServer.Core;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class PreviewModel : PageViewModel<SpockPageBase>
    {
        public IContent PreviewContent { get; set; }
        public List<PreviewArea> Areas { get; set; }
        public PreviewModel(SpockPageBase currentPage, IContent previewContent) : base(currentPage)
        {
            PreviewContent = previewContent;
            Areas = new List<PreviewArea>();
        }

        public class PreviewArea
        {
            public bool Supported { get; set; }
            public string AreaName { get; set; }
            public string AreaTag { get; set; }
            public ContentArea ContentArea { get; set; }
        }
    }
}