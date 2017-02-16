using System.Collections.Generic;
using Brightfind.EktronToEpiserverLab.Models.Pages;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class BlogListViewModel : PageViewModel<BlogPage>
    {
        public int TotalArticles { get; set; }
        public double TotalPages { get; set; }
        public int CurrentPageNumber { get; set; }

        public IEnumerable<BlogPostPage> Articles { get; set; }

        public BlogListViewModel(BlogPage currentPage) : base(currentPage)
        {
        }
    }
}