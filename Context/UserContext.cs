using GisSystemServer.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GisSystemServer.Context
{
    public  class UserContext : DbContext
    {
        public UserContext() : base("name=DefaultConnection")
        {
        }
        public  DbSet<Customer> customer { get; set; }
        public DbSet<Factory> factory { get; set; }
        public DbSet<Material> material { get; set; }
        public DbSet<Message> message { get; set; }
    }
}