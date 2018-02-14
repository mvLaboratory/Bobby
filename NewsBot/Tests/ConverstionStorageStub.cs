using System.Collections.Generic;

namespace NewsBot
{
    public static class ConverstionStorageStub
    {
        public static List<ChatClient> ChatClients { get; set; } = new List<ChatClient>();

        public static List<ChatConversationStatus> ChatConverstionStatus { get; set; } = new List<ChatConversationStatus>();
    }
}