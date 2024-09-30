# Especificação de APIs

> A especificação de APIs descreve os principais endpoints da API RESTful do produto
> de software, os métodos HTTP associados a cada endpoint, suas descrições, os formatos
> de respostas, os parâmetros de URL esperados e o mecanismo de autenticação e autorização 
> utilizado.

| Endpoint                             | Método | Descrição                                      | Parâmetros                        | Formato da Resposta | Autenticação e Autorização |
|--------------------------------------|--------|------------------------------------------------|-----------------------------------|---------------------|----------------------------|
| /api/users/{user_id}/tasks/          | GET    | Obter todas as tarefas cadastradas             | user_id (string)                  | JSON                | JWT Token                  |
| /api/users/{user_id}/tasks/{task_id} | POST   | Criar uma nova tarefa                          | user_id (string) task_id (string) | JSON                | JWT Token                  |
| /api/users/{user_id}/tasks/{task_id} | GET    | Obter detalhes de uma tarefa específica        | user_id (string) task_id (string) | JSON                | JWT Token                  |
| /api/users/{user_id}/tasks/{task_id} | PUT    | Atualizar os detalhes de uma tarefa específica | user_id (string) task_id (string) | JSON                | JWT Token                  |
| /api/users/{user_id}/tasks/{task_id} | DELETE | Excluir uma tarefa específica                  | user_id (string) task_id (string) | JSON                | JWT Token                  |



# Especificando as APIs que descreve endpoints de uma API RESTful, focada em tarefas associadas a usuários. 

# 1. /api/users/{user_id}/tasks/ (GET)
   - Método: GET
   - Descrição: Obter todas as tarefas cadastradas de um usuário específico.
   - Parâmetros: 
     - `user_id` (string) — ID do usuário.
   - Formato da Resposta: JSON
   - Autenticação: JWT Token

# 2. /api/users/{user_id}/tasks/{task_id} (POST)
   - Método: POST
   - Descrição: Criar uma nova tarefa para um usuário específico.
   - Parâmetros: 
     - `user_id` (string) — ID do usuário.
     - `task_id` (string) — ID da tarefa.
   - Formato da Resposta: JSON
   - Autenticação: JWT Token

# 3. /api/users/{user_id}/tasks/{task_id} (GET)
   - Método: GET
   - Descrição: Obter detalhes de uma tarefa específica.
   - Parâmetros: 
     - `user_id` (string) — ID do usuário.
     - `task_id` (string) — ID da tarefa.
   - Formato da Resposta: JSON
   - Autenticação: JWT Token

# 4. /api/users/{user_id}/tasks/{task_id} (PUT)
   - Método: PUT
   - Descrição: Atualizar os detalhes de uma tarefa específica.
   - Parâmetros: 
     - `user_id` (string) — ID do usuário.
     - `task_id` (string) — ID da tarefa.
   - Formato da Resposta: JSON
   - Autenticação: JWT Token

# 5. /api/users/{user_id}/tasks/{task_id} (DELETE)
   - Método: DELETE
   - Descrição: Excluir uma tarefa específica.
   - Parâmetros: 
     - `user_id` (string) — ID do usuário.
     - `task_id` (string) — ID da tarefa.
   - Formato da Resposta: JSON
   - Autenticação: JWT Token

Essa estrutura é útil para documentar o comportamento e a interação dos consumidores com a API, facilitando a integração e o entendimento para os desenvolvedores e outros stakeholders.

[Retorna](../README.md)
