using NewsAPI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPI.Storage
{
    public class NewsRepository : INewsRepository
    {
        public NewsRepository(NewsContext context)
        {
            _context = context;
        }

        public void AddCategory(Category model)
        {
            throw new NotImplementedException();
        }

        public void DeleteCategory(Category model)
        {
            throw new NotImplementedException();
        }

        public List<Category> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Category GetCategory()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category mode)
        {
            throw new NotImplementedException();
        }

        private NewsContext _context;
    }
}
