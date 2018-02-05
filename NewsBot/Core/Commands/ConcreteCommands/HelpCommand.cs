using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace NewsBot
{
    public class HelpCommand : ICommand
    {
        public String Name { get; } = "help";

        public async Task<bool> Execute(Activity activity, String args)
        {
            await Conversation.SendAsync(activity, () => new HelpMonologue());
            return true;
        }
    }
}