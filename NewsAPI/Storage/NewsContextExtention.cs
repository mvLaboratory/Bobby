using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPI.Storage
{
    public static class NewsContextExtention
    {
        public static void EnsureSeedDataForContext(this NewsContext context)
        {
            context.Database.EnsureCreated();

            if (context.categories.Any())
            {
                return;
            }

            var categories = new Category[]
            {
                new Category
                {
                    Name = "Category1", RssURL="http://111.com", CreationDate = DateTime.Now
                },
                new Category
                {
                    Name = "Category2", RssURL="http://222.com", CreationDate = DateTime.Now
                }
            };

            context.categories.AddRangeAsync(categories);
            context.SaveChangesAsync();
        }
    }
}
