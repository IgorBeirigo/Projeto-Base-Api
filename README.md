# Projeto Base ASP.NET Core + C# + MySQL

Esse é um projeto base criado com .NET 8, arquitetura em camadas (Domain, Application, Infrastructure e API), com banco de dados MySQL e Entity Framework Core.

## ✅ Tecnologias

- ASP.NET Core 8
- Entity Framework Core
- MySQL (via Pomelo)
- Swagger (OpenAPI)
- Injeção de dependência
- Arquitetura limpa

## 📦 Estrutura

ProjetoBase.Domain
├── Entities
├── Interfaces

ProjetoBase.Application
├── DTOs
├── Interfaces
├── Services

ProjetoBase.Infrastructure
├── Context
├── Repositories

ProjetoBase.Api
├── Controllers
├── Program.cs



## 🚀 Como usar

1. Configure a `DefaultConnection` no `appsettings.json` com seu MySQL local.
2. Rode os comandos:

```bash
dotnet ef migrations add InitialCreate -p ProjetoBase.Infrastructure -s ProjetoBase.Api
dotnet ef database update -p ProjetoBase.Infrastructure -s ProjetoBase.Api
Inicie o projeto e acesse o Swagger:


https://localhost:5001/swagger
👨‍💻 Autor
Igor Beirigo — Projeto base para clonar e expandir sistemas com .NET.
