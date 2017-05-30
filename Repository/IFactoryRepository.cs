using GisSystemServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GisSystemServer.Repository
{
    public interface IFactoryRepository : IDisposable
    {
        void addFactory(Factory factory , string email);
        List<Factory> getFactoryByEmail(string email);
        List<Factory> getAllFactory();
        int[] getFactoryCount(string email);
        void updFactory(Factory factory);

    }
}
