using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using E06RepetitionRest.Models;

namespace E06RepetitionRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly MyDbContext _context;

        public ModuleController(MyDbContext context)
        {
            _context = context;
        }

        // GET: api/Module
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Module>>> GetModules()
        {
          if (_context.Modules == null)
          {
              return NotFound();
          }
            return await _context.Modules.ToListAsync();
        }

        // GET: api/Module/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Module>> GetModule(Guid id)
        {
          if (_context.Modules == null)
          {
              return NotFound();
          }
            var @module = await _context.Modules.FindAsync(id);

            if (@module == null)
            {
                return NotFound();
            }

            return @module;
        }

        // PUT: api/Module/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModule(Guid id, Module @module)
        {
            if (id != @module.Id)
            {
                return BadRequest();
            }

            _context.Entry(@module).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModuleExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Module
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Module>> PostModule(Module @module)
        {
          if (_context.Modules == null)
          {
              return Problem("Entity set 'MyDbContext.Modules'  is null.");
          }
            _context.Modules.Add(@module);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModule", new { id = @module.Id }, @module);
        }

        // DELETE: api/Module/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModule(Guid id)
        {
            if (_context.Modules == null)
            {
                return NotFound();
            }
            var @module = await _context.Modules.FindAsync(id);
            if (@module == null)
            {
                return NotFound();
            }

            _context.Modules.Remove(@module);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModuleExists(Guid id)
        {
            return (_context.Modules?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
