using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Breakfast.Business.News
{
    public class NewsApiSettings
    {
        //private static readonly Dictionary<string, string> LanguageCodes;
        private static readonly int MaxSrcCount = 20;

        public List<string> QueryStrings;
        public string[] Sources; // questioning implementation here
        public List<string> Domains;
        private Nullable <DateTime> _OldestDate;
        private Nullable <DateTime> _NewestDate;
        public string Language;
        public Nullable <int> PageSize;

        //sort criteria


        #region PropertyFields
        public string OldestDate
        {
            get
            {
                if (_OldestDate == null)
                {
                    return "";
                }
                else
                {
                    return _OldestDate.ToString();
                }
            }
        }
        public string NewestDate
        {
            get
            {
                if (_NewestDate == null)
                {
                    return "";
                }
                else
                {
                    return _NewestDate.ToString();
                }
            }
        }
        #endregion

        #region Constructors
        public NewsApiSettings()
        {
            //Set Language codes
            Sources = new string[MaxSrcCount];
            QueryStrings = new List<string>();
            Domains = new List<string>();
            _OldestDate = null;
            _NewestDate = null;
            PageSize = null;
        }

        public NewsApiSettings(List<string> queryStrings, string [] sources, List<string> domains,
            DateTime oldestDate, DateTime newestDate, string language, int pageSize)
        {
            Sources = new string[MaxSrcCount];
            for(int i = 0; i < sources.Length; i++)
            {
                if(sources[i] != "")
                {
                    Sources[i] = String.Copy(sources[i]);
                }
                else
                {
                    Sources[i] = "";
                }
            }

            QueryStrings = new List<string>();
            foreach (var queryString in queryStrings)
            {
                QueryStrings.Add(String.Copy(queryString));
            }

            Domains = new List<string>();
            foreach (var domain in domains)
            {
                Domains.Add(String.Copy(domain));
            }

            _OldestDate = oldestDate;
            _NewestDate = newestDate;

            Language = String.Copy(language);
            PageSize = pageSize;
        }        

        public NewsApiSettings(NewsApiSettings toCopy)
        {
            Sources = new string[MaxSrcCount];
            QueryStrings = new List<string>();
            Domains = new List<string>();

            for(int i = 0; i < Sources.Length; i++)
            {
                if(toCopy.Sources[i] != "")
                {
                    Sources[i] = String.Copy(toCopy.Sources[i]);
                }
            }

            foreach (var current in toCopy.QueryStrings)
            {
                QueryStrings.Add(String.Copy(current));
            }

            foreach (var current in toCopy.Domains)
            {
                Domains.Add(String.Copy(current));
            }
        }
        #endregion

        public NewsApiSettings Copy()
        {
            return new NewsApiSettings(this);
        }
    }
}
