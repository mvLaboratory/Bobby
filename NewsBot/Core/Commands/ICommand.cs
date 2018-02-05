using Microsoft.Bot.Connector;
using System;
using System.Threading.Tasks;

namespace NewsBot
{
    public interface ICommand
    {
        String Name { get; }

        Task<bool> Execute(Activity activity, String args);
    }
}