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
    public class CategoryRepo : ICategoryRepo
    {
        private readonly ApplicationContext _context;
        private readonly DbSet<Category> _entities;
        public CategoryRepo(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<Category>();
        }
        
        public IEnumerable<CategoryViewModel> GetAll()
        {
            try
            {
                var categories = _entities.AsEnumerable();
                List<CategoryViewModel> categoryVM = categories.Select(c => new CategoryViewModel {

                    Id = c.Id,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive

                }).ToList();

                return categoryVM;

            }
            catch (Exception)
            {

                throw;
            }
        }

        public CategoryViewModel Get(int id)
        {
            try
            {
                var category = _entities.AsNoTracking().Where(c => c.Id == id).SingleOrDefault();
                if (category == null) return null;

                CategoryViewModel categoryVM = new CategoryViewModel
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description,
                    IsActive = category.IsActive,
                };

                return categoryVM;
            }
            catch (Exception)
            {

                throw;
            }
        }

        

        public void Save(CategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Category");
                }

                Category category = new Category
                {
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = model.IsActive
                };

                _entities.Add(category);
                _context.SaveChanges();

            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Update(CategoryViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("Category");
                }

                Category category = new Category
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = model.IsActive
                };

                _entities.Update(category);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }


        public void Delete(int id)
        {
            try
            {
                var category = _entities.Find(id);
                _entities.Remove(category);
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void ChangeStatus(int id)
        {
            var category = _entities.Find(id);
            if (category.IsActive == true)
                category.IsActive = false;
            else
                category.IsActive = true;

            _entities.Update(category);
            _context.SaveChanges();
        }


    }
}
