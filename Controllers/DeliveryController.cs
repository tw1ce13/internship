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
    public class DeliveryController : Controller
    {

        private readonly ProjectContext context;

        public DeliveryController(ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> Get()
        {
            if (context.Deliveries == null)
                return NotFound();

            return await context.Deliveries.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> Get(int id)
        {
            if (context.Deliveries == null)
                return NotFound();

            var delivery = await context.Deliveries.FindAsync(id);

            if (delivery == null)
                return NotFound();

            return delivery;
        }


        [HttpPost]
        public async Task<ActionResult<Delivery>> Post(Delivery delivery)
        {
            context.Deliveries.Add(delivery);
            await context.SaveChangesAsync();

            return CreatedAtAction("Get", new { id = delivery.Id }, delivery);
        }


        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, Delivery delivery)
        {
            if (id != delivery.Id)
                return BadRequest();

            context.Entry(delivery).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
            if (context.Deliveries == null)
                return NotFound();
            var delivery = await context.Deliveries.FindAsync(id);

            if (delivery == null)
                return NotFound();
            context.Deliveries.Remove(delivery);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

