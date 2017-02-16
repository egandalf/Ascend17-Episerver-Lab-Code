using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EPiServer.Core;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class MenuItemViewModel
    {
        public PageData Page { get; set; }
        public bool Selected { get; set; }
        public Lazy<bool> HasChildren { get; set; }

        public MenuItemViewModel(PageData page)
        {
            Page = page;
        }
    }
}