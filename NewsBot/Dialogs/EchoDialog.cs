using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;

namespace NewsBot
{
    [Serializable]
    public class EchoDialog : IDialog<object>
    {
        protected int count = 1;

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;

            if (message.Text == "reset")
            {
                PromptDialog.Confirm(
                    context,
                    AfterResetAsync,
                    "Are you sure you want to reset the count?",
                    "Didn't get that!",
                    promptStyle: PromptStyle.Auto);
            }
            else if(message.Text == "news")
            {
                StoreClient(message);
                await context.PostAsync("Got it! Expect news soon! )");
                context.Wait(MessageReceivedAsync);
            }
            else
            {
                String responseText = await GenerateResponse(message.Text);
                await context.PostAsync(responseText);
                context.Wait(MessageReceivedAsync);
                              
            }
        }

        public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        {
            var confirm = await argument;
            if (confirm)
            {
                this.count = 1;
                await context.PostAsync("Reset count.");
            }
            else
            {
                await context.PostAsync("Did not reset count.");
            }
            context.Wait(MessageReceivedAsync);
        }

        private async Task<String> GenerateResponse(String requestText)
        {
            return String.Format("Fuck, you said: {0}!!", requestText);
        }

        private void StoreClient(IMessageActivity clientMessage)
        {
            //TODO:: init in consttructor
            convSaver = new ConversationSaverFake();
            convSaver.SaveConversation(clientMessage);
        }

        [NonSerialized()]
        private IConversationSaver convSaver;
    }
}