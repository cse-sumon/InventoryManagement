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
    public class PaymentController : ControllerBase
    {

        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }


        // GET: api/<PaymentController>
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_paymentService.GetAllPayments());
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        // GET api/<PaymentController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var payment = _paymentService.GetPayment(id);
                if (payment == null)
                    return NotFound();

                return Ok(payment);
            }

            catch (Exception ex)
            {
                throw;
            }
        }



        // POST api/<PaymentController>
        [HttpPost]
        public IActionResult Post(PaymentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest();

                _paymentService.SavePayment(model);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        // PUT api/<PaymentController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, PaymentViewModel model)
        {
            try
            {
                if (!ModelState.IsValid || model.PaymentId != id)
                    return BadRequest();

                var payment = _paymentService.GetPayment(id);
                if (payment == null)
                    return NotFound();

                _paymentService.UpdatePayment(payment);
                return Ok();
            }
            catch (Exception ex)
            {
                throw;
            }
        }



        // DELETE api/<PaymentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var payment = _paymentService.GetPayment(id);
                if (payment == null)
                    return NotFound();

                _paymentService.Delete(id);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }


    }
}
