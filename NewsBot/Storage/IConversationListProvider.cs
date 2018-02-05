using System.Collections.Generic;

namespace NewsBot
{
    interface IConversationListProvider
    {
        List<ChatConversation> GetConversations();
    }
}
