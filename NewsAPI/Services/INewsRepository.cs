using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsAPI.Services
{
    public interface INewsRepository
    {
        List<Category> GetCategories();
        Category GetCategory();
        void AddCategory(Category model);
        void UpdateCategory(Category mode);
        void DeleteCategory(Category model);

        Boolean Save();
    }
}
