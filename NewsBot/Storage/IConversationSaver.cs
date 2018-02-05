using Microsoft.Bot.Connector;

namespace NewsBot
{
    interface IConversationSaver
    {
        bool SaveConversation(IMessageActivity activity);
    }
}
