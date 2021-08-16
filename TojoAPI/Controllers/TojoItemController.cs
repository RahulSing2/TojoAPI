using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TojoAPI.Models;

namespace TojoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TojoItemController : ControllerBase
    {
        private readonly TojoContext _context;

        public TojoItemController(TojoContext context)
        {
            _context = context;
        }

        // GET: api/TojoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TojoItem>>> GetTojoItems()
        {
            return await _context.TojoItem.ToListAsync();
        }

        // GET: api/TojoItems/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TojoItem>> GetTojoItem(long id)
        {
            var tojoItem = await _context.TojoItem.FindAsync(id);

            if (tojoItem == null)
            {
                return NotFound();
            }
            return Ok(tojoItem);
        }

        // PUT: api/TojoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> PutTojoItem(long id, TojoItem tojoItem)
        {
            if (id != tojoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(tojoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TojoItemExists(id))
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

        // POST: api/TojoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]

        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesDefaultResponseType]
        public async Task<ActionResult<TojoItem>> PostTojoItem(TojoItem tojoItem)
        {
            _context.TojoItem.Add(tojoItem);
            await _context.SaveChangesAsync();

            //return CreatedAtAction("GetTojoItem", new { id = tojoItem.Id }, tojoItem);
            return CreatedAtAction(nameof(GetTojoItem), new { id = tojoItem.Id }, tojoItem);
        }

        // DELETE: api/TojoItems/5
        [HttpDelete("{id}")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteTojoItem(long id)
        {
            var tojoItem = await _context.TojoItem.FindAsync(id);
            if (tojoItem == null)
            {
                return NotFound();
            }

            _context.TojoItem.Remove(tojoItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TojoItemExists(long id)
        {
            return _context.TojoItem.Any(e => e.Id == id);
        }
    }
}
