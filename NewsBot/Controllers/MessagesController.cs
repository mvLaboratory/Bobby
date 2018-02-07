using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Http.Description;
using System.Net.Http;
using Unity.Attributes;
using System;

namespace NewsBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public MessagesController() : this (new CommandFactory())
        {
        }

        public MessagesController(ICommandFactory commandFactory)
        {
            _commandFactory = commandFactory;
        }

        /// <summary>
        /// POST: api/Messages
        /// </summary>
        /// <param name="activity"></param>
        [ResponseType(typeof(void))]
        public virtual async Task<HttpResponseMessage> Post([FromBody] Activity activity)
        {         
            if (activity != null && activity.GetActivityType() == ActivityTypes.Message)
            {
                //await Conversation.SendAsync(activity, () => new NewsDialog());
                String messageText = activity.Text;
                return await executeCommand(activity, messageText);
            }
            else
            {
                return await HandleSystemMessage(activity);
            }
            
        }

        private async Task<HttpResponseMessage> HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                return await executeCommand(message, "greetings");
            }
            else if (message.Type == ActivityTypes.ContactRelationUpdate)
            {
                // Handle add/remove from contact lists
                // Activity.From + Activity.Action represent what happened
            }
            else if (message.Type == ActivityTypes.Typing)
            {
                // Handle knowing tha the user is typing
            }
            else if (message.Type == ActivityTypes.Ping)
            {
            }

            return await executeCommand(message, "");
        }

        private async Task<HttpResponseMessage> executeCommand(Activity activity, String message)
        {
            var _command = _commandFactory.parseCommand(message);
            if (await _command.Execute(activity, message))
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
            }
            else
            {
                return new HttpResponseMessage(System.Net.HttpStatusCode.ExpectationFailed);
            }
        }

        private ICommandFactory _commandFactory;
    }
}