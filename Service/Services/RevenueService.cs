using Repository.Repositories;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Services
{
    public class RevenueService : IRevenueService
    {
        private readonly IRevenueRepo _revenueRepo;
        public RevenueService(IRevenueRepo revenueRepo)
        {
            _revenueRepo = revenueRepo;
        }
        public IEnumerable<RevenueViewModel> GetAllRevenues()
        {
            return _revenueRepo.GetAll();
        }

        public RevenueViewModel GetReveneue(int id)
        {
            return _revenueRepo.Get(id);
        }

        public void SaveRevenue(RevenueViewModel model)
        {
            _revenueRepo.Save(model);
        }

        public void UpdateRevenue(RevenueViewModel model)
        {
            _revenueRepo.Update(model);
        }

        public void DeleteRevenue(int id)
        {
            _revenueRepo.Delete(id);
        }

    }
}
