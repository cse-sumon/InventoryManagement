using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Services
{
    public class PaymentService : IPaymentService
    {

        private readonly IPaymentRepo _paymentRepo;
        public PaymentService(IPaymentRepo paymentRepo)
        {
            _paymentRepo = paymentRepo;
        }

        public IEnumerable<PaymentViewModel> GetAllPayments()
        {
            return _paymentRepo.GetAll();
        }

        public PaymentViewModel GetPayment(int id)
        {
            return _paymentRepo.Get(id);
        }

        public void SavePayment(PaymentViewModel model)
        {
            _paymentRepo.Save(model);
        }

        public void UpdatePayment(PaymentViewModel model)
        {
            _paymentRepo.Update(model);
        }

        public void Delete(int id)
        {
            _paymentRepo.Delete(id);
        }
    }
}
