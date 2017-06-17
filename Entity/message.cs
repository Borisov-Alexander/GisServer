using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GisSystemServer.Entity
{
    public class Message
    {
        public int messageId { get; set; }
        public string inputCustomer { get; set; }
        public string forCustomer { get; set; }
        public string message { get; set; }
    }
}