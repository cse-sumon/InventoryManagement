using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Interfaces
{
    public interface ICustomerService
    {
        IEnumerable<CustomerViewModel> GetAllCustomers();
        CustomerViewModel GetCustomer(int id);
        void SaveCustomer(CustomerViewModel model);
        void UpdateCustomer(CustomerViewModel model);
        void DeleteCustomer(int id);

    }
}
