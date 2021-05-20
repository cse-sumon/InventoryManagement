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
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IProductService productService, IWebHostEnvironment webHostEnvironment)
        {
            _productService = productService;
            _webHostEnvironment = webHostEnvironment;

        }


        // GET: api/<ProductController>
        [HttpGet]
        public IActionResult GetAllProducts()
        {
            try
            {
                var products = _productService.GetAllProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // POST api/<ProductController>
        [HttpPost]
        public IActionResult PostProduct([FromForm]ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

               if(model.IFormFile != null)
                {
                    var fileType = (Path.GetExtension(model.IFormFile.FileName)).ToLower();
                    if (fileType != ".jpg" && fileType != ".png")
                        return BadRequest();

                    var fileName = Path.GetFileName(model.IFormFile.FileName.Replace(" ", "_"));
                    var uniqueFileName = Helper.GetUniqueFileName(fileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads/Product_Images");
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    //model.IFormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    FileStream s = new FileStream(filePath, FileMode.Create);
                    model.IFormFile.CopyTo(s);
                    model.Picture = filePath;

                    s.Close();
                    s.Dispose();

                }

                _productService.SaveProduct(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromForm]ProductViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.Id != id)
                    return BadRequest();

                var product = _productService.GetProduct(id);
                if (product == null)
                    return NotFound();

                if (model.IFormFile != null)
                {
                    var fileType = (Path.GetExtension(model.IFormFile.FileName)).ToLower();
                    if (fileType != ".jpg" && fileType != ".png")
                        return BadRequest();

                    var oldImage = model.Picture;
                    var fileName = Path.GetFileName(model.IFormFile.FileName.Replace(" ", "_"));
                    var uniqueFileName = Helper.GetUniqueFileName(fileName);
                    var uploadPath = Path.Combine(_webHostEnvironment.ContentRootPath, "Uploads/Product_Images");
                    var filePath = Path.Combine(uploadPath, uniqueFileName);

                    //model.IFormFile.CopyTo(new FileStream(filePath, FileMode.Create));
                    //model.Picture = filePath;
                    FileStream s = new FileStream(filePath, FileMode.Create);
                    model.IFormFile.CopyTo(s);
                    model.Picture = filePath;
                    s.Close();
                    s.Dispose();

                    if (System.IO.File.Exists(oldImage))
                    {
                        System.IO.File.Delete(oldImage);
                    }
                }


                _productService.UpdateProduct(model);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var product = _productService.GetProduct(id);
                if (product == null)
                    return NotFound();

                _productService.DeleteProduct(id);

                if (System.IO.File.Exists(product.Picture))
                {
                    System.IO.File.Delete(product.Picture);
                }
                return NoContent();
            }
            catch (Exception ex)
            {

                throw;
            }
        }


        // Get api/<ProductController>/ChangeSatus/5
        [HttpGet("ChangeSatus/{id}")]
        public IActionResult ChangeSatus(int id)
        {
            try
            {
                _productService.ChangeStatus(id);
                return Ok();
            }
            catch (Exception ex)
            {

                throw;
            }
        }






    }
}
