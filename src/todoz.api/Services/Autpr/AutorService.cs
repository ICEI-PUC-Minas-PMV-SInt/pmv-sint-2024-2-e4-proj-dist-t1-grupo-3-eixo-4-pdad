using Microsoft.EntityFrameworkCore;
using todoz.api.Data;
using todoz.api.DTO.Autor;
using todoz.api.Models;

namespace todoz.api.Services.Autor
{
    public class AutorService : iAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context) { 
            _context = context;
        }
        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)

        {
            ResponseModel<AutorModel> response = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                if (autor == null)
                {
                    response.Mensagem = "Nenhum Registro Encontrado";
                    return response;
                }

                response.Dados = autor;
                response.Mensagem = "Autor Localizado";
                return response;
           

            }catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> CadastrarAutor(AutorCriacaoDTO autorCriacaoDTO)
        {
            ResponseModel<List<AutorModel>> response = new ResponseModel<List<AutorModel>>();
            try
            {

                var autor = new AutorModel()
                {
                    NomeCompleto = autorCriacaoDTO.NomeCompleto,
                    DataNascimento = autorCriacaoDTO.DataNascimento,
                    Nacionalidade = autorCriacaoDTO.Nacionalidade,
                    Biografia = autorCriacaoDTO.Biografia
                };

                _context.Add(autor);

                await _context.SaveChangesAsync();

                response.Dados = await _context.Autores.ToListAsync();
                response.Mensagem = "Autor cadastrado com sucesso!";
                return response;

                
            }
            catch (Exception ex) {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
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
