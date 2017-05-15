using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GisSystemServer.Entity
{
    public class Customer
    {
        public int customerId { get; set; }
        public string uompany { get; set; }
        public string userName { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string adress { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string description { get; set; }
    }
}