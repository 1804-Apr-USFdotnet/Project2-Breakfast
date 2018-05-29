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
        public int Id;
        public string Queries;
        public string Sources;
        public string Domains;
        private Nullable <DateTime> _OldestDate;
        private Nullable <DateTime> _NewestDate;
        public string Language;
        public Nullable <int> PageSize;
        public bool Enabled;


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
            Sources = "";
            Queries = "";
            Domains = "";
            _OldestDate = null;
            _NewestDate = null;
            PageSize = null;
            Enabled = false;
        }

        public NewsSettings(int id = -1, string queries = "", string sources = "",
            string domains = "", Nullable<DateTime> oldestDate = null,
            Nullable<DateTime> newestDate = null, string language = null,
            Nullable<int> pageSize = null, bool enabled = false)
        {
            Id = id;
            if (sources != null) { Sources = string.Copy(sources); }
            else { Sources = null; }
            if (queries != null) { Queries = string.Copy(queries); }
            else { Queries = null; }
            if (domains != null) { Domains = string.Copy(domains); }
            else { Domains = null; }
            _OldestDate = oldestDate;
            _NewestDate = newestDate;
            if (language != null) { Language = string.Copy(language); }
            else { Language = null; }
            PageSize = pageSize;
            Enabled = enabled;
        }        

        public NewsSettings(NewsSettings toCopy)
        {
            if (toCopy == null)
            {
                throw new ArgumentNullException();
            }

            if(toCopy.Sources != null) { Sources = string.Copy(toCopy.Sources); }
            else { Sources = null; }

            if (toCopy.Queries != null) { Queries = string.Copy(toCopy.Queries); }
            else { Queries = null; }

            if (toCopy.Domains != null) { Domains = string.Copy(toCopy.Domains); }
            else { Domains = null; }

            _OldestDate = toCopy._OldestDate;
            _NewestDate = toCopy._NewestDate;

            if (toCopy.Language != null) { Language = string.Copy(toCopy.Language); }
            else { Language = null; }

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
            NewsSettings newsSettings = new NewsSettings();
            newsSettings.Id = nsData.Pk_NewsId;
            if (nsData.Queries != null) { newsSettings.Queries = string.Copy(nsData.Queries); }
            else { newsSettings.Queries = null; }

            if (nsData.Sources != null) { newsSettings.Sources = string.Copy(nsData.Sources); }
            else { newsSettings.Sources = null; }

            if (nsData.Domains != null) { newsSettings.Domains = string.Copy(nsData.Domains); }
            else { newsSettings.Domains = null; }

            newsSettings._OldestDate = nsData.OldestDate;
            newsSettings._NewestDate = nsData.NewestDate;

            if (nsData.Language != null) { newsSettings.Language = string.Copy(nsData.Language); }
            else { newsSettings.Language = null; }

            newsSettings.PageSize = nsData.PageSize;
            newsSettings.Enabled = nsData.Enabled;

            return newsSettings;
        }

        static public explicit operator Data.Models.NewsSettings(NewsSettings newsSettings)
        {
            if (newsSettings == null)
            {
                throw new ArgumentNullException();
            }

            Data.Models.NewsSettings nsData = new Data.Models.NewsSettings();

            nsData.Pk_NewsId = newsSettings.Id;

            if (newsSettings.Queries != null) { nsData.Queries = string.Copy(newsSettings.Queries); }
            else { nsData.Queries = null; }

            if (newsSettings.Sources != null) { nsData.Sources = string.Copy(newsSettings.Sources); }
            else { nsData.Sources = null; }

            if (newsSettings.Domains != null) { nsData.Domains = string.Copy(newsSettings.Domains); }
            else { nsData.Domains = null; }

            nsData.OldestDate = newsSettings._OldestDate;
            nsData.NewestDate = newsSettings._NewestDate;
            if (newsSettings.Language != null) { nsData.Language = string.Copy(newsSettings.Language); }
            else { nsData.Language = null; }
            nsData.PageSize = newsSettings.PageSize;
            nsData.Enabled = newsSettings.Enabled;    

            return nsData;
        }
    }
}
