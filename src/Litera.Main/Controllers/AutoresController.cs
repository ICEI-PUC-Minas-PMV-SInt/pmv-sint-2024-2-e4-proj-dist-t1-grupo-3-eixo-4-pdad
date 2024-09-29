using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Litera.Main.Infrastructure.Database;
using Litera.Main.Models;
using Litera.Main.Models.Dtos;
using Litera.Main.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Litera.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AutoresController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Autores
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutorModel>>> GetAutores()
        {
            var autores = await _context.Autores.Include(autor => autor.Obras).ToListAsync();

            var dto = autores
                .Select(autor => new AutorDto
                {
                    Id = autor.Id,
                    NomeCompleto = autor.NomeCompleto,
                    DataNascimento = autor.DataNascimento,
                    Nacionalidade = autor.Nacionalidade,
                    Biografia = autor.Biografia,
                    Obras = autor
                        .Obras.Select(obra => new ObraDto
                        {
                            Id = obra.Id,
                            Nome = obra.Nome,
                            DataLancamento = obra.DataLancamento,
                            Idioma = obra.Idioma,
                            TotalPaginas = obra.TotalPaginas,
                        })
                        .ToList(),
                })
                .ToList();

            return Ok(dto);
        }

        // GET: api/Autores/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AutorDto>> GetAutorModel(int id)
        {
            var autor = await _context
                .Autores.Include(autor => autor.Obras)
                .FirstOrDefaultAsync(autor => autor.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            var dto = new AutorDto
            {
                Id = autor.Id,
                NomeCompleto = autor.NomeCompleto,
                DataNascimento = autor.DataNascimento,
                Nacionalidade = autor.Nacionalidade,
                Biografia = autor.Biografia,
                Obras = autor
                    .Obras.Select(obra => new ObraDto
                    {
                        Id = obra.Id,
                        Nome = obra.Nome,
                        DataLancamento = obra.DataLancamento,
                        Idioma = obra.Idioma,
                        TotalPaginas = obra.TotalPaginas,
                    })
                    .ToList(),
            };

            return Ok(dto);
        }

        // PUT: api/Autores/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAutorModel(int id, AutorModel autorModel)
        {
            if (id != autorModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(autorModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AutorModelExists(id))
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

        // POST: api/Autores
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<AutorModel>> PostAutorModel(AutorModel autorModel)
        {
            _context.Autores.Add(autorModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAutorModel", new { id = autorModel.Id }, autorModel);
        }

        // DELETE: api/Autores/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAutorModel(int id)
        {
            var autorModel = await _context.Autores.FindAsync(id);
            if (autorModel == null)
            {
                return NotFound();
            }

            _context.Autores.Remove(autorModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AutorModelExists(int id)
        {
            return _context.Autores.Any(e => e.Id == id);
        }
    }
}
