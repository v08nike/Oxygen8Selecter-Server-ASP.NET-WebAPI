using System.Collections.Generic;

namespace Oxygen8SelectorServer.Models
{
    public class MailRequest
    {
        public string ToEmail { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}