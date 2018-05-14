using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryInterfaces
{
    public interface ITrafficRepository
    {
        //simply an interface, exposes the methods of the concrete class so we can use the interface in its place
        //and let autofac take care of the rest

        //IQueryable<Model> GetAll();
    }
}
