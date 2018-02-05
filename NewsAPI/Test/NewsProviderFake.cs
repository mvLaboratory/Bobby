using System;
using System.Collections.Generic;

namespace NewsAPI
{
    public class NewsProviderFake : INewsProvider
    {
        public IEnumerable<INewsItem> GetNewsItems()
        {
            return NewsStorageStub.News;
        }
    }
}
