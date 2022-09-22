using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Oxyzen8SelectorServer.Models
{
    public class AuthSchema
    {
        public string userName { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string title { get; set; }
        public string customerId { get; set; }
        public string access { get; set; }
        public string accessLevel { get; set; }
        public string accessPricing { get; set; }
        public string create_data { get; set; }
    }
}