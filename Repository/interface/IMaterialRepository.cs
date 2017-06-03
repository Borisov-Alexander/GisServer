using GisSystemServer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GisSystemServer.Repository
{
    public interface IMaterialRepository : IDisposable
    {
        void addMaterial(Material material);        
        List<Material> getAllMaterial();       
        void updMaterial(Factory factory);
    }
}