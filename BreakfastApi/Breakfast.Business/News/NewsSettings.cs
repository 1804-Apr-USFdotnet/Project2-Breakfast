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
        public string[] Sources;
        public List<string> Domains;
        private DateTime _OldestDate;
        private DateTime _NewestDate;
        public string Language;


        //sort criteria

        public int maxNumResults;

        public string OldestDate { get { return _OldestDate.ToString(); } }
        public string NewestDate { get { return _NewestDate.ToString(); } }

        public NewsApiSettings()
        {
            //Set Language codes
            Sources = new string[MaxSrcCount];
            QueryStrings = new List<string>();
            Domains = new List<string>();
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

        public NewsApiSettings Copy()
        {
            return new NewsApiSettings(this);
        }
    }
}
