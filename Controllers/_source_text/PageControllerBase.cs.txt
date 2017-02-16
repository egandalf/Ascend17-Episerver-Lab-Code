using Brightfind.EktronToEpiserverLab.Business.Interfaces;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer.Web.Mvc;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class PageControllerBase<T> : PageController<T>, IModifyLayout where T : SpockPageBase
    {
        public virtual void ModifyLayout(LayoutModel layoutModel)
        {
            var page = PageContext.Page as SpockPageBase;
            if (page == null) return;
            layoutModel.HideFooter = page.HideFooter;
            layoutModel.HideHeader = page.HideHeader;
        }
    }
}