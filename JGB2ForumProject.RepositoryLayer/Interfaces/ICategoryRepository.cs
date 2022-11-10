using JGB2ForumProject.DataModels;
using System.Collections.Generic;

namespace JGB2ForumProject.RepositoryLayer
{
    public interface ICategoryRepository
    {
        void InsertCategory(Category c);
        void UpdateCategory(Category c); 
        void DeleteCategory(int cid);    
        List<Category> GetAllCategories();
        Category GetCategoryById(int cid);
    }
}
