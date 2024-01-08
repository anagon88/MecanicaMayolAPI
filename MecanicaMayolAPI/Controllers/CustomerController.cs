using MecanicaMayolAPI.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MecanicaMayolAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<CustomerDto>> GetCustomers()
        {
            return new List<CustomerDto>() { new CustomerDto() { Id = 1, Name = "Ana Gonzalez" } };
        }

        [HttpGet("id")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<CustomerDto> GetCustomer(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            return Ok(new CustomerDto() { Id = id, Name = "Ana Gonzalez" });
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<CustomerDto> CreateCustomer([FromBody] CustomerDto customer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(customer);
            }

            if (ModelState.IsValid)
            {
                ModelState.AddModelError("ExistCUstomer", "El customer existe");
                return BadRequest(ModelState);
            }

            if (customer == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return Ok(customer);
        }

        [HttpDelete("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult DeleteCustomer(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpPut("id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult UpdateCustomer(int id, [FromBody]CustomerDto customer)
        {
            if (id == 0 || customer == null)
            {
                return BadRequest();
            }

            return NoContent();
        }


    }
}
