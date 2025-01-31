using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PickupPointAPI.Data;
using PickupPointAPI.Models;

namespace PickupPointAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PickupPointsController : Controller
    {
        private readonly AppDbContext _context;

        public PickupPointsController(AppDbContext context)
        {
            _context = context;
        }
        // GET: api/PickupPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PickupPoint>>> GetPickupPoints()
        {
            return await _context.PickupPoints.ToListAsync();
        }

        // GET: api/PickupPoints/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<PickupPoint>> GetPickupPoint(int id)
        {
            var pickupPoint = await _context.PickupPoints.FindAsync(id);

            if (pickupPoint == null)
            {
                return NotFound();
            }

            return pickupPoint;
        }

        // POST: api/PickupPoints
        [HttpPost]
        public async Task<ActionResult<PickupPoint>> PostPickupPoint(PickupPoint pickupPoint)
        {
            _context.PickupPoints.Add(pickupPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPickupPoint), new { id = pickupPoint.Id }, pickupPoint);
        }

        // PUT: api/PickupPoints/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPickupPoint(int id, PickupPoint pickupPoint)
        {
            if (id != pickupPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(pickupPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.PickupPoints.Any(e => e.Id == id))
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

        // DELETE: api/PickupPoints/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePickupPoint(int id)
        {
            var pickupPoint = await _context.PickupPoints.FindAsync(id);

            if (pickupPoint == null)
            {
                return NotFound();
            }

            _context.PickupPoints.Remove(pickupPoint);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}