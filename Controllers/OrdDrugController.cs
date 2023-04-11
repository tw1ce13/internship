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
    public class OrdDrugController : Controller
    {
        private readonly IOrdDrugService _ordDrugService;

        public OrdDrugController(IOrdDrugService ordDrugService)
        {
            _ordDrugService = ordDrugService;
        }


        [HttpGet]
        public async Task<IEnumerable<OrdDrug>> GetAll()
        {
            var obj = await _ordDrugService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<OrdDrug> Get(int id)
        {
            var obj = await _ordDrugService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<OrdDrug> Post(OrdDrug obj)
        {
            return _ordDrugService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<OrdDrug> Delete(int id)
        {
            return _ordDrugService.Delete(id);
        }
    }
}

