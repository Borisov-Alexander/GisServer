using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GisSystemServer.Entity;
using GisSystemServer.Context;

namespace GisSystemServer.Repository
{
    public class FactoryRepository : IFactoryRepository
    {
        private readonly UserContext context;
        private Boolean Disposed;
        public FactoryRepository(UserContext _context)
        {
            context = _context;
        }        

        public void addFactory(Factory factory, string email)
        {
            Factory _factory = factory;
            _factory.usertEmail = email;
            context.factory.Add(_factory);
            context.SaveChanges();
        }

        public void Dispose()
        {
            if (!Disposed)
            {
                if (context != null)
                {
                    context.Dispose();

                    Disposed = true;
                }
            }
        }

        public List<Factory> getFactoryByEmail(string email)
        {
            return context.factory.Where(m => m.usertEmail == email).ToList();
        }

        public List<Factory> getAllFactory()
        {
            return context.factory.Where(m => m.usertEmail != "").ToList();
        }

        public int[] getFactoryCount(string email)
        {
            List<Factory> list = context.factory.Where(m => m.usertEmail == email).ToList();
            int[] count = new int[2];
            count[0] = list.Count;
            count[1] = context.factory.Count();
            return count; 
        }

        public void updFactory(Factory factory)
        {
            throw new NotImplementedException();
        }
    }
}