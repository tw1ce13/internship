using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectJunior.Models;
using ProjectJunior.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;
using ProjectJunior.Data.Interfaces;
using ProjectJunior.Data.Implementations;
using ProjectJunior.Services.Response;

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : Controller
    {

        private readonly IPharmacyService _pharmacyService;

        public PharmacyController(PharmacyService pharmacyService)
        {
            _pharmacyService = pharmacyService;
        }


        [HttpGet]
        public async Task<IEnumerable<Pharmacy>> GetAll()
        {
            var obj = await _pharmacyService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Pharmacy> Get(int id)
        {
            var obj = await _pharmacyService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Pharmacy> Post(Pharmacy obj)
        {
            return _pharmacyService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Pharmacy> Delete(int id)
        {
            return _pharmacyService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Pharmacy>> Update(int id, Pharmacy obj)
        {
            return await _pharmacyService.Update(obj);
        }
    }
}

