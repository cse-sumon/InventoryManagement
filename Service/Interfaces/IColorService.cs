using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Interfaces
{
    public interface IColorService
    {
        IEnumerable<ColorViewModel> GetAllColors();
        ColorViewModel GetColor(int id);
        void InsertColor(ColorViewModel model);
        void UpdateColor(ColorViewModel model);
        void DeleteColor(int id);
        void UpdateStatus(int id);
    }
}
