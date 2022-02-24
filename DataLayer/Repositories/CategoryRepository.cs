using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Repositories
{
    public class CategoryRepository
    {
        NewsDbContext _ctx;
        public CategoryRepository(NewsDbContext ctx)
        {
            _ctx = ctx;
        }

        public List<Category> GetCategories()
        {
            return _ctx.Categories.ToList();
        }

        public Category GetCategoryById(int id)
        {
            return _ctx.Categories.FirstOrDefault(c => c.CategoryId == id);
        }

        public void AddOrUpdateCategory(Category category)
        {
            if (category.CategoryId <= 0)
            {
                _ctx.Categories.Add(category);
            }
            else
            {
                Category updated = GetCategoryById(category.CategoryId);
                updated.CategoryName = category.CategoryName;
            }
            _ctx.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            Category category = GetCategoryById(id);
            _ctx.Categories.Remove(category);
            _ctx.SaveChanges();
        }
    }
}
