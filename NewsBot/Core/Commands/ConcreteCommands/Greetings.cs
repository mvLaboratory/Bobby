using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NewsBot.Commands
{
    public class Greetings : CommandBase
    {
        public override String Name { get; } = "greetings";

        public override async Task<bool> Execute(IActivity activity, String args)
        {
            //await Conversation.SendAsync(activity, () => new GreetingsMonologue());
            return true;
        }
    }
}