using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MapApi.Models;

namespace MapApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly mtlosmContext _context;

        public MapController(mtlosmContext context)
        {
            _context = context;
        }

        // GET: api/Map
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Amenities>>> GetAmenities()
        {
            return await _context.Amenities.ToListAsync();
        }

        [HttpGet("points")]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints()
        {
            var entity_list = await _context.Amenities.ToListAsync();
            var point_list = new List<Point>();

            foreach (Amenities amenity in entity_list)
            {
                point_list.Add(new Point(amenity.Pt));
            }

            return point_list;
        }

        // GET: api/Map/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Amenities>> GetAmenities(long id)
        {
            var amenities = await _context.Amenities.FindAsync(id);

            if (amenities == null)
            {
                return NotFound();
            }

            return amenities;
        }

        // PUT: api/Map/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAmenities(long id, Amenities amenities)
        {
            if (id != amenities.Id)
            {
                return BadRequest();
            }

            _context.Entry(amenities).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AmenitiesExists(id))
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

        // POST: api/Map
        [HttpPost]
        public async Task<ActionResult<Amenities>> PostAmenities(Amenities amenities)
        {
            _context.Amenities.Add(amenities);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAmenities", new { id = amenities.Id }, amenities);
        }

        // DELETE: api/Map/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Amenities>> DeleteAmenities(long id)
        {
            var amenities = await _context.Amenities.FindAsync(id);
            if (amenities == null)
            {
                return NotFound();
            }

            _context.Amenities.Remove(amenities);
            await _context.SaveChangesAsync();

            return amenities;
        }

        private bool AmenitiesExists(long id)
        {
            return _context.Amenities.Any(e => e.Id == id);
        }
    }
}
