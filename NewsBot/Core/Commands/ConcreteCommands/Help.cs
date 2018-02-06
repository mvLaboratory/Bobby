using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsBot.Commands
{
    public class Help : CommandBase
    {
        public override String Name { get; } = "help";

        public override async Task<bool> Execute(Activity activity, String args)
        {
            await Conversation.SendAsync(activity, () => new HelpMonologue());
            return true;
        }
    }
}