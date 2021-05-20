using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interfaces
{
    public interface IProductRepo
    {
        IEnumerable<ProductViewModel> GetAll();
        ProductViewModel Get(int id);
        void Save(ProductViewModel model);
        void Update(ProductViewModel model);
        void Delete(int id);
        void ChangeStatus(int id);
    }
}
