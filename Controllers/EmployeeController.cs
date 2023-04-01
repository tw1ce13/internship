using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectJunior.Data;
using ProjectJunior.Models;
using Microsoft.EntityFrameworkCore;


namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly ProjectContext context;

        public EmployeeController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> Get()
        {
            if (context.Employees == null)
                return NotFound();
            return await context.Employees.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> Get(int id)
        {
            if (context.Employees == null)
                return NotFound();

            var obj = await context.Employees.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Employee>> Post(Employee obj)
        {
            context.Employees.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Employee obj)
        {
            if (id != obj.Id)
                return BadRequest();
            context.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                return NotFound();
            }

            return NoContent();

        }


        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            if (context.Employees == null)
                return NotFound();
            var obj = await context.Employees.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.Employees.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

