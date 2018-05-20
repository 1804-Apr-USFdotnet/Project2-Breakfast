using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

using Breakfast.Business.News.Models;

namespace Breakfast.Business.News
{
    public static class NewsArticleSerializer
    {
        public static NewsArticle DeserializeFromJson(string json)
        {
            MemoryStream ms = new MemoryStream();

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NewsArticle));
                byte[] bytes = Encoding.ASCII.GetBytes(json);
                ms.Write(bytes, 0, bytes.Length);
                ms.Position = 0;
                return (NewsArticle)ser.ReadObject(ms);
            }
            catch
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
        }

        public static string SerializeToJson(NewsArticle toSerialize)
        {
            if (toSerialize == null)
            {
                throw new ArgumentNullException();
            }

            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(NewsArticle));
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                ser.WriteObject(ms, toSerialize);
                ms.Position = 0;
                string json = sr.ReadLine();
                return json;
            }
            catch
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
        }
    }
    
}
