using Domains;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitOfWorkManager;

namespace Services.Implementations
{
    public class ClsCategory : ICategory
    {
        private readonly IUnitOfWork unitOfWork;
        public ClsCategory(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public async Task<Category> CreateCategoryAsync(Category category)
        {
            await unitOfWork.Categories.AddAsync(category);
            await unitOfWork.CommitAsync();
            return category;
        }

        public async Task<IEnumerable<Category>> GetAllCategoryAsync()
        {
            return await unitOfWork.Categories.GetAllAsync();

        }

        public async ValueTask<Category> GetAllCategoryByIdAsync(int id)
        {
            return await unitOfWork.Categories.GetByIdAsync(id);
        }

        public async Task<Category> RemoveCategoryAsync(Category delCategory)
        {
               unitOfWork.Categories.Remove(delCategory);
            await unitOfWork.CommitAsync();
            return delCategory;
        }

        public async  Task UpdateCategoryAsync(Category currentCategory, Category newCategory)
        {
             currentCategory.CategoryName = newCategory.CategoryName;
            currentCategory.Description = newCategory.Description;
            currentCategory.SeoNameCategory = newCategory.SeoNameCategory;
 
            await unitOfWork.CommitAsync();
        }
    }
}
