using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Text.Json;

namespace web
{
    [ApiController]
    [Route("listings")]
    public class PropertyController : ControllerBase
    {
        private IPropertyRepository _repository;

        private PropertyController(IPropertyRepository repository)
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

    }
}