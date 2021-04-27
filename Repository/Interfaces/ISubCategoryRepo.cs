using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interfaces
{
    public interface ISubCategoryRepo
    {
        IEnumerable<SubCategoryViewModel> GetAll();
        IEnumerable<SubCategoryViewModel> GetByCategoryId(int id);
        SubCategoryViewModel Get(int id);
        void Save(SubCategoryViewModel model);
        void Update(SubCategoryViewModel model);
        void Delete(int id);
        void ChangeStatus(int id);
    }
}
