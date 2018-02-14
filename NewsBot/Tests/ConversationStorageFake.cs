using System.Collections.Generic;

namespace NewsBot
{
    public class ConversationListProviderFake : IConversationClientsListProvider
    {
        public List<ChatClient> GetClietns()
        {
            return ConverstionStorageStub.ChatClients;
        }
    }
}