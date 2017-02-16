using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brightfind.EktronToEpiserverLab.Models.Pages;

namespace Brightfind.EktronToEpiserverLab.Models.ViewModels
{
    public class NewsListViewModel : PageViewModel<NewsListPage>
    {
        public IEnumerable<NewsPage> Articles { get; set; }

        public int TotalArticles { get; set; }
        public double TotalPages { get; set; }
        public int CurrentPageNumber { get; set; }

        public NewsListViewModel(NewsListPage currentPage) : base(currentPage)
        {
        }
    }
}