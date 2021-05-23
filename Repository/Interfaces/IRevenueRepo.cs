using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using ViewModel;

namespace Repository.Repositories
{
    public interface IRevenueRepo
    {
        IEnumerable<RevenueViewModel> GetAll();
        RevenueViewModel Get(int id);
        void Save(RevenueViewModel model);
        void Update(RevenueViewModel model);
        void Delete(int id);

    }
}
