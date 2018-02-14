using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace NewsBot
{
    public class MessageSender : IMessageSender
    {
        public async Task<bool> SendMessage(ChatClient client, String messageText)
        {
            var userAccount = new ChannelAccount(client.ReceiverID, client.ReceiverName);
            var botAccount = new ChannelAccount(client.SenderID, client.SenderName);
            var connector = new ConnectorClient(new Uri(client.ServiceUrl));

            IMessageActivity message = Activity.CreateMessageActivity();
            if (!string.IsNullOrEmpty(client.ConversationId) && !string.IsNullOrEmpty(client.ChannelID))
            {
                message.ChannelId = client.ChannelID;
            }
            else
            {
                client.ConversationId = (await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount)).Id;
            }

            message.From = botAccount;
            message.Recipient = userAccount;
            message.Conversation = new ConversationAccount(id: client.ConversationId);
            message.Text = messageText;
            message.Locale = "en-us";
            await connector.Conversations.SendToConversationAsync((Activity)message);

            return true;
        }
    }
}