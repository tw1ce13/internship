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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : Controller
    {
        private readonly IDrugService _drugService;

        public DrugController(IDrugService drugService)
        {
            _drugService = drugService;
        }


        [HttpGet]
        public async Task<IEnumerable<Drug>> GetAll()
        {
            var obj = await _drugService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Drug> Get(int id)
        {
            var obj = await _drugService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Drug> Post(Drug obj)
        {
            return _drugService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Drug> Delete(int id)
        {
            return _drugService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Drug>> Update(int id, Drug obj)
        {
            return await _drugService.Update(obj);
        }
    }
}

