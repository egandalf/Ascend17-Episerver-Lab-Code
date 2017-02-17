using Brightfind.EktronToEpiserverLab.Models.Pages;
using EPiServer.Core;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : IPageBase
    {
        public T CurrentPage { get; private set; }
        public LayoutModel Layout { get; set; }
        public IContent Section { get; set; }

        public PageViewModel(T currentPage)
        {
            CurrentPage = currentPage;
        }
    }

    public static class PageViewModel
    {
        public static PageViewModel<T> Create<T>(T page) where T : IPageBase => new PageViewModel<T>(page);
    }
}