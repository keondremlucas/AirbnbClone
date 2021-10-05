using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;
using Microsoft.EntityFrameworkCore;

namespace web
{
    [ApiController]
    [Route("listings")]
    public class PropertyController : ControllerBase
    {
        private IPropertyRepository _repository;

        public PropertyController(IPropertyRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create(PropertyDto pdto)
        {
            var property = new Property(pdto);
            await _repository.AddAsync(property);
            await _repository.SaveAsync();

            return CreatedAtAction("GetOne", new { property.Id }, property);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(Guid id)
        {
            var property = await _repository.SearchByIdAsync(id);
            return Ok(property);
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {   
            var properties = await _repository.GetAllAsync();
            return Ok(properties);
        }

         [HttpGet("/owner/{name}")]
        public async Task<IActionResult> SearchPropertiesByOwner(string name)
        {  
            var properties = await _repository.SearchPropertiesByOwnerAsync(name);
            return Ok(properties);
        }

        [HttpGet("/book/{guid}")]
        public async Task<IActionResult> BookAsync(Guid guid)
        {  
            await _repository.BookAsync(guid);
            return Ok("Booked");
        }



        


    }
}