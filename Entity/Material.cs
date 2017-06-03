using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GisSystemServer.Entity
{
    public class Material
    {
        public int materialId { get; set; }
        public string name { get; set; }
        public int count  { get; set; }        
        public string cost { get; set; }
        public string description { get; set; }



        public int? factoryId { set; get; }
        public virtual Factory factory { get; set; }
    }
}