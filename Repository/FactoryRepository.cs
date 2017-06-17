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

        public Factory getFactoryById(int id)
        {
            return context.factory.FirstOrDefault(m => m.factiryId == id);
        }

        public void incrByMaterial(int id)
        {
            Material material =  context.material.FirstOrDefault(m => m.factory.factiryId == id);
            material.factory.views++;
            context.SaveChanges();
        }

        public void incrByFactory(int id)
        {
            Factory factory = context.factory.FirstOrDefault(m => m.factiryId == id);
            factory.views= factory.views+ 1.0;
            context.SaveChanges();
        }

        public Count viewsCount(string email)
        {
            double i = 0;
            List<Factory> list = context.factory.Where(m => m.usertEmail == email).ToList();
            foreach(Factory f in list)
            {
                i = i + f.views;
            }
            Count mc = new Count();
            mc.materialCount = Convert.ToInt32(Math.Round(i));
            return mc;
        }
    }
}