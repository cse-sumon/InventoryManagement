using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interfaces
{
    public interface ICategoryRepo
    {
        IEnumerable<CategoryViewModel> GetAll();
        CategoryViewModel Get(int id);
        void Save(CategoryViewModel model);
        void Update(CategoryViewModel model);
        void Delete(int id);
        void ChangeStatus(int id);
    }
}
