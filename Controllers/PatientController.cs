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
    public class PatientController : Controller
    {
        private readonly ProjectContext context;

        public PatientController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Patient>>> Get()
        {
            if (context.Patients == null)
                return NotFound();
            return await context.Patients.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Patient>> Get(int id)
        {
            if (context.Patients == null)
                return NotFound();

            var obj = await context.Patients.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Patient>> Post(Patient obj)
        {
            context.Patients.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Patient obj)
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
            if (context.Patients == null)
                return NotFound();
            var obj = await context.Patients.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.Patients.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

