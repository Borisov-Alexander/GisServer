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
    }
}