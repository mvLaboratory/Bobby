﻿
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsBot
{
    public class GlobalRoutine
    {
        public GlobalRoutine(IMessageSender messageSender, IConversationClientsListProvider conversationClientsProvider)
        {
            _messageSender = messageSender;
            _conversationClientsProvider = conversationClientsProvider;
        }

        public Task Run()
        {
            return NewsRoutine();
        }

        private async Task NewsRoutine()
        {
            List<ChatClient> chatClients = _conversationClientsProvider.GetClietns();
            while (false)
            {
                await Task.Delay(100000);

                foreach (var client in chatClients)
                {
                    var userAccount = new ChannelAccount(client.ReceiverID, client.ReceiverName);
                    var botAccount = new ChannelAccount(client.SenderID, client.SenderName);
                    var connector = new ConnectorClient(new Uri(client.ServiceUrl));

                    // Create a new message.
                    IMessageActivity message = Activity.CreateMessageActivity();
                    if (!string.IsNullOrEmpty(client.ConversationId) && !string.IsNullOrEmpty(client.ChannelID))
                    {
                        // If conversation ID and channel ID was stored previously, use it.
                        message.ChannelId = client.ChannelID;
                    }
                    else
                    {
                        // Conversation ID was not stored previously, so create a conversation. 
                        // Note: If the user has an existing conversation in a channel, this will likely create a new conversation window.
                        client.ConversationId = (await connector.Conversations.CreateDirectConversationAsync(botAccount, userAccount)).Id;
                    }

                    // Set the address-related properties in the message and send the message.
                    message.From = botAccount;
                    message.Recipient = userAccount;
                    message.Conversation = new ConversationAccount(id: client.ConversationId);
                    message.Text = "Good news everyone";
                    message.Locale = "en-us";
                    await connector.Conversations.SendToConversationAsync((Activity)message);
                }
            }

           // List<ChatConversationStatus> clientStatuses = _conversationClientsProvider.Get;
        }

        IMessageSender _messageSender;
        IConversationClientsListProvider _conversationClientsProvider;
    }
}