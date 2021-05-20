using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ViewModel;

namespace Repository.Repositories
{
    public class ProductRepo : IProductRepo
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Product> _entities;
        public ProductRepo(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<Product>();
        }


        public IEnumerable<ProductViewModel> GetAll()
        {
            try
            {
                var products = (from p in _entities
                                join c in _context.Categories on p.CategoryId equals c.Id
                                join sc in _context.SubCategories on p.SubCategoryId equals sc.Id
                                select new ProductViewModel
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    Description = p.Description,
                                    PurchasePrice = p.PurchasePrice,
                                    SalePrice = p.SalePrice,
                                    Picture = p.Picture,
                                    IsActive = p.IsActive,
                                    CategoryId = c.Id,
                                    CategoryName = c.Name,
                                    SubCategoryId = sc.Id,
                                    SubCategoryName = sc.Name

                                }).ToList();

                return products;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public ProductViewModel Get(int id)
        {
            try
            {
                var product = (from p in _entities
                               where p.Id == id
                               join c in _context.Categories on p.CategoryId equals c.Id
                               join sc in _context.SubCategories on p.SubCategoryId equals sc.Id
                               select new ProductViewModel
                               {
                                   Id = p.Id,
                                   Name = p.Name,
                                   Description = p.Description,
                                   PurchasePrice = p.PurchasePrice,
                                   SalePrice = p.SalePrice,
                                   Picture = p.Picture,
                                   CategoryId = c.Id,
                                   CategoryName = c.Name,
                                   SubCategoryId = sc.Id,
                                   SubCategoryName = sc.Name

                               }).AsNoTracking().SingleOrDefault();

                if (product == null)
                    return null;

                return product;
            }
            catch (Exception ex)
            {
                throw;
            }
        }


        public void Save(ProductViewModel model)
        {
            try
            {
                if(model==null)
                {
                    throw new ArgumentNullException("Product");
                }

                Product product = new Product
                {
                    Name = model.Name,
                    Description =model.Description,
                    PurchasePrice = model.PurchasePrice,
                    SalePrice = model.SalePrice,
                    Picture = model.Picture,
                    IsActive = model.IsActive,
                    CategoryId = model.CategoryId,
                    SubCategoryId = model.SubCategoryId
                };

                _entities.Add(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void Update(ProductViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Product");
                }

                Product product = new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    PurchasePrice = model.PurchasePrice,
                    SalePrice = model.SalePrice,
                    Picture = model.Picture,
                    IsActive = model.IsActive,
                    CategoryId = model.CategoryId,
                    SubCategoryId = model.SubCategoryId
                };
                _entities.Update(product);
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
                var product = _entities.Find(id);
                _entities.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void ChangeStatus(int id)
        {
            try
            {
                var product = _entities.Find(id);
                if (product.IsActive == true)
                    product.IsActive = false;
                else
                    product.IsActive = true;

                _entities.Update(product);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        
    }
}
