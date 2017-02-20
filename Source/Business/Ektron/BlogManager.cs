using Brightfind.EktronToEpiserverLab.Models.Routed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using EPiServer.Framework.Cache;
using EPiServer.ServiceLocation;
using Newtonsoft.Json;

namespace Brightfind.EktronToEpiserverLab.Business.Ektron
{
    public class BlogManager
    {
        private ISynchronizedObjectInstanceCache _cache = ServiceLocator.Current.GetInstance<ISynchronizedObjectInstanceCache>();
        private const string CacheKeySuffix = ".Ektron.BlogArticle";

        public BlogArticle GetItem(long id)
        {
            var article = _cache.Get<BlogArticle>($"{id}{CacheKeySuffix}", ReadStrategy.Wait);
            if (article != null) return article;

            using (var client = new WebClient())
            {
                var json = client.DownloadString(EktronPath("blogitemhandler", new List<KeyValuePair<string, object>>() { new KeyValuePair<string, object>("id", id) }));
                article = JsonConvert.DeserializeObject<BlogArticle>(json);
                if (article == null) return null;
                _cache.Insert($"{id}{CacheKeySuffix}", article, new CacheEvictionPolicy(new TimeSpan(0, 30, 0), CacheTimeoutType.Absolute));
                return article;
            }
        }

        public BlogArticle GetItem(string name, bool isEncoded = false)
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException(nameof(name));

            if (isEncoded) name = HttpUtility.UrlDecode(name);

            var article = _cache.Get<BlogArticle>($"{name}{CacheKeySuffix}", ReadStrategy.Wait);
            if (article != null) return article;

            using (var client = new WebClient())
            {
                var json = client.UploadString(EktronPath("blogitemnamehandler", null), name);
                article = JsonConvert.DeserializeObject<BlogArticle>(json);
                if (article == null) return null;
                _cache.Insert($"{name}{CacheKeySuffix}", article, new CacheEvictionPolicy(new TimeSpan(0, 30, 0), CacheTimeoutType.Absolute));
                return article;
            }
        }

        public IEnumerable<BlogArticle> GetList()
        {
            var articleList = _cache.Get<List<BlogArticle>>($"BlogList{CacheKeySuffix}", ReadStrategy.Wait);
            if (articleList != null) return articleList;

            using (var client = new WebClient())
            {
                var json = client.DownloadString(EktronPath("bloglisthandler", null));
                articleList = JsonConvert.DeserializeObject<List<BlogArticle>>(json);
                _cache.Insert($"BlogList{CacheKeySuffix}", articleList, new CacheEvictionPolicy(new TimeSpan(0, 30, 0), CacheTimeoutType.Absolute));
                return articleList;
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