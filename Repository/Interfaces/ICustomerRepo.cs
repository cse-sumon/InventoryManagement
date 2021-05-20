using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Repositories
{
    public interface ICustomerRepo
    {
        IEnumerable<CustomerViewModel> GetAll();
        CustomerViewModel Get(int id);
        void Save(CustomerViewModel model);
        void Update(CustomerViewModel model);
        void Delete(int id);
    }
}
