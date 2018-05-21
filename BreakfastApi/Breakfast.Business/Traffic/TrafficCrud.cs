using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Breakfast.Business.Traffic.Models;
using Breakfast.Data;

namespace Breakfast.Business.Traffic
{
    public class TrafficCrud
    {
        public static void SaveSettings(string userId, TrafficSettingsBusiness tsb)
        {
            Storage storage = new Storage(new DefaultDBUtils());
            tsb.Id = storage.GetTrafficId(userId);
            storage.SaveTrafficSettings((Data.Models.TrafficSettings)tsb);
        }
    }
}
