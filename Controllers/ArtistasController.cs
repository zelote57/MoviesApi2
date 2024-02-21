﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MoviesApi.Data;
using MoviesApi.Models;

namespace MoviesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : ControllerBase
    {
        private readonly MoviesDbContext _context;

        public ArtistasController(MoviesDbContext context)
        {
            _context = context;
        }

        // GET: api/Artistas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Artista>>> GetArtistas()
        {
          if (_context.Artistas == null)
          {
              return NotFound();
          }
            return await _context.Artistas.ToListAsync();
        }

        // GET: api/Artistas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Artista>> GetArtista(int id)
        {
          if (_context.Artistas == null)
          {
              return NotFound();
          }
            var artista = await _context.Artistas.FindAsync(id);

            if (artista == null)
            {
                return NotFound();
            }

            return artista;
        }

        // PUT: api/Artistas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtista(int id, Artista artista)
        {
            if (id != artista.Id)
            {
                return BadRequest();
            }

            _context.Entry(artista).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistaExists(id))
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

        // POST: api/Artistas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Artista>> PostArtista(Artista artista)
        {
          if (_context.Artistas == null)
          {
              return Problem("Entity set 'MoviesDbContext.Artistas'  is null.");
          }
            _context.Artistas.Add(artista);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtista", new { id = artista.Id }, artista);
        }

        // DELETE: api/Artistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtista(int id)
        {
            if (_context.Artistas == null)
            {
                return NotFound();
            }
            var artista = await _context.Artistas.FindAsync(id);
            if (artista == null)
            {
                return NotFound();
            }

            _context.Artistas.Remove(artista);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ArtistaExists(int id)
        {
            return (_context.Artistas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
