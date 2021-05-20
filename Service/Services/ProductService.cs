using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        public ProductService(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public IEnumerable<ProductViewModel> GetAllProducts()
        {
            return _productRepo.GetAll();
        }

        public ProductViewModel GetProduct(int id)
        {
            return _productRepo.Get(id);
        }

        public void SaveProduct(ProductViewModel model)
        {
            _productRepo.Save(model);
        }

        public void UpdateProduct(ProductViewModel model)
        {
            _productRepo.Update(model);
        }

        public void DeleteProduct(int id)
        {
            _productRepo.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            _productRepo.ChangeStatus(id);
        }

        
    }
}
