using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GisSystemServer.Entity;
using GisSystemServer.Context;

namespace GisSystemServer.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        private readonly UserContext context;
        private Boolean Disposed;
        public MaterialRepository(UserContext _context)
        {
            context = _context;
        }

        public void addMaterial(Material material)
        {
           Factory factory =  context.factory.FirstOrDefault(m => m.factiryId == material.factoryId);
            material.factory = factory;            
            context.material.Add(material);
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

        public List<Material> getAllMaterial()
        {
             
            return context.material.Where(m => m.name != "").ToList();
        }

        public void updMaterial(Factory factory)
        {
            throw new NotImplementedException();
        }
    }
}