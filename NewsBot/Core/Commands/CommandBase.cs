using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Bot.Connector;

namespace NewsBot.Commands 
{
    public abstract class CommandBase : ICommand
    {
        public abstract string Name { get; }

        public abstract Task<bool> Execute(IActivity activity, string args);

        public override bool Equals(object obj)
        {
            var @base = obj as CommandBase;
            return @base != null &&
                   Name == @base.Name;
        }

        public override int GetHashCode()
        {
            return 539060726 + EqualityComparer<string>.Default.GetHashCode(Name);
        }
    }
}