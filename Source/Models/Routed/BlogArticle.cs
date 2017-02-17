using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Brightfind.EktronToEpiserverLab.Models.Pages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Brightfind.EktronToEpiserverLab.Models.Routed
{
    public class BlogArticle : IPageBase
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public DateTime Published { get; set; }
        [JsonConverter(typeof(XhtmlContentConverter))]
        public string Body { get; set; }
        public string Subject { get; set; }
        public string Teaser { get; set; }
        public string MetaTitle { get; set; }

        [JsonConverter(typeof(StringToArrayConverter))]
        public string[] MetaKeywords { get; set; }

        public string MetaDescription { get; set; }
    }

    public class XhtmlContentConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return UpdateReferences(token.Value<string>());
        }

        private string UpdateReferences(string value)
        {
            return value.Replace("src=\"/", "src=\"http://lab.brightfind.com/").Replace("href=\"/", "href=\"http://lab.brightfind.com/");
        }

        public override bool CanConvert(Type objectType) => true;
    }

    public class StringToArrayConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) { }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var token = JToken.Load(reader);
            return token.Type == JTokenType.Array ? token.ToObject<string[]>() : token.Value<string>().Split(';', ',');
        }

        public override bool CanConvert(Type objectType) => true;
    }
}