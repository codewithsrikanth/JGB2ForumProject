using JGB2ForumProject.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace JGB2ForumProject.RepositoryLayer.Implementation
{
    public class CategoryRepository : ICategoryRepository
    {
        JGB2ForumDBContext _dbContext;
        public CategoryRepository()
        {
            _dbContext = new JGB2ForumDBContext();
        }

        public void DeleteCategory(int cid)
        {           
            Category category = _dbContext.Categories.Where(x=>x.CategoryID == cid).FirstOrDefault();
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
        }

        public List<Category> GetAllCategories()
        {
            return _dbContext.Categories.ToList();
        }

        public Category GetCategoryById(int cid)
        {
            return _dbContext.Categories.Find(cid);
        }

        public void InsertCategory(Category c)
        {
            _dbContext.Categories.Add(c);
            _dbContext.SaveChanges();
        }

        public void UpdateCategory(Category c)
        {
            Category category = _dbContext.Categories.Where(x => x.CategoryID == c.CategoryID).FirstOrDefault();
            category.CategoryName = c.CategoryName;
            _dbContext.SaveChanges();
        }
    }
}
