using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_CDE.Data;
using API_CDE.Models;

namespace API_CDE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionGroupsController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public PositionGroupsController(ApplicationDBContext context)
        {
            _context = context;
        }

        // GET: api/PositionGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PositionGroup>>> GetPositionGroups()
        {
          if (_context.PositionGroups == null)
          {
              return NotFound();
          }
            return await _context.PositionGroups.ToListAsync();
        }

        // GET: api/PositionGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PositionGroup>> GetPositionGroup(int id)
        {
          if (_context.PositionGroups == null)
          {
              return NotFound();
          }
            var positionGroup = await _context.PositionGroups.FindAsync(id);

            if (positionGroup == null)
            {
                return NotFound();
            }

            return positionGroup;
        }

        // PUT: api/PositionGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPositionGroup(int id, PositionGroup positionGroup)
        {
            if (id != positionGroup.IdPoGr)
            {
                return BadRequest();
            }

            _context.Entry(positionGroup).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PositionGroupExists(id))
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

        // POST: api/PositionGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PositionGroup>> PostPositionGroup(PositionGroup positionGroup)
        {
          if (_context.PositionGroups == null)
          {
              return Problem("Entity set 'ApplicationDBContext.PositionGroups'  is null.");
          }
            _context.PositionGroups.Add(positionGroup);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPositionGroup", new { id = positionGroup.IdPoGr }, positionGroup);
        }

        // DELETE: api/PositionGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositionGroup(int id)
        {
            if (_context.PositionGroups == null)
            {
                return NotFound();
            }
            var positionGroup = await _context.PositionGroups.FindAsync(id);
            if (positionGroup == null)
            {
                return NotFound();
            }

            _context.PositionGroups.Remove(positionGroup);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PositionGroupExists(int id)
        {
            return (_context.PositionGroups?.Any(e => e.IdPoGr == id)).GetValueOrDefault();
        }
    }
}
