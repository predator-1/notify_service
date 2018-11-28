using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotifyServiceAPI.Interfaces;
using NotifyServiceAPI.Models;

namespace NotifyServiceAPI.Services
{
    public class PushService : IPushService
    {
        public void Send(Message message)
        {
            message.IsSent = true;
        }
    }
}