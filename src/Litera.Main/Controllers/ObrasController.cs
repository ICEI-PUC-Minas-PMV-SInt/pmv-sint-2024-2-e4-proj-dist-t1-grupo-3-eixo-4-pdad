using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Litera.Main.Infrastructure.Database;
using Litera.Main.Models;
using Litera.Main.Models.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Litera.Main.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObrasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ObrasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Obras
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ObraModel>>> GetObras()
        {
            var obras = await _context
                .Obras.Include(obra => obra.Autor)
                .Include(obra => obra.Categoria)
                .ToListAsync();

            var dto = obras
                .Select(obra => new ObraDto
                {
                    Id = obra.Id,
                    Nome = obra.Nome,
                    DataLancamento = obra.DataLancamento,
                    Idioma = obra.Idioma,
                    TotalPaginas = obra.TotalPaginas,
                    Autor = new AutorDto
                    {
                        Id = obra.Autor.Id,
                        NomeCompleto = obra.Autor.NomeCompleto,
                        Biografia = obra.Autor.Biografia,
                        DataNascimento = obra.Autor.DataNascimento,
                        Nacionalidade = obra.Autor.Nacionalidade,
                    },
                    Categoria = new CategoriaDto
                    {
                        Id = obra.Categoria.Id,
                        Nome = obra.Categoria.Nome,
                    },
                })
                .ToList();

            return Ok(dto);
        }

        // GET: api/Obras/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ObraModel>> GetObraModel(int id)
        {
            var obra = await _context
                .Obras.Include(obra => obra.Autor)
                .Include(obra => obra.Categoria)
                .FirstOrDefaultAsync(obra => obra.Id == id);

            if (obra == null)
            {
                return NotFound();
            }

            var dto = new ObraDto
            {
                Id = obra.Id,
                Nome = obra.Nome,
                DataLancamento = obra.DataLancamento,
                Idioma = obra.Idioma,
                TotalPaginas = obra.TotalPaginas,
                Autor = new AutorDto
                {
                    Id = obra.Autor.Id,
                    NomeCompleto = obra.Autor.NomeCompleto,
                    Biografia = obra.Autor.Biografia,
                    DataNascimento = obra.Autor.DataNascimento,
                    Nacionalidade = obra.Autor.Nacionalidade,
                },
                Categoria = new CategoriaDto { Id = obra.Categoria.Id, Nome = obra.Categoria.Nome },
            };

            return Ok(dto);
        }

        // PUT: api/Obras/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutObraModel(int id, ObraModel obraModel)
        {
            if (id != obraModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(obraModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ObraModelExists(id))
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

        // POST: api/Obras
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ObraDto>> PostObraModel(ObraDto obraDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var obra = new ObraModel
            {
                Nome = obraDto.Nome,
                DataLancamento = obraDto.DataLancamento,
                Idioma = obraDto.Idioma,
                TotalPaginas = obraDto.TotalPaginas,
                AutorId = obraDto.Autor.Id,
                CategoriaId = obraDto.Categoria.Id,
            };

            _context.Obras.Add(obra);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetObraModel", new { id = obra.Id }, obra);
        }

        // DELETE: api/Obras/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteObraModel(int id)
        {
            var obraModel = await _context.Obras.FindAsync(id);
            if (obraModel == null)
            {
                return NotFound();
            }

            _context.Obras.Remove(obraModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ObraModelExists(int id)
        {
            return _context.Obras.Any(e => e.Id == id);
        }
    }
}
