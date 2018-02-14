using System.Collections.Generic;

namespace NewsBot
{
    public class ConversationListProviderFake : IConversationClientsListProvider
    {
        public List<ChatClients> GetClietns()
        {
            return ConverstionStorageStub.ChatClients;
        }
    }
}