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
    public class RevenueController : ControllerBase
    {
        private readonly IRevenueService _revenueService;
        public RevenueController(IRevenueService revenueService)
        {
            _revenueService = revenueService;
        }
        // GET: api/<RevenueController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_revenueService.GetAllRevenues());
            }
            catch (Exception ex)
            {
                throw;
            }
          
        }

        // GET api/<RevenueController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var revenue = _revenueService.GetReveneue(id);
                if (revenue == null)
                    return NotFound();

                return Ok(revenue);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // POST api/<RevenueController>
        [HttpPost]
        public IActionResult Post(RevenueViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _revenueService.SaveRevenue(model);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

        // PUT api/<RevenueController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, RevenueViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.RevenueId != id)
                    return BadRequest();

                var revenue = _revenueService.GetReveneue(id);
                if (revenue == null)
                    return NotFound();
                _revenueService.UpdateRevenue(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<RevenueController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var revenue = _revenueService.GetReveneue(id);
                if (revenue == null)
                    return NotFound();
                _revenueService.DeleteRevenue(id);
                return NoContent();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
