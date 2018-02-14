using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot
{
    public class ChatConversationStatus
    {
        public ChatClients Converstion {get; set;}
        public ConversationStatus Status { get; set; }

        public ChatConversationStatus(ChatClients converstion, ConversationStatus status)
        {
            Converstion = converstion;
            Status = status;
        }
    }
}