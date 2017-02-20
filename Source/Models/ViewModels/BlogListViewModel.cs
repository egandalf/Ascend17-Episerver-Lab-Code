using System.Collections.Generic;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Brightfind.EktronToEpiserverLab.Models.Routed;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class BlogListViewModel : PageViewModel<BlogPage>
    {
        public int TotalArticles { get; set; }
        public double TotalPages { get; set; }
        public int CurrentPageNumber { get; set; }

        public IEnumerable<BlogArticle> Articles { get; set; }

        public BlogListViewModel(BlogPage currentPage) : base(currentPage)
        {
        }
    }
}