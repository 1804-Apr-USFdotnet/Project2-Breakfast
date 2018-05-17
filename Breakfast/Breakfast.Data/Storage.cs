using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Breakfast.Data
{
    public class Storage
    {
        private IDButils utility;
        public Storage(IDButils utility)
        {
            this.utility = utility;
        }


    }
}
