using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using todoz.api.DTO.Autor;
using todoz.api.Models;
using todoz.api.Services.Autor;

namespace todoz.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly iAutorInterface _autorInterface;
        public AutorController(iAutorInterface autorInterface) { 
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpGet("BuscarAutorPorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpPost("CadastrarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> CadastrarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            var autores = await _autorInterface.CadastrarAutor(autorCriacaoDTO);
            return Ok(autores);
           
        }
    }
}
