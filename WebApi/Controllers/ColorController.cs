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
    public class ColorController : ControllerBase
    {
        private readonly IColorService _colorServce;
        public ColorController(IColorService colorService)
        {
            _colorServce = colorService;
        }


        // GET: api/<ColorController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                 return Ok(_colorServce.GetAllColors());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET api/<ColorController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var color = _colorServce.GetColor(id);
                if (color == null)
                {
                    return NotFound();
                }

                return Ok(color);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // POST api/<ColorController>
        [HttpPost]
        public IActionResult Post(ColorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _colorServce.InsertColor(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/<ColorController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, ColorViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.Id != id)
                    return BadRequest();

                var color = _colorServce.GetColor(id);

                if (color == null)
                    return NotFound();

                _colorServce.UpdateColor(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<ColorController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var color = _colorServce.GetColor(id);
                if (color == null)
                    return NotFound();

                _colorServce.DeleteColor(id);
                return NoContent();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        [HttpGet]
        [Route("UpdateStatus/{id}")]
        public IActionResult UpdateStatus(int id)
        {
            try
            {
                _colorServce.UpdateStatus(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

            
        }
    }
}
