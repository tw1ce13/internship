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
    public class OrdController : Controller
    {
        private readonly ProjectContext context;

        public OrdController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ord>>> Get()
        {
            if (context.Ords == null)
                return NotFound();
            return await context.Ords.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Ord>> Get(int id)
        {
            if (context.Ords == null)
                return NotFound();

            var obj = await context.Ords.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Ord>> Post(Ord obj)
        {
            context.Ords.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Ord obj)
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
            if (context.Ords == null)
                return NotFound();
            var obj = await context.Ords.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.Ords.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

