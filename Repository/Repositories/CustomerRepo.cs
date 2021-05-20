using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Repository.Repositories
{
    public class CustomerRepo : ICustomerRepo
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Customer> _entities;
        public CustomerRepo(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<Customer>();
        }


        public IEnumerable<CustomerViewModel> GetAll()
        {
            try
            {
                var customers = _entities.AsEnumerable();
                List<CustomerViewModel> customerVM = customers.Select(c => new CustomerViewModel
                {
                    CustomerId = c.CustomerId,
                    CustomerName = c.CustomerName,
                    Mobile = c.Mobile,
                    Email = c.Email,
                    Website = c.Website,
                    Address = c.Address,
                    Picture = c.Picture

                }).ToList();

                return customerVM;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public CustomerViewModel Get(int id)
        {
            try
            {
                var customer = _entities.AsNoTracking().Where(c => c.CustomerId == id).SingleOrDefault();
                if (customer == null)
                {
                    return null;
                }
                CustomerViewModel customerVM = new CustomerViewModel
                {
                    CustomerId = customer.CustomerId,
                    CustomerName = customer.CustomerName,
                    Mobile = customer.Mobile,
                    Email = customer.Email,
                    Website = customer.Website,
                    Address = customer.Address,
                    Picture = customer.Picture
                };
                return customerVM;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        

        public void Save(CustomerViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Customer");
                }
                Customer customer = new Customer
                {
                    CustomerName = model.CustomerName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    Website = model.Website,
                    Address = model.Address,
                    Picture = model.Picture
                };
                _entities.Add(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(CustomerViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Customer");
                }
                Customer customer = new Customer
                {
                    CustomerId = model.CustomerId,
                    CustomerName = model.CustomerName,
                    Mobile = model.Mobile,
                    Email = model.Email,
                    Website = model.Website,
                    Address = model.Address,
                    Picture = model.Picture
                };
                _entities.Update(customer);
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
                var customer = _entities.Find(id);
                _entities.Remove(customer);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
