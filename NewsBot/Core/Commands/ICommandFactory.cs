using System;
using System.Collections.Generic;

namespace NewsBot
{
    public interface ICommandFactory
    {
        ICommand parseCommand(String commandName);
    }
}
