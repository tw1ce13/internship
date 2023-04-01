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
    public class OrdDrugController : Controller
    {
        private readonly ProjectContext context;

        public OrdDrugController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrdDrug>>> Get()
        {
            if (context.OrdsDrugs == null)
                return NotFound();
            return await context.OrdsDrugs.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<OrdDrug>> Get(int id)
        {
            if (context.OrdsDrugs == null)
                return NotFound();

            var obj = await context.OrdsDrugs.FindAsync(id);
            if (obj == null)
                return NotFound();
            return obj;
        }


        [HttpPost]
        public async Task<ActionResult<OrdDrug>> Post(OrdDrug obj)
        {
            context.OrdsDrugs.Add(obj);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = obj.Id }, obj);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, OrdDrug obj)
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
            if (context.OrdsDrugs == null)
                return NotFound();
            var obj = await context.OrdsDrugs.FindAsync(id);

            if (obj == null)
                return NotFound();
            context.OrdsDrugs.Remove(obj);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

