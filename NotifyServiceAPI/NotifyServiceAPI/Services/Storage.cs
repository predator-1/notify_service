using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotifyServiceAPI.Interfaces;
using NotifyServiceAPI.Models;

namespace NotifyServiceAPI.Services
{
    public class Storage : IStorage
    {
        public static ConcurrentBag<Message> Messages = new ConcurrentBag<Message>();

        public List<Message> GetAllMessages()
        {
            return Messages.ToList();
        }

        public void SaveMessage(Message message)
        {
            Messages.Add(message);
        }
    }
}