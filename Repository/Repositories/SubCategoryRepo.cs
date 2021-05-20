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
    public class SubCategoryRepo : ISubCategoryRepo
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<SubCategory> _entities;
        public SubCategoryRepo(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<SubCategory>();
        }
      

        public IEnumerable<SubCategoryViewModel> GetAll()
        {
            try
            {
                var subCategories = (from sc in _entities
                                    join c in _context.Categories
                                    on sc.CategoryId equals c.Id
                                    select new SubCategoryViewModel
                                    {
                                        Id = sc.Id,
                                        Name = sc.Name,
                                        Description = sc.Description,
                                        IsActive = sc.IsActive,
                                        CategoryId = c.Id,
                                        CategoryName = c.Name,
                                    }).ToList();

                return subCategories;
            }
            catch (Exception ex)
            {

                throw;
            }
        }



        public IEnumerable<SubCategoryViewModel> GetByCategoryId(int id)
        {
            try
            {
                var subCategories = (from sc in _entities
                                     where sc.CategoryId == id && sc.IsActive == true
                                     join c in _context.Categories
                                     on sc.CategoryId equals c.Id
                                     select new SubCategoryViewModel
                                     {
                                         Id = sc.Id,
                                         Name = sc.Name,
                                         Description = sc.Description,
                                         IsActive = sc.IsActive,
                                         CategoryId = c.Id,
                                         CategoryName = c.Name,
                                     }).ToList();

                

                if (subCategories == null)
                    return null;

                return subCategories;
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        public SubCategoryViewModel Get(int id)
        {
            try
            {
                var subCategory = (from sc in _entities
                                where sc.Id == id
                                join c in _context.Categories
                                on sc.CategoryId equals c.Id
                                select new SubCategoryViewModel
                                {
                                    Id = sc.Id,
                                    Name = sc.Name,
                                    Description = sc.Description,
                                    IsActive = sc.IsActive,
                                    CategoryId = c.Id,
                                    CategoryName = c.Name,
                                }).AsNoTracking().SingleOrDefault();

                if (subCategory == null) 
                    return null;

                return subCategory;
            }
            catch (Exception ex)
            {

                throw;
            }
        }




        public void Save(SubCategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Sub Category");
                }

                var subCategory = new SubCategory
                {
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    IsActive = model.IsActive
                };

                _entities.Add(subCategory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(SubCategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Sub Category");
                }

                var subCategory = new SubCategory
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    CategoryId = model.CategoryId,
                    IsActive = model.IsActive
                };

                _entities.Update(subCategory);
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
                var subCategory = _entities.Find(id);
                _entities.Remove(subCategory);
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
                var subCategory = _entities.Find(id);
                if (subCategory.IsActive == true)
                    subCategory.IsActive = false;
                else
                    subCategory.IsActive = true;

                _entities.Update(subCategory);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
