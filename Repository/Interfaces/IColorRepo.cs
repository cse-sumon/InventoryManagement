using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Repository.Interface
{
    public interface IColorRepo
    {
        IEnumerable<ColorViewModel> GetAll();
        ColorViewModel Get(int id);
        void Insert(ColorViewModel model);
        void Update(ColorViewModel model);
        void Delete(int id);
        void UpdateStatus(int id);


    }
}
