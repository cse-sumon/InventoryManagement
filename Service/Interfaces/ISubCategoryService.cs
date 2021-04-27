using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Interfaces
{
    public interface ISubCategoryService
    {
        IEnumerable<SubCategoryViewModel> GetAllSubCategories();
        IEnumerable<SubCategoryViewModel> GetByCategoryId(int id);
        SubCategoryViewModel GetSubCategory(int id);
        void SaveSubCategory(SubCategoryViewModel model);
        void UpdateSubCategory(SubCategoryViewModel model);
        void DeleteSubCategory(int id);
        void ChangeStatus(int id);
    }
}
