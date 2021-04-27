using Microsoft.EntityFrameworkCore;
using Repository.Interfaces;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using ViewModel;

namespace Service.Services
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepo _subCategoryRepo;

        public SubCategoryService(ISubCategoryRepo subCategoryRepo)
        {
            _subCategoryRepo = subCategoryRepo;
        }


        public IEnumerable<SubCategoryViewModel> GetAllSubCategories()
        {
            return _subCategoryRepo.GetAll();
        }

        public IEnumerable<SubCategoryViewModel> GetByCategoryId(int id)
        {
            return _subCategoryRepo.GetByCategoryId(id);
        }

        public SubCategoryViewModel GetSubCategory(int id)
        {
            return _subCategoryRepo.Get(id);
        }

        public void SaveSubCategory(SubCategoryViewModel model)
        {
            _subCategoryRepo.Save(model);
        }

        public void UpdateSubCategory(SubCategoryViewModel model)
        {
            _subCategoryRepo.Update(model);
        }
       

        public void DeleteSubCategory(int id)
        {
            _subCategoryRepo.Delete(id);
        }

        public void ChangeStatus(int id)
        {
            _subCategoryRepo.ChangeStatus(id);
        }
    }
}
