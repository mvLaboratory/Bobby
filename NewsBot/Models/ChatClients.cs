using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot
{
    [Serializable]
    public class ChatClients
    {
        public String ReceiverID { get; set; }
        public String ReceiverName { get; set; }
        public String SenderID { get; set; }
        public String SenderName { get; set; }
        public String ServiceUrl { get; set; }
        public String ChannelID { get; set; }
        public String ConversationId { get; set; }

        public ChatClients()
        {

        }
    }
}