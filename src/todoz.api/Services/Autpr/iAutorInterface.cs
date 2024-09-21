﻿using todoz.api.DTO.Autor;
using todoz.api.Models;

namespace todoz.api.Services.Autor
{
    public interface iAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);

        Task<ResponseModel<List<AutorModel>>> CadastrarAutor(AutorCriacaoDTO autorCriacaoDTO);

        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDTO autorEdicaoDTO);
        Task<ResponseModel<List<AutorModel>>> ExcluirAutor(int idAutor);

    }
}