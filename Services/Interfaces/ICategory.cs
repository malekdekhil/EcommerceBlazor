using Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategory
    {
        Task<IEnumerable<Category>> GetAllCategoryAsync();
        ValueTask<Category> GetAllCategoryByIdAsync(int id);
        Task<Category> RemoveCategoryAsync(Category delCategory);
        Task<Category> CreateCategoryAsync(Category category);
        Task UpdateCategoryAsync(Category currentCategory, Category newCategory);
    }
}
