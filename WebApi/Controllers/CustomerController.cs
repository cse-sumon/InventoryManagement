using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ViewModel;
using WebApi.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomerController(ICustomerService customerService, IWebHostEnvironment webHostEnvironment)
        {
            _customerService = customerService;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_customerService.GetAllCustomers());
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var customer = _customerService.GetCustomer(id);
                if (customer == null)
                {
                    return NotFound();
                }
                return Ok(customer);

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // POST api/<CustomerController>
        [HttpPost]
        public IActionResult Post([FromForm] CustomerViewModel model)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                if (model.FormFile != null)
                {
                    var fileType = (Path.GetExtension(model.FormFile.FileName)).ToLower();
                    if (fileType != ".jpg" && fileType != ".png")
                        return BadRequest();

                    var fileName = Path.GetFileName(model.FormFile.FileName.Replace(" ", "_"));
                    var uniqueFileName = Helper.GetUniqueFileName(fileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads/Customer_Images");
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    FileStream s = new FileStream(filePath, FileMode.Create);
                    model.FormFile.CopyTo(s);
                    model.Picture = filePath;

                    s.Close();
                    s.Dispose();

                }

                _customerService.SaveCustomer(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm]CustomerViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.CustomerId != id)
                    return BadRequest();

                var customer = _customerService.GetCustomer(id);
                if (customer == null)
                    return NotFound();

                if (model.FormFile != null)
                {
                    var fileType = (Path.GetExtension(model.FormFile.FileName)).ToLower();
                    if (fileType != ".jpg" && fileType != ".png")
                        return BadRequest();

                    var oldImage = model.Picture;
                    var fileName = Path.GetFileName(model.FormFile.FileName.Replace(" ", "_"));
                    var uniqueFileName = Helper.GetUniqueFileName(fileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads/Customer_Images");
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    FileStream s = new FileStream(filePath, FileMode.Create);
                    model.FormFile.CopyTo(s);
                    model.Picture = filePath;
                    s.Close();
                    s.Dispose();

                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }

                    
                }


                _customerService.UpdateCustomer(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                
                var customer = _customerService.GetCustomer(id);
                if (customer == null)
                    return NotFound();

                _customerService.DeleteCustomer(id);

                if (System.IO.File.Exists(customer.Picture))
                {
                    System.IO.File.Delete(customer.Picture);
                   
                }
                
                
                return NoContent();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
