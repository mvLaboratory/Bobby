using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot
{
    public class ChatConversationStatus
    {
        public ChatClient Converstion {get; set;}
        public ConversationStatus Status { get; set; }

        public ChatConversationStatus(ChatClient converstion, ConversationStatus status)
        {
            Converstion = converstion;
            Status = status;
        }
    }
}