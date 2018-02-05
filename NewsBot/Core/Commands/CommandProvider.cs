using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewsBot
{
    public class CommandProvider : ICommandProvider
    {
        public IEnumerable<ICommand> GetCommands()
        {
            var type = typeof(ICommand);
            var test1 = AppDomain.CurrentDomain.GetAssemblies();
            var test2 = test1.SelectMany(s => s.GetTypes());
            var test3 = test2.Where(p => type.IsAssignableFrom(p)).ToList();

            return new List<ICommand>();
        }
    }
}