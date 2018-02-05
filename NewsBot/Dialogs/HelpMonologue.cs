using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;

namespace NewsBot
{
    [Serializable]
    public class HelpMonologue : IDialog<object>
    {
        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            String responseText = "Help";
            await context.PostAsync(responseText);
            context.Wait(MessageReceivedAsync);
        }
    }
}