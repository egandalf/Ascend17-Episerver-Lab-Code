using Brightfind.EktronToEpiserverLab.Models.Pages;
using EPiServer.Core;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class PageViewModel<T> : IPageViewModel<T> where T : SpockPageBase
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
        public static PageViewModel<T> Create<T>(T page) where T : SpockPageBase => new PageViewModel<T>(page);
    }
}