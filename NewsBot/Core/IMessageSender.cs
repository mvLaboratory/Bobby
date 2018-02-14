
using System;
using System.Threading.Tasks;

namespace NewsBot
{
    public interface IMessageSender
    {
        Task<bool> SendMessage(ChatClient client, String message);
    }
}
