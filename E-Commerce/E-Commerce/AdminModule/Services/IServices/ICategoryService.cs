using E_Commerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.AdminModule.Services.IServices
{
    interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<SubCategory>> GetSubCategoriesAsync();
        Task<List<Section>> GetSectionsAsync();

        Task<Section> AddSectionAsync(Section section);
        Task<SubCategory> AddSubCategoryAsync(SubCategory subCategory);
        Task<Category> AddCategoryAsync(Category category);

        Task<Section> DeleteSectionAsync(int id);
        Task<SubCategory> DeleteSubCategoryAsync(int id);
        Task<Category> DeleteCategoryAsync(int id);
    }
}
