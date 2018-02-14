using Microsoft.Bot.Connector;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace NewsBot
{
    public class ConversationSaverFake : IConversationSaver
    {
        public async Task<bool> SaveConversation(IMessageActivity activity, SemaphoreSlim _semaphoreSlim)
        {
            var client = new ChatClients()
            {
                ReceiverID = activity.From.Id,
                ReceiverName = activity.From.Name,
                SenderID = activity.Recipient.Id,
                SenderName = activity.Recipient.Name,
                ServiceUrl = activity.ServiceUrl,
                ChannelID = activity.ChannelId,
                ConversationId = activity.Conversation.Id
            };

            await _semaphoreSlim.WaitAsync();
            try
            {
                if (!ConverstionStorageStub.ChatClients.Any(conv => conv.ReceiverID.Equals(client.ReceiverID) || conv.SenderID.Equals(client.ReceiverID)))
                {
                    ConverstionStorageStub.ChatClients.Add(client);

                    var convStatus = new ChatConversationStatus(client, ConversationStatus.New);
                    ConverstionStorageStub.ChatConverstionStatus.Add(convStatus);
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
            return true;
        }
    }
}