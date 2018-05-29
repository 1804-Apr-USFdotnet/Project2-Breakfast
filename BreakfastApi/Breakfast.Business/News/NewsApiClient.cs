using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

using Breakfast.Business.News.Models;

namespace Breakfast.Business.News
{
    public class NewsApiClient
    {
        NewsSettings Settings;
        private static readonly string ApiKey = "7d149bd8ce044572abb107044e4abe4a";

        public NewsApiClient()
        {
            Settings = new NewsSettings ();
        }

        public NewsApiClient (NewsSettings settings)
        {
            if(settings == null)
            {
                throw new ArgumentNullException();
            }

            this.Settings = settings.Copy();
        }

        public IEnumerable<NewsArticle> GetNewsArticles(int pageNum = 1)
        {
            string json = CallNewsApi(pageNum);
            return ParseApiRequest(json);
        }

        public IEnumerable<NewsArticle> GetNewsArticles(int pageNum = 1, string domains = null, string queries = null,
                                 string sources = null, string language = null, string oldestDate = null,
                                 string newestDate = null, int pageSize = 20)
        {
            string json = CallNewsApi(pageNum, domains, queries, sources, language, oldestDate, newestDate, pageSize);
            return ParseApiRequest(json);
        }

        public IEnumerable<NewsArticle> GetNewsArticles (string conditions)
        {
            string json = CallNewsApi(conditions);
            return ParseApiRequest(json);
        }

        private IEnumerable<NewsArticle> ParseApiRequest(string json)
        {
            List<NewsArticle> articleList = new List<NewsArticle>();
            int bracketPos = json.IndexOfAny(new char[] { '[' });
            Regex articleJsonGrab = new Regex("(?<=\\[)(\\,)?\\{[^\\{\\}]+(\\{[^\\}]+\\})[^\\{\\}]+\\}\\,?");

            string articlesJson;
            do
            {
                //Regex articleJsonGrab = new Regex("(?<=\\[)(\\,)?\\{[^\\{\\}]+(\\{[^\\}]+\\})[^\\{\\}]+\\}\\,?");
                articlesJson = articleJsonGrab.Match(json).ToString();
                json = json.Remove(bracketPos + 1, articlesJson.Length);
                if (articlesJson != "")
                {
                    articleList.Add(ParseNewsArticle(articlesJson));
                }
            } while (articlesJson != "");
            return articleList;
        }

        private NewsArticle ParseNewsArticle(string json)
        {
            if (json == "" || json == null)
                return null;
            Regex grabTitle = new Regex("(?<=\"title\":\"){1}([^\"]*)(?=\"){1}");
            Regex grabAuthor = new Regex("(?<=\"author\":\"){1}([^\"]*)(?=\"){1}");
            Regex grabSource = new Regex("(?<=\"name\":\"){1}([^\"]*)(?=\"){1}");
            Regex grabUrl = new Regex("(?<=\"url\":\"){1}([^\"]*)(?=\"){1}");
            Regex grabImgUrl = new Regex("(?<=\"urlToImage\":\"){1}([^\"]*)(?=\"){1}");
            Regex grabDesc = new Regex("(?<=\"description\":\"){1}([^\"]*)(?=\"){1}");
            Regex grabDate = new Regex("(?<=\"publishedAt\":\"){1}([^\"]*)(?=\"){1}");

            string title = grabTitle.Match(json).ToString();
            string author = grabAuthor.Match(json).ToString();
            string source = grabSource.Match(json).ToString();
            string url = grabUrl.Match(json).ToString();
            string imageUrl = grabImgUrl.Match(json).ToString();
            string desc = grabDesc.Match(json).ToString();
            DateTime publDate = DateTime.Parse(grabDate.Match(json).ToString());

            return new NewsArticle(title, author, source, url, imageUrl, desc, publDate);
        }

        public string CallNewsApi(string searchConditions)
        {
            searchConditions = searchConditions.Replace(' ', '&');
            string url = "https://newsapi.org/v2/everything?" + searchConditions + "&" + GetSubstringApiKey();
            return new WebClient().DownloadString(url);
        }

        public string CallNewsApi(int pageNum = 1, string domains = null, string queries = null,
                                 string sources = null, string language = null, string oldestDate = null,
                                 string newestDate = null, int pageSize = 20)
        {
            string url = "https://newsapi.org/v2/everything?";
            if (domains != null)
            {
                url += "domains=" + domains + "&";
            }

            if (queries != null)
            {
                url += "q=" + queries + "&";
            }

            if (sources != null)
            {
                url += "sources=" + sources + "&";
            }

            if (language != null)
            {
                url += "language=" + language + "&";
            }

            if (oldestDate != null)
            {
                url += "from=" + oldestDate + "&";
            }

            if (newestDate != null)
            {
                url += "to=" + newestDate + "&";
            }

            url += "page=" + pageNum.ToString() + "&" + "pagesize=" + pageSize.ToString();

            return new WebClient().DownloadString(url);
        }

        public string CallNewsApi(int pageNum = 1)
        {
            var url = "https://newsapi.org/v2/everything?" +
            GetSubstringDomains() +
            GetSubstringQueries() +
            GetSubstringSources() +
            GetSubstringLanguage() +
            GetSubstringOldestDate() +
            GetSubstringNewestDate() +
            GetSubstringPageSize() +
            GetSubstringPage(pageNum) +
             GetSubstringApiKey();

            var json = new WebClient().DownloadString(url);
            return json;
        }

        #region Substring Methods
        public string GetSubstringLanguage()
        {
            if (Settings.Language == "" || Settings.Language == null)
            {
                return "";
            }
            else
            {
                return "language=" + Settings.Language + "&";
            }
        }

        private string GetSubstringQueries ()
        {
            if (Settings.Queries == null || Settings.Queries == "")
            {
                return "";
            }
            else
            {
                return "q=" + Settings.Queries + "&";
            }
        }

        private string GetSubstringSources ()
        {
            if (Settings.Sources == "" || Settings.Sources == null)
            {
                return "";
            }
            else
            {
                return "sources=" + Settings.Sources + "&";
            }
        }

        private string GetSubstringDomains ()
        {
            if (Settings.Domains == "" || Settings.Domains == null)
            {
                return "";
            }
            else
            {
                return "domains=" + Settings.Domains + "&";
            }
        }

        private string GetSubstringOldestDate ()
        {
            if (Settings.OldestDate == "")
            {
                return "";
            }
            else
            {
                return "from=" + Settings.OldestDate + "&";
            }
        }

        private string GetSubstringNewestDate ()
        {
            if (Settings.NewestDate == "")
            {
                return "";
            }
            else
            {
                return "to=" + Settings.NewestDate + "&";
            }
        }

        private string GetSubstringPageSize ()
        {
            if (Settings.PageSize == null)
            {
                return "pagesize=20&";
            }
            return "pagesize=" + Settings.PageSize.ToString() + "&";
        }

        private string GetSubstringPage (int pageNum = 1)
        {
            if (pageNum < 2)
            {
                return "";
            }
            return "page=" + pageNum.ToString() + "&";
        }

        private static string GetSubstringApiKey()
        {
            return "apiKey=" + ApiKey;
        }
        #endregion

        static IEnumerable<string> GetSources()
        {
            List<string> sources = new List<string>();

            string sourceEndpoint = "https://newsapi.org/v2/sources?" + GetSubstringApiKey();

            var json = new WebClient().DownloadString(sourceEndpoint);
            int bracketPos = json.IndexOfAny(new char[] { '[' });

            Regex grabSource = new Regex("(?<=\\[)\\{[^\\}]*\\}\\,?");
            Regex grabId = new Regex("(?<=\\{\\\"id\\\":\\\")[^\\\"]*");
            string sourceJson;
            do
            {
                sourceJson = grabSource.Match(json).ToString();
                json = json.Remove(bracketPos + 1, sourceJson.Length);
                if (sourceJson != "")
                {
                    sources.Add(ParseSourceId(sourceJson));
                }
            } while (sourceJson != "");

            return sources;
        }

        static public bool IsValidSource (string sourceId)
        {
            bool isValid = false;

            foreach (var curSource in GetSources())
            {
                if(sourceId == curSource)
                {
                    isValid = true;
                    break;
                }
            }

            return isValid;
        }

        static string ParseSourceId(string json)
        {
            Regex grabId = new Regex("(?<=\\{\\\"id\\\":\\\")[^\\\"]*");
            return grabId.Match(json).ToString();
        }


    }
}
