using System;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Net.Http;

namespace NewsBot
{
    [Serializable]
    public class NewsDialog : IDialog<object>
    {
        public NewsDialog(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        public async Task StartAsync(IDialogContext context)
        {
            context.Wait(MessageReceivedAsync);
        }

        public async Task MessageReceivedAsync(IDialogContext context, IAwaitable<IMessageActivity> argument)
        {
            var message = await argument;
            var command = _commandFactory.parseCommand(message.Text);
            await command.Execute(context.Activity);
            //if (message.Text == "reset")
            //{
            //    PromptDialog.Confirm(
            //        context,
            //        AfterResetAsync,
            //        "Are you sure you want to reset the count?",
            //        "Didn't get that!",
            //        promptStyle: PromptStyle.Auto);
            //}
            //else if(message.Text == "news")
            //{
            //    StoreClient(message);
            //    await context.PostAsync("Got it! Expect news soon! )");
            //    context.Wait(MessageReceivedAsync);
            //}
            //else
            //{
            //    String responseText = await GenerateResponse(message.Text);
            //    await context.PostAsync(responseText);
            //    context.Wait(MessageReceivedAsync);

            //}
        }

        //public async Task AfterResetAsync(IDialogContext context, IAwaitable<bool> argument)
        //{
        //    var confirm = await argument;
        //    if (confirm)
        //    {
        //        await context.PostAsync("Reset count.");
        //    }
        //    else
        //    {
        //        await context.PostAsync("Did not reset count.");
        //    }
        //    context.Wait(MessageReceivedAsync);
        //}

        //private async Task<String> GenerateResponse(String requestText)
        //{
        //    return String.Format("Fuck, you said: {0}!!", requestText);
        //}

        private ICommandFactory _commandFactory;
    }
}