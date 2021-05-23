using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using ViewModel;

namespace Repository.Repositories
{
    public class PaymentRepo : IPaymentRepo
    {

        private readonly ApplicationContext _context;
        private readonly DbSet<Payment> _entities;
        public PaymentRepo(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<Payment>();
        }


        public IEnumerable<PaymentViewModel> GetAll()
        {
            try
            {
                var payments = (from p in _entities
                                join c in _context.Customers on p.VendorId equals c.CustomerId
                                select new PaymentViewModel
                                {
                                    PaymentId = p.PaymentId,
                                    Date = p.Date,
                                    VendorId = c.CustomerId,
                                    VendorName = c.CustomerName,
                                    PaymentMethod = p.PaymentMethod,
                                    Amount = p.Amount,
                                    Description = p.Description,
                                    BillId = p.BillId,
                                }).ToList();

                return payments;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public PaymentViewModel Get(int id)
        {
            try
            {
                var payment = (from p in _entities
                               join c in _context.Customers on p.VendorId equals c.CustomerId
                               select new PaymentViewModel
                               {
                                   PaymentId = p.PaymentId,
                                   Date = p.Date,
                                   VendorId = c.CustomerId,
                                   VendorName = c.CustomerName,
                                   PaymentMethod = p.PaymentMethod,
                                   Amount = p.Amount,
                                   Description = p.Description,
                                   BillId = p.BillId,
                               }).AsNoTracking().SingleOrDefault();

                return payment;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       

        public void Save(PaymentViewModel model)
        {
            try
            {
                if (model == null)
                    throw new ArgumentNullException("Payment");

                Payment payment = new Payment
                {
                    Date = model.Date,
                    VendorId = model.VendorId,
                    PaymentMethod = model.PaymentMethod,
                    Amount = model.Amount,
                    Description = model.Description,
                    BillId = model.BillId
                };

                _entities.Add(payment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(PaymentViewModel model)
        {
            try
            {
                if (model == null)
                    throw new ArgumentNullException("Payment");

                Payment payment = new Payment
                {
                    PaymentId = model.PaymentId,
                    Date = model.Date,
                    VendorId = model.VendorId,
                    PaymentMethod = model.PaymentMethod,
                    Amount = model.Amount,
                    Description = model.Description,
                    BillId = model.BillId
                };

                _entities.Update(payment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Delete(int id)
        {
            try
            {
                var payment = _entities.Find(id);
                _entities.Remove(payment);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
