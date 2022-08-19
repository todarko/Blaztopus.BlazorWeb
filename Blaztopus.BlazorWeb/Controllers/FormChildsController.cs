using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Blaztopus.BlazorWeb.Data;
using Blaztopus.BlazorWeb.Models;

namespace Blaztopus.BlazorWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FormChildsController : ControllerBase
    {
        private readonly OctopusDbContext _context;

        public FormChildsController(OctopusDbContext context)
        {
            _context = context;
        }

        // GET: api/FormChilds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FormChild>>> GetFormChildren()
        {
          if (_context.FormChildren == null)
          {
              return NotFound();
          }
            return await _context.FormChildren.ToListAsync();
        }

        // GET: api/FormChilds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FormChild>> GetFormChild(Guid id)
        {
          if (_context.FormChildren == null)
          {
              return NotFound();
          }
            var formChild = await _context.FormChildren.FindAsync(id);

            if (formChild == null)
            {
                return NotFound();
            }

            return formChild;
        }

        // PUT: api/FormChilds/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFormChild(Guid id, FormChild formChild)
        {
            if (id != formChild.Id)
            {
                return BadRequest();
            }

            _context.Entry(formChild).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FormChildExists(id))
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

        // POST: api/FormChilds
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FormChild>> PostFormChild(FormChild formChild)
        {
          if (_context.FormChildren == null)
          {
              return Problem("Entity set 'OctopusDbContext.FormChildren'  is null.");
          }
            _context.FormChildren.Add(formChild);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFormChild", new { id = formChild.Id }, formChild);
        }

        // DELETE: api/FormChilds/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFormChild(Guid id)
        {
            if (_context.FormChildren == null)
            {
                return NotFound();
            }
            var formChild = await _context.FormChildren.FindAsync(id);
            if (formChild == null)
            {
                return NotFound();
            }

            _context.FormChildren.Remove(formChild);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FormChildExists(Guid id)
        {
            return (_context.FormChildren?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
