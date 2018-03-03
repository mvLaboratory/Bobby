using Microsoft.Bot.Connector;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Unity;

namespace NewsBot
{
    public class ConversationSaverFake : IConversationSaver
    {
        public ConversationSaverFake(IMessageSender messageSender)
        {
            _messageSender = messageSender;
            _semaphoreSlim = UnityConfig.Container.Resolve<SemaphoreSlim>("semafore");
        }

        public async Task<bool> SaveConversation(IMessageActivity activity)
        {
            var client = new ChatClient()
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

                    await _messageSender.SendMessage(client, "Greeting");
                }
            }
            finally
            {
                _semaphoreSlim.Release();
            }
            return true;
        }

        private SemaphoreSlim _semaphoreSlim;
        private IMessageSender _messageSender;
    }
}