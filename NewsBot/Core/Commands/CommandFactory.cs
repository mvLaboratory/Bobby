using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NewsBot.Commands;
using System.Web;

namespace NewsBot
{
    public class CommandFactory : ICommandFactory
    {
        public CommandFactory()
        {
            findAllCommands();
        }

        public ICommand parseCommand(String commandName)
        {
            var preparedComName = commandName.Trim().ToLower();
            ICommand result = new Help();
            if (_availableTypes.ContainsKey(preparedComName))
            {
                Type concreteCommandType = _availableTypes[preparedComName];
                result = (ICommand) Activator.CreateInstance(concreteCommandType);
            }
            return result;
        }

        private void findAllCommands()
        {
            _availableTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(someType => someType.GetInterface(typeof(ICommand).ToString()) != null)
                .ToDictionary(commandType => commandType.Name.ToLower(), commandType => commandType);

        }

        private IDictionary<String, Type> _availableTypes;
    }
}