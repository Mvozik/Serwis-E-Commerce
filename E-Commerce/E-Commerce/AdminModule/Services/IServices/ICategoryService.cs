using E_Commerce.AdminModule.Dtos;
using E_Commerce.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.AdminModule.Services.IServices
{
    public interface ICategoryService
    {
        Task<List<Category>> GetCategoriesAsync();
        Task<List<SubCategory>> GetSubCategoriesAsync();
        Task<List<Section>> GetSectionsAsync();
        Task<List<Category>> GetCategoriesBySectionIdAsync(int id);

        Task<Section> AddSectionAsync(Section section);
        Task<SubCategory> AddSubCategoryAsync(PostSubCategoryDto postSubCategoryDto);
        Task<Category> AddCategoryAsync(PostCategoryDto postCategoryDto);

        Task<Section> DeleteSectionAsync(int id);
        Task<SubCategory> DeleteSubCategoryAsync(int id);
        Task<Category> DeleteCategoryAsync(int id);
    }
}
