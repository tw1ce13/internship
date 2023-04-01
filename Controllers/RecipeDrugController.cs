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
    public class RecipeDrugController : Controller
    {
        private readonly ProjectContext context;

        public RecipeDrugController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<RecipeDrug>>> Get()
        {
            if (context.RecipesDrugs == null)
                return NotFound();
            return await context.RecipesDrugs.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<RecipeDrug>> Get(int id)
        {
            if (context.RecipesDrugs == null)
                return NotFound();

            var obj = await context.RecipesDrugs.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<RecipeDrug>> Post(RecipeDrug obj)
        {
            context.RecipesDrugs.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, RecipeDrug obj)
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
            if (context.RecipesDrugs == null)
                return NotFound();
            var obj = await context.RecipesDrugs.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.RecipesDrugs.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

