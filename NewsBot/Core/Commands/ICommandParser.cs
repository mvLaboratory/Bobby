using System;

namespace NewsBot
{
    public interface ICommandParser
    {
        void ParseCommand(String commandName);

        ICommand GetCommand();
    }
}
