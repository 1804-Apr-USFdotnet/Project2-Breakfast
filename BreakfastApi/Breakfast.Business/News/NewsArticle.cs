using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Business.News
{
    public class NewsArticle
    {
        [DataMember]
        public readonly string Title;
        [DataMember]
        public readonly string Author;
        [DataMember]
        public readonly string Source;
        [DataMember]
        public readonly string Url;
        [DataMember]
        public readonly string Desc;
        [DataMember]
        public readonly DateTime PublDate;

        private NewsArticle()
        {
        }

        public NewsArticle(string title, string author, string source, string url, string desc, DateTime publDate)
        {
            Title = String.Copy(title);
            Author = String.Copy(author);
            Source = String.Copy(source);
            Url = String.Copy(url);
            Desc = String.Copy(desc);
            PublDate = publDate;
        }

        public NewsArticle(NewsArticle toCopy)
        {
            Title = String.Copy(toCopy.Title);
            Author = String.Copy(toCopy.Author);
            Source = String.Copy(toCopy.Source);
            Url = String.Copy(toCopy.Url);
            Desc = String.Copy(toCopy.Desc);
            PublDate = toCopy.PublDate;
        }
    }
}
