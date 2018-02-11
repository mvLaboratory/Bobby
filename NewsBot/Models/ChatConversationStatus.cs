using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot
{
    public class ChatConversationStatus
    {
        public ChatConversation Converstion {get; set;}
        public ConversationStatus Status { get; set; }

        public ChatConversationStatus(ChatConversation converstion, ConversationStatus status)
        {
            Converstion = converstion;
            Status = status;
        }
    }
}