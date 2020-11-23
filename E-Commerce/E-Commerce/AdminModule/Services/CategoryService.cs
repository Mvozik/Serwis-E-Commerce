using E_Commerce.AdminModule.Services.IServices;
using E_Commerce.Shared.Data;
using E_Commerce.Shared.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Commerce.AdminModule.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly DataContext _dbContext;
        CategoryService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddCategoryAsync(Category category)
        {
            var response = await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Section> AddSectionAsync(Section section)
        {
            var response = await _dbContext.Sections.AddAsync(section);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<SubCategory> AddSubCategoryAsync(SubCategory subCategory)
        {
            var response = await _dbContext.SubCategories.AddAsync(subCategory);
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }


        public async Task<Category> DeleteCategoryAsync(int id)
        {
            var entity = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(entity==null)
            {
                return null;
            }
            _dbContext.Categories.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Section> DeleteSectionAsync(int id)
        {
            var entity = await _dbContext.Sections.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            _dbContext.Sections.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<SubCategory> DeleteSubCategoryAsync(int id)
        {
            var entity = await _dbContext.SubCategories.FirstOrDefaultAsync(x => x.Id == id);
            if (entity == null)
            {
                return null;
            }
            _dbContext.SubCategories.Remove(entity);
            await _dbContext.SaveChangesAsync();
            return entity;
        }


        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<List<Section>> GetSectionsAsync()
        {
            return await _dbContext.Sections.ToListAsync();
        }

        public async Task<List<SubCategory>> GetSubCategoriesAsync()
        {
            return await _dbContext.SubCategories.ToListAsync();
        }
    }
}
