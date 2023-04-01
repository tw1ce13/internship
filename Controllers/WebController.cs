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
    public class WebController : Controller
    {
        private readonly ProjectContext context;

        public WebController (ProjectContext context)
        {
            this.context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Web>>> GetWeb()
        {
            if (context.Webs == null)
                return NotFound();
            return await context.Webs.ToListAsync();
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Web>> Get(int id)
        {
            if (context.Webs == null)
                return NotFound();

            var web = await context.Webs.FindAsync(id);

            if (web == null)
                return NotFound();

            return web;
        }


        [HttpPost]
        public async Task<ActionResult<Web>> PostWeb(Web web)
        {
            context.Webs.Add(web);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetWeb), new { id = web.Id }, web);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutWeb(int id, Web web)
        {
            context.Entry(web).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

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
        public async Task<IActionResult> Delete(int id)
        {
            if (context.Webs == null)
                return NotFound();
            var web = await context.Webs.FindAsync(id);
            if (web == null)
                return NotFound();

            context.Webs.Remove(web);
            await context.SaveChangesAsync();

            return NoContent();
        }
    }
}

