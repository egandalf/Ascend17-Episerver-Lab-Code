using Brightfind.EktronToEpiserverLab.Models.Routed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Brightfind.EktronToEpiserverLab.Business.Ektron
{
    public class BlogManager
    {
        public BlogArticle GetItem(long id)
        {
            return new BlogArticle();
        }

        public IEnumerable<BlogArticle> GetList()
        {
            return new List<BlogArticle>();
        }
    }
}