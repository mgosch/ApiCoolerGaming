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
    public class GamesGenresController : ControllerBase
    {
        private readonly WebApplicationCoolerGamingContext _context;

        public GamesGenresController(WebApplicationCoolerGamingContext context)
        {
            _context = context;
        }

        // GET: api/GamesGenres
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamesGenres>>> GetGamesGenres()
        {
            return await _context.GamesGenres.ToListAsync();
        }

        // GET: api/GamesGenres/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GamesGenres>> GetGamesGenres(int id)
        {
            var gamesGenres = await _context.GamesGenres.FindAsync(id);

            if (gamesGenres == null)
            {
                return NotFound();
            }

            return gamesGenres;
        }

        // PUT: api/GamesGenres/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGamesGenres(int id, GamesGenres gamesGenres)
        {
            if (id != gamesGenres.Id)
            {
                return BadRequest();
            }

            _context.Entry(gamesGenres).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GamesGenresExists(id))
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

        // POST: api/GamesGenres
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<GamesGenres>> PostGamesGenres(GamesGenres gamesGenres)
        {
            _context.GamesGenres.Add(gamesGenres);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetGamesGenres", new { id = gamesGenres.Id }, gamesGenres);
        }

        // DELETE: api/GamesGenres/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGamesGenres(int id)
        {
            var gamesGenres = await _context.GamesGenres.FindAsync(id);
            if (gamesGenres == null)
            {
                return NotFound();
            }

            _context.GamesGenres.Remove(gamesGenres);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool GamesGenresExists(int id)
        {
            return _context.GamesGenres.Any(e => e.Id == id);
        }
    }
}
