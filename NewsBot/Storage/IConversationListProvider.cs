using System.Collections.Generic;

namespace NewsBot
{
    interface IConversationClientsListProvider
    {
        List<ChatClient> GetClietns();
    }
}
