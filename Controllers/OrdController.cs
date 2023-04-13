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
    public class OrdController : Controller
    {
        private readonly IOrdService _ordService;

        public OrdController(IOrdService ordService)
        {
            _ordService = ordService;
        }


        [HttpGet]
        public async Task<IEnumerable<Ord>> GetAll()
        {
            var obj = await _ordService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Ord> Get(int id)
        {
            var obj = await _ordService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Ord> Post(Ord obj)
        {
            return _ordService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Ord> Delete(int id)
        {
            return _ordService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Ord>> Update(int id, Ord obj)
        {
            return await _ordService.Update(obj);
        }
    }
}

