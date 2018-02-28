using Microsoft.Bot.Connector;
using System.Threading;
using System.Threading.Tasks;

namespace NewsBot
{
    public interface IConversationSaver
    {
        Task<bool> SaveConversation(IMessageActivity activity, SemaphoreSlim _semaphoreSlim);
    }
}
