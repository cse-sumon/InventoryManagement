using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<CategoryViewModel> GetAllCategories();
        CategoryViewModel GetCategory(int id);
        void SaveCategory(CategoryViewModel model);
        void UpdateCategory(CategoryViewModel model);
        void DeleteCategory(int id);
        void ChangeStatus(int id);

    }
}
