using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;
using WebApplicationCoolerGaming.Data;

namespace WebApplicationCoolerGaming.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly WebApplicationCoolerGamingContext _context;

        public GenresController(WebApplicationCoolerGamingContext context)
        {
            _context = context;
        }

        // GET: api/Genres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genres>>> GetGenres()
        {
            return await _context.Genres.ToListAsync();
        }

        // GET: api/Genres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Genres>> GetGenres(int id)
        {
            var genres = await _context.Genres.FindAsync(id);

            if (genres == null)
            {
                return NotFound();
            }

            return genres;
        }

        // PUT: api/Genres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGenres(int id, Genres genres)
        {
            if (id != genres.IdGenre)
            {
                return BadRequest();
            }

            _context.Entry(genres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GenresExists(id))
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

        // POST: api/Genres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Genres>> PostGenres(Genres genres)
        {
            _context.Genres.Add(genres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGenres", new { id = genres.IdGenre }, genres);
        }

        // DELETE: api/Genres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGenres(int id)
        {
            var genres = await _context.Genres.FindAsync(id);
            if (genres == null)
            {
                return NotFound();
            }

            _context.Genres.Remove(genres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GenresExists(int id)
        {
            return _context.Genres.Any(e => e.IdGenre == id);
        }
    }
}
