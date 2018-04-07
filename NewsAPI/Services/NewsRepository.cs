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
            return _context.categories.OrderBy(cat => cat.Name).ToList();
        }

        public Category GetCategory()
        {
            throw new NotImplementedException();
        }

        public void UpdateCategory(Category mode)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }

        private NewsContext _context;
    }
}
