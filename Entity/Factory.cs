using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GisSystemServer.Entity
{
    public class Factory
    {
        [Key]
        public int factiryId { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string  year { get; set; }
        public string industry { get; set; }
        public string adress { get; set; }
        public string site { get; set; }
        public string usertEmail { get; set; }
                
                
    }
}