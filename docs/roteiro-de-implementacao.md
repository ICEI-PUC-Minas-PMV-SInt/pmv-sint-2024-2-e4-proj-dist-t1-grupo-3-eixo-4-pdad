# Roteiro de Implementação.
* As APIs devem ser implementadas na linguagem C# usando o framework .NET Core.
* Os dados da aplicação devem ser armazenados em um banco de dados relacional.
* O frontend deverá se comunicar com o backend via API REST para o conteúdo não estático.
* O código do projeto deve ser armazenado na pasta "src" do repositório.
* O código do front-end deverá ser criado na pasta "src/front-end" e do back-end na pasta "src/back-end"
* O código deverá executar corretamente no ambiente de desenvolvimento, testes e produção.



# Implementação da View de Autores:
* Foi desenvolvida uma view para a gestão de autores, permitindo listar, editar e excluir registros.
* As funcionalidades foram implementadas em JavaScript, que realiza as chamadas à API RESTful.
* Principais funções:
  - **`fetchAutores`**: lista os autores.
  - **`salvarAutor`**: cria ou edita autores.
  - **`editarAutor`**: preenche o formulário com os dados do autor selecionado.
  - **`deletarAutor`**: remove registros de autores.

# Atendendo às Exigências:
* As APIs foram implementadas em C# usando o framework .NET Core.
* A comunicação entre front-end e back-end é realizada via API REST para conteúdo dinâmico.
* Os dados são armazenados em um banco de dados, utilizando o SQLite.
* A estrutura foi organizada em pastas separadas para o backend e frontend, conforme solicitado.
