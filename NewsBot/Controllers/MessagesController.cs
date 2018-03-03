using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.Bot.Connector;
using Microsoft.Bot.Builder.Dialogs;
using System.Web.Http.Description;
using System.Net.Http;
using Unity.Attributes;
using System.Threading;

namespace NewsBot
{
    [BotAuthentication]
    public class MessagesController : ApiController
    {
        public MessagesController(IConversationSaver conversationSaver, ICommandFactory commandFactory, IMessageSender messageSender)
        {
            _conversationSaver = conversationSaver;
            _commandFactory = commandFactory;
            _messageSender = messageSender;
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
                await Conversation.SendAsync(activity, () => new NewsDialog(_commandFactory));
            }
            else
            {
                await HandleSystemMessage(activity);
            }
            return new HttpResponseMessage(System.Net.HttpStatusCode.Accepted);
        }

        private async Task<Activity> HandleSystemMessage(Activity message)
        {
            if (message.Type == ActivityTypes.DeleteUserData)
            {
                // Implement user deletion here
                // If we handle user deletion, return a real message
            }
            else if (message.Type == ActivityTypes.ConversationUpdate)
            {
                await _conversationSaver.SaveConversation(message);
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

            return null;
        }

        private ICommandFactory _commandFactory;
        private IConversationSaver _conversationSaver;
        private IMessageSender _messageSender;
        //SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);
    }
}