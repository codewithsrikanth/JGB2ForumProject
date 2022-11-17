using AutoMapper;
using JGB2ForumProject.DataModels;
using JGB2ForumProject.RepositoryLayer;
using JGB2ForumProject.RepositoryLayer.Implementation;
using JGB2ForumProject.ServiceLayer.Interfaces;
using JGB2ForumProject.ViewModels;
using System.Collections.Generic;

namespace JGB2ForumProject.ServiceLayer.Implementations
{
    public class CategoriesService:ICategoriesService
    {
        ICategoryRepository cr;

        public CategoriesService()
        {
            cr = new CategoryRepository();
        }

        public void InsertCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.InsertCategory(c);
        }

        public void UpdateCategory(CategoryViewModel cvm)
        {
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<CategoryViewModel, Category>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            Category c = mapper.Map<CategoryViewModel, Category>(cvm);
            cr.UpdateCategory(c);
        }

        public void DeleteCategory(int cid)
        {
            cr.DeleteCategory(cid);
        }

        public List<CategoryViewModel> GetCategories()
        {
            List<Category> c = cr.GetAllCategories();
            var config = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
            IMapper mapper = config.CreateMapper();
            List<CategoryViewModel> cvm = mapper.Map<List<Category>, List<CategoryViewModel>>(c);
            return cvm;
        }

        public CategoryViewModel GetCategoryByCategoryID(int CategoryID)
        {
            Category c = cr.GetCategoryById(CategoryID);
            CategoryViewModel cvm = null;
            if (c != null)
            {
                var config = new MapperConfiguration(cfg => { cfg.CreateMap<Category, CategoryViewModel>(); cfg.IgnoreUnmapped(); });
                IMapper mapper = config.CreateMapper();
                cvm = mapper.Map<Category, CategoryViewModel>(c);
            }
            return cvm;
        }
    }
}
