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
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CadastrarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            var autores = await _autorInterface.CadastrarAutor(autorCriacaoDTO);
            return Ok(autores);
           
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicaoDTO);
            return Ok(autores);

        }

        [HttpDelete("ExcluirAutor")]

        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ExcluirAutor(int idAutor)
        {
            var autores = await _autorInterface.ExcluirAutor(idAutor);
            return Ok(autores);

        }
    }
}
