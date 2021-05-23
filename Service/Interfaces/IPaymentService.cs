using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Interfaces
{
    public interface IPaymentService
    {
        IEnumerable<PaymentViewModel> GetAllPayments();
        PaymentViewModel GetPayment(int id);
        void SavePayment(PaymentViewModel model);
        void UpdatePayment(PaymentViewModel model);
        void Delete(int id);
    }
}
