using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPI
{
    public interface INewsSaver
    {
        bool SaveNewsItem(INewsItem itemForSave);
    }
}
