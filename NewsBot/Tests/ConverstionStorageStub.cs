using System.Collections.Generic;

namespace NewsBot
{
    public static class ConverstionStorageStub
    {
        public static List<ChatClients> ChatClients { get; set; } = new List<ChatClients>();

        public static List<ChatConversationStatus> ChatConverstionStatus { get; set; } = new List<ChatConversationStatus>();
    }
}