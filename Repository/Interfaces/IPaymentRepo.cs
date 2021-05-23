using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interfaces
{
    public interface IPaymentRepo
    {
        IEnumerable<PaymentViewModel> GetAll();
        PaymentViewModel Get(int id);
        void Save(PaymentViewModel model);
        void Update(PaymentViewModel model);
        void Delete(int id);
    }
}
