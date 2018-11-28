using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NotifyServiceAPI.Interfaces;
using NotifyServiceAPI.Models;

namespace NotifyServiceAPI.Controllers
{
    public class NotifyController : ApiController
    {
        private INotifyService _notifyService { get; }

        public NotifyController(INotifyService notifyService)
        {
            _notifyService = notifyService;
        }

        [HttpGet]
        public List<Message> GetAllMessages()
        {
            return _notifyService.GetAllMessages();
        }

        [HttpPost]
        public Message Send(Message message)
        {
            _notifyService.Send(message);
            return message;
        }
    }
}
