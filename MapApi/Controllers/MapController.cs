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


        [HttpGet]
        public async Task<ActionResult<IEnumerable<AmenityWithPoint>>> GetAmenities()
        {
            return await _context.getAmenitiesWithPoint();
        }

        [HttpGet("2")]
        public IEnumerable<Point> GetAmenities2()
        {
            // LINQ Queries
            var query = from a in _context.Amenities select new Point(a.Pt);
            return query;
        }

        [HttpGet("points")]
        public async Task<ActionResult<IEnumerable<Point>>> GetPoints()
        {
            var entity_list = await _context.Amenities.ToListAsync();
            var point_list = new List<Point>();

            foreach (Amenity amenity in entity_list)
            {
                point_list.Add(new Point(amenity.Pt));
            }

            return point_list;
        }

       

    }
}
