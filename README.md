# LocadoraCarros

Este projeto é uma API desenvolvida em .NET 8 para gerenciar uma locadora de carros. Ele utiliza padrões de arquitetura limpa e boas práticas, como FluentValidation para validação de dados, Entity Framework Core para manipulação do banco de dados e AutoMapper para mapeamento de objetos.

# Tecnologias Utilizadas

.NET 8

Entity Framework Core - ORM para interação com o banco de dados

FluentValidation - Biblioteca para validação de dados

AutoMapper - Facilita o mapeamento entre objetos

Migrations - Para controle da evolução do banco de dados

Autenticação - Implementação de login para administradores

Arquitetura Clean - Separação clara entre camadas de domínio, aplicação e infraestrutura

# Estrutura do Projeto

A solução está organizada em quatro camadas principais:

1. API

Contém os controllers para expor os endpoints da aplicação.

Utiliza Controllers para gerenciar as requisições.

Possui um arquivo appsettings.json para configuração.

2. Application

Contém as regras de negócio da aplicação.

Inclui os DTOs, UseCases e Validations.

Utiliza FluentValidation para validar requisições.

3. Domain

Define as entidades principais da aplicação.

Contém Entities, Enums e Contratos.

4. Infrastructure

Contém o acesso ao banco de dados.

Implementa os repositórios e Migrations do Entity Framework.

Configuração do Projeto

1. Clonar o repositório
      git clone https://github.com/seu-usuario/locadora-carros.git

# Autenticação

A API já conta com um sistema de autenticação para administradores. Apenas usuários autorizados poderão acessar determinadas funcionalidades.

Próximos Passos

Criar a interface do usuário utilizando Vue.js.

Criar mais testes automatizados para garantir a qualidade do código.

Contribuição

Se desejar contribuir para o projeto, sinta-se à vontade para abrir uma issue ou criar um pull request.


Desenvolvido por Caroline Freitas Alegre 🚀
