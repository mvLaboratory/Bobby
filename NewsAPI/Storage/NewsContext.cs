using Microsoft.EntityFrameworkCore;

namespace NewsAPI.Storage
{
    public class NewsContext : DbContext {
        public NewsContext(DbContextOptions<NewsContext> options): base(options)
        {

        }

        public DbSet<Category> categories { get; set; }
        public DbSet<RssItem> news { get; set; }
    }
}
