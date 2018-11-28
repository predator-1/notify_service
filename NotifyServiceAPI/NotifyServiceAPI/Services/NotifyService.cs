using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NotifyServiceAPI.Interfaces;
using NotifyServiceAPI.Models;

namespace NotifyServiceAPI.Services
{
    public class NotifyService : INotifyService
    {
        private IPushService _pushService { get; }
        private IStorage _storage { get; }

        public NotifyService(IPushService pushService, IStorage storage)
        {
            _pushService = pushService;
            _storage = storage;
        }

        public List<Message> GetAllMessages()
        {
            return _storage.GetAllMessages();
        }

        public Message Send(Message message)
        {
            message.Id = Guid.NewGuid().ToString();
            _pushService.Send(message);
            _storage.SaveMessage(message);
            return message;
        }
    }
}