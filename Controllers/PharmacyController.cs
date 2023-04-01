using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectJunior.Models;
using ProjectJunior.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Data.Entity;



namespace ProjectJunior.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PharmacyController : Controller
    {

        private readonly ProjectContext context;

        public PharmacyController(ProjectContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pharmacy>>> GetPharmacy()
        {
            if (context.Pharmacies == null)
                return NotFound();

            return await context.Pharmacies.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Pharmacy>> Get(int id)
        {
            if (context.Pharmacies == null)
                return NotFound();

            var pharmacy = await context.Pharmacies.FindAsync(id);

            if (pharmacy == null)
                return NotFound();

            return pharmacy;
        }


        [HttpPost]
        public async Task<ActionResult<Pharmacy>> PostPharmacy (Pharmacy pharmacy)
        {
            context.Pharmacies.Add(pharmacy);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetPharmacy", new { id = pharmacy.Id }, pharmacy);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Pharmacy pharmacy)
        {
            if (id != pharmacy.Id)
                return BadRequest();

            context.Entry(pharmacy).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
            if (context.Pharmacies == null)
                return NotFound();
            var pharmacy = await context.Pharmacies.FindAsync(id);

            if (pharmacy == null)
                return NotFound();
            context.Pharmacies.Remove(pharmacy);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

