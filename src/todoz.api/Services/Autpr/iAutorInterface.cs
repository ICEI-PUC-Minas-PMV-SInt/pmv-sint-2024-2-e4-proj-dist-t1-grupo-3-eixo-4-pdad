using todoz.api.Models;

namespace todoz.api.Services.Autor
{
    public interface iAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorI(int idAutor);

    }
}
