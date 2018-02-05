using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPI
{
    public static class NewsStorageStub
    {
        public static List<INewsItem> News { get; set; }

        static NewsStorageStub()
        {
            var _cat1 = new Category("Category1", "url1");
            var _cat2 = new Category("Category2", "url2");

            var _item1 = new RssItem(DateTime.MinValue, "title1", "author1", "url1", _cat1);
            var _item2 = new RssItem(DateTime.Now, "title2", "author2", "url2", _cat2);
            var _item3 = new RssItem(DateTime.MaxValue, "title3", "author3", "url3", _cat1);
            News = new List<INewsItem> { _item1, _item2, _item3 };
        }
        
    }
}
