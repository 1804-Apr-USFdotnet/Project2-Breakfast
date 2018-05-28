using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;



namespace Breakfast.Areas.News.Models
{
    public class NewsArticle
    {
        public readonly string Title;
        public readonly string Author;
        public readonly string Source;
        public readonly string Description;
        public readonly string Url;
        public readonly string ImgUrl;
        public readonly DateTime PubDateTime;

        #region Constructors
        [JsonConstructor]
        public NewsArticle(string Title, string Author, string Source, string Desc, string Url, string ImgUrl, DateTime PublDate)
        {
            this.Title = Title;
            this.Author = Author;
            this.Source = Source;
            this.Description = Desc;
            this.Url = Url;
            this.ImgUrl = ImgUrl;
            this.PubDateTime = PublDate;
        }

        public NewsArticle(NewsArticle toCopy)
        {
            Title = String.Copy(toCopy.Title);
            Author = String.Copy(toCopy.Author);
            Source = String.Copy(toCopy.Source);
            Description = String.Copy(toCopy.Description);
            Url = String.Copy(toCopy.Url);
            ImgUrl = String.Copy(toCopy.ImgUrl);
            PubDateTime = toCopy.PubDateTime;
        }
        #endregion

        public static IEnumerable<NewsArticle> GetArticles(string userId)
        {
            const string uri = "http://ec2-18-188-45-20.us-east-2.compute.amazonaws.com/Breakfast.Service_deploy/";

            HttpWebRequest apiRequest = WebRequest.Create(uri + "api/news/getArticles/" + userId + "/") as HttpWebRequest;
            string apiResponse = "";
            using (var response = apiRequest.GetResponse() as HttpWebResponse)
            {
                StreamReader reader = new StreamReader(response.GetResponseStream());
                apiResponse = reader.ReadToEnd();
            }

            IEnumerable<NewsArticle> articles = JsonConvert.DeserializeObject<List<NewsArticle>>(apiResponse);
            return articles;
        }
    }
}