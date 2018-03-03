using System;
using System.Globalization;
using System.Reflection;
using System.Resources;

namespace NewsBot
{
    public class TextFactory : ITextFactory
    {
        public string GetText(String constantName)
        {           
           return rm.GetString(constantName, CultureInfo.CurrentCulture);
        }

        private ResourceManager rm = new ResourceManager("NewsBot.Resources.BotText", Assembly.GetExecutingAssembly());
    }
}