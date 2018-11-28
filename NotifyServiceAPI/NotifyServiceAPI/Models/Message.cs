using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NotifyServiceAPI.Models
{
    public class Message
    {
        public string Id { get; set; }

        public string[] Recipients { get; set; }

        public string Subject { get; set; }

        public string Body { get; set; }

        public bool IsSent { get; set; }
    }
}