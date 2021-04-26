using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepo _categoryRepo;
        public CategoryService(ICategoryRepo categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public IEnumerable<CategoryViewModel> GetAllCategories()
        {
            return _categoryRepo.GetAll();
        }

        public CategoryViewModel GetCategory(int id)
        {
            return _categoryRepo.Get(id);
        }

        public void SaveCategory(CategoryViewModel model)
        {
            _categoryRepo.Save(model);
        }

        public void UpdateCategory(CategoryViewModel model)
        {
            _categoryRepo.Update(model);
        }

      

        public void DeleteCategory(int id)
        {
            _categoryRepo.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            _categoryRepo.ChangeStatus(id);
        }
    }
}
