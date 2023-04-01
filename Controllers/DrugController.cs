using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectJunior.Data;
using ProjectJunior.Models;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrugController : Controller
    {
        private readonly ProjectContext context;

        public DrugController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Drug>>> Get()
        {
            if (context.Drugs == null)
                return NotFound();
            return await context.Drugs.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Drug>> Get(int id)
        {
            if (context.Drugs == null)
                return NotFound();

            var obj = await context.Drugs.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Drug>> Post(Drug obj)
        {
            context.Drugs.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Drug obj)
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
            if (context.Drugs == null)
                return NotFound();
            var obj = await context.Drugs.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.Drugs.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

