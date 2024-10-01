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
    public class CategoriasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CategoriasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaModel>>> GetCategorias()
        {
            var categorias = await _context
                .Categorias.Include(categoria => categoria.Obras)
                .ThenInclude(obra => obra.Autor)
                .ToListAsync();

            var dto = categorias
                .Select(categoria => new CategoriaDto
                {
                    Id = categoria.Id,
                    Nome = categoria.Nome,
                    Obras = categoria
                        .Obras.Select(obra => new ObraDto
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
                            },
                        })
                        .ToList(),
                })
                .ToList();

            return Ok(dto);
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> GetCategoriaModel(int id)
        {
            var categoria = await _context
                .Categorias.Include(categoria => categoria.Obras)
                .ThenInclude(obra => obra.Autor)
                .FirstOrDefaultAsync(categoria => categoria.Id == id);

            if (categoria == null)
            {
                return NotFound();
            }

            var dto = new CategoriaDto
            {
                Id = categoria.Id,
                Nome = categoria.Nome,
                Obras = categoria
                    .Obras.Select(obra => new ObraDto
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
                        },
                    })
                    .ToList(),
            };

            return Ok(dto);
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCategoriaModel(int id, CategoriaModel categoriaModel)
        {
            if (id != categoriaModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoriaModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaModelExists(id))
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

        // POST: api/Categorias
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CategoriaModel>> PostCategoriaModel(
            CategoriaModel categoriaModel
        )
        {
            _context.Categorias.Add(categoriaModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                "GetCategoriaModel",
                new { id = categoriaModel.Id },
                categoriaModel
            );
        }

        // DELETE: api/Categorias/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategoriaModel(int id)
        {
            var categoriaModel = await _context.Categorias.FindAsync(id);
            if (categoriaModel == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoriaModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CategoriaModelExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
