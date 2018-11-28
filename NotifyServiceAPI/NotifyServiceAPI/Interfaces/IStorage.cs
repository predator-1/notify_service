using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NotifyServiceAPI.Models;

namespace NotifyServiceAPI.Interfaces
{
    public interface IStorage
    {
        List<Message> GetAllMessages();
        void SaveMessage(Message message);
    }
}
