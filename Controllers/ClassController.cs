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
    public class ClassController : Controller
    {
        private readonly ProjectContext context;

        public ClassController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Class>>> Get()
        {
            if (context.Classes == null)
                return NotFound();
            return await context.Classes.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Class>> Get(int id)
        {
            if (context.Classes == null)
                return NotFound();

            var obj = await context.Classes.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Class>> Post(Class obj)
        {
            context.Classes.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Class obj)
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
            if (context.Classes == null)
                return NotFound();
            var obj = await context.Classes.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.Classes.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

