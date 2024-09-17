# Especificação de APIs

> A especificação de APIs descreve os principais endpoints da API RESTful do produto
> de software, os métodos HTTP associados a cada endpoint, suas descrições, os formatos
> de respostas, os parâmetros de URL esperados e o mecanismo de autenticação e autorização 
> utilizado.

| Endpoint                             | Método | Descrição                                      | Parâmetros                        | Formato da Resposta | Autenticação e Autorização |
|--------------------------------------|--------|------------------------------------------------|-----------------------------------|---------------------|----------------------------|
| /api/Autor/ListarAutores          | GET    | Listar todos os autores             | -                  | JSON                | JWT Token                  |
| /api/Autor/BuscarAutorPorId/{idAutor}          | GET    | Buscar um autor por ID             | idAutor (int)                  | JSON                | JWT Token                  |
| /api/Autor/BuscarAutorPorIdLivro/{idLivro} | GET   | Buscar um autor por ID de livro                          | idLivro (int) task_id (string) | JSON                | JWT Token                  |
| /api/Autor/CriarAutor | POST    | Criar um novo autor        | - | JSON                | JWT Token                  |
| /api/Autor/EditarAutor | PUT    | Atualizar os dados de um autor | idAutor (string) | JSON                | JWT Token                  |
| /api/Autor/ExcluirAutor | DELETE | Excluir um autor                  | idAutor (int) | JSON                | JWT Token                  |

[Retorna](../README.md)