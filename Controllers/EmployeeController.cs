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
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet]
        public async Task<IEnumerable<Employee>> GetAll()
        {
            var obj = await _employeeService.GetAll();
            return obj.Data;
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(int id)
        {
            var obj = await _employeeService.Get(id);
            return obj.Data;
        }

        [HttpPost]
        public IBaseResponse<Employee> Post(Employee obj)
        {
            return _employeeService.Add(obj);
        }

        [HttpDelete("{id}")]
        public IBaseResponse<Employee> Delete(int id)
        {
            return _employeeService.Delete(id);
        }
    }
}

