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

        [HttpPost("/booking")]
        public async Task<IActionResult> CreateBooking(BookingDto bdto)
        {   
            var property = await _repository.SearchByIdAsync(bdto.PropertyGuid);
            var booking = new Booking(bdto, property);
            await _repository.BookingAsync(booking);
            await _repository.SaveAsync();
            
            return CreatedAtAction("GetBooking", new {booking.Id} , booking);
        }
    
        [HttpGet("/booking/{id}")]
        public async Task<IActionResult> GetBooking(Guid id)
        {
            var booking = await _repository.SearchBookingsById(id);
            return Ok(booking);
        }

         [HttpGet("/search/{keyword}")]
        public async Task<IActionResult> SearchByKeyword(string keyword)
        {
            var results = await _repository.SearchByFields(keyword);
            return Ok(results);
        }

        [HttpGet("/weather/{city}")]
        public async Task<IActionResult> CityWeather(string city)
        {
            var results = await _repository.GetWeather(city);
            return Ok(results);
        }
    



        


    }
}