using System.Linq;
using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Business.Interfaces;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer;
using EPiServer.Core;
using EPiServer.Framework.DataAnnotations;
using EPiServer.Framework.Web;
using EPiServer.ServiceLocation;
using EPiServer.Web;
using EPiServer.Web.Mvc;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    [TemplateDescriptor(
        Inherited = true,
        TemplateTypeCategory = EPiServer.Framework.Web.TemplateTypeCategories.MvcController,
        Tags = new [] { RenderingTags.Preview, RenderingTags.Edit },
        AvailableWithoutTag = false)]
    [VisitorGroupImpersonation]
    public class PreviewController : ActionControllerBase, IRenderTemplate<BlockData>, IModifyLayout
    {
        private readonly IContentLoader _contentLoader = ServiceLocator.Current.GetInstance<IContentLoader>();
        private readonly TemplateResolver _templateResolver = ServiceLocator.Current.GetInstance<TemplateResolver>();
        private readonly DisplayOptions _displayOptions = ServiceLocator.Current.GetInstance<DisplayOptions>();

        public ActionResult Index(IContent currentContent)
        {
            var startPage = _contentLoader.Get<StartPage>(SiteDefinition.Current.StartPage);
            var model = new PreviewModel(startPage, currentContent);
            var supportedDisplayOptions = _displayOptions
                .Select(x => new { Tag = x.Tag, Name = x.Name, Supported = SupportsTag(currentContent, x.Tag) });

            if (supportedDisplayOptions.Any(x => x.Supported) == false) return View(model);

            ContentArea contentArea;
            PreviewModel.PreviewArea areaModel;
            foreach(var option in supportedDisplayOptions)
            {
                contentArea = new ContentArea();
                contentArea.Items.Add(new ContentAreaItem
                {
                    ContentLink = currentContent.ContentLink
                });
                areaModel = new PreviewModel.PreviewArea
                {
                    Supported = option.Supported,
                    AreaTag = option.Tag,
                    AreaName = option.Name,
                    ContentArea = contentArea
                };
                model.Areas.Add(areaModel);
            }
            return View(model);
        }

        public void ModifyLayout(LayoutModel layoutModel)
        {
            layoutModel.HideHeader = true;
            layoutModel.HideFooter = true;
        }

        private bool SupportsTag(IContent content, string tag)
        {
            var templateModel = _templateResolver.Resolve(HttpContext,
                content.GetOriginalType(),
                content,
                TemplateTypeCategories.MvcPartial,
                tag);
            return templateModel != null;
        }
    }
}