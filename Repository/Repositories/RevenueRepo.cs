using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Repository.Repositories
{
    public class RevenueRepo : IRevenueRepo
    {

        private readonly ApplicationContext _context;
        private readonly DbSet<Revenue> _entities;
        public RevenueRepo(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<Revenue>();
        }

        public IEnumerable<RevenueViewModel> GetAll()
        {
            try
            {
                var revenues = (from r in _entities
                                join c in _context.Customers on r.CustomerId equals c.CustomerId
                                select new RevenueViewModel
                                {
                                    RevenueId = r.RevenueId,
                                    Date = r.Date,
                                    CustomerId =c.CustomerId,
                                    CustomerName = c.CustomerName,
                                    PaymentMethod = r.PaymentMethod,
                                    Amount = r.Amount,
                                    Description = r.Description,
                                    InvoiceId = r.InvoiceId,
                                }).ToList();

                return revenues;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public RevenueViewModel Get(int id)
        {
            try
            {
                var revenue = (from r in _entities
                               where r.RevenueId == id
                               join c in _context.Customers on r.CustomerId equals c.CustomerId
                               select new RevenueViewModel
                               {
                                   RevenueId = r.RevenueId,
                                   Date = r.Date,
                                   CustomerId = c.CustomerId,
                                   CustomerName = c.CustomerName,
                                   PaymentMethod = r.PaymentMethod,
                                   Amount = r.Amount,
                                   Description = r.Description,
                                   InvoiceId = r.InvoiceId,
                               }).AsNoTracking().SingleOrDefault();

                return revenue;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        

        public void Save(RevenueViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Revenue");
                }

                Revenue revenue = new Revenue
                {
                    Date = model.Date,
                    CustomerId = model.CustomerId,
                    PaymentMethod = model.PaymentMethod,
                    Amount = model.Amount,
                    Description = model.Description,
                    InvoiceId = model.InvoiceId,
                };

                _entities.Add(revenue);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(RevenueViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Revenue");
                }

                Revenue revenue = new Revenue
                {
                    RevenueId = model.RevenueId,
                    Date = model.Date,
                    CustomerId = model.CustomerId,
                    PaymentMethod = model.PaymentMethod,
                    Amount = model.Amount,
                    Description = model.Description,
                    InvoiceId = model.InvoiceId,
                };

                _entities.Update(revenue);
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
                var revenue = _entities.Find(id);
                _entities.Remove(revenue);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
