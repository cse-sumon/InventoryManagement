using Repository.Interface;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Services
{
    public class ColorService : IColorService
    {
        private readonly IColorRepo _colorRepo;
        public ColorService(IColorRepo colorRepo)
        {
            _colorRepo = colorRepo;
        }

        public IEnumerable<ColorViewModel> GetAllColors()
        {
           return  _colorRepo.GetAll();
        }

        public ColorViewModel GetColor(int id)
        {
            return _colorRepo.Get(id);
        }

        public void InsertColor(ColorViewModel model)
        {
             _colorRepo.Insert(model);
        }

        public void UpdateColor(ColorViewModel model)
        {
             _colorRepo.Update(model);
        }

        public void DeleteColor(int id)
        {
             _colorRepo.Delete(id);
        }

        public void UpdateStatus(int id)
        {
             _colorRepo.UpdateStatus(id);
        }
    }
}
