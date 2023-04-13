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
using ProjectJunior.Data.Implementations;

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : Controller
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }


        [HttpGet]
        public async Task<IEnumerable<Patient>> GetAll()
        {
            var obj = await _patientService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Patient> Get(int id)
        {
            var obj = await _patientService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Patient> Post(Patient obj)
        {
            return _patientService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Patient> Delete(int id)
        {
            return _patientService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Patient>> Update(int id, Patient obj)
        {
            return await _patientService.Update(obj);
        }
    }
}

