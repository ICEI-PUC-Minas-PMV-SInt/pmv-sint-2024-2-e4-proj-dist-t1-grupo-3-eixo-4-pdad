using Microsoft.EntityFrameworkCore;
using todoz.api.Data;
using todoz.api.Models;

namespace todoz.api.Services.Autor
{
    public class AutorService : iAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context) { 
            _context = context;
        }
        public Task<ResponseModel<AutorModel>> BuscarAutorPorI(int idAutor)
        {
            throw new NotImplementedException();
        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {

                var autores = await _context.Autores.ToListAsync();
                response.Dados = autores;
                response.Mensagem = "Todos os autores foram listados com sucesso!";
                return response;

            }
            catch (Exception ex) { 
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }
    }
}
