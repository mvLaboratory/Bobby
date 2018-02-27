using System.Collections.Generic;

namespace NewsBot
{
    public interface IConversationClientsListProvider
    {
        List<ChatClient> GetClietns();

        List<ChatConversationStatus> GetConversationsStatuses();
    }
}
