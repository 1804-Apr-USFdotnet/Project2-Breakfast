﻿using System;
using System.Collections.Generic;
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
        public readonly DateTime PubDateTime;

        #region Constructors
        public NewsArticle(string title, string author, string source, string description, string url, DateTime pubDateTime)
        {
            Title = title;
            Author = author;
            Source = source;
            Description = description;
            Url = url;
            PubDateTime = pubDateTime;
        }

        public NewsArticle(NewsArticle toCopy)
        {
            Title = String.Copy(toCopy.Title);
            Author = String.Copy(toCopy.Author);
            Source = String.Copy(toCopy.Source);
            Description = String.Copy(toCopy.Description);
            Url = String.Copy(toCopy.Url);
            PubDateTime = toCopy.PubDateTime;
        }
        #endregion


        public void GetArticles()
        {
            //todo: Parse these results into separate Articles
            var url = "https://newsapi.org/v2/top-headlines?" +  
                "country=us&" +
                "apiKey=7d149bd8ce044572abb107044e4abe4a"; // hard coded API Key

            var json = new WebClient().DownloadString(url);

            Console.WriteLine(json);
        }
    }
}