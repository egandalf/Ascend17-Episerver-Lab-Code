using System.Web.Mvc;
using Brightfind.EktronToEpiserverLab.Models.Media;
using Brightfind.EktronToEpiserverLab.Models.ViewModels;
using EPiServer.ServiceLocation;
using EPiServer.Web.Mvc;
using EPiServer.Web.Routing;

namespace Brightfind.EktronToEpiserverLab.Controllers
{
    public class ImageMediaController : PartialContentController<ImageMedia>
    {
        private readonly UrlResolver _urlResolver = ServiceLocator.Current.GetInstance<UrlResolver>();

        public override ActionResult Index(ImageMedia currentContent)
        {
            var model = new ImageViewModel
            {
                Name = currentContent.Name,
                Url = _urlResolver.GetUrl(currentContent.ContentLink),
                Copyright = currentContent.Copyright,
                AlternateText = currentContent.AlternateText
            };

            return PartialView(model);
        }

        //public override ActionResult Index(MyContentType currentBlock)
        //{
        //    return PartialView(currentBlock);
        //}
    }
}
