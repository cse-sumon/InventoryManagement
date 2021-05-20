using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Interfaces
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> GetAllProducts();
        ProductViewModel GetProduct(int id);
        void SaveProduct(ProductViewModel model);
        void UpdateProduct(ProductViewModel model);
        void DeleteProduct(int id);
        void ChangeStatus(int id);
    }
}
