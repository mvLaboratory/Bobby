using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Web;

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