using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pagination.Models;
using Pagination.Services;

namespace Pagination.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {

        //get all employee records
        [HttpGet]
        public ActionResult<List<Property>> Getall([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Property> property = PropertyServices.GetAll().AsQueryable();
            property = property.Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size);
            return Ok(property);
        }

        //get employee by id
        [HttpGet("{id}")]
        public ActionResult<Property> Get(int id)
        {
            var property = PropertyServices.Get(id);
            if (property == null)
            {
                return NotFound();
            }
            return property;
        }

        //add new employee
        [HttpPost]
        public IActionResult Post(Property property)
        {
            PropertyServices.Add(property);
            return CreatedAtAction(nameof(Get), new { id = property.propertyId }, property);
        }

        //delete employee
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
           var property = PropertyServices.Get(id);
            if (property == null)
            {
                return NotFound();
            }
            PropertyServices.Delete(id);
            return NoContent();
        }

        //update employee
        [HttpPut("{id}")]
        public IActionResult Update(int id, Property property)
        {
            if (id != property.propertyId)
            {
                return BadRequest();
            }

            var queryemp = PropertyServices.Get(id);
            if (queryemp == null)
            {
                return NotFound();
            }

            PropertyServices.Update(property);
            return NoContent();
        }
    }
}
