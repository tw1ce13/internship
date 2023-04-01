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
    public class RecipeController : Controller
    {
        private readonly ProjectContext context;

        public RecipeController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recipe>>> Get()
        {
            if (context.Recipes == null)
                return NotFound();
            return await context.Recipes.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Recipe>> Get(int id)
        {
            if (context.Recipes == null)
                return NotFound();

            var obj = await context.Recipes.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<Recipe>> Post(Recipe obj)
        {
            context.Recipes.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Recipe obj)
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
            if (context.Recipes == null)
                return NotFound();
            var obj = await context.Recipes.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.Recipes.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

