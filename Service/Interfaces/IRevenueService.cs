using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Interfaces
{
    public interface IRevenueService
    {
        IEnumerable<RevenueViewModel> GetAllRevenues();
        RevenueViewModel GetReveneue(int id);
        void SaveRevenue(RevenueViewModel model);
        void UpdateRevenue(RevenueViewModel model);
        void DeleteRevenue(int id);


    }
}
