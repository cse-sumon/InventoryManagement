using Microsoft.EntityFrameworkCore;
using Model;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;
using System.Linq;

namespace Repository.Repositories
{
    public class ColorRepo : IColorRepo
    {
        private readonly ApplicationContext _context;
        private DbSet<Color> _entities;

        public ColorRepo(ApplicationContext context)
        {
            _context = context;
            _entities = context.Set<Color>();
        }
        

        public IEnumerable<ColorViewModel> GetAll()
        {
            try
            {
                var colors = _entities.AsEnumerable();
                List<ColorViewModel> colorVM = colors.Select(c => new ColorViewModel
                {
                    Id = c.Id,
                    Code = c.Code,
                    Name = c.Name,
                    Description = c.Description,
                    IsActive = c.IsActive

                }).ToList();

                return colorVM;
            }
            catch (Exception ex)
            {

                throw;
            }
          
        }

        public ColorViewModel Get(int id)
        {
            try
            {
                var color = _entities.AsNoTracking().Where(c => c.Id == id).SingleOrDefault();
                if (color == null)
                {
                    return null;
                }
                ColorViewModel colorVM = new ColorViewModel
                {
                    Id = color.Id,
                    Code = color.Code,
                    Name = color.Name,
                    Description = color.Description,
                    IsActive = color.IsActive,
                };
                return colorVM;
            }
            catch (Exception ex)
            {

                throw;
            }
        }

       
        public void Insert(ColorViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("color");
                }
                Color color = new Color
                {
                    Code = model.Code,
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = model.IsActive,
                };
                _entities.Add(color);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void Update(ColorViewModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new ArgumentNullException("color");
                }
                Color color = new Color
                {   Id = model.Id,
                    Code = model.Code,
                    Name = model.Name,
                    Description = model.Description,
                    IsActive = model.IsActive,
                };
                _entities.Update(color);
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
                var color = _entities.Find(id);
                _entities.Remove(color);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        public void UpdateStatus(int id)
        {
            try
            {
                var color = _entities.Find(id);
                if (color.IsActive == true)
                    color.IsActive = false;
                else
                    color.IsActive = true;

                _entities.Update(color);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
