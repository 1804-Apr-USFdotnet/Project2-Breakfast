using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace Breakfast.Business.News.Models
{
    public class NewsSettings
    {
        //private static readonly Dictionary<string, string> LanguageCodes;
        private static readonly int MaxSrcCount = 20;

        public int Id;
        public List<string> Queries;
        public string[] Sources; // questioning implementation here
        public List<string> Domains;
        private Nullable <DateTime> _OldestDate;
        private Nullable <DateTime> _NewestDate;
        public string Language;
        public Nullable <int> PageSize;
        public bool Enabled;
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
                    return _OldestDate.Value.Year + "-" + _OldestDate.Value.Month + "-" + _OldestDate.Value.Day;
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
                    return _NewestDate.Value.Year + "-" + _NewestDate.Value.Month + "-" + _NewestDate.Value.Day;
                }
            }
        }
        #endregion

        #region Constructors
        public NewsSettings()
        {
            Id = -1;
            //Set Language codes
            Sources = new string[MaxSrcCount];
            Queries = new List<string>();
            Domains = new List<string>();
            _OldestDate = null;
            _NewestDate = null;
            PageSize = null;
            Enabled = false;
        }

        public NewsSettings(int id = -1, List<string> queryStrings = null, string [] sources = null,
            List<string> domains = null, Nullable<DateTime> oldestDate = null,
            Nullable<DateTime> newestDate = null, string language = null,
            Nullable<int> pageSize = null, bool enabled = false)
        {
            Id = -1;
            Sources = new string[MaxSrcCount];
            if (sources != null)
            {
                for (int i = 0; i < sources.Length && i < MaxSrcCount; i++)
                {
                    if (sources[i] != "" && sources[i] != null)
                    {
                        Sources[i] = String.Copy(sources[i]);
                    }
                    else
                    {
                        Sources[i] = "";
                    }
                }
            }

            Queries = new List<string>();
            if(queryStrings != null)
            { 
                foreach (var queryString in queryStrings)
                {
                    Queries.Add(String.Copy(queryString));
                }
            }

            Domains = new List<string>();
            if(domains != null)
            {
                foreach (var domain in domains)
                {
                    Domains.Add(String.Copy(domain));
                }
            }

            _OldestDate = oldestDate;
            _NewestDate = newestDate;

            if(language != null)
            {
                Language = String.Copy(language);
            }
            else
            {
                Language = language;
            }

            PageSize = pageSize;
            Enabled = enabled;
        }        

        public NewsSettings(NewsSettings toCopy)
        {
            Sources = new string[MaxSrcCount];
            Queries = new List<string>();
            Domains = new List<string>();

            for(int i = 0; i < Sources.Length && i < MaxSrcCount; i++)
            {
                if(toCopy.Sources[i] != "" && toCopy.Sources[i] != null)
                {
                    Sources[i] = String.Copy(toCopy.Sources[i]);
                }
            }

            foreach (var current in toCopy.Queries)
            {
                Queries.Add(String.Copy(current));
            }

            foreach (var current in toCopy.Domains)
            {
                Domains.Add(String.Copy(current));
            }

            _OldestDate = toCopy._OldestDate;
            _NewestDate = toCopy._NewestDate;

            Language = String.Copy(toCopy.Language);

            PageSize = toCopy.PageSize;
            Enabled = toCopy.Enabled;
        }
        #endregion

        public NewsSettings Copy()
        {
            return new NewsSettings(this);
        }

        static public explicit operator NewsSettings(Data.Models.NewsSettings nsData)
        {
            string concatQueryString = nsData?.Queries;
            string concatDomainString = nsData?.Queries;
            string concatSourceString = nsData?.Queries;
            char[] separatorCharacters = new char[] { '"' };

            string[] parsedQueries = { };
            if (concatQueryString != null)
                parsedQueries = concatQueryString.Split(separatorCharacters);

            string[] parsedDomains = { };
            if (concatDomainString != null)
                parsedDomains = concatDomainString.Split(separatorCharacters);

            string[] parsedSources = { };
            if (concatSourceString != null)
                parsedSources = concatSourceString.Split(separatorCharacters);

            NewsSettings newsSettings = new NewsSettings()
            {
                Id = nsData.Pk_NewsId,
                Queries = parsedQueries.ToList(),
                Sources = parsedSources,
                Domains = parsedDomains.ToList(),
                _OldestDate = nsData.OldestDate,
                _NewestDate = nsData.NewestDate,
                Language = nsData.Language,
                PageSize = nsData.PageSize,
                Enabled = nsData.Enabled
            };

            return newsSettings;
        }

        static public explicit operator Data.Models.NewsSettings(NewsSettings newsSettings)
        {
            if(newsSettings == null)
            {
                throw new ArgumentNullException();
            }
            string concatQueries = null;
            if(newsSettings.Queries != null) { 
                foreach (var query in newsSettings.Queries)
                {
                    concatQueries += query + "\"";
                }
            } else
            {
 //               concatQueries = "";
            }

            string concatSources = null;
            if(newsSettings.Sources != null)
            { 

                foreach (var source in newsSettings.Sources)
                {
                    concatSources += source + "\"";
                }
            }
            else
            {
 //               concatSources = "";
            }

            string concatDomains = null;
            if (newsSettings.Domains != null)
            {

                foreach (var domain in newsSettings.Domains)
                {
                    concatDomains += domain + "\"";
                }
            }
            else
            {
//                concatDomains = "";
            }

            Data.Models.NewsSettings nsData = new Data.Models.NewsSettings()
            {
                Pk_NewsId = newsSettings.Id,
                Queries = concatQueries,
                Sources = concatSources,
                Domains = concatDomains,
                OldestDate = newsSettings._OldestDate,
                NewestDate = newsSettings._NewestDate,
                Language = newsSettings.Language,
                PageSize = newsSettings.PageSize,
                Enabled = newsSettings.Enabled
            };

            return nsData;
        }
    }
}
