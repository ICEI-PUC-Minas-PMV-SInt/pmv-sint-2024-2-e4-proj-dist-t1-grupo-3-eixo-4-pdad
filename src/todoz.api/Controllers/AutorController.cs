using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
