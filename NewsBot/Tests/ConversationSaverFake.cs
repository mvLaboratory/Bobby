using Microsoft.Bot.Connector;
using System.Linq;
using System.Threading.Tasks;

namespace NewsBot
{
    public class ConversationSaverFake : IConversationSaver
    {
        public async Task<bool> SaveConversation(IMessageActivity activity)
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


            if (!ConverstionStorageStub.ChatConverstions.Any(conv => conv.ReceiverID.Equals(converstion.ReceiverID) || conv.SenderID.Equals(converstion.ReceiverID)))
            {
                ConverstionStorageStub.ChatConverstions.Add(converstion);

                var convStatus = new ChatConversationStatus(converstion, ConversationStatus.New);
                ConverstionStorageStub.ChatConverstionStatus.Add(convStatus);
            }

            return true;
        }
    }
}