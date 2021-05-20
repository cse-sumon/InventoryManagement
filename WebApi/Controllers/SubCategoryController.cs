using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }


        // GET: api/<SubCategoryController>
        [HttpGet("GetAllSubCategories")]
        public IActionResult GetAllSubCategories()
        {
            try
            {
                return Ok(_subCategoryService.GetAllSubCategories());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET: api/<SubCategoryController>/GetByCategoryId/5
        [HttpGet("GetByCategoryId/{id}")]
        public IActionResult GetByCategoryId(int id)
        {
            try
            {
                var subCategory = _subCategoryService.GetByCategoryId(id);
                if (subCategory == null)
                    return NotFound();

                return Ok(subCategory);
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        // GET api/<SubCategoryController>/5
        [HttpGet("GetSubCategory/{id}")]
        public IActionResult GetSubCategory(int id)
        {
            try
            {
                var subCategory = _subCategoryService.GetSubCategory(id);
                if (subCategory == null)
                    return NotFound();

                return Ok(subCategory);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // POST api/<SubCategoryController>
        [HttpPost]
        public IActionResult Post(SubCategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();
                _subCategoryService.SaveSubCategory(model);

                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/<SubCategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, SubCategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.Id != id)
                    return BadRequest();

                var subCategory = _subCategoryService.GetSubCategory(id);
                if (subCategory == null)
                    return NotFound();

                _subCategoryService.UpdateSubCategory(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<SubCategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var subCategory = _subCategoryService.GetSubCategory(id);
                if (subCategory == null)
                    return NotFound();

                _subCategoryService.DeleteSubCategory(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET api/<SubCategoryController>/ChangeStatus/5
        [HttpGet("ChangeStatus/{id}")]
        public IActionResult ChangeStatus(int id)
        {
            try
            {
                _subCategoryService.ChangeStatus(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
