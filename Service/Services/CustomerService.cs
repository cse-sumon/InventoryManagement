using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepo _customRepo;
        public CustomerService(ICustomerRepo customerRepo)
        {
            _customRepo = customerRepo;
        }
        public IEnumerable<CustomerViewModel> GetAllCustomers()
        {
            return _customRepo.GetAll();
        }

        public CustomerViewModel GetCustomer(int id)
        {
            return _customRepo.Get(id);
        }

        public void SaveCustomer(CustomerViewModel model)
        {
            _customRepo.Save(model);
        }

        public void UpdateCustomer(CustomerViewModel model)
        {
            _customRepo.Update(model);
        }

        public void DeleteCustomer(int id)
        {
            _customRepo.Delete(id);
        }
    }
}
