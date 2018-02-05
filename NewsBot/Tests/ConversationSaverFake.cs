using Microsoft.Bot.Connector;

namespace NewsBot
{
    public class ConversationSaverFake : IConversationSaver
    {
        public bool SaveConversation(IMessageActivity activity)
        {
            var converstion = new ChatConversation()
            {
                ReceiverID = activity.From.Id,
                ReceiverName = activity.From.Name,
                SenderID = activity.Recipient.Id,
                SenderName = activity.Recipient.Name,
                ServiceUrl = activity.ServiceUrl,
                ChannelID = activity.ChannelId,
                ConversationId = activity.Conversation.Id
            };

            ConverstionStorageStub.ChatConverstions.Add(converstion);

            return true;
        }
    }
}