using Brightfind.EktronToEpiserverLab.Models.Routed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json;

namespace Brightfind.EktronToEpiserverLab.Business.Ektron
{
    public class BlogManager
    {
        public BlogArticle GetItem(long id)
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString(EktronPath("blogitemhandler", new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("id", id) }));
                return JsonConvert.DeserializeObject<BlogArticle>(json);
            }
        }

        public IEnumerable<BlogArticle> GetList()
        {
            using (var client = new WebClient())
            {
                var json = client.DownloadString(EktronPath("bloglisthandler", null));
                return JsonConvert.DeserializeObject<List<BlogArticle>>(json);
            }
        }

        private static string EktronPath(string name, List<KeyValuePair<string, object>> querystring)
        {
            var path = $"http://lab.brightfind.com/components/handlers/{name}.ashx";
            if (querystring == null || !querystring.Any()) return path;

            path += "?";
            var parameterStrings = querystring.Distinct().Select(pair => $"{pair.Key}={pair.Value}").ToArray();
            path += string.Join("&", parameterStrings);
            return path;
        }
    }
}