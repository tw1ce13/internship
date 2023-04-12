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
    public class ClassController : Controller
    {
        private readonly IClassService _classService;

        public ClassController(IClassService classService)
        {
            _classService = classService;
        }


        [HttpGet]
        public async Task<IEnumerable<Class>> GetAll()
        {
            var obj = await _classService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Class> Get(int id)
        {
            var obj = await _classService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Class> Post(Class obj)
        {
            return _classService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Class> Delete(int id)
        {
            return _classService.Delete(id);
        }

        [HttpPut("{id}")]
        public async Task<IBaseResponse<Class>> Update(int id, Class obj)
        {
            return await _classService.Update(id, obj);
        }
    }
}

