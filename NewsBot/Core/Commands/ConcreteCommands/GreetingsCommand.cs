using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace NewsBot
{
    public class GreetingsCommand : ICommand
    {
        public String Name { get; } = "greetings";

        public async Task<bool> Execute(Activity activity, String args)
        {
            await Conversation.SendAsync(activity, () => new GreetingsMonologue());
            return true;
        }
    }
}