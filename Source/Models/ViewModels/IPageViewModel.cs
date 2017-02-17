using Brightfind.EktronToEpiserverLab.Models.Pages;
using EPiServer.Core;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public interface IPageViewModel<out T> where T : IPageBase
    {
        T CurrentPage { get; }
        LayoutModel Layout { get; set; }
        IContent Section { get; set; }
    }
}