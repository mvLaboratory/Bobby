using System.Collections.Generic;

namespace NewsBot
{
    public static class ConverstionStorageStub
    {
        public static List<ChatConversation> ChatConverstions { get; set; } = new List<ChatConversation>();
        public static List<ChatConversationStatus> ChatConverstionStatus { get; set; } = new List<ChatConversationStatus>();
    }
}