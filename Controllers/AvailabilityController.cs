using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectJunior.Data;
using ProjectJunior.Models;
using Microsoft.EntityFrameworkCore;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvailabilityController : Controller
    {
        private readonly IAvailabilityService _availabilityService;

        public AvailabilityController(IAvailabilityService availabilityService)
        {
            _availabilityService = availabilityService;
        }


        [HttpGet]
        public async Task<IEnumerable<Availability>> GetAll()
        {
            var availabilities = await _availabilityService.GetAll();
            return availabilities.Data;
        }

        [HttpGet("{id}")]
        public async Task<Availability> Get(int id)
        {
            var availability = await _availabilityService.Get(id);
            return availability.Data;
        }

        [HttpPost]
        public IBaseResponse<Availability> Post(Availability availability)
        {
            return _availabilityService.Add(availability);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Availability> Delete(int id)
        {
            return _availabilityService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Availability>> Update(int id, Availability availability)
        {
            return await _availabilityService.Update(id, availability);
        }
    }
}

