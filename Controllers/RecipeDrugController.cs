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
    public class RecipeDrugController : Controller
    {
        private readonly IRecipeDrugService _recipeDrugService;

        public RecipeDrugController(IRecipeDrugService recipeDrugService)
        {
            _recipeDrugService = recipeDrugService;
        }


        [HttpGet]
        public async Task<IEnumerable<RecipeDrug>> GetAll()
        {
            var obj = await _recipeDrugService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<RecipeDrug> Get(int id)
        {
            var obj = await _recipeDrugService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<RecipeDrug> Post(RecipeDrug obj)
        {
            return _recipeDrugService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<RecipeDrug> Delete(int id)
        {
            return _recipeDrugService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<RecipeDrug>> Update(int id, RecipeDrug obj)
        {
            return await _recipeDrugService.Update(id, obj);
        }
    }
}

