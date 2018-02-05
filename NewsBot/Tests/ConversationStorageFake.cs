using System.Collections.Generic;

namespace NewsBot
{
    public class ConversationListProviderFake : IConversationListProvider
    {
        public List<ChatConversation> GetConversations()
        {
            return ConverstionStorageStub.ChatConverstions;
        }
    }
}