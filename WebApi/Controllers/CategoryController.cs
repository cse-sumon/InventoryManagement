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
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        // GET: api/<CategoryController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_categoryService.GetAllCategories());
            }
            catch (Exception)
            {

                throw;
            }
        }

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var category = _categoryService.GetCategory(id);
                if (category == null)
                {
                    return NotFound();
                }

                return Ok(category);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST api/<CategoryController>
        [HttpPost]
        public IActionResult Post(CategoryViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _categoryService.SaveCategory(model);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<CategoryController>/5
        [HttpPut("{id}")]
        public IActionResult Put(CategoryViewModel model, int id)
        {
            try
            {
                if (!ModelState.IsValid || model.Id != id)
                    return BadRequest();

                var category = _categoryService.GetCategory(id);
                if (category == null)
                    return NotFound();

                _categoryService.UpdateCategory(model);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // DELETE api/<CategoryController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var category = _categoryService.GetCategory(id);
                if (category == null)
                    return NotFound();

                _categoryService.DeleteCategory(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }


        [HttpGet("ChangeStatus")]
        public IActionResult ChangeStatus(int id)
        {
            try
            {
                _categoryService.ChangeStatus(id);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
