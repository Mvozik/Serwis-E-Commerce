using E_Commerce.AdminModule.Dtos;
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
        public CategoryService(DataContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Category> AddCategoryAsync(PostCategoryDto postCategoryDto)
        {
            var section = await _dbContext.Sections.FirstOrDefaultAsync(x => x.Id == postCategoryDto.SectionId);
            if (section == null)
            {
                return null;
            }
            var response = await _dbContext.Categories.AddAsync(new Category { Name=postCategoryDto.Name,Section = section });
            await _dbContext.SaveChangesAsync();
            return response.Entity;
        }

        public Task<Section> AddSectionAsync(Section section)
        {
            throw new NotImplementedException();
        }

        public async Task<SubCategory> AddSubCategoryAsync(PostSubCategoryDto postSubCategoryDto)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == postSubCategoryDto.CategoryId);
            if(category==null)
            {
                return null;
            }
            var response = await _dbContext.SubCategories.AddAsync(new SubCategory { Name = postSubCategoryDto.Name, Category = category });
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
            return await _dbContext.Categories
                .Include(p=>p.SubCategories)
                .ToListAsync();
        }

        public async Task<List<Product>> GetProductsBySectionIdAsync(int id)
        {
            var section = await _dbContext.Sections.FirstOrDefaultAsync(x => x.Id == id);
            if(section==null)
            {
                return null;
            }
            var products = await _dbContext.Products.Where(x => x.SubCategory.Category.Section.Id == section.Id).ToListAsync();
            return products;
        }

        public async Task<List<Section>> GetSectionsAsync()
        {
            return await _dbContext.Sections
                .Include(p => p.Categories)
                .ThenInclude(p=>p.SubCategories)
                .ToListAsync();
        }

        public async Task<List<SubCategory>> GetSubCategoriesAsync()
        {
            return await _dbContext.SubCategories.ToListAsync();
        }
    }
}
