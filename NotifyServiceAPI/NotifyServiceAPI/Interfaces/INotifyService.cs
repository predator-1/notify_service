using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifyServiceAPI.Models;

namespace NotifyServiceAPI.Interfaces
{
    public interface INotifyService
    {
        Message Send(Message message);

        List<Message> GetAllMessages();
    }
}
